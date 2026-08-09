using System;
using System.Collections.Generic;
using System.IO;

namespace UglyToad.PdfPig.Fonts.SystemFonts;

internal sealed class LinuxSystemFontLister : ISystemFontLister
{
	public IEnumerable<SystemFontRecord> GetAllFonts()
	{
		List<string> list = new List<string> { "/usr/local/fonts", "/usr/local/share/fonts", "/usr/share/fonts", "/usr/X11R6/lib/X11/fonts" };
		try
		{
			string environmentVariable = Environment.GetEnvironmentVariable("$HOME");
			if (string.IsNullOrWhiteSpace(environmentVariable))
			{
				environmentVariable = Environment.GetEnvironmentVariable("HOME");
			}
			if (!string.IsNullOrWhiteSpace(environmentVariable))
			{
				list.Add(environmentVariable + "/.fonts");
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
				files = Directory.GetFiles(item, "*.*", SearchOption.AllDirectories);
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
