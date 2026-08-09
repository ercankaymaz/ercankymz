using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProcessExtension;

[ExpressType("IfcWorkSchedule", 186)]
public class IfcWorkSchedule : IfcWorkControl, IInstantiableEntity, IPersistEntity, IPersist, IIfcWorkSchedule, IIfcWorkControl, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcWorkSchedule>, IExpressValidatable
{
	public enum IfcWorkScheduleClause
	{
		CorrectPredefinedType
	}

	private IfcWorkScheduleTypeEnum? _predefinedType;

	IfcWorkScheduleTypeEnum? IIfcWorkSchedule.PredefinedType
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

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 26)]
	public IfcWorkScheduleTypeEnum? PredefinedType
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
			SetValue(delegate(IfcWorkScheduleTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 14);
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
			foreach (IfcPerson creator in base.Creators)
			{
				yield return creator;
			}
		}
	}

	internal IfcWorkSchedule(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 13:
			_predefinedType = (IfcWorkScheduleTypeEnum)Enum.Parse(typeof(IfcWorkScheduleTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWorkSchedule other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcWorkScheduleClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcWorkScheduleClause.CorrectPredefinedType)
			{
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcWorkScheduleTypeEnum.USERDEFINED || (PredefinedType == IfcWorkScheduleTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcWorkSchedule>()?.LogError($"Exception thrown evaluating where-clause 'IfcWorkSchedule.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcWorkScheduleClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcWorkSchedule.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
