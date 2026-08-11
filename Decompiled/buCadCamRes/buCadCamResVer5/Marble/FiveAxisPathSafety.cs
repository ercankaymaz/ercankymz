using buCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

#nullable disable
namespace buCadCamResVer5.Marble;

/// <summary>
/// Machine envelope used by the controller-independent path gate. Replace the
/// recovery defaults with the real machine travel and rotary limits before use.
/// </summary>
public sealed class FiveAxisSafetyProfile
{
  public double XMin { get; set; } = double.NegativeInfinity;
  public double XMax { get; set; } = double.PositiveInfinity;
  public double YMin { get; set; } = double.NegativeInfinity;
  public double YMax { get; set; } = double.PositiveInfinity;
  public double ZMin { get; set; } = double.NegativeInfinity;
  public double ZMax { get; set; } = double.PositiveInfinity;
  public double AMin { get; set; } = -370.0;
  public double AMax { get; set; } = 370.0;
  public double BMin { get; set; } = -370.0;
  public double BMax { get; set; } = 370.0;
  public double CMin { get; set; } = -370.0;
  public double CMax { get; set; } = 370.0;
  public double MaxCuttingTiltDelta { get; set; } = 170.0;
}

/// <summary>
/// Final, controller-independent safety gate for generated marble CAM paths.
/// Machine-specific collision simulation and post validation remain mandatory.
/// </summary>
public static class FiveAxisPathSafety
{
  private const int MaxGCodeCharacters = 64 * 1024 * 1024;
  private const int MaxGCodeLineCharacters = 8192;
  private static readonly object ProfileSync = new object();
  private static FiveAxisSafetyProfile activeProfile = new FiveAxisSafetyProfile();
  private static bool hasConfiguredMachineEnvelope;
  private static long configurationRevision;
  private static readonly Regex GCodeWordPattern = new Regex(
    @"(?<![A-Z_])([GFSXYZABC])\s*([+-]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:E[+-]?[0-9]+)?)(?=$|[A-Z/#*\s])",
    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
  private static readonly Regex GCodeAxisMarkerPattern = new Regex(
    @"(?<![A-Z_])([XYZABC])(?=\s*(?:[+\-.0-9#\[]|$))",
    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
  private static readonly Regex GCodeScalarMarkerPattern = new Regex(
    @"(?<![A-Z_])([FS])(?=\s*(?:[+\-.0-9#\[]|$))",
    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
  private static readonly Regex GCodeGMarkerPattern = new Regex(
    @"(?<![A-Z_])(G)(?=\s*(?:[+\-.0-9#\[]|$))",
    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
  private static readonly Regex GCodeUnsupportedAxisMarkerPattern = new Regex(
    @"(?<![A-Z_])([UVW])(?=\s*(?:[+\-.0-9#\[]|$))",
    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
  private static readonly Regex CmdG51DisableScalingPattern = new Regex(
    @"^\s*(?:N\s*[0-9]+\s+)?G\s*51(?:\.0+)?\s+D\s*[+-]?0+(?:\.0+)?\s*$",
    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
  private static readonly Regex CmdG20JumpPattern = new Regex(
    @"^\s*(?:N\s*[0-9]+\s+)?G\s*20(?:\.0+)?\s+L\s*(?:[0-9]+|\$JMP\$)\s+K\s*(?:[0-9]+|\$GOJMP\$)\s*$",
    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
  private static readonly Regex GCodeDMarkerPattern = new Regex(
    @"(?<![A-Z_])D(?=\s*(?:[+\-.0-9#\[]|$))",
    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

  /// <summary>
  /// Active machine profile. Machine initialization should replace the recovery
  /// defaults with measured travels and the controller-approved rotary limits.
  /// </summary>
  public static FiveAxisSafetyProfile ActiveProfile
  {
    get
    {
      lock (ProfileSync)
        return CloneProfile(activeProfile);
    }
  }

  public static bool HasConfiguredMachineEnvelope
  {
    get
    {
      lock (ProfileSync)
        return hasConfiguredMachineEnvelope;
    }
  }

  /// <summary>
  /// Process-local revision of the verified machine envelope. Cached CAM/G-code
  /// must be regenerated whenever this value changes.
  /// </summary>
  public static long ConfigurationRevision
  {
    get
    {
      lock (ProfileSync)
        return configurationRevision;
    }
  }

  public static void Configure(FiveAxisSafetyProfile profile)
  {
    if (profile == null)
      throw new InvalidOperationException("Five-axis machine safety profile is null.");
    ValidateConfiguredProfile(profile);
    FiveAxisSafetyProfile snapshot = CloneProfile(profile);
    lock (ProfileSync)
    {
      bool profileChanged = !hasConfiguredMachineEnvelope || !ProfilesEqual(activeProfile, snapshot);
      activeProfile = snapshot;
      hasConfiguredMachineEnvelope = true;
      if (profileChanged)
      {
        unchecked
        {
          ++configurationRevision;
          if (configurationRevision <= 0)
            configurationRevision = 1;
        }
      }
    }
  }

  public static void ClearConfiguration()
  {
    lock (ProfileSync)
    {
      bool profileWasConfigured = hasConfiguredMachineEnvelope;
      activeProfile = new FiveAxisSafetyProfile();
      hasConfiguredMachineEnvelope = false;
      if (profileWasConfigured)
      {
        unchecked
        {
          ++configurationRevision;
          if (configurationRevision <= 0)
            configurationRevision = 1;
        }
      }
    }
  }

  public static void ValidateAndNormalize(List<camTp> cams)
  {
    ValidateAndNormalize(cams, GetConfiguredActiveProfile());
  }

  public static void ValidateAndNormalize(List<camTp> cams, FiveAxisSafetyProfile profile)
  {
    if (cams == null)
      throw new InvalidOperationException("CAM path collection is null.");
    if (profile == null)
      throw new InvalidOperationException("Five-axis machine safety profile is null.");
    ValidateProfile(profile);

    bool hasPreviousPoint = false;
    double previousA = 0.0;
    double previousB = 0.0;
    double previousC = 0.0;

    for (int camIndex = 0; camIndex < cams.Count; ++camIndex)
    {
      camTp cam = cams[camIndex];
      if (cam == null)
        throw CamError(camIndex, "CAM entry is null");
      if (!cam.Enable)
        continue;
      if (cam.CamPoints == null)
        throw CamError(camIndex, "CAM point collection is null");
      bool hasMotionPoints = false;
      for (int segmentIndex = 0; segmentIndex < cam.CamPoints.Count; ++segmentIndex)
      {
        if (cam.CamPoints[segmentIndex] == null)
          throw SegmentError(camIndex, segmentIndex, "CAM segment is null");
        if (cam.CamPoints[segmentIndex].Points == null)
          throw SegmentError(camIndex, segmentIndex, "CAM segment point collection is null");
        if (cam.CamPoints[segmentIndex].Points.Count > 0)
          hasMotionPoints = true;
      }
      if (hasMotionPoints && cam.Tool == null)
        throw CamError(camIndex, "CAM contains motion but has no verified tool");

      FiveAxisSafetyProfile effectiveProfile = CreateEffectiveProfile(profile, cam, camIndex);
      bool hasPreviousPointInCam = false;

      for (int segmentIndex = 0; segmentIndex < cam.CamPoints.Count; ++segmentIndex)
      {
        for (int pointIndex = 0; pointIndex < cam.CamPoints[segmentIndex].Points.Count; ++pointIndex)
        {
          TpPnt9D point = cam.CamPoints[segmentIndex].Points[pointIndex];
          if (point == null)
            throw PathError(camIndex, segmentIndex, pointIndex, "CAM point is null");

          ValidateFinite(point.P9.X, "X", camIndex, segmentIndex, pointIndex);
          ValidateFinite(point.P9.Y, "Y", camIndex, segmentIndex, pointIndex);
          ValidateFinite(point.P9.Z, "Z", camIndex, segmentIndex, pointIndex);
          ValidateFinite(point.P9.A, "A", camIndex, segmentIndex, pointIndex);
          ValidateFinite(point.P9.B, "B", camIndex, segmentIndex, pointIndex);
          ValidateFinite(point.P9.C, "C", camIndex, segmentIndex, pointIndex);
          ValidateFinite(point.Feed, "Feed", camIndex, segmentIndex, pointIndex);

          if (point.Feed < 0.0 || (point.Type != 0 && point.Feed <= 0.0))
            throw PathError(camIndex, segmentIndex, pointIndex, "Cutting feed must be positive");
          ValidateRange(point.P9.X, effectiveProfile.XMin, effectiveProfile.XMax, "X", camIndex, segmentIndex, pointIndex);
          ValidateRange(point.P9.Y, effectiveProfile.YMin, effectiveProfile.YMax, "Y", camIndex, segmentIndex, pointIndex);
          ValidateRange(point.P9.Z, effectiveProfile.ZMin, effectiveProfile.ZMax, "Z", camIndex, segmentIndex, pointIndex);
          ValidateRange(point.P9.A, effectiveProfile.AMin, effectiveProfile.AMax, "A", camIndex, segmentIndex, pointIndex);
          ValidateRange(point.P9.B, effectiveProfile.BMin, effectiveProfile.BMax, "B", camIndex, segmentIndex, pointIndex);

          if (hasPreviousPoint)
            point.P9.C = ResolveEquivalentC(point.P9.C, previousC, effectiveProfile, camIndex, segmentIndex, pointIndex);
          else if (point.P9.C < effectiveProfile.CMin || point.P9.C > effectiveProfile.CMax)
            point.P9.C = ResolveEquivalentC(point.P9.C, 0.0, effectiveProfile, camIndex, segmentIndex, pointIndex);

          // Type 0 is a rapid/link move in the recovered CAM model. Large tilt flips
          // during a cutting move are rejected; they must be resolved by kinematics
          // or split into a retract/reorientation/approach sequence.
          if (hasPreviousPointInCam && point.Type != 0)
          {
            if (Math.Abs(point.P9.A - previousA) > effectiveProfile.MaxCuttingTiltDelta)
              throw PathError(camIndex, segmentIndex, pointIndex, "Unsafe A-axis flip in cutting motion");
            if (Math.Abs(point.P9.B - previousB) > effectiveProfile.MaxCuttingTiltDelta)
              throw PathError(camIndex, segmentIndex, pointIndex, "Unsafe B-axis flip in cutting motion");
          }

          previousA = point.P9.A;
          previousB = point.P9.B;
          previousC = point.P9.C;
          hasPreviousPoint = true;
          hasPreviousPointInCam = true;
        }
      }
    }

    // PreCodes-only CAM objects are used by supported external G-code import
    // flows. Their final output is checked by ValidateGCode after postprocessing.
  }

  public static void ValidateGCode(string gCode)
  {
    ValidateGCode(gCode, GetConfiguredActiveProfile());
  }

  public static void ValidateGCode(string gCode, FiveAxisSafetyProfile profile)
  {
    if (string.IsNullOrWhiteSpace(gCode))
      throw new InvalidOperationException("Postprocessor generated empty G-code.");
    if (gCode.Length > MaxGCodeCharacters)
      throw new InvalidOperationException("Postprocessor output exceeds the 64 MiB G-code safety limit.");
    if (profile == null)
      throw new InvalidOperationException("Five-axis machine safety profile is null.");
    ValidateProfile(profile);

    string[] lines = gCode.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');
    bool absoluteMode = true;
    double unitScale = 1.0;
    int totalParsedAxisWordCount = 0;
    Dictionary<char, double> knownPositions = new Dictionary<char, double>();
    for (int lineIndex = 0; lineIndex < lines.Length; ++lineIndex)
    {
      string line = lines[lineIndex];
      if (line.Length > MaxGCodeLineCharacters)
        throw new InvalidOperationException(
          string.Format(CultureInfo.InvariantCulture, "Postprocessor generated an overlong G-code block at line {0}.", lineIndex + 1));
      string executableLine = StripGCodeComments(line, lineIndex);
      if (executableLine.IndexOf("NaN", StringComparison.OrdinalIgnoreCase) >= 0 ||
          executableLine.IndexOf("Infinity", StringComparison.OrdinalIgnoreCase) >= 0)
        throw new InvalidOperationException(
          string.Format(
            System.Globalization.CultureInfo.InvariantCulture,
            "Postprocessor generated a non-finite numeric token at line {0}.",
            lineIndex + 1));

      MatchCollection wordMatches = GCodeWordPattern.Matches(executableLine);
      bool blockAbsoluteMode = absoluteMode;
      double blockUnitScale = unitScale;
      bool sawAbsoluteMode = false;
      bool sawIncrementalMode = false;
      bool sawMetricUnits = false;
      bool sawInchUnits = false;
      bool cmdG51DisableScaling = CmdG51DisableScalingPattern.IsMatch(executableLine);
      bool cmdG20Jump = CmdG20JumpPattern.IsMatch(executableLine);
      int parsedGWordCount = 0;
      for (int wordIndex = 0; wordIndex < wordMatches.Count; ++wordIndex)
      {
        char word = char.ToUpperInvariant(wordMatches[wordIndex].Groups[1].Value[0]);
        if (word != 'G')
          continue;
        ++parsedGWordCount;

        double value;
        if (!double.TryParse(wordMatches[wordIndex].Groups[2].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out value) ||
            double.IsNaN(value) || double.IsInfinity(value))
          throw new InvalidOperationException(
            string.Format(CultureInfo.InvariantCulture, "Postprocessor generated an invalid G-word value at line {0}.", lineIndex + 1));

        string unsupportedReason = GetUnsupportedGCodeReason(value, cmdG51DisableScaling);
        if (unsupportedReason != null)
          throw new InvalidOperationException(
            string.Format(
              CultureInfo.InvariantCulture,
              "Cannot validate G{0} safely at line {1}: {2}.",
              value.ToString("0.###", CultureInfo.InvariantCulture),
              lineIndex + 1,
              unsupportedReason));

        if (value == 90.0)
        {
          blockAbsoluteMode = true;
          sawAbsoluteMode = true;
        }
        else if (value == 91.0)
        {
          blockAbsoluteMode = false;
          sawIncrementalMode = true;
        }
        else if (value == 21.0)
        {
          blockUnitScale = 1.0;
          sawMetricUnits = true;
        }
        else if (value == 20.0 && !cmdG20Jump)
        {
          blockUnitScale = 25.4;
          sawInchUnits = true;
        }
      }

      if (sawAbsoluteMode && sawIncrementalMode)
        throw new InvalidOperationException(
          string.Format(CultureInfo.InvariantCulture, "G90 and G91 conflict in the same block at line {0}.", lineIndex + 1));
      if (sawMetricUnits && sawInchUnits)
        throw new InvalidOperationException(
          string.Format(CultureInfo.InvariantCulture, "G20 and G21 conflict in the same block at line {0}.", lineIndex + 1));

      absoluteMode = blockAbsoluteMode;
      unitScale = blockUnitScale;
      int parsedAxisWordCount = 0;
      int parsedScalarWordCount = 0;
      HashSet<char> seenAxisAndScalarWords = new HashSet<char>();
      for (int wordIndex = 0; wordIndex < wordMatches.Count; ++wordIndex)
      {
        char word = char.ToUpperInvariant(wordMatches[wordIndex].Groups[1].Value[0]);
        double value;
        if (!double.TryParse(wordMatches[wordIndex].Groups[2].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out value) ||
            double.IsNaN(value) || double.IsInfinity(value))
          throw new InvalidOperationException(
            string.Format(CultureInfo.InvariantCulture, "Postprocessor generated an invalid {0}-word value at line {1}.", word, lineIndex + 1));

        if (word == 'G')
          continue;
        if (word == 'F' || word == 'S')
        {
          if (!seenAxisAndScalarWords.Add(word))
            throw new InvalidOperationException(
              string.Format(CultureInfo.InvariantCulture, "Postprocessor generated duplicate {0}-words at line {1}.", word, lineIndex + 1));
          ++parsedScalarWordCount;
          if (word == 'F' && value <= 0.0)
            throw new InvalidOperationException(
              string.Format(CultureInfo.InvariantCulture, "Postprocessor generated a non-positive feed at line {0}.", lineIndex + 1));
          if (word == 'S' && value < 0.0)
            throw new InvalidOperationException(
              string.Format(CultureInfo.InvariantCulture, "Postprocessor generated a negative spindle speed at line {0}.", lineIndex + 1));
          continue;
        }

        char axis = word;
        if (!seenAxisAndScalarWords.Add(axis))
          throw new InvalidOperationException(
            string.Format(CultureInfo.InvariantCulture, "Postprocessor generated duplicate {0}-axis words at line {1}.", axis, lineIndex + 1));
        ++parsedAxisWordCount;
        ++totalParsedAxisWordCount;

        double commandValue = axis == 'X' || axis == 'Y' || axis == 'Z'
          ? value * unitScale
          : value;
        double target = commandValue;
        if (!absoluteMode)
        {
          double current;
          if (!knownPositions.TryGetValue(axis, out current))
            throw new InvalidOperationException(
              string.Format(
                CultureInfo.InvariantCulture,
                "Cannot validate incremental {0}-axis motion before an absolute position is known at line {1}.",
                axis,
                lineIndex + 1));
          target = current + commandValue;
        }

        ValidateGCodeAxisRange(axis, target, profile, lineIndex);
        knownPositions[axis] = target;
      }

      if (GCodeAxisMarkerPattern.Matches(executableLine).Count != parsedAxisWordCount)
        throw new InvalidOperationException(
          string.Format(
            CultureInfo.InvariantCulture,
            "Cannot validate a non-literal or malformed XYZ/ABC word at line {0}.",
            lineIndex + 1));
      if (GCodeScalarMarkerPattern.Matches(executableLine).Count != parsedScalarWordCount)
        throw new InvalidOperationException(
          string.Format(
            CultureInfo.InvariantCulture,
            "Cannot validate a non-literal or malformed F/S word at line {0}.",
            lineIndex + 1));
      if (GCodeGMarkerPattern.Matches(executableLine).Count != parsedGWordCount)
        throw new InvalidOperationException(
          string.Format(
            CultureInfo.InvariantCulture,
            "Cannot validate a non-literal or malformed G word at line {0}.",
            lineIndex + 1));
      if (GCodeDMarkerPattern.IsMatch(executableLine) && !cmdG51DisableScaling)
        throw new InvalidOperationException(
          string.Format(
            CultureInfo.InvariantCulture,
            "Cannot validate a D word outside the exact CMD 'G51 D0' scaling-disable block at line {0}.",
            lineIndex + 1));
      Match unsupportedAxis = GCodeUnsupportedAxisMarkerPattern.Match(executableLine);
      if (unsupportedAxis.Success)
        throw new InvalidOperationException(
          string.Format(
            CultureInfo.InvariantCulture,
            "Cannot validate unsupported {0}-axis motion at line {1}; only XYZ/ABC are configured.",
            unsupportedAxis.Groups[1].Value.ToUpperInvariant(),
            lineIndex + 1));

      for (int charIndex = 0; charIndex < line.Length; ++charIndex)
      {
        char value = line[charIndex];
        if (char.IsControl(value) && value != '\t')
          throw new InvalidOperationException(
            string.Format(
              System.Globalization.CultureInfo.InvariantCulture,
              "Postprocessor generated an invalid control character at line {0}.",
              lineIndex + 1));
      }
    }
    if (totalParsedAxisWordCount == 0)
      throw new InvalidOperationException("Postprocessor output contains no literal XYZ/ABC motion words.");
  }

  private static FiveAxisSafetyProfile CreateEffectiveProfile(
    FiveAxisSafetyProfile machineProfile,
    camTp cam,
    int camIndex)
  {
    FiveAxisSafetyProfile effective = CloneProfile(machineProfile);

    if (cam.Tool == null)
      return effective;

    ApplyToolRange(ref effective.XMin, ref effective.XMax, cam.Tool.Limits.AxesMinLimits.X, cam.Tool.Limits.AxesMaxLimits.X, "X", camIndex);
    ApplyToolRange(ref effective.YMin, ref effective.YMax, cam.Tool.Limits.AxesMinLimits.Y, cam.Tool.Limits.AxesMaxLimits.Y, "Y", camIndex);
    ApplyToolRange(ref effective.ZMin, ref effective.ZMax, cam.Tool.Limits.AxesMinLimits.Z, cam.Tool.Limits.AxesMaxLimits.Z, "Z", camIndex);
    ApplyToolRange(ref effective.AMin, ref effective.AMax, cam.Tool.Limits.AxesMinLimits.A, cam.Tool.Limits.AxesMaxLimits.A, "A", camIndex);
    ApplyToolRange(ref effective.BMin, ref effective.BMax, cam.Tool.Limits.AxesMinLimits.B, cam.Tool.Limits.AxesMaxLimits.B, "B", camIndex);
    ApplyToolRange(ref effective.CMin, ref effective.CMax, cam.Tool.Limits.AxesMinLimits.C, cam.Tool.Limits.AxesMaxLimits.C, "C", camIndex);
    return effective;
  }

  private static FiveAxisSafetyProfile CloneProfile(FiveAxisSafetyProfile profile)
  {
    return new FiveAxisSafetyProfile()
    {
      XMin = profile.XMin,
      XMax = profile.XMax,
      YMin = profile.YMin,
      YMax = profile.YMax,
      ZMin = profile.ZMin,
      ZMax = profile.ZMax,
      AMin = profile.AMin,
      AMax = profile.AMax,
      BMin = profile.BMin,
      BMax = profile.BMax,
      CMin = profile.CMin,
      CMax = profile.CMax,
      MaxCuttingTiltDelta = profile.MaxCuttingTiltDelta
    };
  }

  private static bool ProfilesEqual(FiveAxisSafetyProfile first, FiveAxisSafetyProfile second)
  {
    return first.XMin == second.XMin && first.XMax == second.XMax &&
           first.YMin == second.YMin && first.YMax == second.YMax &&
           first.ZMin == second.ZMin && first.ZMax == second.ZMax &&
           first.AMin == second.AMin && first.AMax == second.AMax &&
           first.BMin == second.BMin && first.BMax == second.BMax &&
           first.CMin == second.CMin && first.CMax == second.CMax &&
           first.MaxCuttingTiltDelta == second.MaxCuttingTiltDelta;
  }

  private static void ApplyToolRange(
    ref double effectiveMinimum,
    ref double effectiveMaximum,
    double toolMinimum,
    double toolMaximum,
    string axis,
    int camIndex)
  {
    if (double.IsNaN(toolMinimum) || double.IsNaN(toolMaximum) ||
        double.IsInfinity(toolMinimum) || double.IsInfinity(toolMaximum))
      throw CamError(camIndex, axis + " tool envelope contains a non-finite value");
    if (toolMinimum > toolMaximum)
      throw CamError(camIndex, axis + " tool envelope is inverted");

    // Equal legacy values mean that the per-tool envelope was not configured.
    // A configured range is intersected with the machine-wide safety profile.
    if (toolMinimum == toolMaximum)
      return;

    effectiveMinimum = Math.Max(effectiveMinimum, toolMinimum);
    effectiveMaximum = Math.Min(effectiveMaximum, toolMaximum);
    if (effectiveMinimum > effectiveMaximum)
      throw CamError(camIndex, axis + " tool envelope does not intersect the machine envelope");
  }

  private static string StripGCodeComments(string line, int lineIndex)
  {
    StringBuilder result = new StringBuilder(line.Length);
    int parenthesisDepth = 0;
    for (int index = 0; index < line.Length; ++index)
    {
      char value = line[index];
      if (value == ';' && parenthesisDepth == 0)
        break;
      if (value == '(')
      {
        if (parenthesisDepth != 0)
          throw new InvalidOperationException(
            string.Format(CultureInfo.InvariantCulture, "Nested G-code comment at line {0} cannot be validated safely.", lineIndex + 1));
        ++parenthesisDepth;
        continue;
      }
      if (value == ')')
      {
        if (parenthesisDepth == 0)
          throw new InvalidOperationException(
            string.Format(CultureInfo.InvariantCulture, "Unmatched G-code comment terminator at line {0}.", lineIndex + 1));
        --parenthesisDepth;
        continue;
      }
      if (parenthesisDepth == 0)
        result.Append(value);
    }
    if (parenthesisDepth != 0)
      throw new InvalidOperationException(
        string.Format(CultureInfo.InvariantCulture, "Unterminated G-code comment at line {0}.", lineIndex + 1));
    return result.ToString();
  }

  private static string GetUnsupportedGCodeReason(double code, bool cmdG51DisableScaling)
  {
    if (code == 2.0 || code == 3.0)
      return "arc extrema are not proven by endpoint-only validation";
    if (code == 51.0 && !cmdG51DisableScaling)
      return "only the exact controller-approved 'G51 D0' scaling-disable block is supported";
    if (code == 10.0 || code == 52.0 || code == 68.0 || code == 92.0)
      return "coordinate transformation or offset mutation requires controller-specific proof";
    if (code == 28.0 || code == 30.0)
      return "the controller reference-return endpoint is not present in the program";
    if (code == 41.0 || code == 42.0)
      return "cutter compensation can move the tool outside the programmed path";
    if (code == 43.0 || code == 44.0)
      return "tool-length compensation requires a verified controller tool table and kinematic model";
    return null;
  }

  private static void ValidateGCodeAxisRange(
    char axis,
    double value,
    FiveAxisSafetyProfile profile,
    int lineIndex)
  {
    double minimum;
    double maximum;
    switch (axis)
    {
      case 'X': minimum = profile.XMin; maximum = profile.XMax; break;
      case 'Y': minimum = profile.YMin; maximum = profile.YMax; break;
      case 'Z': minimum = profile.ZMin; maximum = profile.ZMax; break;
      case 'A': minimum = profile.AMin; maximum = profile.AMax; break;
      case 'B': minimum = profile.BMin; maximum = profile.BMax; break;
      default: minimum = profile.CMin; maximum = profile.CMax; break;
    }

    if (value < minimum || value > maximum)
      throw new InvalidOperationException(
        string.Format(
          CultureInfo.InvariantCulture,
          "Postprocessor generated {0}{1} outside the configured machine envelope at line {2}.",
          axis,
          value,
          lineIndex + 1));
  }

  private static double ResolveEquivalentC(
    double rawAngle,
    double previousAngle,
    FiveAxisSafetyProfile profile,
    int camIndex,
    int segmentIndex,
    int pointIndex)
  {
    double resolved = 0.0;
    double bestDelta = double.MaxValue;
    bool found = false;

    double centerTurn = Math.Round((previousAngle - rawAngle) / 360.0);
    for (int offset = -2; offset <= 2; ++offset)
    {
      double candidate = rawAngle + (centerTurn + offset) * 360.0;
      if (candidate < profile.CMin || candidate > profile.CMax)
        continue;

      double delta = Math.Abs(candidate - previousAngle);
      if (delta < bestDelta)
      {
        resolved = candidate;
        bestDelta = delta;
        found = true;
      }
    }

    if (!found)
      throw PathError(camIndex, segmentIndex, pointIndex, "C axis has no equivalent angle inside the rotary envelope");

    return resolved;
  }

  private static void ValidateProfile(FiveAxisSafetyProfile profile)
  {
    if (double.IsNaN(profile.XMin) || double.IsNaN(profile.XMax) ||
        double.IsNaN(profile.YMin) || double.IsNaN(profile.YMax) ||
        double.IsNaN(profile.ZMin) || double.IsNaN(profile.ZMax) ||
        double.IsNaN(profile.AMin) || double.IsNaN(profile.AMax) ||
        double.IsNaN(profile.BMin) || double.IsNaN(profile.BMax) ||
        double.IsNaN(profile.CMin) || double.IsNaN(profile.CMax))
      throw new InvalidOperationException("Five-axis machine profile contains a non-numeric axis limit.");
    if (profile.XMin > profile.XMax || profile.YMin > profile.YMax || profile.ZMin > profile.ZMax ||
        profile.AMin > profile.AMax || profile.BMin > profile.BMax || profile.CMin > profile.CMax)
      throw new InvalidOperationException("Five-axis machine profile contains an inverted axis range.");
    if (double.IsNaN(profile.MaxCuttingTiltDelta) || double.IsInfinity(profile.MaxCuttingTiltDelta) ||
        profile.MaxCuttingTiltDelta <= 0.0 || profile.MaxCuttingTiltDelta > 180.0)
      throw new InvalidOperationException("Five-axis machine profile has an invalid cutting tilt delta.");
  }

  internal static void ValidateConfiguredProfile(FiveAxisSafetyProfile profile)
  {
    ValidateProfile(profile);
    if (double.IsInfinity(profile.XMin) || double.IsInfinity(profile.XMax) ||
        double.IsInfinity(profile.YMin) || double.IsInfinity(profile.YMax) ||
        double.IsInfinity(profile.ZMin) || double.IsInfinity(profile.ZMax) ||
        double.IsInfinity(profile.AMin) || double.IsInfinity(profile.AMax) ||
        double.IsInfinity(profile.BMin) || double.IsInfinity(profile.BMax) ||
        double.IsInfinity(profile.CMin) || double.IsInfinity(profile.CMax))
      throw new InvalidOperationException("Configured XYZ/ABC machine limits must be finite.");
    if (profile.XMin >= profile.XMax || profile.YMin >= profile.YMax || profile.ZMin >= profile.ZMax)
      throw new InvalidOperationException("Configured XYZ machine limits must define a positive travel range.");
  }

  private static FiveAxisSafetyProfile GetConfiguredActiveProfile()
  {
    lock (ProfileSync)
    {
      if (!hasConfiguredMachineEnvelope)
        throw new InvalidOperationException(
          "XYZ/ABC machine limits are not configured. Open the tool Limits tab and save the verified values as Machine Limits before generating production G-code.");
      return CloneProfile(activeProfile);
    }
  }

  private static void ValidateRange(
    double value,
    double minimum,
    double maximum,
    string axis,
    int camIndex,
    int segmentIndex,
    int pointIndex)
  {
    if (value < minimum || value > maximum)
      throw PathError(camIndex, segmentIndex, pointIndex, axis + " exceeds the configured machine envelope");
  }

  private static void ValidateFinite(
    double value,
    string axis,
    int camIndex,
    int segmentIndex,
    int pointIndex)
  {
    if (double.IsNaN(value) || double.IsInfinity(value))
      throw PathError(camIndex, segmentIndex, pointIndex, axis + " is not finite");
  }

  private static InvalidOperationException PathError(
    int camIndex,
    int segmentIndex,
    int pointIndex,
    string message)
  {
    return new InvalidOperationException(
      string.Format(
        System.Globalization.CultureInfo.InvariantCulture,
        "5-axis safety validation failed at CAM {0}, segment {1}, point {2}: {3}.",
        camIndex + 1,
        segmentIndex + 1,
        pointIndex + 1,
        message));
  }

  private static InvalidOperationException CamError(int camIndex, string message)
  {
    return new InvalidOperationException(
      string.Format(
        CultureInfo.InvariantCulture,
        "5-axis safety validation failed at CAM {0}: {1}.",
        camIndex + 1,
        message));
  }

  private static InvalidOperationException SegmentError(int camIndex, int segmentIndex, string message)
  {
    return new InvalidOperationException(
      string.Format(
        CultureInfo.InvariantCulture,
        "5-axis safety validation failed at CAM {0}, segment {1}: {2}.",
        camIndex + 1,
        segmentIndex + 1,
        message));
  }
}

/// <summary>
/// Versioned, user-settings persistence for the machine-wide XYZ/ABC envelope.
/// Unknown keys are ignored for forward compatibility; all required keys must
/// be present and valid before the active safety profile is changed.
/// </summary>
public static class FiveAxisSafetyProfileStore
{
  private const string ProfileFileName = "FiveAxisSafety.prm";
  private const string CurrentVersion = "2";
  private const int MaxSettingsDirectories = 1024;
  private const int MaxSettingsFiles = 8192;
  private static readonly string[] ProfileDataKeys = new string[]
  {
    "Version", "XMin", "XMax", "YMin", "YMax", "ZMin", "ZMax",
    "AMin", "AMax", "BMin", "BMax", "CMin", "CMax", "MaxCuttingTiltDelta"
  };

  public static string GetDefaultFilePath(string settingsDirectory)
  {
    if (string.IsNullOrWhiteSpace(settingsDirectory))
      throw new ArgumentException("Settings directory is empty.", nameof(settingsDirectory));
    return Path.Combine(settingsDirectory, ProfileFileName);
  }

  /// <summary>
  /// Loads the active envelope from the complete Settings trees. The signed
  /// FiveAxisSafety profile, when present, must be contained by both the PLC
  /// and application soft limits. Old, Backup and Temp trees are never active.
  /// </summary>
  public static bool TryLoadFromSettings(
    string settingsDirectory,
    string machineSettingsDirectory,
    string baseDirectory,
    out FiveAxisSafetyProfile profile,
    out string sourceSummary)
  {
    profile = null;
    sourceSummary = string.Empty;
    List<string> roots = BuildSettingsRoots(settingsDirectory, machineSettingsDirectory);
    if (roots.Count == 0)
      return false;

    string controllerSummary;
    FiveAxisSafetyProfile controllerProfile = LoadControllerProfile(roots, baseDirectory, out controllerSummary);
    List<string> savedProfiles = FindSettingsFiles(roots, ProfileFileName);
    FiveAxisSafetyProfile selectedProfile = null;
    for (int index = 0; index < savedProfiles.Count; ++index)
    {
      FiveAxisSafetyProfile candidate;
      if (!TryLoad(savedProfiles[index], out candidate))
        continue;
      if (selectedProfile != null && !ProfilesEqual(selectedProfile, candidate))
        throw new InvalidDataException("Conflicting active FiveAxisSafety.prm files were found in the Settings trees.");
      selectedProfile = candidate;
    }

    if (selectedProfile == null)
    {
      selectedProfile = controllerProfile;
      sourceSummary = "Controller settings: " + controllerSummary;
    }
    else
    {
      EnsureContainedByController(selectedProfile, controllerProfile);
      sourceSummary = "FiveAxisSafety.prm + " + controllerSummary;
    }

    ValidateConfiguredProfileForStore(selectedProfile);
    profile = CloneProfile(selectedProfile);
    return true;
  }

  public static void ValidateAgainstControllerSettings(
    string settingsDirectory,
    string machineSettingsDirectory,
    string baseDirectory,
    FiveAxisSafetyProfile profile,
    out string sourceSummary)
  {
    if (profile == null)
      throw new ArgumentNullException(nameof(profile));
    List<string> roots = BuildSettingsRoots(settingsDirectory, machineSettingsDirectory);
    if (roots.Count == 0)
      throw new InvalidDataException("No active Settings directory is available for machine-limit verification.");
    FiveAxisSafetyProfile controllerProfile = LoadControllerProfile(roots, baseDirectory, out sourceSummary);
    EnsureContainedByController(profile, controllerProfile);
  }

  public static void Save(string filePath, FiveAxisSafetyProfile profile)
  {
    if (string.IsNullOrWhiteSpace(filePath))
      throw new ArgumentException("Machine-profile file path is empty.", nameof(filePath));
    if (profile == null)
      throw new ArgumentNullException(nameof(profile));

    FiveAxisPathSafety.ValidateConfiguredProfile(profile);
    string directory = Path.GetDirectoryName(filePath);
    if (string.IsNullOrWhiteSpace(directory))
      throw new InvalidOperationException("Machine-profile directory is invalid.");
    Directory.CreateDirectory(directory);

    string[] dataLines = new string[]
    {
      "Version=" + CurrentVersion,
      "XMin=" + profile.XMin.ToString("R", CultureInfo.InvariantCulture),
      "XMax=" + profile.XMax.ToString("R", CultureInfo.InvariantCulture),
      "YMin=" + profile.YMin.ToString("R", CultureInfo.InvariantCulture),
      "YMax=" + profile.YMax.ToString("R", CultureInfo.InvariantCulture),
      "ZMin=" + profile.ZMin.ToString("R", CultureInfo.InvariantCulture),
      "ZMax=" + profile.ZMax.ToString("R", CultureInfo.InvariantCulture),
      "AMin=" + profile.AMin.ToString("R", CultureInfo.InvariantCulture),
      "AMax=" + profile.AMax.ToString("R", CultureInfo.InvariantCulture),
      "BMin=" + profile.BMin.ToString("R", CultureInfo.InvariantCulture),
      "BMax=" + profile.BMax.ToString("R", CultureInfo.InvariantCulture),
      "CMin=" + profile.CMin.ToString("R", CultureInfo.InvariantCulture),
      "CMax=" + profile.CMax.ToString("R", CultureInfo.InvariantCulture),
      "MaxCuttingTiltDelta=" + profile.MaxCuttingTiltDelta.ToString("R", CultureInfo.InvariantCulture)
    };
    string[] lines = new string[dataLines.Length + 1];
    Array.Copy(dataLines, lines, dataLines.Length);
    lines[lines.Length - 1] = "Checksum=" + ComputeSha256(string.Join("\n", dataLines) + "\n");

    string temporaryFile = filePath + ".tmp";
    try
    {
      File.WriteAllLines(temporaryFile, lines, new UTF8Encoding(false));
      if (File.Exists(filePath))
        File.Replace(temporaryFile, filePath, filePath + ".bak", true);
      else
        File.Move(temporaryFile, filePath);
    }
    finally
    {
      if (File.Exists(temporaryFile))
        File.Delete(temporaryFile);
    }
  }

  public static bool TryLoad(string filePath, out FiveAxisSafetyProfile profile)
  {
    profile = null;
    if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
      return false;

    FileInfo profileFile = new FileInfo(filePath);
    if (profileFile.Length > 65536L)
      throw new InvalidDataException("Machine-profile file exceeds the 64 KiB safety limit.");

    Dictionary<string, string> values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    string[] lines = File.ReadAllLines(filePath);
    if (lines.Length > 128)
      throw new InvalidDataException("Machine-profile file contains too many entries.");
    for (int index = 0; index < lines.Length; ++index)
    {
      string line = lines[index].Trim();
      if (line.Length == 0 || line.StartsWith("#", StringComparison.Ordinal))
        continue;
      int separator = line.IndexOf('=');
      if (separator <= 0 || separator == line.Length - 1)
        throw new InvalidDataException("Invalid machine-profile entry at line " + (index + 1) + ".");
      string key = line.Substring(0, separator).Trim();
      if (values.ContainsKey(key))
        throw new InvalidDataException("Duplicate machine-profile key " + key + " at line " + (index + 1) + ".");
      values.Add(key, line.Substring(separator + 1).Trim());
    }

    string version;
    if (!values.TryGetValue("Version", out version) || version != CurrentVersion)
      throw new InvalidDataException("Unsupported or missing machine-profile version.");

    string suppliedChecksum;
    if (!values.TryGetValue("Checksum", out suppliedChecksum) ||
        !string.Equals(suppliedChecksum, ComputeSha256(BuildChecksumPayload(values)), StringComparison.OrdinalIgnoreCase))
      throw new InvalidDataException("Machine-profile checksum is missing or does not match its XYZ/ABC safety values.");

    FiveAxisSafetyProfile loaded = new FiveAxisSafetyProfile()
    {
      XMin = ReadRequiredDouble(values, "XMin"),
      XMax = ReadRequiredDouble(values, "XMax"),
      YMin = ReadRequiredDouble(values, "YMin"),
      YMax = ReadRequiredDouble(values, "YMax"),
      ZMin = ReadRequiredDouble(values, "ZMin"),
      ZMax = ReadRequiredDouble(values, "ZMax"),
      AMin = ReadRequiredDouble(values, "AMin"),
      AMax = ReadRequiredDouble(values, "AMax"),
      BMin = ReadRequiredDouble(values, "BMin"),
      BMax = ReadRequiredDouble(values, "BMax"),
      CMin = ReadRequiredDouble(values, "CMin"),
      CMax = ReadRequiredDouble(values, "CMax"),
      MaxCuttingTiltDelta = ReadRequiredDouble(values, "MaxCuttingTiltDelta")
    };
    FiveAxisPathSafety.ValidateConfiguredProfile(loaded);
    profile = CloneProfile(loaded);
    return true;
  }

  private static double ReadRequiredDouble(Dictionary<string, string> values, string key)
  {
    string rawValue;
    double parsedValue;
    if (!values.TryGetValue(key, out rawValue) ||
        !double.TryParse(rawValue, NumberStyles.Float, CultureInfo.InvariantCulture, out parsedValue) ||
        double.IsNaN(parsedValue))
      throw new InvalidDataException("Machine profile contains an invalid or missing " + key + " value.");
    return parsedValue;
  }

  private sealed class AxisRange
  {
    public double Minimum;
    public double Maximum;
    public double DataMinimum;
    public double DataMaximum;
    public bool HasDataRange;
    public bool Enabled;
  }

  private static List<string> BuildSettingsRoots(string settingsDirectory, string machineSettingsDirectory)
  {
    List<string> roots = new List<string>();
    AddSettingsRoot(roots, settingsDirectory);
    AddSettingsRoot(roots, machineSettingsDirectory);
    return roots;
  }

  private static void AddSettingsRoot(List<string> roots, string path)
  {
    if (string.IsNullOrWhiteSpace(path))
      return;
    string fullPath = Path.GetFullPath(path);
    if (!Directory.Exists(fullPath))
      return;
    for (int index = 0; index < roots.Count; ++index)
    {
      if (string.Equals(roots[index], fullPath, StringComparison.OrdinalIgnoreCase))
        return;
    }
    roots.Add(fullPath);
  }

  private static FiveAxisSafetyProfile LoadControllerProfile(
    List<string> roots,
    string baseDirectory,
    out string sourceSummary)
  {
    List<string> machineFiles = FindSettingsFiles(roots, "Machine.prm");
    List<string> plcFiles = FindSettingsFiles(roots, "PLCSettings.par");
    if (!string.IsNullOrWhiteSpace(baseDirectory))
    {
      string basePlcFile = Path.Combine(Path.GetFullPath(baseDirectory), "PLCSettings.par");
      if (File.Exists(basePlcFile) && !ContainsPath(plcFiles, basePlcFile))
        plcFiles.Add(basePlcFile);
    }

    FiveAxisSafetyProfile machineProfile = LoadConsistentProfiles(machineFiles, ReadMachineProfile, "Machine.prm");
    FiveAxisSafetyProfile plcProfile = LoadConsistentProfiles(plcFiles, ReadPlcProfile, "PLCSettings.par");
    if (machineProfile == null && plcProfile == null)
      throw new InvalidDataException("Neither Machine.prm soft limits nor PLCSettings.par axis limits were found in the active Settings configuration.");

    FiveAxisSafetyProfile controllerProfile = machineProfile == null
      ? plcProfile
      : (plcProfile == null ? machineProfile : IntersectProfiles(machineProfile, plcProfile));
    bool programCamLimitsApplied = ApplyProgramCamLimits(controllerProfile, FindSettingsFiles(roots, "Program.prm"));
    ValidateConfiguredProfileForStore(controllerProfile);

    string axisConfiguration = ValidateKinematicAndPost(roots);
    string marbleConfiguration = ValidateMarbleSafetySettings(roots);
    List<string> sources = new List<string>();
    if (machineProfile != null)
      sources.Add("Machine.prm soft limits");
    if (plcProfile != null)
      sources.Add("PLCSettings.par limits");
    if (programCamLimitsApplied)
      sources.Add("Program.prm CAM limits");
    sources.Add(axisConfiguration);
    sources.Add(marbleConfiguration);
    sourceSummary = string.Join(" + ", sources.ToArray());
    return controllerProfile;
  }

  private static FiveAxisSafetyProfile LoadConsistentProfiles(
    List<string> files,
    Func<string, FiveAxisSafetyProfile> loader,
    string description)
  {
    FiveAxisSafetyProfile selected = null;
    for (int index = 0; index < files.Count; ++index)
    {
      FiveAxisSafetyProfile candidate = loader(files[index]);
      if (selected != null && !ProfilesEqual(selected, candidate))
        throw new InvalidDataException("Conflicting active " + description + " files were found in the Settings trees.");
      selected = candidate;
    }
    return selected;
  }

  private static FiveAxisSafetyProfile ReadPlcProfile(string filePath)
  {
    string[] lines = ReadBoundedLines(filePath, 262144L, 4096);
    Dictionary<char, AxisRange> ranges = new Dictionary<char, AxisRange>();
    char activeAxis = '\0';
    for (int index = 0; index < lines.Length; ++index)
    {
      string line = lines[index].Trim();
      if (line.Length == 7 && line.StartsWith("<Axis", StringComparison.OrdinalIgnoreCase) && line[6] == '>')
      {
        activeAxis = char.ToUpperInvariant(line[5]);
        continue;
      }
      if (line.StartsWith("</Axis", StringComparison.OrdinalIgnoreCase))
      {
        activeAxis = '\0';
        continue;
      }
      if (activeAxis == '\0' || !line.StartsWith("Set;", StringComparison.OrdinalIgnoreCase))
        continue;
      string[] fields = line.Split(';');
      if (fields.Length < 15)
        throw new InvalidDataException("PLCSettings.par contains an incomplete Set record for axis " + activeAxis + ".");
      AxisRange range = new AxisRange();
      range.Minimum = ParseInvariantDouble(fields[13], "PLC " + activeAxis + " minimum");
      range.Maximum = ParseInvariantDouble(fields[14], "PLC " + activeAxis + " maximum");
      if (fields.Length >= 21)
      {
        range.DataMinimum = ParseInvariantDouble(fields[19], "PLC " + activeAxis + " data minimum");
        range.DataMaximum = ParseInvariantDouble(fields[20], "PLC " + activeAxis + " data maximum");
        range.HasDataRange = range.DataMinimum < range.DataMaximum;
      }
      range.Enabled = true;
      ranges[activeAxis] = range;
    }
    return CreateProfileFromRanges(ranges, "PLCSettings.par");
  }

  private static FiveAxisSafetyProfile ReadMachineProfile(string filePath)
  {
    string[] lines = ReadBoundedLines(filePath, 2L * 1024L * 1024L, 50000);
    string machineText = string.Join("\n", lines);
    Dictionary<char, AxisRange> ranges = new Dictionary<char, AxisRange>();
    char activeAxis = '\0';
    for (int index = 0; index < lines.Length; ++index)
    {
      string line = lines[index].Trim();
      if (line.StartsWith("<CodesysAxis_", StringComparison.OrdinalIgnoreCase) && line.EndsWith(">", StringComparison.Ordinal))
      {
        int axisIndex = "<CodesysAxis_".Length;
        activeAxis = axisIndex < line.Length ? char.ToUpperInvariant(line[axisIndex]) : '\0';
        if (!ranges.ContainsKey(activeAxis))
          ranges[activeAxis] = new AxisRange();
        continue;
      }
      if (line.StartsWith("</CodesysAxis_", StringComparison.OrdinalIgnoreCase))
      {
        activeAxis = '\0';
        continue;
      }
      if (activeAxis == '\0')
        continue;
      int separator = line.IndexOf('=');
      if (separator <= 0)
        continue;
      string key = line.Substring(0, separator).Trim();
      string value = line.Substring(separator + 1).Trim();
      AxisRange range = ranges[activeAxis];
      if (key.EndsWith("setSoftLimitEnable", StringComparison.OrdinalIgnoreCase))
      {
        bool enabled;
        if (!bool.TryParse(value, out enabled))
          throw new InvalidDataException("Machine.prm contains an invalid soft-limit enable value for axis " + activeAxis + ".");
        range.Enabled = enabled;
      }
      else if (key.EndsWith("setSoftLimitNegative", StringComparison.OrdinalIgnoreCase))
        range.Minimum = ParseInvariantDouble(value, "Machine " + activeAxis + " minimum");
      else if (key.EndsWith("setSoftLimitPositive", StringComparison.OrdinalIgnoreCase))
        range.Maximum = ParseInvariantDouble(value, "Machine " + activeAxis + " maximum");
      else if (key.EndsWith("setDataLimitNegative", StringComparison.OrdinalIgnoreCase))
      {
        range.DataMinimum = ParseInvariantDouble(value, "Machine " + activeAxis + " data minimum");
        range.HasDataRange = true;
      }
      else if (key.EndsWith("setDataLimitPositive", StringComparison.OrdinalIgnoreCase))
      {
        range.DataMaximum = ParseInvariantDouble(value, "Machine " + activeAxis + " data maximum");
        range.HasDataRange = true;
      }
    }
    RequireExactAssignment(machineText, "clsAppMarbleOPVar.OptionRTCPEnable", "True", "Machine.prm RTCP");
    RequireExactAssignment(machineText, "clsAppMarbleOPVar.OptionServoAxisA", "True", "Machine.prm A-axis servo");
    RequireExactAssignment(machineText, "clsAppMarbleOPVar.OptionAllAbsoluteEncoder", "True", "Machine.prm absolute encoders");
    RequireExactAssignment(machineText, "clsAppMarbleOPVar.InhibitXLimitCheckAlarm", "False", "Machine.prm X-limit alarm");
    RequireExactAssignment(machineText, "clsAppMarbleOPVar.InhibitYLimitCheckAlarm", "False", "Machine.prm Y-limit alarm");
    RequireExactAssignment(machineText, "clsAppMarbleOPVar.InhibitZLimitCheckAlarm", "False", "Machine.prm Z-limit alarm");
    RequireExactAssignment(machineText, "AlarmActionSettings.XLimitAction", "HardAlarm", "Machine.prm X-limit action");
    RequireExactAssignment(machineText, "AlarmActionSettings.YLimitAction", "HardAlarm", "Machine.prm Y-limit action");
    RequireExactAssignment(machineText, "AlarmActionSettings.ZLimitAction", "HardAlarm", "Machine.prm Z-limit action");
    return CreateProfileFromRanges(ranges, "Machine.prm");
  }

  private static FiveAxisSafetyProfile CreateProfileFromRanges(Dictionary<char, AxisRange> ranges, string source)
  {
    char[] requiredAxes = new char[] { 'X', 'Y', 'Z', 'A', 'C' };
    for (int index = 0; index < requiredAxes.Length; ++index)
    {
      AxisRange range;
      if (!ranges.TryGetValue(requiredAxes[index], out range))
        throw new InvalidDataException(source + " is missing axis " + requiredAxes[index] + ".");
      if (!range.Enabled)
        throw new InvalidDataException(source + " has disabled soft-limit enforcement for axis " + requiredAxes[index] + ".");
      if (range.HasDataRange)
      {
        if (range.DataMinimum >= range.DataMaximum)
          throw new InvalidDataException(source + " has an invalid data range for axis " + requiredAxes[index] + ".");
        range.Minimum = Math.Max(range.Minimum, range.DataMinimum);
        range.Maximum = Math.Min(range.Maximum, range.DataMaximum);
      }
      if (range.Minimum >= range.Maximum)
        throw new InvalidDataException(source + " has an invalid range for axis " + requiredAxes[index] + ".");
    }

    AxisRange x = ranges['X'];
    AxisRange y = ranges['Y'];
    AxisRange z = ranges['Z'];
    AxisRange a = ranges['A'];
    AxisRange c = ranges['C'];
    return new FiveAxisSafetyProfile()
    {
      XMin = x.Minimum, XMax = x.Maximum,
      YMin = y.Minimum, YMax = y.Maximum,
      ZMin = z.Minimum, ZMax = z.Maximum,
      AMin = a.Minimum, AMax = a.Maximum,
      BMin = 0.0, BMax = 0.0,
      CMin = c.Minimum, CMax = c.Maximum,
      MaxCuttingTiltDelta = Math.Min(180.0, a.Maximum - a.Minimum)
    };
  }

  private static FiveAxisSafetyProfile IntersectProfiles(FiveAxisSafetyProfile first, FiveAxisSafetyProfile second)
  {
    FiveAxisSafetyProfile intersection = new FiveAxisSafetyProfile()
    {
      XMin = Math.Max(first.XMin, second.XMin), XMax = Math.Min(first.XMax, second.XMax),
      YMin = Math.Max(first.YMin, second.YMin), YMax = Math.Min(first.YMax, second.YMax),
      ZMin = Math.Max(first.ZMin, second.ZMin), ZMax = Math.Min(first.ZMax, second.ZMax),
      AMin = Math.Max(first.AMin, second.AMin), AMax = Math.Min(first.AMax, second.AMax),
      BMin = Math.Max(first.BMin, second.BMin), BMax = Math.Min(first.BMax, second.BMax),
      CMin = Math.Max(first.CMin, second.CMin), CMax = Math.Min(first.CMax, second.CMax),
      MaxCuttingTiltDelta = Math.Min(first.MaxCuttingTiltDelta, second.MaxCuttingTiltDelta)
    };
    ValidateConfiguredProfileForStore(intersection);
    return intersection;
  }

  private static void EnsureContainedByController(FiveAxisSafetyProfile profile, FiveAxisSafetyProfile controller)
  {
    string[] outsideAxes = new string[]
    {
      IsContained(profile.XMin, profile.XMax, controller.XMin, controller.XMax) ? null : "X",
      IsContained(profile.YMin, profile.YMax, controller.YMin, controller.YMax) ? null : "Y",
      IsContained(profile.ZMin, profile.ZMax, controller.ZMin, controller.ZMax) ? null : "Z",
      IsContained(profile.AMin, profile.AMax, controller.AMin, controller.AMax) ? null : "A",
      IsContained(profile.BMin, profile.BMax, controller.BMin, controller.BMax) ? null : "B",
      IsContained(profile.CMin, profile.CMax, controller.CMin, controller.CMax) ? null : "C"
    };
    List<string> invalid = new List<string>();
    for (int index = 0; index < outsideAxes.Length; ++index)
    {
      if (outsideAxes[index] != null)
        invalid.Add(outsideAxes[index]);
    }
    if (invalid.Count > 0)
      throw new InvalidDataException(
        "FiveAxisSafety.prm exceeds the active controller soft limits on axis/axes: " +
        string.Join(", ", invalid.ToArray()) + ".");
    if (profile.MaxCuttingTiltDelta > controller.MaxCuttingTiltDelta + 0.000001)
      throw new InvalidDataException(
        "FiveAxisSafety.prm cutting tilt delta exceeds the active kinematic tilt travel.");
  }

  private static bool IsContained(double minimum, double maximum, double outerMinimum, double outerMaximum)
  {
    const double tolerance = 0.000001;
    return minimum >= outerMinimum - tolerance && maximum <= outerMaximum + tolerance;
  }

  private static bool ApplyProgramCamLimits(FiveAxisSafetyProfile profile, List<string> files)
  {
    bool applied = false;
    for (int fileIndex = 0; fileIndex < files.Count; ++fileIndex)
    {
      string[] lines = ReadBoundedLines(files[fileIndex], 2L * 1024L * 1024L, 100000);
      Dictionary<char, double> minimums = new Dictionary<char, double>();
      Dictionary<char, double> maximums = new Dictionary<char, double>();
      for (int lineIndex = 0; lineIndex < lines.Length; ++lineIndex)
      {
        string line = lines[lineIndex].Trim();
        if (!line.StartsWith("setCam.", StringComparison.OrdinalIgnoreCase))
          continue;
        int separator = line.IndexOf('=');
        if (separator <= 0)
          continue;
        string key = line.Substring(0, separator).Trim();
        if (key.Length < 19)
          continue;
        char axis = char.ToUpperInvariant(key["setCam.".Length]);
        if (axis != 'X' && axis != 'Y' && axis != 'Z' && axis != 'A' && axis != 'B' && axis != 'C')
          continue;
        double value = ParseInvariantDouble(line.Substring(separator + 1), "Program CAM " + axis + " limit");
        if (key.EndsWith("AxisMinLimit", StringComparison.OrdinalIgnoreCase))
          minimums[axis] = value;
        else if (key.EndsWith("AxisMaxLimit", StringComparison.OrdinalIgnoreCase))
          maximums[axis] = value;
      }

      char[] axes = new char[] { 'X', 'Y', 'Z', 'A', 'B', 'C' };
      for (int axisIndex = 0; axisIndex < axes.Length; ++axisIndex)
      {
        double minimum;
        double maximum;
        if (!minimums.TryGetValue(axes[axisIndex], out minimum) ||
            !maximums.TryGetValue(axes[axisIndex], out maximum) ||
            (minimum == 0.0 && maximum == 0.0))
          continue;
        if (minimum >= maximum)
          throw new InvalidDataException("Program.prm has an invalid CAM range for axis " + axes[axisIndex] + ".");
        IntersectAxis(profile, axes[axisIndex], minimum, maximum);
        applied = true;
      }
    }
    return applied;
  }

  private static void IntersectAxis(FiveAxisSafetyProfile profile, char axis, double minimum, double maximum)
  {
    switch (axis)
    {
      case 'X': profile.XMin = Math.Max(profile.XMin, minimum); profile.XMax = Math.Min(profile.XMax, maximum); break;
      case 'Y': profile.YMin = Math.Max(profile.YMin, minimum); profile.YMax = Math.Min(profile.YMax, maximum); break;
      case 'Z': profile.ZMin = Math.Max(profile.ZMin, minimum); profile.ZMax = Math.Min(profile.ZMax, maximum); break;
      case 'A': profile.AMin = Math.Max(profile.AMin, minimum); profile.AMax = Math.Min(profile.AMax, maximum); break;
      case 'B': profile.BMin = Math.Max(profile.BMin, minimum); profile.BMax = Math.Min(profile.BMax, maximum); break;
      default: profile.CMin = Math.Max(profile.CMin, minimum); profile.CMax = Math.Min(profile.CMax, maximum); break;
    }
  }

  private static string ValidateMarbleSafetySettings(List<string> roots)
  {
    List<string> files = FindSettingsFiles(roots, "Marble.prm");
    if (files.Count == 0)
      throw new InvalidDataException("Marble.prm is missing from the active Settings trees.");
    for (int index = 0; index < files.Count; ++index)
    {
      string text = ReadBoundedText(files[index], 2L * 1024L * 1024L);
      RequireBooleanAssignment(text, "MarbleProgramSettings.CheckMachineLimits", true, "machine-limit checking");
      RequireBooleanAssignment(text, "MarbleProgramSettings.CheckPartLimits", true, "part-limit checking");
      RequireBooleanAssignment(text, "MarbleMachineOptionsSettings.RTCPEnable", true, "RTCP");
      RequireBooleanAssignment(text, "marbleCamPars.MoveZCAAxesToSafeDistance", true, "safe Z/C/A reorientation");
      RequireTextAssignment(text, "MarbleMachineOptionsSettings.AxisXChar", "X");
      RequireTextAssignment(text, "MarbleMachineOptionsSettings.AxisYChar", "Y");
      RequireTextAssignment(text, "MarbleMachineOptionsSettings.AxisZChar", "Z");
      RequireTextAssignment(text, "MarbleMachineOptionsSettings.AxisAChar", "A");
      RequireTextAssignment(text, "MarbleMachineOptionsSettings.AxisCChar", "C");
    }
    return "Marble limits/RTCP";
  }

  private static void RequireBooleanAssignment(string text, string key, bool expected, string description)
  {
    string value = FindAssignment(text, key);
    bool parsed;
    if (value == null || !bool.TryParse(value, out parsed) || parsed != expected)
      throw new InvalidDataException("Marble.prm does not enable required " + description + ".");
  }

  private static void RequireTextAssignment(string text, string key, string expected)
  {
    string value = FindAssignment(text, key);
    if (!string.Equals(value, expected, StringComparison.OrdinalIgnoreCase))
      throw new InvalidDataException("Marble.prm has an invalid " + key + " mapping.");
  }

  private static string FindAssignment(string text, string key)
  {
    string[] lines = text.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');
    for (int index = 0; index < lines.Length; ++index)
    {
      string line = lines[index].Trim();
      if (!line.StartsWith(key, StringComparison.OrdinalIgnoreCase))
        continue;
      int separator = line.IndexOf('=');
      if (separator > 0 && string.Equals(line.Substring(0, separator).Trim(), key, StringComparison.OrdinalIgnoreCase))
        return line.Substring(separator + 1).Trim();
    }
    return null;
  }

  private static void RequireExactAssignment(string text, string key, string expected, string description)
  {
    string value = FindAssignment(text, key);
    if (!string.Equals(value, expected, StringComparison.OrdinalIgnoreCase))
      throw new InvalidDataException(description + " is missing or not set to " + expected + ".");
  }

  private static string ValidateKinematicAndPost(List<string> roots)
  {
    List<string> kinematicFiles = FindSettingsFiles(roots, "Kinematic5Axis.bukinematic");
    List<string> postFiles = FindSettingsFiles(roots, "postMachine.bupost");
    if (kinematicFiles.Count == 0)
      throw new InvalidDataException("Kinematic5Axis.bukinematic is missing from the active Settings trees.");
    if (postFiles.Count == 0)
      throw new InvalidDataException("postMachine.bupost is missing from the active Settings trees.");

    string expectedPair = null;
    for (int index = 0; index < kinematicFiles.Count; ++index)
    {
      string text = ReadBoundedText(kinematicFiles[index], 262144L);
      bool wristAc = text.IndexOf("WristAC_5Axis", StringComparison.OrdinalIgnoreCase) >= 0;
      bool wristBc = text.IndexOf("WristBC_5Axis", StringComparison.OrdinalIgnoreCase) >= 0;
      if (wristAc == wristBc)
        throw new InvalidDataException("Kinematic5Axis.bukinematic does not define exactly one supported A/C or B/C five-axis wrist.");
      string pair = wristAc ? "A/C" : "B/C";
      if (expectedPair != null && expectedPair != pair)
        throw new InvalidDataException("Conflicting active five-axis kinematic files were found in the Settings trees.");
      ValidateKinematicGeometry(text, pair);
      expectedPair = pair;
    }

    for (int index = 0; index < postFiles.Count; ++index)
      ValidatePostAxes(postFiles[index], expectedPair);
    return "Kinematic/post " + expectedPair;
  }

  private static void ValidatePostAxes(string filePath, string expectedPair)
  {
    string[] lines = ReadBoundedLines(filePath, 1024L * 1024L, 20000);
    string postText = string.Join("\n", lines);
    if (postText.IndexOf("G51 D0", StringComparison.OrdinalIgnoreCase) < 0 ||
        postText.IndexOf("G20 L$JMP$ K$GOJMP$", StringComparison.OrdinalIgnoreCase) < 0)
      throw new InvalidDataException("postMachine.bupost is not the audited CMD controller dialect.");
    Dictionary<char, bool> axes = new Dictionary<char, bool>();
    bool inAxesSection = false;
    for (int index = 0; index < lines.Length; ++index)
    {
      string line = lines[index].Trim();
      if (line.Equals("<AxesUsing>", StringComparison.OrdinalIgnoreCase))
      {
        inAxesSection = true;
        continue;
      }
      if (line.Equals("</AxesUsing>", StringComparison.OrdinalIgnoreCase))
        break;
      if (!inAxesSection || line.Length < 3)
        continue;
      int separator = line.IndexOf('=');
      if (separator <= 0)
        continue;
      char axis = char.ToUpperInvariant(line[0]);
      bool enabled;
      if ((axis == 'X' || axis == 'Y' || axis == 'Z' || axis == 'A' || axis == 'B' || axis == 'C') &&
          bool.TryParse(line.Substring(separator + 1).Trim(), out enabled))
        axes[axis] = enabled;
    }

    char[] required = expectedPair == "A/C"
      ? new char[] { 'X', 'Y', 'Z', 'A', 'C' }
      : new char[] { 'X', 'Y', 'Z', 'B', 'C' };
    for (int index = 0; index < required.Length; ++index)
    {
      bool enabled;
      if (!axes.TryGetValue(required[index], out enabled) || !enabled)
        throw new InvalidDataException("postMachine.bupost does not enable required " + required[index] + " axis for the active " + expectedPair + " kinematic.");
    }
    char unusedTilt = expectedPair == "A/C" ? 'B' : 'A';
    bool unusedEnabled;
    if (axes.TryGetValue(unusedTilt, out unusedEnabled) && unusedEnabled)
      throw new InvalidDataException("postMachine.bupost enables " + unusedTilt + " although the active kinematic is " + expectedPair + ".");
  }

  private static void ValidateKinematicGeometry(string text, string pair)
  {
    double[] offset = ReadVectorAssignment(text, "KinematicBase5.OffsetXYZ");
    double[] firstPivot = ReadVectorAssignment(text, pair == "A/C"
      ? "KinematicBase5.RotateCenterOffsetOfA"
      : "KinematicBase5.RotateCenterOffsetOfB");
    double[] cPivot = ReadVectorAssignment(text, "KinematicBase5.RotateCenterOffsetOfC");
    bool hasMeasuredGeometry = false;
    for (int index = 0; index < 3; ++index)
    {
      if (offset[index] != 0.0 || firstPivot[index] != 0.0 || cPivot[index] != 0.0)
        hasMeasuredGeometry = true;
    }
    if (!hasMeasuredGeometry)
      throw new InvalidDataException("Kinematic5Axis.bukinematic contains no measured pivot or base offsets.");
  }

  private static double[] ReadVectorAssignment(string text, string key)
  {
    string value = FindAssignment(text, key);
    if (value == null)
      throw new InvalidDataException("Kinematic5Axis.bukinematic is missing " + key + ".");
    string[] fields = value.Split(';');
    if (fields.Length != 3)
      throw new InvalidDataException("Kinematic5Axis.bukinematic contains an invalid " + key + " vector.");
    return new double[]
    {
      ParseInvariantDouble(fields[0], key + " X"),
      ParseInvariantDouble(fields[1], key + " Y"),
      ParseInvariantDouble(fields[2], key + " Z")
    };
  }

  private static List<string> FindSettingsFiles(List<string> roots, string fileName)
  {
    List<string> results = new List<string>();
    Queue<string> pending = new Queue<string>();
    for (int index = 0; index < roots.Count; ++index)
      pending.Enqueue(roots[index]);
    int visitedDirectories = 0;
    int visitedFiles = 0;
    while (pending.Count > 0)
    {
      string directory = pending.Dequeue();
      if (++visitedDirectories > MaxSettingsDirectories)
        throw new InvalidDataException("Settings tree contains too many directories to audit safely.");
      string[] files = Directory.GetFiles(directory);
      visitedFiles += files.Length;
      if (visitedFiles > MaxSettingsFiles)
        throw new InvalidDataException("Settings tree contains too many files to audit safely.");
      for (int index = 0; index < files.Length; ++index)
      {
        if (string.Equals(Path.GetFileName(files[index]), fileName, StringComparison.OrdinalIgnoreCase) &&
            !ContainsPath(results, files[index]))
          results.Add(files[index]);
      }

      string[] subdirectories = Directory.GetDirectories(directory);
      for (int index = 0; index < subdirectories.Length; ++index)
      {
        DirectoryInfo info = new DirectoryInfo(subdirectories[index]);
        if ((info.Attributes & FileAttributes.ReparsePoint) != 0 || IsInactiveSettingsDirectory(info.Name))
          continue;
        pending.Enqueue(info.FullName);
      }
    }
    results.Sort(StringComparer.OrdinalIgnoreCase);
    return results;
  }

  private static bool IsInactiveSettingsDirectory(string name)
  {
    return name.Equals("Old", StringComparison.OrdinalIgnoreCase) ||
           name.Equals("Backup", StringComparison.OrdinalIgnoreCase) ||
           name.Equals("Temp", StringComparison.OrdinalIgnoreCase);
  }

  private static bool ContainsPath(List<string> paths, string candidate)
  {
    string fullCandidate = Path.GetFullPath(candidate);
    for (int index = 0; index < paths.Count; ++index)
    {
      if (string.Equals(Path.GetFullPath(paths[index]), fullCandidate, StringComparison.OrdinalIgnoreCase))
        return true;
    }
    return false;
  }

  private static string[] ReadBoundedLines(string filePath, long maximumBytes, int maximumLines)
  {
    string text = ReadBoundedText(filePath, maximumBytes);
    string[] lines = text.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');
    if (lines.Length > maximumLines)
      throw new InvalidDataException(Path.GetFileName(filePath) + " contains too many lines.");
    return lines;
  }

  private static string ReadBoundedText(string filePath, long maximumBytes)
  {
    FileInfo file = new FileInfo(filePath);
    if (!file.Exists)
      throw new FileNotFoundException("Settings file was not found.", filePath);
    if (file.Length > maximumBytes)
      throw new InvalidDataException(file.Name + " exceeds the settings audit size limit.");
    return File.ReadAllText(file.FullName);
  }

  private static double ParseInvariantDouble(string value, string description)
  {
    double parsed;
    if (!double.TryParse(value.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out parsed) ||
        double.IsNaN(parsed) || double.IsInfinity(parsed))
      throw new InvalidDataException("Invalid " + description + " value.");
    return parsed;
  }

  private static void ValidateConfiguredProfileForStore(FiveAxisSafetyProfile profile)
  {
    FiveAxisPathSafety.ValidateConfiguredProfile(profile);
  }

  private static bool ProfilesEqual(FiveAxisSafetyProfile first, FiveAxisSafetyProfile second)
  {
    return first.XMin == second.XMin && first.XMax == second.XMax &&
           first.YMin == second.YMin && first.YMax == second.YMax &&
           first.ZMin == second.ZMin && first.ZMax == second.ZMax &&
           first.AMin == second.AMin && first.AMax == second.AMax &&
           first.BMin == second.BMin && first.BMax == second.BMax &&
           first.CMin == second.CMin && first.CMax == second.CMax &&
           first.MaxCuttingTiltDelta == second.MaxCuttingTiltDelta;
  }

  private static string BuildChecksumPayload(Dictionary<string, string> values)
  {
    StringBuilder payload = new StringBuilder();
    for (int index = 0; index < ProfileDataKeys.Length; ++index)
    {
      string value;
      if (!values.TryGetValue(ProfileDataKeys[index], out value))
        throw new InvalidDataException("Machine profile is missing the " + ProfileDataKeys[index] + " checksum field.");
      payload.Append(ProfileDataKeys[index]).Append('=').Append(value).Append('\n');
    }
    return payload.ToString();
  }

  private static string ComputeSha256(string value)
  {
    using (SHA256 algorithm = SHA256.Create())
    {
      byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
      return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
    }
  }

  private static FiveAxisSafetyProfile CloneProfile(FiveAxisSafetyProfile active)
  {
    return new FiveAxisSafetyProfile()
    {
      XMin = active.XMin,
      XMax = active.XMax,
      YMin = active.YMin,
      YMax = active.YMax,
      ZMin = active.ZMin,
      ZMax = active.ZMax,
      AMin = active.AMin,
      AMax = active.AMax,
      BMin = active.BMin,
      BMax = active.BMax,
      CMin = active.CMin,
      CMax = active.CMax,
      MaxCuttingTiltDelta = active.MaxCuttingTiltDelta
    };
  }
}
