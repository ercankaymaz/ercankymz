using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.DateTimeResource;

[ExpressType("IfcRecurrencePattern", 1243)]
public class IfcRecurrencePattern : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcRecurrencePattern>, IIfcRecurrencePattern
{
	private IfcRecurrenceTypeEnum _recurrenceType;

	private readonly OptionalItemSet<IfcDayInMonthNumber> _dayComponent;

	private readonly OptionalItemSet<IfcDayInWeekNumber> _weekdayComponent;

	private readonly OptionalItemSet<IfcMonthInYearNumber> _monthComponent;

	private Xbim.Ifc4x3.MeasureResource.IfcInteger? _position;

	private Xbim.Ifc4x3.MeasureResource.IfcInteger? _interval;

	private Xbim.Ifc4x3.MeasureResource.IfcInteger? _occurrences;

	private readonly OptionalItemSet<IfcTimePeriod> _timePeriods;

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
	public Xbim.Ifc4x3.MeasureResource.IfcInteger? Position
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcInteger? v)
			{
				_position = v;
			}, _position, value, "Position", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger? Interval
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcInteger? v)
			{
				_interval = v;
			}, _interval, value, "Interval", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger? Occurrences
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcInteger? v)
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

	[CrossSchemaAttribute(typeof(IIfcRecurrencePattern), 1)]
	Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum IIfcRecurrencePattern.RecurrenceType
	{
		get
		{
			return RecurrenceType switch
			{
				IfcRecurrenceTypeEnum.BY_DAY_COUNT => Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.BY_DAY_COUNT, 
				IfcRecurrenceTypeEnum.BY_WEEKDAY_COUNT => Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.BY_WEEKDAY_COUNT, 
				IfcRecurrenceTypeEnum.DAILY => Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.DAILY, 
				IfcRecurrenceTypeEnum.MONTHLY_BY_DAY_OF_MONTH => Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.MONTHLY_BY_DAY_OF_MONTH, 
				IfcRecurrenceTypeEnum.MONTHLY_BY_POSITION => Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.MONTHLY_BY_POSITION, 
				IfcRecurrenceTypeEnum.WEEKLY => Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.WEEKLY, 
				IfcRecurrenceTypeEnum.YEARLY_BY_DAY_OF_MONTH => Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.YEARLY_BY_DAY_OF_MONTH, 
				IfcRecurrenceTypeEnum.YEARLY_BY_POSITION => Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.YEARLY_BY_POSITION, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.DAILY:
				RecurrenceType = IfcRecurrenceTypeEnum.DAILY;
				break;
			case Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.WEEKLY:
				RecurrenceType = IfcRecurrenceTypeEnum.WEEKLY;
				break;
			case Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.MONTHLY_BY_DAY_OF_MONTH:
				RecurrenceType = IfcRecurrenceTypeEnum.MONTHLY_BY_DAY_OF_MONTH;
				break;
			case Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.MONTHLY_BY_POSITION:
				RecurrenceType = IfcRecurrenceTypeEnum.MONTHLY_BY_POSITION;
				break;
			case Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.BY_DAY_COUNT:
				RecurrenceType = IfcRecurrenceTypeEnum.BY_DAY_COUNT;
				break;
			case Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.BY_WEEKDAY_COUNT:
				RecurrenceType = IfcRecurrenceTypeEnum.BY_WEEKDAY_COUNT;
				break;
			case Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.YEARLY_BY_DAY_OF_MONTH:
				RecurrenceType = IfcRecurrenceTypeEnum.YEARLY_BY_DAY_OF_MONTH;
				break;
			case Xbim.Ifc4.Interfaces.IfcRecurrenceTypeEnum.YEARLY_BY_POSITION:
				RecurrenceType = IfcRecurrenceTypeEnum.YEARLY_BY_POSITION;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRecurrencePattern), 2)]
	IItemSet<Xbim.Ifc4.DateTimeResource.IfcDayInMonthNumber> IIfcRecurrencePattern.DayComponent => new ProxyValueSet<IfcDayInMonthNumber, Xbim.Ifc4.DateTimeResource.IfcDayInMonthNumber>(DayComponent, (IfcDayInMonthNumber s) => new Xbim.Ifc4.DateTimeResource.IfcDayInMonthNumber(s), (Xbim.Ifc4.DateTimeResource.IfcDayInMonthNumber t) => new IfcDayInMonthNumber(t));

	[CrossSchemaAttribute(typeof(IIfcRecurrencePattern), 3)]
	IItemSet<Xbim.Ifc4.DateTimeResource.IfcDayInWeekNumber> IIfcRecurrencePattern.WeekdayComponent => new ProxyValueSet<IfcDayInWeekNumber, Xbim.Ifc4.DateTimeResource.IfcDayInWeekNumber>(WeekdayComponent, (IfcDayInWeekNumber s) => new Xbim.Ifc4.DateTimeResource.IfcDayInWeekNumber(s), (Xbim.Ifc4.DateTimeResource.IfcDayInWeekNumber t) => new IfcDayInWeekNumber(t));

	[CrossSchemaAttribute(typeof(IIfcRecurrencePattern), 4)]
	IItemSet<Xbim.Ifc4.DateTimeResource.IfcMonthInYearNumber> IIfcRecurrencePattern.MonthComponent => new ProxyValueSet<IfcMonthInYearNumber, Xbim.Ifc4.DateTimeResource.IfcMonthInYearNumber>(MonthComponent, (IfcMonthInYearNumber s) => new Xbim.Ifc4.DateTimeResource.IfcMonthInYearNumber(s), (Xbim.Ifc4.DateTimeResource.IfcMonthInYearNumber t) => new IfcMonthInYearNumber(t));

	[CrossSchemaAttribute(typeof(IIfcRecurrencePattern), 5)]
	Xbim.Ifc4.MeasureResource.IfcInteger? IIfcRecurrencePattern.Position
	{
		get
		{
			if (!Position.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcInteger(Position.Value);
		}
		set
		{
			Position = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcInteger?(new Xbim.Ifc4x3.MeasureResource.IfcInteger(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcInteger?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRecurrencePattern), 6)]
	Xbim.Ifc4.MeasureResource.IfcInteger? IIfcRecurrencePattern.Interval
	{
		get
		{
			if (!Interval.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcInteger(Interval.Value);
		}
		set
		{
			Interval = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcInteger?(new Xbim.Ifc4x3.MeasureResource.IfcInteger(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcInteger?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRecurrencePattern), 7)]
	Xbim.Ifc4.MeasureResource.IfcInteger? IIfcRecurrencePattern.Occurrences
	{
		get
		{
			if (!Occurrences.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcInteger(Occurrences.Value);
		}
		set
		{
			Occurrences = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcInteger?(new Xbim.Ifc4x3.MeasureResource.IfcInteger(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcInteger?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRecurrencePattern), 8)]
	IItemSet<IIfcTimePeriod> IIfcRecurrencePattern.TimePeriods => new ProxyItemSet<IfcTimePeriod, IIfcTimePeriod>(TimePeriods);

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
