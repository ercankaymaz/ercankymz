using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.ExternalReferenceResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PropertyResource;

namespace Xbim.Ifc4x3.CostResource;

[ExpressType("IfcAppliedValue", 79)]
public class IfcAppliedValue : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, Xbim.Ifc4x3.ConstraintResource.IfcMetricValueSelect, IExpressSelectType, Xbim.Ifc4x3.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, Xbim.Ifc4x3.ExternalReferenceResource.IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IEquatable<IfcAppliedValue>, IIfcAppliedValue, Xbim.Ifc4.ConstraintResource.IfcMetricValueSelect, IIfcMetricValueSelect, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private IfcAppliedValueSelect _appliedValue;

	private Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit _unitBasis;

	private Xbim.Ifc4x3.DateTimeResource.IfcDate? _applicableDate;

	private Xbim.Ifc4x3.DateTimeResource.IfcDate? _fixedUntilDate;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _category;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _condition;

	private IfcArithmeticOperatorEnum? _arithmeticOperator;

	private readonly OptionalItemSet<IfcAppliedValue> _components;

	private IIfcAppliedValueSelect _appliedValue4;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcAppliedValueSelect AppliedValue
	{
		get
		{
			if (_activated)
			{
				return _appliedValue;
			}
			Activate();
			return _appliedValue;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAppliedValueSelect v)
			{
				_appliedValue = v;
			}, _appliedValue, value, "AppliedValue", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit UnitBasis
	{
		get
		{
			if (_activated)
			{
				return _unitBasis;
			}
			Activate();
			return _unitBasis;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit v)
			{
				_unitBasis = v;
			}, _unitBasis, value, "UnitBasis", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDate? ApplicableDate
	{
		get
		{
			if (_activated)
			{
				return _applicableDate;
			}
			Activate();
			return _applicableDate;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDate? v)
			{
				_applicableDate = v;
			}, _applicableDate, value, "ApplicableDate", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDate? FixedUntilDate
	{
		get
		{
			if (_activated)
			{
				return _fixedUntilDate;
			}
			Activate();
			return _fixedUntilDate;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDate? v)
			{
				_fixedUntilDate = v;
			}, _fixedUntilDate, value, "FixedUntilDate", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Category
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_category = v;
			}, _category, value, "Category", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Condition
	{
		get
		{
			if (_activated)
			{
				return _condition;
			}
			Activate();
			return _condition;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_condition = v;
			}, _condition, value, "Condition", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 9)]
	public IfcArithmeticOperatorEnum? ArithmeticOperator
	{
		get
		{
			if (_activated)
			{
				return _arithmeticOperator;
			}
			Activate();
			return _arithmeticOperator;
		}
		set
		{
			SetValue(delegate(IfcArithmeticOperatorEnum? v)
			{
				_arithmeticOperator = v;
			}, _arithmeticOperator, value, "ArithmeticOperator", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 10)]
	public IOptionalItemSet<IfcAppliedValue> Components
	{
		get
		{
			if (_activated)
			{
				return _components;
			}
			Activate();
			return _components;
		}
	}

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 11)]
	public IEnumerable<Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship> HasExternalReference => base.Model.Instances.Where((Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (UnitBasis != null)
			{
				yield return UnitBasis;
			}
			foreach (IfcAppliedValue component in Components)
			{
				yield return component;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcAppliedValue.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcAppliedValue.Description
	{
		get
		{
			if (!Description.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Description.Value);
		}
		set
		{
			Description = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 3)]
	IIfcAppliedValueSelect IIfcAppliedValue.AppliedValue
	{
		get
		{
			if (_appliedValue4 != null)
			{
				return _appliedValue4;
			}
			if (AppliedValue == null)
			{
				return null;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit ifcMeasureWithUnit = AppliedValue as Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit;
			if (ifcMeasureWithUnit != null)
			{
				return ifcMeasureWithUnit;
			}
			Xbim.Ifc4x3.ConstraintResource.IfcReference ifcReference = AppliedValue as Xbim.Ifc4x3.ConstraintResource.IfcReference;
			if (ifcReference != null)
			{
				return ifcReference;
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure((Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure((Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure((Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure((Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure((Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure((Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcEnergyMeasure((Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcForceMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure((Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure((Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInductanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure((Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure((Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure((Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure((Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure((Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcPHMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPHMeasure((Xbim.Ifc4x3.MeasureResource.IfcPHMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure((Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure((Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure((Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPowerLevelMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPowerLevelMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPressureLevelMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPressureLevelMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure((Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure((Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure((Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTorqueMeasure((Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure((Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure((Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure((Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcComplexNumber)
			{
				return new Xbim.Ifc4.MeasureResource.IfcComplexNumber((Xbim.Ifc4x3.MeasureResource.IfcComplexNumber)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure((Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcCountMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCountMeasure((long)(Xbim.Ifc4x3.MeasureResource.IfcCountMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNumericMeasure((Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcParameterValue)
			{
				return new Xbim.Ifc4.MeasureResource.IfcParameterValue((Xbim.Ifc4x3.MeasureResource.IfcParameterValue)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTimeMeasure((Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumeMeasure((Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcBinary)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBinary((Xbim.Ifc4x3.MeasureResource.IfcBinary)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.DateTimeResource.IfcDate)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDate((Xbim.Ifc4x3.DateTimeResource.IfcDate)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.DateTimeResource.IfcDateTime)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDateTime((Xbim.Ifc4x3.DateTimeResource.IfcDateTime)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.DateTimeResource.IfcDuration)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDuration((Xbim.Ifc4x3.DateTimeResource.IfcDuration)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcIdentifier)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIdentifier((Xbim.Ifc4x3.MeasureResource.IfcIdentifier)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInteger((Xbim.Ifc4x3.MeasureResource.IfcInteger)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcLabel)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel((Xbim.Ifc4x3.MeasureResource.IfcLabel)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcLogical)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLogical((Xbim.Ifc4x3.MeasureResource.IfcLogical)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveInteger((Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcReal)
			{
				return new Xbim.Ifc4.MeasureResource.IfcReal((Xbim.Ifc4x3.MeasureResource.IfcReal)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcText)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText((Xbim.Ifc4x3.MeasureResource.IfcText)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.DateTimeResource.IfcTime)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTime((Xbim.Ifc4x3.DateTimeResource.IfcTime)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTimeStamp((Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp)(object)AppliedValue);
			}
			if (AppliedValue is Xbim.Ifc4x3.MeasureResource.IfcURIReference)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText(((Xbim.Ifc4x3.MeasureResource.IfcURIReference)(object)AppliedValue).Value.ToString());
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				AppliedValue = null;
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit ifcMeasureWithUnit = value as Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit;
			if (ifcMeasureWithUnit != null)
			{
				AppliedValue = ifcMeasureWithUnit;
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
				return;
			}
			Xbim.Ifc4x3.ConstraintResource.IfcReference ifcReference = value as Xbim.Ifc4x3.ConstraintResource.IfcReference;
			if (ifcReference != null)
			{
				AppliedValue = ifcReference;
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure((Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure((Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure((Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure((Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure((Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure((Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure((Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure((Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcForceMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcForceMeasure((Xbim.Ifc4.MeasureResource.IfcForceMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure((Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure((Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure((Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure((Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure((Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure((Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure((Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure((Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure((Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure((Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure((Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPHMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcPHMeasure((Xbim.Ifc4.MeasureResource.IfcPHMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure((Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPowerMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure((Xbim.Ifc4.MeasureResource.IfcPowerMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPressureMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure((Xbim.Ifc4.MeasureResource.IfcPressureMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure((Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure((Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure((Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure((Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerLevelMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerLevelMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureLevelMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureLevelMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure((Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure((Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure((Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure((Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure((Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure((Xbim.Ifc4.MeasureResource.IfcAreaMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcComplexNumber)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcComplexNumber((Xbim.Ifc4.MeasureResource.IfcComplexNumber)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure((Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCountMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcCountMeasure((Xbim.Ifc4.MeasureResource.IfcCountMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcMassMeasure((Xbim.Ifc4.MeasureResource.IfcMassMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure((Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNumericMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure((Xbim.Ifc4.MeasureResource.IfcNumericMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcParameterValue)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcParameterValue((Xbim.Ifc4.MeasureResource.IfcParameterValue)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure((Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure((Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTimeMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure((Xbim.Ifc4.MeasureResource.IfcTimeMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure((Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBinary)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcBinary((Xbim.Ifc4.MeasureResource.IfcBinary)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDate)
			{
				AppliedValue = new Xbim.Ifc4x3.DateTimeResource.IfcDate((Xbim.Ifc4.DateTimeResource.IfcDate)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDateTime)
			{
				AppliedValue = new Xbim.Ifc4x3.DateTimeResource.IfcDateTime((Xbim.Ifc4.DateTimeResource.IfcDateTime)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDuration)
			{
				AppliedValue = new Xbim.Ifc4x3.DateTimeResource.IfcDuration((Xbim.Ifc4.DateTimeResource.IfcDuration)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIdentifier)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcIdentifier((Xbim.Ifc4.MeasureResource.IfcIdentifier)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInteger)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcInteger((Xbim.Ifc4.MeasureResource.IfcInteger)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLabel)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcLabel((Xbim.Ifc4.MeasureResource.IfcLabel)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLogical)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcLogical((Xbim.Ifc4.MeasureResource.IfcLogical)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveInteger)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger((Xbim.Ifc4.MeasureResource.IfcPositiveInteger)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcReal)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcReal((Xbim.Ifc4.MeasureResource.IfcReal)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcText)
			{
				AppliedValue = new Xbim.Ifc4x3.MeasureResource.IfcText((Xbim.Ifc4.MeasureResource.IfcText)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcTime)
			{
				AppliedValue = new Xbim.Ifc4x3.DateTimeResource.IfcTime((Xbim.Ifc4.DateTimeResource.IfcTime)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
			else
			{
				if (!(value is Xbim.Ifc4.DateTimeResource.IfcTimeStamp))
				{
					return;
				}
				AppliedValue = new Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp((Xbim.Ifc4.DateTimeResource.IfcTimeStamp)(object)value);
				if (_appliedValue4 != null)
				{
					SetValue(delegate(IIfcAppliedValueSelect v)
					{
						_appliedValue4 = v;
					}, _appliedValue4, null, "AppliedValue", -3);
				}
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 4)]
	IIfcMeasureWithUnit IIfcAppliedValue.UnitBasis
	{
		get
		{
			return UnitBasis;
		}
		set
		{
			UnitBasis = value as Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 5)]
	Xbim.Ifc4.DateTimeResource.IfcDate? IIfcAppliedValue.ApplicableDate
	{
		get
		{
			if (!ApplicableDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDate(ApplicableDate.Value);
		}
		set
		{
			ApplicableDate = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDate?(new Xbim.Ifc4x3.DateTimeResource.IfcDate(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDate?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 6)]
	Xbim.Ifc4.DateTimeResource.IfcDate? IIfcAppliedValue.FixedUntilDate
	{
		get
		{
			if (!FixedUntilDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDate(FixedUntilDate.Value);
		}
		set
		{
			FixedUntilDate = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDate?(new Xbim.Ifc4x3.DateTimeResource.IfcDate(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDate?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 7)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcAppliedValue.Category
	{
		get
		{
			if (!Category.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Category.Value);
		}
		set
		{
			Category = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcAppliedValue.Condition
	{
		get
		{
			if (!Condition.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Condition.Value);
		}
		set
		{
			Condition = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 9)]
	Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum? IIfcAppliedValue.ArithmeticOperator
	{
		get
		{
			return ArithmeticOperator switch
			{
				IfcArithmeticOperatorEnum.ADD => Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.ADD, 
				IfcArithmeticOperatorEnum.DIVIDE => Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.DIVIDE, 
				IfcArithmeticOperatorEnum.MODULO => throw new NotSupportedException("MODULO operation only supported in IFC4.3+"), 
				IfcArithmeticOperatorEnum.MULTIPLY => Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.MULTIPLY, 
				IfcArithmeticOperatorEnum.SUBTRACT => Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.SUBTRACT, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.ADD:
				ArithmeticOperator = IfcArithmeticOperatorEnum.ADD;
				break;
			case Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.DIVIDE:
				ArithmeticOperator = IfcArithmeticOperatorEnum.DIVIDE;
				break;
			case Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.MULTIPLY:
				ArithmeticOperator = IfcArithmeticOperatorEnum.MULTIPLY;
				break;
			case Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.SUBTRACT:
				ArithmeticOperator = IfcArithmeticOperatorEnum.SUBTRACT;
				break;
			case null:
				ArithmeticOperator = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 10)]
	IEnumerable<IIfcAppliedValue> IIfcAppliedValue.Components => new ProxyItemSet<IfcAppliedValue, IIfcAppliedValue>(Components);

	IEnumerable<IIfcExternalReferenceRelationship> IIfcAppliedValue.HasExternalReference => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	internal IfcAppliedValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_components = new OptionalItemSet<IfcAppliedValue>(this, 0, 10);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_description = value.StringVal;
			break;
		case 2:
			_appliedValue = (IfcAppliedValueSelect)value.EntityVal;
			break;
		case 3:
			_unitBasis = (Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit)value.EntityVal;
			break;
		case 4:
			_applicableDate = value.StringVal;
			break;
		case 5:
			_fixedUntilDate = value.StringVal;
			break;
		case 6:
			_category = value.StringVal;
			break;
		case 7:
			_condition = value.StringVal;
			break;
		case 8:
			_arithmeticOperator = (IfcArithmeticOperatorEnum)Enum.Parse(typeof(IfcArithmeticOperatorEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_components.InternalAdd((IfcAppliedValue)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAppliedValue other)
	{
		return this == other;
	}
}
