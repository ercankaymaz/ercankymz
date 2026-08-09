using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.TimeSeriesResource;

[ExpressType("IfcIrregularTimeSeriesValue", 609)]
public class IfcIrregularTimeSeriesValue : PersistEntity, IIfcIrregularTimeSeriesValue, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcIrregularTimeSeriesValue>
{
	private IItemSet<IIfcValue> _listValuesIfc4;

	private IfcDateTimeSelect _timeStamp;

	private readonly ItemSet<IfcValue> _listValues;

	[CrossSchemaAttribute(typeof(IIfcIrregularTimeSeriesValue), 1)]
	IfcDateTime IIfcIrregularTimeSeriesValue.TimeStamp
	{
		get
		{
			if (TimeStamp == null)
			{
				return default(IfcDateTime);
			}
			return new IfcDateTime(TimeStamp.ToISODateTimeString());
		}
		set
		{
			DateTime d = value;
			TimeStamp = base.Model.Instances.New(delegate(IfcDateAndTime dt)
			{
				dt.DateComponent = base.Model.Instances.New(delegate(IfcCalendarDate date)
				{
					date.YearComponent = d.Year;
					date.MonthComponent = d.Month;
					date.DayComponent = d.Day;
				});
				dt.TimeComponent = base.Model.Instances.New(delegate(IfcLocalTime t)
				{
					t.HourComponent = d.Hour;
					t.MinuteComponent = d.Minute;
					t.SecondComponent = d.Second;
				});
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcIrregularTimeSeriesValue), 2)]
	IItemSet<IIfcValue> IIfcIrregularTimeSeriesValue.ListValues => _listValuesIfc4 ?? (_listValuesIfc4 = new ExtendedItemSet<IfcValue, IIfcValue>(ListValues, new ItemSet<IIfcValue>(this, 0, -2), (IfcValue v) => v.ToIfc4(), (IIfcValue v) => v.ToIfc3()));

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcDateTimeSelect TimeStamp
	{
		get
		{
			if (_activated)
			{
				return _timeStamp;
			}
			Activate();
			return _timeStamp;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateTimeSelect v)
			{
				_timeStamp = v;
			}, _timeStamp, value, "TimeStamp", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcValue> ListValues
	{
		get
		{
			if (_activated)
			{
				return _listValues;
			}
			Activate();
			return _listValues;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (TimeStamp != null)
			{
				yield return TimeStamp;
			}
		}
	}

	internal IfcIrregularTimeSeriesValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_listValues = new ItemSet<IfcValue>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_timeStamp = (IfcDateTimeSelect)value.EntityVal;
			break;
		case 1:
			_listValues.InternalAdd((IfcValue)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcIrregularTimeSeriesValue other)
	{
		return this == other;
	}
}
