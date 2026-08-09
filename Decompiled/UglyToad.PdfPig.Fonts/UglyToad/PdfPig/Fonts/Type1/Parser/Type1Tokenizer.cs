using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.Type1.Parser;

internal class Type1Tokenizer
{
	private readonly StringBuilder commentBuffer = new StringBuilder();

	private readonly StringBuilder literalBuffer = new StringBuilder();

	private readonly StringBuilder stringBuffer = new StringBuilder();

	private readonly IInputBytes bytes;

	private readonly List<string> comments;

	private int openParens;

	private Type1Token previousToken;

	public Type1Token CurrentToken { get; private set; }

	public IReadOnlyList<string> Comments => comments;

	public Type1Tokenizer(IInputBytes bytes)
	{
		this.bytes = bytes;
		comments = new List<string>();
		CurrentToken = ReadNextToken();
	}

	public Type1Token GetNext()
	{
		CurrentToken = ReadNextToken();
		return CurrentToken;
	}

	private Type1Token ReadNextToken()
	{
		previousToken = CurrentToken;
		bool flag;
		do
		{
			flag = false;
			while (bytes.MoveNext())
			{
				byte currentByte = bytes.CurrentByte;
				char c = (char)currentByte;
				switch (c)
				{
				case '%':
					comments.Add(ReadComment());
					continue;
				case '(':
					return ReadString();
				case ')':
					throw new InvalidOperationException("Encountered an end of string ')' outside of string.");
				case '[':
					return new Type1Token(c, Type1Token.TokenType.StartArray);
				case ']':
					return new Type1Token(c, Type1Token.TokenType.EndArray);
				case '{':
					return new Type1Token(c, Type1Token.TokenType.StartProc);
				case '}':
					return new Type1Token(c, Type1Token.TokenType.EndProc);
				case '/':
					return new Type1Token(ReadLiteral(), Type1Token.TokenType.Literal);
				case '<':
					if (bytes.Peek() == 60)
					{
						bytes.MoveNext();
						return new Type1Token("<<", Type1Token.TokenType.StartDict);
					}
					return new Type1Token(c, Type1Token.TokenType.Name);
				case '>':
					if (bytes.Peek() == 62)
					{
						bytes.MoveNext();
						return new Type1Token(">>", Type1Token.TokenType.EndDict);
					}
					return new Type1Token(c, Type1Token.TokenType.Name);
				}
				if (ReadHelper.IsWhitespace(currentByte))
				{
					flag = true;
					continue;
				}
				if (currentByte == 0)
				{
					flag = true;
					continue;
				}
				if (TryReadNumber(c, out Type1Token numberToken))
				{
					return numberToken;
				}
				string text = ReadLiteral(c);
				if (text == null)
				{
					throw new InvalidOperationException($"The binary portion of the type 1 font was invalid at position {bytes.CurrentOffset}.");
				}
				if (text.Equals("RD", StringComparison.OrdinalIgnoreCase) || text.Equals("-|"))
				{
					if (previousToken.Type == Type1Token.TokenType.Integer)
					{
						return ReadCharString(previousToken.AsInt());
					}
					throw new InvalidOperationException($"Expected integer token before {text} at offset {bytes.CurrentOffset}.");
				}
				return new Type1Token(text, Type1Token.TokenType.Name);
			}
		}
		while (flag);
		return null;
	}

	private Type1Token ReadString()
	{
		stringBuffer.Clear();
		while (bytes.MoveNext())
		{
			char currentByte = (char)bytes.CurrentByte;
			switch (currentByte)
			{
			case '(':
				openParens++;
				stringBuffer.Append('(');
				break;
			case ')':
				if (openParens == 0)
				{
					return new Type1Token(stringBuffer.ToString(), Type1Token.TokenType.String);
				}
				stringBuffer.Append(')');
				openParens--;
				break;
			case '\\':
			{
				char c = GetNext();
				switch (c)
				{
				case 'n':
				case 'r':
					stringBuffer.Append('\n');
					break;
				case 't':
					stringBuffer.Append('\t');
					break;
				case 'b':
					stringBuffer.Append('\b');
					break;
				case 'f':
					stringBuffer.Append('\f');
					break;
				case '\\':
					stringBuffer.Append('\\');
					break;
				case '(':
					stringBuffer.Append('(');
					break;
				case ')':
					stringBuffer.Append(')');
					break;
				}
				if (char.IsDigit(c))
				{
					int num = Convert.ToInt32(new string(new char[3]
					{
						c,
						GetNext(),
						GetNext()
					}), 8);
					stringBuffer.Append((char)num);
				}
				break;
			}
			case '\n':
			case '\r':
				stringBuffer.Append('\n');
				break;
			default:
				stringBuffer.Append(currentByte);
				break;
			}
		}
		return null;
		char GetNext()
		{
			bytes.MoveNext();
			return (char)bytes.CurrentByte;
		}
	}

