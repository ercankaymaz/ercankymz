// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.MaximumProfileTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class MaximumProfileTable : OpenTypeFontTable
{
  public const string Tag = "maxp";
  public int version;
  public ushort numGlyphs;
  public ushort maxPoints;
  public ushort maxContours;
  public ushort maxCompositePoints;
  public ushort maxCompositeContours;
  public ushort maxZones;
  public ushort maxTwilightPoints;
  public ushort maxStorage;
  public ushort maxFunctionDefs;
  public ushort maxInstructionDefs;
  public ushort maxStackElements;
  public ushort maxSizeOfInstructions;
  public ushort maxComponentElements;
  public ushort maxComponentDepth;

  public MaximumProfileTable(OpenTypeFontface fontData)
    : base(fontData, "maxp")
  {
    this.Read();
  }

  public void Read()
  {
    try
    {
      this.version = this._fontData.ReadFixed();
      this.numGlyphs = this._fontData.ReadUShort();
      this.maxPoints = this._fontData.ReadUShort();
      this.maxContours = this._fontData.ReadUShort();
      this.maxCompositePoints = this._fontData.ReadUShort();
      this.maxCompositeContours = this._fontData.ReadUShort();
      this.maxZones = this._fontData.ReadUShort();
      this.maxTwilightPoints = this._fontData.ReadUShort();
      this.maxStorage = this._fontData.ReadUShort();
      this.maxFunctionDefs = this._fontData.ReadUShort();
      this.maxInstructionDefs = this._fontData.ReadUShort();
      this.maxStackElements = this._fontData.ReadUShort();
      this.maxSizeOfInstructions = this._fontData.ReadUShort();
      this.maxComponentElements = this._fontData.ReadUShort();
      this.maxComponentDepth = this._fontData.ReadUShort();
    }
    catch (Exception ex)
    {
      throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
    }
  }
}
