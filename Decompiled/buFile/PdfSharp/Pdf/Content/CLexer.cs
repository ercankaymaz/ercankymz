#define DEBUG
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using PdfSharp.Internal;

namespace PdfSharp.Pdf.Content;

public class CLexer
{
	private static readonly double[] PowersOf10 = new double[11]
	{
		1.0, 10.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, 10000000.0, 100000000.0, 1000000000.0,
		10000000000.0
	};

	private readonly byte[] _content;

	private int _charIndex;

	private char _currChar;

	private char _nextChar;

	private readonly StringBuilder _token = new StringBuilder();

	private long _tokenAsLong;

	private double _tokenAsReal;

	private CSymbol _symbol = CSymbol.None;

	public CSymbol Symbol
	{
		get
		{
			return _symbol;
		}
		set
		{
			_symbol = value;
		}
	}

	public string Token => _token.ToString();

	internal int TokenToInteger
	{
		get
		{
			Debug.Assert(_tokenAsLong == int.Parse(_token.ToString(), CultureInfo.InvariantCulture));
			return (int)_tokenAsLong;
		}
	}

	internal double TokenToReal
	{
		get
		{
			Debug.Assert(_tokenAsReal == double.Parse(_token.ToString(), CultureInfo.InvariantCulture));
			return _tokenAsReal;
		}
	}

	public int ContLength => _content.Length;

	public int Position
	{
		get
		{
			return _charIndex;
		}
		set
		{
			_charIndex = value;
			_currChar = (char)_content[_charIndex - 1];
			_nextChar = (char)_content[_charIndex - 1];
		}
	}

	public CLexer(byte[] content)
	{
		_content = content;
		_charIndex = 0;
	}

	public CLexer(MemoryStream content)
	{
		_content = content.ToArray();
		_charIndex = 0;
	}

	public CSymbol ScanNextToken()
	{
		while (true)
		{
			ClearToken();
			char c = MoveToNonWhiteSpace();
			switch (c)
			{
			case '%':
				break;
			case '/':
				return _symbol = ScanName();
			case '+':
			case '-':
				return _symbol = ScanNumber();
			case '[':
				ScanNextChar();
				return _symbol = CSymbol.BeginArray;
			case ']':
				ScanNextChar();
				return _symbol = CSymbol.EndArray;
			case '(':
				return _symbol = ScanLiteralString();
			case '<':
				if (_nextChar == '<')
				{
					return _symbol = ScanDictionary();
				}
				return _symbol = ScanHexadecimalString();
			case '.':
				return _symbol = ScanNumber();
			case '"':
			case '\'':
				return _symbol = ScanOperator();
			default:
				if (char.IsDigit(c))
				{
					return _symbol = ScanNumber();
				}
				if (char.IsLetter(c))
				{
					return _symbol = ScanOperator();
				}
				if (c == '\uffff')
				{
					return _symbol = CSymbol.Eof;
				}
				ContentReaderDiagnostics.HandleUnexpectedCharacter(c);
				return _symbol = CSymbol.None;
			}
			ScanComment();
		}
	}

	public CSymbol ScanComment()
	{
		Debug.Assert(_currChar == '%');
		ClearToken();
		char c;
		while ((c = AppendAndScanNextChar()) != '\n' && c != '\uffff')
		{
		}
		return _symbol = CSymbol.Comment;
	}

	public CSymbol ScanInlineImage()
	{
		bool flag = false;
		do
		{
			ScanNextToken();
			if (!flag && _symbol == CSymbol.Name && (Token == "/ASCII85Decode" || Token == "/A85"))
			{
				flag = true;
			}
		}
		while (_symbol != CSymbol.Operator || Token != "ID");
		if (flag)
		{
			while (_currChar != '\uffff' && (_currChar != '~' || _nextChar != '>'))
			{
				ScanNextChar();
			}
			if (_currChar == '\uffff')
			{
				ContentReaderDiagnostics.HandleUnexpectedCharacter(_currChar);
			}
		}
		while (_currChar != '\uffff')
		{
			if (IsWhiteSpace(_currChar))
			{
				if (ScanNextChar() == 'E' && ScanNextChar() == 'I' && IsWhiteSpace(ScanNextChar()))
				{
					break;
				}
			}
			else
			{
				ScanNextChar();
			}
		}
		if (_currChar == '\uffff')
		{
			ContentReaderDiagnostics.HandleUnexpectedCharacter(_currChar);
		}
		return CSymbol.None;
	}

	public CSymbol ScanName()
	{
		Debug.Assert(_currChar == '/');
		ClearToken();
		while (true)
		{
			char c = AppendAndScanNextChar();
			if (IsWhiteSpace(c) || IsDelimiter(c))
			{
				break;
			}
			if (c == '#')
			{
				ScanNextChar();
				char[] value = new char[2] { _currChar, _nextChar };
				ScanNextChar();
				c = (char)int.Parse(new string(value), NumberStyles.AllowHexSpecifier);
				_currChar = c;
			}
		}
		return _symbol = CSymbol.Name;
	}

