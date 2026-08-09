using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.QuantityResource;

[ExpressType("IfcQuantityCount", 457)]
public class IfcQuantityCount : IfcPhysicalSimpleQuantity, IInstantiableEntity, IPersistEntity, IPersist, IIfcQuantityCount, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcQuantityCount>, IExpressValidatable
{
	public enum IfcQuantityCountClause
	{
		WR21
	}

	private IfcCountMeasure _countValue;

	private IfcLabel? _formula;

	IfcCountMeasure IIfcQuantityCount.CountValue
	{
		get
		{
			return CountValue;
		}
		set
		{
			CountValue = value;
		}
	}

	IfcLabel? IIfcQuantityCount.Formula
	{
		get
		{
			return Formula;
		}
		set
		{
			Formula = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcCountMeasure CountValue
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
			SetValue(delegate(IfcCountMeasure v)
			{
				_countValue = v;
			}, _countValue, value, "CountValue", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcLabel? Formula
	{
		get
		{
			if (_activated)
			{
				return _formula;
			}
			Activate();
			return _formula;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_formula = v;
			}, _formula, value, "Formula", 5);
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
		case 4:
			_formula = value.StringVal;
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
				result = (long)CountValue >= 0;
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
