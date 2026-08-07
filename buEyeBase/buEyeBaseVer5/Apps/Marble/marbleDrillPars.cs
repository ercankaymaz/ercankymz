// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleDrillPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleDrillPars : buSerilization5
{
  public ColorDrawType colorCamDraw;
  public ColorDrawType colorVacuum;
  public ColorDrawType colorCutSaw;
  public ColorDrawType colorCutMilling;
  public ColorDrawType colorCutMillingHead;
  public ColorDrawType colorCutWaterjet;
  public ColorDrawType colorCutSaw45;
  public ColorType colorViewportGrid;
  public ColorType colorControlEnable;
  public ColorType colorControlDisable;
  public ColorType colorControlselected;

  public string CamSequenceToString(CamSequence Seq)
  {
    string str = "";
    switch (Seq)
    {
      case CamSequence.VerticalSawCut:
        str = $"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.HorizontalSawCut:
        str = $"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.ContourOutsideSawCut:
        str = $"{buLangTranslate.preDef.Outside} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.ContourInsideSawCut:
        str = $"{buLangTranslate.preDef.Inside} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.VacuumCut:
        str = $"{buLangTranslate.preDef.Vacuum} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.SingleVerticalCut:
        str = $"{buLangTranslate.preDef.Single} {buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.SingleHorizontalCut:
        str = $"{buLangTranslate.preDef.Single} {buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.StripStartCut:
        str = $"{buLangTranslate.preDef.Strip} {buLangTranslate.preDef.Beginning} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.StripEndCut:
        str = $"{buLangTranslate.preDef.Strip} {buLangTranslate.preDef.End} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.ContourOutsideMillingCut:
        str = $"{buLangTranslate.preDef.Outside} {buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.ContourInsideMillingCut:
        str = $"{buLangTranslate.preDef.Inside} {buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.ContourConvexMillingCut:
        str = $"{buLangTranslate.preDef.Convex} {buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.ContourConcaveMillingCut:
        str = $"{buLangTranslate.preDef.Concave} {buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.CollapseMillingCut:
        str = $"{buLangTranslate.preDef.Collapse} {buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.ContourConvexDrill:
        str = $"{buLangTranslate.preDef.Convex} {buLangTranslate.preDef.Drill} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.ContourConcaveDrill:
        str = $"{buLangTranslate.preDef.Concave} {buLangTranslate.preDef.Drill} {buLangTranslate.preDef.Cut}";
        break;
      case CamSequence.Drill:
        str = $"{buLangTranslate.preDef.Drill} {buLangTranslate.preDef.Cut}";
        break;
    }
    return str;
  }

  public ToolBase5 FindToolFromType(MarbleToolType ToolType)
  {
    // ISSUE: unable to decompile the method.
  }

  public double DistanceCalcFromToolDiameterAndThickness(
    double Diameter,
    double Thickness,
    double TargetZ,
    double SafeDistance,
    double AngleA)
  {
    double num = Thickness - TargetZ;
    if (AngleA != 0.0)
      num /= Math.Sin(buString5.DegreeToRadian(90.0 - AngleA));
    return Math.Sqrt(Math.Pow(Diameter / 2.0, 2.0) - Math.Pow(Diameter / 2.0 - num, 2.0)) / 1.0 + SafeDistance;
  }

  public void defaultToolSaw(ref ToolBase5 ToolSaw)
  {
    ((ToolGeometry5) ToolSaw).Purpose = ToolPurpose.Saw;
    ((ToolData5) ((ToolGeometry5) ToolSaw).Geometry).GeometryType = ToolType.Saw;
    ((ToolGeometry5) ToolSaw).Geometry.Diameter = 400.0;
    ((ToolDisplay5) ((ToolGeometry5) ToolSaw).Geometry).Thickness = 4.0;
  }

  public void defaultToolMilling(ref ToolBase5 ToolMilling)
  {
    ((ToolGeometry5) ToolMilling).Purpose = ToolPurpose.Milling;
    ((ToolData5) ((ToolGeometry5) ToolMilling).Geometry).GeometryType = ToolType.Flat;
    ((ToolGeometry5) ToolMilling).Geometry.Diameter = 10.0;
    ((ToolGeometry5) ToolMilling).Geometry.Length = 60.0;
  }
}
