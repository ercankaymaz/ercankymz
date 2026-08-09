using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.PdfFonts.Cmap;

internal static class CMapUtils
{
	public static int ToInt(this ReadOnlySpan<byte> data)
	{
		int num = 0;
		for (int i = 0; i < data.Length; i++)
		{
			num <<= 8;
			num |= data[i] & 0xFF;
		}
		return num;
	}

	public static void PutAll<TKey, TValue>(this Dictionary<TKey, TValue> target, IReadOnlyDictionary<TKey, TValue> source) where TKey : notnull
	{
		foreach (KeyValuePair<TKey, TValue> item in source)
		{
			target[item.Key] = item.Value;
		}
	}
}
