using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.QuantityResource;

[ExpressType("IfcQuantityWeight", 603)]
public class IfcQuantityWeight : IfcPhysicalSimpleQuantity, IIfcQuantityWeight, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcQuantityWeight>, IExpressValidatable
{
	public enum IfcQuantityWeightClause
	{
		WR21,
		WR22
	}

	private Xbim.Ifc4.MeasureResource.IfcLabel? _formula;

	private Xbim.Ifc2x3.MeasureResource.IfcMassMeasure _weightValue;

	[CrossSchemaAttribute(typeof(IIfcQuantityWeight), 4)]
	Xbim.Ifc4.MeasureResource.IfcMassMeasure IIfcQuantityWeight.WeightValue
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcMassMeasure(WeightValue);
		}
		set
		{
			WeightValue = new Xbim.Ifc2x3.MeasureResource.IfcMassMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcQuantityWeight), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcQuantityWeight.Formula
	{
		get
		{
			return _formula;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLabel? v)
			{
				_formula = v;
			}, _formula, value, "Formula", -5);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcMassMeasure WeightValue
	{
		get
		{
			if (_activated)
			{
				return _weightValue;
			}
			Activate();
			return _weightValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcMassMeasure v)
			{
				_weightValue = v;
			}, _weightValue, value, "WeightValue", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Unit != null)
			{
				yield return base.Unit;
			}
		}
	}

	internal IfcQuantityWeight(IModel model, int label, bool activated)
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
			_weightValue = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcQuantityWeight other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcQuantityWeightClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcQuantityWeightClause.WR21:
				result = !Functions.EXISTS(base.Unit) || base.Unit.UnitType == Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.MASSUNIT;
				break;
			case IfcQuantityWeightClause.WR22:
				result = (double)WeightValue >= 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcQuantityWeight>()?.LogError($"Exception thrown evaluating where-clause 'IfcQuantityWeight.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcQuantityWeightClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityWeight.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcQuantityWeightClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityWeight.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
