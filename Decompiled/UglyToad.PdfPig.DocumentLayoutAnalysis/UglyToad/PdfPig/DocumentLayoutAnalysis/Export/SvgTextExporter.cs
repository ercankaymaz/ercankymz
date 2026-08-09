using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Graphics.Core;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.Export;

public sealed class SvgTextExporter : ITextExporter
{
	private readonly Func<string, string> invalidCharacterHandler;

	private static readonly Dictionary<string, string> Fonts = new Dictionary<string, string> { { "ArialMT", "Arial Rounded MT Bold" } };

	public int Rounding { get; } = 4;

	public InvalidCharStrategy InvalidCharStrategy { get; }

	public SvgTextExporter(Func<string, string> invalidCharacterHandler)
		: this(InvalidCharStrategy.Custom, invalidCharacterHandler)
	{
	}

	public SvgTextExporter(InvalidCharStrategy invalidCharacterStrategy = InvalidCharStrategy.DoNotCheck)
		: this(invalidCharacterStrategy, null)
	{
	}

	private SvgTextExporter(InvalidCharStrategy invalidCharacterStrategy, Func<string, string> invalidCharacterHandler)
	{
		InvalidCharStrategy = invalidCharacterStrategy;
		if (invalidCharacterHandler == null)
		{
			this.invalidCharacterHandler = TextExporterHelper.GetXmlInvalidCharHandler(InvalidCharStrategy);
		}
		else
		{
			this.invalidCharacterHandler = invalidCharacterHandler;
		}
	}

	public string Get(Page page)
	{
		StringBuilder stringBuilder = new StringBuilder($"<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width='{Math.Round(page.Width, Rounding)}' height='{Math.Round(page.Height, Rounding)}'>\n<g transform=\"scale(1, 1) translate(0, 0)\">\n");
		foreach (PdfPath path in page.Paths)
		{
			if (!path.IsClipping)
			{
				stringBuilder.AppendLine(PathToSvg(path, page.Height));
			}
		}
		XmlDocument doc = new XmlDocument();
		foreach (Letter letter in page.Letters)
		{
			stringBuilder.Append(LetterToSvg(letter, page.Height, doc));
		}
		stringBuilder.Append("</g></svg>");
		return stringBuilder.ToString();
	}

	private string LetterToSvg(Letter l, double height, XmlDocument doc)
	{
		string style;
		string weight;
		string fontFamily = GetFontFamily(l.FontName, out style, out weight);
		string text = "";
		if (l.GlyphRectangle.Rotation != 0.0)
		{
			text = $" transform='rotate({Math.Round(0.0 - l.GlyphRectangle.Rotation, Rounding)} {Math.Round(l.GlyphRectangle.BottomLeft.X, Rounding)},{Math.Round(height - l.GlyphRectangle.TopLeft.Y, Rounding)})'";
		}
		string text2 = ((l.FontSize != 1.0) ? $"font-size='{l.FontSize:0}'" : $"style='font-size:{Math.Round(l.GlyphRectangle.Height, 2)}px'");
		string text3 = XmlEscape(l, doc);
		double num = Math.Round(l.StartBaseLine.X, Rounding);
		double num2 = Math.Round(height - l.StartBaseLine.Y, Rounding);
		return $"<text x='{num}' y='{num2}'{text} font-family='{fontFamily}' font-style='{style}' font-weight='{weight}' {text2} fill='{ColorToSvg(l.Color)}'>{text3}</text>" + Environment.NewLine;
	}

	private static string GetFontFamily(string fontName, out string style, out string weight)
	{
		style = "normal";
		weight = "normal";
		if (fontName.Contains('+') && fontName.Length > 7 && fontName[6] == '+')
		{
			string[] array = fontName.Split('+');
			if (array[0].All(char.IsUpper))
			{
				fontName = array[1];
			}
		}
		if (fontName.Contains('-'))
		{
			string[] array2 = fontName.Split('-');
			fontName = array2[0];
			for (int i = 1; i < array2.Length; i++)
			{
				string text = array2[i].ToLowerInvariant();
				if (text.Contains("light"))
				{
					weight = "lighter";
				}
				else if (text.Contains("bolder"))
				{
					weight = "bolder";
				}
				else if (text.Contains("bold"))
				{
					weight = "bold";
				}
				if (text.Contains("italic"))
				{
					style = "italic";
				}
				else if (text.Contains("oblique"))
				{
					style = "oblique";
				}
			}
		}
		if (Fonts.ContainsKey(fontName))
		{
			fontName = Fonts[fontName];
		}
		return fontName;
	}

	private string XmlEscape(Letter letter, XmlDocument doc)
	{
		XmlElement xmlElement = doc.CreateElement("root");
		xmlElement.InnerText = invalidCharacterHandler(letter.Value);
		return xmlElement.InnerXml;
	}

	private static string ColorToSvg(IColor color)
	{
		if (color == null)
		{
			return string.Empty;
		}
		var (num, num2, num3) = color.ToRGBValues();
		return $"rgb({Convert.ToByte(num * 255.0)},{Convert.ToByte(num2 * 255.0)},{Convert.ToByte(num3 * 255.0)})";
	}

	private static string PathToSvg(PdfPath p, double height)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (PdfSubpath item in p)
		{
			foreach (PdfSubpath.IPathCommand command in item.Commands)
			{
				command.WriteSvg(stringBuilder, height);
			}
		}
		if (stringBuilder.Length == 0)
		{
			return string.Empty;
		}
		if (stringBuilder[stringBuilder.Length - 1] == ' ')
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
		}
		string text = stringBuilder.ToString();
		string text2 = "";
		string text3 = "";
		string text4 = "";
		string text5 = " stroke='none'";
		string text6 = "";
		if (p.IsStroked)
		{
			text5 = " stroke='" + ColorToSvg(p.StrokeColor) + "'";
			text6 = $" stroke-width='{p.LineWidth}'";
			if (p.LineDashPattern.HasValue && p.LineDashPattern.Value.Array.Count > 0)
			{
				text2 = " stroke-dasharray='" + string.Join(" ", p.LineDashPattern.Value.Array) + "'";
			}
			if (p.LineCapStyle != LineCapStyle.Butt)
			{
				text3 = ((p.LineCapStyle != LineCapStyle.Round) ? " stroke-linecap='square'" : " stroke-linecap='round'");
			}
			if (p.LineJoinStyle != LineJoinStyle.Miter)
			{
				text4 = ((p.LineJoinStyle != LineJoinStyle.Round) ? " stroke-linejoin='bevel'" : " stroke-linejoin='round'");
			}
		}
		string text7 = " fill='none'";
		if (p.IsFilled)
		{
			text7 = " fill='" + ColorToSvg(p.FillColor) + "'";
		}
		return "<path d='" + text + "'" + text7 + text5 + text6 + text2 + text3 + text4 + "></path>";
	}
}
