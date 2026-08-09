using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.DateTimeResource;

[ExpressType("IfcWorkTime", 1319)]
public class IfcWorkTime : IfcSchedulingTime, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcWorkTime>, IIfcWorkTime, IIfcSchedulingTime
{
	private IfcRecurrencePattern _recurrencePattern;

	private IfcDate? _startDate;

	private IfcDate? _finishDate;

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
	public IfcDate? StartDate
	{
		get
		{
			if (_activated)
			{
				return _startDate;
			}
			Activate();
			return _startDate;
		}
		set
		{
			SetValue(delegate(IfcDate? v)
			{
				_startDate = v;
			}, _startDate, value, "StartDate", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcDate? FinishDate
	{
		get
		{
			if (_activated)
			{
				return _finishDate;
			}
			Activate();
			return _finishDate;
		}
		set
		{
			SetValue(delegate(IfcDate? v)
			{
				_finishDate = v;
			}, _finishDate, value, "FinishDate", 6);
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

	[CrossSchemaAttribute(typeof(IIfcWorkTime), 4)]
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

	[CrossSchemaAttribute(typeof(IIfcWorkTime), 5)]
	Xbim.Ifc4.DateTimeResource.IfcDate? IIfcWorkTime.Start
	{
		get
		{
			if (!StartDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDate(StartDate.Value);
		}
		set
		{
			StartDate = (value.HasValue ? new IfcDate?(new IfcDate(value.Value)) : ((IfcDate?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWorkTime), 6)]
	Xbim.Ifc4.DateTimeResource.IfcDate? IIfcWorkTime.Finish
	{
		get
		{
			if (!FinishDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDate(FinishDate.Value);
		}
		set
		{
			FinishDate = (value.HasValue ? new IfcDate?(new IfcDate(value.Value)) : ((IfcDate?)null));
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
			_startDate = value.StringVal;
			break;
		case 5:
			_finishDate = value.StringVal;
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
