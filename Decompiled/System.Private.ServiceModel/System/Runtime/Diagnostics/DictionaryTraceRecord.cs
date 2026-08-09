using System.Collections;
using System.Xml;

namespace System.Runtime.Diagnostics;

internal class DictionaryTraceRecord : TraceRecord
{
	private IDictionary _dictionary;

	internal override string EventId => "http://schemas.microsoft.com/2006/08/ServiceModel/DictionaryTraceRecord";

	internal DictionaryTraceRecord(IDictionary dictionary)
	{
		_dictionary = dictionary;
	}

	internal override void WriteTo(XmlWriter xml)
	{
		if (_dictionary == null)
		{
			return;
		}
		foreach (object key in _dictionary.Keys)
		{
			object obj = _dictionary[key];
			xml.WriteElementString(key.ToString(), (obj == null) ? string.Empty : obj.ToString());
		}
	}
}
