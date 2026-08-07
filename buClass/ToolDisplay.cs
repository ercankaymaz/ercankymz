// Decompiled with JetBrains decompiler
// Type: buClass.ToolDisplay
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolDisplay : buSerilization
{
  public SolidItemDisplay Solid = new SolidItemDisplay(Color.Red, 220, Color.DarkRed, 240 /*0xF0*/);
  public SolidItemDisplay ToolCutSolid = new SolidItemDisplay(Color.DarkOrange, 220, Color.DarkRed, 240 /*0xF0*/);
  public SolidItemDisplay ToolBodySolid = new SolidItemDisplay(Color.DarkOliveGreen, 220, Color.DarkRed, 240 /*0xF0*/);
  public SolidItemDisplay HolderSolid = new SolidItemDisplay(Color.DarkGray, 220, Color.DarkRed, 240 /*0xF0*/);
  public SolidItemDisplay ArborSolid = new SolidItemDisplay(Color.DarkSlateBlue, 220, Color.DarkRed, 240 /*0xF0*/);
  public Color CamColor = Color.Red;
  public double CamThickness = 2.0;
  public Color PlungeColor = Color.Green;
  public double PlungeThickness = 2.0;
  public Color LeaveColor = Color.Gold;
  public double LeaveThickness = 2.0;
  public Color UpperCamColor = Color.Blue;
  public double UpperCamThickness = 2.0;

  public ToolDisplay()
  {
  }

  public ToolDisplay(ToolDisplay display)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) display, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
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
    this.ToolBodySolid = new SolidItemDisplay(display.ToolBodySolid);
  }

  public override string ToString()
  {
    return $"Tool Color: {this.Solid.SkinColor.ToString()} - Cam Color: {this.CamColor.ToString()} - Up Cam Color: {this.UpperCamColor.ToString()}";
  }
}
