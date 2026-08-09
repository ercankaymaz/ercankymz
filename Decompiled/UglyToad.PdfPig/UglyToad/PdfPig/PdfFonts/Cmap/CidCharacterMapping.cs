namespace UglyToad.PdfPig.PdfFonts.Cmap;

internal readonly struct CidCharacterMapping
{
	public int SourceCharacterCode { get; }

	public int DestinationCid { get; }

	public CidCharacterMapping(int sourceCharacterCode, int destinationCid)
	{
		SourceCharacterCode = sourceCharacterCode;
		DestinationCid = destinationCid;
	}

	public override string ToString()
	{
		return $"Code {SourceCharacterCode} -> CID {DestinationCid}";
	}
}
