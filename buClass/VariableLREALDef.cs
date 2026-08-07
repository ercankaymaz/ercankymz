// Decompiled with JetBrains decompiler
// Type: buClass.VariableLREALDef
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class VariableLREALDef
{
  public string Name = "";
  public double Value = 0.0;

  public VariableLREALDef()
  {
  }

  public VariableLREALDef(string name) => this.Name = name;

  public VariableLREALDef(string name, double val)
  {
    this.Name = name;
    this.Value = val;
  }

  public override string ToString() => $"{this.Name} = {this.Value.ToString()}";
}
