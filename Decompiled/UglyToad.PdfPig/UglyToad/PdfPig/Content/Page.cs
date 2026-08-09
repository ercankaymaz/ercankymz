using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyToad.PdfPig.Annotations;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Content;

public class Page
{
	[Obsolete("Use methods and properties directly at Page level.")]
	public class Experimental
	{
		private readonly Page page;

		[Obsolete("Use Page.Paths instead.")]
		public IReadOnlyList<PdfPath> Paths => page.Paths;

		internal Experimental(Page page)
		{
			this.page = page;
		}

		[Obsolete("Use Page.GetAnnotations() instead.")]
		public IEnumerable<Annotation> GetAnnotations()
		{
			return page.GetAnnotations();
		}

		[Obsolete("Use Page.GetOptionalContents() instead.")]
		public IReadOnlyDictionary<string, IReadOnlyList<OptionalContentGroupElement>> GetOptionalContents()
		{
			return page.GetOptionalContents();
		}
	}

	internal readonly AnnotationProvider annotationProvider;

	internal readonly IPdfTokenScanner pdfScanner;

	private readonly Lazy<string> textLazy;

	public DictionaryToken Dictionary { get; }

	public int Number { get; }

	public CropBox CropBox { get; }

	public MediaBox MediaBox { get; }

	internal PageContent Content { get; }

	public PageRotationDegrees Rotation { get; }

	public IReadOnlyList<Letter> Letters => Content.Letters;

	public string Text => textLazy.Value;

	public double Width { get; }

	public double Height { get; }

	public PageSize Size { get; }

	public int NumberOfImages => Content.NumberOfImages;

	public IReadOnlyList<IGraphicsStateOperation> Operations => Content.GraphicsStateOperations;

	public IReadOnlyList<PdfPath> Paths => Content?.Paths ?? Array.Empty<PdfPath>();

	[Obsolete("Use methods and properties directly at Page level.")]
	public Experimental ExperimentalAccess { get; }

	internal Page(int number, DictionaryToken dictionary, MediaBox mediaBox, CropBox cropBox, PageRotationDegrees rotation, PageContent content, AnnotationProvider annotationProvider, IPdfTokenScanner pdfScanner)
	{
		if (number <= 0)
		{
			throw new ArgumentOutOfRangeException("number", "Page number cannot be 0 or negative.");
		}
		if (content == null)
		{
			throw new ArgumentNullException("content");
		}
		Dictionary = dictionary ?? throw new ArgumentNullException("dictionary");
		Number = number;
		MediaBox = mediaBox;
		CropBox = cropBox;
		Rotation = rotation;
		Content = content;
		textLazy = new Lazy<string>(() => GetText(Content));
		PdfRectangle rectangle = mediaBox.Bounds.Intersect(cropBox.Bounds) ?? cropBox.Bounds;
		Width = rectangle.Width;
		Height = rectangle.Height;
		Size = rectangle.GetPageSize();
		ExperimentalAccess = new Experimental(this);
		this.annotationProvider = annotationProvider;
		this.pdfScanner = pdfScanner ?? throw new ArgumentNullException("pdfScanner");
	}

	private static string GetText(PageContent content)
	{
		if (content?.Letters == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < content.Letters.Count; i++)
		{
			stringBuilder.Append(content.Letters[i].Value);
		}
		return stringBuilder.ToString();
	}

	public IEnumerable<Word> GetWords()
	{
		return GetWords(DefaultWordExtractor.Instance);
	}

	public IEnumerable<Word> GetWords(IWordExtractor wordExtractor)
	{
		return (wordExtractor ?? DefaultWordExtractor.Instance).GetWords(Letters);
	}

	public IReadOnlyList<Hyperlink> GetHyperlinks()
	{
		return HyperlinkFactory.GetHyperlinks(this, pdfScanner, annotationProvider);
	}

	public IEnumerable<IPdfImage> GetImages()
	{
		return Content.GetImages();
	}

	public IReadOnlyList<MarkedContentElement> GetMarkedContents()
	{
		return Content.GetMarkedContents();
	}

	public IEnumerable<Annotation> GetAnnotations()
	{
		return annotationProvider.GetAnnotations();
	}

	public IReadOnlyDictionary<string, IReadOnlyList<OptionalContentGroupElement>> GetOptionalContents()
	{
		List<OptionalContentGroupElement> mcesOptional = new List<OptionalContentGroupElement>();
		GetOptionalContentsRecursively(Content?.GetMarkedContents(), ref mcesOptional);
		return (from oc in mcesOptional
			group oc by oc.Name).ToDictionary<IGrouping<string, OptionalContentGroupElement>, string, IReadOnlyList<OptionalContentGroupElement>>((Func<IGrouping<string, OptionalContentGroupElement>, string>)((IGrouping<string, OptionalContentGroupElement> g) => g.Key), (Func<IGrouping<string, OptionalContentGroupElement>, IReadOnlyList<OptionalContentGroupElement>>)((IGrouping<string, OptionalContentGroupElement> g) => g.ToList()));
	}

	private void GetOptionalContentsRecursively(IReadOnlyList<MarkedContentElement>? markedContentElements, ref List<OptionalContentGroupElement> mcesOptional)
	{
		if (markedContentElements == null || markedContentElements.Count == 0)
		{
			return;
		}
		foreach (MarkedContentElement markedContentElement in markedContentElements)
		{
			if (markedContentElement.Tag == "OC")
			{
				mcesOptional.Add(new OptionalContentGroupElement(markedContentElement, pdfScanner));
				continue;
			}
			IReadOnlyList<MarkedContentElement> children = markedContentElement.Children;
			if (children != null && children.Count > 0)
			{
				GetOptionalContentsRecursively(markedContentElement.Children, ref mcesOptional);
			}
		}
	}
}
