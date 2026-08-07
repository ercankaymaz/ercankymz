// Decompiled with JetBrains decompiler
// Type: buClass.Apps.LaserProgramSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class LaserProgramSettings : buSerilization
{
  public double G0FeedMmperSec = 50.0;
  public double Pt1ThicknessValue = 0.355;
  public double Pt2ThicknessValue = 0.71;
  public double Pt3ThicknessValue = 1.05;
  public double Pt4ThicknessValue = 1.42;
  public double Pt6ThicknessValue = 2.1;
  public bool Pt3DoubleCutEnable = true;
  public bool Pt4DoubleCutEnable = true;
  public bool Pt6DoubleCutEnable = true;
  public bool isBuSorting = true;
  public bool isBuCalculation = true;
  public bool UseStartPoint = true;
  public double StartPointX = 0.0;
  public double StartPointY = 0.0;
  public double LaserStartTime = 200.0;
  public double LaserStopTime = 200.0;
  public static List<string> Captions = new List<string>();

  public LaserProgramSettings()
  {
  }

  public LaserProgramSettings(LaserProgramSettings data)
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

  public static void Copy(LaserProgramSettings Source, ref LaserProgramSettings Target)
  {
    Target = new LaserProgramSettings(Source);
  }

  public override string ToString() => "";
}
