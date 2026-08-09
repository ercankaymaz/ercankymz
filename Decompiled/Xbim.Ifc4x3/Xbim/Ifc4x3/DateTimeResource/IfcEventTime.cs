using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.DateTimeResource;

[ExpressType("IfcEventTime", 1169)]
public class IfcEventTime : IfcSchedulingTime, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcEventTime>, IIfcEventTime, IIfcSchedulingTime
{
	private IfcDateTime? _actualDate;

	private IfcDateTime? _earlyDate;

	private IfcDateTime? _lateDate;

	private IfcDateTime? _scheduleDate;

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcDateTime? ActualDate
	{
		get
		{
			if (_activated)
			{
				return _actualDate;
			}
			Activate();
			return _actualDate;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_actualDate = v;
			}, _actualDate, value, "ActualDate", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcDateTime? EarlyDate
	{
		get
		{
			if (_activated)
			{
				return _earlyDate;
			}
			Activate();
			return _earlyDate;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_earlyDate = v;
			}, _earlyDate, value, "EarlyDate", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcDateTime? LateDate
	{
		get
		{
			if (_activated)
			{
				return _lateDate;
			}
			Activate();
			return _lateDate;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_lateDate = v;
			}, _lateDate, value, "LateDate", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcDateTime? ScheduleDate
	{
		get
		{
			if (_activated)
			{
				return _scheduleDate;
			}
			Activate();
			return _scheduleDate;
		}
		set
		{
			SetValue(delegate(IfcDateTime? v)
			{
				_scheduleDate = v;
			}, _scheduleDate, value, "ScheduleDate", 7);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcEventTime), 4)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcEventTime.ActualDate
	{
		get
		{
			if (!ActualDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(ActualDate.Value);
		}
		set
		{
			ActualDate = (value.HasValue ? new IfcDateTime?(new IfcDateTime(value.Value)) : ((IfcDateTime?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcEventTime), 5)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcEventTime.EarlyDate
	{
		get
		{
			if (!EarlyDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(EarlyDate.Value);
		}
		set
		{
			EarlyDate = (value.HasValue ? new IfcDateTime?(new IfcDateTime(value.Value)) : ((IfcDateTime?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcEventTime), 6)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcEventTime.LateDate
	{
		get
		{
			if (!LateDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(LateDate.Value);
		}
		set
		{
			LateDate = (value.HasValue ? new IfcDateTime?(new IfcDateTime(value.Value)) : ((IfcDateTime?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcEventTime), 7)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcEventTime.ScheduleDate
	{
		get
		{
			if (!ScheduleDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(ScheduleDate.Value);
		}
		set
		{
			ScheduleDate = (value.HasValue ? new IfcDateTime?(new IfcDateTime(value.Value)) : ((IfcDateTime?)null));
		}
	}

	internal IfcEventTime(IModel model, int label, bool activated)
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
			_actualDate = value.StringVal;
			break;
		case 4:
			_earlyDate = value.StringVal;
			break;
		case 5:
			_lateDate = value.StringVal;
			break;
		case 6:
			_scheduleDate = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEventTime other)
	{
		return this == other;
	}
}
