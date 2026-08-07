// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfRectangle
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;
using System;
using System.Globalization;

#nullable disable
namespace PdfSharp.Pdf;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
public sealed class PdfRectangle : PdfItem
{
  private readonly double _x1;
  private readonly double _y1;
  private readonly double _x2;
  private readonly double _y2;
  public static readonly PdfRectangle Empty = new PdfRectangle();

  public PdfRectangle()
  {
  }

  internal PdfRectangle(double x1, double y1, double x2, double y2)
  {
    this._x1 = x1;
    this._y1 = y1;
    this._x2 = x2;
    this._y2 = y2;
  }

  public PdfRectangle(XPoint pt1, XPoint pt2)
  {
    this._x1 = pt1.X;
    this._y1 = pt1.Y;
    this._x2 = pt2.X;
    this._y2 = pt2.Y;
  }

  public PdfRectangle(XPoint pt, XSize size)
  {
    this._x1 = pt.X;
    this._y1 = pt.Y;
    this._x2 = pt.X + size.Width;
    this._y2 = pt.Y + size.Height;
  }

  public PdfRectangle(XRect rect)
  {
    this._x1 = rect.X;
    this._y1 = rect.Y;
    this._x2 = rect.X + rect.Width;
    this._y2 = rect.Y + rect.Height;
  }

  internal PdfRectangle(PdfItem item)
  {
    if ((item == null ? 1 : (item is PdfNull ? 1 : 0)) != 0)
      return;
    if (item is PdfReference)
      item = (PdfItem) ((PdfReference) item).Value;
    this._x1 = item is PdfArray pdfArray ? pdfArray.Elements.GetReal(0) : throw new InvalidOperationException(PSSR.UnexpectedTokenInPdfFile);
    this._y1 = pdfArray.Elements.GetReal(1);
    this._x2 = pdfArray.Elements.GetReal(2);
    this._y2 = pdfArray.Elements.GetReal(3);
  }

  public PdfRectangle Clone() => (PdfRectangle) this.Copy();

  protected override object Copy() => (object) (PdfRectangle) base.Copy();

  public bool IsEmpty => this._x1 == 0.0 && this._y1 == 0.0 && this._x2 == 0.0 && this._y2 == 0.0;

  public override bool Equals(object obj)
  {
    PdfRectangle pdfRectangle1 = obj as PdfRectangle;
    bool flag;
    if (pdfRectangle1 != (PdfRectangle) null)
    {
      PdfRectangle pdfRectangle2 = pdfRectangle1;
      flag = pdfRectangle2._x1 == this._x1 && pdfRectangle2._y1 == this._y1 && pdfRectangle2._x2 == this._x2 && pdfRectangle2._y2 == this._y2;
    }
    else
      flag = false;
    return flag;
  }

  public override int GetHashCode()
  {
    return (int) (uint) this._x1 ^ ((int) (uint) this._y1 << 13 | (int) ((uint) this._y1 >> 19)) ^ ((int) (uint) this._x2 << 26 | (int) ((uint) this._x2 >> 6)) ^ ((int) (uint) this._y2 << 7 | (int) ((uint) this._y2 >> 25));
  }

  public static bool operator ==(PdfRectangle left, PdfRectangle right)
  {
    return left == null ? (object) right == null : right != null && left._x1 == right._x1 && left._y1 == right._y1 && left._x2 == right._x2 && left._y2 == right._y2;
  }

  public static bool operator !=(PdfRectangle left, PdfRectangle right) => !(left == right);

  public double X1 => this._x1;

  public double Y1 => this._y1;

  public double X2 => this._x2;

  public double Y2 => this._y2;

  public double Width => this._x2 - this._x1;

  public double Height => this._y2 - this._y1;

  public XPoint Location => new XPoint(this._x1, this._y1);

  public XSize Size => new XSize(this._x2 - this._x1, this._y2 - this._y1);

  public bool Contains(XPoint pt) => this.Contains(pt.X, pt.Y);

  public bool Contains(double x, double y)
  {
    return this._x1 <= x && x <= this._x2 && this._y1 <= y && y <= this._y2;
  }

  public bool Contains(XRect rect)
  {
    return this._x1 <= rect.X && rect.X + rect.Width <= this._x2 && this._y1 <= rect.Y && rect.Y + rect.Height <= this._y2;
  }

  public bool Contains(PdfRectangle rect)
  {
    return this._x1 <= rect._x1 && rect._x2 <= this._x2 && this._y1 <= rect._y1 && rect._y2 <= this._y2;
  }

  public XRect ToXRect() => new XRect(this._x1, this._y1, this.Width, this.Height);

  public override string ToString()
  {
    return PdfEncoders.Format("[{0:0.###} {1:0.###} {2:0.###} {3:0.###}]", (object) this._x1, (object) this._y1, (object) this._x2, (object) this._y2);
  }

  internal override void WriteObject(PdfWriter writer) => writer.Write(this);

  private string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "X1={0:0.##########}, X2={1:0.##########}, Y1={2:0.##########}, Y2={3:0.##########}", (object) this._x1, (object) this._y1, (object) this.X2, (object) this._y2);
    }
  }
}
