// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileSupportBlock
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.Marble;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileSupportBlock : buSerilization5
{
  public double Layer7Speed;
  public double Layer8Speed;
  public double Layer9Speed;
  public static List<string> Captions;
  public buNestingSheetSettings MaterailSettings;
  public buNestingPartSettings PartSettings;
  public buNestingSheetAddData AddMaterial;
  public buNestingPartAddData AddPart;
  public buNestingSettings Settings;
  public buNestingProgramSettings ProgramSettings;

  public void GetOperationWithName(
    ProfileItem Profile,
    string OperationName,
    ref ProfileOperation foundOP)
  {
    for (int index = 0; index <= ((ProfileSettings) Profile).Operations.Count - 1; ++index)
    {
      if (((ProfileRuntimeSettings) ((ProfileSettings) Profile).Operations[index]).Name == OperationName)
      {
        foundOP = (ProfileOperation) new buMarbleCalc();
        buMarbleCalc.Copy(((ProfileSettings) Profile).Operations[index], ref foundOP);
        break;
      }
    }
  }

  public bool isOperationEnableFromName(ProfileItem Profile, string OperationName)
  {
    bool flag;
    for (int index = 0; index <= ((ProfileSettings) Profile).Operations.Count - 1; ++index)
    {
      if (((ProfileRuntimeSettings) ((ProfileSettings) Profile).Operations[index]).Name == OperationName)
      {
        flag = ((ProfileRuntimeSettings) ((ProfileSettings) Profile).Operations[index]).Enable;
        goto label_6;
      }
    }
    flag = false;
label_6:
    return flag;
  }
}
