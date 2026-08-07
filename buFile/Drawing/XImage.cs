// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.XImage
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing.Internal;
using PdfSharp.Internal;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

#nullable disable
namespace PdfSharp.Drawing;

public class XImage : IDisposable
{
  private XImageState _xImageState;
  private bool _disposed;
  private const Decimal FactorDPM72 = 2834.6456692913385826771653543M;
  private const Decimal FactorDPM = 39.370078740157480314960629921M;
  private bool _interpolate = true;
  private XImageFormat _format;
  private XGraphics _associatedGraphics;
  internal ImportedImage _importedImage;
  internal Image _gdiImage;
  internal string _path;
  internal Stream _stream;
  internal PdfImageTable.ImageSelector _selector;

  protected XImage()
  {
  }

  private XImage(ImportedImage image)
  {
    this._importedImage = image != null ? image : throw new ArgumentNullException(nameof (image));
    this.Initialize();
  }

  private XImage(string path)
  {
    path = Path.GetFullPath(path);
    this._path = File.Exists(path) ? path : throw new FileNotFoundException(PSSR.FileNotFound(path));
    try
    {
      Lock.EnterGdiPlus();
      this._gdiImage = Image.FromFile(path);
    }
    finally
    {
      Lock.ExitGdiPlus();
    }
    this.Initialize();
  }

  private XImage(Stream stream)
  {
    this._path = "*" + Guid.NewGuid().ToString("B");
    try
    {
      Lock.EnterGdiPlus();
      this._gdiImage = Image.FromStream(stream);
    }
    finally
    {
      Lock.ExitGdiPlus();
    }
    this._stream = stream;
    this.Initialize();
  }

  public static XImage FromFile(string path)
  {
    return PdfReader.TestPdfFile(path) <= 0 ? new XImage(path) : (XImage) new XPdfForm(path);
  }

  public static XImage FromStream(Stream stream)
  {
    if (stream == null)
      throw new ArgumentNullException(nameof (stream));
    return PdfReader.TestPdfFile(stream) <= 0 ? new XImage(stream) : (XImage) new XPdfForm(stream);
  }

  internal static XImage FromFile(string path, bool platformIndependent, PdfDocument document)
  {
    XImage ximage;
    if (!platformIndependent)
      ximage = XImage.FromFile(path);
    else
      ximage = new XImage(ImageImporter.GetImageImporter().ImportImage(path, document) ?? throw new InvalidOperationException("Unsupported image format."))
      {
        _path = path
      };
    return ximage;
  }

  internal static XImage FromStream(Stream stream, bool platformIndependent, PdfDocument document)
  {
    XImage ximage;
    if (!platformIndependent)
      ximage = XImage.FromStream(stream);
    else
      ximage = new XImage(ImageImporter.GetImageImporter().ImportImage(stream, document) ?? throw new InvalidOperationException("Unsupported image format."))
      {
        _stream = stream
      };
    return ximage;
  }

  [Obsolete("THHO4THHO Internal test code.")]
  internal static XImage FromImportedImage(ImportedImage image)
  {
    return image != null ? new XImage(image) : throw new ArgumentNullException(nameof (image));
  }

  public static bool ExistsFile(string path)
  {
    return PdfReader.TestPdfFile(path) > 0 || File.Exists(path);
  }

  internal XImageState XImageState
  {
    get => this._xImageState;
    set => this._xImageState = value;
  }

  internal void Initialize()
  {
    if (this._importedImage != null)
    {
      if (this._importedImage is ImportedImageJpeg)
        this._format = XImageFormat.Jpeg;
      else
        this._format = XImageFormat.Png;
    }
    else
    {
      if (this._gdiImage == null)
        return;
      string upper;
      try
      {
        Lock.EnterGdiPlus();
        upper = this._gdiImage.RawFormat.Guid.ToString("B").ToUpper();
      }
      finally
      {
        Lock.ExitGdiPlus();
      }
      switch (upper)
      {
        case "{B96B3CAA-0728-11D3-9D7B-0000F81EF32E}":
        case "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}":
        case "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}":
          this._format = XImageFormat.Png;
          break;
        case "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}":
          this._format = XImageFormat.Jpeg;
          break;
        case "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}":
          this._format = XImageFormat.Gif;
          break;
        case "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}":
          this._format = XImageFormat.Tiff;
          break;
        case "{B96B3CB5-0728-11D3-9D7B-0000F81EF32E}":
          this._format = XImageFormat.Icon;
          break;
        default:
          throw new InvalidOperationException("Unsupported image format.");
      }
    }
  }

  public void Dispose() => this.Dispose(true);

  protected virtual void Dispose(bool disposing)
  {
    if (!this._disposed)
      this._disposed = true;
    this._importedImage = (ImportedImage) null;
    if (this._gdiImage == null)
      return;
    try
    {
      Lock.EnterGdiPlus();
      this._gdiImage.Dispose();
      this._gdiImage = (Image) null;
    }
    finally
    {
      Lock.ExitGdiPlus();
    }
  }

  [Obsolete("Use either PixelWidth or PointWidth. Temporarily obsolete because of rearrangements for WPF. Currently same as PixelWidth, but will become PointWidth in future releases of PDFsharp.")]
  public virtual double Width
  {
    get
    {
      if (this._importedImage != null)
        return (double) this._importedImage.Information.Width;
      try
      {
        Lock.EnterGdiPlus();
        return (double) this._gdiImage.Width;
      }
      finally
      {
        Lock.ExitGdiPlus();
      }
    }
  }

