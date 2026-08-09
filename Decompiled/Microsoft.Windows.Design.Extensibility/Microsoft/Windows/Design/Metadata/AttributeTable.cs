using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using MS.Internal;
using MS.Internal.Metadata;

namespace Microsoft.Windows.Design.Metadata;

public sealed class AttributeTable
{
	private MutableAttributeTable _attributes;

	public IEnumerable<Type> AttributedTypes => _attributes.AttributedTypes;

	internal MutableAttributeTable MutableTable => _attributes;

	internal AttributeTable(MutableAttributeTable attributes)
	{
		_attributes = attributes;
	}

	public bool ContainsAttributes(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		return _attributes.ContainsAttributes(type);
	}

	public IEnumerable GetCustomAttributes(Assembly assembly)
	{
		if ((object)assembly == null)
		{
			throw new ArgumentNullException("assembly");
		}
		return _attributes.GetCustomAttributes(assembly);
	}

	public IEnumerable GetCustomAttributes(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		return _attributes.GetCustomAttributes(type);
	}

	public IEnumerable GetCustomAttributes(Type ownerType, string memberName)
	{
		if ((object)ownerType == null)
		{
			throw new ArgumentNullException("ownerType");
		}
		if (memberName == null)
		{
			throw new ArgumentNullException("memberName");
		}
		return _attributes.GetCustomAttributes(ownerType, Identifier.For(memberName));
	}

	internal IEnumerable GetCustomAttributes(Type ownerType, Identifier memberIdentifier)
	{
		return _attributes.GetCustomAttributes(ownerType, memberIdentifier);
	}
}
