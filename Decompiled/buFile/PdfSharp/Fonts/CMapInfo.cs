#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Fonts;

internal class CMapInfo
{
	internal OpenTypeDescriptor _descriptor;

	public char MinChar = '\uffff';

	public char MaxChar = '\0';

	public Dictionary<char, int> CharacterToGlyphIndex = new Dictionary<char, int>();

	public Dictionary<int, object> GlyphIndices = new Dictionary<int, object>();

	public char[] Chars
	{
		get
		{
			char[] array = new char[CharacterToGlyphIndex.Count];
			CharacterToGlyphIndex.Keys.CopyTo(array, 0);
			Array.Sort(array);
			return array;
		}
	}

	public CMapInfo(OpenTypeDescriptor descriptor)
	{
		Debug.Assert(descriptor != null);
		_descriptor = descriptor;
	}

	public void AddChars(string text)
	{
		if (text == null)
		{
			return;
		}
		bool symbol = _descriptor.FontFace.cmap.symbol;
		int length = text.Length;
		for (int i = 0; i < length; i++)
		{
			char c = text[i];
			if (!CharacterToGlyphIndex.ContainsKey(c))
			{
				char value = c;
				if (symbol)
				{
					value = (char)(c | (_descriptor.FontFace.os2.usFirstCharIndex & 0xFF00));
				}
				int num = _descriptor.CharCodeToGlyphIndex(value);
				CharacterToGlyphIndex.Add(c, num);
				GlyphIndices[num] = null;
				MinChar = (char)Math.Min(MinChar, c);
				MaxChar = (char)Math.Max(MaxChar, c);
			}
		}
	}

	public void AddGlyphIndices(string glyphIndices)
	{
		if (glyphIndices != null)
		{
			int length = glyphIndices.Length;
			for (int i = 0; i < length; i++)
			{
				int key = glyphIndices[i];
				GlyphIndices[key] = null;
			}
		}
	}

	internal void AddAnsiChars()
	{
		byte[] array = new byte[224];
		for (int i = 0; i < 224; i++)
		{
			array[i] = (byte)(i + 32);
		}
		string text = PdfEncoders.WinAnsiEncoding.GetString(array, 0, array.Length);
		AddChars(text);
	}

	internal bool Contains(char ch)
	{
		return CharacterToGlyphIndex.ContainsKey(ch);
	}

	public int[] GetGlyphIndices()
	{
		int[] array = new int[GlyphIndices.Count];
		GlyphIndices.Keys.CopyTo(array, 0);
		Array.Sort(array);
		return array;
	}
}
