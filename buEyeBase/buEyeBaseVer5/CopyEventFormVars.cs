// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.CopyEventFormVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class CopyEventFormVars : buSerilization5
{
  public bool PlaneAll;
  public bool PlaneSlope;
  public bool RotationA;
  public bool RotationB;
  public bool RotationC;

  public CopyEventFormVars(ToolCamData5 cam)
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
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) cam, ref CopiedClass);
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

  public CopyEventFormVars(ToolCamData cam)
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
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) cam, ref CopiedClass);
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
}
