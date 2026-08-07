// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfShading
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Drawing.Pdf;
using PdfSharp.Pdf.Internal;
using System;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfShading(PdfDocument document) : PdfDictionary(document)
{
  internal void SetupFromBrush(XLinearGradientBrush brush, XGraphicsPdfRenderer renderer)
  {
    if (brush == null)
      throw new ArgumentNullException(nameof (brush));
    PdfColorMode colorMode = this._document.Options.ColorMode;
    XColor color1 = ColorSpaceHelper.EnsureColorMode(colorMode, brush._color1);
    XColor color2 = ColorSpaceHelper.EnsureColorMode(colorMode, brush._color2);
    PdfDictionary pdfDictionary = new PdfDictionary();
    this.Elements["/ShadingType"] = (PdfItem) new PdfInteger(2);
    if (colorMode != PdfColorMode.Cmyk)
      this.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceRGB");
    else
      this.Elements["/ColorSpace"] = (PdfItem) new PdfName("/DeviceCMYK");
    double num1 = 0.0;
    double num2 = 0.0;
    double num3 = 0.0;
    double num4 = 0.0;
    if (brush._useRect)
    {
      XPoint view1 = renderer.WorldToView(brush._rect.TopLeft);
      XPoint view2 = renderer.WorldToView(brush._rect.BottomRight);
      switch (brush._linearGradientMode)
      {
        case XLinearGradientMode.Horizontal:
          num1 = view1.X;
          num2 = view1.Y;
          num3 = view2.X;
          num4 = view1.Y;
          break;
        case XLinearGradientMode.Vertical:
          num1 = view1.X;
          num2 = view1.Y;
          num3 = view1.X;
          num4 = view2.Y;
          break;
        case XLinearGradientMode.ForwardDiagonal:
          num1 = view1.X;
          num2 = view1.Y;
          num3 = view2.X;
          num4 = view2.Y;
          break;
        case XLinearGradientMode.BackwardDiagonal:
          num1 = view2.X;
          num2 = view1.Y;
          num3 = view1.X;
          num4 = view2.Y;
          break;
      }
    }
    else
    {
      XPoint view3 = renderer.WorldToView(brush._point1);
      XPoint view4 = renderer.WorldToView(brush._point2);
      num1 = view3.X;
      num2 = view3.Y;
      num3 = view4.X;
      num4 = view4.Y;
    }
    this.Elements["/Coords"] = (PdfItem) new PdfLiteral("[{0:0.###} {1:0.###} {2:0.###} {3:0.###}]", new object[4]
    {
      (object) num1,
      (object) num2,
      (object) num3,
      (object) num4
    });
    this.Elements["/Function"] = (PdfItem) pdfDictionary;
    string str1 = $"[{PdfEncoders.ToString(color1, colorMode)}]";
    string str2 = $"[{PdfEncoders.ToString(color2, colorMode)}]";
    pdfDictionary.Elements["/FunctionType"] = (PdfItem) new PdfInteger(2);
    pdfDictionary.Elements["/C0"] = (PdfItem) new PdfLiteral(str1);
    pdfDictionary.Elements["/C1"] = (PdfItem) new PdfLiteral(str2);
    pdfDictionary.Elements["/Domain"] = (PdfItem) new PdfLiteral("[0 1]");
    pdfDictionary.Elements["/N"] = (PdfItem) new PdfInteger(1);
  }

  internal override DictionaryMeta Meta => PdfShading.Keys.Meta;

  internal sealed class Keys : KeysBase
  {
    [KeyInfo(KeyType.Integer | KeyType.Required)]
    public const string ShadingType = "/ShadingType";
    [KeyInfo(KeyType.NameOrArray | KeyType.Required)]
    public const string ColorSpace = "/ColorSpace";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Background = "/Background";
    [KeyInfo(KeyType.Rectangle | KeyType.Optional)]
    public const string BBox = "/BBox";
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string AntiAlias = "/AntiAlias";
    [KeyInfo(KeyType.Array | KeyType.Required)]
    public const string Coords = "/Coords";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Domain = "/Domain";
    [KeyInfo(KeyType.Function | KeyType.Required)]
    public const string Function = "/Function";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Extend = "/Extend";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfShading.Keys._meta ?? (PdfShading.Keys._meta = KeysBase.CreateMeta(typeof (PdfShading.Keys)));
      }
    }
  }
}
