using buCore;
using System;
using System.Collections.Generic;

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
  public static void ValidateAndNormalize(List<camTp> cams)
  {
    ValidateAndNormalize(cams, new FiveAxisSafetyProfile());
  }

  public static void ValidateAndNormalize(List<camTp> cams, FiveAxisSafetyProfile profile)
  {
    if (cams == null)
      throw new InvalidOperationException("CAM path collection is null.");
    if (profile == null)
      throw new InvalidOperationException("Five-axis machine safety profile is null.");
    ValidateProfile(profile);

    int validatedPointCount = 0;
    bool hasPreviousPoint = false;
    double previousA = 0.0;
    double previousB = 0.0;
    double previousC = 0.0;

    for (int camIndex = 0; camIndex < cams.Count; ++camIndex)
    {
      camTp cam = cams[camIndex];
      if (cam == null || !cam.Enable || cam.CamPoints == null)
        continue;

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
          ValidateRange(point.P9.X, profile.XMin, profile.XMax, "X", camIndex, segmentIndex, pointIndex);
          ValidateRange(point.P9.Y, profile.YMin, profile.YMax, "Y", camIndex, segmentIndex, pointIndex);
          ValidateRange(point.P9.Z, profile.ZMin, profile.ZMax, "Z", camIndex, segmentIndex, pointIndex);
          ValidateRange(point.P9.A, profile.AMin, profile.AMax, "A", camIndex, segmentIndex, pointIndex);
          ValidateRange(point.P9.B, profile.BMin, profile.BMax, "B", camIndex, segmentIndex, pointIndex);

          if (hasPreviousPoint)
            point.P9.C = ResolveEquivalentC(point.P9.C, previousC, profile, camIndex, segmentIndex, pointIndex);
          else if (point.P9.C < profile.CMin || point.P9.C > profile.CMax)
            point.P9.C = ResolveEquivalentC(point.P9.C, 0.0, profile, camIndex, segmentIndex, pointIndex);

          // Type 0 is a rapid/link move in the recovered CAM model. Large tilt flips
          // during a cutting move are rejected; they must be resolved by kinematics
          // or split into a retract/reorientation/approach sequence.
          if (hasPreviousPoint && point.Type != 0)
          {
            if (Math.Abs(point.P9.A - previousA) > profile.MaxCuttingTiltDelta)
              throw PathError(camIndex, segmentIndex, pointIndex, "Unsafe A-axis flip in cutting motion");
            if (Math.Abs(point.P9.B - previousB) > profile.MaxCuttingTiltDelta)
              throw PathError(camIndex, segmentIndex, pointIndex, "Unsafe B-axis flip in cutting motion");
          }

          previousA = point.P9.A;
          previousB = point.P9.B;
          previousC = point.P9.C;
          hasPreviousPoint = true;
          ++validatedPointCount;
        }
      }
    }

    if (validatedPointCount == 0)
      throw new InvalidOperationException("No enabled CAM points are available for G-code generation.");
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

    for (int turn = -8; turn <= 8; ++turn)
    {
      double candidate = rawAngle + turn * 360.0;
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
    if (profile.XMin > profile.XMax || profile.YMin > profile.YMax || profile.ZMin > profile.ZMax ||
        profile.AMin > profile.AMax || profile.BMin > profile.BMax || profile.CMin > profile.CMax)
      throw new InvalidOperationException("Five-axis machine profile contains an inverted axis range.");
    if (double.IsNaN(profile.MaxCuttingTiltDelta) || double.IsInfinity(profile.MaxCuttingTiltDelta) ||
        profile.MaxCuttingTiltDelta <= 0.0 || profile.MaxCuttingTiltDelta > 180.0)
      throw new InvalidOperationException("Five-axis machine profile has an invalid cutting tilt delta.");
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
}
