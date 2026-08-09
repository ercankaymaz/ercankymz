using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcWorkTime", 1319)]
public class IfcWorkTime : IfcSchedulingTime, IInstantiableEntity, IPersistEntity, IPersist, IIfcWorkTime, IIfcSchedulingTime, IContainsEntityReferences, IEquatable<IfcWorkTime>
{
	private IfcRecurrencePattern _recurrencePattern;

	private IfcDate? _start;

	private IfcDate? _finish;

	IIfcRecurrencePattern IIfcWorkTime.RecurrencePattern
	{
		get
		{
			return RecurrencePattern;
		}
		set
		{
			RecurrencePattern = value as IfcRecurrencePattern;
		}
	}

	IfcDate? IIfcWorkTime.Start
	{
		get
		{
			return Start;
		}
		set
		{
			Start = value;
		}
	}

	IfcDate? IIfcWorkTime.Finish
	{
		get
		{
			return Finish;
		}
		set
		{
			Finish = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcRecurrencePattern RecurrencePattern
	{
		get
		{
			if (_activated)
			{
				return _recurrencePattern;
			}
			Activate();
			return _recurrencePattern;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcRecurrencePattern v)
			{
				_recurrencePattern = v;
			}, _recurrencePattern, value, "RecurrencePattern", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcDate? Start
	{
		get
		{
			if (_activated)
			{
				return _start;
			}
			Activate();
			return _start;
		}
		set
		{
			SetValue(delegate(IfcDate? v)
			{
				_start = v;
			}, _start, value, "Start", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcDate? Finish
	{
		get
		{
			if (_activated)
			{
				return _finish;
			}
			Activate();
			return _finish;
		}
		set
		{
			SetValue(delegate(IfcDate? v)
			{
				_finish = v;
			}, _finish, value, "Finish", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RecurrencePattern != null)
			{
				yield return RecurrencePattern;
			}
		}
	}

	internal IfcWorkTime(IModel model, int label, bool activated)
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
			_recurrencePattern = (IfcRecurrencePattern)value.EntityVal;
			break;
		case 4:
			_start = value.StringVal;
			break;
		case 5:
			_finish = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWorkTime other)
	{
		return this == other;
	}
}
