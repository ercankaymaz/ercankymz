using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.Export;

public sealed class HOcrTextExporter : ITextExporter
{
	private const string XmlHeader = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\"\n\t\"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n";

	private const string Hocrjs = "<script src='https://unpkg.com/hocrjs'></script>\n";

	private readonly IPageSegmenter pageSegmenter;

	private readonly IWordExtractor wordExtractor;

	private readonly Func<string, string> invalidCharacterHandler;

	private readonly double scale;

	private readonly string indentChar;

	private int pageCount;

	private int areaCount;

	private int lineCount;

	private int wordCount;

	private int pathCount;

	private int paraCount;

	private int imageCount;

	public InvalidCharStrategy InvalidCharStrategy { get; }

	public HOcrTextExporter(IWordExtractor wordExtractor, IPageSegmenter pageSegmenter, double scale, string indentChar, Func<string, string> invalidCharacterHandler)
		: this(wordExtractor, pageSegmenter, scale, indentChar, InvalidCharStrategy.Custom, invalidCharacterHandler)
	{
	}

	public HOcrTextExporter(IWordExtractor wordExtractor, IPageSegmenter pageSegmenter, double scale = 1.0, string indentChar = "\t", InvalidCharStrategy invalidCharacterStrategy = InvalidCharStrategy.DoNotCheck)
		: this(wordExtractor, pageSegmenter, scale, indentChar, invalidCharacterStrategy, null)
	{
	}

	private HOcrTextExporter(IWordExtractor wordExtractor, IPageSegmenter pageSegmenter, double scale, string indentChar, InvalidCharStrategy invalidCharacterStrategy, Func<string, string> invalidCharacterHandler)
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

	public string Get(PdfDocument document, bool includePaths = false, bool useHocrjs = false)
	{
		string text = GetHead() + indentChar + "<body>\n";
		for (int i = 0; i < document.NumberOfPages; i++)
		{
			Page page = document.GetPage(i + 1);
			text = text + GetCode(page, includePaths) + "\n";
		}
		if (useHocrjs)
		{
			text = text + indentChar + indentChar + "<script src='https://unpkg.com/hocrjs'></script>\n";
		}
		text = text + indentChar + "</body>";
		return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\"\n\t\"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n" + AddHtmlHeader(text);
	}

	public string Get(Page page)
	{
		return Get(page, false, "unknown", false);
	}

	public string Get(Page page, bool includePaths = false, string imageName = "unknown", bool useHocrjs = false)
	{
		string text = GetHead() + indentChar + "<body>\n";
		text = text + GetCode(page, includePaths, imageName) + "\n";
		if (useHocrjs)
		{
			text = text + indentChar + indentChar + "<script src='https://unpkg.com/hocrjs'></script>\n";
		}
		text = text + indentChar + "</body>";
		return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\"\n\t\"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n" + AddHtmlHeader(text);
	}

	private string GetHead()
	{
		return indentChar + "<head>\n" + indentChar + indentChar + "<title></title>\n" + indentChar + indentChar + "<meta http-equiv='Content-Type' content='text/html;charset=utf-8' />\n" + indentChar + indentChar + "<meta name='ocr-system' content='" + pageSegmenter.GetType().Name + "|" + wordExtractor.GetType().Name + "' />\n" + indentChar + indentChar + "<meta name='ocr-capabilities' content='ocr_page ocr_carea ocr_par ocr_line ocrx_word ocr_linedrawing' />\n" + indentChar + "</head>\n";
	}

	private string AddHtmlHeader(string content)
	{
		return "<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"en\" lang=\"en\">\n" + content + "\n</html>";
	}

	private string GetIndent(int level)
	{
		string text = "";
		for (int i = 0; i < level; i++)
		{
			text += indentChar;
		}
		return text;
	}

	private string GetCode(Page page, bool includePaths, string imageName = "unknown")
	{
		pageCount++;
		int num = 2;
		string text = GetIndent(num) + "<div class='ocr_page' id='page_" + page.Number + "' title='image \"" + imageName + "\"; bbox 0 0 " + (int)Math.Round(page.Width * scale) + " " + (int)Math.Round(page.Height * scale) + "; ppageno " + (page.Number - 1) + "'>";
		if (includePaths)
		{
			foreach (PdfPath path in page.Paths)
			{
				text = text + "\n" + GetCode(path, page.Height, subPaths: true, num + 1);
			}
		}
		foreach (IPdfImage image in page.GetImages())
		{
			text = text + "\n" + GetCode(image, page.Height, num + 1);
		}
		IEnumerable<Word> words = page.GetWords(wordExtractor);
		if (words.Any())
		{
			foreach (TextBlock block in pageSegmenter.GetBlocks(words))
			{
				text = text + "\n" + GetCodeArea(block, page.Height, num + 1);
			}
		}
		return text + "\n" + GetIndent(num) + "</div>";
	}

