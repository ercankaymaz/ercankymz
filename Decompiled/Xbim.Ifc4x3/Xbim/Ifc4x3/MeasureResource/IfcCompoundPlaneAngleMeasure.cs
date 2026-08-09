using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.CostResource;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcCompoundPlaneAngleMeasure", 255)]
[DefinedType(typeof(List<long>))]
public struct IfcCompoundPlaneAngleMeasure : IfcDerivedMeasureValue, IfcValue, IfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IExpressValueType, IExpressComplexType, IEquatable<List<long>>, IEnumerable<long>, IEnumerable
{
	private List<long> _value;

	public object Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(List<long>);

	IEnumerable<object> IExpressComplexType.Properties
	{
		get
		{
			if (_value == null)
			{
				yield break;
			}
			foreach (long item in _value)
			{
				yield return item;
			}
		}
	}

	public double AsDouble
	{
		get
		{
			int count = _value.Count;
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			if (count > 3)
			{
				num4 = _value[3];
			}
			if (count > 2)
			{
				num3 = _value[2];
			}
			if (count > 1)
			{
				num2 = _value[1];
			}
			if (count > 0)
			{
				num = _value[0];
			}
			return num + num2 / 60.0 + num3 / 3600.0 + num4 / 3600000000.0;
		}
	}

	public static void Add(ref IfcCompoundPlaneAngleMeasure comp, long component)
	{
		if (comp._value == null)
		{
			comp.Initialise(component);
		}
		else
		{
			comp._value.Add(component);
		}
	}

	private void Initialise(long comp)
	{
		_value = new List<long> { comp };
	}

	public IfcCompoundPlaneAngleMeasure(List<long> val)
	{
		_value = new List<long>(val);
	}

	public static implicit operator IfcCompoundPlaneAngleMeasure(List<long> value)
	{
		return new IfcCompoundPlaneAngleMeasure(value);
	}

	public static implicit operator List<long>(IfcCompoundPlaneAngleMeasure obj)
	{
		return new List<long>(obj._value);
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
		return ((IfcCompoundPlaneAngleMeasure)obj)._value.SequenceEqual(_value);
	}

	public bool Equals(List<long> other)
	{
		return this == other;
	}

	public static bool operator ==(IfcCompoundPlaneAngleMeasure obj1, IfcCompoundPlaneAngleMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcCompoundPlaneAngleMeasure obj1, IfcCompoundPlaneAngleMeasure obj2)
	{
		return !object.Equals(obj1, obj2);
	}

	public override int GetHashCode()
	{
		if (Value == null)
		{
			return base.GetHashCode();
		}
		return _value.Sum((long o) => o.GetHashCode());
	}

	void IPersist.Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex != 0)
		{
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
		if (_value == null)
		{
			_value = new List<long>();
		}
		_value.Add(value.IntegerVal);
	}

	public static IfcCompoundPlaneAngleMeasure FromDouble(double degreeAngle)
	{
		int num = (int)degreeAngle;
		int num2 = (int)((degreeAngle - (double)num) * 60.0);
		int num3 = (int)(((degreeAngle - (double)num) * 60.0 - (double)num2) * 60.0);
		int num4 = (int)((((degreeAngle - (double)num) * 60.0 - (double)num2) * 60.0 - (double)num3) * 1000000.0);
		return new IfcCompoundPlaneAngleMeasure(new List<long> { num, num2, num3, num4 });
	}

	public IEnumerator<long> GetEnumerator()
	{
		return _value.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
