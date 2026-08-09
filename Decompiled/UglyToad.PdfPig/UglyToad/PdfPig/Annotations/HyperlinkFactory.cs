using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Annotations;

internal static class HyperlinkFactory
{
	public static IReadOnlyList<Hyperlink> GetHyperlinks(Page page, IPdfTokenScanner pdfScanner, AnnotationProvider annotationProvider)
	{
		List<Hyperlink> list = new List<Hyperlink>();
		foreach (Annotation annotation in annotationProvider.GetAnnotations())
		{
			if (annotation.Type != AnnotationType.Link || !annotation.AnnotationDictionary.TryGet<DictionaryToken>(NameToken.A, pdfScanner, out DictionaryToken token) || !token.TryGet<NameToken>(NameToken.S, pdfScanner, out NameToken token2) || token2 != NameToken.Uri || !token.TryGet<IDataToken<string>>(NameToken.Uri, pdfScanner, out IDataToken<string> token3))
			{
				continue;
			}
			PdfRectangle rectangle = annotation.Rectangle;
			PdfRectangle rectangle2 = new PdfRectangle(rectangle.BottomLeft.Translate(-0.5, -0.5), rectangle.TopRight.Translate(0.5, 0.5));
			List<Letter> list2 = new List<Letter>();
			foreach (Letter letter in page.Letters)
			{
				if (rectangle2.Contains(letter.Location, includeBorder: true))
				{
					list2.Add(letter);
				}
			}
			IEnumerable<Word> words = DefaultWordExtractor.Instance.GetWords(list2);
			string text = string.Join(" ", words.Select((Word x) => x.Text));
			list.Add(new Hyperlink(rectangle, list2, text, token3.Data, annotation));
		}
		return list;
	}
}
