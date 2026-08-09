namespace UglyToad.PdfPig.DocumentLayoutAnalysis.Export;

public enum InvalidCharStrategy : byte
{
	Custom,
	DoNotCheck,
	Remove,
	ConvertToHexadecimal
}
