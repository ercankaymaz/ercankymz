using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SharpGLTF.Collections;

internal sealed class ReferenceComparer<T> : IEqualityComparer<T> where T : class
{
	public static readonly ReferenceComparer<T> Instance = new ReferenceComparer<T>();

	private ReferenceComparer()
	{
	}

	public bool Equals(T x, T y)
	{
		return x == y;
	}

	public int GetHashCode(T obj)
	{
		return RuntimeHelpers.GetHashCode(obj);
	}
}
