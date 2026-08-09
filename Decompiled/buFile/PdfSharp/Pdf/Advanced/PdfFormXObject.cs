#define DEBUG
using System;
using System.Diagnostics;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Advanced;

public sealed class PdfFormXObject : PdfXObject, IContentStream
{
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

		[KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof(PdfResources))]
		public const string Resources = "/Resources";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional)]
		public const string Group = "/Group";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	private double _dpiX = 72.0;

	private double _dpiY = 72.0;

	private PdfResources _resources;

	internal double DpiX
	{
		get
		{
			return _dpiX;
		}
		set
		{
			_dpiX = value;
		}
	}

	internal double DpiY
	{
		get
		{
			return _dpiY;
		}
		set
		{
			_dpiY = value;
		}
	}

	public PdfResources Resources
	{
		get
		{
			if (_resources == null)
			{
				_resources = (PdfResources)base.Elements.GetValue("/Resources", VCF.Create);
			}
			return _resources;
		}
	}

	PdfResources IContentStream.Resources => Resources;

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfFormXObject(PdfDocument thisDocument)
		: base(thisDocument)
	{
		base.Elements.SetName("/Type", "/XObject");
		base.Elements.SetName("/Subtype", "/Form");
	}

	internal PdfFormXObject(PdfDocument thisDocument, XForm form)
		: base(thisDocument)
	{
		base.Elements.SetName("/Type", "/XObject");
		base.Elements.SetName("/Subtype", "/Form");
	}

	internal PdfFormXObject(PdfDocument thisDocument, PdfImportedObjectTable importedObjectTable, XPdfForm form)
		: base(thisDocument)
	{
		Debug.Assert(importedObjectTable != null);
		Debug.Assert(thisDocument == importedObjectTable.Owner);
		base.Elements.SetName("/Type", "/XObject");
		base.Elements.SetName("/Subtype", "/Form");
		if (form.IsTemplate)
		{
			Debug.Assert(importedObjectTable == null);
			return;
		}
		PdfPages pages = importedObjectTable.ExternalDocument.Pages;
		if (form.PageNumber < 1 || form.PageNumber > pages.Count)
		{
			PSSR.ImportPageNumberOutOfRange(form.PageNumber, pages.Count, form._path);
		}
		PdfPage pdfPage = pages[form.PageNumber - 1];
		PdfItem pdfItem = pdfPage.Elements["/Resources"];
		if (pdfItem != null)
		{
			PdfObject pdfObject = PdfObject.ImportClosure(importedObjectTable, thisDocument, (!(pdfItem is PdfReference)) ? ((PdfDictionary)pdfItem) : ((PdfReference)pdfItem).Value);
			if (pdfObject.Reference == null)
			{
				thisDocument._irefTable.Add(pdfObject);
			}
			Debug.Assert(pdfObject.Reference != null);
			base.Elements["/Resources"] = pdfObject.Reference;
		}
		PdfRectangle rectangle = pdfPage.Elements.GetRectangle("/MediaBox");
		int integer = pdfPage.Elements.GetInteger("/Rotate");
		if (integer == 0)
		{
			base.Elements["/BBox"] = rectangle;
		}
		else
		{
			base.Elements["/BBox"] = rectangle;
			XMatrix matrix = default(XMatrix);
			double width = rectangle.Width;
			double height = rectangle.Height;
			matrix.RotateAtPrepend(-integer, new XPoint(width / 2.0, height / 2.0));
			if (integer != 180)
			{
				double num = (height - width) / 2.0;
				if (height > width)
				{
					matrix.TranslatePrepend(num, num);
				}
				else
				{
					matrix.TranslatePrepend(0.0 - num, 0.0 - num);
				}
			}
			base.Elements.SetMatrix("/Matrix", matrix);
		}
		PdfContent pdfContent = pdfPage.Contents.CreateSingleContent();
		PdfItem pdfItem2 = pdfContent.Elements["/Filter"];
		if (pdfItem2 != null)
		{
			base.Elements["/Filter"] = pdfItem2.Clone();
		}
		base.Stream = pdfContent.Stream;
		base.Elements.SetInteger("/Length", pdfContent.Stream.Value.Length);
	}

	internal string GetFontName(XFont font, out PdfFont pdfFont)
	{
		pdfFont = _document.FontTable.GetFont(font);
		Debug.Assert(pdfFont != null);
		return Resources.AddFont(pdfFont);
	}

	string IContentStream.GetFontName(XFont font, out PdfFont pdfFont)
	{
		return GetFontName(font, out pdfFont);
	}

	internal string GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
	{
		pdfFont = _document.FontTable.GetFont(idName, fontData);
		Debug.Assert(pdfFont != null);
		return Resources.AddFont(pdfFont);
	}

	string IContentStream.GetFontName(string idName, byte[] fontData, out PdfFont pdfFont)
	{
		return GetFontName(idName, fontData, out pdfFont);
	}

	string IContentStream.GetImageName(XImage image)
	{
		throw new NotImplementedException();
	}

	string IContentStream.GetFormName(XForm form)
	{
		throw new NotImplementedException();
	}
}
