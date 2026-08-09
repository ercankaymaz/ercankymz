using System.Collections.Generic;

namespace UglyToad.PdfPig.Fonts.SystemFonts;

internal interface ISystemFontLister
{
	IEnumerable<SystemFontRecord> GetAllFonts();
}
