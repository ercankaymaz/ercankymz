// Decompiled with JetBrains decompiler
// Type: buClass.JogCommandEventArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class JogCommandEventArg
{
  public JogCommandType Command = JogCommandType.None;
  public double IncrementalPosition = 0.0;
  public double Position = 0.0;
  public double Position1 = 0.0;
  public double Position2 = 0.0;
  public double Velocity = 0.0;
  public double VelocityMove = 0.0;
  public double VelocityJog = 0.0;
  public double Direction = 1.0;
  public int SelectedAxis = 0;
  public double WaitTime = 0.0;

  public override string ToString()
  {
    return $"Cmd : {this.Command.ToString()} , Position: {this.Position1.ToString()} , Velocity: {this.VelocityMove.ToString()}";
  }
}
