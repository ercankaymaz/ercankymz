// Decompiled with JetBrains decompiler
// Type: buClass.Apps.DiemakerBridgeSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class DiemakerBridgeSettings : buSerilization
{
  public double UsageOfBridgeToolWidth = 75.0;

  public DiemakerBridgeSettings()
  {
  }

  public DiemakerBridgeSettings(DiemakerBridgeSettings data)
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

  public static void Copy(DiemakerBridgeSettings Source, ref DiemakerBridgeSettings Target)
  {
    Target = new DiemakerBridgeSettings(Source);
  }

  public override string ToString() => "Tool Width % : " + this.UsageOfBridgeToolWidth.ToString();
}
