using System;
using System.Collections.Generic;
using MS.Internal;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.PropertyEditing;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
public sealed class NewItemTypesAttribute : Attribute
{
	private Type _factoryType;

	private Type[] _types;

	public IEnumerable<Type> Types => _types;

	public Type FactoryType
	{
		get
		{
			return _factoryType;
		}
		set
		{
			if ((object)value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (!typeof(NewItemFactory).IsAssignableFrom(value))
			{
				throw new ArgumentException(MS.Internal.Properties.Resources.Error_InvalidFactoryType);
			}
			_factoryType = value;
		}
	}

	public override object TypeId
	{
		get
		{
			object[] array = new object[_types.Length + 2];
			for (int i = 0; i < _types.Length; i++)
			{
				array[i + 2] = _types[i];
			}
			array[0] = typeof(NewItemTypesAttribute);
			array[1] = _factoryType;
			return new MS.Internal.EqualityArray(array);
		}
	}

	public NewItemTypesAttribute(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		_factoryType = typeof(NewItemFactory);
		_types = new Type[1] { type };
	}

	public NewItemTypesAttribute(params Type[] types)
	{
		if (types == null || types.Length < 1)
		{
			throw new ArgumentNullException("types");
		}
		_factoryType = typeof(NewItemFactory);
		_types = types;
	}
}
