using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.DateTimeResource;

[ExpressType("IfcTaskTimeRecurring", 1295)]
public class IfcTaskTimeRecurring : IfcTaskTime, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcTaskTimeRecurring>, IIfcTaskTimeRecurring, IIfcTaskTime, IIfcSchedulingTime
{
	private IfcRecurrencePattern _recurrence;

	[EntityAttribute(21, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 21)]
	public IfcRecurrencePattern Recurrence
	{
		get
		{
			if (_activated)
			{
				return _recurrence;
			}
			Activate();
			return _recurrence;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcRecurrencePattern v)
			{
				_recurrence = v;
			}, _recurrence, value, "Recurrence", 21);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Recurrence != null)
			{
				yield return Recurrence;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTaskTimeRecurring), 21)]
	IIfcRecurrencePattern IIfcTaskTimeRecurring.Recurrence
	{
		get
		{
			return Recurrence;
		}
		set
		{
			Recurrence = value as IfcRecurrencePattern;
		}
	}

	internal IfcTaskTimeRecurring(IModel model, int label, bool activated)
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
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 20:
			_recurrence = (IfcRecurrencePattern)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTaskTimeRecurring other)
	{
		return this == other;
	}
}
