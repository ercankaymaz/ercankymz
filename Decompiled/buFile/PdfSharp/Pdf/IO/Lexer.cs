#define DEBUG
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using PdfSharp.Internal;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.IO;

public class Lexer
{
	private readonly int _pdfLength;

	private int _idxChar;

	private char _currChar;

	private char _nextChar;

	private StringBuilder _token;

	private Symbol _symbol = Symbol.None;

	private readonly Stream _pdfSteam;

	public int Position
	{
		get
		{
			return _idxChar;
		}
		set
		{
			_idxChar = value;
			_pdfSteam.Position = value;
			_currChar = (char)_pdfSteam.ReadByte();
			_nextChar = (char)_pdfSteam.ReadByte();
			_token = new StringBuilder();
		}
	}

	public Symbol Symbol
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

	public bool TokenToBoolean
	{
		get
		{
			Debug.Assert(_token.ToString() == "true" || _token.ToString() == "false");
			return _token.ToString()[0] == 't';
		}
	}

	public int TokenToInteger => int.Parse(_token.ToString(), CultureInfo.InvariantCulture);

	public uint TokenToUInteger => uint.Parse(_token.ToString(), CultureInfo.InvariantCulture);

	public double TokenToReal => double.Parse(_token.ToString(), CultureInfo.InvariantCulture);

	public PdfObjectID TokenToObjectID
	{
		get
		{
			string[] array = Token.Split('|');
			int objectNumber = int.Parse(array[0]);
			int generationNumber = int.Parse(array[1]);
			return new PdfObjectID(objectNumber, generationNumber);
		}
	}

	public int PdfLength => _pdfLength;

	public Lexer(Stream pdfInputStream)
	{
		_pdfSteam = pdfInputStream;
		_pdfLength = (int)_pdfSteam.Length;
		_idxChar = 0;
		Position = 0;
	}

	public Symbol ScanNextToken()
	{
		char c;
		while (true)
		{
			_token = new StringBuilder();
			c = MoveToNonWhiteSpace();
			switch (c)
			{
			case '%':
				goto IL_007c;
			case '/':
				return _symbol = ScanName();
			case '+':
			case '-':
				return _symbol = ScanNumber();
			case '(':
				return _symbol = ScanLiteralString();
			case '[':
				ScanNextChar(handleCRLF: true);
				return _symbol = Symbol.BeginArray;
			case ']':
				ScanNextChar(handleCRLF: true);
				return _symbol = Symbol.EndArray;
			case '<':
				if (_nextChar == '<')
				{
					ScanNextChar(handleCRLF: true);
					ScanNextChar(handleCRLF: true);
					return _symbol = Symbol.BeginDictionary;
				}
				return _symbol = ScanHexadecimalString();
			case '>':
				if (_nextChar == '>')
				{
					ScanNextChar(handleCRLF: true);
					ScanNextChar(handleCRLF: true);
					return _symbol = Symbol.EndDictionary;
				}
				ParserDiagnostics.HandleUnexpectedCharacter(_nextChar);
				break;
			case '.':
				return _symbol = ScanNumber();
			}
			break;
			IL_007c:
			ScanComment();
		}
		if (char.IsDigit(c))
		{
			if (PeekReference())
			{
				return _symbol = ScanNumber();
			}
			return _symbol = ScanNumber();
		}
		if (char.IsLetter(c))
		{
			return _symbol = ScanKeyword();
		}
		if (c == '\uffff')
		{
			return _symbol = Symbol.Eof;
		}
		ParserDiagnostics.HandleUnexpectedCharacter(c);
		return _symbol = Symbol.None;
	}

	public byte[] ReadStream(int length)
	{
		while (_currChar == ' ')
		{
			ScanNextChar(handleCRLF: true);
		}
		int num = ((_currChar != '\r') ? (_idxChar + 1) : ((_nextChar != '\n') ? (_idxChar + 1) : (_idxChar + 2)));
		_pdfSteam.Position = num;
		byte[] array = new byte[length];
		int num2 = _pdfSteam.Read(array, 0, length);
		Debug.Assert(num2 == length);
		if (array.Length != num2)
		{
			Array.Resize(ref array, num2);
		}
		Position = num + num2;
		return array;
	}

	public string ReadRawString(int position, int length)
	{
		_pdfSteam.Position = position;
		byte[] array = new byte[length];
		_pdfSteam.Read(array, 0, length);
		return PdfEncoders.RawEncoding.GetString(array, 0, array.Length);
	}

