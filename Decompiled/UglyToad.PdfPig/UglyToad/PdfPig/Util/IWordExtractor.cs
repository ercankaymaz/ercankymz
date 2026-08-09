using System.Collections.Generic;
using UglyToad.PdfPig.Content;

namespace UglyToad.PdfPig.Util;

public interface IWordExtractor
{
	IEnumerable<Word> GetWords(IReadOnlyList<Letter> letters);
}
