// Decompiled with JetBrains decompiler
// Type: buClass.ShortCutKey
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class ShortCutKey : buSerilization
{
  public ControlKeys FirstControlKey = ControlKeys.None;
  public ControlKeys SecondControlKey = ControlKeys.None;
  public ActionKeys Key = ActionKeys.KeyNone;
  public string Command = "None";

  public ShortCutKey()
  {
  }

  public ShortCutKey(
    ControlKeys FirstControl,
    ControlKeys SecondControl,
    ActionKeys key,
    string command)
  {
    this.Command = command;
    this.FirstControlKey = FirstControl;
    this.SecondControlKey = SecondControl;
    this.Key = key;
  }

  public override string ToString()
  {
    return $"{this.FirstControlKey.ToString()} + {this.SecondControlKey.ToString()} + {this.Key.ToString()} = {this.Command.ToString()}";
  }
}
