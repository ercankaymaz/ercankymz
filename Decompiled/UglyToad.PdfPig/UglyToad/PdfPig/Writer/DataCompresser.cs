using System.Collections.Generic;
using System.IO;
using System.Linq;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer;

internal static class DataCompresser
{
	public static byte[] CompressBytes(IReadOnlyList<byte> bytes)
	{
		return CompressBytes(bytes.ToArray());
	}

	public static byte[] CompressBytes(byte[] bytes)
	{
		using MemoryStream input = new MemoryStream(bytes);
		DictionaryToken streamDictionary = new DictionaryToken(new Dictionary<NameToken, IToken>());
		return new FlateFilter().Encode(input, streamDictionary, 0);
	}

	public static StreamToken CompressToStream(IReadOnlyList<byte> bytes)
	{
		return CompressToStream(bytes.ToArray());
	}

	public static StreamToken CompressToStream(byte[] bytes)
	{
		byte[] array = CompressBytes(bytes);
		Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>();
		dictionary.Add(NameToken.Length, new NumericToken(array.Length));
		dictionary.Add(NameToken.Length1, new NumericToken(bytes.Length));
		dictionary.Add(NameToken.Filter, new ArrayToken(new NameToken[1] { NameToken.FlateDecode }));
		return new StreamToken(new DictionaryToken(dictionary), array);
	}
}
