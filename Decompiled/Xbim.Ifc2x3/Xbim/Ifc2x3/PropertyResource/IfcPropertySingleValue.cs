using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PropertyResource;

[ExpressType("IfcPropertySingleValue", 628)]
public class IfcPropertySingleValue : IfcSimpleProperty, IIfcPropertySingleValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPropertySingleValue>
{
	private IIfcValue _nominalValue4;

	private Xbim.Ifc2x3.MeasureResource.IfcValue _nominalValue;

	private Xbim.Ifc2x3.MeasureResource.IfcUnit _unit;

	[CrossSchemaAttribute(typeof(IIfcPropertySingleValue), 3)]
	IIfcValue IIfcPropertySingleValue.NominalValue
	{
		get
		{
			if (_nominalValue4 != null)
			{
				return _nominalValue4;
			}
			if (NominalValue == null)
			{
				return null;
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcVolumeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumeMeasure((Xbim.Ifc2x3.MeasureResource.IfcVolumeMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTimeMeasure((Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure((Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcSolidAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure((Xbim.Ifc2x3.MeasureResource.IfcSolidAngleMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure((Xbim.Ifc2x3.MeasureResource.IfcPositivePlaneAngleMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcParameterValue)
			{
				return new Xbim.Ifc4.MeasureResource.IfcParameterValue((Xbim.Ifc2x3.MeasureResource.IfcParameterValue)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcNumericMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNumericMeasure((Xbim.Ifc2x3.MeasureResource.IfcNumericMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassMeasure((Xbim.Ifc2x3.MeasureResource.IfcMassMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcElectricCurrentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure((Xbim.Ifc2x3.MeasureResource.IfcElectricCurrentMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc2x3.MeasureResource.IfcDescriptiveMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcCountMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCountMeasure((Xbim.Ifc2x3.MeasureResource.IfcCountMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcContextDependentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure((Xbim.Ifc2x3.MeasureResource.IfcContextDependentMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure((Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure((Xbim.Ifc2x3.MeasureResource.IfcAmountOfSubstanceMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcLuminousIntensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure((Xbim.Ifc2x3.MeasureResource.IfcLuminousIntensityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcComplexNumber)
			{
				return new Xbim.Ifc4.MeasureResource.IfcComplexNumber((Xbim.Ifc2x3.MeasureResource.IfcComplexNumber)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInteger((Xbim.Ifc2x3.MeasureResource.IfcInteger)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcReal)
			{
				return new Xbim.Ifc4.MeasureResource.IfcReal((Xbim.Ifc2x3.MeasureResource.IfcReal)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc2x3.MeasureResource.IfcBoolean)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcIdentifier)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIdentifier((Xbim.Ifc2x3.MeasureResource.IfcIdentifier)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcText)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText((Xbim.Ifc2x3.MeasureResource.IfcText)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcLabel)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel((Xbim.Ifc2x3.MeasureResource.IfcLabel)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcLogical)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLogical((Xbim.Ifc2x3.MeasureResource.IfcLogical)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure((Xbim.Ifc2x3.MeasureResource.IfcVolumetricFlowRateMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcTimeStamp)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTimeStamp((Xbim.Ifc2x3.MeasureResource.IfcTimeStamp)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure((Xbim.Ifc2x3.MeasureResource.IfcThermalTransmittanceMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcThermalResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure((Xbim.Ifc2x3.MeasureResource.IfcThermalResistanceMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure((Xbim.Ifc2x3.MeasureResource.IfcThermalAdmittanceMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPressureMeasure((Xbim.Ifc2x3.MeasureResource.IfcPressureMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPowerMeasure((Xbim.Ifc2x3.MeasureResource.IfcPowerMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcMassFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure((Xbim.Ifc2x3.MeasureResource.IfcMassFlowRateMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcMassDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure((Xbim.Ifc2x3.MeasureResource.IfcMassDensityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcLinearVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure((Xbim.Ifc2x3.MeasureResource.IfcLinearVelocityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcKinematicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure((Xbim.Ifc2x3.MeasureResource.IfcKinematicViscosityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcIntegerCountRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure((Xbim.Ifc2x3.MeasureResource.IfcIntegerCountRateMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure((Xbim.Ifc2x3.MeasureResource.IfcHeatFluxDensityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure((Xbim.Ifc2x3.MeasureResource.IfcFrequencyMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcEnergyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcEnergyMeasure((Xbim.Ifc2x3.MeasureResource.IfcEnergyMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcElectricVoltageMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure((Xbim.Ifc2x3.MeasureResource.IfcElectricVoltageMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcDynamicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure((Xbim.Ifc2x3.MeasureResource.IfcDynamicViscosityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure((Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcAngularVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure((Xbim.Ifc2x3.MeasureResource.IfcAngularVelocityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcThermalConductivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure((Xbim.Ifc2x3.MeasureResource.IfcThermalConductivityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcMolecularWeightMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure((Xbim.Ifc2x3.MeasureResource.IfcMolecularWeightMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure((Xbim.Ifc2x3.MeasureResource.IfcVaporPermeabilityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure((Xbim.Ifc2x3.MeasureResource.IfcMoistureDiffusivityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc2x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure((Xbim.Ifc2x3.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcMonetaryMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc2x3.MeasureResource.IfcMonetaryMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure((Xbim.Ifc2x3.MeasureResource.IfcMagneticFluxDensityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcMagneticFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure((Xbim.Ifc2x3.MeasureResource.IfcMagneticFluxMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcLuminousFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure((Xbim.Ifc2x3.MeasureResource.IfcLuminousFluxMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcForceMeasure((Xbim.Ifc2x3.MeasureResource.IfcForceMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcInductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInductanceMeasure((Xbim.Ifc2x3.MeasureResource.IfcInductanceMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcIlluminanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure((Xbim.Ifc2x3.MeasureResource.IfcIlluminanceMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcElectricResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure((Xbim.Ifc2x3.MeasureResource.IfcElectricResistanceMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcElectricConductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure((Xbim.Ifc2x3.MeasureResource.IfcElectricConductanceMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcElectricChargeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure((Xbim.Ifc2x3.MeasureResource.IfcElectricChargeMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcDoseEquivalentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure((Xbim.Ifc2x3.MeasureResource.IfcDoseEquivalentMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure((Xbim.Ifc2x3.MeasureResource.IfcElectricCapacitanceMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure((Xbim.Ifc2x3.MeasureResource.IfcAbsorbedDoseMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcRadioActivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure((Xbim.Ifc2x3.MeasureResource.IfcRadioActivityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure((Xbim.Ifc2x3.MeasureResource.IfcRotationalFrequencyMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTorqueMeasure((Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcAccelerationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure((Xbim.Ifc2x3.MeasureResource.IfcAccelerationMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure((Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure((Xbim.Ifc2x3.MeasureResource.IfcModulusOfElasticityMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure((Xbim.Ifc2x3.MeasureResource.IfcMomentOfInertiaMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure((Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcShearModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure((Xbim.Ifc2x3.MeasureResource.IfcShearModulusMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure((Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure((Xbim.Ifc2x3.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcCurvatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure((Xbim.Ifc2x3.MeasureResource.IfcCurvatureMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcMassPerLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure((Xbim.Ifc2x3.MeasureResource.IfcMassPerLengthMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcRotationalMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure((Xbim.Ifc2x3.MeasureResource.IfcRotationalMassMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure((Xbim.Ifc2x3.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcSectionModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure((Xbim.Ifc2x3.MeasureResource.IfcSectionModulusMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcTemperatureGradientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure((Xbim.Ifc2x3.MeasureResource.IfcTemperatureGradientMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure((Xbim.Ifc2x3.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcWarpingConstantMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure((Xbim.Ifc2x3.MeasureResource.IfcWarpingConstantMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcWarpingMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc2x3.MeasureResource.IfcWarpingMomentMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcSoundPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc2x3.MeasureResource.IfcSoundPowerMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcSoundPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc2x3.MeasureResource.IfcSoundPressureMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcHeatingValueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure((Xbim.Ifc2x3.MeasureResource.IfcHeatingValueMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcPHMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPHMeasure((Xbim.Ifc2x3.MeasureResource.IfcPHMeasure)(object)NominalValue);
			}
			if (NominalValue is Xbim.Ifc2x3.MeasureResource.IfcIonConcentrationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure((Xbim.Ifc2x3.MeasureResource.IfcIonConcentrationMeasure)(object)NominalValue);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				NominalValue = null;
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcAbsorbedDoseMeasure((Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcAccelerationMeasure((Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcAngularVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is IfcAreaDensityMeasure)
			{
				if (NominalValue != null)
				{
					NominalValue = null;
				}
				SetValue(delegate(IIfcValue v)
				{
					_nominalValue4 = v;
				}, _nominalValue4, value, "NominalValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcCompoundPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcCurvatureMeasure((Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcDoseEquivalentMeasure((Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcDynamicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcElectricCapacitanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcElectricChargeMeasure((Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcElectricConductanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcElectricResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcElectricVoltageMeasure((Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcEnergyMeasure((Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcForceMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcForceMeasure((Xbim.Ifc4.MeasureResource.IfcForceMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcHeatFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcHeatingValueMeasure((Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcIlluminanceMeasure((Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcInductanceMeasure((Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcIntegerCountRateMeasure((Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcIonConcentrationMeasure((Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcKinematicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcLinearForceMeasure((Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcLinearMomentMeasure((Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcLinearVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcLuminousFluxMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcLuminousIntensityDistributionMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcMagneticFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcMagneticFluxMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcMassDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcMassFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcMassPerLengthMeasure((Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfElasticityMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcMoistureDiffusivityMeasure((Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcMolecularWeightMeasure((Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcMomentOfInertiaMeasure((Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPHMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcPHMeasure((Xbim.Ifc4.MeasureResource.IfcPHMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcPlanarForceMeasure((Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPowerMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcPowerMeasure((Xbim.Ifc4.MeasureResource.IfcPowerMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPressureMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcPressureMeasure((Xbim.Ifc4.MeasureResource.IfcPressureMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcRadioActivityMeasure((Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcRotationalFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcRotationalMassMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcSectionModulusMeasure((Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcSectionalAreaIntegralMeasure((Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcShearModulusMeasure((Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is IfcSoundPowerLevelMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcSoundPowerMeasure((IfcSoundPowerLevelMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is IfcSoundPressureLevelMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcSoundPressureMeasure((IfcSoundPressureLevelMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcSpecificHeatCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcTemperatureGradientMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is IfcTemperatureRateOfChangeMeasure)
			{
				if (NominalValue != null)
				{
					NominalValue = null;
				}
				SetValue(delegate(IIfcValue v)
				{
					_nominalValue4 = v;
				}, _nominalValue4, value, "NominalValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcThermalAdmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcThermalConductivityMeasure((Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcThermalExpansionCoefficientMeasure((Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcThermalResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcThermalTransmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcTorqueMeasure((Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcVaporPermeabilityMeasure((Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcVolumetricFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcWarpingConstantMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcAmountOfSubstanceMeasure((Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure((Xbim.Ifc4.MeasureResource.IfcAreaMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcComplexNumber)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcComplexNumber((Xbim.Ifc4.MeasureResource.IfcComplexNumber)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcContextDependentMeasure((Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCountMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcCountMeasure((Xbim.Ifc4.MeasureResource.IfcCountMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcElectricCurrentMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcLuminousIntensityMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcMassMeasure((Xbim.Ifc4.MeasureResource.IfcMassMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is IfcNonNegativeLengthMeasure)
			{
				if (NominalValue != null)
				{
					NominalValue = null;
				}
				SetValue(delegate(IIfcValue v)
				{
					_nominalValue4 = v;
				}, _nominalValue4, value, "NominalValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNumericMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcNumericMeasure((Xbim.Ifc4.MeasureResource.IfcNumericMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcParameterValue)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcParameterValue((Xbim.Ifc4.MeasureResource.IfcParameterValue)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcPositivePlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcSolidAngleMeasure((Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure((Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTimeMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure((Xbim.Ifc4.MeasureResource.IfcTimeMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcVolumeMeasure((Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is IfcBinary)
			{
				if (NominalValue != null)
				{
					NominalValue = null;
				}
				SetValue(delegate(IIfcValue v)
				{
					_nominalValue4 = v;
				}, _nominalValue4, value, "NominalValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is IfcDate)
			{
				if (NominalValue != null)
				{
					NominalValue = null;
				}
				SetValue(delegate(IIfcValue v)
				{
					_nominalValue4 = v;
				}, _nominalValue4, value, "NominalValue", -3);
			}
			else if (value is IfcDateTime)
			{
				if (NominalValue != null)
				{
					NominalValue = null;
				}
				SetValue(delegate(IIfcValue v)
				{
					_nominalValue4 = v;
				}, _nominalValue4, value, "NominalValue", -3);
			}
			else if (value is IfcDuration)
			{
				if (NominalValue != null)
				{
					NominalValue = null;
				}
				SetValue(delegate(IIfcValue v)
				{
					_nominalValue4 = v;
				}, _nominalValue4, value, "NominalValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIdentifier)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcIdentifier((Xbim.Ifc4.MeasureResource.IfcIdentifier)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInteger)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcInteger((Xbim.Ifc4.MeasureResource.IfcInteger)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLabel)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcLabel((Xbim.Ifc4.MeasureResource.IfcLabel)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLogical)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcLogical((Xbim.Ifc4.MeasureResource.IfcLogical)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is IfcPositiveInteger)
			{
				if (NominalValue != null)
				{
					NominalValue = null;
				}
				SetValue(delegate(IIfcValue v)
				{
					_nominalValue4 = v;
				}, _nominalValue4, value, "NominalValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcReal)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcReal((Xbim.Ifc4.MeasureResource.IfcReal)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcText)
			{
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcText((Xbim.Ifc4.MeasureResource.IfcText)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
			else if (value is IfcTime)
			{
				if (NominalValue != null)
				{
					NominalValue = null;
				}
				SetValue(delegate(IIfcValue v)
				{
					_nominalValue4 = v;
				}, _nominalValue4, value, "NominalValue", -3);
			}
			else
			{
				if (!(value is Xbim.Ifc4.DateTimeResource.IfcTimeStamp))
				{
					return;
				}
				NominalValue = new Xbim.Ifc2x3.MeasureResource.IfcTimeStamp((Xbim.Ifc4.DateTimeResource.IfcTimeStamp)(object)value);
				if (_nominalValue4 != null)
				{
					SetValue(delegate(IIfcValue v)
					{
						_nominalValue4 = v;
					}, _nominalValue4, null, "NominalValue", -3);
				}
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertySingleValue), 4)]
	IIfcUnit IIfcPropertySingleValue.Unit
	{
		get
		{
			if (Unit == null)
			{
				return null;
			}
			Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = Unit as Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			Xbim.Ifc2x3.MeasureResource.IfcNamedUnit ifcNamedUnit = Unit as Xbim.Ifc2x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				return ifcNamedUnit;
			}
			Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = Unit as Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				return ifcMonetaryUnit;
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
			Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = value as Xbim.Ifc2x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				Unit = ifcDerivedUnit;
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = value as Xbim.Ifc2x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				Unit = ifcMonetaryUnit;
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcNamedUnit ifcNamedUnit = value as Xbim.Ifc2x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				Unit = ifcNamedUnit;
			}
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcValue NominalValue
	{
		get
		{
			if (_activated)
			{
				return _nominalValue;
			}
			Activate();
			return _nominalValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcValue v)
			{
				_nominalValue = v;
			}, _nominalValue, value, "NominalValue", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcUnit Unit
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcUnit v)
			{
				_unit = v;
			}, _unit, value, "Unit", 4);
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

	internal IfcPropertySingleValue(IModel model, int label, bool activated)
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
			_nominalValue = (Xbim.Ifc2x3.MeasureResource.IfcValue)value.EntityVal;
			break;
		case 3:
			_unit = (Xbim.Ifc2x3.MeasureResource.IfcUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertySingleValue other)
	{
		return this == other;
	}
}
