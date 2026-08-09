using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcRegularTimeSeries", 417)]
public class IfcRegularTimeSeries : IfcTimeSeries, IInstantiableEntity, IPersistEntity, IPersist, IIfcRegularTimeSeries, IIfcTimeSeries, IfcMetricValueSelect, IIfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IEquatable<IfcRegularTimeSeries>
{
	private IfcTimeMeasure _timeStep;

	private readonly ItemSet<IfcTimeSeriesValue> _values;

	IfcTimeMeasure IIfcRegularTimeSeries.TimeStep
	{
		get
		{
			return TimeStep;
		}
		set
		{
			TimeStep = value;
		}
	}

	IItemSet<IIfcTimeSeriesValue> IIfcRegularTimeSeries.Values => new ProxyItemSet<IfcTimeSeriesValue, IIfcTimeSeriesValue>(Values);

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcTimeMeasure TimeStep
	{
		get
		{
			if (_activated)
			{
				return _timeStep;
			}
			Activate();
			return _timeStep;
		}
		set
		{
			SetValue(delegate(IfcTimeMeasure v)
			{
				_timeStep = v;
			}, _timeStep, value, "TimeStep", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 11)]
	public IItemSet<IfcTimeSeriesValue> Values
	{
		get
		{
			if (_activated)
			{
				return _values;
			}
			Activate();
			return _values;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Unit != null)
			{
				yield return base.Unit;
			}
			foreach (IfcTimeSeriesValue value in Values)
			{
				yield return value;
			}
		}
	}

	internal IfcRegularTimeSeries(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_values = new ItemSet<IfcTimeSeriesValue>(this, 0, 10);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_timeStep = value.RealVal;
			break;
		case 9:
			_values.InternalAdd((IfcTimeSeriesValue)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRegularTimeSeries other)
	{
		return this == other;
	}
}
