// Decompiled with JetBrains decompiler
// Type: buClass.CncRuntime
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class CncRuntime : buSerilization
{
  public bool SingleStep = false;
  public bool UpdateToolData = false;
  public double FeedVelocity = 0.0;
  public double SpindleSpeed = 0.0;
  public int ActiveLine = 0;
  public int ActiveMCode = 0;
  public int ActiveTool = 0;

  public override string ToString()
  {
    return $"FeedVelocity: {this.FeedVelocity.ToString()} ; SpindleSpeed: {this.SpindleSpeed.ToString()} ; ActiveLine: {this.ActiveLine.ToString()} ; ActiveTool: {this.ActiveTool.ToString()} ; ActiveMCode: {this.ActiveMCode.ToString()}";
  }
}
