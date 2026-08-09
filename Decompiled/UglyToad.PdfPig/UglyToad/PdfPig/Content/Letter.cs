using System;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.PdfFonts;

namespace UglyToad.PdfPig.Content;

public class Letter
{
	private readonly IFont? _font;

	public string Value { get; }

	public TextOrientation TextOrientation { get; }

	public PdfPoint Location => StartBaseLine;

	public PdfPoint StartBaseLine { get; }

	public PdfPoint EndBaseLine { get; }

	public double Width { get; }

	public PdfRectangle GlyphRectangle { get; }

	public PdfRectangle GlyphRectangleLoose { get; }

	public double FontSize { get; }

	public string? FontName => FontDetails?.Name;

	public FontDetails FontDetails { get; }

	[Obsolete("Use FontDetails instead.")]
	public FontDetails Font => FontDetails;

	public TextRenderingMode RenderingMode { get; }

	public IColor Color { get; }

	public IColor StrokeColor { get; }

	public IColor FillColor { get; }

	public double PointSize { get; }

	public int TextSequence { get; }

	public Letter(string value, PdfRectangle glyphRectangle, PdfRectangle glyphRectangleLoose, PdfPoint startBaseLine, PdfPoint endBaseLine, double width, double fontSize, IFont font, TextRenderingMode renderingMode, IColor strokeColor, IColor fillColor, double pointSize, int textSequence)
		: this(value, glyphRectangle, glyphRectangleLoose, startBaseLine, endBaseLine, width, fontSize, font.Details, font, renderingMode, strokeColor, fillColor, pointSize, textSequence)
	{
	}

	public Letter(string value, PdfRectangle glyphRectangle, PdfRectangle glyphRectangleLoose, PdfPoint startBaseLine, PdfPoint endBaseLine, double width, double fontSize, FontDetails fontDetails, TextRenderingMode renderingMode, IColor strokeColor, IColor fillColor, double pointSize, int textSequence)
		: this(value, glyphRectangle, glyphRectangleLoose, startBaseLine, endBaseLine, width, fontSize, fontDetails, null, renderingMode, strokeColor, fillColor, pointSize, textSequence)
	{
	}

	private Letter(string value, PdfRectangle glyphRectangle, PdfRectangle glyphRectangleLoose, PdfPoint startBaseLine, PdfPoint endBaseLine, double width, double fontSize, FontDetails fontDetails, IFont? font, TextRenderingMode renderingMode, IColor strokeColor, IColor fillColor, double pointSize, int textSequence)
	{
		Value = value;
		GlyphRectangle = glyphRectangle;
		GlyphRectangleLoose = glyphRectangleLoose;
		StartBaseLine = startBaseLine;
		EndBaseLine = endBaseLine;
		Width = width;
		FontSize = fontSize;
		FontDetails = fontDetails;
		_font = font;
		RenderingMode = renderingMode;
		if (renderingMode == TextRenderingMode.Stroke)
		{
			IColor obj = strokeColor ?? GrayColor.Black;
			IColor color = obj;
			StrokeColor = obj;
			Color = color;
			FillColor = fillColor;
		}
		else
		{
			IColor obj2 = fillColor ?? GrayColor.Black;
			IColor color = obj2;
			FillColor = obj2;
			Color = color;
			StrokeColor = strokeColor;
		}
		PointSize = pointSize;
		TextSequence = textSequence;
		TextOrientation = GetTextOrientation();
	}

	public Letter AsBold()
	{
		return new Letter(Value, GlyphRectangle, GlyphRectangleLoose, StartBaseLine, EndBaseLine, Width, FontSize, FontDetails.AsBold(), _font, RenderingMode, StrokeColor, FillColor, PointSize, TextSequence);
	}

	public IFont? GetFont()
	{
		return _font;
	}

	private TextOrientation GetTextOrientation()
	{
		if (Math.Abs(StartBaseLine.Y - EndBaseLine.Y) < 0.0001)
		{
			if (Math.Abs(StartBaseLine.X - EndBaseLine.X) < 0.0001)
			{
				return GetTextOrientationRot();
			}
			if (StartBaseLine.X > EndBaseLine.X)
			{
				return TextOrientation.Rotate180;
			}
			return TextOrientation.Horizontal;
		}
		if (Math.Abs(StartBaseLine.X - EndBaseLine.X) < 0.0001)
		{
			if (Math.Abs(StartBaseLine.Y - EndBaseLine.Y) < 0.0001)
			{
				return GetTextOrientationRot();
			}
			if (StartBaseLine.Y > EndBaseLine.Y)
			{
				return TextOrientation.Rotate90;
			}
			return TextOrientation.Rotate270;
		}
		return TextOrientation.Other;
	}

	private TextOrientation GetTextOrientationRot()
	{
		double rotation = GlyphRectangle.Rotation;
		if (Math.Abs(rotation % 90.0) >= 0.0001)
		{
			return TextOrientation.Other;
		}
		switch ((int)Math.Round(rotation, MidpointRounding.AwayFromZero))
		{
		case 0:
			return TextOrientation.Horizontal;
		case -90:
			return TextOrientation.Rotate90;
		case -180:
		case 180:
			return TextOrientation.Rotate180;
		case 90:
			return TextOrientation.Rotate270;
		default:
			throw new Exception($"Could not find TextOrientation for rotation '{rotation}'.");
		}
	}

	public override string ToString()
	{
		return $"{Value} {Location} {FontName} {PointSize}";
	}
}
