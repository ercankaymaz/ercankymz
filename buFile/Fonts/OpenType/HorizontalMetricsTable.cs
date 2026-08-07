// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.HorizontalMetricsTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class HorizontalMetricsTable : OpenTypeFontTable
{
  public const string Tag = "hmtx";
  public HorizontalMetrics[] Metrics;
  public short[] LeftSideBearing;

  public HorizontalMetricsTable(OpenTypeFontface fontData)
    : base(fontData, "hmtx")
  {
    this.Read();
  }

  public void Read()
  {
    try
    {
      HorizontalHeaderTable hhea = this._fontData.hhea;
      MaximumProfileTable maxp = this._fontData.maxp;
      if ((hhea == null ? 0 : (maxp != null ? 1 : 0)) == 0)
        return;
      int numberOfHmetrics = (int) hhea.numberOfHMetrics;
      int length = (int) maxp.numGlyphs - numberOfHmetrics;
      Debug.Assert(numberOfHmetrics != 0);
      Debug.Assert(length >= 0);
      this.Metrics = new HorizontalMetrics[numberOfHmetrics];
      for (int index = 0; index < numberOfHmetrics; ++index)
        this.Metrics[index] = new HorizontalMetrics(this._fontData);
      if (length <= 0)
        return;
      this.LeftSideBearing = new short[length];
      for (int index = 0; index < length; ++index)
        this.LeftSideBearing[index] = this._fontData.ReadFWord();
    }
    catch (Exception ex)
    {
      throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
    }
  }
}
