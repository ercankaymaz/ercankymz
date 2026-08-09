using System;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcInteger", 362)]
[DefinedType(typeof(long))]
public struct IfcInteger : IfcSimpleValue, IfcValue, IExpressSelectType, IPersist, IExpressValueType, IExpressIntegerType, IEquatable<long>
{
	private long _value;

	public object Value => _value;

	long IExpressIntegerType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(long);

	public override string ToString()
	{
		return _value.ToString();
	}

	public IfcInteger(long val)
	{
		_value = val;
	}

	public IfcInteger(string val)
	{
		_value = Convert.ToInt64(val);
	}

	public static implicit operator IfcInteger(long value)
	{
		return new IfcInteger(value);
	}

	public static implicit operator long(IfcInteger obj)
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
		return ((IfcInteger)obj)._value == _value;
	}

	public bool Equals(long other)
	{
		return this == other;
	}

	public static bool operator ==(IfcInteger obj1, IfcInteger obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcInteger obj1, IfcInteger obj2)
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
