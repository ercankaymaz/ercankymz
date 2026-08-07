// Decompiled with JetBrains decompiler
// Type: buClass.Apps.RouterProgramSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class RouterProgramSettings : buSerilization
{
  public bool isBuSorting = true;
  public bool isBuCalculation = true;
  public bool UseStartPoint = true;
  public double StartPointX = 0.0;
  public double StartPointY = 0.0;
  public ClockDirectionType InsideCutClosedPatternCutDirection = ClockDirectionType.CCW;
  public TopBottomType WoodBottomRefSide = TopBottomType.Bottom;
  public double WoodBottomTrimPersentage = 50.0;
  public double SafeDistance = 50.0;
  public double LeaveSpeed = 80.0;
  public bool RapidRetract = false;
  public bool ShowBuDialog = false;
  public static List<string> Captions = new List<string>();

  public RouterProgramSettings()
  {
  }

  public RouterProgramSettings(RouterProgramSettings data)
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

  public static void Copy(RouterProgramSettings Source, ref RouterProgramSettings Target)
  {
    Target = new RouterProgramSettings(Source);
  }

  public override string ToString() => "";
}
