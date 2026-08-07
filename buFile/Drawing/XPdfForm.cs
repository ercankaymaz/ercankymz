// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XPdfForm
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Internal;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;
using System;
using System.IO;

#nullable disable
namespace PdfSharp.Drawing;

public class XPdfForm : XForm
{
  private bool _disposed;
  private XImage _placeHolder;
  private int _pageCount = -1;
  private int _pageNumber = 1;
  internal PdfDocument _externalDocument;

  internal XPdfForm(string path)
  {
    int pageNumber;
    path = XPdfForm.ExtractPageNumber(path, out pageNumber);
    path = Path.GetFullPath(path);
    if (!File.Exists(path))
      throw new FileNotFoundException(PSSR.FileNotFound(path));
    this._path = PdfReader.TestPdfFile(path) != 0 ? path : throw new ArgumentException("The specified file has no valid PDF file header.", nameof (path));
    if (pageNumber == 0)
      return;
    this.PageNumber = pageNumber;
  }

  internal XPdfForm(Stream stream)
  {
    this._path = "*" + Guid.NewGuid().ToString("B");
    this._externalDocument = PdfReader.TestPdfFile(stream) != 0 ? PdfReader.Open(stream) : throw new ArgumentException("The specified stream has no valid PDF file header.", nameof (stream));
  }

  public static XPdfForm FromFile(string path) => new XPdfForm(path);

  public static XPdfForm FromStream(Stream stream) => new XPdfForm(stream);

  internal override void Finish()
  {
    if ((this._formState == XForm.FormState.NotATemplate ? 1 : (this._formState == XForm.FormState.Finished ? 1 : 0)) != 0)
      return;
    base.Finish();
  }

  protected override void Dispose(bool disposing)
  {
    if (this._disposed)
      return;
    this._disposed = true;
    try
    {
      if (disposing)
        ;
      if (this._externalDocument == null)
        return;
      PdfDocument.Tls.DetachDocument(this._externalDocument.Handle);
    }
    finally
    {
      base.Dispose(disposing);
    }
  }

  public XImage PlaceHolder
  {
    get => this._placeHolder;
    set => this._placeHolder = value;
  }

  public PdfPage Page
  {
    get => !this.IsTemplate ? this.ExternalDocument.Pages[this._pageNumber - 1] : (PdfPage) null;
  }

  public int PageCount
  {
    get
    {
      int pageCount;
      if (this.IsTemplate)
      {
        pageCount = 1;
      }
      else
      {
        if (this._pageCount == -1)
          this._pageCount = this.ExternalDocument.Pages.Count;
        pageCount = this._pageCount;
      }
      return pageCount;
    }
  }

  [Obsolete("Use either PixelWidth or PointWidth. Temporarily obsolete because of rearrangements for WPF.")]
  public override double Width => (double) this.ExternalDocument.Pages[this._pageNumber - 1].Width;

  [Obsolete("Use either PixelHeight or PointHeight. Temporarily obsolete because of rearrangements for WPF.")]
  public override double Height
  {
    get => (double) this.ExternalDocument.Pages[this._pageNumber - 1].Height;
  }

  public override double PointWidth
  {
    get => (double) this.ExternalDocument.Pages[this._pageNumber - 1].Width;
  }

  public override double PointHeight
  {
    get => (double) this.ExternalDocument.Pages[this._pageNumber - 1].Height;
  }

  public override int PixelWidth => DoubleUtil.DoubleToInt(this.PointWidth);

  public override int PixelHeight => DoubleUtil.DoubleToInt(this.PointHeight);

  public override XSize Size
  {
    get
    {
      PdfPage page = this.ExternalDocument.Pages[this._pageNumber - 1];
      return new XSize((double) page.Width, (double) page.Height);
    }
  }

  public override XMatrix Transform
  {
    get => this._transform;
    set
    {
      if (!(this._transform != value))
        return;
      this._pdfForm = (PdfFormXObject) null;
      this._transform = value;
    }
  }

  public int PageNumber
  {
    get => this._pageNumber;
    set
    {
      if (this.IsTemplate)
        throw new InvalidOperationException("The page number of an XPdfForm template cannot be modified.");
      if (this._pageNumber == value)
        return;
      this._pageNumber = value;
      this._pdfForm = (PdfFormXObject) null;
    }
  }

  public int PageIndex
  {
    get => this.PageNumber - 1;
    set => this.PageNumber = value + 1;
  }

  internal PdfDocument ExternalDocument
  {
    get
    {
      if (this.IsTemplate)
        throw new InvalidOperationException("This XPdfForm is a template and not an imported PDF page; therefore it has no external document.");
      if (this._externalDocument == null)
        this._externalDocument = PdfDocument.Tls.GetDocument(this._path);
      return this._externalDocument;
    }
  }

  public static string ExtractPageNumber(string path, out int pageNumber)
  {
    if (path == null)
      throw new ArgumentNullException(nameof (path));
    pageNumber = 0;
    int length = path.Length;
    if (length != 0)
    {
      int num = length - 1;
      if (char.IsDigit(path, num))
      {
        while ((!char.IsDigit(path, num) ? 0 : (num >= 0 ? 1 : 0)) != 0)
          --num;
        if ((num <= 0 ? 0 : (path[num] == '#' ? 1 : 0)) != 0 && path.IndexOf('.') != -1)
        {
          pageNumber = int.Parse(path.Substring(num + 1));
          path = path.Substring(0, num);
        }
      }
    }
    return path;
  }
}
