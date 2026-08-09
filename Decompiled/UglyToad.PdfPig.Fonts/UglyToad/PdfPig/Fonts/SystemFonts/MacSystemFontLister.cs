using System;
using System.Collections.Generic;
using System.IO;

namespace UglyToad.PdfPig.Fonts.SystemFonts;

internal sealed class MacSystemFontLister : ISystemFontLister
{
	public IEnumerable<SystemFontRecord> GetAllFonts()
	{
		List<string> list = new List<string> { "/Library/Fonts/", "/System/Library/Fonts/", "/Network/Library/Fonts/" };
		try
		{
			string environmentVariable = Environment.GetEnvironmentVariable("$HOME");
			if (!string.IsNullOrWhiteSpace(environmentVariable))
			{
				list.Add(environmentVariable + "/Library/Fonts");
			}
		}
		catch
		{
		}
		foreach (string item in list)
		{
			try
			{
				if (!Directory.Exists(item))
				{
					continue;
				}
			}
			catch
			{
				continue;
			}
			string[] files;
			try
			{
				files = Directory.GetFiles(item);
			}
			catch
			{
				continue;
			}
			string[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				if (SystemFontRecord.TryCreate(array[i], out var type))
				{
					yield return type;
				}
			}
		}
	}
}
