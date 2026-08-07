// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XLinearGradientBrush
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.ComponentModel;

#nullable disable
namespace PdfSharp.Drawing;

public sealed class XLinearGradientBrush : XBrush
{
  internal bool _useRect;
  internal XPoint _point1;
  internal XPoint _point2;
  internal XColor _color1;
  internal XColor _color2;
  internal XRect _rect;
  internal XLinearGradientMode _linearGradientMode;
  internal XMatrix _matrix;

  public XLinearGradientBrush(XPoint point1, XPoint point2, XColor color1, XColor color2)
  {
    this._point1 = point1;
    this._point2 = point2;
    this._color1 = color1;
    this._color2 = color2;
  }

  public XLinearGradientBrush(
    XRect rect,
    XColor color1,
    XColor color2,
    XLinearGradientMode linearGradientMode)
  {
    if (!Enum.IsDefined(typeof (XLinearGradientMode), (object) linearGradientMode))
      throw new InvalidEnumArgumentException(nameof (linearGradientMode), (int) linearGradientMode, typeof (XLinearGradientMode));
    if ((rect.Width == 0.0 ? 1 : (rect.Height == 0.0 ? 1 : 0)) != 0)
      throw new ArgumentException("Invalid rectangle.", nameof (rect));
    this._useRect = true;
    this._color1 = color1;
    this._color2 = color2;
    this._rect = rect;
    this._linearGradientMode = linearGradientMode;
  }

  public XMatrix Transform
  {
    get => this._matrix;
    set => this._matrix = value;
  }

  public void TranslateTransform(double dx, double dy) => this._matrix.TranslatePrepend(dx, dy);

  public void TranslateTransform(double dx, double dy, XMatrixOrder order)
  {
    this._matrix.Translate(dx, dy, order);
  }

  public void ScaleTransform(double sx, double sy) => this._matrix.ScalePrepend(sx, sy);

  public void ScaleTransform(double sx, double sy, XMatrixOrder order)
  {
    this._matrix.Scale(sx, sy, order);
  }

  public void RotateTransform(double angle) => this._matrix.RotatePrepend(angle);

  public void RotateTransform(double angle, XMatrixOrder order)
  {
    this._matrix.Rotate(angle, order);
  }

  public void MultiplyTransform(XMatrix matrix) => this._matrix.Prepend(matrix);

  public void MultiplyTransform(XMatrix matrix, XMatrixOrder order)
  {
    this._matrix.Multiply(matrix, order);
  }

  public void ResetTransform() => this._matrix = new XMatrix();
}
