namespace PdfSharp.Pdf.Content;

public enum CSymbol
{
	None = 0,
	Comment = 1,
	Integer = 2,
	Real = 3,
	String = 4,
	HexString = 5,
	UnicodeString = 6,
	UnicodeHexString = 7,
	Name = 8,
	Operator = 9,
	BeginArray = 10,
	EndArray = 11,
	Dictionary = 12,
	Eof = 13,
	Error = -1
}
