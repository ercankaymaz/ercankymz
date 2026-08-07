// Decompiled with JetBrains decompiler
// Type: buClass.drawPropertiesType
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class drawPropertiesType : buSerilization
{
  public Color Color = Color.DarkGray;
  public float Thickness = 1f;
  public int Transperancy = (int) byte.MaxValue;
  public drawingPattern Pattern = new drawingPattern();
  public static List<string> Captions = new List<string>();

  public drawPropertiesType()
  {
  }

  public drawPropertiesType(drawPropertiesType drawprop)
  {
    this.Color = drawprop.Color;
    this.Thickness = drawprop.Thickness;
    this.Pattern = new drawingPattern(drawprop.Pattern);
    this.Transperancy = drawprop.Transperancy;
  }

  public drawPropertiesType(Color color, float thickness)
  {
    this.Color = color;
    this.Thickness = thickness;
    this.Pattern = new drawingPattern();
  }

  public drawPropertiesType(Color color, float thickness, int transperancy)
  {
    this.Color = color;
    this.Thickness = thickness;
    this.Pattern = new drawingPattern();
    this.Transperancy = transperancy;
  }

  public drawPropertiesType(Color color, float thickness, drawingPattern pattern)
  {
    this.Color = color;
    this.Thickness = thickness;
    this.Pattern = new drawingPattern(pattern);
  }

  public drawPropertiesType(
    Color color,
    float thickness,
    drawingPattern pattern,
    int transperancy)
  {
    this.Color = color;
    this.Thickness = thickness;
    this.Pattern = new drawingPattern(pattern);
    this.Transperancy = transperancy;
  }

  public override string ToString()
  {
    return $"{buStatics.ColorToString(this.Color, ColorConvertType.Html)} - T : {this.Thickness.ToString()}";
  }
}
