using System;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public static class Conversions
{
	internal static class NativeMethods
	{
		public const uint NORM_IGNORECASE = 1u;

		public const uint NORM_IGNORENONSPACE = 2u;

		public const uint NORM_IGNORESYMBOLS = 4u;

		public const uint NORM_IGNOREKANATYPE = 65536u;

		public const uint NORM_IGNOREWIDTH = 131072u;

		public const uint SORT_STRINGSORT = 4096u;

		public const uint LCMAP_SORTKEY = 1024u;
	}

	private static readonly IDictionary<CompareOptions, uint> CompareOptionsToLcmapFlags;

	private static readonly IDictionary<uint, CompareOptions> LcmapFlagsToCompareOptions;

	static Conversions()
	{
		CompareOptionsToLcmapFlags = new Dictionary<CompareOptions, uint>
		{
			{
				CompareOptions.IgnoreCase,
				1u
			},
			{
				CompareOptions.IgnoreKanaType,
				65536u
			},
			{
				CompareOptions.IgnoreNonSpace,
				2u
			},
			{
				CompareOptions.IgnoreSymbols,
				4u
			},
			{
				CompareOptions.IgnoreWidth,
				131072u
			},
			{
				CompareOptions.StringSort,
				4096u
			}
		};
		LcmapFlagsToCompareOptions = InvertDictionary(CompareOptionsToLcmapFlags);
	}

	public static DateTime ConvertDoubleToDateTime(double d)
	{
		try
		{
			return LibraryHelpers.FromOADate(d);
		}
		catch (ArgumentException)
		{
			return (d < 0.0) ? DateTime.MinValue : DateTime.MaxValue;
		}
	}

	[CLSCompliant(false)]
	public static CompareOptions CompareOptionsFromLCMapFlags(uint lcmapFlags)
	{
		CompareOptions compareOptions = CompareOptions.None;
		foreach (uint key in LcmapFlagsToCompareOptions.Keys)
		{
			if (key == (lcmapFlags & key))
			{
				compareOptions |= LcmapFlagsToCompareOptions[key];
			}
		}
		return compareOptions;
	}

	[CLSCompliant(false)]
	public static uint LCMapFlagsFromCompareOptions(CompareOptions compareOptions)
	{
		uint num = 0u;
		foreach (CompareOptions key in CompareOptionsToLcmapFlags.Keys)
		{
			if (key == (compareOptions & key))
			{
				num |= CompareOptionsToLcmapFlags[key];
			}
		}
		return num;
	}

	private static IDictionary<TKey, TValue> InvertDictionary<TValue, TKey>(ICollection<KeyValuePair<TValue, TKey>> dict)
	{
		Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(dict.Count);
		foreach (KeyValuePair<TValue, TKey> item in dict)
		{
			dictionary.Add(item.Value, item.Key);
		}
		return dictionary;
	}
}
