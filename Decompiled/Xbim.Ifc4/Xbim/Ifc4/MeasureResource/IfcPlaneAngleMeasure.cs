using System;
using System.Globalization;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.StructuralElementsDomain;

namespace Xbim.Ifc4.MeasureResource;

[ExpressType("IfcPlaneAngleMeasure", 612)]
[DefinedType(typeof(double))]
public struct IfcPlaneAngleMeasure : IfcBendingParameterSelect, IIfcBendingParameterSelect, IExpressSelectType, IPersist, IExpressValueType, IfcMeasureValue, IfcValue, IfcAppliedValueSelect, IIfcAppliedValueSelect, IfcMetricValueSelect, IIfcMetricValueSelect, IIfcValue, IIfcMeasureValue, IExpressRealType, IEquatable<double>
{
	private double _value;

	private static readonly CultureInfo Culture;

	public object Value => _value;

	double IExpressRealType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(double);

	public override string ToString()
	{
		return _value.ToString("R", Culture);
	}

	public IfcPlaneAngleMeasure(double val)
	{
		_value = val;
	}

	public IfcPlaneAngleMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcPlaneAngleMeasure(double value)
	{
		return new IfcPlaneAngleMeasure(value);
	}

	public static implicit operator double(IfcPlaneAngleMeasure obj)
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
		return ((IfcPlaneAngleMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcPlaneAngleMeasure obj1, IfcPlaneAngleMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcPlaneAngleMeasure obj1, IfcPlaneAngleMeasure obj2)
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
		_value = value.RealVal;
	}

	static IfcPlaneAngleMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
