using buCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
  private static readonly Regex GCodeWordPattern = new Regex(
    @"(?<![A-Z])([GXYZABC])\s*([+-]?(?:[0-9]+(?:\.[0-9]*)?|\.[0-9]+)(?:E[+-]?[0-9]+)?)",
    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

  /// <summary>
  /// Active machine profile. Machine initialization should replace the recovery
  /// defaults with measured travels and the controller-approved rotary limits.
  /// </summary>
  public static FiveAxisSafetyProfile ActiveProfile { get; private set; } = new FiveAxisSafetyProfile();
  public static bool HasConfiguredMachineEnvelope { get; private set; }

  public static void Configure(FiveAxisSafetyProfile profile)
  {
    if (profile == null)
      throw new InvalidOperationException("Five-axis machine safety profile is null.");
    ValidateConfiguredProfile(profile);
    ActiveProfile = CloneProfile(profile);
    HasConfiguredMachineEnvelope = true;
  }

  public static void ValidateAndNormalize(List<camTp> cams)
  {
    EnsureActiveMachineEnvelope();
    ValidateAndNormalize(cams, ActiveProfile);
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
      if (cam == null || !cam.Enable || cam.CamPoints == null)
        continue;
      FiveAxisSafetyProfile effectiveProfile = CreateEffectiveProfile(profile, cam, camIndex);
      bool hasPreviousPointInCam = false;

      for (int segmentIndex = 0; segmentIndex < cam.CamPoints.Count; ++segmentIndex)
      {
        if (cam.CamPoints[segmentIndex] == null || cam.CamPoints[segmentIndex].Points == null)
          continue;

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

          if (point.Feed < 0.0)
            throw PathError(camIndex, segmentIndex, pointIndex, "Feed cannot be negative");
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
    EnsureActiveMachineEnvelope();
    ValidateGCode(gCode, ActiveProfile);
  }

  public static void ValidateGCode(string gCode, FiveAxisSafetyProfile profile)
  {
    if (string.IsNullOrWhiteSpace(gCode))
      throw new InvalidOperationException("Postprocessor generated empty G-code.");
    if (profile == null)
      throw new InvalidOperationException("Five-axis machine safety profile is null.");
    ValidateProfile(profile);

    string[] lines = gCode.Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');
    bool absoluteMode = true;
    Dictionary<char, double> knownPositions = new Dictionary<char, double>();
    for (int lineIndex = 0; lineIndex < lines.Length; ++lineIndex)
    {
      string line = lines[lineIndex];
      string executableLine = StripGCodeComments(line);
      if (executableLine.IndexOf("NaN", StringComparison.OrdinalIgnoreCase) >= 0 ||
          executableLine.IndexOf("Infinity", StringComparison.OrdinalIgnoreCase) >= 0)
        throw new InvalidOperationException(
          string.Format(
            System.Globalization.CultureInfo.InvariantCulture,
            "Postprocessor generated a non-finite numeric token at line {0}.",
            lineIndex + 1));

      MatchCollection wordMatches = GCodeWordPattern.Matches(executableLine);
      for (int wordIndex = 0; wordIndex < wordMatches.Count; ++wordIndex)
      {
        char word = char.ToUpperInvariant(wordMatches[wordIndex].Groups[1].Value[0]);
        double value;
        if (!double.TryParse(wordMatches[wordIndex].Groups[2].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out value) ||
            double.IsNaN(value) || double.IsInfinity(value))
          throw new InvalidOperationException(
            string.Format(CultureInfo.InvariantCulture, "Postprocessor generated an invalid {0}-word value at line {1}.", word, lineIndex + 1));

        if (word == 'G')
        {
          if (value == 90.0)
            absoluteMode = true;
          else if (value == 91.0)
            absoluteMode = false;
          continue;
        }

        char axis = word;

        double target = value;
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
          target = current + value;
        }

        ValidateGCodeAxisRange(axis, target, profile, lineIndex);
        knownPositions[axis] = target;
      }

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

  private static void ApplyToolRange(
    ref double effectiveMinimum,
    ref double effectiveMaximum,
    double toolMinimum,
    double toolMaximum,
    string axis,
    int camIndex)
  {
    if (double.IsNaN(toolMinimum) || double.IsNaN(toolMaximum))
      throw CamError(camIndex, axis + " tool envelope contains a non-numeric value");
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

  private static string StripGCodeComments(string line)
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
        ++parenthesisDepth;
        continue;
      }
      if (value == ')' && parenthesisDepth > 0)
      {
        --parenthesisDepth;
        continue;
      }
      if (parenthesisDepth == 0)
        result.Append(value);
    }
    return result.ToString();
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
  }

  private static void EnsureActiveMachineEnvelope()
  {
    if (!HasConfiguredMachineEnvelope)
      throw new InvalidOperationException(
        "XYZ/ABC machine limits are not configured. Open the tool Limits tab and save the verified values as Machine Limits before generating production G-code.");
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
}

/// <summary>
/// Versioned, user-settings persistence for the machine-wide XYZ/ABC envelope.
/// Unknown keys are ignored for forward compatibility; all required keys must
/// be present and valid before the active safety profile is changed.
/// </summary>
public static class FiveAxisSafetyProfileStore
{
  private const string ProfileFileName = "FiveAxisSafety.prm";
  private const string CurrentVersion = "1";

  public static string GetDefaultFilePath(string settingsDirectory)
  {
    if (string.IsNullOrWhiteSpace(settingsDirectory))
      throw new ArgumentException("Settings directory is empty.", nameof(settingsDirectory));
    return Path.Combine(settingsDirectory, ProfileFileName);
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

    string[] lines = new string[]
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

    Dictionary<string, string> values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    string[] lines = File.ReadAllLines(filePath);
    for (int index = 0; index < lines.Length; ++index)
    {
      string line = lines[index].Trim();
      if (line.Length == 0 || line.StartsWith("#", StringComparison.Ordinal))
        continue;
      int separator = line.IndexOf('=');
      if (separator <= 0 || separator == line.Length - 1)
        throw new InvalidDataException("Invalid machine-profile entry at line " + (index + 1) + ".");
      values[line.Substring(0, separator).Trim()] = line.Substring(separator + 1).Trim();
    }

    string version;
    if (!values.TryGetValue("Version", out version) || version != CurrentVersion)
      throw new InvalidDataException("Unsupported or missing machine-profile version.");

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
    FiveAxisPathSafety.Configure(loaded);
    profile = CloneActiveProfile();
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

  private static FiveAxisSafetyProfile CloneActiveProfile()
  {
    FiveAxisSafetyProfile active = FiveAxisPathSafety.ActiveProfile;
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
