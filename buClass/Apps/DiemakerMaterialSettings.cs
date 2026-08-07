// Decompiled with JetBrains decompiler
// Type: buClass.Apps.DiemakerMaterialSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class DiemakerMaterialSettings : buSerilization
{
  public double PT1Thickness = 0.35;
  public double PT2Thickness = 0.71;
  public double PT3Thickness = 1.05;
  public double PT4Thickness = 1.42;
  public double BridgeHeight = 15.0;
  public double BladeHeigth = 23.5;
  public double LipWidthRatio = 0.04;
  public double LipHeightRatio = 0.05;
  public double LipClickArea = 0.1;
  public double RuleHeight = 23.8;
  public static List<string> Captions = new List<string>();

  public DiemakerMaterialSettings()
  {
  }

  public DiemakerMaterialSettings(DiemakerMaterialSettings data)
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

  public static void Copy(DiemakerMaterialSettings Source, ref DiemakerMaterialSettings Target)
  {
    Target = new DiemakerMaterialSettings(Source);
  }

  public override string ToString() => "PT2Thickness : " + this.PT2Thickness.ToString();
}
