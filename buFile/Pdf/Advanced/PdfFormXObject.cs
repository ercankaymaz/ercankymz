// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfFormXObject
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public sealed class PdfFormXObject : PdfXObject, IContentStream
{
  private double _dpiX = 72.0;
  private double _dpiY = 72.0;
  private PdfResources _resources;

  internal PdfFormXObject(PdfDocument thisDocument)
    : base(thisDocument)
  {
    this.Elements.SetName("/Type", "/XObject");
    this.Elements.SetName("/Subtype", "/Form");
  }

  internal PdfFormXObject(PdfDocument thisDocument, XForm form)
    : base(thisDocument)
  {
    this.Elements.SetName("/Type", "/XObject");
    this.Elements.SetName("/Subtype", "/Form");
  }

  internal double DpiX
  {
    get => this._dpiX;
    set => this._dpiX = value;
  }

  internal double DpiY
  {
    get => this._dpiY;
    set => this._dpiY = value;
  }

  internal PdfFormXObject(
    PdfDocument thisDocument,
    PdfImportedObjectTable importedObjectTable,
    XPdfForm form)
    : base(thisDocument)
  {
    Debug.Assert(importedObjectTable != null);
    Debug.Assert(thisDocument == importedObjectTable.Owner);
    this.Elements.SetName("/Type", "/XObject");
    this.Elements.SetName("/Subtype", "/Form");
    if (form.IsTemplate)
    {
      Debug.Assert(importedObjectTable == null);
    }
    else
    {
      XPdfForm xpdfForm = form;
      PdfPages pages = importedObjectTable.ExternalDocument.Pages;
      if ((xpdfForm.PageNumber < 1 ? 1 : (xpdfForm.PageNumber > pages.Count ? 1 : 0)) != 0)
        PSSR.ImportPageNumberOutOfRange(xpdfForm.PageNumber, pages.Count, form._path);
      PdfPage pdfPage = pages[xpdfForm.PageNumber - 1];
      PdfItem element1 = pdfPage.Elements["/Resources"];
      if (element1 != null)
      {
        PdfObject externalObject = !(element1 is PdfReference) ? (PdfObject) element1 : ((PdfReference) element1).Value;
        PdfObject pdfObject = PdfObject.ImportClosure(importedObjectTable, thisDocument, externalObject);
        if (pdfObject.Reference == null)
          thisDocument._irefTable.Add(pdfObject);
        Debug.Assert(pdfObject.Reference != null);
        this.Elements["/Resources"] = (PdfItem) pdfObject.Reference;
      }
      PdfRectangle rectangle = pdfPage.Elements.GetRectangle("/MediaBox");
      int integer = pdfPage.Elements.GetInteger("/Rotate");
      if (integer == 0)
      {
        this.Elements["/BBox"] = (PdfItem) rectangle;
      }
      else
      {
        this.Elements["/BBox"] = (PdfItem) rectangle;
        XMatrix matrix = new XMatrix();
        double width = rectangle.Width;
        double height = rectangle.Height;
        matrix.RotateAtPrepend((double) -integer, new XPoint(width / 2.0, height / 2.0));
        if (integer != 180)
        {
          double num = (height - width) / 2.0;
          if (height > width)
            matrix.TranslatePrepend(num, num);
          else
            matrix.TranslatePrepend(-num, -num);
        }
        this.Elements.SetMatrix("/Matrix", matrix);
      }
      PdfContent singleContent = pdfPage.Contents.CreateSingleContent();
      PdfItem element2 = singleContent.Elements["/Filter"];
      if (element2 != null)
        this.Elements["/Filter"] = element2.Clone();
      this.Stream = singleContent.Stream;
      this.Elements.SetInteger("/Length", singleContent.Stream.Value.Length);
    }
  }

  public PdfResources Resources
  {
    get
    {
      if (this._resources == null)
        this._resources = (PdfResources) this.Elements.GetValue("/Resources", VCF.Create);
      return this._resources;
    }
  }

  PdfResources IContentStream.Resources => this.Resources;

  internal string GetFontName(XFont font, out PdfFont pdfFont)
  {
    pdfFont = this._document.FontTable.GetFont(font);
    Debug.Assert(pdfFont != null);
    return this.Resources.AddFont(pdfFont);
  }

  string IContentStream.GetFontName(XFont font, out PdfFont pdfFont)
  {
    return this.GetFontName(font, out pdfFont);
  }

  internal string GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
  {
    pdfFont = this._document.FontTable.GetFont(idName, fontData);
    Debug.Assert(pdfFont != null);
    return this.Resources.AddFont(pdfFont);
  }

  string IContentStream.GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
  {
    return this.GetFontName(idName, fontData, out pdfFont);
  }

  string IContentStream.GetImageName(XImage image) => throw new NotImplementedException();

  string IContentStream.GetFormName(XForm form) => throw new NotImplementedException();

  internal override DictionaryMeta Meta => PdfFormXObject.Keys.Meta;

  public new sealed class Keys : PdfXObject.Keys
  {
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string Subtype = "/Subtype";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string FormType = "/FormType";
    [KeyInfo(KeyType.Rectangle | KeyType.Required)]
    public const string BBox = "/BBox";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string Matrix = "/Matrix";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof (PdfResources))]
    public const string Resources = "/Resources";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional)]
    public const string Group = "/Group";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfFormXObject.Keys._meta ?? (PdfFormXObject.Keys._meta = KeysBase.CreateMeta(typeof (PdfFormXObject.Keys)));
      }
    }
  }
}
