using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.PdfFonts.Cmap;

internal sealed class CMapLocalCache
{
	private readonly object cacheLock = new object();

	private readonly Dictionary<string, Dictionary<Guid, CMap>> _cache = new Dictionary<string, Dictionary<Guid, CMap>>();

	private readonly ILookupFilterProvider _filterProvider;

	private readonly IPdfTokenScanner _scanner;

	private static ReadOnlySpan<byte> cmapNameTag => "/CMapName "u8;

	public CMapLocalCache(ILookupFilterProvider filterProvider, IPdfTokenScanner scanner)
	{
		_filterProvider = filterProvider;
		_scanner = scanner;
	}

	public bool TryGet(string name, [NotNullWhen(true)] out CMap? result)
	{
		return CMapCache.TryGet(name, out result);
	}

	private static Guid GetGuid(ReadOnlySpan<byte> bytes)
	{
		return new Guid(MurmurHash3.Compute_x64_128(bytes));
	}

	public bool TryGet(StreamToken token, [NotNullWhen(true)] out CMap? result)
	{
		if (token.Data.IsEmpty)
		{
			result = null;
			return false;
		}
		Memory<byte> memory = token.Decode(_filterProvider, _scanner);
		if (!TryGetNameFast(memory.Span, out string name))
		{
			result = CMapCache.Parse(new MemoryInputBytes(memory));
			return true;
		}
		Guid guid = GetGuid(memory.Span);
		lock (cacheLock)
		{
			if (!_cache.TryGetValue(name, out Dictionary<Guid, CMap> value))
			{
				value = new Dictionary<Guid, CMap>();
				_cache[name] = value;
			}
			if (value.TryGetValue(guid, out result))
			{
				return true;
			}
			result = CMapCache.Parse(new MemoryInputBytes(memory));
			value[guid] = result;
		}
		return true;
	}

	private static bool TryGetNameFast(ReadOnlySpan<byte> bytes, out string? name)
	{
		name = null;
		int num = bytes.IndexOf(cmapNameTag);
		if (num <= -1)
		{
			return false;
		}
		num += cmapNameTag.Length;
		int num2 = bytes.Slice(num).IndexOf("def"u8);
		if (num2 <= -1)
		{
			return false;
		}
		name = Encoding.UTF8.GetString(bytes.Slice(num, num2 - 1));
		return true;
	}
}
