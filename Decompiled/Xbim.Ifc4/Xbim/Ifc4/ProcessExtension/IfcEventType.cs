using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProcessExtension;

[ExpressType("IfcEventType", 1170)]
public class IfcEventType : IfcTypeProcess, IInstantiableEntity, IPersistEntity, IPersist, IIfcEventType, IIfcTypeProcess, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcEventType>, IExpressValidatable
{
	public enum IfcEventTypeClause
	{
		CorrectPredefinedType,
		CorrectEventTriggerType
	}

	private IfcEventTypeEnum _predefinedType;

	private IfcEventTriggerTypeEnum _eventTriggerType;

	private IfcLabel? _userDefinedEventTriggerType;

	IfcEventTypeEnum IIfcEventType.PredefinedType
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

	IfcEventTriggerTypeEnum IIfcEventType.EventTriggerType
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

	IfcLabel? IIfcEventType.UserDefinedEventTriggerType
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

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcEventTypeEnum PredefinedType
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
			SetValue(delegate(IfcEventTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 20)]
	public IfcEventTriggerTypeEnum EventTriggerType
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
			SetValue(delegate(IfcEventTriggerTypeEnum v)
			{
				_eventTriggerType = v;
			}, _eventTriggerType, value, "EventTriggerType", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
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
			}, _userDefinedEventTriggerType, value, "UserDefinedEventTriggerType", 12);
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
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcEventType(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_predefinedType = (IfcEventTypeEnum)Enum.Parse(typeof(IfcEventTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_eventTriggerType = (IfcEventTriggerTypeEnum)Enum.Parse(typeof(IfcEventTriggerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 11:
			_userDefinedEventTriggerType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEventType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcEventTypeClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcEventTypeClause.CorrectPredefinedType:
				result = PredefinedType != IfcEventTypeEnum.USERDEFINED || (PredefinedType == IfcEventTypeEnum.USERDEFINED && Functions.EXISTS(base.ProcessType));
				break;
			case IfcEventTypeClause.CorrectEventTriggerType:
				result = EventTriggerType != IfcEventTriggerTypeEnum.USERDEFINED || (EventTriggerType == IfcEventTriggerTypeEnum.USERDEFINED && Functions.EXISTS(UserDefinedEventTriggerType));
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcEventType>()?.LogError($"Exception thrown evaluating where-clause 'IfcEventType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcEventTypeClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcEventType.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcEventTypeClause.CorrectEventTriggerType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcEventType.CorrectEventTriggerType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
