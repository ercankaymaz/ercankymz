using System;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.DateTimeResource;

[ExpressType("IfcDayInMonthNumber", 194)]
[DefinedType(typeof(long))]
public struct IfcDayInMonthNumber : IExpressValueType, IPersist, IExpressIntegerType, IEquatable<long>
{
	private long _value;

	public object Value => _value;

	long IExpressIntegerType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(long);

	public override string ToString()
	{
		return _value.ToString();
	}

	public IfcDayInMonthNumber(long val)
	{
		_value = val;
	}

	public IfcDayInMonthNumber(string val)
	{
		_value = Convert.ToInt64(val);
	}

	public static implicit operator IfcDayInMonthNumber(long value)
	{
		return new IfcDayInMonthNumber(value);
	}

	public static implicit operator long(IfcDayInMonthNumber obj)
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
		return ((IfcDayInMonthNumber)obj)._value == _value;
	}

	public bool Equals(long other)
	{
		return this == other;
	}

	public static bool operator ==(IfcDayInMonthNumber obj1, IfcDayInMonthNumber obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcDayInMonthNumber obj1, IfcDayInMonthNumber obj2)
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
		_value = value.IntegerVal;
	}
}