	private bool TryReadNumber(char c, out Type1Token numberToken)
	{
		numberToken = null;
		long currentOffset = bytes.CurrentOffset;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = null;
		bool flag = false;
		if (c == '+' || c == '-')
		{
			stringBuilder.Append(c);
			c = GetNext();
		}
		while (char.IsDigit(c))
		{
			stringBuilder.Append(c);
			c = GetNext();
			flag = true;
		}
		switch (c)
		{
		case '.':
			stringBuilder.Append(c);
			c = GetNext();
			break;
		case '#':
			stringBuilder2 = stringBuilder;
			stringBuilder = new StringBuilder();
			c = GetNext();
			break;
		default:
			if (stringBuilder.Length == 0 || !flag)
			{
				bytes.Seek(currentOffset);
				return false;
			}
			bytes.Seek(bytes.CurrentOffset - 1);
			numberToken = new Type1Token(stringBuilder.ToString(), Type1Token.TokenType.Integer);
			return true;
		}
		if (char.IsDigit(c))
		{
			stringBuilder.Append(c);
			c = GetNext();
			while (char.IsDigit(c))
			{
				stringBuilder.Append(c);
				c = GetNext();
			}
			if (c == 'E')
			{
				stringBuilder.Append(c);
				c = GetNext();
				if (c == '-')
				{
					stringBuilder.Append(c);
					c = GetNext();
				}
				if (!char.IsDigit(c))
				{
					bytes.Seek(currentOffset);
					return false;
				}
				stringBuilder.Append(c);
				c = GetNext();
				while (char.IsDigit(c))
				{
					stringBuilder.Append(c);
					c = GetNext();
				}
			}
			bytes.Seek(bytes.CurrentOffset - 1);
			if (stringBuilder2 != null)
			{
				numberToken = new Type1Token(Convert.ToInt32(stringBuilder.ToString(), int.Parse(stringBuilder2.ToString(), CultureInfo.InvariantCulture)).ToString(), Type1Token.TokenType.Integer);
			}
			else
			{
				numberToken = new Type1Token(stringBuilder.ToString(), Type1Token.TokenType.Real);
			}
			return true;
		}
		bytes.Seek(currentOffset);
		return false;
		char GetNext()
		{
			bytes.MoveNext();
			return (char)bytes.CurrentByte;
		}
	}

	private string ReadLiteral(char? previousCharacter = null)
	{
		literalBuffer.Clear();
		if (previousCharacter.HasValue)
		{
			literalBuffer.Append(previousCharacter);
		}
		do
		{
			byte? b = bytes.Peek();
			if (!b.HasValue)
			{
				break;
			}
			char value = (char)b.Value;
			if (char.IsWhiteSpace(value) || value == '(' || value == ')' || value == '<' || value == '>' || value == '[' || value == ']' || value == '{' || value == '}' || value == '/' || value == '%')
			{
				break;
			}
			literalBuffer.Append(value);
		}
		while (bytes.MoveNext());
		string text = literalBuffer.ToString();
		if (text.Length != 0)
		{
			return text;
		}
		return null;
	}

	private string ReadComment()
	{
		commentBuffer.Clear();
		while (bytes.MoveNext())
		{
			char currentByte = (char)bytes.CurrentByte;
			if (ReadHelper.IsEndOfLine(currentByte))
			{
				break;
			}
			commentBuffer.Append(currentByte);
		}
		return commentBuffer.ToString();
	}

	private Type1DataToken ReadCharString(int length)
	{
		bytes.MoveNext();
		byte[] array = new byte[length];
		for (int i = 0; i < length; i++)
		{
			bytes.MoveNext();
			array[i] = bytes.CurrentByte;
		}
		return new Type1DataToken(Type1Token.TokenType.Charstring, array);
	}
}
