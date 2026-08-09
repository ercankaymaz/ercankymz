using System;
using System.Collections.Generic;
using System.Numerics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Schema2;

internal static class _Schema2Extensions
{
	public static void SetMorphWeights(this IList<double> list, int maxCount, SparseWeight8 weights)
	{
		while (list.Count > maxCount)
		{
			list.RemoveAt(list.Count - 1);
		}
		while (list.Count < maxCount)
		{
			list.Add(0.0);
		}
		if (list.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			list[i] = 0.0;
		}
		foreach (var nonZeroWeight in weights.GetNonZeroWeights())
		{
			int item = nonZeroWeight.Index;
			float item2 = nonZeroWeight.Weight;
			list[item] = item2;
		}
	}

	public static void SetMorphWeights(this IList<double> list, IReadOnlyList<float> weights)
	{
		if (weights == null)
		{
			list.Clear();
			return;
		}
		while (list.Count > weights.Count)
		{
			list.RemoveAt(list.Count - 1);
		}
		while (list.Count < weights.Count)
		{
			list.Add(0.0);
		}
		if (list.Count > 0)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = weights[i];
			}
		}
	}

	internal static string AsName(this string name)
	{
		if (!string.IsNullOrWhiteSpace(name))
		{
			return name;
		}
		return null;
	}

	internal static T AsValue<T>(this T? value, T defval) where T : struct
	{
		return value ?? defval;
	}

	internal static T? AsNullable<T>(this T value, T defval) where T : struct
	{
		if (!value.Equals(defval))
		{
			return value;
		}
		return null;
	}

	internal static T? AsNullable<T>(this T value, T defval, T minval, T maxval) where T : struct, IEquatable<T>, IComparable<T>
	{
		if (value.Equals(defval))
		{
			return null;
		}
		if (value.CompareTo(minval) < 0)
		{
			value = minval;
		}
		if (value.CompareTo(maxval) > 0)
		{
			value = maxval;
		}
		if (!value.Equals(defval))
		{
			return value;
		}
		return null;
	}

	internal static Vector2? AsNullable(this Vector2 value, Vector2 defval, Vector2 minval, Vector2 maxval)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if (((Vector2)(ref value)).Equals(defval))
		{
			return null;
		}
		value = Vector2.Min(value, maxval);
		value = Vector2.Max(value, minval);
		if (!((Vector2)(ref value)).Equals(defval))
		{
			return value;
		}
		return null;
	}

	internal static Vector3? AsNullable(this Vector3 value, Vector3 defval, Vector3 minval, Vector3 maxval)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if (((Vector3)(ref value)).Equals(defval))
		{
			return null;
		}
		value = Vector3.Min(value, maxval);
		value = Vector3.Max(value, minval);
		if (!((Vector3)(ref value)).Equals(defval))
		{
			return value;
		}
		return null;
	}

	internal static Vector4? AsNullable(this Vector4 value, Vector4 defval, Vector4 minval, Vector4 maxval)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if (((Vector4)(ref value)).Equals(defval))
		{
			return null;
		}
		value = Vector4.Min(value, maxval);
		value = Vector4.Max(value, minval);
		if (!((Vector4)(ref value)).Equals(defval))
		{
			return value;
		}
		return null;
	}

	internal static string AsNullable(this string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			return value;
		}
		return null;
	}

	internal static string AsEmptyNullable(this string value)
	{
		if (!string.IsNullOrWhiteSpace(value))
		{
			return value;
		}
		return null;
	}
}
