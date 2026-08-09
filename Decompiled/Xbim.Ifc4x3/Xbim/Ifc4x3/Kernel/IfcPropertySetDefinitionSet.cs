using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcPropertySetDefinitionSet", 996)]
[DefinedType(typeof(List<IfcPropertySetDefinition>))]
public struct IfcPropertySetDefinitionSet : IfcPropertySetDefinitionSelect, IExpressSelectType, IPersist, IExpressComplexType, IExpressValueType, IEquatable<List<IfcPropertySetDefinition>>, IIfcPropertySetDefinitionSelect
{
	private List<IfcPropertySetDefinition> _value;

	public object Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(List<IfcPropertySetDefinition>);

	IEnumerable<object> IExpressComplexType.Properties
	{
		get
		{
			if (_value == null)
			{
				yield break;
			}
			foreach (IfcPropertySetDefinition item in _value)
			{
				yield return item;
			}
		}
	}

	public IEnumerable<IfcPropertySetDefinition> PropertySetDefinitions => _value;

	IEnumerable<IIfcPropertySetDefinition> IIfcPropertySetDefinitionSelect.PropertySetDefinitions => _value;

	public static void Add(ref IfcPropertySetDefinitionSet comp, IfcPropertySetDefinition component)
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

	private void Initialise(IfcPropertySetDefinition comp)
	{
		_value = new List<IfcPropertySetDefinition> { comp };
	}

	public IfcPropertySetDefinitionSet(List<IfcPropertySetDefinition> val)
	{
		_value = new List<IfcPropertySetDefinition>(val);
	}

	public static implicit operator IfcPropertySetDefinitionSet(List<IfcPropertySetDefinition> value)
	{
		return new IfcPropertySetDefinitionSet(value);
	}

	public static implicit operator List<IfcPropertySetDefinition>(IfcPropertySetDefinitionSet obj)
	{
		return new List<IfcPropertySetDefinition>(obj._value);
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

	public bool Equals(List<IfcPropertySetDefinition> other)
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
		return _value.Sum((IfcPropertySetDefinition o) => o.GetHashCode());
	}

	void IPersist.Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex != 0)
		{
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
		if (_value == null)
		{
			_value = new List<IfcPropertySetDefinition>();
		}
		_value.Add(value.EntityVal as IfcPropertySetDefinition);
	}
}
