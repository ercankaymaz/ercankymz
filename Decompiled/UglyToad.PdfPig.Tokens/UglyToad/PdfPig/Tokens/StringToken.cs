using System;
using System.Text;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Tokens;

public class StringToken : IDataToken<string>, IToken, IEquatable<IToken>
{
	public enum Encoding : byte
	{
		Iso88591,
		Utf16,
		Utf16BE,
		PdfDocEncoding
	}

	public string Data { get; }

	public Encoding EncodedWith { get; }

	public StringToken(string data, Encoding encodedWith = Encoding.Iso88591)
	{
		Data = data ?? throw new ArgumentNullException("data");
		EncodedWith = encodedWith;
	}

	public byte[] GetBytes()
	{
		switch (EncodedWith)
		{
		case Encoding.Utf16BE:
		{
			byte[] bytes = System.Text.Encoding.BigEndianUnicode.GetBytes(Data);
			byte[] array = new byte[bytes.Length + 2];
			array[0] = 254;
			array[1] = byte.MaxValue;
			Array.Copy(bytes, 0, array, 2, bytes.Length);
			return array;
		}
		case Encoding.Utf16:
			return System.Text.Encoding.Unicode.GetBytes(Data);
		case Encoding.PdfDocEncoding:
			return PdfDocEncoding.StringToBytes(Data);
		default:
			return OtherEncodings.StringAsLatin1Bytes(Data);
		}
	}

	public bool Equals(IToken obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is StringToken stringToken))
		{
			return false;
		}
		if (EncodedWith.Equals(stringToken.EncodedWith))
		{
			return Data.Equals(stringToken.Data);
		}
		return false;
	}

	public override string ToString()
	{
		return "(" + Data + ")";
	}
}
