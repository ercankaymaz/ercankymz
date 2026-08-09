using System.Collections.Generic;

namespace SharpGLTF.Memory;

internal static class EncodedArrayUtils
{
	public static void _CopyTo(this IEnumerable<int> src, IList<uint> dst, int dstOffset = 0)
	{
		using IEnumerator<int> enumerator = src.GetEnumerator();
		while (dstOffset < dst.Count && enumerator.MoveNext())
		{
			dst[dstOffset++] = (uint)enumerator.Current;
		}
	}

	public static void _CopyTo<T>(this IEnumerable<T> src, IList<T> dst, int dstOffset = 0)
	{
		using IEnumerator<T> enumerator = src.GetEnumerator();
		while (dstOffset < dst.Count && enumerator.MoveNext())
		{
			dst[dstOffset++] = enumerator.Current;
		}
	}

	public static int _FirstIndexOf<T>(this IReadOnlyList<T> src, T value)
	{
		EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
		int count = src.Count;
		for (int i = 0; i < count; i++)
		{
			if (equalityComparer.Equals(src[i], value))
			{
				return i;
			}
		}
		return -1;
	}
}
