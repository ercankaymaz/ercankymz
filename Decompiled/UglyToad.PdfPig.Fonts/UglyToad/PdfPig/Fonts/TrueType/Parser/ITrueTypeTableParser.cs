using UglyToad.PdfPig.Fonts.TrueType.Tables;

namespace UglyToad.PdfPig.Fonts.TrueType.Parser;

internal interface ITrueTypeTableParser<out T> where T : ITrueTypeTable
{
	T Parse(TrueTypeHeaderTable header, TrueTypeDataBytes data, TableRegister.Builder register);
}
