using System;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Pdf;

namespace PdfSharp.Pdf.Advanced;

public sealed class PdfShadingPattern : PdfDictionaryWithContentStream
{
	internal new sealed class Keys : PdfDictionaryWithContentStream.Keys
	{
		[KeyInfo(KeyType.Name | KeyType.Required)]
		public const string Type = "/Type";

		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string PatternType = "/PatternType";

		[KeyInfo(KeyType.Dictionary | KeyType.Required)]
		public const string Shading = "/Shading";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string Matrix = "/Matrix";

		[KeyInfo(KeyType.Dictionary | KeyType.Optional)]
		public const string ExtGState = "/ExtGState";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfShadingPattern(PdfDocument document)
		: base(document)
	{
		base.Elements.SetName("/Type", "/Pattern");
		base.Elements["/PatternType"] = new PdfInteger(2);
	}

	internal void SetupFromBrush(XLinearGradientBrush brush, XMatrix matrix, XGraphicsPdfRenderer renderer)
	{
		if (brush == null)
		{
			throw new ArgumentNullException("brush");
		}
		PdfShading pdfShading = new PdfShading(_document);
		pdfShading.SetupFromBrush(brush, renderer);
		base.Elements["/Shading"] = pdfShading;
		base.Elements.SetMatrix("/Matrix", matrix);
	}
}
