// Decompiled with JetBrains decompiler
// Type: buClass.Apps.TuftingLoadedFileInfo
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class TuftingLoadedFileInfo : buSerilization
{
  public string LoadedFileName = "";
  public string LoadedColor = "";
  public double FrameSizeX = 0.0;
  public double FrameSizeY = 0.0;
  public double TuftingSizeX = 0.0;
  public double TuftingSizeY = 0.0;
  public int TotalVectorCount = 0;
  public int TotalStitchCount = 0;
  public double TotalYarnLengthAsMeter = 0.0;
  public double TotalYarnWeight = 0.0;
  public double TotalUsedYarnWeight = 0.0;
  public string YarnType = "";
}
