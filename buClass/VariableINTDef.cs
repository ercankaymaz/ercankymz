// Decompiled with JetBrains decompiler
// Type: buClass.VariableINTDef
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class VariableINTDef
{
  public string Name = "";
  public short Value = 0;

  public VariableINTDef()
  {
  }

  public VariableINTDef(string name) => this.Name = name;

  public VariableINTDef(string name, short val)
  {
    this.Name = name;
    this.Value = val;
  }

  public override string ToString() => $"{this.Name} = {this.Value.ToString()}";
}
