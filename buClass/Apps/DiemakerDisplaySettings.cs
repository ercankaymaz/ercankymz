// Decompiled with JetBrains decompiler
// Type: buClass.Apps.DiemakerDisplaySettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class DiemakerDisplaySettings : buSerilization
{
  public Color colorActive = Color.LightGreen;
  public Color colorPassive = Color.Red;
  public Color colorCutting = Color.Gray;
  public Color colorCreasing = Color.Gray;
  public Color colorPerfo = Color.Gray;
  public Color colorCutCrease = Color.Gray;
  public Color colorBridge = Color.Gold;
  public Color colorSameEntity = Color.BlueViolet;
  public Color colorMirrorEntity = Color.DarkOliveGreen;
  public Color colorText = Color.Black;
  public Color colorJobPageSmallPreviewTopColor = Color.DarkGray;
  public Color colorJobPageSmallPreviewBottomColor = Color.DarkGray;
  public Color colorJobPageBigPreviewTopColor = Color.DarkGray;
  public Color colorJobPageBigPreviewBottomColor = Color.DarkGray;
  public Color colorBreakMark = Color.Green;
  public Color colorPreviewActive = Color.LightGreen;
  public Color colorPreviewPassive = Color.Red;
  public Color colorInfo = Color.LightCyan;
  public Color colorForeJobDone = Color.Red;
  public Color colorForeJobNotDone = Color.LightGreen;
  public Color colorForeJobNext = Color.Blue;
  public Color colorGridNextJob = Color.AliceBlue;
  public Color colorGridActiveJob = Color.AliceBlue;
  public Color colorCuttingListAllEntitiy = Color.DarkGray;
  public static List<string> Captions = new List<string>();

  public DiemakerDisplaySettings()
  {
  }

  public DiemakerDisplaySettings(DiemakerDisplaySettings data)
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

  public static void Copy(DiemakerDisplaySettings Source, ref DiemakerDisplaySettings Target)
  {
    Target = new DiemakerDisplaySettings(Source);
  }

  public override string ToString() => "colorActive : " + this.colorActive.ToString();
}
