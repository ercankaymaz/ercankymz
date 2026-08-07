// Decompiled with JetBrains decompiler
// Type: buMotion.buMotionWarningLang
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buMotion;

[Serializable]
public class buMotionWarningLang : buSerilization
{
  public string SystemisRunning;
  public string SysteminAlarm;
  public string ToolMeasure;
  public string ToolChange;
  public string GoingPark;
  public string GoingHoming;
  public string SystemPaused;
  public string Calculating;
  public static byte f00011D;
  public string NoWarning;
  public string SystemOffline;
  public string HomingMissing;
  public string SysteminAlarm;
  public string SystemisRunning;
  public string DrivesareDisable;
  public string SystemisMoving;
  public string SsytemisPaused;
  public string NoAxisSelected;
  public string CanNotdoThisCommand;
  public string FileNotLoaded;
  public string AccelerationZero;
  public string DecelerationZero;
  public string JerkZero;
  public string WaitTimeLowerThen0;
  public string VelocityZero;
  public string AxisinSimulationMode;
  public string IOinSimulationMode;
  public string AutoMode;
  public string GantryError;
  public string LevelisnotEnoughtThisOperation;
  public string DoorisOpen;
  public string MacError;

  public static void LoadAxisWarning(List<string> SL)
  {
    string str = nameof (LoadAxisWarning);
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
