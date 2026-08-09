using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.DateTimeResource;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcMeasureWithUnit", 7)]
public class IfcMeasureWithUnit : PersistEntity, IIfcMeasureWithUnit, IPersistEntity, IPersist, Xbim.Ifc4.CostResource.IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, Xbim.Ifc4.ConstraintResource.IfcMetricValueSelect, IIfcMetricValueSelect, IInstantiableEntity, Xbim.Ifc4x3.CostResource.IfcAppliedValueSelect, Xbim.Ifc4x3.ConstraintResource.IfcMetricValueSelect, IContainsEntityReferences, IEquatable<IfcMeasureWithUnit>
{
	private IIfcValue _valueComponent4;

	private IfcValue _valueComponent;

	private IfcUnit _unitComponent;

	[CrossSchemaAttribute(typeof(IIfcMeasureWithUnit), 1)]
	IIfcValue IIfcMeasureWithUnit.ValueComponent
	{
		get
		{
			if (_valueComponent4 != null)
			{
				return _valueComponent4;
			}
			if (ValueComponent == null)
			{
				return null;
			}
			if (ValueComponent is IfcAbsorbedDoseMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure((IfcAbsorbedDoseMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcAccelerationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure((IfcAccelerationMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcAngularVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure((IfcAngularVelocityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcAreaDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure((IfcAreaDensityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcCompoundPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure((IfcCompoundPlaneAngleMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcCurvatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure((IfcCurvatureMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcDoseEquivalentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure((IfcDoseEquivalentMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcDynamicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure((IfcDynamicViscosityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcElectricCapacitanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure((IfcElectricCapacitanceMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcElectricChargeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure((IfcElectricChargeMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcElectricConductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure((IfcElectricConductanceMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcElectricResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure((IfcElectricResistanceMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcElectricVoltageMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure((IfcElectricVoltageMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcEnergyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcEnergyMeasure((IfcEnergyMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcForceMeasure((IfcForceMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure((IfcFrequencyMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcHeatFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure((IfcHeatFluxDensityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcHeatingValueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure((IfcHeatingValueMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcIlluminanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure((IfcIlluminanceMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcInductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInductanceMeasure((IfcInductanceMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcIntegerCountRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure((IfcIntegerCountRateMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcIonConcentrationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure((IfcIonConcentrationMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcIsothermalMoistureCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure((IfcIsothermalMoistureCapacityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcKinematicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure((IfcKinematicViscosityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcLinearForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure((IfcLinearForceMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcLinearMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure((IfcLinearMomentMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcLinearStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure((IfcLinearStiffnessMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcLinearVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure((IfcLinearVelocityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcLuminousFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure((IfcLuminousFluxMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcLuminousIntensityDistributionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure((IfcLuminousIntensityDistributionMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcMagneticFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure((IfcMagneticFluxDensityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcMagneticFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure((IfcMagneticFluxMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcMassDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure((IfcMassDensityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcMassFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure((IfcMassFlowRateMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcMassPerLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure((IfcMassPerLengthMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcModulusOfElasticityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure((IfcModulusOfElasticityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcModulusOfLinearSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((IfcModulusOfLinearSubgradeReactionMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((IfcModulusOfRotationalSubgradeReactionMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcModulusOfSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure((IfcModulusOfSubgradeReactionMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcMoistureDiffusivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure((IfcMoistureDiffusivityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcMolecularWeightMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure((IfcMolecularWeightMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcMomentOfInertiaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure((IfcMomentOfInertiaMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcMonetaryMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure((IfcMonetaryMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcPHMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPHMeasure((IfcPHMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcPlanarForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure((IfcPlanarForceMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPowerMeasure((IfcPowerMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPressureMeasure((IfcPressureMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcRadioActivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure((IfcRadioActivityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcRotationalFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure((IfcRotationalFrequencyMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcRotationalMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure((IfcRotationalMassMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcRotationalStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure((IfcRotationalStiffnessMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcSectionModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure((IfcSectionModulusMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcSectionalAreaIntegralMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure((IfcSectionalAreaIntegralMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcShearModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure((IfcShearModulusMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcSoundPowerLevelMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((IfcSoundPowerLevelMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcSoundPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((IfcSoundPowerMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcSoundPressureLevelMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((IfcSoundPressureLevelMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcSoundPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((IfcSoundPressureMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcSpecificHeatCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure((IfcSpecificHeatCapacityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcTemperatureGradientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure((IfcTemperatureGradientMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcTemperatureRateOfChangeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure((IfcTemperatureRateOfChangeMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcThermalAdmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure((IfcThermalAdmittanceMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcThermalConductivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure((IfcThermalConductivityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcThermalExpansionCoefficientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure((IfcThermalExpansionCoefficientMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcThermalResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure((IfcThermalResistanceMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcThermalTransmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure((IfcThermalTransmittanceMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcTorqueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTorqueMeasure((IfcTorqueMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcVaporPermeabilityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure((IfcVaporPermeabilityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcVolumetricFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure((IfcVolumetricFlowRateMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcWarpingConstantMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure((IfcWarpingConstantMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcWarpingMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure((IfcWarpingMomentMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcAmountOfSubstanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure((IfcAmountOfSubstanceMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcAreaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure((IfcAreaMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcComplexNumber)
			{
				return new Xbim.Ifc4.MeasureResource.IfcComplexNumber((IfcComplexNumber)(object)ValueComponent);
			}
			if (ValueComponent is IfcContextDependentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure((IfcContextDependentMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcCountMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCountMeasure((long)(IfcCountMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((IfcDescriptiveMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcElectricCurrentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure((IfcElectricCurrentMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((IfcLengthMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcLuminousIntensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure((IfcLuminousIntensityMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassMeasure((IfcMassMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcNonNegativeLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure((IfcNonNegativeLengthMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((IfcNormalisedRatioMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcNumericMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNumericMeasure((IfcNumericMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcParameterValue)
			{
				return new Xbim.Ifc4.MeasureResource.IfcParameterValue((IfcParameterValue)(object)ValueComponent);
			}
			if (ValueComponent is IfcPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure((IfcPlaneAngleMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((IfcPositiveLengthMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcPositivePlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure((IfcPositivePlaneAngleMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((IfcPositiveRatioMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((IfcRatioMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcSolidAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure((IfcSolidAngleMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcThermodynamicTemperatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure((IfcThermodynamicTemperatureMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcTimeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTimeMeasure((IfcTimeMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcVolumeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumeMeasure((IfcVolumeMeasure)(object)ValueComponent);
			}
			if (ValueComponent is IfcBinary)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBinary((IfcBinary)(object)ValueComponent);
			}
			if (ValueComponent is IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((IfcBoolean)(object)ValueComponent);
			}
			if (ValueComponent is Xbim.Ifc4x3.DateTimeResource.IfcDate)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDate((Xbim.Ifc4x3.DateTimeResource.IfcDate)(object)ValueComponent);
			}
			if (ValueComponent is Xbim.Ifc4x3.DateTimeResource.IfcDateTime)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDateTime((Xbim.Ifc4x3.DateTimeResource.IfcDateTime)(object)ValueComponent);
			}
			if (ValueComponent is Xbim.Ifc4x3.DateTimeResource.IfcDuration)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDuration((Xbim.Ifc4x3.DateTimeResource.IfcDuration)(object)ValueComponent);
			}
			if (ValueComponent is IfcIdentifier)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIdentifier((IfcIdentifier)(object)ValueComponent);
			}
			if (ValueComponent is IfcInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInteger((IfcInteger)(object)ValueComponent);
			}
			if (ValueComponent is IfcLabel)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel((IfcLabel)(object)ValueComponent);
			}
			if (ValueComponent is IfcLogical)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLogical((IfcLogical)(object)ValueComponent);
			}
			if (ValueComponent is IfcPositiveInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveInteger((IfcPositiveInteger)(object)ValueComponent);
			}
			if (ValueComponent is IfcReal)
			{
				return new Xbim.Ifc4.MeasureResource.IfcReal((IfcReal)(object)ValueComponent);
			}
			if (ValueComponent is IfcText)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText((IfcText)(object)ValueComponent);
			}
			if (ValueComponent is Xbim.Ifc4x3.DateTimeResource.IfcTime)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTime((Xbim.Ifc4x3.DateTimeResource.IfcTime)(object)ValueComponent);
			}
			if (ValueComponent is Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTimeStamp((Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp)(object)ValueComponent);
			}
			if (ValueComponent is IfcURIReference)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText(((IfcURIReference)(object)ValueComponent).Value.ToString());
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				ValueComponent = null;
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				ValueComponent = new IfcAbsorbedDoseMeasure((Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)
			{
				ValueComponent = new IfcAccelerationMeasure((Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)
			{
				ValueComponent = new IfcAngularVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure)
			{
				ValueComponent = new IfcAreaDensityMeasure((Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				ValueComponent = new IfcCompoundPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)
			{
				ValueComponent = new IfcCurvatureMeasure((Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)
			{
				ValueComponent = new IfcDoseEquivalentMeasure((Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)
			{
				ValueComponent = new IfcDynamicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				ValueComponent = new IfcElectricCapacitanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)
			{
				ValueComponent = new IfcElectricChargeMeasure((Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)
			{
				ValueComponent = new IfcElectricConductanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)
			{
				ValueComponent = new IfcElectricResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)
			{
				ValueComponent = new IfcElectricVoltageMeasure((Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)
			{
				ValueComponent = new IfcEnergyMeasure((Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcForceMeasure)
			{
				ValueComponent = new IfcForceMeasure((Xbim.Ifc4.MeasureResource.IfcForceMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)
			{
				ValueComponent = new IfcFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				ValueComponent = new IfcHeatFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)
			{
				ValueComponent = new IfcHeatingValueMeasure((Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)
			{
				ValueComponent = new IfcIlluminanceMeasure((Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)
			{
				ValueComponent = new IfcInductanceMeasure((Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)
			{
				ValueComponent = new IfcIntegerCountRateMeasure((Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)
			{
				ValueComponent = new IfcIonConcentrationMeasure((Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				ValueComponent = new IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)
			{
				ValueComponent = new IfcKinematicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)
			{
				ValueComponent = new IfcLinearForceMeasure((Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)
			{
				ValueComponent = new IfcLinearMomentMeasure((Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				ValueComponent = new IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)
			{
				ValueComponent = new IfcLinearVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)
			{
				ValueComponent = new IfcLuminousFluxMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				ValueComponent = new IfcLuminousIntensityDistributionMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				ValueComponent = new IfcMagneticFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)
			{
				ValueComponent = new IfcMagneticFluxMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)
			{
				ValueComponent = new IfcMassDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)
			{
				ValueComponent = new IfcMassFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)
			{
				ValueComponent = new IfcMassPerLengthMeasure((Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				ValueComponent = new IfcModulusOfElasticityMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				ValueComponent = new IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				ValueComponent = new IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				ValueComponent = new IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				ValueComponent = new IfcMoistureDiffusivityMeasure((Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)
			{
				ValueComponent = new IfcMolecularWeightMeasure((Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				ValueComponent = new IfcMomentOfInertiaMeasure((Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)
			{
				ValueComponent = new IfcMonetaryMeasure((Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPHMeasure)
			{
				ValueComponent = new IfcPHMeasure((Xbim.Ifc4.MeasureResource.IfcPHMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)
			{
				ValueComponent = new IfcPlanarForceMeasure((Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPowerMeasure)
			{
				ValueComponent = new IfcPowerMeasure((Xbim.Ifc4.MeasureResource.IfcPowerMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPressureMeasure)
			{
				ValueComponent = new IfcPressureMeasure((Xbim.Ifc4.MeasureResource.IfcPressureMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)
			{
				ValueComponent = new IfcRadioActivityMeasure((Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				ValueComponent = new IfcRotationalFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)
			{
				ValueComponent = new IfcRotationalMassMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				ValueComponent = new IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)
			{
				ValueComponent = new IfcSectionModulusMeasure((Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				ValueComponent = new IfcSectionalAreaIntegralMeasure((Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)
			{
				ValueComponent = new IfcShearModulusMeasure((Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerLevelMeasure)
			{
				ValueComponent = new IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerLevelMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)
			{
				ValueComponent = new IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureLevelMeasure)
			{
				ValueComponent = new IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureLevelMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)
			{
				ValueComponent = new IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				ValueComponent = new IfcSpecificHeatCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)
			{
				ValueComponent = new IfcTemperatureGradientMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure)
			{
				ValueComponent = new IfcTemperatureRateOfChangeMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				ValueComponent = new IfcThermalAdmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)
			{
				ValueComponent = new IfcThermalConductivityMeasure((Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				ValueComponent = new IfcThermalExpansionCoefficientMeasure((Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)
			{
				ValueComponent = new IfcThermalResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				ValueComponent = new IfcThermalTransmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)
			{
				ValueComponent = new IfcTorqueMeasure((Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				ValueComponent = new IfcVaporPermeabilityMeasure((Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				ValueComponent = new IfcVolumetricFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)
			{
				ValueComponent = new IfcWarpingConstantMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)
			{
				ValueComponent = new IfcWarpingMomentMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				ValueComponent = new IfcAmountOfSubstanceMeasure((Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaMeasure)
			{
				ValueComponent = new IfcAreaMeasure((Xbim.Ifc4.MeasureResource.IfcAreaMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcComplexNumber)
			{
				ValueComponent = new IfcComplexNumber((Xbim.Ifc4.MeasureResource.IfcComplexNumber)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)
			{
				ValueComponent = new IfcContextDependentMeasure((Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCountMeasure)
			{
				ValueComponent = new IfcCountMeasure((Xbim.Ifc4.MeasureResource.IfcCountMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				ValueComponent = new IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)
			{
				ValueComponent = new IfcElectricCurrentMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				ValueComponent = new IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)
			{
				ValueComponent = new IfcLuminousIntensityMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassMeasure)
			{
				ValueComponent = new IfcMassMeasure((Xbim.Ifc4.MeasureResource.IfcMassMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure)
			{
				ValueComponent = new IfcNonNegativeLengthMeasure((Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				ValueComponent = new IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNumericMeasure)
			{
				ValueComponent = new IfcNumericMeasure((Xbim.Ifc4.MeasureResource.IfcNumericMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcParameterValue)
			{
				ValueComponent = new IfcParameterValue((Xbim.Ifc4.MeasureResource.IfcParameterValue)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)
			{
				ValueComponent = new IfcPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				ValueComponent = new IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				ValueComponent = new IfcPositivePlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				ValueComponent = new IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				ValueComponent = new IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)
			{
				ValueComponent = new IfcSolidAngleMeasure((Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				ValueComponent = new IfcThermodynamicTemperatureMeasure((Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTimeMeasure)
			{
				ValueComponent = new IfcTimeMeasure((Xbim.Ifc4.MeasureResource.IfcTimeMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)
			{
				ValueComponent = new IfcVolumeMeasure((Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBinary)
			{
				ValueComponent = new IfcBinary((Xbim.Ifc4.MeasureResource.IfcBinary)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				ValueComponent = new IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDate)
			{
				ValueComponent = new Xbim.Ifc4x3.DateTimeResource.IfcDate((Xbim.Ifc4.DateTimeResource.IfcDate)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDateTime)
			{
				ValueComponent = new Xbim.Ifc4x3.DateTimeResource.IfcDateTime((Xbim.Ifc4.DateTimeResource.IfcDateTime)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDuration)
			{
				ValueComponent = new Xbim.Ifc4x3.DateTimeResource.IfcDuration((Xbim.Ifc4.DateTimeResource.IfcDuration)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIdentifier)
			{
				ValueComponent = new IfcIdentifier((Xbim.Ifc4.MeasureResource.IfcIdentifier)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInteger)
			{
				ValueComponent = new IfcInteger((Xbim.Ifc4.MeasureResource.IfcInteger)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLabel)
			{
				ValueComponent = new IfcLabel((Xbim.Ifc4.MeasureResource.IfcLabel)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLogical)
			{
				ValueComponent = new IfcLogical((Xbim.Ifc4.MeasureResource.IfcLogical)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveInteger)
			{
				ValueComponent = new IfcPositiveInteger((Xbim.Ifc4.MeasureResource.IfcPositiveInteger)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcReal)
			{
				ValueComponent = new IfcReal((Xbim.Ifc4.MeasureResource.IfcReal)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcText)
			{
				ValueComponent = new IfcText((Xbim.Ifc4.MeasureResource.IfcText)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcTime)
			{
				ValueComponent = new Xbim.Ifc4x3.DateTimeResource.IfcTime((Xbim.Ifc4.DateTimeResource.IfcTime)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
			else
			{
				if (!(value is Xbim.Ifc4.DateTimeResource.IfcTimeStamp))
				{
					return;
				}
				ValueComponent = new Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp((Xbim.Ifc4.DateTimeResource.IfcTimeStamp)(object)value);
				if (_valueComponent4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_valueComponent4 = v;
					}, _valueComponent4, null, "ValueComponent", -1);
				}
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMeasureWithUnit), 2)]
	IIfcUnit IIfcMeasureWithUnit.UnitComponent
	{
		get
		{
			if (UnitComponent == null)
			{
				return null;
			}
			IfcDerivedUnit ifcDerivedUnit = UnitComponent as IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			IfcMonetaryUnit ifcMonetaryUnit = UnitComponent as IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				return ifcMonetaryUnit;
			}
			IfcNamedUnit ifcNamedUnit = UnitComponent as IfcNamedUnit;
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
				UnitComponent = null;
				return;
			}
			IfcDerivedUnit ifcDerivedUnit = value as IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				UnitComponent = ifcDerivedUnit;
				return;
			}
			IfcMonetaryUnit ifcMonetaryUnit = value as IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				UnitComponent = ifcMonetaryUnit;
				return;
			}
			IfcNamedUnit ifcNamedUnit = value as IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				UnitComponent = ifcNamedUnit;
			}
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcValue ValueComponent
	{
		get
		{
			if (_activated)
			{
				return _valueComponent;
			}
			Activate();
			return _valueComponent;
		}
		set
		{
			SetValue(delegate(IfcValue v)
			{
				_valueComponent = v;
			}, _valueComponent, value, "ValueComponent", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcUnit UnitComponent
	{
		get
		{
			if (_activated)
			{
				return _unitComponent;
			}
			Activate();
			return _unitComponent;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcUnit v)
			{
				_unitComponent = v;
			}, _unitComponent, value, "UnitComponent", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (UnitComponent != null)
			{
				yield return UnitComponent;
			}
		}
	}

	internal IfcMeasureWithUnit(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_valueComponent = (IfcValue)value.EntityVal;
			break;
		case 1:
			_unitComponent = (IfcUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMeasureWithUnit other)
	{
		return this == other;
	}
}
