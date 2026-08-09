using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.PdfFonts.Simple;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.PdfFonts.Parser.Handlers;

internal class Type3FontHandler : IFontHandler
{
	private readonly IEncodingReader encodingReader;

	private readonly IPdfTokenScanner scanner;

	private readonly CMapLocalCache cmapLocalCache;

	public Type3FontHandler(IPdfTokenScanner scanner, IEncodingReader encodingReader, CMapLocalCache cMapLocalCache)
	{
		this.encodingReader = encodingReader;
		this.scanner = scanner;
		cmapLocalCache = cMapLocalCache;
	}

	public IFont Generate(DictionaryToken dictionary)
	{
		PdfRectangle boundingBox = GetBoundingBox(dictionary);
		TransformationMatrix fontMatrix = GetFontMatrix(dictionary);
		if (boundingBox.Left == 0.0 && boundingBox.Bottom == 0.0 && boundingBox.Height == 0.0 && boundingBox.Width == 0.0 && fontMatrix.A != 0.0 && fontMatrix.D != 0.0)
		{
			boundingBox = new PdfRectangle(0.0, 0.0, 1.0 / fontMatrix.A, 1.0 / fontMatrix.D);
		}
		int firstCharacter = FontDictionaryAccessHelper.GetFirstCharacter(dictionary);
		int lastCharacter = FontDictionaryAccessHelper.GetLastCharacter(dictionary);
		double[] widths = FontDictionaryAccessHelper.GetWidths(scanner, dictionary);
		Encoding encoding = encodingReader.Read(dictionary);
		CMap result = null;
		if (dictionary.TryGet(NameToken.ToUnicode, out var token))
		{
			StreamToken token2 = DirectObjectFinder.Get<StreamToken>(token, scanner);
			cmapLocalCache.TryGet(token2, out result);
		}
		return new Type3Font(GetFontName(dictionary), boundingBox, fontMatrix, encoding, firstCharacter, lastCharacter, widths, result);
	}

	private NameToken GetFontName(DictionaryToken dictionary)
	{
		if (dictionary.TryGet<NameToken>(NameToken.Name, scanner, out NameToken token))
		{
			return token;
		}
		return NameToken.Type3;
	}

	private TransformationMatrix GetFontMatrix(DictionaryToken dictionary)
	{
		if (!dictionary.TryGet(NameToken.FontMatrix, out var token))
		{
			throw new InvalidFontFormatException($"No font matrix found: {dictionary}.");
		}
		ArrayToken array = DirectObjectFinder.Get<ArrayToken>(token, scanner);
		return TransformationMatrix.FromValues(array.GetNumeric(0).Double, array.GetNumeric(1).Double, array.GetNumeric(2).Double, array.GetNumeric(3).Double, array.GetNumeric(4).Double, array.GetNumeric(5).Double);
	}

	private static PdfRectangle GetBoundingBox(DictionaryToken dictionary)
	{
		if (!dictionary.TryGet(NameToken.FontBbox, out var token))
		{
			throw new InvalidFontFormatException($"Type 3 font was invalid. No Font Bounding Box: {dictionary}.");
		}
		if (token is ArrayToken array)
		{
			return new PdfRectangle(array.GetNumeric(0).Double, array.GetNumeric(1).Double, array.GetNumeric(2).Double, array.GetNumeric(3).Double);
		}
		return new PdfRectangle(0, 0, 0, 0);
	}
}
