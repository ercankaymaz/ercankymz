using System;
using System.Collections.Generic;
using System.IO;

namespace UglyToad.PdfPig.Fonts.SystemFonts;

internal sealed class WindowsSystemFontLister : ISystemFontLister
{
	public IEnumerable<SystemFontRecord> GetAllFonts()
	{
		string winDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
		string fonts = Path.Combine(winDir, "Fonts");
		string[] array;
		if (Directory.Exists(fonts))
		{
			string[] files = Directory.GetFiles(fonts);
			array = files;
			for (int i = 0; i < array.Length; i++)
			{
				if (SystemFontRecord.TryCreate(array[i], out var type))
				{
					yield return type;
				}
			}
		}
		if (!Directory.Exists(Path.Combine(winDir, "PSFonts")))
		{
			yield break;
		}
		string[] files2 = Directory.GetFiles(fonts);
		array = files2;
		for (int i = 0; i < array.Length; i++)
		{
			if (SystemFontRecord.TryCreate(array[i], out var type2))
			{
				yield return type2;
			}
		}
	}
}