	private string GetCode(PdfPath path, double pageHeight, bool subPaths, int level)
	{
		if (path == null)
		{
			return string.Empty;
		}
		string text = string.Empty;
		if (subPaths)
		{
			PdfRectangle? boundingRectangle = path.GetBoundingRectangle();
			if (boundingRectangle.HasValue)
			{
				areaCount++;
				text = text + GetIndent(level) + "<div class='ocr_carea' id='block_" + pageCount + "_" + areaCount + "' title='" + GetCode(boundingRectangle.Value, pageHeight) + "'>\n";
				foreach (PdfSubpath item in path)
				{
					PdfRectangle? boundingRectangle2 = item.GetBoundingRectangle();
					if (boundingRectangle2.HasValue)
					{
						pathCount++;
						text = text + GetIndent(level + 1) + "<span class='ocr_linedrawing' id='drawing_" + pageCount + "_" + pathCount + "' title='" + GetCode(boundingRectangle2.Value, pageHeight) + "' />\n";
					}
				}
				text = text + GetIndent(level) + "</div>";
			}
		}
		else
		{
			PdfRectangle? boundingRectangle3 = path.GetBoundingRectangle();
			if (boundingRectangle3.HasValue)
			{
				pathCount++;
				text = text + GetIndent(level) + "<span class='ocr_linedrawing' id='drawing_" + pageCount + "_" + pathCount + "' title='" + GetCode(boundingRectangle3.Value, pageHeight) + "' />";
			}
		}
		return text;
	}

	private string GetCode(IPdfImage pdfImage, double pageHeight, int level)
	{
		imageCount++;
		PdfRectangle bounds = pdfImage.Bounds;
		return GetIndent(level) + "<span class='ocr_image' id='image_" + pageCount + "_" + imageCount + "' title='" + GetCode(bounds, pageHeight) + "' />";
	}

	private string GetCodeArea(TextBlock block, double pageHeight, int level)
	{
		areaCount++;
		return string.Concat(string.Concat(GetIndent(level) + "<div class='ocr_carea' id='block_" + pageCount + "_" + areaCount + "' title='" + GetCode(block.BoundingBox, pageHeight) + "'>", GetCodeParagraph(block, pageHeight, level + 1)), "\n", GetIndent(level), "</div>");
	}

	private string GetCodeParagraph(TextBlock block, double pageHeight, int level)
	{
		paraCount++;
		string text = "\n" + GetIndent(level) + "<p class='ocr_par' id='par_" + pageCount + "_" + paraCount + "' title='" + GetCode(block.BoundingBox, pageHeight) + "'>";
		foreach (TextLine textLine in block.TextLines)
		{
			text = text + "\n" + GetCode(textLine, pageHeight, level + 1);
		}
		return text + "\n" + GetIndent(level) + "</p>";
	}

	private string GetCode(TextLine line, double pageHeight, int level)
	{
		lineCount++;
		double num = 0.0;
		double y = line.Words[0].Letters[0].StartBaseLine.Y;
		y = line.BoundingBox.Bottom - y;
		string text = GetIndent(level) + "<span class='ocr_line' id='line_" + pageCount + "_" + lineCount + "' title='" + GetCode(line.BoundingBox, pageHeight) + "; baseline " + num + " 0'>";
		foreach (Word word in line.Words)
		{
			text = text + "\n" + GetCode(word, pageHeight, level + 1);
		}
		return text + "\n" + GetIndent(level) + "</span>";
	}

	private string GetCode(Word word, double pageHeight, int level)
	{
		wordCount++;
		string text = GetIndent(level) + "<span class='ocrx_word' id='word_" + pageCount + "_" + wordCount + "' title='" + GetCode(word.BoundingBox, pageHeight) + "; x_wconf " + GetConfidence(word);
		text = text + "; x_font " + word.FontName;
		if (word.Letters.Count > 0 && word.Letters[0].FontSize != 1.0)
		{
			text = text + "; x_fsize " + word.Letters[0].FontSize;
		}
		text += "'";
		return text + ">" + invalidCharacterHandler(word.Text) + "</span> ";
	}

	private int GetConfidence(Word word)
	{
		return 100;
	}

	private string GetCode(PdfRectangle rectangle, double pageHeight)
	{
		int num = (int)Math.Round(rectangle.Left * scale);
		int num2 = (int)Math.Round((pageHeight - rectangle.Top) * scale);
		int num3 = (int)Math.Round(rectangle.Right * scale);
		int num4 = (int)Math.Round((pageHeight - rectangle.Bottom) * scale);
		return "bbox " + ((num > 0) ? num : 0) + " " + ((num2 > 0) ? num2 : 0) + " " + ((num3 > 0) ? num3 : 0) + " " + ((num4 > 0) ? num4 : 0);
	}
}
