using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.Json.Nodes;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF;

internal static class _Extensions
{
	private readonly struct _ListSelect<TSource, TResult>(IReadOnlyList<TSource> list, Func<TSource, TResult> selector) : IReadOnlyList<TResult>, IEnumerable<TResult>, IEnumerable, IReadOnlyCollection<TResult>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		private readonly IReadOnlyList<TSource> _List = list;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Func<TSource, TResult> _Selector = selector;

		public TResult this[int index] => _Selector(_List[index]);

		public int Count => _List.Count;

		public IEnumerator<TResult> GetEnumerator()
		{
			foreach (TSource item in _List)
			{
				yield return _Selector(item);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (TSource item in _List)
			{
				yield return _Selector(item);
			}
		}
	}

	private readonly struct _CollectionSelect<TSource, TResult>(IReadOnlyCollection<TSource> list, Func<TSource, TResult> selector) : IReadOnlyCollection<TResult>, IEnumerable<TResult>, IEnumerable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		private readonly IReadOnlyCollection<TSource> _List = list;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Func<TSource, TResult> _Selector = selector;

		public int Count => _List.Count;

		public IEnumerator<TResult> GetEnumerator()
		{
			foreach (TSource item in _List)
			{
				yield return _Selector(item);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (TSource item in _List)
			{
				yield return _Selector(item);
			}
		}
	}

	private const float _UnitLengthThresholdVec3 = 0.00674f;

	private const float _UnitLengthThresholdVec4 = 0.00769f;

	private const float _UnitSumThresholdStep = 0.0039216f;

	internal static bool IsMultipleOf(this int value, int mult)
	{
		return value % mult == 0;
	}

	internal static int WordPadded(this int length)
	{
		int num = length & 3;
		return length + ((num != 0) ? (4 - num) : 0);
	}

	internal static bool _IsFinite(this float value)
	{
		if (!float.IsNaN(value))
		{
			return !float.IsInfinity(value);
		}
		return false;
	}

