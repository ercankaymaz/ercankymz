#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using PdfSharp.Drawing.Internal;
using PdfSharp.Internal;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Drawing;

public class XImage : IDisposable
{
	private XImageState _xImageState;

	private bool _disposed;

	private const decimal FactorDPM72 = 2834.6456692913385826771653543m;

	private const decimal FactorDPM = 39.370078740157480314960629921m;

	private bool _interpolate = true;

	private XImageFormat _format;

	private XGraphics _associatedGraphics;

	internal ImportedImage _importedImage;

	internal Image _gdiImage;

	internal string _path;

	internal Stream _stream;

	internal PdfImageTable.ImageSelector _selector;

	internal XImageState XImageState
	{
		get
		{
			return _xImageState;
		}
		set
		{
			_xImageState = value;
		}
	}

	[Obsolete("Use either PixelWidth or PointWidth. Temporarily obsolete because of rearrangements for WPF. Currently same as PixelWidth, but will become PointWidth in future releases of PDFsharp.")]
	public virtual double Width
	{
		get
		{
			if (_importedImage == null)
			{
				try
				{
					Lock.EnterGdiPlus();
					return _gdiImage.Width;
				}
				finally
				{
					Lock.ExitGdiPlus();
				}
			}
			return _importedImage.Information.Width;
		}
	}

	[Obsolete("Use either PixelHeight or PointHeight. Temporarily obsolete because of rearrangements for WPF. Currently same as PixelHeight, but will become PointHeight in future releases of PDFsharp.")]
	public virtual double Height
	{
		get
		{
			if (_importedImage == null)
			{
				try
				{
					Lock.EnterGdiPlus();
					return _gdiImage.Height;
				}
				finally
				{
					Lock.ExitGdiPlus();
				}
			}
			return _importedImage.Information.Height;
		}
	}

