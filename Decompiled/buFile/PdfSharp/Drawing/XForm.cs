#define DEBUG
using System;
using System.Diagnostics;
using PdfSharp.Drawing.Pdf;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Drawing;

public class XForm : XImage, IContentStream
{
	internal enum FormState
	{
		NotATemplate,
		Created,
		UnderConstruction,
		Finished
	}

	internal XGraphics Gfx;

	private PdfDocument _document;

	internal FormState _formState;

	private XRect _viewBox;

	private XRect _boundingBox;

	internal XMatrix _transform;

	internal PdfFormXObject _pdfForm;

	internal XGraphicsPdfRenderer PdfRenderer;

	internal PdfDocument Owner => _document;

	internal PdfColorMode ColorMode
	{
		get
		{
			if (_document == null)
			{
				return PdfColorMode.Undefined;
			}
			return _document.Options.ColorMode;
		}
	}

	internal bool IsTemplate => _formState != FormState.NotATemplate;

	[Obsolete("Use either PixelWidth or PointWidth. Temporarily obsolete because of rearrangements for WPF. Currently same as PixelWidth, but will become PointWidth in future releases of PDFsharp.")]
	public override double Width => _viewBox.Width;

	[Obsolete("Use either PixelHeight or PointHeight. Temporarily obsolete because of rearrangements for WPF. Currently same as PixelHeight, but will become PointHeight in future releases of PDFsharp.")]
	public override double Height => _viewBox.Height;

	public override double PointWidth => _viewBox.Width;

	public override double PointHeight => _viewBox.Height;

	public override int PixelWidth => (int)_viewBox.Width;

	public override int PixelHeight => (int)_viewBox.Height;

	public override XSize Size => _viewBox.Size;

	public XRect ViewBox => _viewBox;

	public override double HorizontalResolution => 72.0;

	public override double VerticalResolution => 72.0;

	public XRect BoundingBox
	{
		get
		{
			return _boundingBox;
		}
		set
		{
			_boundingBox = value;
		}
	}

	public virtual XMatrix Transform
	{
		get
		{
			return _transform;
		}
		set
		{
			if (_formState == FormState.Finished)
			{
				throw new InvalidOperationException("After a XPdfForm was once drawn it must not be modified.");
			}
			_transform = value;
		}
	}

	internal PdfResources Resources
	{
		get
		{
			Debug.Assert(IsTemplate, "This function is for form templates only.");
			return PdfForm.Resources;
		}
	}

	PdfResources IContentStream.Resources => Resources;

	internal PdfFormXObject PdfForm
	{
		get
		{
			Debug.Assert(IsTemplate, "This function is for form templates only.");
			if (_pdfForm.Reference == null)
			{
				_document._irefTable.Add(_pdfForm);
			}
			return _pdfForm;
		}
	}

	protected XForm()
	{
	}

	public XForm(PdfDocument document, XRect viewBox)
	{
		if (viewBox.Width < 1.0 || viewBox.Height < 1.0)
		{
			throw new ArgumentNullException("viewBox", "The size of the XPdfForm is to small.");
		}
		if (document == null)
		{
			throw new ArgumentNullException("document", "An XPdfForm template must be associated with a document at creation time.");
		}
		_formState = FormState.Created;
		_document = document;
		_pdfForm = new PdfFormXObject(document, this);
		_viewBox = viewBox;
		PdfRectangle rect = new PdfRectangle(viewBox);
		_pdfForm.Elements.SetRectangle("/BBox", rect);
	}

	public XForm(PdfDocument document, XSize size)
		: this(document, new XRect(0.0, 0.0, size.Width, size.Height))
	{
	}

	public XForm(PdfDocument document, XUnit width, XUnit height)
		: this(document, new XRect(0.0, 0.0, width, height))
	{
	}

	public void DrawingFinished()
	{
		if (_formState != FormState.Finished)
		{
			if (_formState == FormState.NotATemplate)
			{
				throw new InvalidOperationException("This object is an imported PDF page and you cannot finish drawing on it because you must not draw on it at all.");
			}
			Finish();
		}
	}

	internal void AssociateGraphics(XGraphics gfx)
	{
		if (_formState == FormState.NotATemplate)
		{
			throw new NotImplementedException("The current version of PDFsharp cannot draw on an imported page.");
		}
		if (_formState == FormState.UnderConstruction)
		{
			throw new InvalidOperationException("An XGraphics object already exists for this form.");
		}
		if (_formState == FormState.Finished)
		{
			throw new InvalidOperationException("After drawing a form it cannot be modified anymore.");
		}
		Debug.Assert(_formState == FormState.Created);
		_formState = FormState.UnderConstruction;
		Gfx = gfx;
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	internal virtual void Finish()
	{
	}

	internal string GetFontName(XFont font, out PdfFont pdfFont)
	{
		Debug.Assert(IsTemplate, "This function is for form templates only.");
		pdfFont = _document.FontTable.GetFont(font);
		Debug.Assert(pdfFont != null);
		return Resources.AddFont(pdfFont);
	}

	string IContentStream.GetFontName(XFont font, out PdfFont pdfFont)
	{
		return GetFontName(font, out pdfFont);
	}

	internal string TryGetFontName(string idName, out PdfFont pdfFont)
	{
		Debug.Assert(IsTemplate, "This function is for form templates only.");
		pdfFont = _document.FontTable.TryGetFont(idName);
		string result = null;
		if (pdfFont != null)
		{
			result = Resources.AddFont(pdfFont);
		}
		return result;
	}

	internal string GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
	{
		Debug.Assert(IsTemplate, "This function is for form templates only.");
		pdfFont = _document.FontTable.GetFont(idName, fontData);
		Debug.Assert(pdfFont != null);
		return Resources.AddFont(pdfFont);
	}

	string IContentStream.GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
	{
		return GetFontName(idName, fontData, out pdfFont);
	}

	internal string GetImageName(XImage image)
	{
		Debug.Assert(IsTemplate, "This function is for form templates only.");
		PdfImage image2 = _document.ImageTable.GetImage(image);
		Debug.Assert(image2 != null);
		return Resources.AddImage(image2);
	}

	string IContentStream.GetImageName(XImage image)
	{
		return GetImageName(image);
	}

	internal string GetFormName(XForm form)
	{
		Debug.Assert(IsTemplate, "This function is for form templates only.");
		PdfFormXObject form2 = _document.FormTable.GetForm(form);
		Debug.Assert(form2 != null);
		return Resources.AddForm(form2);
	}

	string IContentStream.GetFormName(XForm form)
	{
		return GetFormName(form);
	}
}