	public Symbol ScanComment()
	{
		Debug.Assert(_currChar == '%');
		_token = new StringBuilder();
		char c;
		do
		{
			c = AppendAndScanNextChar();
		}
		while (c != '\n' && c != '\uffff');
		if (_token.ToString().StartsWith("%%EOF"))
		{
			return Symbol.Eof;
		}
		return _symbol = Symbol.Comment;
	}

	public Symbol ScanName()
	{
		Debug.Assert(_currChar == '/');
		_token = new StringBuilder();
		while (true)
		{
			char c = AppendAndScanNextChar();
			if (IsWhiteSpace(c) || IsDelimiter(c) || c == '\uffff')
			{
				break;
			}
			if (c == '#')
			{
				ScanNextChar(handleCRLF: true);
				char[] value = new char[2] { _currChar, _nextChar };
				ScanNextChar(handleCRLF: true);
				c = (char)int.Parse(new string(value), NumberStyles.AllowHexSpecifier);
				_currChar = c;
			}
		}
		return _symbol = Symbol.Name;
	}

	public Symbol ScanNumber()
	{
		bool flag = false;
		_token = new StringBuilder();
		char c = _currChar;
		if (c == '+' || c == '-')
		{
			_token.Append(c);
			c = ScanNextChar(handleCRLF: true);
		}
		while (true)
		{
			if (char.IsDigit(c))
			{
				_token.Append(c);
			}
			else
			{
				if (c != '.')
				{
					break;
				}
				if (flag)
				{
					ParserDiagnostics.ThrowParserException("More than one period in number.");
				}
				flag = true;
				_token.Append(c);
			}
			c = ScanNextChar(handleCRLF: true);
		}
		if (flag)
		{
			return Symbol.Real;
		}
		long num = long.Parse(_token.ToString(), CultureInfo.InvariantCulture);
		if (num >= int.MinValue && num <= int.MaxValue)
		{
			return Symbol.Integer;
		}
		if (num > 0 && num <= uint.MaxValue)
		{
			return Symbol.UInteger;
		}
		return Symbol.Real;
	}

	public Symbol ScanNumberOrReference()
	{
		Symbol symbol = ScanNumber();
		if (symbol == Symbol.Integer)
		{
			int position = Position;
			string token = Token;
		}
		return symbol;
	}

	public Symbol ScanKeyword()
	{
		_token = new StringBuilder();
		char c = _currChar;
		while (char.IsLetter(c))
		{
			_token.Append(c);
			c = ScanNextChar(handleCRLF: false);
		}
		switch (_token.ToString())
		{
		case "obj":
			return _symbol = Symbol.Obj;
		case "endobj":
			return _symbol = Symbol.EndObj;
		case "null":
			return _symbol = Symbol.Null;
		case "true":
		case "false":
			return _symbol = Symbol.Boolean;
		case "R":
			return _symbol = Symbol.R;
		case "stream":
			return _symbol = Symbol.BeginStream;
		case "endstream":
			return _symbol = Symbol.EndStream;
		case "xref":
			return _symbol = Symbol.XRef;
		case "trailer":
			return _symbol = Symbol.Trailer;
		case "startxref":
			return _symbol = Symbol.StartXRef;
		default:
			return _symbol = Symbol.Keyword;
		}
	}

