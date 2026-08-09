using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.FacilitiesMgmtDomain;

[ExpressType("IfcConditionCriterion", 688)]
public class IfcConditionCriterion : IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcConditionCriterion>, IExpressValidatable
{
	public enum IfcConditionCriterionClause
	{
		WR1
	}

	private IfcConditionCriterionSelect _criterion;

	private IfcDateTimeSelect _criterionDateTime;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public IfcConditionCriterionSelect Criterion
	{
		get
		{
			if (_activated)
			{
				return _criterion;
			}
			Activate();
			return _criterion;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcConditionCriterionSelect v)
			{
				_criterion = v;
			}, _criterion, value, "Criterion", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
	public IfcDateTimeSelect CriterionDateTime
	{
		get
		{
			if (_activated)
			{
				return _criterionDateTime;
			}
			Activate();
			return _criterionDateTime;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateTimeSelect v)
			{
				_criterionDateTime = v;
			}, _criterionDateTime, value, "CriterionDateTime", 7);
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
			if (CriterionDateTime != null)
			{
				yield return CriterionDateTime;
			}
		}
	}

	internal IfcConditionCriterion(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_criterion = (IfcConditionCriterionSelect)value.EntityVal;
			break;
		case 6:
			_criterionDateTime = (IfcDateTimeSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConditionCriterion other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcConditionCriterionClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcConditionCriterionClause.WR1)
			{
				result = Functions.EXISTS(base.Name);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcConditionCriterion>()?.LogError($"Exception thrown evaluating where-clause 'IfcConditionCriterion.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcConditionCriterionClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcConditionCriterion.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
