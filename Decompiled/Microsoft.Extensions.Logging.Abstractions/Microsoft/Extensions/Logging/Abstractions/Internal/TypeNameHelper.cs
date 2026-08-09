using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Extensions.Logging.Abstractions.Internal;

public class TypeNameHelper
{
	private static readonly Dictionary<Type, string> _builtInTypeNames = new Dictionary<Type, string>
	{
		{
			typeof(bool),
			"bool"
		},
		{
			typeof(byte),
			"byte"
		},
		{
			typeof(char),
			"char"
		},
		{
			typeof(decimal),
			"decimal"
		},
		{
			typeof(double),
			"double"
		},
		{
			typeof(float),
			"float"
		},
		{
			typeof(int),
			"int"
		},
		{
			typeof(long),
			"long"
		},
		{
			typeof(object),
			"object"
		},
		{
			typeof(sbyte),
			"sbyte"
		},
		{
			typeof(short),
			"short"
		},
		{
			typeof(string),
			"string"
		},
		{
			typeof(uint),
			"uint"
		},
		{
			typeof(ulong),
			"ulong"
		},
		{
			typeof(ushort),
			"ushort"
		}
	};

	public static string GetTypeDisplayName(Type type)
	{
		if (type.GetTypeInfo().IsGenericType)
		{
			string[] array = type.GetGenericTypeDefinition().FullName.Split(new char[1] { '+' });
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				int num = text.IndexOf('`');
				if (num >= 0)
				{
					text = text.Substring(0, num);
				}
				array[i] = text;
			}
			return string.Join(".", array);
		}
		if (_builtInTypeNames.ContainsKey(type))
		{
			return _builtInTypeNames[type];
		}
		string text2 = type.FullName;
		if (type.IsNested)
		{
			text2 = text2.Replace('+', '.');
		}
		return text2;
	}
}
