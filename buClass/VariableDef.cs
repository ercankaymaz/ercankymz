// Decompiled with JetBrains decompiler
// Type: buClass.VariableDef
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

#nullable disable
namespace buClass;

public class VariableDef
{
  public string Name = "";
  public object Value = (object) null;

  public VariableDef()
  {
  }

  public VariableDef(string name) => this.Name = name;

  public VariableDef(string name, object val)
  {
    this.Name = name;
    this.Value = val;
  }

  public override string ToString() => $"{this.Name} = {this.Value.ToString()}";
}
