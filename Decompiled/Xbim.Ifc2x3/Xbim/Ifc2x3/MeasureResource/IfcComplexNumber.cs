using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcComplexNumber", 650)]
[DefinedType(typeof(List<double>))]
public struct IfcComplexNumber : IfcMeasureValue, IfcValue, IExpressSelectType, IPersist, IExpressValueType, IExpressComplexType, IEquatable<List<double>>
{
	private List<double> _value;

	public object Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(List<double>);

	IEnumerable<object> IExpressComplexType.Properties
	{
		get
		{
			if (_value == null)
			{
				yield break;
			}
			foreach (double item in _value)
			{
				yield return item;
			}
		}
	}

	public static void Add(ref IfcComplexNumber comp, double component)
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

	private void Initialise(double comp)
	{
		_value = new List<double> { comp };
	}

	public IfcComplexNumber(List<double> val)
	{
		_value = new List<double>(val);
	}

	public static implicit operator IfcComplexNumber(List<double> value)
	{
		return new IfcComplexNumber(value);
	}

	public static implicit operator List<double>(IfcComplexNumber obj)
	{
		return new List<double>(obj._value);
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
		return ((IfcComplexNumber)obj)._value.SequenceEqual(_value);
	}

	public bool Equals(List<double> other)
	{
		return this == other;
	}

	public static bool operator ==(IfcComplexNumber obj1, IfcComplexNumber obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcComplexNumber obj1, IfcComplexNumber obj2)
	{
		return !object.Equals(obj1, obj2);
	}

	public override int GetHashCode()
	{
		if (Value == null)
		{
			return base.GetHashCode();
		}
		return _value.Sum((double o) => o.GetHashCode());
	}

	void IPersist.Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex != 0)
		{
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
		if (_value == null)
		{
			_value = new List<double>();
		}
		_value.Add(value.RealVal);
	}
}
