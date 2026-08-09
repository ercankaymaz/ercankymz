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

[ExpressType("IfcQuantityVolume", 100)]
public class IfcQuantityVolume : IfcPhysicalSimpleQuantity, IIfcQuantityVolume, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcQuantityVolume>, IExpressValidatable
{
	public enum IfcQuantityVolumeClause
	{
		WR21,
		WR22
	}

	private Xbim.Ifc4.MeasureResource.IfcLabel? _formula;

	private Xbim.Ifc2x3.MeasureResource.IfcVolumeMeasure _volumeValue;

	[CrossSchemaAttribute(typeof(IIfcQuantityVolume), 4)]
	Xbim.Ifc4.MeasureResource.IfcVolumeMeasure IIfcQuantityVolume.VolumeValue
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcVolumeMeasure(VolumeValue);
		}
		set
		{
			VolumeValue = new Xbim.Ifc2x3.MeasureResource.IfcVolumeMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcQuantityVolume), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcQuantityVolume.Formula
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
	public Xbim.Ifc2x3.MeasureResource.IfcVolumeMeasure VolumeValue
	{
		get
		{
			if (_activated)
			{
				return _volumeValue;
			}
			Activate();
			return _volumeValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcVolumeMeasure v)
			{
				_volumeValue = v;
			}, _volumeValue, value, "VolumeValue", 4);
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

	internal IfcQuantityVolume(IModel model, int label, bool activated)
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
			_volumeValue = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcQuantityVolume other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcQuantityVolumeClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcQuantityVolumeClause.WR21:
				result = !Functions.EXISTS(base.Unit) || base.Unit.UnitType == Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.VOLUMEUNIT;
				break;
			case IfcQuantityVolumeClause.WR22:
				result = (double)VolumeValue >= 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcQuantityVolume>()?.LogError($"Exception thrown evaluating where-clause 'IfcQuantityVolume.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcQuantityVolumeClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityVolume.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcQuantityVolumeClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityVolume.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
