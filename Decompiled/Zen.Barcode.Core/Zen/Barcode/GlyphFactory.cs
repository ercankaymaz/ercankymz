using System;
using System.Collections.Generic;

namespace Zen.Barcode;

public abstract class GlyphFactory
{
	private Dictionary<char, BarGlyph> _rawLookup;

	private Dictionary<char, Glyph> _lookup;

	public virtual int GetRawCharIndex(char character)
	{
		int num = 0;
		BarGlyph[] glyphs = GetGlyphs();
		foreach (BarGlyph barGlyph in glyphs)
		{
			if (barGlyph.Character == character)
			{
				return num;
			}
			num++;
		}
		throw new ArgumentException("Invalid character.");
	}

	public virtual BarGlyph GetRawGlyph(int index)
	{
		return GetGlyphs()[index];
	}

	public virtual BarGlyph GetRawGlyph(char character)
	{
		EnsureRawGlyphLookup();
		return _rawLookup[character];
	}

	public virtual int GetRawGlyphIndex(BarGlyph glyph)
	{
		int result = -1;
		BarGlyph[] glyphs = GetGlyphs();
		for (int i = 0; i < glyphs.Length; i++)
		{
			if (glyphs[i] == glyph)
			{
				result = i;
				break;
			}
		}
		return result;
	}

	public virtual Glyph[] GetGlyphs(char character)
	{
		return GetGlyphs(character, allowComposite: false);
	}

	public virtual Glyph[] GetGlyphs(char character, bool allowComposite)
	{
		EnsureFullLookup();
		Glyph glyph = _lookup[character];
		if (glyph is CompositeGlyph compositeGlyph && !allowComposite)
		{
			return new Glyph[2] { compositeGlyph.First, compositeGlyph.Second };
		}
		return new Glyph[1] { glyph };
	}

	public virtual Glyph[] GetGlyphs(string text)
	{
		return GetGlyphs(text, allowComposite: false);
	}

	public virtual Glyph[] GetGlyphs(string text, bool allowComposite)
	{
		if (string.IsNullOrEmpty(text))
		{
			return new Glyph[0];
		}
		List<Glyph> list = new List<Glyph>();
		foreach (char character in text)
		{
			list.AddRange(GetGlyphs(character, allowComposite));
		}
		return list.ToArray();
	}

	protected abstract BarGlyph[] GetGlyphs();

	protected abstract CompositeGlyph[] GetCompositeGlyphs();

	private void EnsureRawGlyphLookup()
	{
		if (_rawLookup == null)
		{
			_rawLookup = new Dictionary<char, BarGlyph>();
			BarGlyph[] glyphs = GetGlyphs();
			BarGlyph[] array = glyphs;
			foreach (BarGlyph barGlyph in array)
			{
				_rawLookup.Add(barGlyph.Character, barGlyph);
			}
		}
	}

	private void EnsureFullLookup()
	{
		if (_lookup != null)
		{
			return;
		}
		_lookup = new Dictionary<char, Glyph>();
		CompositeGlyph[] compositeGlyphs = GetCompositeGlyphs();
		CompositeGlyph[] array = compositeGlyphs;
		foreach (CompositeGlyph compositeGlyph in array)
		{
			_lookup.Add(compositeGlyph.Character, compositeGlyph);
		}
		BarGlyph[] glyphs = GetGlyphs();
		foreach (BarGlyph barGlyph in glyphs)
		{
			if (!_lookup.ContainsKey(barGlyph.Character))
			{
				_lookup.Add(barGlyph.Character, barGlyph);
			}
		}
	}
}
