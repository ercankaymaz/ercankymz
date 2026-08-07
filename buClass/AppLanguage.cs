// Decompiled with JetBrains decompiler
// Type: buClass.AppLanguage
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class AppLanguage : buSerilization
{
  public static int SelectedLanguage = 0;
  public static List<string> AxesMessages = new List<string>();
  public static List<string> SystemMessages = new List<string>();
  public static List<string> AppMessages = new List<string>();
  public static List<string> CadCamMessages = new List<string>();
  public static List<string> Messages = new List<string>();
  public static List<string> MachineMessages = new List<string>();
  public static List<string> AxesWarning = new List<string>();
  public static List<string> SystemWarning = new List<string>();
  public static List<string> AppWarning = new List<string>();
  public static List<string> CadCamWarning = new List<string>();
  public static List<string> Warning = new List<string>();
  public static List<string> MachineWarning = new List<string>();
  public static List<string> AxesError = new List<string>();
  public static List<string> SystemError = new List<string>();
  public static List<string> AppError = new List<string>();
  public static List<string> CadCamError = new List<string>();
  public static List<string> Error = new List<string>();
  public static List<string> MachineError = new List<string>();
  public static List<string> AxesStatus = new List<string>();
  public static List<string> SystemStatus = new List<string>();
  public static List<string> AppStatus = new List<string>();
  public static List<string> CadCamStatus = new List<string>();
  public static List<string> Status = new List<string>();
  public static List<string> MachineStatus = new List<string>();
  public static List<string> AxesDynamic = new List<string>();
  public static List<string> SystemDynamic = new List<string>();
  public static List<string> AppDynamic = new List<string>();
  public static List<string> CadCamDynamic = new List<string>();
  public static List<string> Dynamic = new List<string>();
  public static List<string> MachineDynamic = new List<string>();
  public static List<string> AxesCommand = new List<string>();
  public static List<string> SystemCommand = new List<string>();
  public static List<string> AppCommand = new List<string>();
  public static List<string> CadCamCommand = new List<string>();
  public static List<string> Command = new List<string>();
  public static List<string> MachineCommand = new List<string>();
  public static List<string> Info = new List<string>();
  public static List<string> SystemInfo = new List<string>();
  public static List<string> AppInfo = new List<string>();
  public static List<string> CadCamInfo = new List<string>();
  public static List<string> MachineInfo = new List<string>();
  public static List<string> buClassStrings = new List<string>();
  public static List<string> CadCamStrings = new List<string>();
  public static List<string> CadCamSentences = new List<string>();
  public static List<string> EnumBase = new List<string>();

  public static void Clear()
  {
    AppLanguage.Messages.Clear();
    AppLanguage.Warning.Clear();
    AppLanguage.Error.Clear();
    AppLanguage.Status.Clear();
    AppLanguage.Dynamic.Clear();
    AppLanguage.Info.Clear();
    AppLanguage.SystemMessages.Clear();
    AppLanguage.SystemWarning.Clear();
    AppLanguage.SystemError.Clear();
    AppLanguage.SystemStatus.Clear();
    AppLanguage.SystemDynamic.Clear();
    AppLanguage.SystemInfo.Clear();
    AppLanguage.EnumBase.Clear();
  }
}
