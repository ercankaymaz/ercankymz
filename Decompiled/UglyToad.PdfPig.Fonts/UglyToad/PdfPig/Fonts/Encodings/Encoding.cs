using System.Collections.Generic;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Fonts.Encodings;

public abstract class Encoding
{
	protected internal const string NotDefined = ".notdef";

	protected readonly Dictionary<int, string> CodeToName = new Dictionary<int, string>(250);

	protected readonly Dictionary<string, int> NameToCode = new Dictionary<string, int>(250);

	public IReadOnlyDictionary<int, string> CodeToNameMap => CodeToName;

	public IReadOnlyDictionary<string, int> NameToCodeMap => NameToCode;

	public abstract string EncodingName { get; }

	public bool ContainsName(string name)
	{
		return NameToCode.ContainsKey(name);
	}

	public bool ContainsCode(int code)
	{
		return CodeToName.ContainsKey(code);
	}

	public virtual string GetName(int code)
	{
		if (!CodeToName.TryGetValue(code, out string value))
		{
			return ".notdef";
		}
		return value;
	}

	public virtual int GetCode(string name)
	{
		if (!NameToCode.TryGetValue(name, out var value))
		{
			return -1;
		}
		return value;
	}

	protected void Add(int code, string name)
	{
		CodeToName[code] = name;
		if (!NameToCode.ContainsKey(name))
		{
			NameToCode[name] = code;
		}
	}

	public static bool TryGetNamedEncoding(NameToken name, out Encoding encoding)
	{
		encoding = null;
		if (name == null)
		{
			return false;
		}
		if (name.Equals(NameToken.StandardEncoding))
		{
			encoding = StandardEncoding.Instance;
			return true;
		}
		if (name.Equals(NameToken.WinAnsiEncoding))
		{
			encoding = WinAnsiEncoding.Instance;
			return true;
		}
		if (name.Equals(NameToken.MacExpertEncoding))
		{
			encoding = MacExpertEncoding.Instance;
			return true;
		}
		if (name.Equals(NameToken.MacRomanEncoding))
		{
			encoding = MacRomanEncoding.Instance;
			return true;
		}
		return false;
	}
}
