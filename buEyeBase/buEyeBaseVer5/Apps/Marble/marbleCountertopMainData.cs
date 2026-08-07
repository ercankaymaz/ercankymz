// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCountertopMainData
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
public class marbleCountertopMainData : buSerilization5
{
  public bool isConvex;
  public bool isInside;
  public bool isInsideSecond;
  public bool ReverseThetaCalculation;
  public bool FirstCornerCalculated;
  public double MinLength;
  public double ConvexLength;
  public double ConcaveLength;
  public double ConvexMinRadius;
  public double Depth;
  public int EntityIndex;
  public int EntitySubIndex;
  public ClockDirectionType ClockDir;
  public static byte f004C99;
  public bool Enable;
  public double Length;
  public int Count;
  public double StartAngle;
  public double EndAngle;
  public static List<string> Captions;

  public void doSingleCut(
    Pnt6D Position,
    ToolBase5 Tool,
    MarbleItemSettings varOperation,
    KinematicBase5 Kinematic,
    EntitiesResolution Resolution,
    ref List<MarbleItem> Items,
    MarbleSliceType SliceType,
    bool isFinished = true)
  {
    // ISSUE: unable to decompile the method.
  }

  public void doMultiCut(
    Pnt6D PositionHor,
    Pnt6D PositionVer,
    ToolBase5 Tool,
    List<marbleCuttingItems> ItemsHor,
    List<marbleCuttingItems> ItemsVer,
    MarbleItemSettings varOperation,
    KinematicBase5 Kinematic,
    EntitiesResolution Resolution,
    ref List<MarbleItem> Items,
    MarbleSliceType SliceType,
    double HorLength,
    double VerLength,
    bool isFinished = true)
  {
    // ISSUE: unable to decompile the method.
  }

  public void doPerpendicularCut(
    Pnt6D HorizontalPosition,
    Pnt6D VerticalPosition,
    ToolBase5 Tool,
    List<marbleCuttingItems> HorizontalItems,
    List<marbleCuttingItems> VerticalItems,
    MarbleItemSettings varOperation,
    KinematicBase Kinematic,
    EntitiesResolution Resolution,
    ref camTp Cam)
  {
  }

  public void HorizontalItemsCalc(
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
    double y = 0.0;
    double LastA = 0.0;
    double num1 = 1.0;
    Entity SurfaceEntity = (Entity) null;
    double materialThickness = ((MarbleCamType) ((MarbleMachineSimultionSettings) varOperation).MaterialParameter).MaterialThickness;
    double num2 = Math.Round(Position.C);
    if (Items.Count == 0)
      return;
    if (((marbleCountertopMainData) Items[0]).Length < 0.0)
      num1 = -1.0;
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
        num6 = 0.0;
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
      buCall.\u0001.Trapezoid3D(new Point3D(Position.X, Position.Y, ((MarbleCamType) ((MarbleMachineSimultionSettings) varOperation).MaterialParameter).MaterialThickness), num5, ((MarbleCamType) ((MarbleMachineSimultionSettings) varOperation).MaterialParameter).MaterialThickness - ((marbleEdgeItem) ((MarbleMachineSimultionSettings) varOperation).settingMarbleCam).TargetZ, num3 + 90.0, num4 + 90.0, new Vec3D(1.0, 0.0, 0.0), CutLength, num2, ref TopFirstLine, ref BottomFirstLine, ref TopLastLine, ref BottomLastLine, ref SurfaceEntity);
      if (num1 < 0.0)
      {
        num3 *= -1.0;
        num4 *= -1.0;
      }
      int Cnt = 0;
      for (int index2 = 0; index2 <= ((marbleCountertopMainData) Items[index1]).Count - 1; ++index2)
      {
        double num7 = 0.0;
        double num8 = Math.Abs(((marbleCountertopMainData) Items[index1]).Length) / Math.Cos(buString5.DegreeToRadian(num2));
        double num9 = 0.0;
        double num10 = Thickness / Math.Cos(buString5.DegreeToRadian(Math.Abs(num3)));
        double num11 = Thickness / Math.Cos(buString5.DegreeToRadian(Math.Abs(num4)));
        double num12 = Thickness / 2.0 / Math.Cos(buString5.DegreeToRadian(Math.Abs(num3)));
        double num13 = Thickness / 2.0 / Math.Cos(buString5.DegreeToRadian(Math.Abs(num4)));
        double num14 = num11;
        Entity refEntities1 = buVector5.CopyEntities(SurfaceEntity);
        buCall.\u0001.Move(new Point3D(), new Point3D(0.0, y, 0.0), ref refEntities1);
        buEntity rectangleEntity = (buEntity) null;
        buCall.\u0001.DrawRectangle(new Point3D(Position.X, Position.Y + y, 0.0), CutLength, num5, Plane.XY, ref rectangleEntity);
        ((buLinearDim) rectangleEntity).Rotate(-num2, Vector3D.AxisZ, new Point3D(Position.X, Position.Y + y, 0.0));
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
        buCall.\u0001.Move(new Point3D(), new Point3D(0.0, y - num15, 0.0), ref refEntities2);
        buCall.\u0001.Move(new Point3D(), new Point3D(0.0, y - num15, 0.0), ref refEntities3);
        ((marbleCountertopInsideData) this).MarblecalcItemLines(((CustomData) refEntities2).StartPoint, ((CustomData) refEntities3).StartPoint, ((CustomData) refEntities2).EndPoint, ((CustomData) refEntities3).EndPoint, num3, num4, LastA, Position, true, true, false, varOperation, ref CalcLines, ref Cnt);
        if (!AlwaysSAandEAZero)
          ++Cnt;
        buCall.\u0001.Move(new Point3D(), new Point3D(0.0, y + num13, 0.0), ref refEntities4);
        buCall.\u0001.Move(new Point3D(), new Point3D(0.0, y + num13, 0.0), ref refEntities5);
        ((marbleCountertopInsideData) this).MarblecalcItemLines(((CustomData) refEntities4).StartPoint, ((CustomData) refEntities5).StartPoint, ((CustomData) refEntities4).EndPoint, ((CustomData) refEntities5).EndPoint, num3, num4, LastA, Position, false, true, false, varOperation, ref CalcLines, ref Cnt);
        LastA = num4 * -1.0;
        y = y + num8 + num14 + num9;
        if (!AlwaysSAandEAZero)
          ++Cnt;
      }
    }
    if (num1 >= 0.0)
      return;
    buCall.\u0001.Mirror(new Point3D(0.0, Position.Y, 0.0), new Point3D(1.0, Position.Y, 0.0), Plane.XY, ref Entities);
    buCall.\u0001.Mirror(new Point3D(0.0, Position.Y, 0.0), new Point3D(1.0, Position.Y, 0.0), Plane.XY, ref CalcLines);
    buCall.\u0001.Mirror(new Point3D(0.0, Position.Y, 0.0), new Point3D(1.0, Position.Y, 0.0), Plane.XY, ref entRectangles);
  }
}
