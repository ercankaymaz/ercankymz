// Decompiled with JetBrains decompiler
// Type: buMotion.buMotionColors
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;

#nullable disable
namespace buMotion;

[Serializable]
public class buMotionColors : buSerilization
{
  public static int cntGeneralTick;
  public static bool WarningAvailable;
  public static string LogFileName;
  public static string ExceptionFileName;
  public static string SeasonFileName;

  public buMotionColors()
  {
    ((TechnicianLoginInfo) this).Message = (string) null;
    ((TechnicianLoginInfo) this).Command = "";
    ((TechnicianLoginInfo) this).Method = "";
    ((TechnicianLoginInfo) this).Data = (string) null;
    ((TechnicianLoginInfo) this).BaseClass = (string) null;
    ((TechnicianLoginInfo) this).ID = 0.0;
    ((TechnicianType) this).Value = 0.0;
    ((TechnicianType) this).Time = new DateTime();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public buMotionColors(buMotionLogVer5 log)
  {
    ((TechnicianLoginInfo) this).Message = (string) null;
    ((TechnicianLoginInfo) this).Command = "";
    ((TechnicianLoginInfo) this).Method = "";
    ((TechnicianLoginInfo) this).Data = (string) null;
    ((TechnicianLoginInfo) this).BaseClass = (string) null;
    ((TechnicianLoginInfo) this).ID = 0.0;
    ((TechnicianType) this).Value = 0.0;
    ((TechnicianType) this).Time = new DateTime();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((TechnicianLoginInfo) this).Message = ((TechnicianLoginInfo) log).Message;
    ((TechnicianLoginInfo) this).Data = ((TechnicianLoginInfo) log).Data;
    ((TechnicianLoginInfo) this).ID = ((TechnicianLoginInfo) log).ID;
    ((TechnicianType) this).Time = ((TechnicianType) log).Time;
    ((TechnicianLoginInfo) this).Command = ((TechnicianLoginInfo) log).Command;
    ((TechnicianLoginInfo) this).Method = ((TechnicianLoginInfo) log).Method;
    ((TechnicianType) this).Value = ((TechnicianType) log).Value;
  }
}