	public virtual double PointWidth
	{
		get
		{
			if (_importedImage != null)
			{
				if (_importedImage.Information.HorizontalDPM > 0m)
				{
					return (double)((decimal)_importedImage.Information.Width * 2834.6456692913385826771653543m / _importedImage.Information.HorizontalDPM);
				}
				if (_importedImage.Information.HorizontalDPI > 0m)
				{
					return (double)((decimal)(_importedImage.Information.Width * 72) / _importedImage.Information.HorizontalDPI);
				}
				return _importedImage.Information.Width;
			}
			try
			{
				Lock.EnterGdiPlus();
				return (float)(_gdiImage.Width * 72) / _gdiImage.HorizontalResolution;
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
			if (_importedImage != null)
			{
				if (_importedImage.Information.VerticalDPM > 0m)
				{
					return (double)((decimal)_importedImage.Information.Height * 2834.6456692913385826771653543m / _importedImage.Information.VerticalDPM);
				}
				if (_importedImage.Information.VerticalDPI > 0m)
				{
					return (double)((decimal)(_importedImage.Information.Height * 72) / _importedImage.Information.VerticalDPI);
				}
				return _importedImage.Information.Width;
			}
			try
			{
				Lock.EnterGdiPlus();
				return (float)(_gdiImage.Height * 72) / _gdiImage.HorizontalResolution;
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
			if (_importedImage != null)
			{
				return (int)_importedImage.Information.Width;
			}
			try
			{
				Lock.EnterGdiPlus();
				return _gdiImage.Width;
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
			if (_importedImage != null)
			{
				return (int)_importedImage.Information.Height;
			}
			try
			{
				Lock.EnterGdiPlus();
				return _gdiImage.Height;
			}
			finally
			{
				Lock.ExitGdiPlus();
			}
		}
	}

	public virtual XSize Size => new XSize(PointWidth, PointHeight);

	public virtual double HorizontalResolution
	{
		get
		{
			if (_importedImage != null)
			{
				if (_importedImage.Information.HorizontalDPI > 0m)
				{
					return (double)_importedImage.Information.HorizontalDPI;
				}
				if (_importedImage.Information.HorizontalDPM > 0m)
				{
					return (double)(_importedImage.Information.HorizontalDPM / 39.370078740157480314960629921m);
				}
				return 72.0;
			}
			try
			{
				Lock.EnterGdiPlus();
				return _gdiImage.HorizontalResolution;
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
			if (_importedImage != null)
			{
				if (_importedImage.Information.VerticalDPI > 0m)
				{
					return (double)_importedImage.Information.VerticalDPI;
				}
				if (_importedImage.Information.VerticalDPM > 0m)
				{
					return (double)(_importedImage.Information.VerticalDPM / 39.370078740157480314960629921m);
				}
				return 72.0;
			}
			try
			{
				Lock.EnterGdiPlus();
				return _gdiImage.VerticalResolution;
			}
			finally
			{
				Lock.ExitGdiPlus();
			}
		}
	}

	public virtual bool Interpolate
	{
		get
		{
			return _interpolate;
		}
		set
		{
			_interpolate = value;
		}
	}

	public XImageFormat Format => _format;

	internal XGraphics AssociatedGraphics
	{
		get
		{
			return _associatedGraphics;
		}
		set
		{
			_associatedGraphics = value;
		}
	}

	protected XImage()
	{
	}

	private XImage(ImportedImage image)
	{
		if (image == null)
		{
			throw new ArgumentNullException("image");
		}
		_importedImage = image;
		Initialize();
	}

	private XImage(string path)
	{
		path = Path.GetFullPath(path);
		if (!File.Exists(path))
		{
			throw new FileNotFoundException(PSSR.FileNotFound(path));
		}
		_path = path;
		try
		{
			Lock.EnterGdiPlus();
			_gdiImage = Image.FromFile(path);
		}
		finally
		{
			Lock.ExitGdiPlus();
		}
		Initialize();
	}

	private XImage(Stream stream)
	{
		_path = "*" + Guid.NewGuid().ToString("B");
		try
		{
			Lock.EnterGdiPlus();
			_gdiImage = Image.FromStream(stream);
		}
		finally
		{
			Lock.ExitGdiPlus();
		}
		_stream = stream;
		Initialize();
	}

	public static XImage FromFile(string path)
	{
		if (PdfReader.TestPdfFile(path) > 0)
		{
			return new XPdfForm(path);
		}
		return new XImage(path);
	}

	public static XImage FromStream(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (PdfReader.TestPdfFile(stream) > 0)
		{
			return new XPdfForm(stream);
		}
		return new XImage(stream);
	}

	internal static XImage FromFile(string path, bool platformIndependent, PdfDocument document)
	{
		if (!platformIndependent)
		{
			return FromFile(path);
		}
		ImageImporter imageImporter = ImageImporter.GetImageImporter();
		ImportedImage importedImage = imageImporter.ImportImage(path, document);
		if (importedImage == null)
		{
			throw new InvalidOperationException("Unsupported image format.");
		}
		XImage xImage = new XImage(importedImage);
		xImage._path = path;
		return xImage;
	}

	internal static XImage FromStream(Stream stream, bool platformIndependent, PdfDocument document)
	{
		if (!platformIndependent)
		{
			return FromStream(stream);
		}
		ImageImporter imageImporter = ImageImporter.GetImageImporter();
		ImportedImage importedImage = imageImporter.ImportImage(stream, document);
		if (importedImage == null)
		{
			throw new InvalidOperationException("Unsupported image format.");
		}
		XImage xImage = new XImage(importedImage);
		xImage._stream = stream;
		return xImage;
	}

	[Obsolete("THHO4THHO Internal test code.")]
	internal static XImage FromImportedImage(ImportedImage image)
	{
		if (image == null)
		{
			throw new ArgumentNullException("image");
		}
		return new XImage(image);
	}

	public static bool ExistsFile(string path)
	{
		if (PdfReader.TestPdfFile(path) > 0)
		{
			return true;
		}
		return File.Exists(path);
	}

	internal void Initialize()
	{
		if (_importedImage != null)
		{
			if (_importedImage is ImportedImageJpeg)
			{
				_format = XImageFormat.Jpeg;
			}
			else
			{
				_format = XImageFormat.Png;
			}
		}
		else if (_gdiImage != null)
		{
			string text;
			try
			{
				Lock.EnterGdiPlus();
				text = _gdiImage.RawFormat.Guid.ToString("B").ToUpper();
			}
			finally
			{
				Lock.ExitGdiPlus();
			}
			switch (text)
			{
			case "{B96B3CAA-0728-11D3-9D7B-0000F81EF32E}":
			case "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}":
			case "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}":
				_format = XImageFormat.Png;
				break;
			case "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}":
				_format = XImageFormat.Jpeg;
				break;
			case "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}":
				_format = XImageFormat.Gif;
				break;
			case "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}":
				_format = XImageFormat.Tiff;
				break;
			case "{B96B3CB5-0728-11D3-9D7B-0000F81EF32E}":
				_format = XImageFormat.Icon;
				break;
			default:
				throw new InvalidOperationException("Unsupported image format.");
			}
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			_disposed = true;
		}
		_importedImage = null;
		if (_gdiImage != null)
		{
			try
			{
				Lock.EnterGdiPlus();
				_gdiImage.Dispose();
				_gdiImage = null;
			}
			finally
			{
				Lock.ExitGdiPlus();
			}
		}
	}

	internal void AssociateWithGraphics(XGraphics gfx)
	{
		if (_associatedGraphics != null)
		{
			throw new InvalidOperationException("XImage already associated with XGraphics.");
		}
		_associatedGraphics = null;
	}

	internal void DisassociateWithGraphics()
	{
		if (_associatedGraphics == null)
		{
			throw new InvalidOperationException("XImage not associated with XGraphics.");
		}
		_associatedGraphics.DisassociateImage();
		Debug.Assert(_associatedGraphics == null);
	}

	internal void DisassociateWithGraphics(XGraphics gfx)
	{
		if (_associatedGraphics != gfx)
		{
			throw new InvalidOperationException("XImage not associated with XGraphics.");
		}
		_associatedGraphics = null;
	}
}
