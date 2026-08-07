// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.BarCodes.BarCode
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.ComponentModel;

#nullable disable
namespace PdfSharp.Drawing.BarCodes;

public abstract class BarCode : CodeBase
{
  private TextLocation _textLocation;
  private int _dataLength;
  private char _startChar;
  private char _endChar;
  private bool _turboBit;

  public BarCode(string text, XSize size, CodeDirection direction)
    : base(text, size, direction)
  {
    this.Text = text;
    this.Size = size;
    this.Direction = direction;
  }

  public static BarCode FromType(CodeType type, string text, XSize size, CodeDirection direction)
  {
    BarCode barCode;
    switch (type)
    {
      case CodeType.Code2of5Interleaved:
        barCode = (BarCode) new Code2of5Interleaved(text, size, direction);
        break;
      case CodeType.Code3of9Standard:
        barCode = (BarCode) new Code3of9Standard(text, size, direction);
        break;
      default:
        throw new InvalidEnumArgumentException(nameof (type), (int) type, typeof (CodeType));
    }
    return barCode;
  }

  public static BarCode FromType(CodeType type, string text, XSize size)
  {
    return BarCode.FromType(type, text, size, CodeDirection.LeftToRight);
  }

  public static BarCode FromType(CodeType type, string text)
  {
    return BarCode.FromType(type, text, XSize.Empty, CodeDirection.LeftToRight);
  }

  public static BarCode FromType(CodeType type)
  {
    return BarCode.FromType(type, string.Empty, XSize.Empty, CodeDirection.LeftToRight);
  }

  public virtual double WideNarrowRatio
  {
    get => 0.0;
    set
    {
    }
  }

  public TextLocation TextLocation
  {
    get => this._textLocation;
    set => this._textLocation = value;
  }

  public int DataLength
  {
    get => this._dataLength;
    set => this._dataLength = value;
  }

  public char StartChar
  {
    get => this._startChar;
    set => this._startChar = value;
  }

  public char EndChar
  {
    get => this._endChar;
    set => this._endChar = value;
  }

  public virtual bool TurboBit
  {
    get => this._turboBit;
    set => this._turboBit = value;
  }

  internal virtual void InitRendering(BarCodeRenderInfo info)
  {
    if (this.Text == null)
      throw new InvalidOperationException(BcgSR.BarCodeNotSet);
    if (this.Size.IsEmpty)
      throw new InvalidOperationException(BcgSR.EmptyBarCodeSize);
  }

  protected internal abstract void Render(
    XGraphics gfx,
    XBrush brush,
    XFont font,
    XPoint position);
}
