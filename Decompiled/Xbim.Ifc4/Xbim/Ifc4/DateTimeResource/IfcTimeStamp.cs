using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcTimeStamp", 605)]
[DefinedType(typeof(long))]
public struct IfcTimeStamp : IfcSimpleValue, IfcValue, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IIfcValue, IExpressValueType, IIfcSimpleValue, IExpressIntegerType, IEquatable<long>
{
	private long _value;

	public object Value => _value;

	long IExpressIntegerType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(long);

	public override string ToString()
	{
		return _value.ToString();
	}

	public IfcTimeStamp(long val)
	{
		_value = val;
	}

	public IfcTimeStamp(string val)
	{
		_value = Convert.ToInt64(val);
	}

	public static implicit operator IfcTimeStamp(long value)
	{
		return new IfcTimeStamp(value);
	}

	public static implicit operator long(IfcTimeStamp obj)
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
		return ((IfcTimeStamp)obj)._value == _value;
	}

	public bool Equals(long other)
	{
		return this == other;
	}

	public static bool operator ==(IfcTimeStamp obj1, IfcTimeStamp obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcTimeStamp obj1, IfcTimeStamp obj2)
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

	public DateTime ToDateTime()
	{
		return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds((long)this);
	}

	public static implicit operator DateTime(IfcTimeStamp obj)
	{
		return obj.ToDateTime();
	}

	public static implicit operator IfcTimeStamp(DateTime obj)
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
		return (long)(obj - dateTime).TotalSeconds;
	}

	public static implicit operator TimeSpan(IfcTimeStamp obj)
	{
		return TimeSpan.FromSeconds((long)obj);
	}

	public static implicit operator IfcTimeStamp(TimeSpan obj)
	{
		return (long)obj.TotalSeconds;
	}
}
