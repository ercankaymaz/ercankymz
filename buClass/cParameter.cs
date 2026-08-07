// Decompiled with JetBrains decompiler
// Type: buClass.cParameter
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

public class cParameter
{
  public object ValueBaseClass = (object) null;
  public object Value = (object) null;
  public string ValueAsString = (string) null;
  public object SubParameter = (object) null;
  public string Name = "Par";
  public Type Types = (Type) null;
  public FieldInfo Field = (FieldInfo) null;
  public PropertyInfo Property = (PropertyInfo) null;

  public cParameter()
  {
  }

  public cParameter(string name, object val)
  {
    this.Value = val;
    this.Name = name;
  }

  public override string ToString() => $"{this.Name} = {this.Value.ToString()} | {this.Types.Name}";
}
