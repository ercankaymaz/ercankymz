using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts;

public class DescriptorFontFile
{
	public enum FontFileType
	{
		Type1,
		TrueType,
		FromSubtype
	}

	public IndirectReferenceToken ObjectKey { get; }

	public FontFileType FileType { get; }

	public DescriptorFontFile(IndirectReferenceToken key, FontFileType fileType)
	{
		ObjectKey = key;
		FileType = fileType;
	}
}
