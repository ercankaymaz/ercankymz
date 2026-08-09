using System.Collections.Generic;
using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

internal class IdentityModelDictionary : IXmlDictionary
{
	public static readonly IdentityModelDictionary Version1 = new IdentityModelDictionary(new IdentityModelStringsVersion1());

	private IdentityModelStrings _strings;

	private int _count;

	private XmlDictionaryString[] _dictionaryStrings;

	private Dictionary<string, int> _dictionary;

	private XmlDictionaryString[] _versionedDictionaryStrings;

	public static IdentityModelDictionary CurrentVersion => Version1;

	public IdentityModelDictionary(IdentityModelStrings strings)
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
		if (_dictionaryStrings == null)
		{
			_dictionaryStrings = new XmlDictionaryString[_count];
		}
		XmlDictionaryString xmlDictionaryString = _dictionaryStrings[key];
		if (xmlDictionaryString == null)
		{
			xmlDictionaryString = CreateString(_strings[key], key);
			_dictionaryStrings[key] = xmlDictionaryString;
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
