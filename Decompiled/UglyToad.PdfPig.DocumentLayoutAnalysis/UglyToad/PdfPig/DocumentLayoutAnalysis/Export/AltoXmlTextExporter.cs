using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.DocumentLayoutAnalysis.Export.Alto;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.Export;

public sealed class AltoXmlTextExporter : ITextExporter
{
	private readonly IPageSegmenter pageSegmenter;

	private readonly IWordExtractor wordExtractor;

	private readonly Func<string, string> invalidCharacterHandler;

	private readonly double scale;

	private readonly string indentChar;

	private int pageCount;

	private int pageSpaceCount;

	private int graphicalElementCount;

	private int illustrationCount;

	private int textBlockCount;

	private int textLineCount;

	private int stringCount;

	private int glyphCount;

	public InvalidCharStrategy InvalidCharStrategy { get; }

	public AltoXmlTextExporter(IWordExtractor wordExtractor, IPageSegmenter pageSegmenter, double scale, string indentChar, Func<string, string> invalidCharacterHandler)
		: this(wordExtractor, pageSegmenter, scale, indentChar, InvalidCharStrategy.Custom, invalidCharacterHandler)
	{
	}

	public AltoXmlTextExporter(IWordExtractor wordExtractor, IPageSegmenter pageSegmenter, double scale = 1.0, string indentChar = "\t", InvalidCharStrategy invalidCharacterStrategy = InvalidCharStrategy.DoNotCheck)
		: this(wordExtractor, pageSegmenter, scale, indentChar, invalidCharacterStrategy, null)
	{
	}

	private AltoXmlTextExporter(IWordExtractor wordExtractor, IPageSegmenter pageSegmenter, double scale, string indentChar, InvalidCharStrategy invalidCharacterStrategy, Func<string, string> invalidCharacterHandler)
	{
		this.wordExtractor = wordExtractor;
		this.pageSegmenter = pageSegmenter;
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
		AltoDocument altoDocument = CreateAltoDocument("unknown");
		altoDocument.Layout.Pages = (from x in document.GetPages()
			select ToAltoPage(x, includePaths)).ToArray();
		return Serialize(altoDocument);
	}

	public string Get(Page page)
	{
		return Get(page, includePaths: false);
	}

	public string Get(Page page, bool includePaths)
	{
		AltoDocument altoDocument = CreateAltoDocument("unknown");
		altoDocument.Layout.Pages = new AltoDocument.AltoPage[1] { ToAltoPage(page, includePaths) };
		return Serialize(altoDocument);
	}

	private AltoDocument CreateAltoDocument(string fileName)
	{
		return new AltoDocument
		{
			Layout = new AltoDocument.AltoLayout
			{
				StyleRefs = null
			},
			Description = GetAltoDescription(fileName),
			SchemaVersion = "4"
		};
	}

	private AltoDocument.AltoPage ToAltoPage(Page page, bool includePaths)
	{
		pageCount = page.Number;
		pageSpaceCount++;
		AltoDocument.AltoPage altoPage = new AltoDocument.AltoPage
		{
			Height = (float)Math.Round(page.Height * scale),
			Width = (float)Math.Round(page.Width * scale),
			Accuracy = float.NaN,
			Quality = AltoDocument.AltoQuality.OK,
			QualityDetail = null,
			BottomMargin = null,
			LeftMargin = null,
			RightMargin = null,
			TopMargin = null,
			Pc = float.NaN,
			PhysicalImgNr = page.Number,
			PrintedImgNr = null,
			PageClass = null,
			Position = AltoDocument.AltoPosition.Cover,
			Processing = null,
			ProcessingRefs = null,
			StyleRefs = null,
			PrintSpace = new AltoDocument.AltoPageSpace
			{
				Height = (float)Math.Round(page.Height * scale),
				Width = (float)Math.Round(page.Width * scale),
				VerticalPosition = 0f,
				HorizontalPosition = 0f,
				ComposedBlocks = null,
				GraphicalElements = null,
				Illustrations = null,
				ProcessingRefs = null,
				StyleRefs = null,
				Id = "P" + pageCount + "_PS" + pageSpaceCount.ToString("#00000")
			},
			Id = "P" + pageCount
		};
		IEnumerable<Word> words = page.GetWords(wordExtractor);
		altoPage.PrintSpace.TextBlock = (from b in pageSegmenter.GetBlocks(words)
			select ToAltoTextBlock(b, page.Height)).ToArray();
		altoPage.PrintSpace.Illustrations = (from i in page.GetImages()
			select ToAltoIllustration(i, page.Height)).ToArray();
		if (includePaths)
		{
			altoPage.PrintSpace.GraphicalElements = page.Paths.Select((PdfPath p) => ToAltoGraphicalElement(p, page.Height)).ToArray();
		}
		return altoPage;
	}

