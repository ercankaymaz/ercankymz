using System;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.Common.Helpers;

internal static class RuntimeUtility
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Swap<T>(ref T a, ref T b)
	{
		T val = a;
		a = b;
		b = val;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Swap<T>(ref Span<T> a, ref Span<T> b)
	{
		Span<T> span = a;
		a = b;
		b = span;
	}
}
