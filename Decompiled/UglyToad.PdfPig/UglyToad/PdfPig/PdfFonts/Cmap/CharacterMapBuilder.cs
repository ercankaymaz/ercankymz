using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.PdfFonts.Cmap;

internal class CharacterMapBuilder
{
	private List<CidRange> cidRanges = new List<CidRange>();

	public CharacterIdentifierSystemInfo CharacterIdentifierSystemInfo { get; set; }

	public CharacterIdentifierSystemInfoBuilder SystemInfoBuilder { get; } = new CharacterIdentifierSystemInfoBuilder();

	public int WMode { get; set; }

	public string Name { get; set; }

	public string? Version { get; set; }

	public int Type { get; set; } = -1;

	public IReadOnlyList<CodespaceRange> CodespaceRanges { get; set; }

	public IReadOnlyList<CidCharacterMapping> CidCharacterMappings { get; set; }

	public IReadOnlyList<CidRange> CidRanges => cidRanges;

	public Dictionary<int, string> BaseFontCharacterMap { get; } = new Dictionary<int, string>();

	public void AddBaseFontCharacter(ReadOnlySpan<byte> bytes, ReadOnlySpan<byte> value)
	{
		AddBaseFontCharacter(bytes, CreateStringFromBytes(value));
	}

	public void AddBaseFontCharacter(ReadOnlySpan<byte> bytes, string value)
	{
		int codeFromArray = GetCodeFromArray(bytes);
		BaseFontCharacterMap[codeFromArray] = value;
	}

	public CMap Build()
	{
		return new CMap(GetCidSystemInfo(), Type, WMode, Name, Version, BaseFontCharacterMap ?? new Dictionary<int, string>(), CodespaceRanges ?? Array.Empty<CodespaceRange>(), CidRanges ?? Array.Empty<CidRange>(), CidCharacterMappings ?? Array.Empty<CidCharacterMapping>());
	}

	private CharacterIdentifierSystemInfo GetCidSystemInfo()
	{
		if (CharacterIdentifierSystemInfo.Registry != null)
		{
			return CharacterIdentifierSystemInfo;
		}
		if (SystemInfoBuilder.HasOrdering && SystemInfoBuilder.HasRegistry && SystemInfoBuilder.HasSupplement)
		{
			return new CharacterIdentifierSystemInfo(SystemInfoBuilder.Registry, SystemInfoBuilder.Ordering, SystemInfoBuilder.Supplement);
		}
		return CharacterIdentifierSystemInfo;
	}

	public void UseCMap(CMap other)
	{
		CodespaceRanges = Combine<CodespaceRange>(CodespaceRanges, other.CodespaceRanges);
		CidCharacterMappings = Combine(CidCharacterMappings, other.CidCharacterMappings.Values.ToList());
		cidRanges.AddRange(other.CidRanges);
		if (other.BaseFontCharacterMap == null)
		{
			return;
		}
		foreach (KeyValuePair<int, string> item in other.BaseFontCharacterMap)
		{
			BaseFontCharacterMap[item.Key] = item.Value;
		}
	}

	private static IReadOnlyList<T> Combine<T>(IReadOnlyList<T> a, IReadOnlyList<T> b)
	{
		if (a == null && b == null)
		{
			return new T[0];
		}
		if (a == null)
		{
			return b;
		}
		if (b == null)
		{
			return a;
		}
		int num = 0;
		T[] array = new T[a.Count + b.Count];
		foreach (T item in a)
		{
			array[num] = item;
			num++;
		}
		foreach (T item2 in b)
		{
			array[num] = item2;
			num++;
		}
		return new global::_003C_003Ez__ReadOnlyArray<T>(array);
	}

	private int GetCodeFromArray(ReadOnlySpan<byte> data)
	{
		int num = 0;
		for (int i = 0; i < data.Length; i++)
		{
			num <<= 8;
			num |= (data[i] + 256) % 256;
		}
		return num;
	}

	private static string CreateStringFromBytes(ReadOnlySpan<byte> bytes)
	{
		if (bytes.Length != 1)
		{
			return Encoding.BigEndianUnicode.GetString(bytes);
		}
		return OtherEncodings.BytesAsLatin1String(bytes);
	}

	public void AddCidRange(CidRange range)
	{
		cidRanges.Add(range);
	}
}
