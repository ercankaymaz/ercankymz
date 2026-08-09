using System;

namespace UglyToad.PdfPig.Fonts.Type1.Parser;

internal sealed class Type1DataToken : Type1Token
{
	public ReadOnlyMemory<byte> Data { get; }

	public override bool IsPrivateDictionary { get; }

	public Type1DataToken(TokenType type, ReadOnlyMemory<byte> data)
		: base(string.Empty, type)
	{
		if (type != TokenType.Charstring)
		{
			throw new ArgumentException($"Invalid token type for type 1 token receiving bytes, expected Charstring, got {type}.");
		}
		Data = data;
	}

	public override string ToString()
	{
		return $"Token[type = {base.Type}, data = {Data.Length} bytes]";
	}
}
