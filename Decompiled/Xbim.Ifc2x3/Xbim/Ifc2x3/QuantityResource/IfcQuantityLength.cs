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

[ExpressType("IfcQuantityLength", 527)]
public class IfcQuantityLength : IfcPhysicalSimpleQuantity, IIfcQuantityLength, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcQuantityLength>, IExpressValidatable
{
	public enum IfcQuantityLengthClause
	{
		WR21,
		WR22
	}

	private Xbim.Ifc4.MeasureResource.IfcLabel? _formula;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure _lengthValue;

	[CrossSchemaAttribute(typeof(IIfcQuantityLength), 4)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcQuantityLength.LengthValue
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(LengthValue);
		}
		set
		{
			LengthValue = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcQuantityLength), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcQuantityLength.Formula
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
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure LengthValue
	{
		get
		{
			if (_activated)
			{
				return _lengthValue;
			}
			Activate();
			return _lengthValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure v)
			{
				_lengthValue = v;
			}, _lengthValue, value, "LengthValue", 4);
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

	internal IfcQuantityLength(IModel model, int label, bool activated)
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
			_lengthValue = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcQuantityLength other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcQuantityLengthClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcQuantityLengthClause.WR21:
				result = !Functions.EXISTS(base.Unit) || base.Unit.UnitType == Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.LENGTHUNIT;
				break;
			case IfcQuantityLengthClause.WR22:
				result = (double)LengthValue >= 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcQuantityLength>()?.LogError($"Exception thrown evaluating where-clause 'IfcQuantityLength.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcQuantityLengthClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityLength.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcQuantityLengthClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityLength.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
