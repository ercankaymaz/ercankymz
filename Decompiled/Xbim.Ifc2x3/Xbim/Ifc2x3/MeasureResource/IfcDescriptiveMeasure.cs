using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcDescriptiveMeasure", 131)]
[DefinedType(typeof(string))]
public struct IfcDescriptiveMeasure : IfcMeasureValue, IfcValue, IExpressSelectType, IPersist, IExpressValueType, IfcSizeSelect, IExpressStringType, IEquatable<string>
{
	private string _value;

	public object Value => _value;

	string IExpressStringType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(string);

	public override string ToString()
	{
		return _value ?? "";
	}

	public IfcDescriptiveMeasure(string val)
	{
		_value = val;
	}

	public static implicit operator IfcDescriptiveMeasure(string value)
	{
		return new IfcDescriptiveMeasure(value);
	}

	public static implicit operator string(IfcDescriptiveMeasure obj)
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
		return ((IfcDescriptiveMeasure)obj)._value == _value;
	}

	public bool Equals(string other)
	{
		return this == (IfcDescriptiveMeasure)other;
	}

	public static bool operator ==(IfcDescriptiveMeasure obj1, IfcDescriptiveMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcDescriptiveMeasure obj1, IfcDescriptiveMeasure obj2)
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
