using System;
using System.Globalization;

namespace UglyToad.PdfPig.Fonts.Type1.Parser;

internal class Type1Token
{
	public enum TokenType
	{
		None,
		String,
		Name,
		Literal,
		Real,
		Integer,
		StartArray,
		EndArray,
		StartProc,
		EndProc,
		StartDict,
		EndDict,
		Charstring
	}

	public TokenType Type { get; }

	public string Text { get; }

	public virtual bool IsPrivateDictionary
	{
		get
		{
			if (Type == TokenType.Literal)
			{
				return string.Equals(Text, "Private", StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}
	}

	public Type1Token(char c, TokenType type)
		: this(c.ToString(), type)
	{
	}

	public Type1Token(string text, TokenType type)
	{
		Text = text;
		Type = type;
	}

	public int AsInt()
	{
		return (int)AsDouble();
	}

	public double AsDouble()
	{
		return double.Parse(Text, CultureInfo.InvariantCulture);
	}

	public bool AsBool()
	{
		return string.Equals(Text, "true", StringComparison.OrdinalIgnoreCase);
	}

	public override string ToString()
	{
		return $"Token[type={Type}, text={Text}]";
	}
}
