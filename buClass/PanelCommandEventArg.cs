// Decompiled with JetBrains decompiler
// Type: buClass.PanelCommandEventArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class PanelCommandEventArg
{
  public PanelCommandType Command = PanelCommandType.None;
  public double Value = 0.0;

  public override string ToString()
  {
    return $"Cmd : {this.Command.ToString()} , Value: {this.Value.ToString()}";
  }
}
