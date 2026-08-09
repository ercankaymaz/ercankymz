using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Parser;

internal interface IEncodingReader
{
	Encoding? Read(DictionaryToken fontDictionary, FontDescriptor? descriptor = null, Encoding? fontEncoding = null);
}
