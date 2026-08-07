// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.BarCodes.MatrixCode
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Drawing.BarCodes;

public abstract class MatrixCode : CodeBase
{
  private string _encoding;
  private int _columns;
  private int _rows;
  private XImage _matrixImage;

  public MatrixCode(string text, string encoding, int rows, int columns, XSize size)
    : base(text, size, CodeDirection.LeftToRight)
  {
    this._encoding = encoding;
    if (string.IsNullOrEmpty(this._encoding))
      this._encoding = new string('a', this.Text.Length);
    if (columns < rows)
    {
      this._rows = columns;
      this._columns = rows;
    }
    else
    {
      this._columns = columns;
      this._rows = rows;
    }
    this.Text = text;
  }

  public string Encoding
  {
    get => this._encoding;
    set
    {
      this._encoding = value;
      this._matrixImage = (XImage) null;
    }
  }

  public int Columns
  {
    get => this._columns;
    set
    {
      this._columns = value;
      this._matrixImage = (XImage) null;
    }
  }

  public int Rows
  {
    get => this._rows;
    set
    {
      this._rows = value;
      this._matrixImage = (XImage) null;
    }
  }

  public new string Text
  {
    get => base.Text;
    set
    {
      base.Text = value;
      this._matrixImage = (XImage) null;
    }
  }

  internal XImage MatrixImage
  {
    get => this._matrixImage;
    set => this._matrixImage = value;
  }

  protected internal abstract void Render(XGraphics gfx, XBrush brush, XPoint center);

  protected override void CheckCode(string text)
  {
  }
}
