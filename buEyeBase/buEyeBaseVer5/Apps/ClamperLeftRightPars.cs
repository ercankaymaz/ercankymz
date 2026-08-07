// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ClamperLeftRightPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ClamperLeftRightPars : buSerilization5
{
  public UpDownLocationType UpDown;
  public LeftRightLocationType LeftRight;
  public static byte f0044D4;
  public double Width;
  public double Height;
  public double Angle;
  public static byte f0044D8;
  public double Width;
  public double Height;

  public void AddWarningToProfile(string strWarning, ref ProfileItem Profile)
  {
    if (((ProfileSettings) Profile).warningAllList.Count == 0)
    {
      ((ProfileSettings) Profile).warningAllList.Add(strWarning);
    }
    else
    {
      for (int index = 0; index <= ((ProfileSettings) Profile).warningAllList.Count - 1; ++index)
      {
        if (((ProfileSettings) Profile).warningAllList[index] == strWarning)
          return;
      }
      ((ProfileSettings) Profile).warningAllList.Add(strWarning);
    }
  }

  public void AddErrorToProfile(string strError, ref ProfileItem Profile)
  {
    if (((ProfileSettings) Profile).errorAllList.Count == 0)
    {
      ((ProfileSettings) Profile).errorAllList.Add(strError);
    }
    else
    {
      for (int index = 0; index <= ((ProfileSettings) Profile).errorAllList.Count - 1; ++index)
      {
        if (((ProfileSettings) Profile).errorAllList[index] == strError)
        {
          if (((ProfileSettings) Profile).errorAllList.Count <= 0)
            return;
          ((ProfileSettings) Profile).isError = true;
          return;
        }
      }
      ((ProfileSettings) Profile).errorAllList.Add(strError);
    }
    if (((ProfileSettings) Profile).errorAllList.Count <= 0)
      return;
    ((ProfileSettings) Profile).isError = true;
  }

  public void AddInfoToProfile(string strInfo, ref ProfileItem Profile)
  {
    if (((ProfileSettings) Profile).infoAllList.Count == 0)
    {
      ((ProfileSettings) Profile).infoAllList.Add(strInfo);
    }
    else
    {
      for (int index = 0; index <= ((ProfileSettings) Profile).infoAllList.Count - 1; ++index)
      {
        if (((ProfileSettings) Profile).infoAllList[index] == strInfo)
          return;
      }
      ((ProfileSettings) Profile).infoAllList.Add(strInfo);
    }
  }
}
