// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.WoodJob
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class WoodJob : buSerilization5
{
  public double VShapeHeightRoughSpindleSpeed;
  public double VShapeHeightFinishSpindleSpeed;
  public bool VShapeHeightZigzag;
  public int VShapeHeightToolNo;
  public double FeedDistance;
  public int FeedCount;
  public double GrindingLength;
  public double ToolPersentage;
  public double NickWidth;
  public double NickDepth;

  static WoodJob()
  {
    PipeBendTempVars.varGrindingShape = (DiemakerGrindingShapeSettings) new WoodJob();
  }

  public WoodJob()
  {
    ((PipeBendMoveCommand) this).BaseMaterialHeight = 23.9;
    ((PipeBendMoveCommand) this).TargetMaterialHeight = 23.8;
    ((buWood) this).MaterialThickness = 0.71;
    ((buWood) this).VShapeTargetAngle = 42.0;
    ((buWood) this).VShapeHeightWidth = 5.0;
    ((buWood) this).VShapeHeightRoughDepth = 0.05;
    ((buWood) this).VShapeHeightFinishDepth = 0.01;
    ((buWood) this).VShapeHeightRoughVel = 40.0;
    ((buWood) this).VShapeHeightFinishVel = 5.0;
    this.VShapeHeightRoughSpindleSpeed = 3000.0;
    this.VShapeHeightFinishSpindleSpeed = 4000.0;
    this.VShapeHeightZigzag = true;
    this.VShapeHeightToolNo = 2;
    this.FeedDistance = 3.0;
    this.FeedCount = 1;
    this.GrindingLength = 10.0;
    this.ToolPersentage = 80.0;
    this.NickWidth = 5.0;
    this.NickDepth = 22.0;
    ((WoodSettings) this).NickFinishDepth = 0.01;
    ((WoodSettings) this).NickRoughVel = 40.0;
    ((WoodSettings) this).NickFinishVel = 5.0;
    ((WoodSettings) this).NickRoughSpindleSpeed = 3000.0;
    ((WoodSettings) this).NickFinishSpindleSpeed = 4000.0;
    ((WoodSettings) this).NickToolNo = 2;
    ((WoodSettings) this).NickEnable = false;
    ((WoodSettings) this).NickReverseDir = false;
    ((WoodSettings) this).VShapeAngleEnable = true;
    ((WoodRuntimeSettings) this).VShapeAngleWidth = 5.0;
    ((WoodRuntimeSettings) this).VShapeAngleRoughDepth = 0.05;
    ((WoodRuntimeSettings) this).VShapeAngleFinishDepth = 0.01;
    ((WoodRuntimeSettings) this).VShapeAngleRoughVel = 40.0;
    ((WoodRuntimeSettings) this).VShapeAngleFinishVel = 5.0;
    ((WoodTempVars) this).VShapeAngleRoughSpindleSpeed = 3000.0;
    ((WoodTempVars) this).VShapeAngleFinishSpindleSpeed = 4000.0;
    ((WoodTempVars) this).VShapeAngleOffset = -0.02;
    ((WoodTempVars) this).VShapeAngleZigzag = true;
    ((WoodTempVars) this).VShapeAngleToolNo = 2;
    ((WoodTempVars) this).VShapeAngleFinishCount = 1;
    ((WoodItemType) this).VShapeAngleUpDownMode = UpDownDirectionType.UpToDown;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public WoodJob(DiemakerGrindingShapeSettings data)
  {
    ((PipeBendMoveCommand) this).BaseMaterialHeight = 23.9;
    ((PipeBendMoveCommand) this).TargetMaterialHeight = 23.8;
    ((buWood) this).MaterialThickness = 0.71;
    ((buWood) this).VShapeTargetAngle = 42.0;
    ((buWood) this).VShapeHeightWidth = 5.0;
    ((buWood) this).VShapeHeightRoughDepth = 0.05;
    ((buWood) this).VShapeHeightFinishDepth = 0.01;
    ((buWood) this).VShapeHeightRoughVel = 40.0;
    ((buWood) this).VShapeHeightFinishVel = 5.0;
    this.VShapeHeightRoughSpindleSpeed = 3000.0;
    this.VShapeHeightFinishSpindleSpeed = 4000.0;
    this.VShapeHeightZigzag = true;
    this.VShapeHeightToolNo = 2;
    this.FeedDistance = 3.0;
    this.FeedCount = 1;
    this.GrindingLength = 10.0;
    this.ToolPersentage = 80.0;
    this.NickWidth = 5.0;
    this.NickDepth = 22.0;
    ((WoodSettings) this).NickFinishDepth = 0.01;
    ((WoodSettings) this).NickRoughVel = 40.0;
    ((WoodSettings) this).NickFinishVel = 5.0;
    ((WoodSettings) this).NickRoughSpindleSpeed = 3000.0;
    ((WoodSettings) this).NickFinishSpindleSpeed = 4000.0;
    ((WoodSettings) this).NickToolNo = 2;
    ((WoodSettings) this).NickEnable = false;
    ((WoodSettings) this).NickReverseDir = false;
    ((WoodSettings) this).VShapeAngleEnable = true;
    ((WoodRuntimeSettings) this).VShapeAngleWidth = 5.0;
    ((WoodRuntimeSettings) this).VShapeAngleRoughDepth = 0.05;
    ((WoodRuntimeSettings) this).VShapeAngleFinishDepth = 0.01;
    ((WoodRuntimeSettings) this).VShapeAngleRoughVel = 40.0;
    ((WoodRuntimeSettings) this).VShapeAngleFinishVel = 5.0;
    ((WoodTempVars) this).VShapeAngleRoughSpindleSpeed = 3000.0;
    ((WoodTempVars) this).VShapeAngleFinishSpindleSpeed = 4000.0;
    ((WoodTempVars) this).VShapeAngleOffset = -0.02;
    ((WoodTempVars) this).VShapeAngleZigzag = true;
    ((WoodTempVars) this).VShapeAngleToolNo = 2;
    ((WoodTempVars) this).VShapeAngleFinishCount = 1;
    ((WoodItemType) this).VShapeAngleUpDownMode = UpDownDirectionType.UpToDown;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
