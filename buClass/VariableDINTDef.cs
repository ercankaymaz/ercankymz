// Decompiled with JetBrains decompiler
// Type: buClass.VariableDINTDef
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class VariableDINTDef
{
  public string Name = "";
  public int Value = 0;

  public VariableDINTDef()
  {
  }

  public VariableDINTDef(string name) => this.Name = name;

  public VariableDINTDef(string name, int val)
  {
    this.Name = name;
    this.Value = val;
  }

  public override string ToString() => $"{this.Name} = {this.Value.ToString()}";
}
