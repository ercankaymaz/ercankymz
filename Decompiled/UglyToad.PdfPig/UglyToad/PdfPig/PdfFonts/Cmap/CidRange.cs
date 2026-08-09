using System;

namespace UglyToad.PdfPig.PdfFonts.Cmap;

internal readonly struct CidRange
{
	private readonly int firstCharacterCode;

	private readonly int lastCharacterCode;

	private readonly int cid;

	public CidRange(int firstCharacterCode, int lastCharacterCode, int cid)
	{
		if (lastCharacterCode < firstCharacterCode)
		{
			throw new ArgumentOutOfRangeException("lastCharacterCode", "The last character code cannot be lower than the first character code: " + $"First: {firstCharacterCode}, Last: {lastCharacterCode}, CID: {cid}");
		}
		this.firstCharacterCode = firstCharacterCode;
		this.lastCharacterCode = lastCharacterCode;
		this.cid = cid;
	}

	public bool Contains(int characterCode)
	{
		if (firstCharacterCode <= characterCode)
		{
			return characterCode <= lastCharacterCode;
		}
		return false;
	}

	public bool TryMap(int characterCode, out int cidValue)
	{
		cidValue = 0;
		if (Contains(characterCode))
		{
			cidValue = cid + (characterCode - firstCharacterCode);
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return $"CID {cid}: Code {firstCharacterCode} -> {lastCharacterCode}";
	}
}
