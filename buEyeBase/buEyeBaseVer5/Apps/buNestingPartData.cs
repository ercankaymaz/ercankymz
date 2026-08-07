// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingPartData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingPartData : buSerilization5
{
  public double ToolRepeatDistance;
  public bool SimulationDevideEnable;
  public double SimulationDevideG0Length;
  public double SimulationDevideG1Length;
  public double SlotMinLengthForBottomSpindleAtClamperArea;
  public double SlotMinLengthForTopSpindleAtClamperArea;
  public double ContourMinLengthForBottomSpindleAtClamperArea;
  public double ContourMinLengthForTopSpindleAtClamperArea;
  public double ContourLimitLenForTopSpindleOneMove;
  public double ContourLimitLenForBottomSpindleOneMove;
  public ClockDirectionType ContourTopDirection;
  public ClockDirectionType ContourBottomDirection;
  public double ParkX1;
  public double ParkX2;
  public double ParkY1;

  public buNestingPartData(SewingSelectedPoint data)
  {
    ((DrillCNCSettings) this).refPoint = new Point3D();
    ((DrillCNCSettings) this).VertexIndex = -1;
    ((DrillCNCSettings) this).EntityIndex = -1;
    ((DrillCNCSettings) this).CatchPosition = StartMiddleEndType.Start;
    ((DrillCNCSettings) this).isStitch = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"{((DrillCNCSettings) this).CatchPosition.ToString()} - Ent Index: {((DrillCNCSettings) this).EntityIndex.ToString()} - PointIndex: {((DrillCNCSettings) this).VertexIndex.ToString()} - X: {((DrillCNCSettings) this).refPoint.X.ToString()} - Y: {((DrillCNCSettings) this).refPoint.Y.ToString()}";
  }

  public abstract void m001BE1();

  public buNestingPartData()
    : this()
  {
  }
}
