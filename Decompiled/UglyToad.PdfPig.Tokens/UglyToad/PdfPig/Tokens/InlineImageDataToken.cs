using System;

namespace UglyToad.PdfPig.Tokens;

public sealed class InlineImageDataToken : IDataToken<Memory<byte>>, IToken, IEquatable<IToken>
{
	public Memory<byte> Data { get; }

	public InlineImageDataToken(Memory<byte> data)
	{
		Data = data;
	}

	public bool Equals(IToken obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is InlineImageDataToken inlineImageDataToken))
		{
			return false;
		}
		Memory<byte> data = Data;
		Span<byte> span = data.Span;
		data = inlineImageDataToken.Data;
		return span.SequenceEqual(data.Span);
	}
}
