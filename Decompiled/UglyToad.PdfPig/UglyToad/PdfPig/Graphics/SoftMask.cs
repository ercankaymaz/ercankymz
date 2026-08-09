using System;
using System.Linq;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Functions;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Graphics;

public sealed class SoftMask
{
	public SoftMaskType Subtype { get; private set; }

	public StreamToken TransparencyGroup { get; private set; }

	public double[]? BC { get; private set; }

	public PdfFunction? TransferFunction { get; private set; }

	internal static SoftMask Parse(DictionaryToken dictionaryToken, IPdfTokenScanner pdfTokenScanner, ILookupFilterProvider filterProvider)
	{
		if (dictionaryToken == null)
		{
			throw new ArgumentNullException("dictionaryToken");
		}
		SoftMask softMask = new SoftMask();
		if (!dictionaryToken.TryGet<NameToken>(NameToken.S, pdfTokenScanner, out NameToken token))
		{
			throw new Exception($"Missing soft-mask dictionary '{NameToken.S}' entry.");
		}
		if (token.Equals(NameToken.Luminosity))
		{
			softMask.Subtype = SoftMaskType.Luminosity;
		}
		else
		{
			if (!token.Equals(NameToken.Alpha))
			{
				throw new Exception($"Invalid soft-mask Subtype '{token}' entry.");
			}
			softMask.Subtype = SoftMaskType.Alpha;
		}
		if (!dictionaryToken.TryGet<StreamToken>(NameToken.G, pdfTokenScanner, out StreamToken token2))
		{
			throw new Exception($"Missing soft-mask dictionary '{NameToken.G}' entry.");
		}
		softMask.TransparencyGroup = token2;
		if (dictionaryToken.TryGet<ArrayToken>(NameToken.Bc, pdfTokenScanner, out ArrayToken token3))
		{
			softMask.BC = (from x in token3.Data.OfType<NumericToken>()
				select x.Data).ToArray();
		}
		IToken token5;
		if (dictionaryToken.TryGet<NameToken>(NameToken.Tr, pdfTokenScanner, out NameToken token4))
		{
			if (!token4.Equals(NameToken.Identity))
			{
				throw new Exception($"Invalid transfer function name '{token4}' entry, should be '{NameToken.Identity}'.");
			}
		}
		else if (dictionaryToken.TryGet<IToken>(NameToken.Tr, pdfTokenScanner, out token5))
		{
			softMask.TransferFunction = PdfFunctionParser.Create(token5, pdfTokenScanner, filterProvider);
		}
		return softMask;
	}
}
