using System.Collections.Generic;
using System.Xml;

namespace System.ServiceModel;

internal class ServiceModelDictionary : IXmlDictionary
{
	public static readonly ServiceModelDictionary Version1 = new ServiceModelDictionary(new ServiceModelStringsVersion1());

	private ServiceModelStrings _strings;

	private int _count;

	private XmlDictionaryString[] _dictionaryStrings1;

	private XmlDictionaryString[] _dictionaryStrings2;

	private Dictionary<string, int> _dictionary;

	private XmlDictionaryString[] _versionedDictionaryStrings;

	public static ServiceModelDictionary CurrentVersion => Version1;

	public ServiceModelDictionary(ServiceModelStrings strings)
	{
		_strings = strings;
		_count = strings.Count;
	}

	public XmlDictionaryString CreateString(string value, int key)
	{
		return new XmlDictionaryString(this, value, key);
	}

	public bool TryLookup(string key, out XmlDictionaryString value)
	{
		if (key == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("key"));
		}
		if (_dictionary == null)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>(_count);
			for (int i = 0; i < _count; i++)
			{
				dictionary.Add(_strings[i], i);
			}
			_dictionary = dictionary;
		}
		if (_dictionary.TryGetValue(key, out var value2))
		{
			return TryLookup(value2, out value);
		}
		value = null;
		return false;
	}

	public bool TryLookup(int key, out XmlDictionaryString value)
	{
		if (key < 0 || key >= _count)
		{
			value = null;
			return false;
		}
		XmlDictionaryString xmlDictionaryString;
		if (key < 32)
		{
			if (_dictionaryStrings1 == null)
			{
				_dictionaryStrings1 = new XmlDictionaryString[32];
			}
			xmlDictionaryString = _dictionaryStrings1[key];
			if (xmlDictionaryString == null)
			{
				xmlDictionaryString = CreateString(_strings[key], key);
				_dictionaryStrings1[key] = xmlDictionaryString;
			}
		}
		else
		{
			if (_dictionaryStrings2 == null)
			{
				_dictionaryStrings2 = new XmlDictionaryString[_count - 32];
			}
			xmlDictionaryString = _dictionaryStrings2[key - 32];
			if (xmlDictionaryString == null)
			{
				xmlDictionaryString = CreateString(_strings[key], key);
				_dictionaryStrings2[key - 32] = xmlDictionaryString;
			}
		}
		value = xmlDictionaryString;
		return true;
	}

	public bool TryLookup(XmlDictionaryString key, out XmlDictionaryString value)
	{
		if (key == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("key"));
		}
		if (key.Dictionary == this)
		{
			value = key;
			return true;
		}
		if (key.Dictionary == CurrentVersion)
		{
			if (_versionedDictionaryStrings == null)
			{
				_versionedDictionaryStrings = new XmlDictionaryString[CurrentVersion._count];
			}
			XmlDictionaryString value2 = _versionedDictionaryStrings[key.Key];
			if (value2 == null)
			{
				if (!TryLookup(key.Value, out value2))
				{
					value = null;
					return false;
				}
				_versionedDictionaryStrings[key.Key] = value2;
			}
			value = value2;
			return true;
		}
		value = null;
		return false;
	}
}