	internal static bool _IsFinite(this Vector2 v)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		if (v.X._IsFinite())
		{
			return v.Y._IsFinite();
		}
		return false;
	}

	internal static bool _IsFinite(this Vector3 v)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (v.X._IsFinite() && v.Y._IsFinite())
		{
			return v.Z._IsFinite();
		}
		return false;
	}

	internal static bool _IsFinite(this in Vector4 v)
	{
		if (v.X._IsFinite() && v.Y._IsFinite() && v.Z._IsFinite())
		{
			return v.W._IsFinite();
		}
		return false;
	}

	internal static bool _IsFinite(this in Matrix4x4 v)
	{
		if (!v.M11._IsFinite() || !v.M12._IsFinite() || !v.M13._IsFinite() || !v.M14._IsFinite())
		{
			return false;
		}
		if (!v.M21._IsFinite() || !v.M22._IsFinite() || !v.M23._IsFinite() || !v.M24._IsFinite())
		{
			return false;
		}
		if (!v.M31._IsFinite() || !v.M32._IsFinite() || !v.M33._IsFinite() || !v.M34._IsFinite())
		{
			return false;
		}
		if (!v.M41._IsFinite() || !v.M42._IsFinite() || !v.M43._IsFinite() || !v.M44._IsFinite())
		{
			return false;
		}
		return true;
	}

	internal static bool _IsFinite(this Quaternion v)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		if (v.X._IsFinite() && v.Y._IsFinite() && v.Z._IsFinite())
		{
			return v.W._IsFinite();
		}
		return false;
	}

	internal static Vector3 WithLength(this Vector3 v, float len)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return Vector3.Normalize(v) * len;
	}

	internal static bool IsNormalized(this Vector3 normal)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if (!normal._IsFinite())
		{
			return false;
		}
		return Math.Abs(((Vector3)(ref normal)).Length() - 1f) <= 0.00674f;
	}

	internal static bool IsNormalized(this Quaternion rotation)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if (!rotation._IsFinite())
		{
			return false;
		}
		return Math.Abs(((Quaternion)(ref rotation)).Length() - 1f) <= 0.00769f;
	}

	internal static Quaternion AsQuaternion(this Vector4 v)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		return new Quaternion(v.X, v.Y, v.Z, v.W);
	}

	internal static Quaternion Sanitized(this Quaternion q)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		if (!q.IsNormalized())
		{
			return Quaternion.Normalize(q);
		}
		return q;
	}

	internal static bool IsInRange(this Vector3 value, Vector3 min, Vector3 max)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if (value.X < min.X || value.X > max.X)
		{
			return false;
		}
		if (value.Y < min.Y || value.Y > max.Y)
		{
			return false;
		}
		if (value.Z < min.Z || value.Z > max.Z)
		{
			return false;
		}
		return true;
	}

	internal static bool IsInRange(this Vector4 value, Vector4 min, Vector4 max)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		if (value.X < min.X || value.X > max.X)
		{
			return false;
		}
		if (value.Y < min.Y || value.Y > max.Y)
		{
			return false;
		}
		if (value.Z < min.Z || value.Z > max.Z)
		{
			return false;
		}
		if (value.W < min.W || value.W > max.W)
		{
			return false;
		}
		return true;
	}

	internal static bool IsRound(this Vector4 value)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		Vector4 val = default(Vector4);
		((Vector4)(ref val))._002Ector((float)(int)value.X, (float)(int)value.Y, (float)(int)value.Z, (float)(int)value.W);
		return value - val == Vector4.Zero;
	}

	internal static void ValidateNormal(this Vector3 normal, string msg)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (!normal._IsFinite())
		{
			throw new NotFiniteNumberException(msg + " is invalid.");
		}
		if (!normal.IsNormalized())
		{
			throw new ArithmeticException(msg + " is not unit length.");
		}
	}

	internal static void ValidateTangent(this Vector4 tangent, string msg)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		if (tangent.W != 1f && tangent.W != -1f)
		{
			throw new ArithmeticException(msg);
		}
		ValidateNormal(new Vector3(tangent.X, tangent.Y, tangent.Z), msg);
	}

	internal static Vector3 SanitizeNormal(this Vector3 normal)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if (normal == Vector3.Zero)
		{
			return Vector3.UnitX;
		}
		if (!normal.IsNormalized())
		{
			return Vector3.Normalize(normal);
		}
		return normal;
	}

	internal static bool IsValidTangent(this Vector4 tangent)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		if (tangent.W != 1f && tangent.W != -1f)
		{
			return false;
		}
		return _Extensions.IsNormalized(new Vector3(tangent.X, tangent.Y, tangent.Z));
	}

	internal static Vector4 SanitizeTangent(this Vector4 tangent)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = SanitizeNormal(new Vector3(tangent.X, tangent.Y, tangent.Z));
		float num = (float.IsNaN(tangent.W) ? 1f : tangent.W);
		return new Vector4(val, (float)((num > 0f) ? 1 : (-1)));
	}

	internal static Matrix4x4 Inverse(this in Matrix4x4 src)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		Matrix4x4 result = default(Matrix4x4);
		if (!Matrix4x4.Invert(src, ref result))
		{
			Guard.IsTrue(target: false, "src", "Matrix cannot be inverted.");
		}
		if (src.M44 == 1f)
		{
			result.M44 = 1f;
		}
		return result;
	}

	internal static bool IsValid(this in Matrix4x4 matrix, Matrix4x4Factory.MatrixCheck check, float tolerance = 0f)
	{
		return Matrix4x4Factory.IsValid(in matrix, check, tolerance);
	}

	internal static bool StartsWith(this string text, char c)
	{
		return text.StartsWith(c.ToString());
	}

	internal static string Replace(this string text, string oldText, string newText, StringComparison comparison)
	{
		if (comparison == StringComparison.Ordinal)
		{
			return text.Replace(oldText, newText);
		}
		throw new NotImplementedException();
	}

	internal static int IndexOf(this string text, string value, StringComparison comparison)
	{
		switch (comparison)
		{
		case StringComparison.InvariantCultureIgnoreCase:
		case StringComparison.OrdinalIgnoreCase:
			text = text.ToUpperInvariant();
			value = value.ToUpperInvariant();
			break;
		case StringComparison.CurrentCultureIgnoreCase:
			text = text.ToUpper();
			value = value.ToUpper();
			break;
		}
		return text.IndexOf(value);
	}

	internal static int IndexOf(this string text, char value, StringComparison comparison)
	{
		switch (comparison)
		{
		case StringComparison.InvariantCultureIgnoreCase:
		case StringComparison.OrdinalIgnoreCase:
			text = text.ToUpperInvariant();
			value = char.ToUpperInvariant(value);
			break;
		case StringComparison.CurrentCultureIgnoreCase:
			text = text.ToUpper();
			value = char.ToUpper(value);
			break;
		}
		return text.IndexOf(value);
	}

	public static bool AreSameReference<T>(this (T x, T y) refs, out bool result) where T : class
	{
		if (refs.x == refs.y)
		{
			result = true;
			return true;
		}
		if (refs.x == null)
		{
			result = false;
			return true;
		}
		if (refs.y == null)
		{
			result = false;
			return true;
		}
		result = false;
		return false;
	}

	internal static bool Contains(this string self, string value, StringComparison comparisonType)
	{
		switch (comparisonType)
		{
		case StringComparison.InvariantCultureIgnoreCase:
		case StringComparison.OrdinalIgnoreCase:
			return self.ToUpperInvariant().Contains(value.ToUpperInvariant());
		case StringComparison.CurrentCultureIgnoreCase:
			return self.ToUpper().Contains(value.ToUpper());
		default:
			return self.Contains(value);
		}
	}

	internal static int GetHashCode(this string text, StringComparison comparisonType)
	{
		switch (comparisonType)
		{
		case StringComparison.InvariantCultureIgnoreCase:
		case StringComparison.OrdinalIgnoreCase:
			return text.ToUpperInvariant().GetHashCode();
		case StringComparison.CurrentCultureIgnoreCase:
			return text.ToUpper().GetHashCode();
		default:
			return text.GetHashCode();
		}
	}

	internal static int GetContentHashCode<T>(this IEnumerable<T> collection, int count = int.MaxValue)
	{
		if (collection == null)
		{
			return 0;
		}
		int num = 0;
		if (collection is IReadOnlyList<T> readOnlyList)
		{
			count = Math.Min(count, readOnlyList.Count);
			for (int i = 0; i < count; i++)
			{
				num ^= readOnlyList[i]?.GetHashCode() ?? 0;
				num *= 17;
			}
			return num;
		}
		foreach (T item in collection.Take(count))
		{
			num ^= item?.GetHashCode() ?? 0;
			num *= 17;
		}
		return num;
	}

	internal static ArraySegment<T> Slice<T>(this T[] array, int offset)
	{
		return new ArraySegment<T>(array, offset, array.Length - offset);
	}

	internal static ArraySegment<T> Slice<T>(this ArraySegment<T> array, int offset)
	{
		return new ArraySegment<T>(array.Array, array.Offset + offset, array.Count - offset);
	}

	internal static ArraySegment<T> Slice<T>(this ArraySegment<T> array, int offset, int count)
	{
		return new ArraySegment<T>(array.Array, array.Offset + offset, count);
	}

	internal static T[] CloneArray<T>(this T[] srcArray)
	{
		if (srcArray == null)
		{
			return null;
		}
		T[] array = new T[srcArray.Length];
		srcArray.CopyTo(array, 0);
		return array;
	}

	internal static void Fill<T>(this IList<T> collection, T value)
	{
		for (int i = 0; i < collection.Count; i++)
		{
			collection[i] = value;
		}
	}

	internal static void Fill<T>(this T[] array, T value)
	{
		MemoryExtensions.AsSpan(array).Fill(value);
	}

	internal static IReadOnlyList<T> EnsureList<T>(this IEnumerable<T> collection)
	{
		if (!(collection is IReadOnlyList<T> result))
		{
			return collection.ToList();
		}
		return result;
	}

	internal static bool IsEmpty<T>(this IReadOnlyList<T> list)
	{
		return list.Count == 0;
	}

	internal static int IndexOf<T>(this IReadOnlyList<T> collection, T value)
	{
		int count = collection.Count;
		for (int i = 0; i < count; i++)
		{
			if (object.Equals(collection[i], value))
			{
				return i;
			}
		}
		return -1;
	}

	internal static int IndexOf<T>(this IReadOnlyList<T> collection, Predicate<T> predicate)
	{
		int count = collection.Count;
		for (int i = 0; i < count; i++)
		{
			if (predicate(collection[i]))
			{
				return i;
			}
		}
		return -1;
	}

	internal static int IndexOf<T>(this IReadOnlyList<T> collection, T[] subset) where T : IEquatable<T>
	{
		int num = collection.Count - subset.Length;
		for (int i = 0; i < num; i++)
		{
			bool flag = false;
			for (int j = 0; j < subset.Length && collection[i + j].Equals(subset[j]); j++)
			{
				flag = true;
			}
			if (flag)
			{
				return i;
			}
		}
		return -1;
	}

	internal static void CopyTo<T>(this T[] src, int srcOffset, IList<T> dst, int dstOffset, int count)
	{
		ArraySegment<T> src2 = new ArraySegment<T>(src);
		src2.CopyTo(srcOffset, dst, dstOffset, count);
	}

	internal static void CopyTo<T>(this ArraySegment<T> src, int srcOffset, IList<T> dst, int dstOffset, int count)
	{
		if (dst is T[] destinationArray)
		{
			Array.Copy(src.Array, src.Offset + srcOffset, destinationArray, dstOffset, count);
			return;
		}
		for (int i = 0; i < count; i++)
		{
			dst[dstOffset + i] = src.Array[src.Offset + srcOffset + i];
		}
	}

	internal static void AddRange<Tin, Tout>(this IList<Tout> dst, IEnumerable<Tin> src, Converter<Tin, Tout> cvt)
	{
		foreach (Tin item in src)
		{
			dst.Add(cvt(item));
		}
	}

	internal static IEnumerable<T> ConcatElements<T>(this IEnumerable<T> collection, params T[] elements)
	{
		return collection.Concat(elements.Where((T item) => item != null));
	}

	public static void SanitizeNormals(this IList<Vector3> normals)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < normals.Count; i++)
		{
			if (!normals[i].IsNormalized())
			{
				normals[i] = normals[i].SanitizeNormal();
			}
		}
	}

	public static void SanitizeTangents(this IList<Vector4> tangents)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < tangents.Count; i++)
		{
			if (!tangents[i].IsValidTangent())
			{
				tangents[i] = tangents[i].SanitizeTangent();
			}
		}
	}

	public static IReadOnlyList<TResult> SelectList<TSource, TResult>(this IReadOnlyList<TSource> collection, Func<TSource, TResult> selector)
	{
		return new _ListSelect<TSource, TResult>(collection, selector);
	}

	public static IReadOnlyCollection<TResult> SelectCollection<TSource, TResult>(this IReadOnlyCollection<TSource> collection, Func<TSource, TResult> selector)
	{
		return new _CollectionSelect<TSource, TResult>(collection, selector);
	}

	public static string ToDebugString(this EncodingType encoding, DimensionType dimensions, bool normalized)
	{
		string text = string.Empty;
		switch (encoding)
		{
		case EncodingType.BYTE:
			text += "SByte";
			break;
		case EncodingType.FLOAT:
			text += "Float";
			break;
		case EncodingType.SHORT:
			text += "SShort";
			break;
		case EncodingType.UNSIGNED_BYTE:
			text += "UByte";
			break;
		case EncodingType.UNSIGNED_INT:
			text += "UInt";
			break;
		case EncodingType.UNSIGNED_SHORT:
			text += "UShort";
			break;
		}
		switch (dimensions)
		{
		case DimensionType.VEC2:
			text += "2";
			break;
		case DimensionType.VEC3:
			text += "3";
			break;
		case DimensionType.VEC4:
			text += "4";
			break;
		case DimensionType.MAT2:
			text += "2x2";
			break;
		case DimensionType.MAT3:
			text += "3x3";
			break;
		case DimensionType.MAT4:
			text += "4x4";
			break;
		}
		if (normalized)
		{
			text = "Norm" + text;
		}
		return text;
	}

	public static int ByteLength(this IndexEncodingType encoding)
	{
		return encoding switch
		{
			IndexEncodingType.UNSIGNED_BYTE => 1, 
			IndexEncodingType.UNSIGNED_SHORT => 2, 
			IndexEncodingType.UNSIGNED_INT => 4, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static int ByteLength(this EncodingType encoding)
	{
		return encoding switch
		{
			EncodingType.BYTE => 1, 
			EncodingType.SHORT => 2, 
			EncodingType.FLOAT => 4, 
			EncodingType.UNSIGNED_BYTE => 1, 
			EncodingType.UNSIGNED_SHORT => 2, 
			EncodingType.UNSIGNED_INT => 4, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static EncodingType ToComponent(this IndexEncodingType t)
	{
		return t switch
		{
			IndexEncodingType.UNSIGNED_BYTE => EncodingType.UNSIGNED_BYTE, 
			IndexEncodingType.UNSIGNED_SHORT => EncodingType.UNSIGNED_SHORT, 
			IndexEncodingType.UNSIGNED_INT => EncodingType.UNSIGNED_INT, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static IndexEncodingType ToIndex(this EncodingType t)
	{
		return t switch
		{
			EncodingType.UNSIGNED_BYTE => IndexEncodingType.UNSIGNED_BYTE, 
			EncodingType.UNSIGNED_SHORT => IndexEncodingType.UNSIGNED_SHORT, 
			EncodingType.UNSIGNED_INT => IndexEncodingType.UNSIGNED_INT, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static int DimCount(this DimensionType dimension)
	{
		return dimension switch
		{
			DimensionType.SCALAR => 1, 
			DimensionType.VEC2 => 2, 
			DimensionType.VEC3 => 3, 
			DimensionType.VEC4 => 4, 
			DimensionType.MAT2 => 4, 
			DimensionType.MAT3 => 9, 
			DimensionType.MAT4 => 16, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static DimensionType ToDimension(this int len)
	{
		return len switch
		{
			1 => DimensionType.SCALAR, 
			2 => DimensionType.VEC2, 
			3 => DimensionType.VEC3, 
			4 => DimensionType.VEC4, 
			9 => DimensionType.MAT3, 
			16 => DimensionType.MAT4, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static DimensionType ToDimension(this Type t)
	{
		if (t == typeof(sbyte))
		{
			return DimensionType.SCALAR;
		}
		if (t == typeof(byte))
		{
			return DimensionType.SCALAR;
		}
		if (t == typeof(short))
		{
			return DimensionType.SCALAR;
		}
		if (t == typeof(ushort))
		{
			return DimensionType.SCALAR;
		}
		if (t == typeof(int))
		{
			return DimensionType.SCALAR;
		}
		if (t == typeof(uint))
		{
			return DimensionType.SCALAR;
		}
		if (t == typeof(float))
		{
			return DimensionType.SCALAR;
		}
		if (t == typeof(double))
		{
			return DimensionType.SCALAR;
		}
		if (t == typeof(Vector2))
		{
			return DimensionType.VEC2;
		}
		if (t == typeof(Vector3))
		{
			return DimensionType.VEC3;
		}
		if (t == typeof(Vector4))
		{
			return DimensionType.VEC4;
		}
		if (t == typeof(Quaternion))
		{
			return DimensionType.VEC4;
		}
		if (t == typeof(Matrix4x4))
		{
			return DimensionType.MAT4;
		}
		throw new NotImplementedException();
	}

	public static int GetPrimitiveVertexSize(this PrimitiveType ptype)
	{
		return ptype switch
		{
			PrimitiveType.POINTS => 1, 
			PrimitiveType.LINES => 2, 
			PrimitiveType.LINE_LOOP => 2, 
			PrimitiveType.LINE_STRIP => 2, 
			PrimitiveType.TRIANGLES => 3, 
			PrimitiveType.TRIANGLE_FAN => 3, 
			PrimitiveType.TRIANGLE_STRIP => 3, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static IEnumerable<(int A, int B)> GetLinesIndices(this PrimitiveType ptype, int vertexCount)
	{
		return ptype.GetLinesIndices(from item in Enumerable.Range(0, vertexCount)
			select (uint)item);
	}

	public static IEnumerable<(int A, int B, int C)> GetTrianglesIndices(this PrimitiveType ptype, int vertexCount)
	{
		return ptype.GetTrianglesIndices(from item in Enumerable.Range(0, vertexCount)
			select (uint)item);
	}

	public static IEnumerable<(int A, int B)> GetLinesIndices(this PrimitiveType ptype, IEnumerable<uint> sourceIndices)
	{
		if (ptype == PrimitiveType.LINES)
		{
			using (IEnumerator<uint> ptr = sourceIndices.GetEnumerator())
			{
				while (ptr.MoveNext())
				{
					uint current = ptr.Current;
					if (!ptr.MoveNext())
					{
						break;
					}
					uint current2 = ptr.Current;
					if (!_IsDegeneratedSegment(current, current2))
					{
						yield return (A: (int)current, B: (int)current2);
					}
				}
			}
			yield break;
		}
		throw new NotImplementedException();
	}

	public static IEnumerable<(int A, int B, int C)> GetTrianglesIndices(this PrimitiveType ptype, IEnumerable<uint> sourceIndices)
	{
		switch (ptype)
		{
		case PrimitiveType.TRIANGLES:
		{
			using (IEnumerator<uint> ptr = sourceIndices.GetEnumerator())
			{
				while (ptr.MoveNext())
				{
					uint current = ptr.Current;
					if (!ptr.MoveNext())
					{
						break;
					}
					uint current2 = ptr.Current;
					if (!ptr.MoveNext())
					{
						break;
					}
					uint current3 = ptr.Current;
					if (!_IsDegeneratedTriangle(current, current2, current3))
					{
						yield return (A: (int)current, B: (int)current2, C: (int)current3);
					}
				}
			}
			break;
		}
		case PrimitiveType.TRIANGLE_FAN:
		{
			using IEnumerator<uint> ptr = sourceIndices.GetEnumerator();
			if (!ptr.MoveNext())
			{
				break;
			}
			uint a = ptr.Current;
			if (!ptr.MoveNext())
			{
				break;
			}
			uint num2 = ptr.Current;
			while (ptr.MoveNext())
			{
				uint c = ptr.Current;
				if (!_IsDegeneratedTriangle(a, num2, c))
				{
					yield return (A: (int)a, B: (int)num2, C: (int)c);
				}
				num2 = c;
			}
			break;
		}
		case PrimitiveType.TRIANGLE_STRIP:
		{
			using IEnumerator<uint> ptr = sourceIndices.GetEnumerator();
			if (!ptr.MoveNext())
			{
				break;
			}
			uint num = ptr.Current;
			if (!ptr.MoveNext())
			{
				break;
			}
			uint a = ptr.Current;
			bool reversed = false;
			while (ptr.MoveNext())
			{
				uint c = ptr.Current;
				if (!_IsDegeneratedTriangle(num, a, c))
				{
					if (reversed)
					{
						yield return (A: (int)a, B: (int)num, C: (int)c);
					}
					else
					{
						yield return (A: (int)num, B: (int)a, C: (int)c);
					}
				}
				num = a;
				a = c;
				reversed = !reversed;
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
	}

	private static bool _IsDegeneratedSegment(uint a, uint b)
	{
		return a == b;
	}

	private static bool _IsDegeneratedTriangle(uint a, uint b, uint c)
	{
		if (a == b)
		{
			return true;
		}
		if (a == c)
		{
			return true;
		}
		if (b == c)
		{
			return true;
		}
		return false;
	}

	public static bool TryGetUnderlayingArray<T>(this ArraySegment<T> segment, out T[] array)
	{
		array = segment.Array ?? Array.Empty<T>();
		if (segment.Offset == 0)
		{
			return segment.Count == segment.Array.Length;
		}
		return false;
	}

	public static ArraySegment<byte> ToArraySegment(this MemoryStream m)
	{
		if (!m.TryGetBuffer(out var buffer))
		{
			return new ArraySegment<byte>(m.ToArray());
		}
		return buffer;
	}

	public static byte[] GetPaddedContent(this byte[] content)
	{
		if (content == null)
		{
			return null;
		}
		if (content.Length.IsMultipleOf(4))
		{
			return content;
		}
		int num = content.Length % 4;
		num = ((num != 0) ? (4 - num) : 0);
		byte[] array = new byte[content.Length + num];
		content.CopyTo(array, 0);
		return array;
	}

	public static byte[] TryParseBase64Unchecked(this string uri, params string[] prefixes)
	{
		if (uri == null)
		{
			return null;
		}
		if (!uri.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
		{
			return null;
		}
		foreach (string prefix in prefixes)
		{
			byte[] array = _TryParseBase64Unchecked(uri, prefix);
			if (array != null)
			{
				return array;
			}
		}
		return null;
	}

	private static byte[] _TryParseBase64Unchecked(string uri, string prefix)
	{
		if (!uri.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
		{
			return null;
		}
		string text = uri.Substring(prefix.Length);
		if (text.StartsWith(";base64,", StringComparison.OrdinalIgnoreCase))
		{
			text = text.Substring(";base64,".Length);
			return Convert.FromBase64String(text);
		}
		if (StartsWith(text, ','))
		{
			text = text.Substring(1);
			if (text.Length == 1)
			{
				return new byte[1] { byte.Parse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture) };
			}
			throw new NotImplementedException();
		}
		throw new NotImplementedException();
	}

	public static string _EscapeStringInternal(this string uri)
	{
		return Uri.EscapeUriString(uri);
	}

	public static bool DeepEquals(this JsonNode x, JsonNode y, double precission)
	{
		return JsonNode.DeepEquals(x, y);
	}
}
