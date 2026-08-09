using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Fonts.TrueType.Names;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

public class NameTable : ITrueTypeTable
{
	public string Tag => "name";

	public TrueTypeHeaderTable DirectoryTable { get; }

	public string FontName { get; }

	public string FontFamilyName { get; }

	public string FontSubFamilyName { get; }

	public IReadOnlyList<TrueTypeNameRecord> NameRecords { get; }

	public NameTable(TrueTypeHeaderTable directoryTable, string fontName, string fontFamilyName, string fontSubFamilyName, IReadOnlyList<TrueTypeNameRecord> nameRecords)
	{
		DirectoryTable = directoryTable;
		FontName = fontName;
		FontFamilyName = fontFamilyName;
		FontSubFamilyName = fontSubFamilyName;
		NameRecords = nameRecords ?? throw new ArgumentNullException("nameRecords");
	}

	public string GetPostscriptName()
	{
		string result = null;
		foreach (TrueTypeNameRecord nameRecord in NameRecords)
		{
			if (nameRecord != null && nameRecord.NameId == 6)
			{
				if (nameRecord.PlatformId == TrueTypePlatformIdentifier.Windows)
				{
					return nameRecord.Value;
				}
				result = nameRecord.Value;
			}
		}
		return result;
	}
}
