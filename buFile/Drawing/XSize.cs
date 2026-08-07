// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XSize
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using System;
using System.Globalization;

#nullable disable
namespace PdfSharp.Drawing;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
[Serializable]
public struct XSize(double width, double height) : IFormattable
{
  private static readonly XSize s_empty = XSize.CreateEmptySize();
  private double _width = (width < 0.0 ? 1 : (height < 0.0 ? 1 : 0)) == 0 ? width : throw new ArgumentException("WidthAndHeightCannotBeNegative");
  private double _height = height;

  public static bool operator ==(XSize size1, XSize size2)
  {
    return size1.Width == size2.Width && size1.Height == size2.Height;
  }

  public static bool operator !=(XSize size1, XSize size2) => !(size1 == size2);

  public static bool Equals(XSize size1, XSize size2)
  {
    return !size1.IsEmpty ? size1.Width.Equals(size2.Width) && size1.Height.Equals(size2.Height) : size2.IsEmpty;
  }

  public override bool Equals(object o) => o is XSize size2 && XSize.Equals(this, size2);

  public bool Equals(XSize value) => XSize.Equals(this, value);

  public override int GetHashCode()
  {
    return !this.IsEmpty ? this.Width.GetHashCode() ^ this.Height.GetHashCode() : 0;
  }

  public static XSize Parse(string source)
  {
    CultureInfo invariantCulture = CultureInfo.InvariantCulture;
    TokenizerHelper tokenizerHelper = new TokenizerHelper(source, (IFormatProvider) invariantCulture);
    string str = tokenizerHelper.NextTokenRequired();
    XSize xsize = !(str == "Empty") ? new XSize(Convert.ToDouble(str, (IFormatProvider) invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), (IFormatProvider) invariantCulture)) : XSize.Empty;
    tokenizerHelper.LastTokenRequired();
    return xsize;
  }

  public XPoint ToXPoint() => new XPoint(this._width, this._height);

  public XVector ToXVector() => new XVector(this._width, this._height);

  public override string ToString() => this.ConvertToString((string) null, (IFormatProvider) null);

  public string ToString(IFormatProvider provider) => this.ConvertToString((string) null, provider);

  string IFormattable.ToString(string format, IFormatProvider provider)
  {
    return this.ConvertToString(format, provider);
  }

  internal string ConvertToString(string format, IFormatProvider provider)
  {
    string str;
    if (this.IsEmpty)
    {
      str = "Empty";
    }
    else
    {
      char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
      provider = provider ?? (IFormatProvider) CultureInfo.InvariantCulture;
      str = string.Format(provider, $"{{1:{format}}}{{0}}{{2:{format}}}", new object[3]
      {
        (object) numericListSeparator,
        (object) this._width,
        (object) this._height
      });
    }
    return str;
  }

  public static XSize Empty => XSize.s_empty;

  public bool IsEmpty => this._width < 0.0;

  public double Width
  {
    get => this._width;
    set
    {
      if (this.IsEmpty)
        throw new InvalidOperationException("CannotModifyEmptySize");
      this._width = value >= 0.0 ? value : throw new ArgumentException("WidthCannotBeNegative");
    }
  }

  public double Height
  {
    get => this._height;
    set
    {
      if (this.IsEmpty)
        throw new InvalidOperationException("CannotModifyEmptySize");
      this._height = value >= 0.0 ? value : throw new ArgumentException("HeightCannotBeNegative");
    }
  }

  public static explicit operator XVector(XSize size) => new XVector(size._width, size._height);

  public static explicit operator XPoint(XSize size) => new XPoint(size._width, size._height);

  private static XSize CreateEmptySize()
  {
    return new XSize()
    {
      _width = double.NegativeInfinity,
      _height = double.NegativeInfinity
    };
  }

  private string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "size=({2}{0:0.##########}, {1:0.##########})", (object) this._width, (object) this._height, this.IsEmpty ? (object) "Empty " : (object) "");
    }
  }
}
