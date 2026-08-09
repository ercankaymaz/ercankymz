using System;
using System.Text;

namespace Xbim.IO.Step21;

public class XbimP21StringDecoder
{
	private const string SingleApostrophToken = "''";

	private const string SingleBackslashToken = "\\\\";

	private const string CodeTableToken = "\\P";

	private const string UpperAsciiToken = "\\S\\";

	private const string Hex8Token = "\\X\\";

	private const string Hex16Token = "\\X2\\";

	private const string Hex32Token = "\\X4\\";

	private const string LongHexEndToken = "\\X0\\";

	private const byte UpperAsciiShift = 128;

	private int iCurChar;

	private string p21;

	private StringBuilder builder;

	private bool eof;

	private Encoding OneByteDecoder;

	public string Unescape(string value, int codePageOverride = -1)
	{
		Initialize(value, codePageOverride);
		while (!eof)
		{
			if (At("''"))
			{
				ReplaceApostrophes();
			}
			else if (At("\\\\"))
			{
				ReplaceBackSlashes();
			}
			else if (At("\\P"))
			{
				ParseCodeTable();
			}
			else if (At("\\S\\"))
			{
				ParseUpperAscii();
			}
			else if (At("\\X\\"))
			{
				ParseHex8();
			}
			else if (At("\\X2\\"))
			{
				ParseTerminatedHex(4);
			}
			else if (At("\\X4\\"))
			{
				ParseTerminatedHex(8);
			}
			else
			{
				CopyCharacter();
			}
		}
		return builder.ToString();
	}

	private void ParseCodeTable()
	{
		MovePast("\\P");
		if (eof || !HasLength(2))
		{
			throw new XbimP21EofException();
		}
		char c = CurrentChar();
		int num = "ABCDEFGHI".IndexOf(c);
		if (num == -1)
		{
			throw new XbimP21InvalidCharacterException($"Invalid codepage character '{c}'");
		}
		MoveNext();
		if (CurrentChar() != '\\')
		{
			throw new XbimP21InvalidCharacterException($"Invalid codepage termination '{CurrentChar()}'");
		}
		num++;
		Move(1);
		OneByteDecoder = Encoding.GetEncoding("iso-8859-" + num);
	}

	private void ReplaceBackSlashes()
	{
		MovePast("\\\\");
		builder.Append('\\');
	}

	private void ReplaceApostrophes()
	{
		MovePast("''");
		builder.Append("'");
	}

	private void ParseUpperAscii()
	{
		MovePast("\\S\\");
		if (eof)
		{
			throw new XbimP21EofException();
		}
		byte b = (byte)(CurrentChar() + 128);
		byte[] bytes = new byte[1] { b };
		builder.Append(OneByteDecoder.GetChars(bytes));
		MoveNext();
	}

	private void ParseHex8()
	{
		MovePast("\\X\\");
		if (eof || !HasLength(2))
		{
			throw new XbimP21EofException();
		}
		byte[] hexLength = GetHexLength(2);
		builder.Append(OneByteDecoder.GetChars(hexLength));
	}

	private byte[] GetHexLength(int StringLenght)
	{
		StringLenght /= 2;
		byte[] array = new byte[StringLenght];
		for (int i = 0; i < StringLenght; i++)
		{
			string text = p21.Substring(iCurChar, 2);
			try
			{
				array[i] = Convert.ToByte(text, 16);
				Move(2);
			}
			catch (Exception)
			{
				throw new XbimP21InvalidCharacterException($"Invalid hexadecimal representation '{text}'");
			}
		}
		return array;
	}

	private void ParseTerminatedHex(int stringLenght)
	{
		Move(4);
		string name = "unicodeFFFE";
		if (stringLenght == 8)
		{
			name = "utf-32BE";
		}
		Encoding encoding = Encoding.GetEncoding(name);
		while (!At("\\X0\\"))
		{
			if (eof || !HasLength(stringLenght + "\\X0\\".Length))
			{
				throw new XbimP21EofException();
			}
			byte[] hexLength = GetHexLength(stringLenght);
			builder.Append(encoding.GetChars(hexLength, 0, stringLenght / 2));
		}
		MovePast("\\X0\\");
	}

	private void CopyCharacter()
	{
		builder.Append(CurrentChar());
		MoveNext();
	}

	private char CurrentChar()
	{
		return p21[iCurChar];
	}

	private void Initialize(string value, int codePageOverride = -1)
	{
		if (codePageOverride == -1)
		{
			OneByteDecoder = Encoding.GetEncoding("iso-8859-1");
		}
		else
		{
			OneByteDecoder = Encoding.GetEncoding(codePageOverride);
		}
		builder = new StringBuilder();
		p21 = value;
		eof = p21.Length == 0;
		iCurChar = 0;
	}

	private bool At(string token)
	{
		if (HasLength(token))
		{
			return p21.Substring(iCurChar, token.Length).Equals(token);
		}
		return false;
	}

	private bool HasLength(string token)
	{
		return HasLength(token.Length);
	}

	private bool HasLength(int length)
	{
		return iCurChar + length <= p21.Length;
	}

	private void MoveNext()
	{
		Move(1);
	}

	private void MovePast(string token)
	{
		Move(token.Length);
	}

	private void Move(int length)
	{
		if (!eof)
		{
			iCurChar += length;
			eof = iCurChar >= p21.Length;
		}
	}
}
