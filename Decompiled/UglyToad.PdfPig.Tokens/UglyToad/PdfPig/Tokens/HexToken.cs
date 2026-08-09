using System;
using System.Collections.Generic;
using System.Text;

namespace UglyToad.PdfPig.Tokens;

public sealed class HexToken : IDataToken<string>, IToken, IEquatable<IToken>
{
	private static readonly Dictionary<char, byte> HexMap = new Dictionary<char, byte>
	{
		{ '0', 0 },
		{ '1', 1 },
		{ '2', 2 },
		{ '3', 3 },
		{ '4', 4 },
		{ '5', 5 },
		{ '6', 6 },
		{ '7', 7 },
		{ '8', 8 },
		{ '9', 9 },
		{ 'A', 10 },
		{ 'a', 10 },
		{ 'B', 11 },
		{ 'b', 11 },
		{ 'C', 12 },
		{ 'c', 12 },
		{ 'D', 13 },
		{ 'd', 13 },
		{ 'E', 14 },
		{ 'e', 14 },
		{ 'F', 15 },
		{ 'f', 15 }
	};

	private readonly byte[] _bytes;

	public string Data { get; }

	public ReadOnlySpan<byte> Bytes => _bytes;

	public ReadOnlyMemory<byte> Memory => _bytes;

	public HexToken(ReadOnlySpan<char> characters)
	{
		if (characters == null)
		{
			throw new ArgumentNullException("characters");
		}
		byte[] array = new byte[(characters.Length + 1) / 2];
		int num = 0;
		for (int i = 0; i < characters.Length; i += 2)
		{
			char high = characters[i];
			char low = ((i != characters.Length - 1) ? characters[i + 1] : '0');
			byte b = ConvertPair(high, low);
			array[num++] = b;
		}
		if (array.Length >= 2 && array[0] == 254 && array[1] == byte.MaxValue)
		{
			Data = Encoding.BigEndianUnicode.GetString(array, 2, array.Length - 2);
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array2 = array;
			foreach (byte b2 in array2)
			{
				if (b2 != 0)
				{
					stringBuilder.Append((char)b2);
				}
			}
			Data = stringBuilder.ToString();
		}
		_bytes = array;
	}

	public static byte ConvertPair(char high, char low)
	{
		byte num = HexMap[high];
		byte b = HexMap[low];
		return (byte)((num << 4) | b);
	}

	public static int ConvertHexBytesToInt(HexToken token)
	{
		if (token == null)
		{
			throw new ArgumentNullException("token");
		}
		ReadOnlySpan<byte> bytes = token.Bytes;
		int num = bytes[0] & 0xFF;
		if (bytes.Length == 2)
		{
			num <<= 8;
			num += bytes[1] & 0xFF;
		}
		return num;
	}

	public bool Equals(IToken obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is HexToken hexToken))
		{
			return false;
		}
		return Data == hexToken.Data;
	}

	public string GetHexString()
	{
		return BitConverter.ToString(_bytes).Replace("-", string.Empty);
	}
}
