// Decompiled with JetBrains decompiler
// Type: buClass.MacroBase
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class MacroBase : buSerilization
{
  public ArrayList Args = new ArrayList();
  public string Command = "";
  public static List<string> Captions = new List<string>();

  public MacroBase()
  {
  }

  public MacroBase(MacroBase macro)
  {
    this.Command = macro.Command;
    this.Args.Clear();
    for (int index = 0; index <= macro.Args.Count - 1; ++index)
      this.Args.Add(macro.Args[index]);
  }

  public override string ToString()
  {
    string str = "";
    if (this.Args.Count > 0)
    {
      str = this.Args[0].ToString();
      for (int index = 1; index <= this.Args.Count - 1; ++index)
        str = $"{str} - {this.Args[index].ToString()}";
    }
    return $"{this.Command} , {str}";
  }
}
