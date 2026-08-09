using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokenization;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Fonts.Type1.Parser;

public sealed class Type1ArrayTokenizer : ITokenizer
{
	private static readonly string[] Space = new string[1] { " " };

	public bool ReadsNextByte { get; }

	public bool TryTokenize(byte currentByte, IInputBytes inputBytes, out IToken token)
	{
		token = null;
		if (currentByte != 123)
		{
			return false;
		}
		StringBuilder stringBuilder = new StringBuilder();
		while (inputBytes.MoveNext() && inputBytes.CurrentByte != 125)
		{
			stringBuilder.Append((char)inputBytes.CurrentByte);
		}
		string[] array = stringBuilder.ToString().Split(Space, StringSplitOptions.RemoveEmptyEntries);
		List<IToken> list = new List<IToken>();
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (char.IsNumber(text[0]) || text[0] == '-')
			{
				if (double.TryParse(text, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out var result))
				{
					list.Add(new NumericToken(result));
				}
				else
				{
					list.Add(OperatorToken.Create(text.AsSpan()));
				}
			}
			else if (text[0] == '/')
			{
				list.Add(NameToken.Create(text.Substring(1)));
			}
			else if (text[0] == '(' && text[text.Length - 1] == ')')
			{
				list.Add(new StringToken(text));
			}
			else
			{
				list.Add(OperatorToken.Create(text.AsSpan()));
			}
		}
		token = new ArrayToken(list);
		return true;
	}
}