	protected CSymbol ScanDictionary()
	{
		ClearToken();
		_token.Append(_currChar);
		_token.Append(ScanNextChar());
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			char c;
			_token.Append(c = ScanNextChar());
			if (c == '<')
			{
				if (_nextChar == '<')
				{
					_token.Append(ScanNextChar());
					num++;
				}
				else
				{
					flag2 = true;
				}
				continue;
			}
			if (!flag2 && c == '(')
			{
				if (flag)
				{
					num2++;
					continue;
				}
				flag = true;
				num2 = 0;
				continue;
			}
			if (flag && c == ')')
			{
				if (num2 > 0)
				{
					num2--;
				}
				else
				{
					flag = false;
				}
				continue;
			}
			if (flag && c == '\\')
			{
				_token.Append(ScanNextChar());
				continue;
			}
			switch (c)
			{
			case '>':
				if (flag2)
				{
					flag2 = false;
				}
				else if (_nextChar == '>')
				{
					_token.Append(ScanNextChar());
					if (num <= 0)
					{
						ScanNextChar();
						return CSymbol.Dictionary;
					}
					num--;
				}
				break;
			case '\uffff':
				ContentReaderDiagnostics.HandleUnexpectedCharacter(c);
				break;
			}
		}
	}

	public CSymbol ScanNumber()
	{
		long num = 0L;
		int num2 = 0;
		bool flag = false;
		bool flag2 = false;
		ClearToken();
		char c = _currChar;
		if (c == '+' || c == '-')
		{
			if (c == '-')
			{
				flag2 = true;
			}
			_token.Append(c);
			c = ScanNextChar();
		}
		while (true)
		{
			if (char.IsDigit(c))
			{
				_token.Append(c);
				if (num2 < 10)
				{
					num = 10 * num + c - 48;
					if (flag)
					{
						num2++;
					}
				}
			}
			else
			{
				if (c != '.')
				{
					break;
				}
				if (flag)
				{
					ContentReaderDiagnostics.ThrowContentReaderException("More than one period in number.");
				}
				flag = true;
				_token.Append(c);
			}
			c = ScanNextChar();
		}
		if (flag2)
		{
			num = -num;
		}
		if (flag)
		{
			if (num2 > 0)
			{
				_tokenAsReal = (double)num / PowersOf10[num2];
			}
			else
			{
				_tokenAsReal = num;
				_tokenAsLong = num;
			}
			return CSymbol.Real;
		}
		_tokenAsLong = num;
		_tokenAsReal = Convert.ToDouble(num);
		Debug.Assert(long.Parse(_token.ToString(), CultureInfo.InvariantCulture) == num);
		if (num >= int.MinValue && num < int.MaxValue)
		{
			return CSymbol.Integer;
		}
		ContentReaderDiagnostics.ThrowNumberOutOfIntegerRange(num);
		return CSymbol.Error;
	}

	public CSymbol ScanOperator()
	{
		ClearToken();
		char ch = _currChar;
		while (IsOperatorChar(ch))
		{
			ch = AppendAndScanNextChar();
		}
		return _symbol = CSymbol.Operator;
	}

	public CSymbol ScanLiteralString()
	{
		Debug.Assert(_currChar == '(');
		ClearToken();
		int num = 0;
		char c = ScanNextChar();
		if (c == 'þ' && _nextChar == 'ÿ')
		{
			ScanNextChar();
			char c2 = ScanNextChar();
			if (c2 == ')')
			{
				ScanNextChar();
				return _symbol = CSymbol.String;
			}
			char c3 = ScanNextChar();
			c = (char)(c2 * 256 + c3);
			while (true)
			{
				bool flag = true;
				while (true)
				{
					switch (c)
					{
					case '(':
						num++;
						break;
					case ')':
						if (num == 0)
						{
							ScanNextChar();
							return _symbol = CSymbol.String;
						}
						num--;
						break;
					case '\\':
						c = ScanNextChar();
						switch (c)
						{
						case 'n':
							c = '\n';
							break;
						case 'r':
							c = '\r';
							break;
						case 't':
							c = '\t';
							break;
						case 'b':
							c = '\b';
							break;
						case 'f':
							c = '\f';
							break;
						case '(':
							c = '(';
							break;
						case ')':
							c = ')';
							break;
						case '\\':
							c = '\\';
							break;
						case '\n':
							goto IL_0182;
						default:
						{
							if (!char.IsDigit(c))
							{
								break;
							}
							int num2 = c - 48;
							if (char.IsDigit(_nextChar))
							{
								num2 = num2 * 8 + ScanNextChar() - 48;
								if (char.IsDigit(_nextChar))
								{
									num2 = num2 * 8 + ScanNextChar() - 48;
								}
							}
							c = (char)num2;
							break;
						}
						}
						break;
					}
					break;
					IL_0182:
					c = ScanNextChar();
				}
				_token.Append(c);
				c2 = ScanNextChar();
				if (c2 == ')')
				{
					break;
				}
				c3 = ScanNextChar();
				c = (char)(c2 * 256 + c3);
			}
			ScanNextChar();
			return _symbol = CSymbol.String;
		}
		while (true)
		{
			bool flag2 = true;
			while (true)
			{
				switch (c)
				{
				case '(':
					num++;
					break;
				case ')':
					if (num == 0)
					{
						ScanNextChar();
						return _symbol = CSymbol.String;
					}
					num--;
					break;
				case '\\':
					c = ScanNextChar();
					switch (c)
					{
					case 'n':
						c = '\n';
						break;
					case 'r':
						c = '\r';
						break;
					case 't':
						c = '\t';
						break;
					case 'b':
						c = '\b';
						break;
					case 'f':
						c = '\f';
						break;
					case '(':
						c = '(';
						break;
					case ')':
						c = ')';
						break;
					case '\\':
						c = '\\';
						break;
					case '\n':
						goto IL_0341;
					default:
					{
						if (!char.IsDigit(c))
						{
							break;
						}
						int num3 = c - 48;
						if (char.IsDigit(_nextChar))
						{
							num3 = num3 * 8 + ScanNextChar() - 48;
							if (char.IsDigit(_nextChar))
							{
								num3 = num3 * 8 + ScanNextChar() - 48;
							}
						}
						c = (char)num3;
						break;
					}
					}
					break;
				}
				break;
				IL_0341:
				c = ScanNextChar();
			}
			_token.Append(c);
			c = ScanNextChar();
		}
	}

	public CSymbol ScanHexadecimalString()
	{
		Debug.Assert(_currChar == '<');
		ClearToken();
		char[] array = new char[2];
		ScanNextChar();
		while (true)
		{
			MoveToNonWhiteSpace();
			if (_currChar == '>')
			{
				break;
			}
			if (char.IsLetterOrDigit(_currChar))
			{
				array[0] = char.ToUpper(_currChar);
				array[1] = char.ToUpper(_nextChar);
				int value = int.Parse(new string(array), NumberStyles.AllowHexSpecifier);
				_token.Append(Convert.ToChar(value));
				ScanNextChar();
				ScanNextChar();
			}
		}
		ScanNextChar();
		string text = _token.ToString();
		int length = text.Length;
		if (length > 2 && text[0] == 'þ' && text[1] == 'ÿ')
		{
			Debug.Assert(length % 2 == 0);
			_token.Length = 0;
			for (int i = 2; i < length; i += 2)
			{
				_token.Append((char)(text[i] * 256 + text[i + 1]));
			}
		}
		return _symbol = CSymbol.HexString;
	}

	internal char ScanNextChar()
	{
		if (ContLength <= _charIndex)
		{
			_currChar = '\uffff';
			if (IsOperatorChar(_nextChar))
			{
				_token.Append(_nextChar);
			}
			_nextChar = '\uffff';
		}
		else
		{
			_currChar = _nextChar;
			_nextChar = (char)_content[_charIndex++];
			if (_currChar == '\r')
			{
				if (_nextChar == '\n')
				{
					_currChar = _nextChar;
					if (ContLength <= _charIndex)
					{
						_nextChar = '\uffff';
					}
					else
					{
						_nextChar = (char)_content[_charIndex++];
					}
				}
				else
				{
					_currChar = '\n';
				}
			}
		}
		return _currChar;
	}

	private void ClearToken()
	{
		_token.Length = 0;
		_tokenAsLong = 0L;
		_tokenAsReal = 0.0;
	}

	internal char AppendAndScanNextChar()
	{
		_token.Append(_currChar);
		return ScanNextChar();
	}

	public char MoveToNonWhiteSpace()
	{
		while (_currChar != '\uffff')
		{
			switch (_currChar)
			{
			case '\0':
			case '\t':
			case '\n':
			case '\f':
			case '\r':
			case ' ':
				break;
			default:
				return _currChar;
			}
			ScanNextChar();
		}
		return _currChar;
	}

	internal static bool IsWhiteSpace(char ch)
	{
		switch (ch)
		{
		case '\0':
		case '\t':
		case '\n':
		case '\f':
		case '\r':
		case ' ':
			return true;
		default:
			return false;
		}
	}

	internal static bool IsOperatorChar(char ch)
	{
		if (char.IsLetter(ch))
		{
			return true;
		}
		char c = ch;
		char c2 = c;
		if (c2 == '"' || c2 == '\'' || c2 == '*')
		{
			return true;
		}
		return false;
	}

	internal static bool IsDelimiter(char ch)
	{
		switch (ch)
		{
		case '%':
		case '(':
		case ')':
		case '/':
		case '<':
		case '>':
		case '[':
		case ']':
			return true;
		default:
			return false;
		}
	}
}
