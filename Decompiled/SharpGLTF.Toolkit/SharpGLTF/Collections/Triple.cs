using System;
using System.Collections;
using System.Collections.Generic;

namespace SharpGLTF.Collections;

public readonly struct Triple<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IEquatable<Triple<T>>
{
	public readonly T A;

	public readonly T B;

	public readonly T C;

	public int Count => 3;

	public T this[int index] => index switch
	{
		0 => A, 
		1 => B, 
		2 => C, 
		_ => throw new ArgumentOutOfRangeException("index"), 
	};

	public static implicit operator Triple<T>(in (T A, T B, T C) triple)
	{
		return new Triple<T>(triple.A, triple.B, triple.C);
	}

	public Triple(T a, T b, T c)
	{
		A = a;
		B = b;
		C = c;
	}

	public override int GetHashCode()
	{
		int num = 0;
		int num2 = num;
		T a = A;
		num = num2 ^ ((a != null) ? a.GetHashCode() : 0);
		int num3 = num;
		a = B;
		num = num3 ^ ((a != null) ? a.GetHashCode() : 0);
		int num4 = num;
		a = C;
		return num4 ^ ((a != null) ? a.GetHashCode() : 0);
	}

	public override bool Equals(object obj)
	{
		if (obj is Triple<T>)
		{
			return Equals((Triple<T>)obj);
		}
		return false;
	}

	public bool Equals(Triple<T> other)
	{
		if (!A.Equals(other.A))
		{
			return false;
		}
		if (!B.Equals(other.B))
		{
			return false;
		}
		if (!C.Equals(other.C))
		{
			return false;
		}
		return true;
	}

	public static bool operator ==(in Triple<T> left, in Triple<T> right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(in Triple<T> left, in Triple<T> right)
	{
		return !left.Equals(right);
	}

	public IEnumerator<T> GetEnumerator()
	{
		yield return A;
		yield return B;
		yield return C;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		yield return A;
		yield return B;
		yield return C;
	}
}
