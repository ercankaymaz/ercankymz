using System;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Parser.Parts;

internal class BaseFontRangeParser : ICidFontPartParser<NumericToken>
{
	public void Parse(NumericToken numberOfOperations, ITokenScanner scanner, CharacterMapBuilder builder)
	{
		for (int i = 0; i < numberOfOperations.Int; i++)
		{
			if (!scanner.TryReadToken<HexToken>(out var token))
			{
				if (!(scanner.CurrentToken is OperatorToken operatorToken) || !operatorToken.Data.Equals("endbfrange", StringComparison.OrdinalIgnoreCase))
				{
					throw new InvalidFontFormatException($"bfrange was missing the low source code: {scanner.CurrentToken}");
				}
				break;
			}
			if (!scanner.TryReadToken<HexToken>(out var token2))
			{
				throw new InvalidFontFormatException($"bfrange was missing the high source code: {scanner.CurrentToken}");
			}
			if (!scanner.MoveNext())
			{
				throw new InvalidFontFormatException("bfrange ended unexpectedly after the high source code.");
			}
			byte[] array = null;
			ArrayToken arrayToken = null;
			IToken currentToken = scanner.CurrentToken;
			if (!(currentToken is ArrayToken arrayToken2))
			{
				if (!(currentToken is HexToken { Bytes: var bytes }))
				{
					if (currentToken is NumericToken)
					{
						throw new NotImplementedException("From the spec it seems this possible but the meaning is unclear...");
					}
					throw new InvalidOperationException();
				}
				array = bytes.ToArray();
			}
			else
			{
				arrayToken = arrayToken2;
			}
			bool flag = false;
			byte[] array2 = token.Bytes.ToArray();
			ReadOnlySpan<byte> bytes2 = token2.Bytes;
			if (arrayToken != null)
			{
				int num = 0;
				while (!flag)
				{
					if (Compare(array2, bytes2) >= 0)
					{
						flag = true;
					}
					IToken token3 = arrayToken.Data[num];
					if (token3 is NameToken nameToken)
					{
						builder.AddBaseFontCharacter(array2, nameToken.Data);
					}
					else if (token3 is HexToken hexToken2)
					{
						builder.AddBaseFontCharacter(array2, hexToken2.Bytes);
					}
					Increment(array2, array2.Length - 1);
					num++;
				}
				continue;
			}
			while (!flag)
			{
				if (Compare(array2, bytes2) >= 0)
				{
					flag = true;
				}
				builder.AddBaseFontCharacter(array2, array);
				Increment(array2, array2.Length - 1);
				Increment(array, array.Length - 1);
			}
		}
	}

	private static void Increment(Span<byte> data, int position)
	{
		if (position > 0 && (data[position] & 0xFF) == 255)
		{
			data[position] = 0;
			Increment(data, position - 1);
		}
		else
		{
			data[position]++;
		}
	}

	private static int Compare(ReadOnlySpan<byte> first, ReadOnlySpan<byte> second)
	{
		for (int i = 0; i < first.Length; i++)
		{
			if (first[i] != second[i])
			{
				if ((first[i] & 0xFF) < (second[i] & 0xFF))
				{
					return -1;
				}
				return 1;
			}
		}
		return 0;
	}
}
