using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcRecurrencePattern", 1243)]
public class IfcRecurrencePattern : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcRecurrencePattern, IContainsEntityReferences, IEquatable<IfcRecurrencePattern>
{
	private IfcRecurrenceTypeEnum _recurrenceType;

	private readonly OptionalItemSet<IfcDayInMonthNumber> _dayComponent;

	private readonly OptionalItemSet<IfcDayInWeekNumber> _weekdayComponent;

	private readonly OptionalItemSet<IfcMonthInYearNumber> _monthComponent;

	private IfcInteger? _position;

	private IfcInteger? _interval;

	private IfcInteger? _occurrences;

	private readonly OptionalItemSet<IfcTimePeriod> _timePeriods;

	IfcRecurrenceTypeEnum IIfcRecurrencePattern.RecurrenceType
	{
		get
		{
			return RecurrenceType;
		}
		set
		{
			RecurrenceType = value;
		}
	}

	IItemSet<IfcDayInMonthNumber> IIfcRecurrencePattern.DayComponent => DayComponent;

	IItemSet<IfcDayInWeekNumber> IIfcRecurrencePattern.WeekdayComponent => WeekdayComponent;

	IItemSet<IfcMonthInYearNumber> IIfcRecurrencePattern.MonthComponent => MonthComponent;

	IfcInteger? IIfcRecurrencePattern.Position
	{
		get
		{
			return Position;
		}
		set
		{
			Position = value;
		}
	}

	IfcInteger? IIfcRecurrencePattern.Interval
	{
		get
		{
			return Interval;
		}
		set
		{
			Interval = value;
		}
	}

	IfcInteger? IIfcRecurrencePattern.Occurrences
	{
		get
		{
			return Occurrences;
		}
		set
		{
			Occurrences = value;
		}
	}

	IItemSet<IIfcTimePeriod> IIfcRecurrencePattern.TimePeriods => new ProxyItemSet<IfcTimePeriod, IIfcTimePeriod>(TimePeriods);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 1)]
	public IfcRecurrenceTypeEnum RecurrenceType
	{
		get
		{
			if (_activated)
			{
				return _recurrenceType;
			}
			Activate();
			return _recurrenceType;
		}
		set
		{
			SetValue(delegate(IfcRecurrenceTypeEnum v)
			{
				_recurrenceType = v;
			}, _recurrenceType, value, "RecurrenceType", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 2)]
	public IOptionalItemSet<IfcDayInMonthNumber> DayComponent
	{
		get
		{
			if (_activated)
			{
				return _dayComponent;
			}
			Activate();
			return _dayComponent;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 3)]
	public IOptionalItemSet<IfcDayInWeekNumber> WeekdayComponent
	{
		get
		{
			if (_activated)
			{
				return _weekdayComponent;
			}
			Activate();
			return _weekdayComponent;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 4)]
	public IOptionalItemSet<IfcMonthInYearNumber> MonthComponent
	{
		get
		{
			if (_activated)
			{
				return _monthComponent;
			}
			Activate();
			return _monthComponent;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcInteger? Position
	{
		get
		{
			if (_activated)
			{
				return _position;
			}
			Activate();
			return _position;
		}
		set
		{
			SetValue(delegate(IfcInteger? v)
			{
				_position = v;
			}, _position, value, "Position", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcInteger? Interval
	{
		get
		{
			if (_activated)
			{
				return _interval;
			}
			Activate();
			return _interval;
		}
		set
		{
			SetValue(delegate(IfcInteger? v)
			{
				_interval = v;
			}, _interval, value, "Interval", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcInteger? Occurrences
	{
		get
		{
			if (_activated)
			{
				return _occurrences;
			}
			Activate();
			return _occurrences;
		}
		set
		{
			SetValue(delegate(IfcInteger? v)
			{
				_occurrences = v;
			}, _occurrences, value, "Occurrences", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 8)]
	public IOptionalItemSet<IfcTimePeriod> TimePeriods
	{
		get
		{
			if (_activated)
			{
				return _timePeriods;
			}
			Activate();
			return _timePeriods;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcTimePeriod timePeriod in TimePeriods)
			{
				yield return timePeriod;
			}
		}
	}

	internal IfcRecurrencePattern(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_dayComponent = new OptionalItemSet<IfcDayInMonthNumber>(this, 0, 2);
		_weekdayComponent = new OptionalItemSet<IfcDayInWeekNumber>(this, 0, 3);
		_monthComponent = new OptionalItemSet<IfcMonthInYearNumber>(this, 0, 4);
		_timePeriods = new OptionalItemSet<IfcTimePeriod>(this, 0, 8);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_recurrenceType = (IfcRecurrenceTypeEnum)Enum.Parse(typeof(IfcRecurrenceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 1:
			_dayComponent.InternalAdd(value.IntegerVal);
			break;
		case 2:
			_weekdayComponent.InternalAdd(value.IntegerVal);
			break;
		case 3:
			_monthComponent.InternalAdd(value.IntegerVal);
			break;
		case 4:
			_position = value.IntegerVal;
			break;
		case 5:
			_interval = value.IntegerVal;
			break;
		case 6:
			_occurrences = value.IntegerVal;
			break;
		case 7:
			_timePeriods.InternalAdd((IfcTimePeriod)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRecurrencePattern other)
	{
		return this == other;
	}
}