	private AltoDocument.AltoGraphicalElement ToAltoGraphicalElement(PdfPath pdfPath, double height)
	{
		graphicalElementCount++;
		PdfRectangle? boundingRectangle = pdfPath.GetBoundingRectangle();
		if (boundingRectangle.HasValue)
		{
			return new AltoDocument.AltoGraphicalElement
			{
				VerticalPosition = (float)Math.Round((height - boundingRectangle.Value.Top) * scale),
				HorizontalPosition = (float)Math.Round(boundingRectangle.Value.Left * scale),
				Height = (float)Math.Round(boundingRectangle.Value.Height * scale),
				Width = (float)Math.Round(boundingRectangle.Value.Width * scale),
				Rotation = 0f,
				StyleRefs = null,
				TagRefs = null,
				Title = null,
				Type = null,
				Id = "P" + pageCount + "_GE" + graphicalElementCount.ToString("#00000")
			};
		}
		return null;
	}

	private AltoDocument.AltoIllustration ToAltoIllustration(IPdfImage pdfImage, double height)
	{
		illustrationCount++;
		PdfRectangle bounds = pdfImage.Bounds;
		return new AltoDocument.AltoIllustration
		{
			VerticalPosition = (float)Math.Round((height - bounds.Top) * scale),
			HorizontalPosition = (float)Math.Round(bounds.Left * scale),
			Height = (float)Math.Round(bounds.Height * scale),
			Width = (float)Math.Round(bounds.Width * scale),
			FileId = "",
			Rotation = 0f,
			Id = "P" + pageCount + "_I" + illustrationCount.ToString("#00000")
		};
	}

	private AltoDocument.AltoTextBlock ToAltoTextBlock(TextBlock textBlock, double height)
	{
		textBlockCount++;
		return new AltoDocument.AltoTextBlock
		{
			VerticalPosition = (float)Math.Round((height - textBlock.BoundingBox.Top) * scale),
			HorizontalPosition = (float)Math.Round(textBlock.BoundingBox.Left * scale),
			Height = (float)Math.Round(textBlock.BoundingBox.Height * scale),
			Width = (float)Math.Round(textBlock.BoundingBox.Width * scale),
			Rotation = 0f,
			TextLines = textBlock.TextLines.Select((TextLine l) => ToAltoTextLine(l, height)).ToArray(),
			StyleRefs = null,
			TagRefs = null,
			Title = null,
			Type = null,
			Id = "P" + pageCount + "_TB" + textBlockCount.ToString("#00000")
		};
	}

	private AltoDocument.AltoTextBlockTextLine ToAltoTextLine(TextLine textLine, double height)
	{
		textLineCount++;
		AltoDocument.AltoString[] strings = textLine.Words.Select((Word w) => ToAltoString(w, height)).ToArray();
		return new AltoDocument.AltoTextBlockTextLine
		{
			VerticalPosition = (float)Math.Round((height - textLine.BoundingBox.Top) * scale),
			HorizontalPosition = (float)Math.Round(textLine.BoundingBox.Left * scale),
			Height = (float)Math.Round(textLine.BoundingBox.Height * scale),
			Width = (float)Math.Round(textLine.BoundingBox.Width * scale),
			BaseLine = float.NaN,
			Strings = strings,
			Language = null,
			StyleRefs = null,
			TagRefs = null,
			Id = "P" + pageCount + "_TL" + textLineCount.ToString("#00000")
		};
	}

	private AltoDocument.AltoString ToAltoString(Word word, double height)
	{
		stringCount++;
		AltoDocument.AltoGlyph[] array = word.Letters.Select((Letter l) => ToAltoGlyph(l, height)).ToArray();
		return new AltoDocument.AltoString
		{
			VerticalPosition = (float)Math.Round((height - word.BoundingBox.Top) * scale),
			HorizontalPosition = (float)Math.Round(word.BoundingBox.Left * scale),
			Height = (float)Math.Round(word.BoundingBox.Height * scale),
			Width = (float)Math.Round(word.BoundingBox.Width * scale),
			Glyph = array,
			Cc = string.Join("", array.Select((AltoDocument.AltoGlyph g) => 9f * (1f - g.Gc))),
			Content = invalidCharacterHandler(word.Text),
			Language = null,
			StyleRefs = null,
			SubsContent = null,
			TagRefs = null,
			Wc = float.NaN,
			Id = "P" + pageCount + "_ST" + stringCount.ToString("#00000")
		};
	}

