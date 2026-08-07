// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.Converter.CurrencyTypeConverter
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Globalization;

#nullable disable
namespace DevAge.ComponentModel.Converter;

public class CurrencyTypeConverter : NumberTypeConverter
{
  public CurrencyTypeConverter(Type p_BaseType)
    : base(p_BaseType)
  {
    this.Format = "C";
    this.NumberStyles = NumberStyles.Currency;
  }

  public CurrencyTypeConverter(Type p_BaseType, string p_Format)
    : this(p_BaseType)
  {
    this.Format = p_Format;
  }
}
