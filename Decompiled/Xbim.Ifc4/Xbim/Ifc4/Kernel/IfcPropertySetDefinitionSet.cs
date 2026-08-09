using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcPropertySetDefinitionSet", 996)]
[DefinedType(typeof(List<IIfcPropertySetDefinition>))]
public struct IfcPropertySetDefinitionSet : IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect, IExpressSelectType, IPersist, IExpressComplexType, IExpressValueType, IEquatable<List<IIfcPropertySetDefinition>>
{
	private List<IIfcPropertySetDefinition> _value;

	public object Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(List<IIfcPropertySetDefinition>);

	IEnumerable<object> IExpressComplexType.Properties
	{
		get
		{
			if (_value == null)
			{
				yield break;
			}
			foreach (IIfcPropertySetDefinition item in _value)
			{
				yield return item;
			}
		}
	}

	public IEnumerable<IIfcPropertySetDefinition> PropertySetDefinitions
	{
		get
		{
			foreach (IIfcPropertySetDefinition propertySetDefinition in PropertySetDefinitions)
			{
				yield return propertySetDefinition;
			}
		}
	}

	public static void Add(ref IfcPropertySetDefinitionSet comp, IIfcPropertySetDefinition component)
	{
		if (comp._value == null)
		{
			comp.Initialise(component);
		}
		else
		{
			comp._value.Add(component);
		}
	}

	private void Initialise(IIfcPropertySetDefinition comp)
	{
		_value = new List<IIfcPropertySetDefinition> { comp };
	}

	public IfcPropertySetDefinitionSet(List<IIfcPropertySetDefinition> val)
	{
		_value = new List<IIfcPropertySetDefinition>(val);
	}

	public static implicit operator IfcPropertySetDefinitionSet(List<IIfcPropertySetDefinition> value)
	{
		return new IfcPropertySetDefinitionSet(value);
	}

	public static implicit operator List<IIfcPropertySetDefinition>(IfcPropertySetDefinitionSet obj)
	{
		return new List<IIfcPropertySetDefinition>(obj._value);
	}

	public override bool Equals(object obj)
	{
		if (obj == null && Value == null)
		{
			return true;
		}
		if (obj == null)
		{
			return false;
		}
		if (GetType() != obj.GetType())
		{
			return false;
		}
		return ((IfcPropertySetDefinitionSet)obj)._value.SequenceEqual(_value);
	}

	public bool Equals(List<IIfcPropertySetDefinition> other)
	{
		return this == other;
	}

	public static bool operator ==(IfcPropertySetDefinitionSet obj1, IfcPropertySetDefinitionSet obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcPropertySetDefinitionSet obj1, IfcPropertySetDefinitionSet obj2)
	{
		return !object.Equals(obj1, obj2);
	}

	public override int GetHashCode()
	{
		if (Value == null)
		{
			return base.GetHashCode();
		}
		return _value.Sum((IIfcPropertySetDefinition o) => o.GetHashCode());
	}

	void IPersist.Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex != 0)
		{
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
		if (_value == null)
		{
			_value = new List<IIfcPropertySetDefinition>();
		}
		_value.Add(value.EntityVal as IIfcPropertySetDefinition);
	}
}
