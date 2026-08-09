using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcArcIndex", 984)]
[DefinedType(typeof(List<IfcPositiveInteger>))]
public struct IfcArcIndex : IfcSegmentIndexSelect, IIfcSegmentIndexSelect, IExpressSelectType, IPersist, IExpressValueType, IExpressComplexType, IEquatable<List<IfcPositiveInteger>>
{
	private List<IfcPositiveInteger> _value;

	public object Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(List<IfcPositiveInteger>);

	IEnumerable<object> IExpressComplexType.Properties
	{
		get
		{
			if (_value == null)
			{
				yield break;
			}
			foreach (IfcPositiveInteger item in _value)
			{
				yield return item;
			}
		}
	}

	public static void Add(ref IfcArcIndex comp, IfcPositiveInteger component)
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

	private void Initialise(IfcPositiveInteger comp)
	{
		_value = new List<IfcPositiveInteger> { comp };
	}

	public IfcArcIndex(List<IfcPositiveInteger> val)
	{
		_value = new List<IfcPositiveInteger>(val);
	}

	public static implicit operator IfcArcIndex(List<IfcPositiveInteger> value)
	{
		return new IfcArcIndex(value);
	}

	public static implicit operator List<IfcPositiveInteger>(IfcArcIndex obj)
	{
		return new List<IfcPositiveInteger>(obj._value);
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
		return ((IfcArcIndex)obj)._value.SequenceEqual(_value);
	}

	public bool Equals(List<IfcPositiveInteger> other)
	{
		return this == other;
	}

	public static bool operator ==(IfcArcIndex obj1, IfcArcIndex obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcArcIndex obj1, IfcArcIndex obj2)
	{
		return !object.Equals(obj1, obj2);
	}

	public override int GetHashCode()
	{
		if (Value == null)
		{
			return base.GetHashCode();
		}
		return _value.Sum((IfcPositiveInteger o) => o.GetHashCode());
	}

	void IPersist.Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex != 0)
		{
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
		if (_value == null)
		{
			_value = new List<IfcPositiveInteger>();
		}
		_value.Add(value.IntegerVal);
	}
}
