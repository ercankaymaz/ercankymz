using System;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcTimeStamp", 605)]
[DefinedType(typeof(long))]
public struct IfcTimeStamp : IfcDerivedMeasureValue, IfcValue, IExpressSelectType, IPersist, IExpressValueType, IExpressIntegerType, IEquatable<long>
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

	public static DateTime ToDateTime(IfcTimeStamp timeStamp)
	{
		return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds((long)timeStamp);
	}

	public static IfcTimeStamp ToTimeStamp(DateTime dateTime)
	{
		DateTime value = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
		return new IfcTimeStamp(Convert.ToInt32(dateTime.Subtract(value).TotalSeconds));
	}
}
