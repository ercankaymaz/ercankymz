// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camParameters5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camParameters5 : buSerilization5
{
  public bool isCW;
  public bool isReverse;
  public static byte f0001B2;
  public List<Pnt6DSimMove> SimMove;
  public string Aux1;
  public string Aux2;
  public SimulationMoveCommand MoveCommand;
  public object Obj1;
  public static byte f0001B8;
  public camOptions5 Options;
  public camOperation5 Operations;
  public camDistances5 Distances;
  public camStep5 Steps;
  public camSpeeds5 Speeds;
  public camOffset5 Offsets;
  public camPocket5 Pockets;
  public camStrategy5 Strategy;
  public camRotary5 Rotary;

  public camParameters5(TpArcData arc)
  {
    ((TpArcData) this).StartPoint = new Point3D();
    ((TpArcData) this).EndPoint = new Point3D();
    ((TpArcData) this).CenterPoint = new Point3D();
    ((SimulationTp) this).Radius = 0.0;
    ((SimulationTp) this).Length = 0.0;
    ((SimulationTp) this).SweepAngle = 0.0;
    ((SimulationTp) this).StartAngle = 0.0;
    ((SimulationTp) this).EndAngle = 0.0;
    this.isCW = false;
    this.isReverse = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).CenterPoint = F_NotchEdit.ToPoint3D(arc.CenterPoint);
    ((SimulationTp) this).Radius = ((SimulationTp) arc).Radius;
    ((SimulationTp) this).SweepAngle = ((SimulationTp) arc).SweepAngle;
    this.isCW = ((camParameters5) arc).isCW;
    ((SimulationTp) this).StartAngle = ((SimulationTp) arc).StartAngle;
    ((SimulationTp) this).EndAngle = ((SimulationTp) arc).EndAngle;
    ((TpArcData) this).StartPoint = F_NotchEdit.ToPoint3D(arc.StartPoint);
    ((TpArcData) this).EndPoint = F_NotchEdit.ToPoint3D(arc.EndPoint);
  }

  public camParameters5(Point3D Center, double Rad, double StartAng, double EndAng)
  {
    ((TpArcData) this).StartPoint = new Point3D();
    ((TpArcData) this).EndPoint = new Point3D();
    ((TpArcData) this).CenterPoint = new Point3D();
    ((SimulationTp) this).Radius = 0.0;
    ((SimulationTp) this).Length = 0.0;
    ((SimulationTp) this).SweepAngle = 0.0;
    ((SimulationTp) this).StartAngle = 0.0;
    ((SimulationTp) this).EndAngle = 0.0;
    this.isCW = false;
    this.isReverse = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).CenterPoint = F_NotchEdit.ToPoint3D(Center);
    ((SimulationTp) this).Radius = Rad;
    ((SimulationTp) this).StartAngle = StartAng;
    ((SimulationTp) this).EndAngle = EndAng;
  }

  public camParameters5(Point3D Center, Point3D startPoint, Point3D endPoint)
  {
    ((TpArcData) this).StartPoint = new Point3D();
    ((TpArcData) this).EndPoint = new Point3D();
    ((TpArcData) this).CenterPoint = new Point3D();
    ((SimulationTp) this).Radius = 0.0;
    ((SimulationTp) this).Length = 0.0;
    ((SimulationTp) this).SweepAngle = 0.0;
    ((SimulationTp) this).StartAngle = 0.0;
    ((SimulationTp) this).EndAngle = 0.0;
    this.isCW = false;
    this.isReverse = false;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TpArcData) this).CenterPoint = F_NotchEdit.ToPoint3D(Center);
    ((TpArcData) this).StartPoint = F_NotchEdit.ToPoint3D(startPoint);
    ((TpArcData) this).EndPoint = F_NotchEdit.ToPoint3D(endPoint);
  }

  public override string ToString()
  {
    return $"Arc - Center : {((TpArcData) this).CenterPoint.ToString()} , Rad : {((SimulationTp) this).Radius.ToString()} , SA : {((SimulationTp) this).StartAngle.ToString()} , EA : {((SimulationTp) this).EndAngle.ToString()}";
  }

  public abstract void m0000F0();

  public camParameters5() => ((pageInfo) this).\u002Ector();

  public camParameters5(SimulationTp sim)
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    this.SimMove.Clear();
    for (int index = 0; index <= ((camParameters5) sim).SimMove.Count - 1; ++index)
      this.SimMove.Add((Pnt6DSimMove) new AlingmentPoints3D(((camParameters5) sim).SimMove[index]));
  }

  public override string ToString() => "Count: " + this.SimMove.Count.ToString();

  public abstract void m0000F4();

  public camParameters5()
  {
    ((camRuntime5) this).Hole = (camHole5) new camDrill5();
    ((camRuntime5) this).Material = (camMaterial5) new camPocket5();
    ((camRuntime5) this).LeadIn = (LeadIn5) new camResult();
    ((camOffset5) this).LeadOut = (LeadOut5) new CamEntitiesToGEntities();
    ((camOffset5) this).Hatch = (camHatch5) new camNotch5();
    ((camOffset5) this).Drill = (camDrill5) new camOperation5();
    ((camOffset5) this).Notch = (camNotch5) new LeadOut5();
    ((camOffset5) this).Runtime = (camRuntime5) new camStep5();
    ((camOffset5) this).Sorting = (SortSettings) new ShapeRuntimeData();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
