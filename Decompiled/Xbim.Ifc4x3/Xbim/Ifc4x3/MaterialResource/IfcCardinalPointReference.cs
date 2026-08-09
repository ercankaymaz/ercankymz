using System;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.MaterialResource;

[ExpressType("IfcCardinalPointReference", 987)]
[DefinedType(typeof(long))]
public struct IfcCardinalPointReference : IExpressValueType, IPersist, IExpressIntegerType, IEquatable<long>
{
	private long _value;

	public object Value => _value;

	long IExpressIntegerType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(long);

	public override string ToString()
	{
		return _value.ToString();
	}

	public IfcCardinalPointReference(long val)
	{
		_value = val;
	}

	public IfcCardinalPointReference(string val)
	{
		_value = Convert.ToInt64(val);
	}

	public static implicit operator IfcCardinalPointReference(long value)
	{
		return new IfcCardinalPointReference(value);
	}

	public static implicit operator long(IfcCardinalPointReference obj)
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
		return ((IfcCardinalPointReference)obj)._value == _value;
	}

	public bool Equals(long other)
	{
		return this == other;
	}

	public static bool operator ==(IfcCardinalPointReference obj1, IfcCardinalPointReference obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcCardinalPointReference obj1, IfcCardinalPointReference obj2)
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
