// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.ParseFormatAttribute
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Globalization;

#nullable disable
namespace DevAge.Text.FixedLength;

[AttributeUsage(AttributeTargets.Property)]
public class ParseFormatAttribute : Attribute
{
  private string string_0;
  private string string_1;
  private bool bool_0;
  private CultureInfo cultureInfo_0;

  public ParseFormatAttribute()
  {
    CultureInfo invariantCulture = CultureInfo.InvariantCulture;
    this.DateTimeFormat = invariantCulture.DateTimeFormat.ShortDatePattern;
    this.NumberFormat = "+00000000.0000;-00000000.0000";
    this.TrimBeforeParse = true;
    this.CultureInfo = invariantCulture;
  }

  public CultureInfo CultureInfo
  {
    get => this.cultureInfo_0;
    set => this.cultureInfo_0 = value;
  }

  public string DateTimeFormat
  {
    get => this.string_0;
    set => this.string_0 = value;
  }

  public string NumberFormat
  {
    get => this.string_1;
    set => this.string_1 = value;
  }

  public bool TrimBeforeParse
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }
}
