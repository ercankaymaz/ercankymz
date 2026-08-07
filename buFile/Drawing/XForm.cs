// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XForm
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing.Pdf;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Drawing;

public class XForm : XImage, IContentStream
{
  internal XGraphics Gfx;
  private PdfDocument _document;
  internal XForm.FormState _formState;
  private XRect _viewBox;
  private XRect _boundingBox;
  internal XMatrix _transform;
  internal PdfFormXObject _pdfForm;
  internal XGraphicsPdfRenderer PdfRenderer;

  protected XForm()
  {
  }

  public XForm(PdfDocument document, XRect viewBox)
  {
    if ((viewBox.Width < 1.0 ? 1 : (viewBox.Height < 1.0 ? 1 : 0)) != 0)
      throw new ArgumentNullException(nameof (viewBox), "The size of the XPdfForm is to small.");
    if (document == null)
      throw new ArgumentNullException(nameof (document), "An XPdfForm template must be associated with a document at creation time.");
    this._formState = XForm.FormState.Created;
    this._document = document;
    this._pdfForm = new PdfFormXObject(document, this);
    this._viewBox = viewBox;
    this._pdfForm.Elements.SetRectangle("/BBox", new PdfRectangle(viewBox));
  }

  public XForm(PdfDocument document, XSize size)
    : this(document, new XRect(0.0, 0.0, size.Width, size.Height))
  {
  }

  public XForm(PdfDocument document, XUnit width, XUnit height)
    : this(document, new XRect(0.0, 0.0, (double) width, (double) height))
  {
  }

  public void DrawingFinished()
  {
    if (this._formState == XForm.FormState.Finished)
      return;
    if (this._formState == XForm.FormState.NotATemplate)
      throw new InvalidOperationException("This object is an imported PDF page and you cannot finish drawing on it because you must not draw on it at all.");
    this.Finish();
  }

  internal void AssociateGraphics(XGraphics gfx)
  {
    if (this._formState == XForm.FormState.NotATemplate)
      throw new NotImplementedException("The current version of PDFsharp cannot draw on an imported page.");
    if (this._formState == XForm.FormState.UnderConstruction)
      throw new InvalidOperationException("An XGraphics object already exists for this form.");
    if (this._formState == XForm.FormState.Finished)
      throw new InvalidOperationException("After drawing a form it cannot be modified anymore.");
    Debug.Assert(this._formState == XForm.FormState.Created);
    this._formState = XForm.FormState.UnderConstruction;
    this.Gfx = gfx;
  }

  protected override void Dispose(bool disposing) => base.Dispose(disposing);

  internal virtual void Finish()
  {
  }

  internal PdfDocument Owner => this._document;

  internal PdfColorMode ColorMode
  {
    get => this._document != null ? this._document.Options.ColorMode : PdfColorMode.Undefined;
  }

  internal bool IsTemplate => this._formState != 0;

  [Obsolete("Use either PixelWidth or PointWidth. Temporarily obsolete because of rearrangements for WPF. Currently same as PixelWidth, but will become PointWidth in future releases of PDFsharp.")]
  public override double Width => this._viewBox.Width;

  [Obsolete("Use either PixelHeight or PointHeight. Temporarily obsolete because of rearrangements for WPF. Currently same as PixelHeight, but will become PointHeight in future releases of PDFsharp.")]
  public override double Height => this._viewBox.Height;

  public override double PointWidth => this._viewBox.Width;

  public override double PointHeight => this._viewBox.Height;

  public override int PixelWidth => (int) this._viewBox.Width;

  public override int PixelHeight => (int) this._viewBox.Height;

  public override XSize Size => this._viewBox.Size;

  public XRect ViewBox => this._viewBox;

  public override double HorizontalResolution => 72.0;

  public override double VerticalResolution => 72.0;

  public XRect BoundingBox
  {
    get => this._boundingBox;
    set => this._boundingBox = value;
  }

  public virtual XMatrix Transform
  {
    get => this._transform;
    set
    {
      if (this._formState == XForm.FormState.Finished)
        throw new InvalidOperationException("After a XPdfForm was once drawn it must not be modified.");
      this._transform = value;
    }
  }

  internal PdfResources Resources
  {
    get
    {
      Debug.Assert(this.IsTemplate, "This function is for form templates only.");
      return this.PdfForm.Resources;
    }
  }

  PdfResources IContentStream.Resources => this.Resources;

  internal string GetFontName(XFont font, out PdfFont pdfFont)
  {
    Debug.Assert(this.IsTemplate, "This function is for form templates only.");
    pdfFont = this._document.FontTable.GetFont(font);
    Debug.Assert(pdfFont != null);
    return this.Resources.AddFont(pdfFont);
  }

  string IContentStream.GetFontName(XFont font, out PdfFont pdfFont)
  {
    return this.GetFontName(font, out pdfFont);
  }

  internal string TryGetFontName(string idName, out PdfFont pdfFont)
  {
    Debug.Assert(this.IsTemplate, "This function is for form templates only.");
    pdfFont = this._document.FontTable.TryGetFont(idName);
    string fontName = (string) null;
    if (pdfFont != null)
      fontName = this.Resources.AddFont(pdfFont);
    return fontName;
  }

  internal string GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
  {
    Debug.Assert(this.IsTemplate, "This function is for form templates only.");
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
    Debug.Assert(this.IsTemplate, "This function is for form templates only.");
    PdfImage image1 = this._document.ImageTable.GetImage(image);
    Debug.Assert(image1 != null);
    return this.Resources.AddImage(image1);
  }

  string IContentStream.GetImageName(XImage image) => this.GetImageName(image);

  internal PdfFormXObject PdfForm
  {
    get
    {
      Debug.Assert(this.IsTemplate, "This function is for form templates only.");
      if (this._pdfForm.Reference == null)
        this._document._irefTable.Add((PdfObject) this._pdfForm);
      return this._pdfForm;
    }
  }

  internal string GetFormName(XForm form)
  {
    Debug.Assert(this.IsTemplate, "This function is for form templates only.");
    PdfFormXObject form1 = this._document.FormTable.GetForm(form);
    Debug.Assert(form1 != null);
    return this.Resources.AddForm(form1);
  }

  string IContentStream.GetFormName(XForm form) => this.GetFormName(form);

  internal enum FormState
  {
    NotATemplate,
    Created,
    UnderConstruction,
    Finished,
  }
}
