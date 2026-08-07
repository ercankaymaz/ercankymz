// Decompiled with JetBrains decompiler
// Type: buClass.VariableSTRINGDef
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class VariableSTRINGDef
{
  public string Name = "";
  public string Value = "";

  public VariableSTRINGDef()
  {
  }

  public VariableSTRINGDef(string name) => this.Name = name;

  public VariableSTRINGDef(string name, string val)
  {
    this.Name = name;
    this.Value = val;
  }

  public override string ToString() => $"{this.Name} = {this.Value.ToString()}";
}
