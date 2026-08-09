using System;

namespace UglyToad.PdfPig.PdfFonts.CidFonts;

internal class CharacterIdentifierToGlyphIndexMap
{
	private readonly bool isIdentity;

	private readonly int[]? map;

	public CharacterIdentifierToGlyphIndexMap()
	{
		isIdentity = true;
		map = null;
	}

	public CharacterIdentifierToGlyphIndexMap(ReadOnlySpan<byte> streamBytes)
	{
		int num = streamBytes.Length / 2;
		map = new int[num];
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			int num3 = (streamBytes[num2] << 8) | streamBytes[num2 + 1];
			map[i] = num3;
			num2 += 2;
		}
	}

	public int? GetGlyphIndex(int characterIdentifier)
	{
		if (isIdentity)
		{
			return characterIdentifier;
		}
		if (characterIdentifier >= map.Length || characterIdentifier < 0)
		{
			return 0;
		}
		return map[characterIdentifier];
	}
}
