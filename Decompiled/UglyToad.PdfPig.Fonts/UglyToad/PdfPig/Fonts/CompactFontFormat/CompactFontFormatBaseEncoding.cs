using System.Collections.Generic;
using UglyToad.PdfPig.Fonts.Encodings;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

internal abstract class CompactFontFormatBaseEncoding : Encoding
{
	private readonly Dictionary<int, string> codeToNameMap = new Dictionary<int, string>(250);

	public override string EncodingName { get; } = "CFF";

	public override string GetName(int code)
	{
		if (!codeToNameMap.TryGetValue(code, out string value))
		{
			return ".notdef";
		}
		return value;
	}

	public void Add(int code, int sid, string name)
	{
		codeToNameMap[code] = name;
		Add(code, name);
	}

	protected void Add(int code, int sid)
	{
		string name = CompactFontFormatStandardStrings.GetName(sid);
		codeToNameMap[code] = name;
		Add(code, name);
	}
}
