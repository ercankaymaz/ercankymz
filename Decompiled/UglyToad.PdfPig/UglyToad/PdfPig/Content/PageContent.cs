using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.XObjects;

namespace UglyToad.PdfPig.Content;

internal class PageContent
{
	private readonly IReadOnlyList<Union<XObjectContentRecord, InlineImage>> images;

	private readonly IReadOnlyList<MarkedContentElement> markedContents;

	private readonly IPdfTokenScanner pdfScanner;

	private readonly ILookupFilterProvider filterProvider;

	private readonly IResourceStore resourceStore;

	internal IReadOnlyList<IGraphicsStateOperation> GraphicsStateOperations { get; }

	public IReadOnlyList<Letter> Letters { get; }

	public IReadOnlyList<PdfPath> Paths { get; }

	public int NumberOfImages => images.Count;

	internal PageContent(IReadOnlyList<IGraphicsStateOperation> graphicsStateOperations, IReadOnlyList<Letter> letters, IReadOnlyList<PdfPath> paths, IReadOnlyList<Union<XObjectContentRecord, InlineImage>> images, IReadOnlyList<MarkedContentElement> markedContents, IPdfTokenScanner pdfScanner, ILookupFilterProvider filterProvider, IResourceStore resourceStore)
	{
		GraphicsStateOperations = graphicsStateOperations;
		Letters = letters;
		Paths = paths;
		this.images = images;
		this.markedContents = markedContents;
		this.pdfScanner = pdfScanner ?? throw new ArgumentNullException("pdfScanner");
		this.filterProvider = filterProvider ?? throw new ArgumentNullException("filterProvider");
		this.resourceStore = resourceStore ?? throw new ArgumentNullException("resourceStore");
	}

	public IEnumerable<IPdfImage> GetImages()
	{
		foreach (Union<XObjectContentRecord, InlineImage> image in images)
		{
			InlineImage b;
			if (image.TryGetFirst(out var a))
			{
				yield return XObjectFactory.ReadImage(a, pdfScanner, filterProvider, resourceStore);
			}
			else if (image.TryGetSecond(out b))
			{
				yield return b;
			}
		}
	}

	public IReadOnlyList<MarkedContentElement> GetMarkedContents()
	{
		return markedContents;
	}
}