	private AltoDocument.AltoGlyph ToAltoGlyph(Letter letter, double height)
	{
		glyphCount++;
		AltoDocument.AltoGlyph altoGlyph = new AltoDocument.AltoGlyph();
		altoGlyph.VerticalPosition = (float)Math.Round((height - letter.GlyphRectangle.Top) * scale);
		altoGlyph.HorizontalPosition = (float)Math.Round(letter.GlyphRectangle.Left * scale);
		altoGlyph.Height = (float)Math.Round(letter.GlyphRectangle.Height * scale);
		altoGlyph.Width = (float)Math.Round(letter.GlyphRectangle.Width * scale);
		altoGlyph.Gc = 1f;
		altoGlyph.Content = invalidCharacterHandler(letter.Value);
		altoGlyph.Id = "P" + pageCount + "_ST" + stringCount.ToString("#00000") + "_G" + glyphCount.ToString("#00");
		return altoGlyph;
	}

	private AltoDocument.AltoDescription GetAltoDescription(string fileName)
	{
		AltoDocument.AltoDescriptionProcessing altoDescriptionProcessing = new AltoDocument.AltoDescriptionProcessing
		{
			ProcessingAgency = null,
			ProcessingCategory = AltoDocument.AltoProcessingCategory.Other,
			ProcessingDateTime = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture),
			ProcessingSoftware = new AltoDocument.AltoProcessingSoftware
			{
				SoftwareName = "PdfPig",
				SoftwareCreator = "https://github.com/UglyToad/PdfPig",
				ApplicationDescription = "Read and extract text and other content from PDFs in C# (port of PdfBox)",
				SoftwareVersion = "x.x.xx"
			},
			ProcessingStepDescription = null,
			ProcessingStepSettings = pageSegmenter.GetType().Name + "|" + wordExtractor.GetType().Name,
			Id = "P" + pageCount + "_D1"
		};
		AltoDocument.AltoDocumentIdentifier altoDocumentIdentifier = new AltoDocument.AltoDocumentIdentifier
		{
			DocumentIdentifierLocation = null,
			Value = null
		};
		AltoDocument.AltoFileIdentifier altoFileIdentifier = new AltoDocument.AltoFileIdentifier
		{
			FileIdentifierLocation = null,
			Value = null
		};
		AltoDocument.AltoDescription altoDescription = new AltoDocument.AltoDescription();
		altoDescription.MeasurementUnit = AltoDocument.AltoMeasurementUnit.Pixel;
		altoDescription.Processings = new AltoDocument.AltoDescriptionProcessing[1] { altoDescriptionProcessing };
		altoDescription.SourceImageInformation = new AltoDocument.AltoSourceImageInformation
		{
			DocumentIdentifiers = new AltoDocument.AltoDocumentIdentifier[1] { altoDocumentIdentifier },
			FileIdentifiers = new AltoDocument.AltoFileIdentifier[1] { altoFileIdentifier },
			FileName = fileName
		};
		return altoDescription;
	}

	private string Serialize(AltoDocument altoDocument)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(AltoDocument));
		XmlWriterSettings settings = new XmlWriterSettings
		{
			Encoding = Encoding.UTF8,
			Indent = true,
			IndentChars = indentChar,
			CheckCharacters = (InvalidCharStrategy != InvalidCharStrategy.DoNotCheck)
		};
		using MemoryStream memoryStream = new MemoryStream();
		using XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings);
		xmlSerializer.Serialize(xmlWriter, altoDocument);
		return Encoding.UTF8.GetString(memoryStream.ToArray());
	}

	public static AltoDocument Deserialize(string xmlPath)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(AltoDocument));
		XmlReaderSettings settings = new XmlReaderSettings
		{
			CheckCharacters = false
		};
		using XmlReader xmlReader = XmlReader.Create(xmlPath, settings);
		return (AltoDocument)xmlSerializer.Deserialize(xmlReader);
	}
}
