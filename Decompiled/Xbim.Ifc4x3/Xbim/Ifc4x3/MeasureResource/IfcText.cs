using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.CostResource;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcText", 537)]
[DefinedType(typeof(string))]
public struct IfcText : IfcSimpleValue, IfcValue, IfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IExpressValueType, IExpressStringType, IEquatable<string>
{
	private string _value;

	public object Value => _value;

	string IExpressStringType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(string);

	public override string ToString()
	{
		return _value ?? "";
	}

	public IfcText(string val)
	{
		_value = val;
	}

	public static implicit operator IfcText(string value)
	{
		return new IfcText(value);
	}

	public static implicit operator string(IfcText obj)
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
		return ((IfcText)obj)._value == _value;
	}

	public bool Equals(string other)
	{
		return this == (IfcText)other;
	}

	public static bool operator ==(IfcText obj1, IfcText obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcText obj1, IfcText obj2)
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
