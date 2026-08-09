using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.PdfFonts.Cmap;

internal sealed class CMap
{
	private readonly bool hasEmptyCodespace;

	private readonly int minCodeLength = 4;

	private readonly int maxCodeLength;

	public CharacterIdentifierSystemInfo Info { get; }

	public int Type { get; }

	public string Name { get; }

	public string? Version { get; }

	public IReadOnlyDictionary<int, string> BaseFontCharacterMap { get; }

	public IReadOnlyList<CodespaceRange> CodespaceRanges { get; }

	public IReadOnlyList<CidRange> CidRanges { get; }

	public IReadOnlyDictionary<int, CidCharacterMapping> CidCharacterMappings { get; }

	public WritingMode WritingMode { get; }

	public bool HasCidMappings
	{
		get
		{
			if (CidCharacterMappings.Count <= 0)
			{
				return CidRanges.Count > 0;
			}
			return true;
		}
	}

	public bool HasUnicodeMappings => BaseFontCharacterMap.Count > 0;

	public CMap(CharacterIdentifierSystemInfo info, int type, int wMode, string name, string? version, IReadOnlyDictionary<int, string> baseFontCharacterMap, IReadOnlyList<CodespaceRange> codespaceRanges, IReadOnlyList<CidRange> cidRanges, IReadOnlyList<CidCharacterMapping> cidCharacterMappings)
	{
		if (cidCharacterMappings == null)
		{
			throw new ArgumentNullException("cidCharacterMappings");
		}
		Info = info;
		Type = type;
		WritingMode = (WritingMode)wMode;
		Name = name;
		Version = version;
		BaseFontCharacterMap = baseFontCharacterMap ?? throw new ArgumentNullException("baseFontCharacterMap");
		CodespaceRanges = codespaceRanges ?? throw new ArgumentNullException("codespaceRanges");
		CidRanges = cidRanges ?? throw new ArgumentNullException("cidRanges");
		if (CodespaceRanges.Count > 0)
		{
			maxCodeLength = CodespaceRanges.Max((CodespaceRange x) => x.CodeLength);
			minCodeLength = CodespaceRanges.Min((CodespaceRange x) => x.CodeLength);
		}
		else
		{
			hasEmptyCodespace = true;
		}
		Dictionary<int, CidCharacterMapping> dictionary = new Dictionary<int, CidCharacterMapping>();
		foreach (CidCharacterMapping cidCharacterMapping in cidCharacterMappings)
		{
			dictionary[cidCharacterMapping.SourceCharacterCode] = cidCharacterMapping;
		}
		CidCharacterMappings = dictionary;
	}

	public bool TryConvertToUnicode(int code, [NotNullWhen(true)] out string? result)
	{
		return BaseFontCharacterMap.TryGetValue(code, out result);
	}

	public int ConvertToCid(int code)
	{
		if (CidCharacterMappings.TryGetValue(code, out var value))
		{
			return value.DestinationCid;
		}
		foreach (CidRange cidRange in CidRanges)
		{
			if (cidRange.TryMap(code, out var cidValue))
			{
				return cidValue;
			}
		}
		return 0;
	}

	public override string ToString()
	{
		return Name;
	}

	public int ReadCode(IInputBytes bytes, bool useLenientParsing)
	{
		long currentOffset = bytes.CurrentOffset;
		if (hasEmptyCodespace)
		{
			byte[] array = new byte[minCodeLength];
			bytes.Read(array);
			return ((ReadOnlySpan<byte>)array).Slice(0, minCodeLength).ToInt();
		}
		byte[] array2 = new byte[maxCodeLength];
		array2[0] = bytes.CurrentByte;
		for (int i = 1; i < minCodeLength; i++)
		{
			if (bytes.IsAtEnd())
			{
				break;
			}
			array2[i] = ReadByte(bytes, useLenientParsing);
		}
		for (int j = minCodeLength - 1; j < maxCodeLength; j++)
		{
			int num = j + 1;
			foreach (CodespaceRange codespaceRange in CodespaceRanges)
			{
				if (codespaceRange.IsFullMatch(array2, num))
				{
					return ByteArrayToInt(array2.AsSpan(0, num));
				}
			}
			if (num < maxCodeLength)
			{
				array2[num] = ReadByte(bytes, useLenientParsing);
			}
		}
		if (useLenientParsing)
		{
			bytes.Seek(currentOffset);
			for (int k = 0; k < minCodeLength; k++)
			{
				array2[k] = ReadByte(bytes, useLenientParsing);
			}
			return ByteArrayToInt(array2.AsSpan(0, minCodeLength));
		}
		throw new PdfDocumentFormatException($"CMap is invalid, min code length was {minCodeLength}, max was {maxCodeLength}. Bytes: {BitConverter.ToString(array2)}.");
	}

	private static byte ReadByte(IInputBytes bytes, bool useLenientParsing)
	{
		if (!bytes.MoveNext())
		{
			if (useLenientParsing)
			{
				return 0;
			}
			throw new InvalidOperationException("Read byte called on input bytes which was at end of byte set. Current offset: " + bytes.CurrentOffset);
		}
		return bytes.CurrentByte;
	}

	private static int ByteArrayToInt(ReadOnlySpan<byte> data)
	{
		int num = 0;
		for (int i = 0; i < data.Length; i++)
		{
			num <<= 8;
			num |= data[i] & 0xFF;
		}
		return num;
	}
}
