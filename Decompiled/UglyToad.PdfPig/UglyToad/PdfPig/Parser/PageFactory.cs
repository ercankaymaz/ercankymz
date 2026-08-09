using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Annotations;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Outline.Destinations;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Parser;

internal class PageFactory : BasePageFactory<Page>
{
	public PageFactory(IPdfTokenScanner pdfScanner, IResourceStore resourceStore, ILookupFilterProvider filterProvider, IPageContentParser pageContentParser, ParsingOptions parsingOptions)
		: base(pdfScanner, resourceStore, filterProvider, pageContentParser, parsingOptions)
	{
	}

	protected override Page ProcessPage(int pageNumber, DictionaryToken dictionary, NamedDestinations namedDestinations, MediaBox mediaBox, CropBox cropBox, UserSpaceUnit userSpaceUnit, PageRotationDegrees rotation, TransformationMatrix initialMatrix, IReadOnlyList<IGraphicsStateOperation> operations)
	{
		AnnotationProvider annotationProvider = new AnnotationProvider(PdfScanner, dictionary, initialMatrix, namedDestinations, ParsingOptions.Logger);
		if (operations == null || operations.Count == 0)
		{
			PageContent content = new PageContent(Array.Empty<IGraphicsStateOperation>(), Array.Empty<Letter>(), Array.Empty<PdfPath>(), Array.Empty<Union<XObjectContentRecord, InlineImage>>(), Array.Empty<MarkedContentElement>(), PdfScanner, FilterProvider, ResourceStore);
			return new Page(pageNumber, dictionary, mediaBox, cropBox, rotation, content, annotationProvider, PdfScanner);
		}
		PageContent content2 = new ContentStreamProcessor(pageNumber, ResourceStore, PdfScanner, PageContentParser, FilterProvider, cropBox, userSpaceUnit, rotation, initialMatrix, ParsingOptions).Process(pageNumber, operations);
		return new Page(pageNumber, dictionary, mediaBox, cropBox, rotation, content2, annotationProvider, PdfScanner);
	}
}
