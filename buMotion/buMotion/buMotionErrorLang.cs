// Decompiled with JetBrains decompiler
// Type: buMotion.buMotionErrorLang
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buMotion;

[Serializable]
public class buMotionErrorLang : buSerilization
{
  public string SystemisNotRunning;
  public string CNCStepZero;
  public string PartZeronotSet;
  public string DoorisClosed;
  public string HandWheelisActive;
  public string SystemisnotReady;
  public string NotConnected;
  public string ParameterWritingtoSystemPleaseTryAfewSecoondLater;
  public string ParameterHasNotDownloadedPleaseUpdateParameter;
  public static byte f00013E;
  public string NoAlarm;
  public string EmergencyStop;
  public string HomingTimeout;
  public string MACMismatch;
  public string InitFailure;
  public string GantryError;
  public string LowAirPressure;
  public string SpindleFault;
  public string ToolChangeTimeout;
  public string ToolMeasureTimeout;
  public string ToolMeasureFailure;
  public string ParkTimeout;
  public string CompileError;
  public string ShortToolError;
  public string LongToolError;
  public string ToolClamperNotEmpty;
  public string ToolNotAvailable;
  public string ToolNoActive;
  public string ReadNCFBError;
  public string DecodeNCFBError;
  public string SmootMergeFBError;
  public string SmoothPathFBError;
  public string ExtendeVelocityFBError;
  public string LimitDynamicsFBError;
  public string CheckVelocityFBError;
  public string ToolCoverNotOpen;
  public string ToolCoverNotClosed;
  public string ToolMagazineNotForwardPosition;
  public string ToolMagazineNotBackwardPosition;
  public string WaterLowLevel;
  public string DoorOpen;
  public string ToolStillinSpindle;
  public string ToolChangeNextToolWrong;
  public string CNCIpoFBError;
  public string CNCReadNCFBError;
  public string CNCDecodeNCFBError;
  public string BBBActivated;
  public string ToolGetError;

  public static void LoadMessage(List<string> SL)
  {
    string str = nameof (LoadMessage);
    try
    {
      if (SL.Count > 0)
        ;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(buMotionStatusLang.sClassName, str, "Error");
      buException.throwException(ex, str, true, "");
    }
  }
}
