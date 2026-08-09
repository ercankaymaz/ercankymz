using System.Collections.Concurrent;
using System.Xml.Serialization;

namespace System.ServiceModel.Description;

internal static class XmlMappingExtension
{
	private static ConcurrentDictionary<XmlMapping, string> s_dictionary = new ConcurrentDictionary<XmlMapping, string>();

	public static string GetKey(this XmlMapping mapping)
	{
		s_dictionary.TryGetValue(mapping, out var value);
		return value;
	}

	public static void SetKeyInternal(this XmlMapping mapping, string key)
	{
		mapping.SetKey(key);
		s_dictionary.TryAdd(mapping, key);
	}
}
