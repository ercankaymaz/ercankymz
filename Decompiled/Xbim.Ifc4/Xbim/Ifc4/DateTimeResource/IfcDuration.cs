using System;
using System.Xml;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.XbimExtensions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcDuration", 991)]
[DefinedType(typeof(string))]
public struct IfcDuration : IfcSimpleValue, IfcValue, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IIfcValue, IExpressValueType, IIfcSimpleValue, IfcTimeOrRatioSelect, IIfcTimeOrRatioSelect, IExpressStringType, IEquatable<string>
{
	private string _value;

	public object Value => _value;

	string IExpressStringType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(string);

	public override string ToString()
	{
		return _value ?? "";
	}

	public IfcDuration(string val)
	{
		_value = val;
	}

	public static implicit operator IfcDuration(string value)
	{
		return new IfcDuration(value);
	}

	public static implicit operator string(IfcDuration obj)
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
		return ((IfcDuration)obj)._value == _value;
	}

	public bool Equals(string other)
	{
		return this == (IfcDuration)other;
	}

	public static bool operator ==(IfcDuration obj1, IfcDuration obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcDuration obj1, IfcDuration obj2)
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

	public TimeSpan ToTimeSpan()
	{
		return XmlConvert.ToTimeSpan(Value.ToString());
	}

	public static implicit operator IfcDuration(TimeSpan value)
	{
		return new IfcDuration(TimeSpanToString(value));
	}

	public static implicit operator TimeSpan(IfcDuration obj)
	{
		return TimeSpanExtensions.Iso8601DurationToTimeSpan(obj);
	}

	private static string TimeSpanToString(TimeSpan span)
	{
		return span.ToIso8601Representation();
	}
}
