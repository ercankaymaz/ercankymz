// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationDataHole
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataHole : buSerilization5
{
  public List<Rectangle2D> RemnantSheets;
  public List<camTp> Cams;
  public MachineGCodeExecutionResult GCodeResult;
  public static byte f004315;
  public Vec3D MovedDistance;
  public double RotateValue;
  public double Width;
  public double Height;
  public double Thickness;

  public void InsertSupportBlockInfoToGCode(
    ProfileItem Item,
    int InsertIndex,
    ref PostProcessor tempPost,
    string CommentStartChar,
    string CommentEndChar,
    string EqualChar = " = ")
  {
    string callMethod = nameof (InsertSupportBlockInfoToGCode);
    try
    {
      if (!(((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockZHeight > 0.0 | ((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockY1FrontWidth > 0.0 | ((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockY2BackWidth > 0.0))
        return;
      string str1 = CommentStartChar;
      if (((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockZHeight > 0.0)
        str1 = $"{str1}Z {buLangTranslate.preDef.Bottom} {buLangTranslate.preDef.Leaning}= {((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockZHeight.ToString("f1")}  ";
      if (((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockY1FrontWidth > 0.0)
        str1 = $"{str1}Y {buLangTranslate.preDef.Front} {buLangTranslate.preDef.Leaning}= {((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockY1FrontWidth.ToString("f1")}  ";
      if (((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockY2BackWidth > 0.0)
        str1 = $"{str1}Y {buLangTranslate.preDef.Back} {buLangTranslate.preDef.Leaning}= {((MarbleJob) ((ProfileSettings) Item).SupportBlock).SupportBlockY2BackWidth.ToString("f1")}";
      string str2 = str1 + CommentEndChar;
      tempPost.StartLines.Insert(InsertIndex, (object) str2);
    }
    catch (Exception ex)
    {
      buException.throwException(ex, ProfileSettings.sClass, callMethod, false, "");
    }
  }

  public void InsertOperationInfoToGCode(
    GProfileOperation OP,
    ref ArrayList Infos,
    string CommentStartChar,
    string CommentEndChar,
    string EqualChar = "= ")
  {
    string callMethod = nameof (InsertOperationInfoToGCode);
    try
    {
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Rectangle)
      {
        string str1 = $"{CommentStartChar}{buLangTranslate.preDef.Rectangle} - {buLangTranslate.preDef.Width}{EqualChar}{((CreateProfileFromDataOptions) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleData).RectangleWidth.ToString("f2")} - {buLangTranslate.preDef.Height}{EqualChar}{((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleData).RectangleHeight.ToString("f2")}";
        if (((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleData).RectangleRadius > 0.0)
          str1 = $"{str1} - {buLangTranslate.preDef.Radius}{EqualChar}{((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).RectangleData).RectangleRadius.ToString("f2")}";
        string str2 = str1 + CommentEndChar;
        Infos.Add((object) str2);
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Circle)
      {
        string str = $"{CommentStartChar}{buLangTranslate.preDef.Cirlce} - {buLangTranslate.preDef.Diameter}{EqualChar}{((CreateProfileFromDataOptions) ((OperationInsideClampers) ((ProfileRuntimeSettings) OP).OperationData).CircleData).CircleDiameter.ToString("f2")}" + CommentEndChar;
        Infos.Add((object) str);
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Slot)
      {
        string str = $"{CommentStartChar}{buLangTranslate.preDef.Slot} - {buLangTranslate.preDef.Width}{EqualChar}{((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).SlotData).SlotWidth.ToString("f2")} - {buLangTranslate.preDef.Diameter}{EqualChar}{((PanelEntityData) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).SlotData).SlotDiameter.ToString("f2")}" + CommentEndChar;
        Infos.Add((object) str);
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Ellipse)
      {
        string str = $"{CommentStartChar}{buLangTranslate.preDef.Ellipse} - {buLangTranslate.preDef.Width}{EqualChar}{((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).EllipseData).EllipseWidth.ToString("f2")} - {buLangTranslate.preDef.Height}{EqualChar}{((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).EllipseData).EllipseHeight.ToString("f2")}" + CommentEndChar;
        Infos.Add((object) str);
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Polygon)
      {
        string str = $"{CommentStartChar}{buLangTranslate.preDef.Polygon} - {buLangTranslate.preDef.Diameter}{EqualChar}{((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).PolygonData).PolygonDiameter.ToString("f2")} - {buLangTranslate.preDef.Side}{EqualChar}{((CreateProfileFromDataOptions) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).PolygonData).PolygonSide.ToString()}" + CommentEndChar;
        Infos.Add((object) str);
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Hole)
      {
        string str = $"{CommentStartChar}{buLangTranslate.preDef.Hole} - {buLangTranslate.preDef.Diameter}{EqualChar}{((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).HoleData).HoleDiameter.ToString("f2")}" + CommentEndChar;
        Infos.Add((object) str);
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Barrel)
      {
        string str = $"{CommentStartChar}{buLangTranslate.preDef.KeyHole} - {buLangTranslate.preDef.Diameter}{EqualChar}{((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelDiameter.ToString("f2")} - {buLangTranslate.preDef.Length}{EqualChar}{((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelLength.ToString("f2")} - {buLangTranslate.preDef.Width}{EqualChar}{((PanelCutMove) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).BarelData).BarrelWidth.ToString("f2")}" + CommentEndChar;
        Infos.Add((object) str);
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.FreeDraw)
      {
        string str = $"{CommentStartChar}{buLangTranslate.preDef.FreeDraw} - {buLangTranslate.preDef.Width}{EqualChar}{((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).FreeDrawData).FreeDrawWidth.ToString("f2")} - {buLangTranslate.preDef.Height}{EqualChar}{((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).FreeDrawData).FreeDrawHeight.ToString("f2")}" + CommentEndChar;
        Infos.Add((object) str);
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Text | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.CustomText | ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.WireText)
      {
        string str = $"{CommentStartChar}{buLangTranslate.preDef.Text}{EqualChar}{((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData).TextString} - {buLangTranslate.preDef.Width}{EqualChar}{((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData).TextWidth.ToString("f2")} - {buLangTranslate.preDef.Height}{EqualChar}{((NestingPanelNode) ((DepthPositionOptions) ((ProfileRuntimeSettings) OP).OperationData).TextData).TextHeight.ToString("f2")}" + CommentEndChar;
        Infos.Add((object) str);
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Cut)
      {
        string str = $"{CommentStartChar}{buLangTranslate.preDef.Cut} - {buLangTranslate.preDef.Width}{EqualChar}{((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).CutData).CutWidth.ToString("f2")} - {buLangTranslate.preDef.Height}{EqualChar}{((PanelDonePart) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).CutData).CutHeigth.ToString("f2")}" + CommentEndChar;
        Infos.Add((object) str);
      }
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) OP).OperationData).OperationType == ProfileOperationTypes.Notch)
      {
        string str = CommentStartChar + buLangTranslate.preDef.Notch + EqualChar + ((NestingPanel) ((DepthPositions) ((ProfileRuntimeSettings) OP).OperationData).NotchData).NotchOPType.ToString() + CommentEndChar;
        Infos.Add((object) str);
      }
      string str3 = $"{CommentStartChar}{ProfileOperationDataNotch.PlaneToString(((ProfileMirror) ((ProfileRuntimeSettings) OP).OperationData).selectedPlaneName)} - {buLangTranslate.preDef.Depth}{EqualChar}{(((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExternalDepth + ((ProfileArray) ((ProfileRuntimeSettings) OP).OperationData).ExtraDepth).ToString("f2")}{CommentEndChar}";
      Infos.Add((object) str3);
      if (((ProfileRuntimeSettings) OP).Tool == null)
        return;
      string str4 = $"{CommentStartChar}{buLangTranslate.preDef.Tool} {((ToolCamData5) ((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Data).Name} - {buLangTranslate.preDef.Diameter}{EqualChar}{((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Geometry.Diameter.ToString()} - {buLangTranslate.preDef.Length}{EqualChar}{((ToolGeometry5) ((ProfileRuntimeSettings) OP).Tool).Geometry.Length.ToString()}{CommentEndChar}";
      Infos.Add((object) str4);
    }
    catch (Exception ex)
    {
      buException.throwException(ex, ProfileSettings.sClass, callMethod, false, "");
    }
  }

  public void CreatePlane(
    ProfilePlaneDef Type,
    int Index,
    bool Create,
    Point3D pntMinProfile,
    Point3D pntMaxProfile,
    double PlaneThinkness,
    UCSObjectData UcsData,
    ref SelectedPlaneInfo P)
  {
    string str = ((ColorDrawType) P).Explanation;
    if (Create)
      P = (SelectedPlaneInfo) new hmiUISettings();
    ((GCodeConverter) P).PlaneType = Type;
    if (Create)
    {
      if (Type == ProfilePlaneDef.Top0)
      {
        ((ColorType) P).pntPlane = new Point3D(0.0, pntMinProfile.Y, pntMaxProfile.Z);
        ((GCodeConverter) P).Angle = 0.0;
        str = $"{buLangTranslate.preDef.Top} {buLangTranslate.preDef.Plane}: {(((GCodeConverter) P).Angle + ((GCodeConverter) P).AngleOffset).ToString("f1")} °";
      }
      if (Type == ProfilePlaneDef.Back45 | Type == ProfilePlaneDef.Back90)
      {
        ((ColorType) P).pntPlane = new Point3D(0.0, 0.0, pntMaxProfile.Z);
        if (Type == ProfilePlaneDef.Back45)
          ((GCodeConverter) P).Angle = -45.0;
        if (Type == ProfilePlaneDef.Back90)
          ((GCodeConverter) P).Angle = -90.0;
        str = $"{buLangTranslate.preDef.Back} {buLangTranslate.preDef.Plane}: {(((GCodeConverter) P).Angle + ((GCodeConverter) P).AngleOffset).ToString("f1")} °";
      }
      if (Type == ProfilePlaneDef.Front45 | Type == ProfilePlaneDef.Front90)
      {
        ((ColorType) P).pntPlane = new Point3D(0.0, pntMinProfile.Y, pntMaxProfile.Z);
        if (Type == ProfilePlaneDef.Front45)
          ((GCodeConverter) P).Angle = 45.0;
        if (Type == ProfilePlaneDef.Front90)
        {
          ((GCodeConverter) P).Angle = 90.0;
          ((ColorType) P).pntPlane.Z = 0.0;
        }
        str = $"{buLangTranslate.preDef.Front} {buLangTranslate.preDef.Plane}: {(((GCodeConverter) P).Angle + ((GCodeConverter) P).AngleOffset).ToString("f1")} °";
      }
    }
    ((GCodeConverter) P).AngleOffset = 0.0;
    ((WriteDxfDwgPropeties) P).refPlane = new Plane(new Point3D(0.0, ((ColorType) P).pntPlane.Y, ((ColorType) P).pntPlane.Z), Vector3D.AxisX, Vector3D.AxisY);
    ((WriteDxfDwgPropeties) P).refPlane.Rotate(buString5.DegreeToRadian(((GCodeConverter) P).Angle), ((WriteDxfDwgPropeties) P).refPlane.AxisX, ((ColorType) P).pntPlane);
    ((WriteDxfDwgPropeties) P).refPlane.UpdateEquation();
    ((ColorDrawType) P).Length = pntMaxProfile.X - pntMinProfile.X;
    ((ColorDrawType) P).Height = pntMaxProfile.Y - pntMinProfile.Y;
    if (((ColorDrawType) P).Length <= 0.0)
      ((ColorDrawType) P).Length = 100.0;
    if (((ColorDrawType) P).Height <= 0.0)
      ((ColorDrawType) P).Height = 20.0;
    buCall.\u0001.PlaneToEntity(((WriteDxfDwgPropeties) P).refPlane, ((ColorDrawType) P).Length, ((ColorDrawType) P).Height, PlaneThinkness, UcsData, ref ((WriteDxfDwgPropeties) P).entityPlane, ref ((WriteDxfDwgPropeties) P).entityXVector, ref ((WriteDxfDwgPropeties) P).entityYVector, ref ((WriteDxfDwgPropeties) P).entityZVector, ref ((ColorType) P).entityBall);
    ((ColorDrawType) P).Explanation = str;
    ((GCodeConverter) P).Index = Index;
  }

  public int ClamperPreperation(
    ref ProfileItemCalc ItemCalc,
    List<ProfileClamper> Clampers,
    List<ProfileLengthClamperCount> ClampCountFromLength,
    ref List<ProfileClamper> opClampers,
    ref int RemainClamper)
  {
    try
    {
      ((ProfileSettings) ItemCalc).IsClamperDone = false;
      if (Clampers.Count == 0)
      {
        int num = (int) MessageBox.Show(buLangTranslate.preSentencesProfile.NoClamperAvailable);
        return -1;
      }
      if (ClampCountFromLength.Count > 0)
      {
        for (int index = 0; index <= ClampCountFromLength.Count - 1; ++index)
        {
          if (index == 0)
          {
            // ISSUE: reference to a compiler-generated field
            if (((ProfileSettings) ItemCalc).Length <= ((buMarbleCalc) ClampCountFromLength[index]).ProfileLength && ((ProfileSettings) ItemCalc).MaxClamperNumber >= ((buMarbleCalc.\u003C\u003Ec) ClampCountFromLength[index]).ClamperCount)
            {
              // ISSUE: reference to a compiler-generated field
              RemainClamper = ((ProfileSettings) ItemCalc).MaxClamperNumber - ((buMarbleCalc.\u003C\u003Ec) ClampCountFromLength[index]).ClamperCount;
              // ISSUE: reference to a compiler-generated field
              ((ProfileSettings) ItemCalc).MaxClamperNumber = ((buMarbleCalc.\u003C\u003Ec) ClampCountFromLength[index]).ClamperCount;
            }
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            if (((buMarbleCalc) ClampCountFromLength[index - 1]).ProfileLength < ((ProfileSettings) ItemCalc).Length & ((ProfileSettings) ItemCalc).Length <= ((buMarbleCalc) ClampCountFromLength[index]).ProfileLength && ((ProfileSettings) ItemCalc).MaxClamperNumber >= ((buMarbleCalc.\u003C\u003Ec) ClampCountFromLength[index]).ClamperCount)
            {
              // ISSUE: reference to a compiler-generated field
              RemainClamper = ((ProfileSettings) ItemCalc).MaxClamperNumber - ((buMarbleCalc.\u003C\u003Ec) ClampCountFromLength[index]).ClamperCount;
              // ISSUE: reference to a compiler-generated field
              ((ProfileSettings) ItemCalc).MaxClamperNumber = ((buMarbleCalc.\u003C\u003Ec) ClampCountFromLength[index]).ClamperCount;
            }
          }
        }
      }
      if (((ProfileSettings) ItemCalc).CalcType == ProfileExcType.LongSecondPart | ((ProfileSettings) ItemCalc).CalcType == ProfileExcType.LongSecondBottom)
      {
        ((ProfileSettings) ItemCalc).MaxClamperNumber = Clampers.Count;
        RemainClamper = 0;
      }
      for (int index = 0; index <= ((ProfileSettings) ItemCalc).MaxClamperNumber - 1; ++index)
      {
        if (index <= Clampers.Count - 1)
          opClampers.Add(Clampers[index]);
        else
          opClampers.Add((ProfileClamper) new MarbleVacuumCut());
      }
      for (int index = 0; index <= opClampers.Count - 1; ++index)
        ((buMarbleCalc) opClampers[index]).Used = false;
      return 1;
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public void ReArrangeClampers(
    double MinX,
    double MaxX,
    double ForbiddenMixX,
    double ForbiddenMaxX,
    int ClamperCount,
    double MinDisBetweenClamper,
    double MaxDisBetweenClamper,
    ref List<ProfileClamper> Clampers)
  {
    try
    {
      double num1 = MaxX - ForbiddenMaxX;
      for (int index = 0; index <= Clampers.Count - 1; ++index)
      {
        if (index == 0)
        {
          ((PanelCutMoveCommand) Clampers[index]).XPosition = MinX;
          ((buMarbleCalc) Clampers[index]).GeometrixMaxX = ((PanelCutMoveCommand) Clampers[index]).XPosition + ((buMarbleCalc) Clampers[index]).Width / 2.0;
          ((buMarbleCalc) Clampers[index]).GeometrixMinX = ((PanelCutMoveCommand) Clampers[index]).XPosition - ((buMarbleCalc) Clampers[index]).Width / 2.0;
        }
        else if (index == ClamperCount - 1)
        {
          if (num1 > ((buMarbleCalc) Clampers[0]).Width / 2.0)
          {
            ((PanelCutMoveCommand) Clampers[index]).XPosition = ForbiddenMaxX + ((buMarbleCalc) Clampers[index]).Width / 2.0;
            ((buMarbleCalc) Clampers[index]).GeometrixMaxX = ((PanelCutMoveCommand) Clampers[index]).XPosition + ((buMarbleCalc) Clampers[index]).Width / 2.0;
            ((buMarbleCalc) Clampers[index]).GeometrixMinX = ((PanelCutMoveCommand) Clampers[index]).XPosition - ((buMarbleCalc) Clampers[index]).Width / 2.0;
          }
          else
          {
            double num2 = ForbiddenMixX - ((buMarbleCalc) Clampers[index]).Width / 2.0 - ((PanelCutMoveCommand) Clampers[index - 1]).XPosition;
            if (MinDisBetweenClamper < num2 & num2 < MaxDisBetweenClamper)
            {
              ((PanelCutMoveCommand) Clampers[index]).XPosition = ForbiddenMixX - ((buMarbleCalc) Clampers[index]).Width / 2.0;
              ((buMarbleCalc) Clampers[index]).GeometrixMaxX = ((PanelCutMoveCommand) Clampers[index]).XPosition + ((buMarbleCalc) Clampers[index]).Width / 2.0;
              ((buMarbleCalc) Clampers[index]).GeometrixMinX = ((PanelCutMoveCommand) Clampers[index]).XPosition - ((buMarbleCalc) Clampers[index]).Width / 2.0;
            }
            else if (((PanelCutMoveCommand) Clampers[index]).XPosition < MaxX)
            {
              ((PanelCutMoveCommand) Clampers[index]).XPosition = MaxX + MinDisBetweenClamper;
              ((buMarbleCalc) Clampers[index]).GeometrixMaxX = ((PanelCutMoveCommand) Clampers[index]).XPosition + ((buMarbleCalc) Clampers[index]).Width / 2.0;
              ((buMarbleCalc) Clampers[index]).GeometrixMinX = ((PanelCutMoveCommand) Clampers[index]).XPosition - ((buMarbleCalc) Clampers[index]).Width / 2.0;
            }
          }
        }
        else if (index > 0 & index < ClamperCount - 1)
        {
          double num3 = ForbiddenMixX - ((buMarbleCalc) Clampers[index]).Width / 2.0 - ((PanelCutMoveCommand) Clampers[index - 1]).XPosition;
          if (MinDisBetweenClamper < num3 & num3 < MaxDisBetweenClamper)
          {
            ((PanelCutMoveCommand) Clampers[index]).XPosition = ForbiddenMixX - ((buMarbleCalc) Clampers[index]).Width / 2.0;
            ((buMarbleCalc) Clampers[index]).GeometrixMaxX = ((PanelCutMoveCommand) Clampers[index]).XPosition + ((buMarbleCalc) Clampers[index]).Width / 2.0;
            ((buMarbleCalc) Clampers[index]).GeometrixMinX = ((PanelCutMoveCommand) Clampers[index]).XPosition - ((buMarbleCalc) Clampers[index]).Width / 2.0;
          }
        }
        else if (((PanelCutMoveCommand) Clampers[index]).XPosition < ((PanelCutMoveCommand) Clampers[index - 1]).XPosition + MinDisBetweenClamper)
        {
          ((PanelCutMoveCommand) Clampers[index]).XPosition = ((PanelCutMoveCommand) Clampers[index - 1]).XPosition + MinDisBetweenClamper;
          ((buMarbleCalc) Clampers[index]).GeometrixMaxX = ((PanelCutMoveCommand) Clampers[index]).XPosition + ((buMarbleCalc) Clampers[index]).Width / 2.0;
          ((buMarbleCalc) Clampers[index]).GeometrixMinX = ((PanelCutMoveCommand) Clampers[index]).XPosition - ((buMarbleCalc) Clampers[index]).Width / 2.0;
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public int HowManyClamperInsideProfile(
    ProfileItemCalc Item,
    double StartOffset,
    double EndOffset,
    List<ProfileClamper> Clampers,
    double ProfileOffset = 0.0)
  {
    try
    {
      double num1 = StartOffset + ProfileOffset;
      double num2 = ((ProfileSettings) Item).Length - EndOffset + ProfileOffset;
      int num3 = 0;
      for (int index = 0; index <= Clampers.Count - 1; ++index)
      {
        if (num1 <= ((PanelCutMoveCommand) Clampers[index]).XPosition & ((PanelCutMoveCommand) Clampers[index]).XPosition <= num2)
          ++num3;
      }
      return num3;
    }
    catch (Exception ex)
    {
      return 0;
    }
  }
}
