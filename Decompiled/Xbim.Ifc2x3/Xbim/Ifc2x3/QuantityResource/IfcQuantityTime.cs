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

[ExpressType("IfcQuantityTime", 254)]
public class IfcQuantityTime : IfcPhysicalSimpleQuantity, IIfcQuantityTime, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcQuantityTime>, IExpressValidatable
{
	public enum IfcQuantityTimeClause
	{
		WR21,
		WR22
	}

	private Xbim.Ifc4.MeasureResource.IfcLabel? _formula;

	private Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure _timeValue;

	[CrossSchemaAttribute(typeof(IIfcQuantityTime), 4)]
	Xbim.Ifc4.MeasureResource.IfcTimeMeasure IIfcQuantityTime.TimeValue
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcTimeMeasure(TimeValue);
		}
		set
		{
			TimeValue = new Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcQuantityTime), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcQuantityTime.Formula
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
	public Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure TimeValue
	{
		get
		{
			if (_activated)
			{
				return _timeValue;
			}
			Activate();
			return _timeValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure v)
			{
				_timeValue = v;
			}, _timeValue, value, "TimeValue", 4);
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

	internal IfcQuantityTime(IModel model, int label, bool activated)
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
			_timeValue = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcQuantityTime other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcQuantityTimeClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcQuantityTimeClause.WR21:
				result = !Functions.EXISTS(base.Unit) || base.Unit.UnitType == Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.TIMEUNIT;
				break;
			case IfcQuantityTimeClause.WR22:
				result = (double)TimeValue >= 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcQuantityTime>()?.LogError($"Exception thrown evaluating where-clause 'IfcQuantityTime.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcQuantityTimeClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityTime.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcQuantityTimeClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityTime.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
