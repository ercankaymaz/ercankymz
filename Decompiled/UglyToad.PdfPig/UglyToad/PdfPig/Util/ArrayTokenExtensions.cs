using System;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Util;

public static class ArrayTokenExtensions
{
	public static NumericToken GetNumeric(this ArrayToken array, int index)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (index < 0 || index >= array.Data.Count)
		{
			throw new ArgumentOutOfRangeException($"Cannot index into array at index {index}. Array was: {array}.");
		}
		if (array.Data[index] is NumericToken result)
		{
			return result;
		}
		throw new PdfDocumentFormatException($"The array did not contain a number at index {index}. Array was: {array}.");
	}

	public static PdfRectangle ToRectangle(this ArrayToken array, IPdfTokenScanner tokenScanner)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (array.Data.Count != 4)
		{
			throw new PdfDocumentFormatException($"Cannot convert array to rectangle, expected 4 values instead got: {array.Data.Count}.");
		}
		return new PdfRectangle(DirectObjectFinder.Get<NumericToken>(array[0], tokenScanner).Double, DirectObjectFinder.Get<NumericToken>(array[1], tokenScanner).Double, DirectObjectFinder.Get<NumericToken>(array[2], tokenScanner).Double, DirectObjectFinder.Get<NumericToken>(array[3], tokenScanner).Double);
	}

	public static PdfRectangle ToIntRectangle(this ArrayToken array, IPdfTokenScanner tokenScanner)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (array.Data.Count != 4)
		{
			throw new PdfDocumentFormatException($"Cannot convert array to rectangle, expected 4 values instead got: {array.Data.Count}.");
		}
		return new PdfRectangle(DirectObjectFinder.Get<NumericToken>(array[0], tokenScanner).Int, DirectObjectFinder.Get<NumericToken>(array[1], tokenScanner).Int, DirectObjectFinder.Get<NumericToken>(array[2], tokenScanner).Int, DirectObjectFinder.Get<NumericToken>(array[3], tokenScanner).Int);
	}
}
