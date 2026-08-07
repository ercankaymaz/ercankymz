// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.LayerOverride
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class LayerOverride : buSerilization5
{
  public bool PlaneFront;
  public bool PlaneBack;
  public bool PlaneLeft;
  public bool PlaneRight;

  public abstract void m0001A3();

  public LayerOverride()
  {
    ((ToolLimits5) this).DepthConstant = 1.0;
    ((ToolLimits5) this).DepthSliceCount = 2;
    ((ToolLimits5) this).DepthType = CamDepthType.Constant;
    ((ToolLimits5) this).Stepover = 0.0;
    ((ToolLimits5) this).Cutover = 0.0;
    ((ToolLimits5) this).OperationHeight = 0.0;
    ((ToolLimits5) this).AreaClearanceSpeed = 100.0;
    ((ToolLimits5) this).FinishSpeed = 100.0;
    ((ToolLimits5) this).RetractSpeed = 100.0;
    ((ToolLimits5) this).FeedSpeed = 100.0;
    ((ToolPositions5) this).PlungeSpeed = 30.0;
    ((ToolPositions5) this).LeaveSpeed = 50.0;
    ((ToolPositions5) this).SpindleSpeed = 10000.0;
    ((ToolPositions5) this).OperationHeigthForSecond = 0.0;
    ((ToolPositions5) this).ExtraOffset = 0.0;
    ((LayerBase5) this).SafeDistance = 100.0;
    ((LayerBase5) this).RapidDistance = 40.0;
    ((LayerBase5) this).WaitTime = 0.0;
    ((LayerBase5) this).DepthOffset = 0.0;
    ((LayerBase5) this).Air = false;
    ((LayerBase5) this).Water = false;
    ((LayerBase5) this).Oil = false;
    ((LayerBase5) this).Dust = false;
    ((LayerBase5) this).InnerCooling = false;
    ((LayerBase5) this).FeedFromTool = false;
    ((LayerBase5) this).DistanceFromTool = false;
    ((LayerBase5) this).DepthFromTool = false;
    ((LayerBase5) this).CutOverrideFromTool = true;
    ((LayerBase5) this).SpindleReverseDir = false;
    ((LayerBase5) this).AirText = new ArrayList();
    ((LayerBase5) this).OilText = new ArrayList();
    ((LayerBase5) this).WaterText = new ArrayList();
    ((LayerBase5) this).InnerCoolText = new ArrayList();
    ((LayerBase5) this).SimMoveOffset = new Pnt6D();
    ((LayerBase5) this).SpindleDirection = ClockDirectionType.CW;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
