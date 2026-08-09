using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProcessExtension;

[ExpressType("IfcEvent", 1168)]
public class IfcEvent : IfcProcess, IInstantiableEntity, IPersistEntity, IPersist, IIfcEvent, IIfcProcess, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect, IContainsEntityReferences, IEquatable<IfcEvent>, IExpressValidatable
{
	public enum IfcEventClause
	{
		CorrectPredefinedType,
		CorrectTypeAssigned
	}

	private IfcEventTypeEnum? _predefinedType;

	private IfcEventTriggerTypeEnum? _eventTriggerType;

	private IfcLabel? _userDefinedEventTriggerType;

	private IfcEventTime _eventOccurenceTime;

	IfcEventTypeEnum? IIfcEvent.PredefinedType
	{
		get
		{
			return PredefinedType;
		}
		set
		{
			PredefinedType = value;
		}
	}

	IfcEventTriggerTypeEnum? IIfcEvent.EventTriggerType
	{
		get
		{
			return EventTriggerType;
		}
		set
		{
			EventTriggerType = value;
		}
	}

	IfcLabel? IIfcEvent.UserDefinedEventTriggerType
	{
		get
		{
			return UserDefinedEventTriggerType;
		}
		set
		{
			UserDefinedEventTriggerType = value;
		}
	}

	IIfcEventTime IIfcEvent.EventOccurenceTime
	{
		get
		{
			return EventOccurenceTime;
		}
		set
		{
			EventOccurenceTime = value as IfcEventTime;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 22)]
	public IfcEventTypeEnum? PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcEventTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 23)]
	public IfcEventTriggerTypeEnum? EventTriggerType
	{
		get
		{
			if (_activated)
			{
				return _eventTriggerType;
			}
			Activate();
			return _eventTriggerType;
		}
		set
		{
			SetValue(delegate(IfcEventTriggerTypeEnum? v)
			{
				_eventTriggerType = v;
			}, _eventTriggerType, value, "EventTriggerType", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 24)]
	public IfcLabel? UserDefinedEventTriggerType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedEventTriggerType;
			}
			Activate();
			return _userDefinedEventTriggerType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedEventTriggerType = v;
			}, _userDefinedEventTriggerType, value, "UserDefinedEventTriggerType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 25)]
	public IfcEventTime EventOccurenceTime
	{
		get
		{
			if (_activated)
			{
				return _eventOccurenceTime;
			}
			Activate();
			return _eventOccurenceTime;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcEventTime v)
			{
				_eventOccurenceTime = v;
			}, _eventOccurenceTime, value, "EventOccurenceTime", 11);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (EventOccurenceTime != null)
			{
				yield return EventOccurenceTime;
			}
		}
	}

	internal IfcEvent(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_predefinedType = (IfcEventTypeEnum)Enum.Parse(typeof(IfcEventTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_eventTriggerType = (IfcEventTriggerTypeEnum)Enum.Parse(typeof(IfcEventTriggerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_userDefinedEventTriggerType = value.StringVal;
			break;
		case 10:
			_eventOccurenceTime = (IfcEventTime)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEvent other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcEventClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcEventClause.CorrectPredefinedType:
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcEventTypeEnum.USERDEFINED || (PredefinedType == IfcEventTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
				break;
			case IfcEventClause.CorrectTypeAssigned:
				result = !Functions.EXISTS(EventTriggerType) || EventTriggerType != IfcEventTriggerTypeEnum.USERDEFINED || (EventTriggerType == IfcEventTriggerTypeEnum.USERDEFINED && Functions.EXISTS(UserDefinedEventTriggerType));
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcEvent>()?.LogError($"Exception thrown evaluating where-clause 'IfcEvent.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcEventClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcEvent.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcEventClause.CorrectTypeAssigned))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcEvent.CorrectTypeAssigned",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
