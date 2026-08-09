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

[ExpressType("IfcQuantityArea", 495)]
public class IfcQuantityArea : IfcPhysicalSimpleQuantity, IIfcQuantityArea, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcQuantityArea>, IExpressValidatable
{
	public enum IfcQuantityAreaClause
	{
		WR21,
		WR22
	}

	private Xbim.Ifc4.MeasureResource.IfcLabel? _formula;

	private Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure _areaValue;

	[CrossSchemaAttribute(typeof(IIfcQuantityArea), 4)]
	Xbim.Ifc4.MeasureResource.IfcAreaMeasure IIfcQuantityArea.AreaValue
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure(AreaValue);
		}
		set
		{
			AreaValue = new Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcQuantityArea), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcQuantityArea.Formula
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
	public Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure AreaValue
	{
		get
		{
			if (_activated)
			{
				return _areaValue;
			}
			Activate();
			return _areaValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure v)
			{
				_areaValue = v;
			}, _areaValue, value, "AreaValue", 4);
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

	internal IfcQuantityArea(IModel model, int label, bool activated)
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
			_areaValue = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcQuantityArea other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcQuantityAreaClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcQuantityAreaClause.WR21:
				result = !Functions.EXISTS(base.Unit) || base.Unit.UnitType == Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.AREAUNIT;
				break;
			case IfcQuantityAreaClause.WR22:
				result = (double)AreaValue >= 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcQuantityArea>()?.LogError($"Exception thrown evaluating where-clause 'IfcQuantityArea.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcQuantityAreaClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityArea.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcQuantityAreaClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityArea.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
