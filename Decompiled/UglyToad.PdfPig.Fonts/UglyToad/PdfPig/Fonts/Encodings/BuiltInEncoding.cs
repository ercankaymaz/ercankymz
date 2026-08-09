using System.Collections.Generic;

namespace UglyToad.PdfPig.Fonts.Encodings;

public class BuiltInEncoding : Encoding
{
	public override string EncodingName => "built-in (TTF)";

	public BuiltInEncoding(IReadOnlyDictionary<int, string> codeToName)
	{
		foreach (KeyValuePair<int, string> item in codeToName)
		{
			Add(item.Key, item.Value);
		}
	}
}
