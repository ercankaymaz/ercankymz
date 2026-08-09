using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PropertyResource;

[ExpressType("IfcPropertyBoundedValue", 3)]
public class IfcPropertyBoundedValue : IfcSimpleProperty, IIfcPropertyBoundedValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPropertyBoundedValue>
{
	private IIfcValue _upperBoundValue4;

	private IIfcValue _lowerBoundValue4;

	private IIfcValue _setPointValue4;

	private Xbim.Ifc4x3.MeasureResource.IfcValue _upperBoundValue;

	private Xbim.Ifc4x3.MeasureResource.IfcValue _lowerBoundValue;

	private Xbim.Ifc4x3.MeasureResource.IfcUnit _unit;

	private Xbim.Ifc4x3.MeasureResource.IfcValue _setPointValue;

	[CrossSchemaAttribute(typeof(IIfcPropertyBoundedValue), 3)]
	IIfcValue IIfcPropertyBoundedValue.UpperBoundValue
	{
		get
		{
			if (_upperBoundValue4 != null)
			{
				return _upperBoundValue4;
			}
			if (UpperBoundValue == null)
			{
				return null;
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure((Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure((Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure((Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure((Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure((Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure((Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcEnergyMeasure((Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcForceMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure((Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure((Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInductanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure((Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure((Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure((Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure((Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure((Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPHMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPHMeasure((Xbim.Ifc4x3.MeasureResource.IfcPHMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure((Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure((Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure((Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPowerLevelMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPowerLevelMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPressureLevelMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPressureLevelMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure((Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure((Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure((Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTorqueMeasure((Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure((Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure((Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure((Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcComplexNumber)
			{
				return new Xbim.Ifc4.MeasureResource.IfcComplexNumber((Xbim.Ifc4x3.MeasureResource.IfcComplexNumber)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure((Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcCountMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCountMeasure((long)(Xbim.Ifc4x3.MeasureResource.IfcCountMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNumericMeasure((Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcParameterValue)
			{
				return new Xbim.Ifc4.MeasureResource.IfcParameterValue((Xbim.Ifc4x3.MeasureResource.IfcParameterValue)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTimeMeasure((Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumeMeasure((Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcBinary)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBinary((Xbim.Ifc4x3.MeasureResource.IfcBinary)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.DateTimeResource.IfcDate)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDate((Xbim.Ifc4x3.DateTimeResource.IfcDate)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.DateTimeResource.IfcDateTime)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDateTime((Xbim.Ifc4x3.DateTimeResource.IfcDateTime)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.DateTimeResource.IfcDuration)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDuration((Xbim.Ifc4x3.DateTimeResource.IfcDuration)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcIdentifier)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIdentifier((Xbim.Ifc4x3.MeasureResource.IfcIdentifier)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInteger((Xbim.Ifc4x3.MeasureResource.IfcInteger)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLabel)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel((Xbim.Ifc4x3.MeasureResource.IfcLabel)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLogical)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLogical((Xbim.Ifc4x3.MeasureResource.IfcLogical)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveInteger((Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcReal)
			{
				return new Xbim.Ifc4.MeasureResource.IfcReal((Xbim.Ifc4x3.MeasureResource.IfcReal)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcText)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText((Xbim.Ifc4x3.MeasureResource.IfcText)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.DateTimeResource.IfcTime)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTime((Xbim.Ifc4x3.DateTimeResource.IfcTime)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTimeStamp((Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp)(object)UpperBoundValue);
			}
			if (UpperBoundValue is Xbim.Ifc4x3.MeasureResource.IfcURIReference)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText(((Xbim.Ifc4x3.MeasureResource.IfcURIReference)(object)UpperBoundValue).Value.ToString());
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				UpperBoundValue = null;
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure((Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure((Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure((Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure((Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure((Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure((Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure((Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure((Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcForceMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcForceMeasure((Xbim.Ifc4.MeasureResource.IfcForceMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure((Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure((Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure((Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure((Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure((Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure((Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure((Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure((Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure((Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure((Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure((Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPHMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPHMeasure((Xbim.Ifc4.MeasureResource.IfcPHMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure((Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPowerMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure((Xbim.Ifc4.MeasureResource.IfcPowerMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPressureMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure((Xbim.Ifc4.MeasureResource.IfcPressureMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure((Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure((Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure((Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure((Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerLevelMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerLevelMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureLevelMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureLevelMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure((Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure((Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure((Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure((Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure((Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure((Xbim.Ifc4.MeasureResource.IfcAreaMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcComplexNumber)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcComplexNumber((Xbim.Ifc4.MeasureResource.IfcComplexNumber)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure((Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCountMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcCountMeasure((Xbim.Ifc4.MeasureResource.IfcCountMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMassMeasure((Xbim.Ifc4.MeasureResource.IfcMassMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure((Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNumericMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure((Xbim.Ifc4.MeasureResource.IfcNumericMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcParameterValue)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcParameterValue((Xbim.Ifc4.MeasureResource.IfcParameterValue)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure((Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure((Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTimeMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure((Xbim.Ifc4.MeasureResource.IfcTimeMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure((Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBinary)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcBinary((Xbim.Ifc4.MeasureResource.IfcBinary)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDate)
			{
				UpperBoundValue = new Xbim.Ifc4x3.DateTimeResource.IfcDate((Xbim.Ifc4.DateTimeResource.IfcDate)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDateTime)
			{
				UpperBoundValue = new Xbim.Ifc4x3.DateTimeResource.IfcDateTime((Xbim.Ifc4.DateTimeResource.IfcDateTime)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDuration)
			{
				UpperBoundValue = new Xbim.Ifc4x3.DateTimeResource.IfcDuration((Xbim.Ifc4.DateTimeResource.IfcDuration)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIdentifier)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcIdentifier((Xbim.Ifc4.MeasureResource.IfcIdentifier)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInteger)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcInteger((Xbim.Ifc4.MeasureResource.IfcInteger)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLabel)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLabel((Xbim.Ifc4.MeasureResource.IfcLabel)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLogical)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLogical((Xbim.Ifc4.MeasureResource.IfcLogical)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveInteger)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger((Xbim.Ifc4.MeasureResource.IfcPositiveInteger)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcReal)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcReal((Xbim.Ifc4.MeasureResource.IfcReal)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcText)
			{
				UpperBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcText((Xbim.Ifc4.MeasureResource.IfcText)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcTime)
			{
				UpperBoundValue = new Xbim.Ifc4x3.DateTimeResource.IfcTime((Xbim.Ifc4.DateTimeResource.IfcTime)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
			else
			{
				if (!(value is Xbim.Ifc4.DateTimeResource.IfcTimeStamp))
				{
					return;
				}
				UpperBoundValue = new Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp((Xbim.Ifc4.DateTimeResource.IfcTimeStamp)(object)value);
				if (_upperBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_upperBoundValue4 = v;
					}, _upperBoundValue4, null, "UpperBoundValue", -3);
				}
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertyBoundedValue), 4)]
	IIfcValue IIfcPropertyBoundedValue.LowerBoundValue
	{
		get
		{
			if (_lowerBoundValue4 != null)
			{
				return _lowerBoundValue4;
			}
			if (LowerBoundValue == null)
			{
				return null;
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure((Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure((Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure((Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure((Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure((Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure((Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcEnergyMeasure((Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcForceMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure((Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure((Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInductanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure((Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure((Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure((Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure((Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure((Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPHMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPHMeasure((Xbim.Ifc4x3.MeasureResource.IfcPHMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure((Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure((Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure((Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPowerLevelMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPowerLevelMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPressureLevelMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPressureLevelMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure((Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure((Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure((Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTorqueMeasure((Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure((Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure((Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure((Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcComplexNumber)
			{
				return new Xbim.Ifc4.MeasureResource.IfcComplexNumber((Xbim.Ifc4x3.MeasureResource.IfcComplexNumber)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure((Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcCountMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCountMeasure((long)(Xbim.Ifc4x3.MeasureResource.IfcCountMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNumericMeasure((Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcParameterValue)
			{
				return new Xbim.Ifc4.MeasureResource.IfcParameterValue((Xbim.Ifc4x3.MeasureResource.IfcParameterValue)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTimeMeasure((Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumeMeasure((Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcBinary)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBinary((Xbim.Ifc4x3.MeasureResource.IfcBinary)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.DateTimeResource.IfcDate)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDate((Xbim.Ifc4x3.DateTimeResource.IfcDate)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.DateTimeResource.IfcDateTime)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDateTime((Xbim.Ifc4x3.DateTimeResource.IfcDateTime)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.DateTimeResource.IfcDuration)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDuration((Xbim.Ifc4x3.DateTimeResource.IfcDuration)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcIdentifier)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIdentifier((Xbim.Ifc4x3.MeasureResource.IfcIdentifier)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInteger((Xbim.Ifc4x3.MeasureResource.IfcInteger)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLabel)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel((Xbim.Ifc4x3.MeasureResource.IfcLabel)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcLogical)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLogical((Xbim.Ifc4x3.MeasureResource.IfcLogical)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveInteger((Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcReal)
			{
				return new Xbim.Ifc4.MeasureResource.IfcReal((Xbim.Ifc4x3.MeasureResource.IfcReal)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcText)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText((Xbim.Ifc4x3.MeasureResource.IfcText)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.DateTimeResource.IfcTime)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTime((Xbim.Ifc4x3.DateTimeResource.IfcTime)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTimeStamp((Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp)(object)LowerBoundValue);
			}
			if (LowerBoundValue is Xbim.Ifc4x3.MeasureResource.IfcURIReference)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText(((Xbim.Ifc4x3.MeasureResource.IfcURIReference)(object)LowerBoundValue).Value.ToString());
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				LowerBoundValue = null;
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure((Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure((Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure((Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure((Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure((Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure((Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure((Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure((Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcForceMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcForceMeasure((Xbim.Ifc4.MeasureResource.IfcForceMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure((Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure((Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure((Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure((Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure((Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure((Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure((Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure((Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure((Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure((Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure((Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPHMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPHMeasure((Xbim.Ifc4.MeasureResource.IfcPHMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure((Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPowerMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure((Xbim.Ifc4.MeasureResource.IfcPowerMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPressureMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure((Xbim.Ifc4.MeasureResource.IfcPressureMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure((Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure((Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure((Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure((Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerLevelMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerLevelMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureLevelMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureLevelMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure((Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure((Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure((Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure((Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure((Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure((Xbim.Ifc4.MeasureResource.IfcAreaMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcComplexNumber)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcComplexNumber((Xbim.Ifc4.MeasureResource.IfcComplexNumber)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure((Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCountMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcCountMeasure((Xbim.Ifc4.MeasureResource.IfcCountMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcMassMeasure((Xbim.Ifc4.MeasureResource.IfcMassMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure((Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNumericMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure((Xbim.Ifc4.MeasureResource.IfcNumericMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcParameterValue)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcParameterValue((Xbim.Ifc4.MeasureResource.IfcParameterValue)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure((Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure((Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTimeMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure((Xbim.Ifc4.MeasureResource.IfcTimeMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure((Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBinary)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcBinary((Xbim.Ifc4.MeasureResource.IfcBinary)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDate)
			{
				LowerBoundValue = new Xbim.Ifc4x3.DateTimeResource.IfcDate((Xbim.Ifc4.DateTimeResource.IfcDate)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDateTime)
			{
				LowerBoundValue = new Xbim.Ifc4x3.DateTimeResource.IfcDateTime((Xbim.Ifc4.DateTimeResource.IfcDateTime)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDuration)
			{
				LowerBoundValue = new Xbim.Ifc4x3.DateTimeResource.IfcDuration((Xbim.Ifc4.DateTimeResource.IfcDuration)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIdentifier)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcIdentifier((Xbim.Ifc4.MeasureResource.IfcIdentifier)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInteger)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcInteger((Xbim.Ifc4.MeasureResource.IfcInteger)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLabel)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLabel((Xbim.Ifc4.MeasureResource.IfcLabel)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLogical)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcLogical((Xbim.Ifc4.MeasureResource.IfcLogical)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveInteger)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger((Xbim.Ifc4.MeasureResource.IfcPositiveInteger)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcReal)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcReal((Xbim.Ifc4.MeasureResource.IfcReal)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcText)
			{
				LowerBoundValue = new Xbim.Ifc4x3.MeasureResource.IfcText((Xbim.Ifc4.MeasureResource.IfcText)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcTime)
			{
				LowerBoundValue = new Xbim.Ifc4x3.DateTimeResource.IfcTime((Xbim.Ifc4.DateTimeResource.IfcTime)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
			else
			{
				if (!(value is Xbim.Ifc4.DateTimeResource.IfcTimeStamp))
				{
					return;
				}
				LowerBoundValue = new Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp((Xbim.Ifc4.DateTimeResource.IfcTimeStamp)(object)value);
				if (_lowerBoundValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_lowerBoundValue4 = v;
					}, _lowerBoundValue4, null, "LowerBoundValue", -4);
				}
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertyBoundedValue), 5)]
	IIfcUnit IIfcPropertyBoundedValue.Unit
	{
		get
		{
			if (Unit == null)
			{
				return null;
			}
			Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = Unit as Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = Unit as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				return ifcMonetaryUnit;
			}
			Xbim.Ifc4x3.MeasureResource.IfcNamedUnit ifcNamedUnit = Unit as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				return ifcNamedUnit;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				Unit = null;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = value as Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				Unit = ifcDerivedUnit;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = value as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				Unit = ifcMonetaryUnit;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcNamedUnit ifcNamedUnit = value as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				Unit = ifcNamedUnit;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertyBoundedValue), 6)]
	IIfcValue IIfcPropertyBoundedValue.SetPointValue
	{
		get
		{
			if (_setPointValue4 != null)
			{
				return _setPointValue4;
			}
			if (SetPointValue == null)
			{
				return null;
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure((Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure((Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure((Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure((Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure((Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure((Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcEnergyMeasure((Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcForceMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure((Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure((Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInductanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure((Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure((Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure((Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure((Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure((Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcPHMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPHMeasure((Xbim.Ifc4x3.MeasureResource.IfcPHMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure((Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure((Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure((Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPowerLevelMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPowerLevelMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPressureLevelMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPressureLevelMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure((Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure((Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure((Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTorqueMeasure((Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure((Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure((Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure((Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcComplexNumber)
			{
				return new Xbim.Ifc4.MeasureResource.IfcComplexNumber((Xbim.Ifc4x3.MeasureResource.IfcComplexNumber)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure((Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcCountMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCountMeasure((long)(Xbim.Ifc4x3.MeasureResource.IfcCountMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNumericMeasure((Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcParameterValue)
			{
				return new Xbim.Ifc4.MeasureResource.IfcParameterValue((Xbim.Ifc4x3.MeasureResource.IfcParameterValue)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTimeMeasure((Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumeMeasure((Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcBinary)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBinary((Xbim.Ifc4x3.MeasureResource.IfcBinary)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.DateTimeResource.IfcDate)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDate((Xbim.Ifc4x3.DateTimeResource.IfcDate)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.DateTimeResource.IfcDateTime)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDateTime((Xbim.Ifc4x3.DateTimeResource.IfcDateTime)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.DateTimeResource.IfcDuration)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDuration((Xbim.Ifc4x3.DateTimeResource.IfcDuration)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcIdentifier)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIdentifier((Xbim.Ifc4x3.MeasureResource.IfcIdentifier)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInteger((Xbim.Ifc4x3.MeasureResource.IfcInteger)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcLabel)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel((Xbim.Ifc4x3.MeasureResource.IfcLabel)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcLogical)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLogical((Xbim.Ifc4x3.MeasureResource.IfcLogical)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveInteger((Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcReal)
			{
				return new Xbim.Ifc4.MeasureResource.IfcReal((Xbim.Ifc4x3.MeasureResource.IfcReal)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcText)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText((Xbim.Ifc4x3.MeasureResource.IfcText)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.DateTimeResource.IfcTime)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTime((Xbim.Ifc4x3.DateTimeResource.IfcTime)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTimeStamp((Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp)(object)SetPointValue);
			}
			if (SetPointValue is Xbim.Ifc4x3.MeasureResource.IfcURIReference)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText(((Xbim.Ifc4x3.MeasureResource.IfcURIReference)(object)SetPointValue).Value.ToString());
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				SetPointValue = null;
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure((Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure((Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure((Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure((Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure((Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure((Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure((Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure((Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcForceMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcForceMeasure((Xbim.Ifc4.MeasureResource.IfcForceMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure((Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure((Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure((Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure((Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure((Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure((Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure((Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure((Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure((Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure((Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure((Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPHMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcPHMeasure((Xbim.Ifc4.MeasureResource.IfcPHMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure((Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPowerMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure((Xbim.Ifc4.MeasureResource.IfcPowerMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPressureMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure((Xbim.Ifc4.MeasureResource.IfcPressureMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure((Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure((Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure((Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure((Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerLevelMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerLevelMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureLevelMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureLevelMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure((Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure((Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure((Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure((Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure((Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure((Xbim.Ifc4.MeasureResource.IfcAreaMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcComplexNumber)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcComplexNumber((Xbim.Ifc4.MeasureResource.IfcComplexNumber)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure((Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCountMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcCountMeasure((Xbim.Ifc4.MeasureResource.IfcCountMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcMassMeasure((Xbim.Ifc4.MeasureResource.IfcMassMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure((Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNumericMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure((Xbim.Ifc4.MeasureResource.IfcNumericMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcParameterValue)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcParameterValue((Xbim.Ifc4.MeasureResource.IfcParameterValue)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure((Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure((Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTimeMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure((Xbim.Ifc4.MeasureResource.IfcTimeMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure((Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBinary)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcBinary((Xbim.Ifc4.MeasureResource.IfcBinary)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDate)
			{
				SetPointValue = new Xbim.Ifc4x3.DateTimeResource.IfcDate((Xbim.Ifc4.DateTimeResource.IfcDate)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDateTime)
			{
				SetPointValue = new Xbim.Ifc4x3.DateTimeResource.IfcDateTime((Xbim.Ifc4.DateTimeResource.IfcDateTime)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDuration)
			{
				SetPointValue = new Xbim.Ifc4x3.DateTimeResource.IfcDuration((Xbim.Ifc4.DateTimeResource.IfcDuration)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIdentifier)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcIdentifier((Xbim.Ifc4.MeasureResource.IfcIdentifier)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInteger)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcInteger((Xbim.Ifc4.MeasureResource.IfcInteger)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLabel)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcLabel((Xbim.Ifc4.MeasureResource.IfcLabel)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLogical)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcLogical((Xbim.Ifc4.MeasureResource.IfcLogical)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveInteger)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger((Xbim.Ifc4.MeasureResource.IfcPositiveInteger)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcReal)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcReal((Xbim.Ifc4.MeasureResource.IfcReal)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcText)
			{
				SetPointValue = new Xbim.Ifc4x3.MeasureResource.IfcText((Xbim.Ifc4.MeasureResource.IfcText)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcTime)
			{
				SetPointValue = new Xbim.Ifc4x3.DateTimeResource.IfcTime((Xbim.Ifc4.DateTimeResource.IfcTime)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
			else
			{
				if (!(value is Xbim.Ifc4.DateTimeResource.IfcTimeStamp))
				{
					return;
				}
				SetPointValue = new Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp((Xbim.Ifc4.DateTimeResource.IfcTimeStamp)(object)value);
				if (_setPointValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_setPointValue4 = v;
					}, _setPointValue4, null, "SetPointValue", -6);
				}
			}
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc4x3.MeasureResource.IfcValue UpperBoundValue
	{
		get
		{
			if (_activated)
			{
				return _upperBoundValue;
			}
			Activate();
			return _upperBoundValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcValue v)
			{
				_upperBoundValue = v;
			}, _upperBoundValue, value, "UpperBoundValue", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc4x3.MeasureResource.IfcValue LowerBoundValue
	{
		get
		{
			if (_activated)
			{
				return _lowerBoundValue;
			}
			Activate();
			return _lowerBoundValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcValue v)
			{
				_lowerBoundValue = v;
			}, _lowerBoundValue, value, "LowerBoundValue", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc4x3.MeasureResource.IfcUnit Unit
	{
		get
		{
			if (_activated)
			{
				return _unit;
			}
			Activate();
			return _unit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcUnit v)
			{
				_unit = v;
			}, _unit, value, "Unit", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
	public Xbim.Ifc4x3.MeasureResource.IfcValue SetPointValue
	{
		get
		{
			if (_activated)
			{
				return _setPointValue;
			}
			Activate();
			return _setPointValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcValue v)
			{
				_setPointValue = v;
			}, _setPointValue, value, "SetPointValue", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Unit != null)
			{
				yield return Unit;
			}
		}
	}

	internal IfcPropertyBoundedValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_upperBoundValue = (Xbim.Ifc4x3.MeasureResource.IfcValue)value.EntityVal;
			break;
		case 3:
			_lowerBoundValue = (Xbim.Ifc4x3.MeasureResource.IfcValue)value.EntityVal;
			break;
		case 4:
			_unit = (Xbim.Ifc4x3.MeasureResource.IfcUnit)value.EntityVal;
			break;
		case 5:
			_setPointValue = (Xbim.Ifc4x3.MeasureResource.IfcValue)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyBoundedValue other)
	{
		return this == other;
	}
}
