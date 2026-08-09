using System;

namespace PdfSharp.Pdf;

internal class KeyInfoAttribute : Attribute
{
	private string _version = "1.0";

	private KeyType _entryType;

	private Type _objectType;

	private string _fixedValue;

	public string Version
	{
		get
		{
			return _version;
		}
		set
		{
			_version = value;
		}
	}

	public KeyType KeyType
	{
		get
		{
			return _entryType;
		}
		set
		{
			_entryType = value;
		}
	}

	public Type ObjectType
	{
		get
		{
			return _objectType;
		}
		set
		{
			_objectType = value;
		}
	}

	public string FixedValue
	{
		get
		{
			return _fixedValue;
		}
		set
		{
			_fixedValue = value;
		}
	}

	public KeyInfoAttribute()
	{
	}

	public KeyInfoAttribute(KeyType keyType)
	{
		KeyType = keyType;
	}

	public KeyInfoAttribute(string version, KeyType keyType)
	{
		_version = version;
		KeyType = keyType;
	}

	public KeyInfoAttribute(KeyType keyType, Type objectType)
	{
		KeyType = keyType;
		_objectType = objectType;
	}

	public KeyInfoAttribute(string version, KeyType keyType, Type objectType)
	{
		KeyType = keyType;
		_objectType = objectType;
	}
}
