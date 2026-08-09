using System;
using System.Collections.Generic;
using System.Reflection;

namespace PdfSharp.Pdf;

internal class DictionaryMeta
{
	private readonly Dictionary<string, KeyDescriptor> _keyDescriptors = new Dictionary<string, KeyDescriptor>();

	public KeyDescriptor this[string key]
	{
		get
		{
			_keyDescriptors.TryGetValue(key, out var value);
			return value;
		}
	}

	public DictionaryMeta(Type type)
	{
		FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
		FieldInfo[] array = fields;
		foreach (FieldInfo fieldInfo in array)
		{
			object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(KeyInfoAttribute), inherit: false);
			if (customAttributes.Length == 1)
			{
				KeyInfoAttribute attribute = (KeyInfoAttribute)customAttributes[0];
				KeyDescriptor keyDescriptor = new KeyDescriptor(attribute)
				{
					KeyValue = (string)fieldInfo.GetValue(null)
				};
				_keyDescriptors[keyDescriptor.KeyValue] = keyDescriptor;
			}
		}
	}
}
