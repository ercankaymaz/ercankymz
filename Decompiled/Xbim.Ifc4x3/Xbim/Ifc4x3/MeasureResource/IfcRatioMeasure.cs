using System;
using System.Globalization;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.PresentationAppearanceResource;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcRatioMeasure", 606)]
[DefinedType(typeof(double))]
public struct IfcRatioMeasure : IfcMeasureValue, IfcValue, IfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IExpressValueType, IfcSizeSelect, IfcTimeOrRatioSelect, IExpressRealType, IEquatable<double>
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

	public IfcRatioMeasure(double val)
	{
		_value = val;
	}

	public IfcRatioMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcRatioMeasure(double value)
	{
		return new IfcRatioMeasure(value);
	}

	public static implicit operator double(IfcRatioMeasure obj)
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
		return ((IfcRatioMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcRatioMeasure obj1, IfcRatioMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcRatioMeasure obj1, IfcRatioMeasure obj2)
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

	static IfcRatioMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
