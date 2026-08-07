// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.BarCodes.CodeDataMatrix
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Drawing.BarCodes;

public class CodeDataMatrix : MatrixCode
{
  private int _quietZone;

  public CodeDataMatrix()
    : this("", "", 26, 26, 0, XSize.Empty)
  {
  }

  public CodeDataMatrix(string code, int length)
    : this(code, "", length, length, 0, XSize.Empty)
  {
  }

  public CodeDataMatrix(string code, int length, XSize size)
    : this(code, "", length, length, 0, size)
  {
  }

  public CodeDataMatrix(string code, DataMatrixEncoding dmEncoding, int length, XSize size)
    : this(code, CodeDataMatrix.CreateEncoding(dmEncoding, code.Length), length, length, 0, size)
  {
  }

  public CodeDataMatrix(string code, int rows, int columns)
    : this(code, "", rows, columns, 0, XSize.Empty)
  {
  }

  public CodeDataMatrix(string code, int rows, int columns, XSize size)
    : this(code, "", rows, columns, 0, size)
  {
  }

  public CodeDataMatrix(
    string code,
    DataMatrixEncoding dmEncoding,
    int rows,
    int columns,
    XSize size)
    : this(code, CodeDataMatrix.CreateEncoding(dmEncoding, code.Length), rows, columns, 0, size)
  {
  }

  public CodeDataMatrix(string code, int rows, int columns, int quietZone)
    : this(code, "", rows, columns, quietZone, XSize.Empty)
  {
  }

  public CodeDataMatrix(
    string code,
    string encoding,
    int rows,
    int columns,
    int quietZone,
    XSize size)
    : base(code, encoding, rows, columns, size)
  {
    this.QuietZone = quietZone;
  }

  public void SetEncoding(DataMatrixEncoding dmEncoding)
  {
    this.Encoding = CodeDataMatrix.CreateEncoding(dmEncoding, this.Text.Length);
  }

  private static string CreateEncoding(DataMatrixEncoding dmEncoding, int length)
  {
    string encoding = "";
    switch (dmEncoding)
    {
      case DataMatrixEncoding.Ascii:
        encoding = new string('a', length);
        break;
      case DataMatrixEncoding.C40:
        encoding = new string('c', length);
        break;
      case DataMatrixEncoding.Text:
        encoding = new string('t', length);
        break;
      case DataMatrixEncoding.X12:
        encoding = new string('x', length);
        break;
      case DataMatrixEncoding.EDIFACT:
        encoding = new string('e', length);
        break;
      case DataMatrixEncoding.Base256:
        encoding = new string('b', length);
        break;
    }
    return encoding;
  }

  public int QuietZone
  {
    get => this._quietZone;
    set => this._quietZone = value;
  }

  protected internal override void Render(XGraphics gfx, XBrush brush, XPoint position)
  {
    XGraphicsState state = gfx.Save();
    switch (this.Direction)
    {
      case CodeDirection.BottomToTop:
        gfx.RotateAtTransform(-90.0, position);
        break;
      case CodeDirection.RightToLeft:
        gfx.RotateAtTransform(180.0, position);
        break;
      case CodeDirection.TopToBottom:
        gfx.RotateAtTransform(90.0, position);
        break;
    }
    XPoint xpoint1 = position + CodeBase.CalcDistance(this.Anchor, AnchorType.TopLeft, this.Size);
    if (this.MatrixImage == null)
      this.MatrixImage = DataMatrixImage.GenerateMatrixImage(this.Text, this.Encoding, this.Rows, this.Columns);
    if (this.QuietZone > 0)
    {
      XSize xsize = new XSize(this.Size.Width, this.Size.Height);
      xsize.Width = xsize.Width / (double) (this.Columns + 2 * this.QuietZone) * (double) this.Columns;
      xsize.Height = xsize.Height / (double) (this.Rows + 2 * this.QuietZone) * (double) this.Rows;
      XPoint xpoint2 = new XPoint(xpoint1.X, xpoint1.Y);
      xpoint2.X += this.Size.Width / (double) (this.Columns + 2 * this.QuietZone) * (double) this.QuietZone;
      xpoint2.Y += this.Size.Height / (double) (this.Rows + 2 * this.QuietZone) * (double) this.QuietZone;
      gfx.DrawRectangle((XBrush) XBrushes.White, xpoint1.X, xpoint1.Y, this.Size.Width, this.Size.Height);
      gfx.DrawImage(this.MatrixImage, xpoint2.X, xpoint2.Y, xsize.Width, xsize.Height);
    }
    else
      gfx.DrawImage(this.MatrixImage, xpoint1.X, xpoint1.Y, this.Size.Width, this.Size.Height);
    gfx.Restore(state);
  }

  protected override void CheckCode(string text)
  {
    if (text == null)
      throw new ArgumentNullException(nameof (text));
    new DataMatrixImage(this.Text, this.Encoding, this.Rows, this.Columns).Iec16022Ecc200(this.Columns, this.Rows, this.Encoding, this.Text.Length, this.Text, 0, 0, 0);
  }
}
