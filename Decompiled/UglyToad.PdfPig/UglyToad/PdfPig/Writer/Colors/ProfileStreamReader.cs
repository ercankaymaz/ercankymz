using System;
using System.IO;
using System.Linq;
using UglyToad.PdfPig.PdfFonts.Parser;

namespace UglyToad.PdfPig.Writer.Colors;

internal static class ProfileStreamReader
{
	public static byte[] GetSRgb2014()
	{
		string text = typeof(ProfileStreamReader).Assembly.GetManifestResourceNames().FirstOrDefault((string x) => x.EndsWith("sRGB2014.icc", StringComparison.InvariantCultureIgnoreCase));
		if (text == null)
		{
			throw new InvalidOperationException("Could not find the sRGB ICC color profile stream.");
		}
		using Stream stream = typeof(CMapParser).Assembly.GetManifestResourceStream(text);
		using MemoryStream memoryStream = new MemoryStream();
		stream?.CopyTo(memoryStream);
		return memoryStream.ToArray();
	}
}
