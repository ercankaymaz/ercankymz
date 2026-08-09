using System;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Pdf;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.Advanced;

public sealed class PdfShading : PdfDictionary
{
	internal sealed class Keys : KeysBase
	{
		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string ShadingType = "/ShadingType";

		[KeyInfo(KeyType.NameOrArray | KeyType.Required)]
		public const string ColorSpace = "/ColorSpace";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string Background = "/Background";

		[KeyInfo(KeyType.Rectangle | KeyType.Optional)]
		public const string BBox = "/BBox";

		[KeyInfo(KeyType.Boolean | KeyType.Optional)]
		public const string AntiAlias = "/AntiAlias";

		[KeyInfo(KeyType.Array | KeyType.Required)]
		public const string Coords = "/Coords";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string Domain = "/Domain";

		[KeyInfo(KeyType.Function | KeyType.Required)]
		public const string Function = "/Function";

		[KeyInfo(KeyType.Array | KeyType.Optional)]
		public const string Extend = "/Extend";

		private static DictionaryMeta _meta;

		internal static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	public PdfShading(PdfDocument document)
		: base(document)
	{
	}

	internal void SetupFromBrush(XLinearGradientBrush brush, XGraphicsPdfRenderer renderer)
	{
		if (brush == null)
		{
			throw new ArgumentNullException("brush");
		}
		PdfColorMode colorMode = _document.Options.ColorMode;
		XColor xColor = ColorSpaceHelper.EnsureColorMode(colorMode, brush._color1);
		XColor xColor2 = ColorSpaceHelper.EnsureColorMode(colorMode, brush._color2);
		PdfDictionary pdfDictionary = new PdfDictionary();
		base.Elements["/ShadingType"] = new PdfInteger(2);
		if (colorMode != PdfColorMode.Cmyk)
		{
			base.Elements["/ColorSpace"] = new PdfName("/DeviceRGB");
		}
		else
		{
			base.Elements["/ColorSpace"] = new PdfName("/DeviceCMYK");
		}
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		if (brush._useRect)
		{
			XPoint xPoint = renderer.WorldToView(brush._rect.TopLeft);
			XPoint xPoint2 = renderer.WorldToView(brush._rect.BottomRight);
			switch (brush._linearGradientMode)
			{
			case XLinearGradientMode.Horizontal:
				num = xPoint.X;
				num2 = xPoint.Y;
				num3 = xPoint2.X;
				num4 = xPoint.Y;
				break;
			case XLinearGradientMode.Vertical:
				num = xPoint.X;
				num2 = xPoint.Y;
				num3 = xPoint.X;
				num4 = xPoint2.Y;
				break;
			case XLinearGradientMode.ForwardDiagonal:
				num = xPoint.X;
				num2 = xPoint.Y;
				num3 = xPoint2.X;
				num4 = xPoint2.Y;
				break;
			case XLinearGradientMode.BackwardDiagonal:
				num = xPoint2.X;
				num2 = xPoint.Y;
				num3 = xPoint.X;
				num4 = xPoint2.Y;
				break;
			}
		}
		else
		{
			XPoint xPoint3 = renderer.WorldToView(brush._point1);
			XPoint xPoint4 = renderer.WorldToView(brush._point2);
			num = xPoint3.X;
			num2 = xPoint3.Y;
			num3 = xPoint4.X;
			num4 = xPoint4.Y;
		}
		base.Elements["/Coords"] = new PdfLiteral("[{0:0.###} {1:0.###} {2:0.###} {3:0.###}]", num, num2, num3, num4);
		base.Elements["/Function"] = pdfDictionary;
		string value = "[" + PdfEncoders.ToString(xColor, colorMode) + "]";
		string value2 = "[" + PdfEncoders.ToString(xColor2, colorMode) + "]";
		pdfDictionary.Elements["/FunctionType"] = new PdfInteger(2);
		pdfDictionary.Elements["/C0"] = new PdfLiteral(value);
		pdfDictionary.Elements["/C1"] = new PdfLiteral(value2);
		pdfDictionary.Elements["/Domain"] = new PdfLiteral("[0 1]");
		pdfDictionary.Elements["/N"] = new PdfInteger(1);
	}
}
