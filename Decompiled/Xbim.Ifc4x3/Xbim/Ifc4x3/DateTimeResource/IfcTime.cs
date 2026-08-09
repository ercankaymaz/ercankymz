using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.DateTimeResource;

[ExpressType("IfcTime", 1000)]
[DefinedType(typeof(string))]
public struct IfcTime : IfcSimpleValue, IfcValue, IfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IExpressValueType, IExpressStringType, IEquatable<string>
{
	private string _value;

	public object Value => _value;

	string IExpressStringType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(string);

	public override string ToString()
	{
		return _value ?? "";
	}

	public IfcTime(string val)
	{
		_value = val;
	}

	public static implicit operator IfcTime(string value)
	{
		return new IfcTime(value);
	}

	public static implicit operator string(IfcTime obj)
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
		return ((IfcTime)obj)._value == _value;
	}

	public bool Equals(string other)
	{
		return this == (IfcTime)other;
	}

	public static bool operator ==(IfcTime obj1, IfcTime obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcTime obj1, IfcTime obj2)
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

	public static implicit operator DateTime(IfcTime obj)
	{
		if (DateTime.TryParse(obj, out var result))
		{
			return result;
		}
		return default(DateTime);
	}

	public static implicit operator IfcTime(DateTime obj)
	{
		return obj.ToString("O").Substring(11);
	}
}
