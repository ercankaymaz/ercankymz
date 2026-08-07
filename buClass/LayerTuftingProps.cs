// Decompiled with JetBrains decompiler
// Type: buClass.LayerTuftingProps
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using buClass.Apps;
using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class LayerTuftingProps : buSerilization
{
  public string PileExplanation = "";
  public double PileHeight = 10.0;
  public double StitchLength = 4.0;
  public double YarnWidth = 4.0;
  public double TuftingThickness = 4.0;
  public int YarnID = -1;
  public string ColorCode = "";
  public bool isDirectionArrow = false;
  public Color RealColor = Color.Black;
  public tuftingStitchModeType StitchMode = tuftingStitchModeType.Cut;
  public tuftingMixerModeType MixerMode = tuftingMixerModeType.None;
  public TuftingYarn YarnType = new TuftingYarn();

  public LayerTuftingProps()
  {
  }

  public LayerTuftingProps(LayerTuftingProps data)
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

  public override string ToString()
  {
    return $"Pile Height : {this.PileHeight.ToString()} -  Stitch Length : {this.StitchLength.ToString()}";
  }
}
