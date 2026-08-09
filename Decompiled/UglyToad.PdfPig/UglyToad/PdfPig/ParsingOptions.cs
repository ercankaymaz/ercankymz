using System.Collections.Generic;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Logging;

namespace UglyToad.PdfPig;

public sealed class ParsingOptions
{
	public static ParsingOptions LenientParsingOff { get; } = new ParsingOptions
	{
		UseLenientParsing = false
	};

	public bool ClipPaths { get; set; }

	public bool UseLenientParsing { get; set; } = true;

	public ILog Logger { get; set; } = new NoOpLog();

	public string Password { get; set; } = string.Empty;

	public List<string> Passwords { get; set; } = new List<string>();

	public bool SkipMissingFonts { get; set; }

	public IFilterProvider? FilterProvider { get; set; }
}
