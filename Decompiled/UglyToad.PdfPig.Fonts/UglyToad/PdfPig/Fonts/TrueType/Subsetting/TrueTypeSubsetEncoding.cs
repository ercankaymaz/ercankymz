using System.Collections.Generic;

namespace UglyToad.PdfPig.Fonts.TrueType.Subsetting;

public class TrueTypeSubsetEncoding
{
	public IReadOnlyList<char> Characters { get; }

	public TrueTypeSubsetEncoding(IReadOnlyList<char> characters)
	{
		Characters = characters;
	}
}
