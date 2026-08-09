using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

public static class ObjectExtensions
{
	internal class ReferenceEqualityComparer : EqualityComparer<object>
	{
		public override bool Equals(object x, object y)
		{
			return x == y;
		}

		public override int GetHashCode(object obj)
		{
			return obj?.GetHashCode() ?? 0;
		}
	}

	internal class ArrayTraverse
	{
		public int[] Position;

		private int[] maxLengths;

		public ArrayTraverse(Array array)
		{
			maxLengths = new int[array.Rank];
			for (int i = 0; i < array.Rank; i++)
			{
				maxLengths[i] = array.GetLength(i) - 1;
			}
			Position = new int[array.Rank];
		}

		public bool Step()
		{
			for (int i = 0; i < Position.Length; i++)
			{
				if (Position[i] < maxLengths[i])
				{
					Position[i]++;
					for (int j = 0; j < i; j++)
					{
						Position[j] = 0;
					}
					return true;
				}
			}
			return false;
		}
	}

	private static readonly MethodInfo CloneMethod = typeof(object).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);

	public static bool IsPrimitive(this Type type)
	{
		if (type == typeof(string))
		{
			return true;
		}
		return type.IsValueType & type.IsPrimitive;
	}

	public static object DeepClone(this object obj)
	{
		return DeepClone_Internal(obj, new Dictionary<object, object>(new ReferenceEqualityComparer()));
	}

	public static T DeepClone<T>(this T obj)
	{
		return (T)((object)obj).DeepClone();
	}

	private static object DeepClone_Internal(object obj, IDictionary<object, object> visited)
	{
		if (obj == null)
		{
			return null;
		}
		Type type = obj.GetType();
		if (type.IsPrimitive())
		{
			return obj;
		}
		if (visited.ContainsKey(obj))
		{
			return visited[obj];
		}
		if (typeof(Delegate).IsAssignableFrom(type))
		{
			return null;
		}
		object obj2 = CloneMethod.Invoke(obj, null);
		if (type.IsArray)
		{
			Type elementType = type.GetElementType();
			if (!elementType.IsPrimitive())
			{
				Array clonedArray = (Array)obj2;
				clonedArray.ForEach(delegate(Array array, int[] indices)
				{
					array.SetValue(DeepClone_Internal(clonedArray.GetValue(indices), visited), indices);
				});
			}
		}
		visited.Add(obj, obj2);
		CopyFields(obj, visited, obj2, type);
		RecursiveCopyBaseTypePrivateFields(obj, visited, obj2, type);
		return obj2;
	}

	private static void RecursiveCopyBaseTypePrivateFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect)
	{
		if (typeToReflect.BaseType != null)
		{
			RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
			CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, (FieldInfo info) => info.IsPrivate);
		}
	}

	private static void CopyFields(object originalObject, IDictionary<object, object> visited, object cloneObject, Type typeToReflect, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, Func<FieldInfo, bool> filter = null)
	{
		FieldInfo[] fields = typeToReflect.GetFields(bindingFlags);
		foreach (FieldInfo fieldInfo in fields)
		{
			if ((filter == null || filter(fieldInfo)) && !fieldInfo.FieldType.IsPrimitive())
			{
				object value = fieldInfo.GetValue(originalObject);
				object value2 = DeepClone_Internal(value, visited);
				fieldInfo.SetValue(cloneObject, value2);
			}
		}
	}

	public static void ForEach(this Array array, Action<Array, int[]> action)
	{
		if (array.LongLength != 0)
		{
			ArrayTraverse arrayTraverse = new ArrayTraverse(array);
			do
			{
				action(array, arrayTraverse.Position);
			}
			while (arrayTraverse.Step());
		}
	}
}
