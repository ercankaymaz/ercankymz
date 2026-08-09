using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.DocumentLayoutAnalysis.Export.PAGE;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;
using UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.Export;

public sealed class PageXmlTextExporter : ITextExporter
{
	private sealed class PageXmlData
	{
		public int LinesCount { get; set; }

		public int WordsCount { get; set; }

		public int GlyphsCount { get; set; }

		public int RegionsCount { get; set; }

		public int GroupOrdersCount { get; set; }

		public List<PageXmlDocument.PageXmlRegionRefIndexed> OrderedRegions { get; }

		public PageXmlData()
		{
			OrderedRegions = new List<PageXmlDocument.PageXmlRegionRefIndexed>();
		}
	}

	private readonly IPageSegmenter pageSegmenter;

	private readonly IWordExtractor wordExtractor;

	private readonly IReadingOrderDetector readingOrderDetector;

	private readonly Func<string, string> invalidCharacterHandler;

	private readonly double scale;

	private readonly string indentChar;

	public InvalidCharStrategy InvalidCharStrategy { get; }

	public PageXmlTextExporter(IWordExtractor wordExtractor, IPageSegmenter pageSegmenter, IReadingOrderDetector readingOrderDetector, double scale, string indentChar, Func<string, string> invalidCharacterHandler)
		: this(wordExtractor, pageSegmenter, readingOrderDetector, scale, indentChar, InvalidCharStrategy.Custom, invalidCharacterHandler)
	{
	}

	public PageXmlTextExporter(IWordExtractor wordExtractor, IPageSegmenter pageSegmenter, IReadingOrderDetector readingOrderDetector = null, double scale = 1.0, string indent = "\t", InvalidCharStrategy invalidCharacterStrategy = InvalidCharStrategy.DoNotCheck)
		: this(wordExtractor, pageSegmenter, readingOrderDetector, scale, indent, invalidCharacterStrategy, null)
	{
	}

