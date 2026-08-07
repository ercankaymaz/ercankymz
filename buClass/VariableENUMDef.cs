// Decompiled with JetBrains decompiler
// Type: buClass.VariableENUMDef
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

public class VariableENUMDef
{
  public string Name = "";
  public Enum Value = (Enum) null;

  public VariableENUMDef()
  {
  }

  public VariableENUMDef(string name) => this.Name = name;

  public VariableENUMDef(string name, Enum val)
  {
    this.Name = name;
    this.Value = val;
  }

  public override string ToString() => $"{this.Name} = {this.Value.ToString()}";
}
