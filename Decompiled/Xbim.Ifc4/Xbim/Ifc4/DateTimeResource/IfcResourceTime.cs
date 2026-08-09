using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcResourceTime", 1259)]
public class IfcResourceTime : IfcSchedulingTime, IInstantiableEntity, IPersistEntity, IPersist, IIfcResourceTime, IIfcSchedulingTime, IEquatable<IfcResourceTime>
{
	private IfcDuration? _scheduleWork;

	private IfcPositiveRatioMeasure? _scheduleUsage;

	private IfcDateTime? _scheduleStart;

	private IfcDateTime? _scheduleFinish;

	private IfcLabel? _scheduleContour;

	private IfcDuration? _levelingDelay;

	private IfcBoolean? _isOverAllocated;

	private IfcDateTime? _statusTime;

	private IfcDuration? _actualWork;

	private IfcPositiveRatioMeasure? _actualUsage;

	private IfcDateTime? _actualStart;

	private IfcDateTime? _actualFinish;

	private IfcDuration? _remainingWork;

	private IfcPositiveRatioMeasure? _remainingUsage;

	private IfcPositiveRatioMeasure? _completion;

	IfcDuration? IIfcResourceTime.ScheduleWork
	{
		get
		{
			return ScheduleWork;
		}
		set
		{
			ScheduleWork = value;
		}
	}

	IfcPositiveRatioMeasure? IIfcResourceTime.ScheduleUsage
	{
		get
		{
			return ScheduleUsage;
		}
		set
		{
			ScheduleUsage = value;
		}
	}

	IfcDateTime? IIfcResourceTime.ScheduleStart
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

	IfcDateTime? IIfcResourceTime.ScheduleFinish
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

	IfcLabel? IIfcResourceTime.ScheduleContour
	{
		get
		{
			return ScheduleContour;
		}
		set
		{
			ScheduleContour = value;
		}
	}

	IfcDuration? IIfcResourceTime.LevelingDelay
	{
		get
		{
			return LevelingDelay;
		}
		set
		{
			LevelingDelay = value;
		}
	}

	IfcBoolean? IIfcResourceTime.IsOverAllocated
	{
		get
		{
			return IsOverAllocated;
		}
		set
		{
			IsOverAllocated = value;
		}
	}

	IfcDateTime? IIfcResourceTime.StatusTime
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

	IfcDuration? IIfcResourceTime.ActualWork
	{
		get
		{
			return ActualWork;
		}
		set
		{
			ActualWork = value;
		}
	}

	IfcPositiveRatioMeasure? IIfcResourceTime.ActualUsage
	{
		get
		{
			return ActualUsage;
		}
		set
		{
			ActualUsage = value;
		}
	}

	IfcDateTime? IIfcResourceTime.ActualStart
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

	IfcDateTime? IIfcResourceTime.ActualFinish
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

	IfcDuration? IIfcResourceTime.RemainingWork
	{
		get
		{
			return RemainingWork;
		}
		set
		{
			RemainingWork = value;
		}
	}

	IfcPositiveRatioMeasure? IIfcResourceTime.RemainingUsage
	{
		get
		{
			return RemainingUsage;
		}
		set
		{
			RemainingUsage = value;
		}
	}

	IfcPositiveRatioMeasure? IIfcResourceTime.Completion
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

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcDuration? ScheduleWork
	{
		get
		{
			if (_activated)
			{
				return _scheduleWork;
			}
			Activate();
			return _scheduleWork;
		}
		set
		{
			SetValue(delegate(IfcDuration? v)
			{
				_scheduleWork = v;
			}, _scheduleWork, value, "ScheduleWork", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveRatioMeasure? ScheduleUsage
	{
		get
		{
			if (_activated)
			{
				return _scheduleUsage;
			}
			Activate();
			return _scheduleUsage;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_scheduleUsage = v;
			}, _scheduleUsage, value, "ScheduleUsage", 5);
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
	public IfcLabel? ScheduleContour
	{
		get
		{
			if (_activated)
			{
				return _scheduleContour;
			}
			Activate();
			return _scheduleContour;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_scheduleContour = v;
			}, _scheduleContour, value, "ScheduleContour", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcDuration? LevelingDelay
	{
		get
		{
			if (_activated)
			{
				return _levelingDelay;
			}
			Activate();
			return _levelingDelay;
		}
		set
		{
			SetValue(delegate(IfcDuration? v)
			{
				_levelingDelay = v;
			}, _levelingDelay, value, "LevelingDelay", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcBoolean? IsOverAllocated
	{
		get
		{
			if (_activated)
			{
				return _isOverAllocated;
			}
			Activate();
			return _isOverAllocated;
		}
		set
		{
			SetValue(delegate(IfcBoolean? v)
			{
				_isOverAllocated = v;
			}, _isOverAllocated, value, "IsOverAllocated", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
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
			}, _statusTime, value, "StatusTime", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcDuration? ActualWork
	{
		get
		{
			if (_activated)
			{
				return _actualWork;
			}
			Activate();
			return _actualWork;
		}
		set
		{
			SetValue(delegate(IfcDuration? v)
			{
				_actualWork = v;
			}, _actualWork, value, "ActualWork", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcPositiveRatioMeasure? ActualUsage
	{
		get
		{
			if (_activated)
			{
				return _actualUsage;
			}
			Activate();
			return _actualUsage;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_actualUsage = v;
			}, _actualUsage, value, "ActualUsage", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
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
			}, _actualStart, value, "ActualStart", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
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
			}, _actualFinish, value, "ActualFinish", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public IfcDuration? RemainingWork
	{
		get
		{
			if (_activated)
			{
				return _remainingWork;
			}
			Activate();
			return _remainingWork;
		}
		set
		{
			SetValue(delegate(IfcDuration? v)
			{
				_remainingWork = v;
			}, _remainingWork, value, "RemainingWork", 16);
		}
	}

	[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public IfcPositiveRatioMeasure? RemainingUsage
	{
		get
		{
			if (_activated)
			{
				return _remainingUsage;
			}
			Activate();
			return _remainingUsage;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_remainingUsage = v;
			}, _remainingUsage, value, "RemainingUsage", 17);
		}
	}

	[EntityAttribute(18, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
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
			}, _completion, value, "Completion", 18);
		}
	}

	internal IfcResourceTime(IModel model, int label, bool activated)
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
			_scheduleWork = value.StringVal;
			break;
		case 4:
			_scheduleUsage = value.RealVal;
			break;
		case 5:
			_scheduleStart = value.StringVal;
			break;
		case 6:
			_scheduleFinish = value.StringVal;
			break;
		case 7:
			_scheduleContour = value.StringVal;
			break;
		case 8:
			_levelingDelay = value.StringVal;
			break;
		case 9:
			_isOverAllocated = value.BooleanVal;
			break;
		case 10:
			_statusTime = value.StringVal;
			break;
		case 11:
			_actualWork = value.StringVal;
			break;
		case 12:
			_actualUsage = value.RealVal;
			break;
		case 13:
			_actualStart = value.StringVal;
			break;
		case 14:
			_actualFinish = value.StringVal;
			break;
		case 15:
			_remainingWork = value.StringVal;
			break;
		case 16:
			_remainingUsage = value.RealVal;
			break;
		case 17:
			_completion = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcResourceTime other)
	{
		return this == other;
	}
}
