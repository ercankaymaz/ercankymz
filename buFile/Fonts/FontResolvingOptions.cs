// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.FontResolvingOptions
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;

#nullable disable
namespace PdfSharp.Fonts;

internal class FontResolvingOptions
{
  public XFontStyle FontStyle;
  public bool OverrideStyleSimulations;
  public XStyleSimulations StyleSimulations;

  public FontResolvingOptions(XFontStyle fontStyle) => this.FontStyle = fontStyle;

  public FontResolvingOptions(XFontStyle fontStyle, XStyleSimulations styleSimulations)
  {
    this.FontStyle = fontStyle;
    this.OverrideStyleSimulations = true;
    this.StyleSimulations = styleSimulations;
  }

  public bool IsBold => (this.FontStyle & XFontStyle.Bold) == XFontStyle.Bold;

  public bool IsItalic => (this.FontStyle & XFontStyle.Italic) == XFontStyle.Italic;

  public bool IsBoldItalic => (this.FontStyle & XFontStyle.BoldItalic) == XFontStyle.BoldItalic;

  public bool MustSimulateBold
  {
    get
    {
      return (this.StyleSimulations & XStyleSimulations.BoldSimulation) == XStyleSimulations.BoldSimulation;
    }
  }

  public bool MustSimulateItalic
  {
    get
    {
      return (this.StyleSimulations & XStyleSimulations.ItalicSimulation) == XStyleSimulations.ItalicSimulation;
    }
  }
}
