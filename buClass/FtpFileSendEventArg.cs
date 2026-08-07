// Decompiled with JetBrains decompiler
// Type: buClass.FtpFileSendEventArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class FtpFileSendEventArg
{
  public int TotalLineCount = 0;
  public int ActualLineIndex = 0;
  public double SendPersentage = 0.0;

  public override string ToString() => "TotalLineCount: " + this.TotalLineCount.ToString();
}
