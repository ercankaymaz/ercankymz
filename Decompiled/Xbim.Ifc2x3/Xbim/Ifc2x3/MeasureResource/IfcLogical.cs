using System;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcLogical", 54)]
[DefinedType(typeof(bool?))]
public struct IfcLogical : IfcSimpleValue, IfcValue, IExpressSelectType, IPersist, IExpressValueType, IExpressLogicalType, IEquatable<bool?>
{
	private bool? _value;

	public object Value => _value;

	bool? IExpressLogicalType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(bool?);

	public override string ToString()
	{
		if (_value == true)
		{
			return "true";
		}
		if (_value == false)
		{
			return "false";
		}
		return "unknown";
	}

	public IfcLogical(bool? val)
	{
		_value = val;
	}

	public IfcLogical(string val)
	{
		if (string.Compare(val, "true", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(val, ".T.", StringComparison.OrdinalIgnoreCase) == 0)
		{
			_value = true;
		}
		else if (string.Compare(val, "false", StringComparison.OrdinalIgnoreCase) == 0)
		{
			_value = false;
		}
		else
		{
			_value = null;
		}
	}

	public static implicit operator IfcLogical(bool? value)
	{
		return new IfcLogical(value);
	}

	public static implicit operator bool?(IfcLogical obj)
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
		return ((IfcLogical)obj)._value == _value;
	}

	public bool Equals(bool? other)
	{
		return this == other;
	}

	public static bool operator ==(IfcLogical obj1, IfcLogical obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcLogical obj1, IfcLogical obj2)
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
