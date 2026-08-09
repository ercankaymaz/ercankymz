using System;
using System.Globalization;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.PresentationAppearanceResource;
using Xbim.Ifc4x3.StructuralElementsDomain;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcLengthMeasure", 409)]
[DefinedType(typeof(double))]
public struct IfcLengthMeasure : IIfcLengthMeasure, IExpressRealType, IfcBendingParameterSelect, IExpressSelectType, IPersist, IExpressValueType, IfcCurveMeasureSelect, IfcMeasureValue, IfcValue, IfcAppliedValueSelect, IfcMetricValueSelect, IfcSizeSelect, IEquatable<double>
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

	public IfcLengthMeasure(double val)
	{
		_value = val;
	}

	public IfcLengthMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcLengthMeasure(double value)
	{
		return new IfcLengthMeasure(value);
	}

	public static implicit operator double(IfcLengthMeasure obj)
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
		return ((IfcLengthMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcLengthMeasure obj1, IfcLengthMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcLengthMeasure obj1, IfcLengthMeasure obj2)
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

	static IfcLengthMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
