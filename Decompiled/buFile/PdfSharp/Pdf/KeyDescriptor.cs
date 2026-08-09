#define DEBUG
using System;
using System.Diagnostics;

namespace PdfSharp.Pdf;

internal sealed class KeyDescriptor
{
	private string _version;

	private KeyType _keyType;

	private string _keyValue;

	private readonly string _fixedValue;

	private Type _objectType;

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
			return _keyType;
		}
		set
		{
			_keyType = value;
		}
	}

	public string KeyValue
	{
		get
		{
			return _keyValue;
		}
		set
		{
			_keyValue = value;
		}
	}

	public string FixedValue => _fixedValue;

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

	public bool CanBeIndirect => (_keyType & KeyType.MustNotBeIndirect) == 0;

	public KeyDescriptor(KeyInfoAttribute attribute)
	{
		_version = attribute.Version;
		_keyType = attribute.KeyType;
		_fixedValue = attribute.FixedValue;
		_objectType = attribute.ObjectType;
		if (_version == "")
		{
			_version = "1.0";
		}
	}

	public Type GetValueType()
	{
		Type type = _objectType;
		if (type == null)
		{
			switch (_keyType & KeyType.TypeMask)
			{
			case KeyType.Name:
				type = typeof(PdfName);
				break;
			case KeyType.String:
				type = typeof(PdfString);
				break;
			case KeyType.Boolean:
				type = typeof(PdfBoolean);
				break;
			case KeyType.Integer:
				type = typeof(PdfInteger);
				break;
			case KeyType.Real:
				type = typeof(PdfReal);
				break;
			case KeyType.Date:
				type = typeof(PdfDate);
				break;
			case KeyType.Rectangle:
				type = typeof(PdfRectangle);
				break;
			case KeyType.Array:
				type = typeof(PdfArray);
				break;
			case KeyType.Dictionary:
				type = typeof(PdfDictionary);
				break;
			case KeyType.Stream:
				type = typeof(PdfDictionary);
				break;
			case KeyType.NumberTree:
				throw new NotImplementedException("KeyType.NumberTree");
			case KeyType.NameOrArray:
				throw new NotImplementedException("KeyType.NameOrArray");
			case KeyType.ArrayOrDictionary:
				throw new NotImplementedException("KeyType.ArrayOrDictionary");
			case KeyType.StreamOrArray:
				throw new NotImplementedException("KeyType.StreamOrArray");
			case KeyType.ArrayOrNameOrString:
				return null;
			default:
				Debug.Assert(condition: false, "Invalid KeyType: " + _keyType);
				break;
			}
		}
		return type;
	}
}
