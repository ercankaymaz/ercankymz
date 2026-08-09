using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.StructuralLoadResource;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcBoolean", 616)]
[DefinedType(typeof(bool))]
public struct IfcBoolean : IfcModulusOfRotationalSubgradeReactionSelect, IExpressSelectType, IPersist, IExpressValueType, IfcModulusOfSubgradeReactionSelect, IfcModulusOfTranslationalSubgradeReactionSelect, IfcRotationalStiffnessSelect, IfcSimpleValue, IfcValue, IfcAppliedValueSelect, IfcMetricValueSelect, IfcTranslationalStiffnessSelect, IfcWarpingStiffnessSelect, IExpressBooleanType, IEquatable<bool>
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

	public IfcBoolean(bool val)
	{
		_value = val;
	}

	public IfcBoolean(string val)
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

	public static implicit operator IfcBoolean(bool value)
	{
		return new IfcBoolean(value);
	}

	public static implicit operator bool(IfcBoolean obj)
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
		return ((IfcBoolean)obj)._value == _value;
	}

	public bool Equals(bool other)
	{
		return this == other;
	}

	public static bool operator ==(IfcBoolean obj1, IfcBoolean obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcBoolean obj1, IfcBoolean obj2)
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
