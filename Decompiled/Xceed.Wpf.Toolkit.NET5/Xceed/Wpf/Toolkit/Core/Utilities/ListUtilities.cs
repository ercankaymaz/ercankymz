using System;
using System.Collections.Generic;
using System.Linq;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal class ListUtilities
{
	internal static bool IsListOfItems(Type listType)
	{
		return GetListItemType(listType) != null;
	}

	internal static Type GetListItemType(Type listType)
	{
		Type type = listType.GetInterfaces().FirstOrDefault((Type i) => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IList<>));
		if (type != null)
		{
			return type.GetGenericArguments()[0];
		}
		if (listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
		{
			return listType.GetGenericArguments()[0];
		}
		return null;
	}

	internal static bool IsCollectionOfItems(Type colType)
	{
		return GetCollectionItemType(colType) != null;
	}

	internal static Type GetCollectionItemType(Type colType)
	{
		Type type = null;
		type = ((!colType.IsGenericType || !(colType.GetGenericTypeDefinition() == typeof(ICollection<>))) ? colType.GetInterfaces().FirstOrDefault((Type i) => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICollection<>)) : colType);
		if (!(type != null))
		{
			return null;
		}
		return type.GetGenericArguments()[0];
	}

	internal static bool IsDictionaryOfItems(Type dictType)
	{
		return GetDictionaryItemsType(dictType) != null;
	}

	internal static Type[] GetDictionaryItemsType(Type dictType)
	{
		if (dictType.IsGenericType && (dictType.GetGenericTypeDefinition() == typeof(Dictionary<, >) || dictType.GetGenericTypeDefinition() == typeof(IDictionary<, >)))
		{
			return new Type[2]
			{
				dictType.GetGenericArguments()[0],
				dictType.GetGenericArguments()[1]
			};
		}
		return null;
	}

	internal static object CreateEditableKeyValuePair(object key, Type keyType, object value, Type valueType)
	{
		return Activator.CreateInstance(CreateEditableKeyValuePairType(keyType, valueType), key, value);
	}

	internal static Type CreateEditableKeyValuePairType(Type keyType, Type valueType)
	{
		Type typeFromHandle = typeof(EditableKeyValuePair<, >);
		Type[] typeArguments = new Type[2] { keyType, valueType };
		return typeFromHandle.MakeGenericType(typeArguments);
	}
}
