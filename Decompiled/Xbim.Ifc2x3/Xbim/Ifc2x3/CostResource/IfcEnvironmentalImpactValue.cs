using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.CostResource;

[ExpressType("IfcEnvironmentalImpactValue", 78)]
public class IfcEnvironmentalImpactValue : IfcAppliedValue, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcEnvironmentalImpactValue>, IExpressValidatable
{
	public enum IfcEnvironmentalImpactValueClause
	{
		WR1
	}

	private IfcLabel _impactType;

	private IfcEnvironmentalImpactCategoryEnum _category;

	private IfcLabel? _userDefinedCategory;

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcLabel ImpactType
	{
		get
		{
			if (_activated)
			{
				return _impactType;
			}
			Activate();
			return _impactType;
		}
		set
		{
			SetValue(delegate(IfcLabel v)
			{
				_impactType = v;
			}, _impactType, value, "ImpactType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 11)]
	public IfcEnvironmentalImpactCategoryEnum Category
	{
		get
		{
			if (_activated)
			{
				return _category;
			}
			Activate();
			return _category;
		}
		set
		{
			SetValue(delegate(IfcEnvironmentalImpactCategoryEnum v)
			{
				_category = v;
			}, _category, value, "Category", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcLabel? UserDefinedCategory
	{
		get
		{
			if (_activated)
			{
				return _userDefinedCategory;
			}
			Activate();
			return _userDefinedCategory;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedCategory = v;
			}, _userDefinedCategory, value, "UserDefinedCategory", 9);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.UnitBasis != null)
			{
				yield return base.UnitBasis;
			}
			if (base.ApplicableDate != null)
			{
				yield return base.ApplicableDate;
			}
			if (base.FixedUntilDate != null)
			{
				yield return base.FixedUntilDate;
			}
		}
	}

	internal IfcEnvironmentalImpactValue(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_impactType = value.StringVal;
			break;
		case 7:
			_category = (IfcEnvironmentalImpactCategoryEnum)Enum.Parse(typeof(IfcEnvironmentalImpactCategoryEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_userDefinedCategory = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEnvironmentalImpactValue other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcEnvironmentalImpactValueClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcEnvironmentalImpactValueClause.WR1)
			{
				result = Category != IfcEnvironmentalImpactCategoryEnum.USERDEFINED || (Category == IfcEnvironmentalImpactCategoryEnum.USERDEFINED && Functions.EXISTS(UserDefinedCategory));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcEnvironmentalImpactValue>()?.LogError($"Exception thrown evaluating where-clause 'IfcEnvironmentalImpactValue.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcEnvironmentalImpactValueClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcEnvironmentalImpactValue.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
