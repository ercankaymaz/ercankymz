using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcTaskTime", 1294)]
public class IfcTaskTime : IfcSchedulingTime, IInstantiableEntity, IPersistEntity, IPersist, IIfcTaskTime, IIfcSchedulingTime, IEquatable<IfcTaskTime>
{
	private IfcTaskDurationEnum? _durationType;

	private IfcDuration? _scheduleDuration;

	private IfcDateTime? _scheduleStart;

	private IfcDateTime? _scheduleFinish;

	private IfcDateTime? _earlyStart;

	private IfcDateTime? _earlyFinish;

	private IfcDateTime? _lateStart;

	private IfcDateTime? _lateFinish;

	private IfcDuration? _freeFloat;

	private IfcDuration? _totalFloat;

	private IfcBoolean? _isCritical;

	private IfcDateTime? _statusTime;

	private IfcDuration? _actualDuration;

	private IfcDateTime? _actualStart;

	private IfcDateTime? _actualFinish;

	private IfcDuration? _remainingTime;

	private IfcPositiveRatioMeasure? _completion;

	IfcTaskDurationEnum? IIfcTaskTime.DurationType
	{
		get
		{
			return DurationType;
		}
		set
		{
			DurationType = value;
		}
	}

	IfcDuration? IIfcTaskTime.ScheduleDuration
	{
		get
		{
			return ScheduleDuration;
		}
		set
		{
			ScheduleDuration = value;
		}
	}

	IfcDateTime? IIfcTaskTime.ScheduleStart
	{
		get
		{
			return ScheduleStart;
		}
		set
		{
			ScheduleStart = value;
		}
	}

	IfcDateTime? IIfcTaskTime.ScheduleFinish
	{
		get
		{
			return ScheduleFinish;
		}
		set
		{
			ScheduleFinish = value;
		}
	}

	IfcDateTime? IIfcTaskTime.EarlyStart
	{
		get
		{
			return EarlyStart;
		}
		set
		{
			EarlyStart = value;
		}
	}

	IfcDateTime? IIfcTaskTime.EarlyFinish
	{
		get
		{
			return EarlyFinish;
		}
		set
		{
			EarlyFinish = value;
		}
	}

	IfcDateTime? IIfcTaskTime.LateStart
	{
		get
		{
			return LateStart;
		}
		set
		{
			LateStart = value;
		}
	}

	IfcDateTime? IIfcTaskTime.LateFinish
	{
		get
		{
			return LateFinish;
		}
		set
		{
			LateFinish = value;
		}
	}

	IfcDuration? IIfcTaskTime.FreeFloat
	{
		get
		{
			return FreeFloat;
		}
		set
		{
			FreeFloat = value;
		}
	}

	IfcDuration? IIfcTaskTime.TotalFloat
	{
		get
		{
			return TotalFloat;
		}
		set
		{
			TotalFloat = value;
		}
	}

	IfcBoolean? IIfcTaskTime.IsCritical
	{
		get
		{
			return IsCritical;
		}
		set
		{
			IsCritical = value;
		}
	}

	IfcDateTime? IIfcTaskTime.StatusTime
	{
		get
		{
			return StatusTime;
		}
		set
		{
			StatusTime = value;
		}
	}

	IfcDuration? IIfcTaskTime.ActualDuration
	{
		get
		{
			return ActualDuration;
		}
		set
		{
			ActualDuration = value;
		}
	}

	IfcDateTime? IIfcTaskTime.ActualStart
	{
		get
		{
			return ActualStart;
		}
		set
		{
			ActualStart = value;
		}
	}

	IfcDateTime? IIfcTaskTime.ActualFinish
	{
		get
		{
			return ActualFinish;
		}
		set
		{
			ActualFinish = value;
		}
	}

	IfcDuration? IIfcTaskTime.RemainingTime
	{
		get
		{
			return RemainingTime;
		}
		set
		{
			RemainingTime = value;
		}
	}

