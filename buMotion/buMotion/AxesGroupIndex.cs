// Decompiled with JetBrains decompiler
// Type: buMotion.AxesGroupIndex
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buMotion;

[Serializable]
public class AxesGroupIndex : buSerilization
{
  public AlarmWarningActionType CabinetMaintenance;
  public AlarmWarningActionType AirMaintenance;
  public AlarmWarningActionType MachineCleaningMaintenance;
  public static List<string> Captions = new List<string>();
  public static byte f0000EF;
  public int AxX;
  public int AxY;
  public int AxZ;
  public int AxA;
  public int AxB;
  public int AxC;
  public int AxX1;
  public int AxX2;

  public override string ToString()
  {
    // ISSUE: unable to decompile the method.
  }
}
