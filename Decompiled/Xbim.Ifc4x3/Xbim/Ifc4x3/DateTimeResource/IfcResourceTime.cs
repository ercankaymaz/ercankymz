using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.DateTimeResource;

[ExpressType("IfcResourceTime", 1259)]
public class IfcResourceTime : IfcSchedulingTime, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcResourceTime>, IIfcResourceTime, IIfcSchedulingTime
{
	private IfcDuration? _scheduleWork;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? _scheduleUsage;

	private IfcDateTime? _scheduleStart;

	private IfcDateTime? _scheduleFinish;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _scheduleContour;

	private IfcDuration? _levelingDelay;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean? _isOverAllocated;

	private IfcDateTime? _statusTime;

	private IfcDuration? _actualWork;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? _actualUsage;

	private IfcDateTime? _actualStart;

	private IfcDateTime? _actualFinish;

	private IfcDuration? _remainingWork;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? _remainingUsage;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? _completion;

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
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? ScheduleUsage
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? v)
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
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? ScheduleContour
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
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
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean? IsOverAllocated
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean? v)
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
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? ActualUsage
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? v)
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
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? RemainingUsage
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? v)
			{
				_remainingUsage = v;
			}, _remainingUsage, value, "RemainingUsage", 17);
		}
	}

	[EntityAttribute(18, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? Completion
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure? v)
			{
				_completion = v;
			}, _completion, value, "Completion", 18);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 4)]
	Xbim.Ifc4.DateTimeResource.IfcDuration? IIfcResourceTime.ScheduleWork
	{
		get
		{
			if (!ScheduleWork.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDuration(ScheduleWork.Value);
		}
		set
		{
			ScheduleWork = (value.HasValue ? new IfcDuration?(new IfcDuration(value.Value)) : ((IfcDuration?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure? IIfcResourceTime.ScheduleUsage
	{
		get
		{
			if (!ScheduleUsage.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure(ScheduleUsage.Value);
		}
		set
		{
			ScheduleUsage = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 6)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcResourceTime.ScheduleStart
	{
		get
		{
			if (!ScheduleStart.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(ScheduleStart.Value);
		}
		set
		{
			ScheduleStart = (value.HasValue ? new IfcDateTime?(new IfcDateTime(value.Value)) : ((IfcDateTime?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 7)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcResourceTime.ScheduleFinish
	{
		get
		{
			if (!ScheduleFinish.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(ScheduleFinish.Value);
		}
		set
		{
			ScheduleFinish = (value.HasValue ? new IfcDateTime?(new IfcDateTime(value.Value)) : ((IfcDateTime?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcResourceTime.ScheduleContour
	{
		get
		{
			if (!ScheduleContour.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ScheduleContour.Value);
		}
		set
		{
			ScheduleContour = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 9)]
	Xbim.Ifc4.DateTimeResource.IfcDuration? IIfcResourceTime.LevelingDelay
	{
		get
		{
			if (!LevelingDelay.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDuration(LevelingDelay.Value);
		}
		set
		{
			LevelingDelay = (value.HasValue ? new IfcDuration?(new IfcDuration(value.Value)) : ((IfcDuration?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 10)]
	Xbim.Ifc4.MeasureResource.IfcBoolean? IIfcResourceTime.IsOverAllocated
	{
		get
		{
			if (!IsOverAllocated.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(IsOverAllocated.Value);
		}
		set
		{
			IsOverAllocated = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcBoolean?(new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcBoolean?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 11)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcResourceTime.StatusTime
	{
		get
		{
			if (!StatusTime.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(StatusTime.Value);
		}
		set
		{
			StatusTime = (value.HasValue ? new IfcDateTime?(new IfcDateTime(value.Value)) : ((IfcDateTime?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 12)]
	Xbim.Ifc4.DateTimeResource.IfcDuration? IIfcResourceTime.ActualWork
	{
		get
		{
			if (!ActualWork.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDuration(ActualWork.Value);
		}
		set
		{
			ActualWork = (value.HasValue ? new IfcDuration?(new IfcDuration(value.Value)) : ((IfcDuration?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 13)]
	Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure? IIfcResourceTime.ActualUsage
	{
		get
		{
			if (!ActualUsage.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure(ActualUsage.Value);
		}
		set
		{
			ActualUsage = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 14)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcResourceTime.ActualStart
	{
		get
		{
			if (!ActualStart.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(ActualStart.Value);
		}
		set
		{
			ActualStart = (value.HasValue ? new IfcDateTime?(new IfcDateTime(value.Value)) : ((IfcDateTime?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 15)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcResourceTime.ActualFinish
	{
		get
		{
			if (!ActualFinish.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(ActualFinish.Value);
		}
		set
		{
			ActualFinish = (value.HasValue ? new IfcDateTime?(new IfcDateTime(value.Value)) : ((IfcDateTime?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 16)]
	Xbim.Ifc4.DateTimeResource.IfcDuration? IIfcResourceTime.RemainingWork
	{
		get
		{
			if (!RemainingWork.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDuration(RemainingWork.Value);
		}
		set
		{
			RemainingWork = (value.HasValue ? new IfcDuration?(new IfcDuration(value.Value)) : ((IfcDuration?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 17)]
	Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure? IIfcResourceTime.RemainingUsage
	{
		get
		{
			if (!RemainingUsage.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure(RemainingUsage.Value);
		}
		set
		{
			RemainingUsage = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcResourceTime), 18)]
	Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure? IIfcResourceTime.Completion
	{
		get
		{
			if (!Completion.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure(Completion.Value);
		}
		set
		{
			Completion = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure?)null));
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