	IfcPositiveRatioMeasure? IIfcTaskTime.Completion
	{
		get
		{
			return Completion;
		}
		set
		{
			Completion = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 4)]
	public IfcTaskDurationEnum? DurationType
	{
		get
		{
			if (_activated)
			{
				return _durationType;
			}
			Activate();
			return _durationType;
		}
		set
		{
			SetValue(delegate(IfcTaskDurationEnum? v)
			{
				_durationType = v;
			}, _durationType, value, "DurationType", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcDuration? ScheduleDuration
	{
		get
		{
			if (_activated)
			{
				return _scheduleDuration;
			}
			Activate();
			return _scheduleDuration;
		}
		set
		{
			SetValue(delegate(IfcDuration? v)
			{
				_scheduleDuration = v;
			}, _scheduleDuration, value, "ScheduleDuration", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcDateTime? ScheduleStart
	{
		get
		{
			if (_activated)
			{
				return _scheduleStart;
			}
			Activate();
			return _scheduleStart;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_scheduleStart = v;
			}, _scheduleStart, value, "ScheduleStart", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcDateTime? ScheduleFinish
	{
		get
		{
			if (_activated)
			{
				return _scheduleFinish;
			}
			Activate();
			return _scheduleFinish;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_scheduleFinish = v;
			}, _scheduleFinish, value, "ScheduleFinish", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcDateTime? EarlyStart
	{
		get
		{
			if (_activated)
			{
				return _earlyStart;
			}
			Activate();
			return _earlyStart;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_earlyStart = v;
			}, _earlyStart, value, "EarlyStart", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcDateTime? EarlyFinish
	{
		get
		{
			if (_activated)
			{
				return _earlyFinish;
			}
			Activate();
			return _earlyFinish;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_earlyFinish = v;
			}, _earlyFinish, value, "EarlyFinish", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcDateTime? LateStart
	{
		get
		{
			if (_activated)
			{
				return _lateStart;
			}
			Activate();
			return _lateStart;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_lateStart = v;
			}, _lateStart, value, "LateStart", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcDateTime? LateFinish
	{
		get
		{
			if (_activated)
			{
				return _lateFinish;
			}
			Activate();
			return _lateFinish;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_lateFinish = v;
			}, _lateFinish, value, "LateFinish", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcDuration? FreeFloat
	{
		get
		{
			if (_activated)
			{
				return _freeFloat;
			}
			Activate();
			return _freeFloat;
		}
		set
		{
			SetValue(delegate(IfcDuration? v)
			{
				_freeFloat = v;
			}, _freeFloat, value, "FreeFloat", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcDuration? TotalFloat
	{
		get
		{
			if (_activated)
			{
				return _totalFloat;
			}
			Activate();
			return _totalFloat;
		}
		set
		{
			SetValue(delegate(IfcDuration? v)
			{
				_totalFloat = v;
			}, _totalFloat, value, "TotalFloat", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public IfcBoolean? IsCritical
	{
		get
		{
			if (_activated)
			{
				return _isCritical;
			}
			Activate();
			return _isCritical;
		}
		set
		{
			SetValue(delegate(IfcBoolean? v)
			{
				_isCritical = v;
			}, _isCritical, value, "IsCritical", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public IfcDateTime? StatusTime
	{
		get
		{
			if (_activated)
			{
				return _statusTime;
			}
			Activate();
			return _statusTime;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_statusTime = v;
			}, _statusTime, value, "StatusTime", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public IfcDuration? ActualDuration
	{
		get
		{
			if (_activated)
			{
				return _actualDuration;
			}
			Activate();
			return _actualDuration;
		}
		set
		{
			SetValue(delegate(IfcDuration? v)
			{
				_actualDuration = v;
			}, _actualDuration, value, "ActualDuration", 16);
		}
	}

	[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public IfcDateTime? ActualStart
	{
		get
		{
			if (_activated)
			{
				return _actualStart;
			}
			Activate();
			return _actualStart;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_actualStart = v;
			}, _actualStart, value, "ActualStart", 17);
		}
	}

	[EntityAttribute(18, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
	public IfcDateTime? ActualFinish
	{
		get
		{
			if (_activated)
			{
				return _actualFinish;
			}
			Activate();
			return _actualFinish;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_actualFinish = v;
			}, _actualFinish, value, "ActualFinish", 18);
		}
	}

	[EntityAttribute(19, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public IfcDuration? RemainingTime
	{
		get
		{
			if (_activated)
			{
				return _remainingTime;
			}
			Activate();
			return _remainingTime;
		}
		set
		{
			SetValue(delegate(IfcDuration? v)
			{
				_remainingTime = v;
			}, _remainingTime, value, "RemainingTime", 19);
		}
	}

	[EntityAttribute(20, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public IfcPositiveRatioMeasure? Completion
	{
		get
		{
			if (_activated)
			{
				return _completion;
			}
			Activate();
			return _completion;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_completion = v;
			}, _completion, value, "Completion", 20);
		}
	}

	internal IfcTaskTime(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_durationType = (IfcTaskDurationEnum)Enum.Parse(typeof(IfcTaskDurationEnum), value.EnumVal, ignoreCase: true);
			break;
		case 4:
			_scheduleDuration = value.StringVal;
			break;
		case 5:
			_scheduleStart = value.StringVal;
			break;
		case 6:
			_scheduleFinish = value.StringVal;
			break;
		case 7:
			_earlyStart = value.StringVal;
			break;
		case 8:
			_earlyFinish = value.StringVal;
			break;
		case 9:
			_lateStart = value.StringVal;
			break;
		case 10:
			_lateFinish = value.StringVal;
			break;
		case 11:
			_freeFloat = value.StringVal;
			break;
		case 12:
			_totalFloat = value.StringVal;
			break;
		case 13:
			_isCritical = value.BooleanVal;
			break;
		case 14:
			_statusTime = value.StringVal;
			break;
		case 15:
			_actualDuration = value.StringVal;
			break;
		case 16:
			_actualStart = value.StringVal;
			break;
		case 17:
			_actualFinish = value.StringVal;
			break;
		case 18:
			_remainingTime = value.StringVal;
			break;
		case 19:
			_completion = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTaskTime other)
	{
		return this == other;
	}
}
