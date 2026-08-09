using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis;

public static class ArraySegmentExtensions
{
	public static ArraySegment<T> Take<T>(this ArraySegment<T> source, int count)
	{
		return new ArraySegment<T>(source.Array, source.Offset, count);
	}

	public static ArraySegment<T> Skip<T>(this ArraySegment<T> source, int count)
	{
		return new ArraySegment<T>(source.Array, source.Offset + count, source.Count - count);
	}

	public static void Sort<T>(this ArraySegment<T> source, IComparer<T> comparer)
	{
		Array.Sort(source.Array, source.Offset, source.Count, comparer);
	}

	public static T GetAt<T>(this ArraySegment<T> source, int index)
	{
		return source.Array[source.Offset + index];
	}
}