	private PageXmlTextExporter(IWordExtractor wordExtractor, IPageSegmenter pageSegmenter, IReadingOrderDetector readingOrderDetector, double scale, string indentChar, InvalidCharStrategy invalidCharacterStrategy, Func<string, string> invalidCharacterHandler)
	{
		this.wordExtractor = wordExtractor;
		this.pageSegmenter = pageSegmenter;
		this.readingOrderDetector = readingOrderDetector;
		this.scale = scale;
		this.indentChar = indentChar ?? string.Empty;
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

	public string Get(PdfDocument document, bool includePaths = false)
	{
		throw new NotImplementedException();
	}

	public string Get(Page page)
	{
		return Get(page, includePaths: false);
	}

	public string Get(Page page, bool includePaths)
	{
		PageXmlData data = new PageXmlData();
		DateTime utcNow = DateTime.UtcNow;
		PageXmlDocument pageXmlDocument = new PageXmlDocument
		{
			Metadata = new PageXmlDocument.PageXmlMetadata
			{
				Created = utcNow,
				LastChange = utcNow,
				Creator = "PdfPig",
				Comments = pageSegmenter.GetType().Name + "|" + wordExtractor.GetType().Name
			},
			PcGtsId = "pc-" + page.GetHashCode()
		};
		pageXmlDocument.Page = ToPageXmlPage(page, data, includePaths);
		return Serialize(pageXmlDocument);
	}

	public static string PointToString(PdfPoint point, double pageWidth, double pageHeight, double scaleToApply = 1.0)
	{
		double num = Math.Round(point.X * scaleToApply);
		double num2 = Math.Round((pageHeight - point.Y) * scaleToApply);
		num = ((num > 1.0) ? num : 1.0);
		num2 = ((num2 > 1.0) ? num2 : 1.0);
		return ((num < pageWidth - 1.0) ? num : (pageWidth - 1.0)).ToString("0") + "," + ((num2 < pageHeight - 1.0) ? num2 : (pageHeight - 1.0)).ToString("0");
	}

	private string ToPoints(IEnumerable<PdfPoint> points, double pageWidth, double pageHeight)
	{
		return string.Join(" ", points.Select((PdfPoint p) => PointToString(p, pageWidth, pageHeight, scale)));
	}

	private string ToPoints(PdfRectangle pdfRectangle, double pageWidth, double pageHeight)
	{
		return ToPoints(new PdfPoint[4] { pdfRectangle.BottomLeft, pdfRectangle.TopLeft, pdfRectangle.TopRight, pdfRectangle.BottomRight }, pageWidth, pageHeight);
	}

	private PageXmlDocument.PageXmlCoords ToCoords(PdfRectangle pdfRectangle, double pageWidth, double pageHeight)
	{
		return new PageXmlDocument.PageXmlCoords
		{
			Points = ToPoints(pdfRectangle, pageWidth, pageHeight)
		};
	}

	private string ToRgbEncoded(IColor color)
	{
		(double r, double g, double b) tuple = color.ToRGBValues();
		double item = tuple.r;
		double item2 = tuple.g;
		double item3 = tuple.b;
		byte num = Convert.ToByte(255.0 * item);
		int num2 = 256 * Convert.ToByte(255.0 * item2);
		int num3 = 65536 * Convert.ToByte(255.0 * item3);
		return (num + num2 + num3).ToString();
	}

	private PageXmlDocument.PageXmlPage ToPageXmlPage(Page page, PageXmlData data, bool includePaths)
	{
		PageXmlDocument.PageXmlPage pageXmlPage = new PageXmlDocument.PageXmlPage
		{
			ImageFilename = "unknown",
			ImageHeight = (int)Math.Round(page.Height * scale),
			ImageWidth = (int)Math.Round(page.Width * scale)
		};
		List<PageXmlDocument.PageXmlRegion> list = new List<PageXmlDocument.PageXmlRegion>();
		List<Word> list2 = page.GetWords(wordExtractor).ToList();
		if (list2.Count > 0)
		{
			IReadOnlyList<TextBlock> readOnlyList = pageSegmenter.GetBlocks(list2);
			if (readingOrderDetector != null)
			{
				readOnlyList = readingOrderDetector.Get(readOnlyList).ToList();
			}
			list.AddRange(readOnlyList.Select((TextBlock b) => ToPageXmlTextRegion(b, data, page.Width, page.Height)));
			if (data.OrderedRegions.Count > 0)
			{
				data.GroupOrdersCount++;
				PageXmlDocument.PageXmlReadingOrder pageXmlReadingOrder = new PageXmlDocument.PageXmlReadingOrder();
				PageXmlDocument.PageXmlOrderedGroup pageXmlOrderedGroup = new PageXmlDocument.PageXmlOrderedGroup();
				object[] items = data.OrderedRegions.ToArray();
				pageXmlOrderedGroup.Items = items;
				pageXmlOrderedGroup.Id = "g" + data.GroupOrdersCount;
				pageXmlReadingOrder.Item = pageXmlOrderedGroup;
				pageXmlPage.ReadingOrder = pageXmlReadingOrder;
			}
		}
		List<IPdfImage> list3 = page.GetImages().ToList();
		if (list3.Count > 0)
		{
			list.AddRange(list3.Select((IPdfImage i) => ToPageXmlImageRegion(i, data, page.Width, page.Height)));
		}
		if (includePaths)
		{
			foreach (PdfPath path in page.Paths)
			{
				PageXmlDocument.PageXmlLineDrawingRegion pageXmlLineDrawingRegion = ToPageXmlLineDrawingRegion(path, data, page.Width, page.Height);
				if (pageXmlLineDrawingRegion != null)
				{
					list.Add(pageXmlLineDrawingRegion);
				}
			}
		}
		pageXmlPage.Items = list.ToArray();
		return pageXmlPage;
	}

	private PageXmlDocument.PageXmlLineDrawingRegion ToPageXmlLineDrawingRegion(PdfPath pdfPath, PageXmlData data, double pageWidth, double pageHeight)
	{
		PdfRectangle? boundingRectangle = pdfPath.GetBoundingRectangle();
		if (boundingRectangle.HasValue)
		{
			data.RegionsCount++;
			return new PageXmlDocument.PageXmlLineDrawingRegion
			{
				Coords = ToCoords(boundingRectangle.Value, pageWidth, pageHeight),
				Id = "r" + data.RegionsCount
			};
		}
		return null;
	}

	private PageXmlDocument.PageXmlImageRegion ToPageXmlImageRegion(IPdfImage pdfImage, PageXmlData data, double pageWidth, double pageHeight)
	{
		data.RegionsCount++;
		PdfRectangle bounds = pdfImage.Bounds;
		return new PageXmlDocument.PageXmlImageRegion
		{
			Coords = ToCoords(bounds, pageWidth, pageHeight),
			Id = "r" + data.RegionsCount
		};
	}

	private PageXmlDocument.PageXmlTextRegion ToPageXmlTextRegion(TextBlock textBlock, PageXmlData data, double pageWidth, double pageHeight)
	{
		data.RegionsCount++;
		string text = "r" + data.RegionsCount;
		if (readingOrderDetector != null && textBlock.ReadingOrder > -1)
		{
			data.OrderedRegions.Add(new PageXmlDocument.PageXmlRegionRefIndexed
			{
				RegionRef = text,
				Index = textBlock.ReadingOrder
			});
		}
		PageXmlDocument.PageXmlTextRegion pageXmlTextRegion = new PageXmlDocument.PageXmlTextRegion();
		pageXmlTextRegion.Coords = ToCoords(textBlock.BoundingBox, pageWidth, pageHeight);
		pageXmlTextRegion.Type = PageXmlDocument.PageXmlTextSimpleType.Paragraph;
		pageXmlTextRegion.TextLines = textBlock.TextLines.Select((TextLine l) => ToPageXmlTextLine(l, data, pageWidth, pageHeight)).ToArray();
		pageXmlTextRegion.TextEquivs = new PageXmlDocument.PageXmlTextEquiv[1]
		{
			new PageXmlDocument.PageXmlTextEquiv
			{
				Unicode = invalidCharacterHandler(textBlock.Text)
			}
		};
		pageXmlTextRegion.Id = text;
		return pageXmlTextRegion;
	}

	private PageXmlDocument.PageXmlTextLine ToPageXmlTextLine(TextLine textLine, PageXmlData data, double pageWidth, double pageHeight)
	{
		data.LinesCount++;
		PageXmlDocument.PageXmlTextLine pageXmlTextLine = new PageXmlDocument.PageXmlTextLine();
		pageXmlTextLine.Coords = ToCoords(textLine.BoundingBox, pageWidth, pageHeight);
		pageXmlTextLine.Production = PageXmlDocument.PageXmlProductionSimpleType.Printed;
		pageXmlTextLine.Words = textLine.Words.Select((Word w) => ToPageXmlWord(w, data, pageWidth, pageHeight)).ToArray();
		pageXmlTextLine.TextEquivs = new PageXmlDocument.PageXmlTextEquiv[1]
		{
			new PageXmlDocument.PageXmlTextEquiv
			{
				Unicode = invalidCharacterHandler(textLine.Text)
			}
		};
		pageXmlTextLine.Id = "l" + data.LinesCount;
		return pageXmlTextLine;
	}

	private PageXmlDocument.PageXmlWord ToPageXmlWord(Word word, PageXmlData data, double pageWidth, double pageHeight)
	{
		data.WordsCount++;
		PageXmlDocument.PageXmlWord pageXmlWord = new PageXmlDocument.PageXmlWord();
		pageXmlWord.Coords = ToCoords(word.BoundingBox, pageWidth, pageHeight);
		pageXmlWord.Glyphs = word.Letters.Select((Letter l) => ToPageXmlGlyph(l, data, pageWidth, pageHeight)).ToArray();
		pageXmlWord.TextEquivs = new PageXmlDocument.PageXmlTextEquiv[1]
		{
			new PageXmlDocument.PageXmlTextEquiv
			{
				Unicode = invalidCharacterHandler(word.Text)
			}
		};
		pageXmlWord.Id = "w" + data.WordsCount;
		return pageXmlWord;
	}

	private PageXmlDocument.PageXmlGlyph ToPageXmlGlyph(Letter letter, PageXmlData data, double pageWidth, double pageHeight)
	{
		data.GlyphsCount++;
		PageXmlDocument.PageXmlGlyph pageXmlGlyph = new PageXmlDocument.PageXmlGlyph();
		pageXmlGlyph.Coords = ToCoords(letter.GlyphRectangle, pageWidth, pageHeight);
		pageXmlGlyph.Ligature = false;
		pageXmlGlyph.Production = PageXmlDocument.PageXmlProductionSimpleType.Printed;
		pageXmlGlyph.TextStyle = new PageXmlDocument.PageXmlTextStyle
		{
			FontSize = (float)letter.FontSize,
			FontFamily = letter.FontName,
			TextColourRgb = ToRgbEncoded(letter.Color)
		};
		pageXmlGlyph.TextEquivs = new PageXmlDocument.PageXmlTextEquiv[1]
		{
			new PageXmlDocument.PageXmlTextEquiv
			{
				Unicode = invalidCharacterHandler(letter.Value)
			}
		};
		pageXmlGlyph.Id = "c" + data.GlyphsCount;
		return pageXmlGlyph;
	}

	private string Serialize(PageXmlDocument pageXmlDocument)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(PageXmlDocument));
		XmlWriterSettings settings = new XmlWriterSettings
		{
			Encoding = Encoding.UTF8,
			Indent = true,
			IndentChars = indentChar,
			CheckCharacters = (InvalidCharStrategy != InvalidCharStrategy.DoNotCheck)
		};
		using MemoryStream memoryStream = new MemoryStream();
		using XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings);
		xmlSerializer.Serialize(xmlWriter, pageXmlDocument);
		return Encoding.UTF8.GetString(memoryStream.ToArray());
	}

	public static PageXmlDocument Deserialize(string xmlPath)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(PageXmlDocument));
		XmlReaderSettings settings = new XmlReaderSettings
		{
			CheckCharacters = false
		};
		using XmlReader xmlReader = XmlReader.Create(xmlPath, settings);
		return (PageXmlDocument)xmlSerializer.Deserialize(xmlReader);
	}
}
