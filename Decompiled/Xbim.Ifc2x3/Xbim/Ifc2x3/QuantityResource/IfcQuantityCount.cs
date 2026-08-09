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

[ExpressType("IfcQuantityCount", 457)]
public class IfcQuantityCount : IfcPhysicalSimpleQuantity, IIfcQuantityCount, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcQuantityCount>, IExpressValidatable
{
	public enum IfcQuantityCountClause
	{
		WR21
	}

	private Xbim.Ifc4.MeasureResource.IfcLabel? _formula;

	private Xbim.Ifc2x3.MeasureResource.IfcCountMeasure _countValue;

	[CrossSchemaAttribute(typeof(IIfcQuantityCount), 4)]
	Xbim.Ifc4.MeasureResource.IfcCountMeasure IIfcQuantityCount.CountValue
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcCountMeasure(CountValue);
		}
		set
		{
			CountValue = new Xbim.Ifc2x3.MeasureResource.IfcCountMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcQuantityCount), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcQuantityCount.Formula
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
	public Xbim.Ifc2x3.MeasureResource.IfcCountMeasure CountValue
	{
		get
		{
			if (_activated)
			{
				return _countValue;
			}
			Activate();
			return _countValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcCountMeasure v)
			{
				_countValue = v;
			}, _countValue, value, "CountValue", 4);
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

	internal IfcQuantityCount(IModel model, int label, bool activated)
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
			_countValue = value.NumberVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcQuantityCount other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcQuantityCountClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcQuantityCountClause.WR21)
			{
				result = (double)CountValue >= 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcQuantityCount>()?.LogError($"Exception thrown evaluating where-clause 'IfcQuantityCount.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcQuantityCountClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityCount.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
