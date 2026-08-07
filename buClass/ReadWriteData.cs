// Decompiled with JetBrains decompiler
// Type: buClass.ReadWriteData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ReadWriteData : buSerilization
{
  public bool bWriteSettingsParameter = false;
  public bool bWriteCNCSettingsParameter = false;
  public bool bWriteG54Parameter = false;
  public bool bWriteToolParameter = false;
  public bool bWriteAppParameter = false;
  public bool bWriteCounterParameters = false;
  public bool bWriteCncAutoListParameter = false;
  public bool bVariablesImported = false;
  public bool bParameterWriting = false;
  public bool bReadInputs = false;
  public bool bReadOutputs = false;
  public bool bReadSystemVars = false;
  public bool bReadAppVars = false;
  public bool bReadUserVars = false;

  public ReadWriteData()
  {
  }

  public ReadWriteData(ReadWriteData data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }

  public override string ToString() => "bReadSystemVars: " + this.bReadSystemVars.ToString();
}
