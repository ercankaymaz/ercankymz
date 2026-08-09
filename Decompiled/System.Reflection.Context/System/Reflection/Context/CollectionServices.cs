using System.Collections.Generic;

namespace System.Reflection.Context;

internal static class CollectionServices
{
	public static T[] Empty<T>()
	{
		return Array.Empty<T>();
	}

	public static bool CompareArrays<T>(T[] left, T[] right)
	{
		if (left.Length != right.Length)
		{
			return false;
		}
		for (int i = 0; i < left.Length; i++)
		{
			if (!left[i].Equals(right[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static int GetArrayHashCode<T>(T[] array)
	{
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			T val = array[i];
			num ^= val.GetHashCode();
		}
		return num;
	}

	public static object[] ConvertListToArray(List<object> list, Type arrayType)
	{
		if (arrayType.HasElementType || arrayType.IsValueType || arrayType.ContainsGenericParameters)
		{
			return list.ToArray();
		}
		Array array = Array.CreateInstance(arrayType, list.Count);
		list.CopyTo((object[])array);
		return (object[])array;
	}

	public static object[] IEnumerableToArray(IEnumerable<object> enumerable, Type arrayType)
	{
		List<object> list = new List<object>(enumerable);
		return ConvertListToArray(list, arrayType);
	}
}
