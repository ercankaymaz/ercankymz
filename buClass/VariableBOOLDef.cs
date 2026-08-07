// Decompiled with JetBrains decompiler
// Type: buClass.VariableBOOLDef
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class VariableBOOLDef
{
  public string Name = "";
  public bool Value = false;

  public VariableBOOLDef()
  {
  }

  public VariableBOOLDef(string name) => this.Name = name;

  public VariableBOOLDef(string name, bool val)
  {
    this.Name = name;
    this.Value = val;
  }

  public override string ToString() => $"{this.Name} = {this.Value.ToString()}";
}
