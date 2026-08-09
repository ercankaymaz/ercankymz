using System;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcTextAlignment", 583)]
[DefinedType(typeof(string))]
public struct IfcTextAlignment : IExpressValueType, IPersist, IExpressStringType, IEquatable<string>
{
	private string _value;

	public object Value => _value;

	string IExpressStringType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(string);

	public override string ToString()
	{
		return _value ?? "";
	}

	public IfcTextAlignment(string val)
	{
		_value = val;
	}

	public static implicit operator IfcTextAlignment(string value)
	{
		return new IfcTextAlignment(value);
	}

	public static implicit operator string(IfcTextAlignment obj)
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
		return ((IfcTextAlignment)obj)._value == _value;
	}

	public bool Equals(string other)
	{
		return this == (IfcTextAlignment)other;
	}

	public static bool operator ==(IfcTextAlignment obj1, IfcTextAlignment obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcTextAlignment obj1, IfcTextAlignment obj2)
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
