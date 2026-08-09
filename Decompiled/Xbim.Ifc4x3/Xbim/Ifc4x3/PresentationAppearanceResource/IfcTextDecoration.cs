using System;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcTextDecoration", 582)]
[DefinedType(typeof(string))]
public struct IfcTextDecoration : IExpressValueType, IPersist, IExpressStringType, IEquatable<string>
{
	private string _value;

	public object Value => _value;

	string IExpressStringType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(string);

	public override string ToString()
	{
		return _value ?? "";
	}

	public IfcTextDecoration(string val)
	{
		_value = val;
	}

	public static implicit operator IfcTextDecoration(string value)
	{
		return new IfcTextDecoration(value);
	}

	public static implicit operator string(IfcTextDecoration obj)
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
		return ((IfcTextDecoration)obj)._value == _value;
	}

	public bool Equals(string other)
	{
		return this == (IfcTextDecoration)other;
	}

	public static bool operator ==(IfcTextDecoration obj1, IfcTextDecoration obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcTextDecoration obj1, IfcTextDecoration obj2)
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
}
