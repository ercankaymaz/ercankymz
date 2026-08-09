using System;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4;

[ExpressType("IfcStrippedOptional", 983)]
[DefinedType(typeof(bool))]
public struct IfcStrippedOptional : IExpressValueType, IPersist, IExpressBooleanType, IEquatable<bool>
{
	private bool _value;

	public object Value => _value;

	bool IExpressBooleanType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(bool);

	public override string ToString()
	{
		if (!_value)
		{
			return "false";
		}
		return "true";
	}

	public IfcStrippedOptional(bool val)
	{
		_value = val;
	}

	public IfcStrippedOptional(string val)
	{
		if (string.Compare(val, "true", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(val, ".T.", StringComparison.OrdinalIgnoreCase) == 0)
		{
			_value = true;
		}
		else
		{
			_value = false;
		}
	}

	public static implicit operator IfcStrippedOptional(bool value)
	{
		return new IfcStrippedOptional(value);
	}

	public static implicit operator bool(IfcStrippedOptional obj)
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
		return ((IfcStrippedOptional)obj)._value == _value;
	}

	public bool Equals(bool other)
	{
		return this == other;
	}

	public static bool operator ==(IfcStrippedOptional obj1, IfcStrippedOptional obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcStrippedOptional obj1, IfcStrippedOptional obj2)
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
		_value = value.BooleanVal;
	}
}
