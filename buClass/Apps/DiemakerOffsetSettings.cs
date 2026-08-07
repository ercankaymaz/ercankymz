// Decompiled with JetBrains decompiler
// Type: buClass.Apps.DiemakerOffsetSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class DiemakerOffsetSettings : buSerilization
{
  public double LeftCustomOffset1 = 1.35;
  public double LeftCustomOffset2 = 2.0;
  public double LeftCustomOffset3 = 3.0;
  public double RightCustomOffset1 = 1.35;
  public double RightCustomOffset2 = 2.0;
  public double RightCustomOffset3 = 3.0;
  public double Creasing1PtExtraOffset = -0.1;
  public double Creasing2PtExtraOffset = -0.1;
  public double Creasing3PtExtraOffset = -0.1;
  public double Creasing4PtExtraOffset = -0.1;
  public double CuttingStraight1PtOffset = 0.25;
  public double CuttingStraight2PtOffset = 0.4;
  public double CuttingStraight3PtOffset = 0.6;
  public double CuttingStraight4PtOffset = 0.7;
  public double CuttingLip1PtOffset = -0.25;
  public double CuttingLip2PtOffset = -0.3;
  public double CuttingLip3PtOffset = -0.5;
  public double CuttingLip4PtOffset = -0.7;
  public static List<string> Captions = new List<string>();

  public DiemakerOffsetSettings()
  {
  }

  public DiemakerOffsetSettings(DiemakerOffsetSettings data)
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

  public static void Copy(DiemakerOffsetSettings Source, ref DiemakerOffsetSettings Target)
  {
    Target = new DiemakerOffsetSettings(Source);
  }

  public override string ToString()
  {
    return $"LeftCustomOffset1 : {this.LeftCustomOffset1.ToString()} - RightCustomOffset1 : {this.RightCustomOffset1.ToString()}";
  }
}