  [Obsolete("Use either PixelHeight or PointHeight. Temporarily obsolete because of rearrangements for WPF. Currently same as PixelHeight, but will become PointHeight in future releases of PDFsharp.")]
  public virtual double Height
  {
    get
    {
      if (this._importedImage != null)
        return (double) this._importedImage.Information.Height;
      try
      {
        Lock.EnterGdiPlus();
        return (double) this._gdiImage.Height;
      }
      finally
      {
        Lock.ExitGdiPlus();
      }
    }
  }

  public virtual double PointWidth
  {
    get
    {
      if (this._importedImage != null)
      {
        if (this._importedImage.Information.HorizontalDPM > 0M)
          return (double) ((Decimal) this._importedImage.Information.Width * 2834.6456692913385826771653543M / this._importedImage.Information.HorizontalDPM);
        return this._importedImage.Information.HorizontalDPI > 0M ? (double) ((Decimal) (this._importedImage.Information.Width * 72U) / this._importedImage.Information.HorizontalDPI) : (double) this._importedImage.Information.Width;
      }
      try
      {
        Lock.EnterGdiPlus();
        return (double) (this._gdiImage.Width * 72) / (double) this._gdiImage.HorizontalResolution;
      }
      finally
      {
        Lock.ExitGdiPlus();
      }
    }
  }

  public virtual double PointHeight
  {
    get
    {
      if (this._importedImage != null)
      {
        if (this._importedImage.Information.VerticalDPM > 0M)
          return (double) ((Decimal) this._importedImage.Information.Height * 2834.6456692913385826771653543M / this._importedImage.Information.VerticalDPM);
        return this._importedImage.Information.VerticalDPI > 0M ? (double) ((Decimal) (this._importedImage.Information.Height * 72U) / this._importedImage.Information.VerticalDPI) : (double) this._importedImage.Information.Width;
      }
      try
      {
        Lock.EnterGdiPlus();
        return (double) (this._gdiImage.Height * 72) / (double) this._gdiImage.HorizontalResolution;
      }
      finally
      {
        Lock.ExitGdiPlus();
      }
    }
  }

  public virtual int PixelWidth
  {
    get
    {
      if (this._importedImage != null)
        return (int) this._importedImage.Information.Width;
      try
      {
        Lock.EnterGdiPlus();
        return this._gdiImage.Width;
      }
      finally
      {
        Lock.ExitGdiPlus();
      }
    }
  }

  public virtual int PixelHeight
  {
    get
    {
      if (this._importedImage != null)
        return (int) this._importedImage.Information.Height;
      try
      {
        Lock.EnterGdiPlus();
        return this._gdiImage.Height;
      }
      finally
      {
        Lock.ExitGdiPlus();
      }
    }
  }

  public virtual XSize Size => new XSize(this.PointWidth, this.PointHeight);

  public virtual double HorizontalResolution
  {
    get
    {
      if (this._importedImage != null)
      {
        if (this._importedImage.Information.HorizontalDPI > 0M)
          return (double) this._importedImage.Information.HorizontalDPI;
        return this._importedImage.Information.HorizontalDPM > 0M ? (double) (this._importedImage.Information.HorizontalDPM / 39.370078740157480314960629921M) : 72.0;
      }
      try
      {
        Lock.EnterGdiPlus();
        return (double) this._gdiImage.HorizontalResolution;
      }
      finally
      {
        Lock.ExitGdiPlus();
      }
    }
  }

  public virtual double VerticalResolution
  {
    get
    {
      if (this._importedImage != null)
      {
        if (this._importedImage.Information.VerticalDPI > 0M)
          return (double) this._importedImage.Information.VerticalDPI;
        return this._importedImage.Information.VerticalDPM > 0M ? (double) (this._importedImage.Information.VerticalDPM / 39.370078740157480314960629921M) : 72.0;
      }
      try
      {
        Lock.EnterGdiPlus();
        return (double) this._gdiImage.VerticalResolution;
      }
      finally
      {
        Lock.ExitGdiPlus();
      }
    }
  }

  public virtual bool Interpolate
  {
    get => this._interpolate;
    set => this._interpolate = value;
  }

  public XImageFormat Format => this._format;

  internal void AssociateWithGraphics(XGraphics gfx)
  {
    this._associatedGraphics = this._associatedGraphics == null ? (XGraphics) null : throw new InvalidOperationException("XImage already associated with XGraphics.");
  }

  internal void DisassociateWithGraphics()
  {
    if (this._associatedGraphics == null)
      throw new InvalidOperationException("XImage not associated with XGraphics.");
    this._associatedGraphics.DisassociateImage();
    Debug.Assert(this._associatedGraphics == null);
  }

  internal void DisassociateWithGraphics(XGraphics gfx)
  {
    this._associatedGraphics = this._associatedGraphics == gfx ? (XGraphics) null : throw new InvalidOperationException("XImage not associated with XGraphics.");
  }

  internal XGraphics AssociatedGraphics
  {
    get => this._associatedGraphics;
    set => this._associatedGraphics = value;
  }
}
