using System;
using MS.Internal;

namespace Microsoft.Windows.Design.Metadata;

public struct TypeIdentifier : IEquatable<TypeIdentifier>
{
	private Identifier _xmlNamespace;

	private Identifier _name;

	private int _hashCode;

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

	internal string SimpleName
	{
		get
		{
			if (_xmlNamespace.IsDefined)
			{
				return _name.Name;
			}
			string text = _name.Name;
			int num = text.IndexOf(',');
			if (num >= 0)
			{
				text = text.Substring(0, num);
			}
			num = text.LastIndexOf('.');
			if (num >= 0)
			{
				text = text.Substring(num + 1);
			}
			return text.Trim();
		}
	}

	public string XmlNamespace
	{
		get
		{
			if (!_xmlNamespace.IsDefined)
			{
				return null;
			}
			return _xmlNamespace.Name;
		}
	}

	public TypeIdentifier(string xmlNamespace, string name)
	{
		if (xmlNamespace == null)
		{
			throw new ArgumentNullException("xmlNamespace");
		}
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		_xmlNamespace = Identifier.For(xmlNamespace);
		_name = Identifier.For(name);
		_hashCode = _xmlNamespace.GetHashCode() ^ _name.GetHashCode();
	}

	public TypeIdentifier(string fullyQualifiedName)
	{
		if (fullyQualifiedName == null)
		{
			throw new ArgumentNullException("fullyQualifiedName");
		}
		_xmlNamespace = Identifier.Undefined;
		_name = Identifier.For(fullyQualifiedName);
		_hashCode = _name.GetHashCode();
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	public override bool Equals(object obj)
	{
		if (obj is TypeIdentifier)
		{
			return Equals((TypeIdentifier)obj);
		}
		return false;
	}

	public static bool operator ==(TypeIdentifier first, TypeIdentifier second)
	{
		return first.Equals(second);
	}

	public static bool operator !=(TypeIdentifier first, TypeIdentifier second)
	{
		return !first.Equals(second);
	}

	public bool Equals(TypeIdentifier other)
	{
		if (_xmlNamespace == other._xmlNamespace)
		{
			return _name == other._name;
		}
		return false;
	}

	public override string ToString()
	{
		return _name.Name;
	}
}
