// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationDataRectangleRound
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataRectangleRound : buSerilization5
{
  public double ApproxExecution1Len;
  public double ApproxExecution2Len;
  public double ApproxExecution3Len;
  public double ApproxExecution4Len;
  public double ApproxExecution5Len;
  public double ApproxExecution6Len;

  static ProfileOperationDataRectangleRound()
  {
    ProfileClamperSettings.Captions = new List<string>();
  }

  public ProfileOperationDataRectangleRound()
  {
    ((ProfileClamperSettings) this).NestingThreadCalculationCount = 2;
    ((ProfileClamperSettings) this).NestExecutionByThread = true;
    ((ProfileClamperSettings) this).GarbageCollectionDisableSize = 200000000;
    ((ProfileClamperSettings) this).ShowResultPreviewAfterFinish = false;
    ((ProfileClamperSettings) this).ShowBetterResult = true;
    ((ProfileClamperSettings) this).DeleteNestedPartAfterNesting = false;
    ((ProfileClamperSettings) this).UseCallBacks = true;
    ((ProfileClamperSettings) this).UseCompactMethod = false;
    ((ProfileClamperSettings) this).CompactTime = 10.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ProfileOperationDataRectangleRound(buNestingSettings data)
  {
    ((ProfileClamperSettings) this).NestingThreadCalculationCount = 2;
    ((ProfileClamperSettings) this).NestExecutionByThread = true;
    ((ProfileClamperSettings) this).GarbageCollectionDisableSize = 200000000;
    ((ProfileClamperSettings) this).ShowResultPreviewAfterFinish = false;
    ((ProfileClamperSettings) this).ShowBetterResult = true;
    ((ProfileClamperSettings) this).DeleteNestedPartAfterNesting = false;
    ((ProfileClamperSettings) this).UseCallBacks = true;
    ((ProfileClamperSettings) this).UseCompactMethod = false;
    ((ProfileClamperSettings) this).CompactTime = 10.0;
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

  static ProfileOperationDataRectangleRound()
  {
    ProfileClamperSettings.Captions = new List<string>();
  }

  public ProfileOperationDataRectangleRound()
  {
    ((ProfileClamperSettings) this).UnitLength = LengthUnit.mm;
    ((ProfileClamperSettings) this).UnitArea = LengthUnit.m;
    ((ProfileClamperSettings) this).UnitSpeed = SpeedUnit.mmPerMin;
    ((ProfileClamperSettings) this).CalculationShowFormat = nestCalculationShowFormat.PastalAsSingleSheet;
    ((ProfileClamperSettings) this).isCutter = false;
    ((ProfileClamperSettings) this).View3D = true;
    ((ProfileClamperSettings) this).DoubleSheetAtPdf = true;
    ((ProfileClamperSettings) this).PenUpTime = 0.2;
    ((ProfileClamperSettings) this).PenDownTime = 0.2;
    ((ProfileClamperSettings) this).CuttingSpeed = 500.0;
    ((ProfileClamperSettings) this).NoneCuttingSpeed = 800.0;
    ((ProfileClamperSettings) this).UseNoneCutting = true;
    ((ProfileClamperSettings) this).TextTime = 0.0;
    ((ProfileLengthClamperCount) this).Layer0Speed = 1000.0;
    ((ProfileLengthClamperCount) this).Layer1Speed = 1200.0;
    ((ProfileDrawings) this).Layer2Speed = 1400.0;
    ((ProfileDrawings) this).Layer3Speed = 1000.0;
    ((ProfileDrawings) this).Layer4Speed = 1000.0;
    ((ProfileDrawings) this).Layer5Speed = 1000.0;
    ((ProfileDrawings) this).Layer6Speed = 1000.0;
    ((ProfileSupportBlock) this).Layer7Speed = 1000.0;
    ((ProfileSupportBlock) this).Layer8Speed = 1000.0;
    ((ProfileSupportBlock) this).Layer9Speed = 1000.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ProfileOperationDataRectangleRound(buNestingProgramSettings data)
  {
    ((ProfileClamperSettings) this).UnitLength = LengthUnit.mm;
    ((ProfileClamperSettings) this).UnitArea = LengthUnit.m;
    ((ProfileClamperSettings) this).UnitSpeed = SpeedUnit.mmPerMin;
    ((ProfileClamperSettings) this).CalculationShowFormat = nestCalculationShowFormat.PastalAsSingleSheet;
    ((ProfileClamperSettings) this).isCutter = false;
    ((ProfileClamperSettings) this).View3D = true;
    ((ProfileClamperSettings) this).DoubleSheetAtPdf = true;
    ((ProfileClamperSettings) this).PenUpTime = 0.2;
    ((ProfileClamperSettings) this).PenDownTime = 0.2;
    ((ProfileClamperSettings) this).CuttingSpeed = 500.0;
    ((ProfileClamperSettings) this).NoneCuttingSpeed = 800.0;
    ((ProfileClamperSettings) this).UseNoneCutting = true;
    ((ProfileClamperSettings) this).TextTime = 0.0;
    ((ProfileLengthClamperCount) this).Layer0Speed = 1000.0;
    ((ProfileLengthClamperCount) this).Layer1Speed = 1200.0;
    ((ProfileDrawings) this).Layer2Speed = 1400.0;
    ((ProfileDrawings) this).Layer3Speed = 1000.0;
    ((ProfileDrawings) this).Layer4Speed = 1000.0;
    ((ProfileDrawings) this).Layer5Speed = 1000.0;
    ((ProfileDrawings) this).Layer6Speed = 1000.0;
    ((ProfileSupportBlock) this).Layer7Speed = 1000.0;
    ((ProfileSupportBlock) this).Layer8Speed = 1000.0;
    ((ProfileSupportBlock) this).Layer9Speed = 1000.0;
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
}