	public Symbol ScanLiteralString()
	{
		Debug.Assert(_currChar == '(');
		_token = new StringBuilder();
		int num = 0;
		char c = ScanNextChar(handleCRLF: false);
		while (c != '\uffff')
		{
			char c2 = c;
			char c3 = c2;
			if (c3 != '(')
			{
				if (c3 != ')')
				{
					if (c3 == '\\')
					{
						c = ScanNextChar(handleCRLF: false);
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
						case ' ':
							c = ' ';
							break;
						case '\n':
						case '\r':
							c = ScanNextChar(handleCRLF: false);
							continue;
						default:
						{
							if (!char.IsDigit(c) || _nextChar == '8' || _nextChar == '9')
							{
								break;
							}
							int num2 = c - 48;
							if (char.IsDigit(_nextChar) && _nextChar != '8' && _nextChar != '9')
							{
								c = ScanNextChar(handleCRLF: false);
								num2 = num2 * 8 + c - 48;
								if (char.IsDigit(_nextChar) && _nextChar != '8' && _nextChar != '9')
								{
									c = ScanNextChar(handleCRLF: false);
									num2 = num2 * 8 + c - 48;
								}
							}
							c = (char)num2;
							break;
						}
						}
					}
				}
				else
				{
					if (num == 0)
					{
						ScanNextChar(handleCRLF: false);
						break;
					}
					num--;
				}
			}
			else
			{
				num++;
			}
			_token.Append(c);
			c = ScanNextChar(handleCRLF: false);
		}
		if (_token.Length >= 2 && _token[0] == 'þ' && _token[1] == 'ÿ')
		{
			StringBuilder token = _token;
			int num3 = token.Length;
			if ((num3 & 1) == 1)
			{
				token.Append(0);
				num3++;
				DebugBreak.Break();
			}
			_token = new StringBuilder();
			for (int i = 2; i < num3; i += 2)
			{
				_token.Append((char)(256 * token[i] + token[i + 1]));
			}
			return _symbol = Symbol.UnicodeString;
		}
		if (_token.Length >= 2 && _token[0] == 'ÿ' && _token[1] == 'þ')
		{
			StringBuilder token2 = _token;
			int num4 = token2.Length;
			if ((num4 & 1) == 1)
			{
				token2.Append(0);
				num4++;
				DebugBreak.Break();
			}
			_token = new StringBuilder();
			for (int j = 2; j < num4; j += 2)
			{
				_token.Append((char)(256 * token2[j + 1] + token2[j]));
			}
			return _symbol = Symbol.UnicodeString;
		}
		return _symbol = Symbol.String;
	}

	public Symbol ScanHexadecimalString()
	{
		Debug.Assert(_currChar == '<');
		_token = new StringBuilder();
		char[] array = new char[2];
		ScanNextChar(handleCRLF: true);
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
				if (char.IsLetterOrDigit(_nextChar))
				{
					array[1] = char.ToUpper(_nextChar);
					ScanNextChar(handleCRLF: true);
				}
				else
				{
					array[1] = '0';
				}
				ScanNextChar(handleCRLF: true);
				int value = int.Parse(new string(array), NumberStyles.AllowHexSpecifier);
				_token.Append(Convert.ToChar(value));
			}
			else
			{
				ParserDiagnostics.HandleUnexpectedCharacter(_currChar);
			}
		}
		ScanNextChar(handleCRLF: true);
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
			return _symbol = Symbol.UnicodeHexString;
		}
		return _symbol = Symbol.HexString;
	}

	internal char ScanNextChar(bool handleCRLF)
	{
		if (_pdfLength <= _idxChar)
		{
			_currChar = '\uffff';
			_nextChar = '\uffff';
		}
		else
		{
			_currChar = _nextChar;
			_nextChar = (char)_pdfSteam.ReadByte();
			_idxChar++;
			if (handleCRLF && _currChar == '\r')
			{
				if (_nextChar == '\n')
				{
					_currChar = _nextChar;
					_nextChar = (char)_pdfSteam.ReadByte();
					_idxChar++;
				}
				else
				{
					_currChar = '\n';
				}
			}
		}
		return _currChar;
	}

	private bool PeekReference()
	{
		int position = Position;
		while (char.IsDigit(_currChar))
		{
			ScanNextChar(handleCRLF: true);
		}
		if (_currChar == ' ')
		{
			while (_currChar == ' ')
			{
				ScanNextChar(handleCRLF: true);
			}
			if (char.IsDigit(_currChar))
			{
				while (char.IsDigit(_currChar))
				{
					ScanNextChar(handleCRLF: true);
				}
				if (_currChar == ' ')
				{
					while (_currChar == ' ')
					{
						ScanNextChar(handleCRLF: true);
					}
					if (_currChar == 'R')
					{
						Position = position;
						return true;
					}
				}
			}
		}
		Position = position;
		return false;
	}

	internal char AppendAndScanNextChar()
	{
		if (_currChar == '\uffff')
		{
			ParserDiagnostics.ThrowParserException("Undetected EOF reached.");
		}
		_token.Append(_currChar);
		return ScanNextChar(handleCRLF: true);
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
				ScanNextChar(handleCRLF: true);
				break;
			case '\v':
			case '\u00ad':
				ScanNextChar(handleCRLF: true);
				break;
			default:
				return _currChar;
			}
		}
		return _currChar;
	}

	public string SurroundingsOfCurrentPosition(bool hex)
	{
		int num = Math.Max(Position - 20, 0);
		int num2 = Math.Min(40, PdfLength - num);
		long position = _pdfSteam.Position;
		_pdfSteam.Position = num;
		byte[] array = new byte[num2];
		_pdfSteam.Read(array, 0, num2);
		_pdfSteam.Position = position;
		string text = "";
		if (hex)
		{
			for (int i = 0; i < num2; i++)
			{
				string text2 = text;
				int num3 = array[i];
				text = text2 + num3.ToString("x2");
			}
		}
		else
		{
			for (int j = 0; j < num2; j++)
			{
				string text3 = text;
				char c = (char)array[j];
				text = text3 + c;
			}
		}
		return text;
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
		case '{':
		case '}':
			return true;
		default:
			return false;
		}
	}
}
