#define DEBUG
using System;
using System.Diagnostics;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Advanced;

public abstract class PdfDictionaryWithContentStream : PdfDictionary, IContentStream
{
	public class Keys : PdfStream.Keys
	{
		[KeyInfo(KeyType.Dictionary | KeyType.Optional, typeof(PdfResources))]
		public const string Resources = "/Resources";
	}

	private PdfResources _resources;

	internal PdfResources Resources
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

	internal string GetImageName(XImage image)
	{
		PdfImage image2 = _document.ImageTable.GetImage(image);
		Debug.Assert(image2 != null);
		return Resources.AddImage(image2);
	}

	string IContentStream.GetImageName(XImage image)
	{
		throw new NotImplementedException();
	}

	internal string GetFormName(XForm form)
	{
		PdfFormXObject form2 = _document.FormTable.GetForm(form);
		Debug.Assert(form2 != null);
		return Resources.AddForm(form2);
	}

	string IContentStream.GetFormName(XForm form)
	{
		throw new NotImplementedException();
	}
}
