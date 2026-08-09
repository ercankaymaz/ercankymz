namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

public interface ITrueTypeTable
{
	string Tag { get; }

	TrueTypeHeaderTable DirectoryTable { get; }
}
