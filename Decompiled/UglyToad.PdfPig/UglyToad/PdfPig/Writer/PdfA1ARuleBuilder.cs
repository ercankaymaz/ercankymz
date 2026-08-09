using System.Collections.Generic;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer;

internal static class PdfA1ARuleBuilder
{
	public static void Obey(Dictionary<NameToken, IToken> catalog)
	{
		DictionaryToken value = GenerateStructTree();
		catalog[NameToken.StructTreeRoot] = value;
		DictionaryToken value2 = new DictionaryToken(new Dictionary<NameToken, IToken> { 
		{
			NameToken.Marked,
			BooleanToken.True
		} });
		catalog[NameToken.MarkInfo] = value2;
	}

	private static DictionaryToken GenerateStructTree()
	{
		return new DictionaryToken(new Dictionary<NameToken, IToken> { 
		{
			NameToken.Type,
			NameToken.StructTreeRoot
		} });
	}
}
