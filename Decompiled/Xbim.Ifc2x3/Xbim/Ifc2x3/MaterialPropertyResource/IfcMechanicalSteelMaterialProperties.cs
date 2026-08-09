using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.MaterialPropertyResource;

[ExpressType("IfcMechanicalSteelMaterialProperties", 510)]
public class IfcMechanicalSteelMaterialProperties : IfcMechanicalMaterialProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcMechanicalSteelMaterialProperties>, IExpressValidatable
{
	public enum IfcMechanicalSteelMaterialPropertiesClause
	{
		WR31,
		WR32,
		WR33,
		WR34
	}

	private IfcPressureMeasure? _yieldStress;

	private IfcPressureMeasure? _ultimateStress;

	private IfcPositiveRatioMeasure? _ultimateStrain;

	private IfcModulusOfElasticityMeasure? _hardeningModule;

	private IfcPressureMeasure? _proportionalStress;

	private IfcPositiveRatioMeasure? _plasticStrain;

	private readonly OptionalItemSet<IfcRelaxation> _relaxations;

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPressureMeasure? YieldStress
	{
		get
		{
			if (_activated)
			{
				return _yieldStress;
			}
			Activate();
			return _yieldStress;
		}
		set
		{
			SetValue(delegate(IfcPressureMeasure? v)
			{
				_yieldStress = v;
			}, _yieldStress, value, "YieldStress", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcPressureMeasure? UltimateStress
	{
		get
		{
			if (_activated)
			{
				return _ultimateStress;
			}
			Activate();
			return _ultimateStress;
		}
		set
		{
			SetValue(delegate(IfcPressureMeasure? v)
			{
				_ultimateStress = v;
			}, _ultimateStress, value, "UltimateStress", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcPositiveRatioMeasure? UltimateStrain
	{
		get
		{
			if (_activated)
			{
				return _ultimateStrain;
			}
			Activate();
			return _ultimateStrain;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_ultimateStrain = v;
			}, _ultimateStrain, value, "UltimateStrain", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcModulusOfElasticityMeasure? HardeningModule
	{
		get
		{
			if (_activated)
			{
				return _hardeningModule;
			}
			Activate();
			return _hardeningModule;
		}
		set
		{
			SetValue(delegate(IfcModulusOfElasticityMeasure? v)
			{
				_hardeningModule = v;
			}, _hardeningModule, value, "HardeningModule", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcPressureMeasure? ProportionalStress
	{
		get
		{
			if (_activated)
			{
				return _proportionalStress;
			}
			Activate();
			return _proportionalStress;
		}
		set
		{
			SetValue(delegate(IfcPressureMeasure? v)
			{
				_proportionalStress = v;
			}, _proportionalStress, value, "ProportionalStress", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcPositiveRatioMeasure? PlasticStrain
	{
		get
		{
			if (_activated)
			{
				return _plasticStrain;
			}
			Activate();
			return _plasticStrain;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_plasticStrain = v;
			}, _plasticStrain, value, "PlasticStrain", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 13)]
	public IOptionalItemSet<IfcRelaxation> Relaxations
	{
		get
		{
			if (_activated)
			{
				return _relaxations;
			}
			Activate();
			return _relaxations;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Material != null)
			{
				yield return base.Material;
			}
			foreach (IfcRelaxation relaxation in Relaxations)
			{
				yield return relaxation;
			}
		}
	}

	internal IfcMechanicalSteelMaterialProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relaxations = new OptionalItemSet<IfcRelaxation>(this, 0, 13);
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
			_yieldStress = value.RealVal;
			break;
		case 7:
			_ultimateStress = value.RealVal;
			break;
		case 8:
			_ultimateStrain = value.RealVal;
			break;
		case 9:
			_hardeningModule = value.RealVal;
			break;
		case 10:
			_proportionalStress = value.RealVal;
			break;
		case 11:
			_plasticStrain = value.RealVal;
			break;
		case 12:
			_relaxations.InternalAdd((IfcRelaxation)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMechanicalSteelMaterialProperties other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcMechanicalSteelMaterialPropertiesClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcMechanicalSteelMaterialPropertiesClause.WR31:
				result = !Functions.EXISTS(YieldStress) || (double?)YieldStress >= 0.0;
				break;
			case IfcMechanicalSteelMaterialPropertiesClause.WR32:
				result = !Functions.EXISTS(UltimateStress) || (double?)UltimateStress >= 0.0;
				break;
			case IfcMechanicalSteelMaterialPropertiesClause.WR33:
				result = !Functions.EXISTS(HardeningModule) || (double?)HardeningModule >= 0.0;
				break;
			case IfcMechanicalSteelMaterialPropertiesClause.WR34:
				result = !Functions.EXISTS(ProportionalStress) || (double?)ProportionalStress >= 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcMechanicalSteelMaterialProperties>()?.LogError($"Exception thrown evaluating where-clause 'IfcMechanicalSteelMaterialProperties.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcMechanicalSteelMaterialPropertiesClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMechanicalSteelMaterialProperties.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcMechanicalSteelMaterialPropertiesClause.WR32))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMechanicalSteelMaterialProperties.WR32",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcMechanicalSteelMaterialPropertiesClause.WR33))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMechanicalSteelMaterialProperties.WR33",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcMechanicalSteelMaterialPropertiesClause.WR34))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMechanicalSteelMaterialProperties.WR34",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
