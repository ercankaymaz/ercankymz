using System;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.Annotations;

public sealed class PdfLinkAnnotation : PdfAnnotation
{
	private enum LinkType
	{
		None,
		Document,
		Web,
		File
	}

	internal new class Keys : PdfAnnotation.Keys
	{
		[KeyInfo(KeyType.ArrayOrNameOrString | KeyType.Optional)]
		public const string Dest = "/Dest";

		[KeyInfo("1.2", KeyType.Name | KeyType.Optional)]
		public const string H = "/H";

		[KeyInfo("1.3", KeyType.Dictionary | KeyType.Optional)]
		public const string PA = "/PA";

		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	private int _destPage;

	private LinkType _linkType;

	private string _url;

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfLinkAnnotation()
	{
		_linkType = LinkType.None;
		base.Elements.SetName("/Subtype", "/Link");
	}

	public PdfLinkAnnotation(PdfDocument document)
		: base(document)
	{
		_linkType = LinkType.None;
		base.Elements.SetName("/Subtype", "/Link");
	}

	public static PdfLinkAnnotation CreateDocumentLink(PdfRectangle rect, int destinationPage)
	{
		if (destinationPage < 1)
		{
			throw new ArgumentException("Invalid destination page in call to CreateDocumentLink: page number is one-based and must be 1 or higher.", "destinationPage");
		}
		PdfLinkAnnotation pdfLinkAnnotation = new PdfLinkAnnotation();
		pdfLinkAnnotation._linkType = LinkType.Document;
		pdfLinkAnnotation.Rectangle = rect;
		pdfLinkAnnotation._destPage = destinationPage;
		return pdfLinkAnnotation;
	}

	public static PdfLinkAnnotation CreateWebLink(PdfRectangle rect, string url)
	{
		PdfLinkAnnotation pdfLinkAnnotation = new PdfLinkAnnotation();
		pdfLinkAnnotation._linkType = LinkType.Web;
		pdfLinkAnnotation.Rectangle = rect;
		pdfLinkAnnotation._url = url;
		return pdfLinkAnnotation;
	}

	public static PdfLinkAnnotation CreateFileLink(PdfRectangle rect, string fileName)
	{
		PdfLinkAnnotation pdfLinkAnnotation = new PdfLinkAnnotation();
		pdfLinkAnnotation._linkType = LinkType.File;
		pdfLinkAnnotation.Rectangle = rect;
		pdfLinkAnnotation._url = fileName;
		return pdfLinkAnnotation;
	}

	internal override void WriteObject(PdfWriter writer)
	{
		PdfPage pdfPage = null;
		if (base.Elements["/BS"] == null)
		{
			base.Elements["/BS"] = new PdfLiteral("<</Type/Border/W 0>>");
		}
		if (base.Elements["/Border"] == null)
		{
			base.Elements["/Border"] = new PdfLiteral("[0 0 0]");
		}
		switch (_linkType)
		{
		case LinkType.Document:
		{
			int num = _destPage;
			if (num > Owner.PageCount)
			{
				num = Owner.PageCount;
			}
			num--;
			pdfPage = Owner.Pages[num];
			base.Elements["/Dest"] = new PdfLiteral("[{0} 0 R/XYZ null null 0]", pdfPage.ObjectNumber);
			break;
		}
		case LinkType.Web:
			base.Elements["/A"] = new PdfLiteral("<</S/URI/URI{0}>>", PdfEncoders.ToStringLiteral(_url, PdfStringEncoding.WinAnsiEncoding, writer.SecurityHandler));
			break;
		case LinkType.File:
			base.Elements["/A"] = new PdfLiteral("<</Type/Action/S/Launch/F<</Type/Filespec/F{0}>> >>", PdfEncoders.ToStringLiteral(_url, PdfStringEncoding.WinAnsiEncoding, writer.SecurityHandler));
			break;
		}
		base.WriteObject(writer);
	}
}
