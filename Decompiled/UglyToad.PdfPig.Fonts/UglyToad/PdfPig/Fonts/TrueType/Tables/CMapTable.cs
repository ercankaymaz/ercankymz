using System;
using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.TrueType.Tables.CMapSubTables;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

public class CMapTable : ITrueTypeTable, IWriteable
{
	public string Tag => "cmap";

	public TrueTypeHeaderTable DirectoryTable { get; }

	public ushort Version { get; }

	public IReadOnlyList<ICMapSubTable> SubTables { get; }

	public CMapTable(ushort version, TrueTypeHeaderTable directoryTable, IReadOnlyList<ICMapSubTable> subTables)
	{
		SubTables = subTables;
		Version = version;
		DirectoryTable = directoryTable;
	}

	public bool TryGetGlyphIndex(int characterCode, out int glyphIndex)
	{
		glyphIndex = 0;
		if (SubTables.Count == 0)
		{
			return false;
		}
		ICMapSubTable iCMapSubTable = null;
		foreach (ICMapSubTable subTable in SubTables)
		{
			glyphIndex = subTable.CharacterCodeToGlyphIndex(characterCode);
			if (glyphIndex != 0)
			{
				return true;
			}
			if (subTable.EncodingId == 0 && subTable.PlatformId == TrueTypeCMapPlatform.Windows)
			{
				iCMapSubTable = subTable;
			}
		}
		if (iCMapSubTable != null && characterCode >= 0 && characterCode <= 255)
		{
			glyphIndex = iCMapSubTable.CharacterCodeToGlyphIndex(characterCode + 61440);
			if (glyphIndex != 0)
			{
				return true;
			}
			glyphIndex = iCMapSubTable.CharacterCodeToGlyphIndex(characterCode + 61696);
			if (glyphIndex != 0)
			{
				return true;
			}
			glyphIndex = iCMapSubTable.CharacterCodeToGlyphIndex(characterCode + 61952);
			if (glyphIndex != 0)
			{
				return true;
			}
		}
		return false;
	}

	public void Write(Stream stream)
	{
		long position = stream.Position;
		stream.WriteUShort(Version);
		stream.WriteUShort(SubTables.Count);
		long[] array = new long[SubTables.Count];
		for (int i = 0; i < SubTables.Count; i++)
		{
			ICMapSubTable iCMapSubTable = SubTables[i];
			stream.WriteUShort((ushort)iCMapSubTable.PlatformId);
			stream.WriteUShort(iCMapSubTable.EncodingId);
			array[i] = stream.Position;
			stream.WriteUInt(0u);
		}
		long[] array2 = new long[SubTables.Count];
		for (int j = 0; j < SubTables.Count; j++)
		{
			ICMapSubTable iCMapSubTable2 = SubTables[j];
			IWriteable obj = (iCMapSubTable2 as IWriteable) ?? throw new InvalidOperationException("Cannot write subtable of type: " + iCMapSubTable2.GetType().Name + ".");
			array2[j] = stream.Position - position;
			obj.Write(stream);
		}
		long position2 = stream.Position;
		for (int k = 0; k < array.Length; k++)
		{
			long value = array2[k];
			stream.Seek(array[k], SeekOrigin.Begin);
			stream.WriteUInt(value);
		}
		stream.Seek(position2, SeekOrigin.Begin);
	}
}
