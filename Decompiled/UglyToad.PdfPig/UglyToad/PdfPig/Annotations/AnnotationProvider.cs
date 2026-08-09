using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Actions;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Outline.Destinations;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Annotations;

public class AnnotationProvider
{
	private readonly IPdfTokenScanner tokenScanner;

	private readonly DictionaryToken pageDictionary;

	private readonly NamedDestinations namedDestinations;

	private readonly ILog log;

	private readonly TransformationMatrix matrix;

	public AnnotationProvider(IPdfTokenScanner tokenScanner, DictionaryToken pageDictionary, TransformationMatrix matrix, NamedDestinations namedDestinations, ILog log)
	{
		this.matrix = matrix;
		this.tokenScanner = tokenScanner ?? throw new ArgumentNullException("tokenScanner");
		this.pageDictionary = pageDictionary ?? throw new ArgumentNullException("pageDictionary");
		this.namedDestinations = namedDestinations;
		this.log = log;
	}

	public IEnumerable<Annotation> GetAnnotations()
	{
		Dictionary<IndirectReference, Annotation> lookupAnnotations = new Dictionary<IndirectReference, Annotation>();
		if (!pageDictionary.TryGet<ArrayToken>(NameToken.Annots, tokenScanner, out ArrayToken token))
		{
			yield break;
		}
		foreach (IToken datum in token.Data)
		{
			if (!DirectObjectFinder.TryGet<DictionaryToken>(datum, tokenScanner, out DictionaryToken tokenResult))
			{
				continue;
			}
			Annotation inReplyTo = null;
			if (tokenResult.TryGet(NameToken.Irt, out IndirectReferenceToken token2) && lookupAnnotations.TryGetValue(token2.Data, out Annotation value))
			{
				inReplyTo = value;
			}
			AnnotationType type = tokenResult.Get<NameToken>(NameToken.Subtype, tokenScanner).ToAnnotationType();
			PdfAction action = GetAction(tokenResult);
			PdfRectangle rectangle = matrix.Transform(tokenResult.Get<ArrayToken>(NameToken.Rect, tokenScanner).ToRectangle(tokenScanner));
			string namedString = GetNamedString(NameToken.Contents, tokenResult);
			string namedString2 = GetNamedString(NameToken.Nm, tokenResult);
			string namedString3 = GetNamedString(NameToken.M, tokenResult);
			AnnotationFlags flags = (AnnotationFlags)0;
			if (tokenResult.TryGet(NameToken.F, out var token3) && DirectObjectFinder.TryGet<NumericToken>(token3, tokenScanner, out NumericToken tokenResult2))
			{
				flags = (AnnotationFlags)tokenResult2.Int;
			}
			AnnotationBorder border = AnnotationBorder.Default;
			if (tokenResult.TryGet(NameToken.Border, out var token4) && DirectObjectFinder.TryGet<ArrayToken>(token4, tokenScanner, out ArrayToken tokenResult3) && tokenResult3.Length >= 3)
			{
				double data = tokenResult3.GetNumeric(0).Data;
				double data2 = tokenResult3.GetNumeric(1).Data;
				double data3 = tokenResult3.GetNumeric(2).Data;
				IReadOnlyList<double> lineDashPattern = null;
				if (tokenResult3.Length == 4 && tokenResult3.Data[3] is ArrayToken arrayToken)
				{
					lineDashPattern = (from x in arrayToken.Data.OfType<NumericToken>()
						select x.Data).ToArray();
				}
				border = new AnnotationBorder(data, data2, data3, lineDashPattern);
			}
			List<QuadPointsQuadrilateral> list = new List<QuadPointsQuadrilateral>();
			if (tokenResult.TryGet<ArrayToken>(NameToken.Quadpoints, tokenScanner, out ArrayToken token5))
			{
				List<double> list2 = new List<double>();
				for (int num = 0; num < token5.Length; num++)
				{
					if (token5[num] is NumericToken numericToken)
					{
						list2.Add(numericToken.Data);
						if (list2.Count == 8)
						{
							list.Add(new QuadPointsQuadrilateral(new PdfPoint[4]
							{
								matrix.Transform(new PdfPoint(list2[0], list2[1])),
								matrix.Transform(new PdfPoint(list2[2], list2[3])),
								matrix.Transform(new PdfPoint(list2[4], list2[5])),
								matrix.Transform(new PdfPoint(list2[6], list2[7]))
							}));
							list2.Clear();
						}
					}
				}
			}
			AppearanceStream normalAppearanceStream = null;
			AppearanceStream downAppearanceStream = null;
			AppearanceStream rollOverAppearanceStream = null;
			if (tokenResult.TryGet(NameToken.Ap, out DictionaryToken token6))
			{
				if (AppearanceStreamFactory.TryCreate(token6, NameToken.N, tokenScanner, out AppearanceStream appearanceStream))
				{
					normalAppearanceStream = appearanceStream;
				}
				if (AppearanceStreamFactory.TryCreate(token6, NameToken.R, tokenScanner, out appearanceStream))
				{
					rollOverAppearanceStream = appearanceStream;
				}
				if (AppearanceStreamFactory.TryCreate(token6, NameToken.D, tokenScanner, out appearanceStream))
				{
					downAppearanceStream = appearanceStream;
				}
			}
			string appearanceState = null;
			if (tokenResult.TryGet(NameToken.As, out NameToken token7))
			{
				appearanceState = token7.Data;
			}
			Annotation annotation = new Annotation(tokenResult, type, rectangle, namedString, namedString2, namedString3, flags, border, list, action, normalAppearanceStream, rollOverAppearanceStream, downAppearanceStream, appearanceState, inReplyTo);
			if (datum is IndirectReferenceToken indirectReferenceToken)
			{
				lookupAnnotations[indirectReferenceToken.Data] = annotation;
			}
			yield return annotation;
		}
	}

	internal PdfAction? GetAction(DictionaryToken annotationDictionary)
	{
		if (DestinationProvider.TryGetDestination(annotationDictionary, NameToken.Dest, namedDestinations, tokenScanner, log, isRemoteDestination: false, out ExplicitDestination destination))
		{
			return new GoToAction(destination);
		}
		if (ActionProvider.TryGetAction(annotationDictionary, namedDestinations, tokenScanner, log, out PdfAction result))
		{
			return result;
		}
		return null;
	}

	private string? GetNamedString(NameToken name, DictionaryToken dictionary)
	{
		string result = null;
		if (dictionary.TryGet(name, out var token))
		{
			StringToken tokenResult;
			if (token is StringToken stringToken)
			{
				result = stringToken.Data;
			}
			else if (token is HexToken hexToken)
			{
				result = hexToken.Data;
			}
			else if (DirectObjectFinder.TryGet<StringToken>(token, tokenScanner, out tokenResult))
			{
				result = tokenResult.Data;
			}
		}
		return result;
	}
}
