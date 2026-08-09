using System;
using MS.Internal;

namespace Microsoft.Windows.Design.Metadata;

public struct PropertyIdentifier : IEquatable<PropertyIdentifier>
{
	private Type _declaringType;

	private TypeIdentifier _declaringTypeId;

	private Identifier _name;

	private string _fullName;

	public Type DeclaringType => _declaringType;

	public TypeIdentifier DeclaringTypeIdentifier => _declaringTypeId;

	public string FullName => _fullName;

	public bool IsEmpty => !_name.IsDefined;

	public string Name
	{
		get
		{
			if (!_name.IsDefined)
			{
				return null;
			}
			return _name.Name;
		}
	}

	public PropertyIdentifier(Type declaringType, string name)
	{
		if ((object)declaringType == null)
		{
			throw new ArgumentNullException("declaringType");
		}
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		_declaringType = declaringType;
		_declaringTypeId = default(TypeIdentifier);
		_name = Identifier.For(name);
		_fullName = CreateFullName(_declaringType, _declaringTypeId, _name);
	}

	public PropertyIdentifier(TypeIdentifier declaringTypeId, string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (declaringTypeId.IsEmpty)
		{
			throw new ArgumentNullException("declaringTypeId");
		}
		_declaringType = null;
		_declaringTypeId = declaringTypeId;
		_name = Identifier.For(name);
		_fullName = CreateFullName(_declaringType, _declaringTypeId, _name);
	}

	private static string CreateFullName(Type declaringType, TypeIdentifier declaringTypeId, Identifier name)
	{
		if (name.IsDefined)
		{
			string text = (((object)declaringType != null) ? declaringType.Name : declaringTypeId.SimpleName);
			return text + "." + name.Name;
		}
		return string.Empty;
	}

	public override int GetHashCode()
	{
		int num = (((object)_declaringType != null) ? _declaringType.GetHashCode() : _declaringTypeId.GetHashCode());
		return num ^ _name.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is PropertyIdentifier)
		{
			return Equals((PropertyIdentifier)obj);
		}
		return false;
	}

	public static bool operator ==(PropertyIdentifier first, PropertyIdentifier second)
	{
		return first.Equals(second);
	}

	public static bool operator !=(PropertyIdentifier first, PropertyIdentifier second)
	{
		return !first.Equals(second);
	}

	public bool Equals(PropertyIdentifier other)
	{
		if ((object)_declaringType != null)
		{
			if ((object)_declaringType == other._declaringType)
			{
				return _name == other._name;
			}
			return false;
		}
		if (_declaringTypeId.Equals(other._declaringTypeId))
		{
			return _name == other._name;
		}
		return false;
	}

	public override string ToString()
	{
		return FullName;
	}
}
