// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileExistingClamperCompare
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileExistingClamperCompare : buSerilization5
{
  public double Angle;
  public string Text;
  public bool isWire;
  public Font TextFont;
  public static byte f0044DF;

  public void AddWarningToOperation(string strWarning, ref ProfileOperation OP)
  {
    if (((ProfileRuntimeSettings) OP).warningList.Count == 0)
    {
      ((ProfileRuntimeSettings) OP).warningList.Add(strWarning);
    }
    else
    {
      for (int index = 0; index <= ((ProfileRuntimeSettings) OP).warningList.Count - 1; ++index)
      {
        if (((ProfileRuntimeSettings) OP).warningList[index] == strWarning)
          return;
      }
      ((ProfileRuntimeSettings) OP).warningList.Add(strWarning);
    }
  }

  public void AddErrorToOperation(string strError, ref ProfileOperation OP)
  {
    if (((ProfileRuntimeSettings) OP).errorList.Count == 0)
    {
      ((ProfileRuntimeSettings) OP).errorList.Add(strError);
    }
    else
    {
      for (int index = 0; index <= ((ProfileRuntimeSettings) OP).errorList.Count - 1; ++index)
      {
        if (((ProfileRuntimeSettings) OP).errorList[index] == strError)
        {
          if (((ProfileRuntimeSettings) OP).errorList.Count <= 0)
            return;
          ((ProfileRuntimeSettings) OP).Error = true;
          return;
        }
      }
      ((ProfileRuntimeSettings) OP).errorList.Add(strError);
    }
    if (((ProfileRuntimeSettings) OP).errorList.Count <= 0)
      return;
    ((ProfileRuntimeSettings) OP).Error = true;
  }

  public void AddInfoToOperation(string strInfo, ref ProfileOperation OP)
  {
    if (((ProfileRuntimeSettings) OP).infoList.Count == 0)
    {
      ((ProfileRuntimeSettings) OP).infoList.Add(strInfo);
    }
    else
    {
      for (int index = 0; index <= ((ProfileRuntimeSettings) OP).infoList.Count - 1; ++index)
      {
        if (((ProfileRuntimeSettings) OP).infoList[index] == strInfo)
          return;
      }
      ((ProfileRuntimeSettings) OP).infoList.Add(strInfo);
    }
  }

  public static string ToolToString(ToolBase5 Tool)
  {
    return Tool != null ? $"{((ToolCamData5) ((ToolGeometry5) Tool).Data).Name} - T: {((ToolCamData5) ((ToolGeometry5) Tool).Data).No.ToString()}" : "";
  }
}
