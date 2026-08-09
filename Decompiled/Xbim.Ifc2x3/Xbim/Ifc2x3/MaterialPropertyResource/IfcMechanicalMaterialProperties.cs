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

[ExpressType("IfcMechanicalMaterialProperties", 436)]
public class IfcMechanicalMaterialProperties : IfcMaterialProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcMechanicalMaterialProperties>, IExpressValidatable
{
	public enum IfcMechanicalMaterialPropertiesClause
	{
		WR21,
		WR22
	}

	private IfcDynamicViscosityMeasure? _dynamicViscosity;

	private IfcModulusOfElasticityMeasure? _youngModulus;

	private IfcModulusOfElasticityMeasure? _shearModulus;

	private IfcPositiveRatioMeasure? _poissonRatio;

	private IfcThermalExpansionCoefficientMeasure? _thermalExpansionCoefficient;

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcDynamicViscosityMeasure? DynamicViscosity
	{
		get
		{
			if (_activated)
			{
				return _dynamicViscosity;
			}
			Activate();
			return _dynamicViscosity;
		}
		set
		{
			SetValue(delegate(IfcDynamicViscosityMeasure? v)
			{
				_dynamicViscosity = v;
			}, _dynamicViscosity, value, "DynamicViscosity", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcModulusOfElasticityMeasure? YoungModulus
	{
		get
		{
			if (_activated)
			{
				return _youngModulus;
			}
			Activate();
			return _youngModulus;
		}
		set
		{
			SetValue(delegate(IfcModulusOfElasticityMeasure? v)
			{
				_youngModulus = v;
			}, _youngModulus, value, "YoungModulus", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcModulusOfElasticityMeasure? ShearModulus
	{
		get
		{
			if (_activated)
			{
				return _shearModulus;
			}
			Activate();
			return _shearModulus;
		}
		set
		{
			SetValue(delegate(IfcModulusOfElasticityMeasure? v)
			{
				_shearModulus = v;
			}, _shearModulus, value, "ShearModulus", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveRatioMeasure? PoissonRatio
	{
		get
		{
			if (_activated)
			{
				return _poissonRatio;
			}
			Activate();
			return _poissonRatio;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_poissonRatio = v;
			}, _poissonRatio, value, "PoissonRatio", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcThermalExpansionCoefficientMeasure? ThermalExpansionCoefficient
	{
		get
		{
			if (_activated)
			{
				return _thermalExpansionCoefficient;
			}
			Activate();
			return _thermalExpansionCoefficient;
		}
		set
		{
			SetValue(delegate(IfcThermalExpansionCoefficientMeasure? v)
			{
				_thermalExpansionCoefficient = v;
			}, _thermalExpansionCoefficient, value, "ThermalExpansionCoefficient", 6);
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
		}
	}

	internal IfcMechanicalMaterialProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_dynamicViscosity = value.RealVal;
			break;
		case 2:
			_youngModulus = value.RealVal;
			break;
		case 3:
			_shearModulus = value.RealVal;
			break;
		case 4:
			_poissonRatio = value.RealVal;
			break;
		case 5:
			_thermalExpansionCoefficient = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMechanicalMaterialProperties other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcMechanicalMaterialPropertiesClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcMechanicalMaterialPropertiesClause.WR21:
				result = !Functions.EXISTS(YoungModulus) || (double?)YoungModulus >= 0.0;
				break;
			case IfcMechanicalMaterialPropertiesClause.WR22:
				result = !Functions.EXISTS(ShearModulus) || (double?)ShearModulus >= 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcMechanicalMaterialProperties>()?.LogError($"Exception thrown evaluating where-clause 'IfcMechanicalMaterialProperties.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcMechanicalMaterialPropertiesClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMechanicalMaterialProperties.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcMechanicalMaterialPropertiesClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMechanicalMaterialProperties.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
