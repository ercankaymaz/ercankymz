// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfDictionaryWithContentStream
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public abstract class PdfDictionaryWithContentStream : PdfDictionary, IContentStream
{
  private PdfResources _resources;

  public PdfDictionaryWithContentStream()
  {
  }

  public PdfDictionaryWithContentStream(PdfDocument document)
    : base(document)
  {
  }

  protected PdfDictionaryWithContentStream(PdfDictionary dict)
    : base(dict)
  {
  }

  internal PdfResources Resources
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

  internal string GetImageName(XImage image)
  {
    PdfImage image1 = this._document.ImageTable.GetImage(image);
    Debug.Assert(image1 != null);
    return this.Resources.AddImage(image1);
  }

  string IContentStream.GetImageName(XImage image) => throw new NotImplementedException();

  internal string GetFormName(XForm form)
  {
    PdfFormXObject form1 = this._document.FormTable.GetForm(form);
    Debug.Assert(form1 != null);
    return this.Resources.AddForm(form1);
  }

  string IContentStream.GetFormName(XForm form) => throw new NotImplementedException();

  public class Keys : PdfDictionary.PdfStream.Keys
  {
    [KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof (PdfResources))]
    public const string Resources = "/Resources";
  }
}
