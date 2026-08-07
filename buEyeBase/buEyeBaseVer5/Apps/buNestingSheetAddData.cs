// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingSheetAddData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingSheetAddData : buSerilization5
{
  public double HorizontalTableTopSurfaceZLimit;
  public double MaterialFeedMaxDistance;
  public double ProfilingLeadInDistance;
  public double ProfilingLeadOutDistance;
  public double ReclineDiameter;
  public double ToolPistonVerticalDistance;
  public double ToolPistonHorizontalDistance;
  public double HorizontalToolHolderWidth;
  public double ToolPistonSawDistance;
  public double ToolTopSpindlePistonDistance;
  public double ToolBottomSpindlePistonDistance;

  public override string ToString()
  {
    return $"{((DrillCNCSettings) this).Defination.ToString()} : {((DrillCNCSettings) this).No.ToString()}";
  }

  public abstract void m001BDD();

  public buNestingSheetAddData()
  {
    ((DrillCNCSettings) this).refPoint = new Point3D();
    ((DrillCNCSettings) this).VertexIndex = -1;
    ((DrillCNCSettings) this).EntityIndex = -1;
    ((DrillCNCSettings) this).CatchPosition = StartMiddleEndType.Start;
    ((DrillCNCSettings) this).isStitch = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
