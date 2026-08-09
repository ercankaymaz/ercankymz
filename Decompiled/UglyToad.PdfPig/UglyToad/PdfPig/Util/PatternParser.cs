using System;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Util;

internal static class PatternParser
{
	public static PatternColor Create(IToken pattern, IPdfTokenScanner scanner, IResourceStore resourceStore, ILookupFilterProvider filterProvider)
	{
		StreamToken patternStream = null;
		DictionaryToken dictionaryToken;
		if (DirectObjectFinder.TryGet<StreamToken>(pattern, scanner, out StreamToken tokenResult))
		{
			dictionaryToken = tokenResult.StreamDictionary;
			patternStream = new StreamToken(tokenResult.StreamDictionary, tokenResult.Decode(filterProvider, scanner));
		}
		else
		{
			if (!DirectObjectFinder.TryGet<DictionaryToken>(pattern, scanner, out DictionaryToken tokenResult2))
			{
				throw new PdfDocumentFormatException($"Invalid Pattern token encountered in page resource dictionary: {pattern}.");
			}
			dictionaryToken = tokenResult2;
		}
		if (!dictionaryToken.Data.ContainsKey(NameToken.PatternType))
		{
			throw new Exception("TODO");
		}
		int num = ((NumericToken)dictionaryToken.Data[NameToken.PatternType]).Int;
		TransformationMatrix matrix;
		if (dictionaryToken.Data.ContainsKey(NameToken.Matrix) && DirectObjectFinder.TryGet<ArrayToken>(dictionaryToken.Data[NameToken.Matrix], scanner, out ArrayToken tokenResult3))
		{
			matrix = TransformationMatrix.FromArray((from n in tokenResult3.Data.OfType<NumericToken>()
				select n.Data).ToArray());
		}
		else
		{
			object obj = global::_003CPrivateImplementationDetails_003E._4787A52766C2D47C0D1BA11D22DDB34A2BEEE258C82364EB9A6FBB8754C63D20_A4;
			if (obj == null)
			{
				obj = new double[6] { 1.0, 0.0, 0.0, 1.0, 0.0, 0.0 };
				global::_003CPrivateImplementationDetails_003E._4787A52766C2D47C0D1BA11D22DDB34A2BEEE258C82364EB9A6FBB8754C63D20_A4 = (double[])obj;
			}
			matrix = TransformationMatrix.FromArray(new ReadOnlySpan<double>((double[])obj));
		}
		DictionaryToken tokenResult4 = null;
		if (dictionaryToken.Data.ContainsKey(NameToken.ExtGState))
		{
			DirectObjectFinder.TryGet<DictionaryToken>(dictionaryToken.Data[NameToken.ExtGState], scanner, out tokenResult4);
		}
		return num switch
		{
			1 => CreateTilingPattern(patternStream, tokenResult4, in matrix, scanner), 
			2 => CreateShadingPattern(dictionaryToken, tokenResult4, in matrix, scanner, resourceStore, filterProvider), 
			_ => throw new PdfDocumentFormatException($"Invalid Pattern type encountered in page resource dictionary: {num}."), 
		};
	}

	private static PatternColor CreateTilingPattern(StreamToken patternStream, DictionaryToken patternExtGState, in TransformationMatrix matrix, IPdfTokenScanner scanner)
	{
		if (!patternStream.StreamDictionary.TryGet<NumericToken>(NameToken.PaintType, scanner, out NumericToken token))
		{
			throw new PdfDocumentFormatException("Invalid Pattern token encountered.");
		}
		if (!patternStream.StreamDictionary.TryGet<NumericToken>(NameToken.TilingType, scanner, out NumericToken token2))
		{
			throw new PdfDocumentFormatException("Invalid Pattern token encountered.");
		}
		if (!patternStream.StreamDictionary.TryGet<ArrayToken>(NameToken.Bbox, scanner, out ArrayToken token3))
		{
			throw new PdfDocumentFormatException("Invalid Pattern token encountered.");
		}
		if (!patternStream.StreamDictionary.TryGet<NumericToken>(NameToken.XStep, scanner, out NumericToken token4))
		{
			throw new PdfDocumentFormatException("Invalid Pattern token encountered.");
		}
		if (!patternStream.StreamDictionary.TryGet<NumericToken>(NameToken.YStep, scanner, out NumericToken token5))
		{
			throw new PdfDocumentFormatException("Invalid Pattern token encountered.");
		}
		if (!patternStream.StreamDictionary.TryGet<DictionaryToken>(NameToken.Resources, scanner, out DictionaryToken token6))
		{
			throw new PdfDocumentFormatException("Invalid Pattern token encountered.");
		}
		return new TilingPatternColor(matrix, patternExtGState, patternStream, (PatternPaintType)token.Int, (PatternTilingType)token2.Int, token3.ToRectangle(scanner), token4.Double, token5.Double, token6, patternStream.Data);
	}

	private static PatternColor CreateShadingPattern(DictionaryToken patternDictionary, DictionaryToken? patternExtGState, in TransformationMatrix matrix, IPdfTokenScanner scanner, IResourceStore resourceStore, ILookupFilterProvider filterProvider)
	{
		IToken token = patternDictionary.Data[NameToken.Shading];
		Shading shading;
		if (DirectObjectFinder.TryGet<DictionaryToken>(token, scanner, out DictionaryToken tokenResult))
		{
			shading = ShadingParser.Create(tokenResult, scanner, resourceStore, filterProvider);
		}
		else
		{
			if (!DirectObjectFinder.TryGet<StreamToken>(token, scanner, out StreamToken tokenResult2))
			{
				throw new ArgumentException("TODO");
			}
			shading = ShadingParser.Create(tokenResult2, scanner, resourceStore, filterProvider);
		}
		return new ShadingPatternColor(matrix, patternExtGState, patternDictionary, shading);
	}
}
