// Decompiled with JetBrains decompiler
// Type: buClass.AppProcess
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Windows.Forms;

#nullable disable
namespace buClass;

[Serializable]
public class AppProcess : buSerilization
{
  public static int SelectedAxis = -1;
  public static double SelectedMolt = 0.1;
  public static int Status = 0;
  public static int ActiveLine = -1;
  public static int ActiveTool = -1;
  public static int ActiveMCode = -1;
  public static int WarningID = 0;
  public static int AlarmCount = 0;
  public static int WarningCount = 0;
  public static int GCodeStartLine = -1;
  public static int GCodeTotalLineCount = 0;
  public static int TickSave = 0;
  public static int TickGeneral = 0;
  public static double FeedVelocity = 0.0;
  public static double FeedOverride = 0.0;
  public static double SpindleSpeed = 0.0;
  public static double SpindleOverride = 0.0;
  public static bool Automatic = false;
  public static bool Manuel = false;
  public static bool Paused = false;
  public static bool Alarmmm = false;
  public static bool Warning = false;
  public static AppWarning activeWarning = new AppWarning();
  public static AppAlarm activeAlarm = new AppAlarm();
  public static DateTime StartedTime = new DateTime();
  public static string LastLoadedFileName = Application.StartupPath;
  public static string LastLoadedFolder = Application.StartupPath;
}
