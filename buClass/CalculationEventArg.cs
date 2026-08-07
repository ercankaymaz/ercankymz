// Decompiled with JetBrains decompiler
// Type: buClass.CalculationEventArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class CalculationEventArg
{
  public int Sequence = 0;
  public double ActiveProgressPercentage = 0.0;
  public double OverallProgressPercentage = 0.0;
  public string Job = "";
  public string SubJob = "";
  public bool Canceled = false;
  public bool Done = false;
  public bool ShowForm = true;
  public bool ShowOnMainForm = false;

  public CalculationEventArg()
  {
  }

  public CalculationEventArg(
    double activePersentage,
    double overallPercentage,
    int seq,
    string job,
    string subjob)
  {
    this.ActiveProgressPercentage = activePersentage;
    this.OverallProgressPercentage = overallPercentage;
    this.Sequence = seq;
    this.Job = job;
    this.SubJob = subjob;
    this.Done = false;
  }

  public CalculationEventArg(
    double activePersentage,
    double overallPercentage,
    int seq,
    string job,
    string subjob,
    bool done)
  {
    this.ActiveProgressPercentage = activePersentage;
    this.OverallProgressPercentage = overallPercentage;
    this.Sequence = seq;
    this.Job = job;
    this.SubJob = subjob;
    this.Done = done;
  }
}
