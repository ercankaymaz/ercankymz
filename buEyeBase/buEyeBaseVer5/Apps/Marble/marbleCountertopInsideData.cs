// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCountertopInsideData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopInsideData : buSerilization5
{
  public static List<string> CaptionsUnits;
  public static byte f004CA1;
  public double Angle;
  public static List<string> Captions;
  public double MaterialCutWidth;
  public double MaterialCutHeight;
  public double HorizontalOffset;
  public double MaterialHorizontalMinDistance;
  public double MaterialVerticalMinDistance;
  public double VerticalOffset;
  public bool HorizontalCutEnable;
  public bool VerticalCutEnable;
  public bool PauseAfterCut;
  public bool UseMaterialData;
  public static List<string> Captions;
  public bool eventRotateByMouse;
  public bool eventMoveByMouse;
  public bool UndoEnable;

  public void VerticalItemsCalc(
    Pnt6D Position,
    double Thickness,
    List<marbleCuttingItems> Items,
    MarbleItemSettings varOperation,
    double CutLength,
    ref List<Entity> Entities,
    ref List<List<buEntity>> CalcLines,
    ref List<buEntity> entRectangles,
    bool AlwaysSAandEAZero = false)
  {
    double x = 0.0;
    double LastA = 0.0;
    double num1 = 1.0;
    double num2 = 1.0;
    Entity SurfaceEntity = (Entity) null;
    double materialThickness = ((MarbleCamType) ((MarbleMachineSimultionSettings) varOperation).MaterialParameter).MaterialThickness;
    double Rotation = Math.Round(Position.C);
    if (Items.Count == 0)
      return;
    if (entRectangles == null)
      entRectangles = new List<buEntity>();
    entRectangles.Clear();
    if (((marbleCountertopMainData) Items[0]).Length < 0.0)
      num1 = -1.0;
    int Cnt = 0;
    for (int index1 = 0; index1 <= Items.Count - 1; ++index1)
    {
      double num3 = ((marbleCountertopMainData) Items[index1]).StartAngle;
      double num4 = ((marbleCountertopMainData) Items[index1]).EndAngle;
      double num5 = Math.Abs(((marbleCountertopMainData) Items[index1]).Length);
      double num6 = 360.0;
      if (AlwaysSAandEAZero)
      {
        num3 = 0.0;
        num4 = 0.0;
      }
      if (num3 > 0.0)
        num5 -= materialThickness * Math.Tan(buString5.DegreeToRadian(num3));
      if (num4 > 0.0)
        num5 -= materialThickness * Math.Tan(buString5.DegreeToRadian(num4));
      if (index1 <= Items.Count - 2)
        num6 = ((marbleCountertopMainData) Items[index1 + 1]).StartAngle;
      buEntity TopFirstLine = (buEntity) null;
      buEntity BottomFirstLine = (buEntity) null;
      buEntity TopLastLine = (buEntity) null;
      buEntity BottomLastLine = (buEntity) null;
      buCall.\u0001.Trapezoid3D(new Point3D(Position.X, Position.Y, ((MarbleCamType) ((MarbleMachineSimultionSettings) varOperation).MaterialParameter).MaterialThickness), num5, ((MarbleCamType) ((MarbleMachineSimultionSettings) varOperation).MaterialParameter).MaterialThickness - ((marbleEdgeItem) ((MarbleMachineSimultionSettings) varOperation).settingMarbleCam).TargetZ, num3 + 90.0, num4 + 90.0, new Vec3D(0.0, 1.0, 0.0), CutLength, Rotation, ref TopFirstLine, ref BottomFirstLine, ref TopLastLine, ref BottomLastLine, ref SurfaceEntity);
      if (num1 < 0.0)
      {
        num3 *= -1.0;
        num4 *= -1.0;
      }
      for (int index2 = 0; index2 <= ((marbleCountertopMainData) Items[index1]).Count - 1; ++index2)
      {
        double num7 = 0.0;
        double num8 = Math.Abs(((marbleCountertopMainData) Items[index1]).Length) / Math.Cos(buString5.DegreeToRadian(Rotation - 90.0));
        double num9 = 0.0;
        double num10 = Thickness / Math.Cos(buString5.DegreeToRadian(Math.Abs(num3)));
        double num11 = Thickness / Math.Cos(buString5.DegreeToRadian(Math.Abs(num4)));
        double num12 = Thickness / 2.0 / Math.Cos(buString5.DegreeToRadian(Math.Abs(num3)));
        double num13 = Thickness / 2.0 / Math.Cos(buString5.DegreeToRadian(Math.Abs(num4)));
        double num14 = num11;
        if (Position.C > 180.0 | Position.C < -45.0)
          num2 = -1.0;
        Entity refEntities1 = buVector5.CopyEntities(SurfaceEntity);
        buCall.\u0001.Move(new Point3D(), new Point3D(x, 0.0, 0.0), ref refEntities1);
        buEntity rectangleEntity = (buEntity) null;
        buCall.\u0001.DrawRectangle(new Point3D(Position.X + x, Position.Y, 0.0), num5, CutLength, Plane.XY, ref rectangleEntity);
        ((buLinearDim) rectangleEntity).Rotate(Rotation - 90.0, Vector3D.AxisZ, new Point3D(Position.X + x, Position.Y, 0.0));
        entRectangles.Add(rectangleEntity);
        CustomData customData = (CustomData) new ClipperOffset();
        ((\u001D.\u0001) customData).set_ActionName("horizontal");
        refEntities1.EntityData = (object) customData;
        Entities.Add(refEntities1);
        if (index1 == 0 & index2 == 0 | LastA != num3)
          num7 = num12;
        double num15 = num12;
        if (index2 <= ((marbleCountertopMainData) Items[index1]).Count - 2 && ((marbleCountertopMainData) Items[index1]).EndAngle != -((marbleCountertopMainData) Items[index1]).StartAngle)
          num9 = ((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) varOperation).settingSliceCut).SliceOffset;
        if (index2 == ((marbleCountertopMainData) Items[index1]).Count - 1 && ((marbleCountertopMainData) Items[index1]).EndAngle != -num6)
          num9 = ((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) varOperation).settingSliceCut).SliceOffset;
        buEntity refEntities2 = buAngularDim.Copy(TopFirstLine);
        buEntity refEntities3 = buAngularDim.Copy(BottomFirstLine);
        buEntity refEntities4 = buAngularDim.Copy(TopLastLine);
        buEntity refEntities5 = buAngularDim.Copy(BottomLastLine);
        buCall.\u0001.Move(new Point3D(), new Point3D(x - num2 * num15, 0.0, 0.0), ref refEntities2);
        buCall.\u0001.Move(new Point3D(), new Point3D(x - num2 * num15, 0.0, 0.0), ref refEntities3);
        this.MarblecalcItemLines(((CustomData) refEntities2).StartPoint, ((CustomData) refEntities3).StartPoint, ((CustomData) refEntities2).EndPoint, ((CustomData) refEntities3).EndPoint, num3, num4, LastA, Position, true, true, true, varOperation, ref CalcLines, ref Cnt);
        buCall.\u0001.Move(new Point3D(), new Point3D(x + num2 * num13, 0.0, 0.0), ref refEntities4);
        buCall.\u0001.Move(new Point3D(), new Point3D(x + num2 * num13, 0.0, 0.0), ref refEntities5);
        this.MarblecalcItemLines(((CustomData) refEntities4).StartPoint, ((CustomData) refEntities5).StartPoint, ((CustomData) refEntities4).EndPoint, ((CustomData) refEntities5).EndPoint, num3, num4, LastA, Position, false, true, true, varOperation, ref CalcLines, ref Cnt);
        LastA = num4 * -1.0;
        x = x + num8 + num2 * num14 + num2 * num9;
        if (!AlwaysSAandEAZero)
          ++Cnt;
      }
    }
    if (num1 >= 0.0)
      return;
    buCall.\u0001.Mirror(new Point3D(Position.X, 0.0, 0.0), new Point3D(Position.X, 1.0, 0.0), Plane.XY, ref Entities);
    buCall.\u0001.Mirror(new Point3D(Position.X, 0.0, 0.0), new Point3D(Position.X, 1.0, 0.0), Plane.XY, ref CalcLines);
    buCall.\u0001.Mirror(new Point3D(Position.X, 0.0, 0.0), new Point3D(Position.X, 1.0, 0.0), Plane.XY, ref entRectangles);
  }

  public void MarblecalcItemLines(
    Point3D FirstUpPnt,
    Point3D FirstDownPnt,
    Point3D LastUpPnt,
    Point3D LastDownPnt,
    double StartAngle,
    double EndAngle,
    double LastA,
    Pnt6D Position,
    bool StartMode,
    bool AddAllLines,
    bool isVertical,
    MarbleItemSettings varOperation,
    ref List<List<buEntity>> Entities,
    ref int Cnt)
  {
    List<buEntity> buEntityList1 = new List<buEntity>();
    List<Point3D> CalcPoints1 = new List<Point3D>();
    List<Point3D> CalcPoints2 = new List<Point3D>();
    ((marbleCountertopTapData) this).MarbleItemHeightByDirection(((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) varOperation).settingSliceCut).SliceDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) varOperation).settingMarbleCam).SawForwardStepDownDistance, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) varOperation).settingMarbleCam).SawBackwardStepDownDistance, ((MarbleCamType) ((MarbleMachineSimultionSettings) varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) varOperation).settingMarbleCam).TargetZ, FirstUpPnt, FirstDownPnt, ref CalcPoints1);
    ((marbleCountertopTapData) this).MarbleItemHeightByDirection(((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) varOperation).settingSliceCut).SliceDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) varOperation).settingMarbleCam).SawForwardStepDownDistance, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) varOperation).settingMarbleCam).SawBackwardStepDownDistance, ((MarbleCamType) ((MarbleMachineSimultionSettings) varOperation).MaterialParameter).MaterialThickness, ((marbleEdgeItem) ((MarbleMachineSimultionSettings) varOperation).settingMarbleCam).TargetZ, LastUpPnt, LastDownPnt, ref CalcPoints2);
    List<buEntity> buEntityList2 = new List<buEntity>();
    for (int index = 0; index <= CalcPoints1.Count - 1; ++index)
    {
      buLine buLine = (buLine) new buMultilineText(CalcPoints1[index], CalcPoints2[index]);
      if (!isVertical)
      {
        if (StartMode)
        {
          if (StartAngle > 0.0)
          {
            ((CustomDataSurrogate) buLine).Orientation = new OrientationAngle(StartAngle, 0.0, Position.C + 180.0);
            buCall.\u0001.CamDirectionChange(ref ((CustomData) buLine).sortDirection);
          }
          else
            ((CustomDataSurrogate) buLine).Orientation = new OrientationAngle(-StartAngle, 0.0, Position.C);
        }
        else if (EndAngle >= 0.0)
        {
          ((CustomDataSurrogate) buLine).Orientation = new OrientationAngle(EndAngle, 0.0, Position.C);
        }
        else
        {
          ((CustomDataSurrogate) buLine).Orientation = new OrientationAngle(-EndAngle, 0.0, Position.C + 180.0);
          buCall.\u0001.CamDirectionChange(ref ((CustomData) buLine).sortDirection);
        }
      }
      else if (StartMode)
      {
        if (StartAngle == 0.0)
          ((CustomDataSurrogate) buLine).Orientation = new OrientationAngle(StartAngle, 0.0, Position.C);
        else if (StartAngle > 0.0)
        {
          ((CustomDataSurrogate) buLine).Orientation = new OrientationAngle(StartAngle, 0.0, Position.C);
        }
        else
        {
          ((CustomDataSurrogate) buLine).Orientation = new OrientationAngle(-StartAngle, 0.0, Position.C + 180.0);
          buCall.\u0001.CamDirectionChange(ref ((CustomData) buLine).sortDirection);
        }
      }
      else if (EndAngle == 0.0)
        ((CustomDataSurrogate) buLine).Orientation = new OrientationAngle(EndAngle, 0.0, Position.C);
      else if (EndAngle >= 0.0)
      {
        ((CustomDataSurrogate) buLine).Orientation = new OrientationAngle(EndAngle, 0.0, Position.C + 180.0);
        buCall.\u0001.CamDirectionChange(ref ((CustomData) buLine).sortDirection);
      }
      else
        ((CustomDataSurrogate) buLine).Orientation = new OrientationAngle(-EndAngle, 0.0, Position.C);
      ((CustomData) buLine).Marble = (MarbleInfo) new Line2D();
      buEntityList2.Add((buEntity) buLine);
    }
    if (StartMode)
    {
      if (buEntityList2.Count <= 0)
        return;
      if (Entities.Count == 0)
        Entities.Add(buEntityList2);
      else if (!AddAllLines)
      {
        if (LastA != StartAngle)
        {
          Entities.Add(buEntityList2);
        }
        else
        {
          if (buConversion5.EQ(Position.C, 0.0))
            return;
          Entities.Add(buEntityList2);
        }
      }
      else
        Entities.Add(buEntityList2);
    }
    else
    {
      if (buEntityList2.Count <= 0)
        return;
      Entities.Add(buEntityList2);
    }
  }

  public void MarblecalcItemCam(
    ToolBase5 Tool,
    KinematicBase5 Kinematic,
    MarbleJob Job,
    int indexBase,
    bool isLast,
    TpPnt9D LastP9,
    MarbleItem Item,
    ref MarbleItemCam marbleCam)
  {
    // ISSUE: unable to decompile the method.
  }
}
