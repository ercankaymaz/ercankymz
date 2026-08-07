// Decompiled with JetBrains decompiler
// Type: buClass.Ruler
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class Ruler : buSerilization
{
  public bool Enable = false;
  public double Width = 20.0;
  public double Height = 20.0;
  public double BigTickThickness = 2.0;
  public double SmallTickThickness = 2.0;
  public double BigTickLength = 20.0;
  public double SmallTickLength = 5.0;
  public int TotalTickCount = 20;
  public int BigTickCount = 5;
  public Color BigTickColor = Color.Black;
  public Color SmallTickColor = Color.DarkGray;
  public Color RulerColor = Color.White;
  public byte Transparancy = 100;
  public Color TextColor = Color.Black;
  public Color MoveCursorColor = Color.Red;
  public double MoveCursorThickness = 2.0;
  public static List<string> Captions = new List<string>();

  public Ruler()
  {
  }

  public Ruler(Ruler data)
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

  public Ruler(bool enable) => this.Enable = enable;

  public Ruler(
    bool Enable_,
    double Width_,
    double Height_,
    int TotalTickCount_,
    int BigTickCount_,
    Color BigTickColor_,
    Color SmallTickColor_,
    Color RulerColor_,
    byte Transparancy_,
    Color TextColor_,
    double BigTickLength_,
    double SmallTickLength_,
    Color MoveCursorColor_,
    double MoveCursorThickness_,
    double BigTickThickness_,
    double SmallTickThickness_)
  {
    this.Enable = Enable_;
    this.Width = Width_;
    this.Height = Height_;
    this.TotalTickCount = TotalTickCount_;
    this.BigTickColor = BigTickColor_;
    this.BigTickCount = BigTickCount_;
    this.SmallTickColor = SmallTickColor_;
    this.RulerColor = RulerColor_;
    this.Transparancy = Transparancy_;
    this.TextColor = TextColor_;
    this.SmallTickLength = SmallTickLength_;
    this.BigTickLength = BigTickLength_;
    this.MoveCursorColor = MoveCursorColor_;
    this.MoveCursorThickness = MoveCursorThickness_;
    this.BigTickThickness = BigTickThickness_;
    this.SmallTickThickness = SmallTickThickness_;
  }

  public override string ToString() => "Enable : " + this.Enable.ToString();
}
