using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Fonts;

internal static class GlyphListFactory
{
	private static readonly char[] Semicolon = new char[1] { ';' };

	public static GlyphList Get(params string[] listNames)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(listNames.Any((string n) => string.Equals("glyphlist", n, StringComparison.OrdinalIgnoreCase)) ? 4300 : 0);
		foreach (string text in listNames)
		{
			using Stream stream = typeof(GlyphListFactory).Assembly.GetManifestResourceStream("UglyToad.PdfPig.Fonts.Resources.GlyphList." + text);
			if (stream == null)
			{
				throw new ArgumentException("No embedded glyph list resource was found with the name " + text + ".");
			}
			ReadInternal(stream, dictionary);
		}
		return new GlyphList(dictionary);
	}

	public static GlyphList Read(Stream stream)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		ReadInternal(stream, dictionary);
		return new GlyphList(dictionary);
	}

	private static void ReadInternal(Stream stream, Dictionary<string, string> result)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		using StreamReader streamReader = new StreamReader(stream);
		while (!streamReader.EndOfStream)
		{
			string text = streamReader.ReadLine();
			if (!string.IsNullOrWhiteSpace(text) && text[0] != '#')
			{
				string[] array = text.Split(Semicolon, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != 2)
				{
					throw new InvalidOperationException("The line in the glyph list did not match the expected format. Line was: " + text);
				}
				string key = array[0];
				StringSplitter stringSplitter = new StringSplitter(array[1].AsSpan(), ' ');
				string text2 = string.Empty;
				ReadOnlySpan<char> result2;
				while (stringSplitter.TryRead(out result2))
				{
					int utf = int.Parse(result2.ToString(), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
					text2 += char.ConvertFromUtf32(utf);
				}
				result[key] = text2;
			}
		}
	}
}
