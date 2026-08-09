using System;
using System.Globalization;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcDate", 988)]
[DefinedType(typeof(string))]
public struct IfcDate : IfcSimpleValue, IfcValue, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IIfcValue, IExpressValueType, IIfcSimpleValue, IExpressStringType, IEquatable<string>
{
	private string _value;

	public object Value => _value;

	string IExpressStringType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(string);

	public override string ToString()
	{
		return _value ?? "";
	}

	public IfcDate(string val)
	{
		_value = val;
	}

	public static implicit operator IfcDate(string value)
	{
		return new IfcDate(value);
	}

	public static implicit operator string(IfcDate obj)
	{
		return obj._value;
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
		return ((IfcDate)obj)._value == _value;
	}

	public bool Equals(string other)
	{
		return this == (IfcDate)other;
	}

	public static bool operator ==(IfcDate obj1, IfcDate obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcDate obj1, IfcDate obj2)
	{
		return !object.Equals(obj1, obj2);
	}

	public override int GetHashCode()
	{
		if (Value == null)
		{
			return base.GetHashCode();
		}
		return _value.GetHashCode();
	}

	void IPersist.Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex != 0)
		{
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
		_value = value.StringVal;
	}

	public DateTime ToDateTime()
	{
		return this;
	}

	public static implicit operator DateTime(IfcDate obj)
	{
		if (DateTime.TryParse(obj._value, null, DateTimeStyles.RoundtripKind, out var result))
		{
			return result;
		}
		return default(DateTime);
	}

	public static implicit operator IfcDate(DateTime obj)
	{
		obj = DateTime.SpecifyKind(obj, DateTimeKind.Unspecified);
		return obj.ToString("yyyy-MM-dd");
	}
}
