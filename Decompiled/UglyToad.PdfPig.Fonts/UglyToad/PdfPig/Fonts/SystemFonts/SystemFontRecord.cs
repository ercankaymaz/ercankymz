using System;

namespace UglyToad.PdfPig.Fonts.SystemFonts;

internal readonly struct SystemFontRecord
{
	public string Path { get; }

	public SystemFontType Type { get; }

	public SystemFontRecord(string path, SystemFontType type)
	{
		Path = path ?? throw new ArgumentNullException("path");
		Type = type;
	}

	public static bool TryCreate(string path, out SystemFontRecord type)
	{
		type = default(SystemFontRecord);
		SystemFontType type2;
		if (path.EndsWith(".ttf"))
		{
			type2 = SystemFontType.TrueType;
		}
		else if (path.EndsWith(".otf"))
		{
			type2 = SystemFontType.OpenType;
		}
		else if (path.EndsWith(".ttc"))
		{
			type2 = SystemFontType.TrueTypeCollection;
		}
		else if (path.EndsWith(".otc"))
		{
			type2 = SystemFontType.OpenTypeCollection;
		}
		else
		{
			if (!path.EndsWith(".pfb"))
			{
				return false;
			}
			type2 = SystemFontType.Type1;
		}
		type = new SystemFontRecord(path, type2);
		return true;
	}
}
