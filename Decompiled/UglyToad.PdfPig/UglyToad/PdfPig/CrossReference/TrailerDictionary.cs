using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.CrossReference;

public class TrailerDictionary
{
	public int Size { get; }

	public long? PreviousCrossReferenceOffset { get; }

	public IndirectReference Root { get; }

	public IToken? Info { get; }

	public IReadOnlyList<IDataToken<string>> Identifier { get; }

	public IToken? EncryptionToken { get; }

	internal TrailerDictionary(DictionaryToken dictionary, bool isLenientParsing)
	{
		if (dictionary == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		Size = dictionary.GetInt(NameToken.Size);
		PreviousCrossReferenceOffset = dictionary.GetLongOrDefault(NameToken.Prev);
		if (!dictionary.TryGet(NameToken.Root, out IndirectReferenceToken token))
		{
			throw new PdfDocumentFormatException($"No root token was found in the trailer dictionary: {dictionary}.");
		}
		Root = token.Data;
		if (dictionary.TryGet(NameToken.Info, out var token2))
		{
			if (!isLenientParsing && !(token2 is IndirectReferenceToken))
			{
				throw new PdfDocumentFormatException($"The info token in the trailer dictionary should only contain indirect references, instead got: {token2}.");
			}
			Info = token2;
		}
		if (dictionary.TryGet(NameToken.Id, out ArrayToken token3))
		{
			List<IDataToken<string>> list = new List<IDataToken<string>>(token3.Data.Count);
			foreach (IToken datum in token3.Data)
			{
				if (datum is StringToken item)
				{
					list.Add(item);
				}
				else if (datum is HexToken item2)
				{
					list.Add(item2);
				}
			}
			Identifier = list;
		}
		else
		{
			Identifier = Array.Empty<IDataToken<string>>();
		}
		if (dictionary.TryGet(NameToken.Encrypt, out var token4))
		{
			EncryptionToken = token4;
		}
	}

	public override string ToString()
	{
		return $"Size: {Size}, Root: {Root}";
	}
}
