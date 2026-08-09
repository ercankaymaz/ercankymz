using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.CompactFontFormat;
using UglyToad.PdfPig.Fonts.TrueType.Parser;
using UglyToad.PdfPig.Fonts.TrueType.Tables.CMapSubTables;

namespace UglyToad.PdfPig.Fonts.TrueType;

public sealed class TrueTypeFont
{
	private readonly CompactFontFormatFontCollection? cffFontCollection;

	public float Version { get; }

	public IReadOnlyDictionary<string, TrueTypeHeaderTable> TableHeaders { get; }

	public TableRegister TableRegister { get; }

	public string Name => TableRegister.NameTable?.FontName;

	public ICMapSubTable WindowsUnicodeCMap { get; }

	public ICMapSubTable MacRomanCMap { get; }

	public ICMapSubTable WindowsSymbolCMap { get; }

	public int NumberOfTables { get; }

	internal TrueTypeFont(float version, IReadOnlyDictionary<string, TrueTypeHeaderTable> tableHeaders, TableRegister tableRegister, CompactFontFormatFontCollection? cffFontCollection)
	{
		Version = version;
		TableHeaders = tableHeaders ?? throw new ArgumentNullException("tableHeaders");
		TableRegister = tableRegister ?? throw new ArgumentNullException("tableRegister");
		NumberOfTables = tableHeaders.Count;
		this.cffFontCollection = cffFontCollection;
		if (TableRegister.CMapTable == null)
		{
			return;
		}
		foreach (ICMapSubTable subTable in TableRegister.CMapTable.SubTables)
		{
			if (WindowsSymbolCMap == null && subTable.PlatformId == TrueTypeCMapPlatform.Windows && subTable.EncodingId == 0)
			{
				WindowsSymbolCMap = subTable;
			}
			else if (WindowsUnicodeCMap == null && subTable.PlatformId == TrueTypeCMapPlatform.Windows && subTable.EncodingId == 1)
			{
				WindowsUnicodeCMap = subTable;
			}
			else if (MacRomanCMap == null && subTable.PlatformId == TrueTypeCMapPlatform.Macintosh && subTable.EncodingId == 0)
			{
				MacRomanCMap = subTable;
			}
		}
	}

	public bool TryGetBoundingBox(int characterCode, out PdfRectangle boundingBox)
	{
		return TryGetBoundingBox(characterCode, null, out boundingBox);
	}

	public bool TryGetBoundingBox(int characterCode, Func<int, int?> characterCodeToGlyphId, out PdfRectangle boundingBox)
	{
		boundingBox = default(PdfRectangle);
		if (TableRegister.GlyphTable == null)
		{
			if (cffFontCollection != null)
			{
				string characterName = cffFontCollection.FirstFont.GetCharacterName(characterCode, isCid: true);
				if (string.IsNullOrEmpty(characterName))
				{
					return false;
				}
				PdfRectangle? characterBoundingBox = cffFontCollection.FirstFont.GetCharacterBoundingBox(characterName);
				if (characterBoundingBox.HasValue)
				{
					boundingBox = characterBoundingBox.Value;
					return true;
				}
			}
			return false;
		}
		if (!TryGetGlyphIndex(characterCode, characterCodeToGlyphId, out var glyphId))
		{
			return false;
		}
		if (!TableRegister.GlyphTable.TryGetGlyphBounds(glyphId, out boundingBox))
		{
			return false;
		}
		if (boundingBox.Width.Equals(0.0) && TryGetBoundingAdvancedWidthByIndex(glyphId, out var width))
		{
			boundingBox = new PdfRectangle(0.0, 0.0, width, 0.0);
		}
		return true;
	}

	public bool TryGetPath(int characterCode, out IReadOnlyList<PdfSubpath> path)
	{
		return TryGetPath(characterCode, null, out path);
	}

	public bool TryGetPath(int characterCode, Func<int, int?> characterCodeToGlyphId, out IReadOnlyList<PdfSubpath> path)
	{
		path = null;
		if (TableRegister.GlyphTable == null)
		{
			if (cffFontCollection != null)
			{
				string characterName = cffFontCollection.FirstFont.GetCharacterName(characterCode, isCid: true);
				if (string.IsNullOrEmpty(characterName))
				{
					return false;
				}
				return cffFontCollection.FirstFont.TryGetPath(characterName, out path);
			}
			return false;
		}
		if (!TryGetGlyphIndex(characterCode, characterCodeToGlyphId, out var glyphId))
		{
			return false;
		}
		return TableRegister.GlyphTable.TryGetGlyphPath(glyphId, out path);
	}

	public bool TryGetAdvanceWidth(int characterCode, out double width)
	{
		return TryGetAdvanceWidth(characterCode, null, out width);
	}

	public bool TryGetAdvanceWidth(int characterCode, Func<int, int?> characterCodeToGlyphId, out double width)
	{
		width = 0.0;
		if (!TryGetGlyphIndex(characterCode, characterCodeToGlyphId, out var glyphId))
		{
			return false;
		}
		return TryGetBoundingAdvancedWidthByIndex(glyphId, out width);
	}

	public int GetUnitsPerEm()
	{
		return TableRegister.HeaderTable.UnitsPerEm;
	}

	private bool TryGetBoundingAdvancedWidthByIndex(int index, out double width)
	{
		width = 0.0;
		if (TableRegister.HorizontalMetricsTable == null)
		{
			return false;
		}
		width = (int)TableRegister.HorizontalMetricsTable.GetAdvanceWidth(index);
		return true;
	}

	private bool TryGetGlyphIndex(int characterIdentifier, Func<int, int?> characterCodeToGlyphId, out int glyphId)
	{
		glyphId = 0;
		int? num = characterCodeToGlyphId?.Invoke(characterIdentifier);
		if (num.HasValue)
		{
			glyphId = num.Value;
			return true;
		}
		if (TableRegister.CMapTable == null)
		{
			return false;
		}
		return TableRegister.CMapTable.TryGetGlyphIndex(characterIdentifier, out glyphId);
	}
}
