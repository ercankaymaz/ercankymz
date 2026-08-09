using System;

namespace UglyToad.PdfPig.Tokens;

public sealed class StreamToken : IDataToken<Memory<byte>>, IToken, IEquatable<IToken>
{
	public DictionaryToken StreamDictionary { get; }

	public Memory<byte> Data { get; }

	public StreamToken(DictionaryToken streamDictionary, byte[] data)
	{
		StreamDictionary = streamDictionary ?? throw new ArgumentNullException("streamDictionary");
		Data = data ?? throw new ArgumentNullException("data");
	}

	public StreamToken(DictionaryToken streamDictionary, Memory<byte> data)
	{
		StreamDictionary = streamDictionary ?? throw new ArgumentNullException("streamDictionary");
		Data = data;
	}

	public bool Equals(IToken obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is StreamToken streamToken))
		{
			return false;
		}
		if (!StreamDictionary.Equals(streamToken.StreamDictionary))
		{
			return false;
		}
		Memory<byte> data = Data;
		Span<byte> span = data.Span;
		data = streamToken.Data;
		return span.SequenceEqual(data.Span);
	}

	public override string ToString()
	{
		return $"Length: {Data.Length}, Dictionary: {StreamDictionary}";
	}
}
