// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationDataBarel
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataBarel : buSerilization5
{
  public double ApproxExecution7Len;
  public double ApproxExecution8Len;
  public double ApproxExecution9Len;
  public double ApproxExecution0TimeSec;
  public double ApproxExecution1TimeSec;
  public double ApproxExecution2TimeSec;

  static ProfileOperationDataBarel() => ProfileSupportBlock.Captions = new List<string>();

  public ProfileOperationDataBarel()
  {
    ((ProfileSupportBlock) this).MaterailSettings = (buNestingSheetSettings) new ProfileOperationRectangle();
    ((ProfileSupportBlock) this).PartSettings = (buNestingPartSettings) new ProfileOperationHole();
    ((ProfileSupportBlock) this).AddMaterial = (buNestingSheetAddData) new ProfileOperationSlot();
    ((ProfileSupportBlock) this).AddPart = (buNestingPartAddData) new ProfileOperationNotch();
    ((ProfileSupportBlock) this).Settings = (buNestingSettings) new ProfileOperationDataRectangleRound();
    ((ProfileSupportBlock) this).ProgramSettings = (buNestingProgramSettings) new ProfileOperationDataRectangleRound();
    ((ProfileMultiply) this).ResultSettings = (buNestingResultSettings) new ProfileOperationDataRectangle();
    ((ProfileMultiply) this).Runtime = (buNestingRuntime) new ProfileOperationDataBarel();
    ((ProfileMultiply) this).Draw = (buNestingDraw) new ProfileOperationDataRectangle();
    ((ProfileMultiply) this).AnalyseSettings = (AnalyseEntitiesSetting) new PlaneAngle();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ProfileOperationDataBarel(buNestingVar data)
  {
    ((ProfileSupportBlock) this).MaterailSettings = (buNestingSheetSettings) new ProfileOperationRectangle();
    ((ProfileSupportBlock) this).PartSettings = (buNestingPartSettings) new ProfileOperationHole();
    ((ProfileSupportBlock) this).AddMaterial = (buNestingSheetAddData) new ProfileOperationSlot();
    ((ProfileSupportBlock) this).AddPart = (buNestingPartAddData) new ProfileOperationNotch();
    ((ProfileSupportBlock) this).Settings = (buNestingSettings) new ProfileOperationDataRectangleRound();
    ((ProfileSupportBlock) this).ProgramSettings = (buNestingProgramSettings) new ProfileOperationDataRectangleRound();
    ((ProfileMultiply) this).ResultSettings = (buNestingResultSettings) new ProfileOperationDataRectangle();
    ((ProfileMultiply) this).Runtime = (buNestingRuntime) new ProfileOperationDataBarel();
    ((ProfileMultiply) this).Draw = (buNestingDraw) new ProfileOperationDataRectangle();
    ((ProfileMultiply) this).AnalyseSettings = (AnalyseEntitiesSetting) new PlaneAngle();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ProfileSupportBlock) this).MaterailSettings = (buNestingSheetSettings) new ProfileOperationSlot(((ProfileSupportBlock) data).MaterailSettings);
    ((ProfileSupportBlock) this).PartSettings = (buNestingPartSettings) new ProfileOperationNotch(((ProfileSupportBlock) data).PartSettings);
    ((ProfileSupportBlock) this).AddMaterial = (buNestingSheetAddData) new ProfileOperationCut(((ProfileSupportBlock) data).AddMaterial);
    ((ProfileSupportBlock) this).AddPart = (buNestingPartAddData) new ProfileOperationNotchOld(((ProfileSupportBlock) data).AddPart);
    ((ProfileSupportBlock) this).Settings = (buNestingSettings) new ProfileOperationDataRectangleRound(((ProfileSupportBlock) data).Settings);
    ((ProfileMultiply) this).ResultSettings = (buNestingResultSettings) new ProfileOperationDataRectangle(((ProfileMultiply) data).ResultSettings);
    ((ProfileMultiply) this).Runtime = (buNestingRuntime) new ProfileOperationDataBarel(((ProfileMultiply) data).Runtime);
    ((ProfileMultiply) this).Draw = (buNestingDraw) new ProfileOperationDataRectangle(((ProfileMultiply) data).Draw);
    ((ProfileSupportBlock) this).ProgramSettings = (buNestingProgramSettings) new ProfileOperationDataRectangleRound(((ProfileSupportBlock) data).ProgramSettings);
  }

  public ProfileOperationDataBarel()
  {
    // ISSUE: unable to decompile the method.
  }

  public ProfileOperationDataBarel(buNestingRuntime data)
  {
    // ISSUE: unable to decompile the method.
  }

  static ProfileOperationDataBarel() => ProfileTempVars.Captions = new List<string>();
}
