using System;
using MS.Internal;

namespace Microsoft.Windows.Design.Metadata;

public struct EventIdentifier : IEquatable<EventIdentifier>
{
	private Type _declaringType;

	private TypeIdentifier _declaringTypeId;

	private Identifier _name;

	public Type DeclaringType => _declaringType;

	public TypeIdentifier DeclaringTypeIdentifier => _declaringTypeId;

	public string FullName
	{
		get
		{
			if (_name.IsDefined)
			{
				string text = (((object)_declaringType != null) ? _declaringType.Name : _declaringTypeId.SimpleName);
				return text + "." + _name.Name;
			}
			return string.Empty;
		}
	}

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

	public bool IsEmpty => !_name.IsDefined;

	public EventIdentifier(Type declaringType, string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if ((object)declaringType == null)
		{
			throw new ArgumentNullException("declaringType");
		}
		_declaringType = declaringType;
		_declaringTypeId = default(TypeIdentifier);
		_name = Identifier.For(name);
	}

	public EventIdentifier(TypeIdentifier declaringTypeId, string name)
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
	}

	public override int GetHashCode()
	{
		int num = (((object)_declaringType != null) ? _declaringType.GetHashCode() : _declaringTypeId.GetHashCode());
		return num ^ _name.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is EventIdentifier)
		{
			return Equals((EventIdentifier)obj);
		}
		return false;
	}

	public static bool operator ==(EventIdentifier first, EventIdentifier second)
	{
		return first.Equals(second);
	}

	public static bool operator !=(EventIdentifier first, EventIdentifier second)
	{
		return !first.Equals(second);
	}

	public bool Equals(EventIdentifier other)
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
