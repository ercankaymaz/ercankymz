using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.UtilityResource;

namespace Xbim.Ifc4x3.ConstraintResource;

[ExpressType("IfcMetric", 80)]
public class IfcMetric : IfcConstraint, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcMetric>, IIfcMetric, IIfcConstraint, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	private IfcBenchmarkEnum _benchmark;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _valueSource;

	private IfcMetricValueSelect _dataValue;

	private IfcReference _referencePath;

	private IIfcMetricValueSelect _dataValue4;

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 10)]
	public IfcBenchmarkEnum Benchmark
	{
		get
		{
			if (_activated)
			{
				return _benchmark;
			}
			Activate();
			return _benchmark;
		}
		set
		{
			SetValue(delegate(IfcBenchmarkEnum v)
			{
				_benchmark = v;
			}, _benchmark, value, "Benchmark", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? ValueSource
	{
		get
		{
			if (_activated)
			{
				return _valueSource;
			}
			Activate();
			return _valueSource;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_valueSource = v;
			}, _valueSource, value, "ValueSource", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public IfcMetricValueSelect DataValue
	{
		get
		{
			if (_activated)
			{
				return _dataValue;
			}
			Activate();
			return _dataValue;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMetricValueSelect v)
			{
				_dataValue = v;
			}, _dataValue, value, "DataValue", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
	public IfcReference ReferencePath
	{
		get
		{
			if (_activated)
			{
				return _referencePath;
			}
			Activate();
			return _referencePath;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcReference v)
			{
				_referencePath = v;
			}, _referencePath, value, "ReferencePath", 11);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.CreatingActor != null)
			{
				yield return base.CreatingActor;
			}
			if (ReferencePath != null)
			{
				yield return ReferencePath;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMetric), 8)]
	Xbim.Ifc4.Interfaces.IfcBenchmarkEnum IIfcMetric.Benchmark
	{
		get
		{
			return Benchmark switch
			{
				IfcBenchmarkEnum.EQUALTO => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.EQUALTO, 
				IfcBenchmarkEnum.GREATERTHAN => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.GREATERTHAN, 
				IfcBenchmarkEnum.GREATERTHANOREQUALTO => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.GREATERTHANOREQUALTO, 
				IfcBenchmarkEnum.INCLUDEDIN => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.INCLUDEDIN, 
				IfcBenchmarkEnum.INCLUDES => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.INCLUDES, 
				IfcBenchmarkEnum.LESSTHAN => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.LESSTHAN, 
				IfcBenchmarkEnum.LESSTHANOREQUALTO => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.LESSTHANOREQUALTO, 
				IfcBenchmarkEnum.NOTEQUALTO => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.NOTEQUALTO, 
				IfcBenchmarkEnum.NOTINCLUDEDIN => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.NOTINCLUDEDIN, 
				IfcBenchmarkEnum.NOTINCLUDES => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.NOTINCLUDES, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.GREATERTHAN:
				Benchmark = IfcBenchmarkEnum.GREATERTHAN;
				break;
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.GREATERTHANOREQUALTO:
				Benchmark = IfcBenchmarkEnum.GREATERTHANOREQUALTO;
				break;
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.LESSTHAN:
				Benchmark = IfcBenchmarkEnum.LESSTHAN;
				break;
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.LESSTHANOREQUALTO:
				Benchmark = IfcBenchmarkEnum.LESSTHANOREQUALTO;
				break;
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.EQUALTO:
				Benchmark = IfcBenchmarkEnum.EQUALTO;
				break;
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.NOTEQUALTO:
				Benchmark = IfcBenchmarkEnum.NOTEQUALTO;
				break;
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.INCLUDES:
				Benchmark = IfcBenchmarkEnum.INCLUDES;
				break;
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.NOTINCLUDES:
				Benchmark = IfcBenchmarkEnum.NOTINCLUDES;
				break;
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.INCLUDEDIN:
				Benchmark = IfcBenchmarkEnum.INCLUDEDIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.NOTINCLUDEDIN:
				Benchmark = IfcBenchmarkEnum.NOTINCLUDEDIN;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMetric), 9)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMetric.ValueSource
	{
		get
		{
			if (!ValueSource.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ValueSource.Value);
		}
		set
		{
			ValueSource = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMetric), 10)]
	IIfcMetricValueSelect IIfcMetric.DataValue
	{
		get
		{
			if (_dataValue4 != null)
			{
				return _dataValue4;
			}
			if (DataValue == null)
			{
				return null;
			}
			IfcAppliedValue ifcAppliedValue = DataValue as IfcAppliedValue;
			if (ifcAppliedValue != null)
			{
				return ifcAppliedValue;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit ifcMeasureWithUnit = DataValue as Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit;
			if (ifcMeasureWithUnit != null)
			{
				return ifcMeasureWithUnit;
			}
			IfcReference ifcReference = DataValue as IfcReference;
			if (ifcReference != null)
			{
				return ifcReference;
			}
			IfcTable ifcTable = DataValue as IfcTable;
			if (ifcTable != null)
			{
				return ifcTable;
			}
			Xbim.Ifc4x3.DateTimeResource.IfcTimeSeries ifcTimeSeries = DataValue as Xbim.Ifc4x3.DateTimeResource.IfcTimeSeries;
			if (ifcTimeSeries != null)
			{
				return ifcTimeSeries;
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure((Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure((Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure((Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure((Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure((Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure((Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcEnergyMeasure((Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcForceMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure((Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure((Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInductanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure((Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure((Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure((Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure((Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure((Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure((Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcPHMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPHMeasure((Xbim.Ifc4x3.MeasureResource.IfcPHMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure((Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure((Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure((Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure((Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPowerLevelMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPowerLevelMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPressureLevelMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPressureLevelMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure((Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure((Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure((Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTorqueMeasure((Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure((Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure((Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure((Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure((Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure((Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcComplexNumber)
			{
				return new Xbim.Ifc4.MeasureResource.IfcComplexNumber((Xbim.Ifc4x3.MeasureResource.IfcComplexNumber)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure((Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcCountMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcCountMeasure((long)(Xbim.Ifc4x3.MeasureResource.IfcCountMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure((Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure((Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcMassMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMassMeasure((Xbim.Ifc4x3.MeasureResource.IfcMassMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNumericMeasure((Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcParameterValue)
			{
				return new Xbim.Ifc4.MeasureResource.IfcParameterValue((Xbim.Ifc4x3.MeasureResource.IfcParameterValue)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure((Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcTimeMeasure((Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcVolumeMeasure((Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcBinary)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBinary((Xbim.Ifc4x3.MeasureResource.IfcBinary)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcBoolean)
			{
				return new Xbim.Ifc4.MeasureResource.IfcBoolean((Xbim.Ifc4x3.MeasureResource.IfcBoolean)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.DateTimeResource.IfcDate)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDate((Xbim.Ifc4x3.DateTimeResource.IfcDate)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.DateTimeResource.IfcDateTime)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDateTime((Xbim.Ifc4x3.DateTimeResource.IfcDateTime)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.DateTimeResource.IfcDuration)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcDuration((Xbim.Ifc4x3.DateTimeResource.IfcDuration)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcIdentifier)
			{
				return new Xbim.Ifc4.MeasureResource.IfcIdentifier((Xbim.Ifc4x3.MeasureResource.IfcIdentifier)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcInteger((Xbim.Ifc4x3.MeasureResource.IfcInteger)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcLabel)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLabel((Xbim.Ifc4x3.MeasureResource.IfcLabel)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcLogical)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLogical((Xbim.Ifc4x3.MeasureResource.IfcLogical)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveInteger((Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcReal)
			{
				return new Xbim.Ifc4.MeasureResource.IfcReal((Xbim.Ifc4x3.MeasureResource.IfcReal)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcText)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText((Xbim.Ifc4x3.MeasureResource.IfcText)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.DateTimeResource.IfcTime)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTime((Xbim.Ifc4x3.DateTimeResource.IfcTime)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp)
			{
				return new Xbim.Ifc4.DateTimeResource.IfcTimeStamp((Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp)(object)DataValue);
			}
			if (DataValue is Xbim.Ifc4x3.MeasureResource.IfcURIReference)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText(((Xbim.Ifc4x3.MeasureResource.IfcURIReference)(object)DataValue).Value.ToString());
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				DataValue = null;
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
				return;
			}
			IfcAppliedValue ifcAppliedValue = value as IfcAppliedValue;
			if (ifcAppliedValue != null)
			{
				DataValue = ifcAppliedValue;
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit ifcMeasureWithUnit = value as Xbim.Ifc4x3.MeasureResource.IfcMeasureWithUnit;
			if (ifcMeasureWithUnit != null)
			{
				DataValue = ifcMeasureWithUnit;
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
				return;
			}
			IfcReference ifcReference = value as IfcReference;
			if (ifcReference != null)
			{
				DataValue = ifcReference;
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
				return;
			}
			IfcTable ifcTable = value as IfcTable;
			if (ifcTable != null)
			{
				DataValue = ifcTable;
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
				return;
			}
			Xbim.Ifc4x3.DateTimeResource.IfcTimeSeries ifcTimeSeries = value as Xbim.Ifc4x3.DateTimeResource.IfcTimeSeries;
			if (ifcTimeSeries != null)
			{
				DataValue = ifcTimeSeries;
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcAbsorbedDoseMeasure((Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcAccelerationMeasure((Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcAngularVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcAreaDensityMeasure((Xbim.Ifc4.MeasureResource.IfcAreaDensityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcCompoundPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcCurvatureMeasure((Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcDoseEquivalentMeasure((Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcDynamicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricCapacitanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricChargeMeasure((Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricConductanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricVoltageMeasure((Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcEnergyMeasure((Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcForceMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcForceMeasure((Xbim.Ifc4.MeasureResource.IfcForceMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcHeatFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcHeatingValueMeasure((Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcIlluminanceMeasure((Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcInductanceMeasure((Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcIntegerCountRateMeasure((Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcIonConcentrationMeasure((Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcIsothermalMoistureCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcKinematicViscosityMeasure((Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearForceMeasure((Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearMomentMeasure((Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcLinearVelocityMeasure((Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousFluxMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityDistributionMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcMagneticFluxMeasure((Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcMassDensityMeasure((Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcMassFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcMassPerLengthMeasure((Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfElasticityMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcModulusOfSubgradeReactionMeasure((Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcMoistureDiffusivityMeasure((Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcMolecularWeightMeasure((Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcMomentOfInertiaMeasure((Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPHMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcPHMeasure((Xbim.Ifc4.MeasureResource.IfcPHMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcPlanarForceMeasure((Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPowerMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcPowerMeasure((Xbim.Ifc4.MeasureResource.IfcPowerMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPressureMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcPressureMeasure((Xbim.Ifc4.MeasureResource.IfcPressureMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcRadioActivityMeasure((Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalFrequencyMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalMassMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcRotationalStiffnessMeasure((Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcSectionModulusMeasure((Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcSectionalAreaIntegralMeasure((Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcShearModulusMeasure((Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerLevelMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerLevelMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPowerMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureLevelMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureLevelMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcSoundPressureMeasure((Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcSpecificHeatCapacityMeasure((Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcTemperatureGradientMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcTemperatureRateOfChangeMeasure((Xbim.Ifc4.MeasureResource.IfcTemperatureRateOfChangeMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalAdmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalConductivityMeasure((Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalExpansionCoefficientMeasure((Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalResistanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcThermalTransmittanceMeasure((Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcTorqueMeasure((Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcVaporPermeabilityMeasure((Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcVolumetricFlowRateMeasure((Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcWarpingConstantMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcWarpingMomentMeasure((Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcAmountOfSubstanceMeasure((Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure((Xbim.Ifc4.MeasureResource.IfcAreaMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcComplexNumber)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcComplexNumber((Xbim.Ifc4.MeasureResource.IfcComplexNumber)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcContextDependentMeasure((Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCountMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcCountMeasure((Xbim.Ifc4.MeasureResource.IfcCountMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcElectricCurrentMeasure((Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcLuminousIntensityMeasure((Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcMassMeasure((Xbim.Ifc4.MeasureResource.IfcMassMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure((Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNumericMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcNumericMeasure((Xbim.Ifc4.MeasureResource.IfcNumericMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcParameterValue)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcParameterValue((Xbim.Ifc4.MeasureResource.IfcParameterValue)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcPositivePlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcSolidAngleMeasure((Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcThermodynamicTemperatureMeasure((Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTimeMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcTimeMeasure((Xbim.Ifc4.MeasureResource.IfcTimeMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure((Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBinary)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcBinary((Xbim.Ifc4.MeasureResource.IfcBinary)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcBoolean((Xbim.Ifc4.MeasureResource.IfcBoolean)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDate)
			{
				DataValue = new Xbim.Ifc4x3.DateTimeResource.IfcDate((Xbim.Ifc4.DateTimeResource.IfcDate)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDateTime)
			{
				DataValue = new Xbim.Ifc4x3.DateTimeResource.IfcDateTime((Xbim.Ifc4.DateTimeResource.IfcDateTime)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcDuration)
			{
				DataValue = new Xbim.Ifc4x3.DateTimeResource.IfcDuration((Xbim.Ifc4.DateTimeResource.IfcDuration)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIdentifier)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcIdentifier((Xbim.Ifc4.MeasureResource.IfcIdentifier)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInteger)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcInteger((Xbim.Ifc4.MeasureResource.IfcInteger)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLabel)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcLabel((Xbim.Ifc4.MeasureResource.IfcLabel)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLogical)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcLogical((Xbim.Ifc4.MeasureResource.IfcLogical)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveInteger)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger((Xbim.Ifc4.MeasureResource.IfcPositiveInteger)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcReal)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcReal((Xbim.Ifc4.MeasureResource.IfcReal)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcText)
			{
				DataValue = new Xbim.Ifc4x3.MeasureResource.IfcText((Xbim.Ifc4.MeasureResource.IfcText)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcTime)
			{
				DataValue = new Xbim.Ifc4x3.DateTimeResource.IfcTime((Xbim.Ifc4.DateTimeResource.IfcTime)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else
			{
				if (!(value is Xbim.Ifc4.DateTimeResource.IfcTimeStamp))
				{
					return;
				}
				DataValue = new Xbim.Ifc4x3.DateTimeResource.IfcTimeStamp((Xbim.Ifc4.DateTimeResource.IfcTimeStamp)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMetric), 11)]
	IIfcReference IIfcMetric.ReferencePath
	{
		get
		{
			return ReferencePath;
		}
		set
		{
			ReferencePath = value as IfcReference;
		}
	}

	internal IfcMetric(IModel model, int label, bool activated)
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
		case 3:
		case 4:
		case 5:
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_benchmark = (IfcBenchmarkEnum)Enum.Parse(typeof(IfcBenchmarkEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_valueSource = value.StringVal;
			break;
		case 9:
			_dataValue = (IfcMetricValueSelect)value.EntityVal;
			break;
		case 10:
			_referencePath = (IfcReference)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMetric other)
	{
		return this == other;
	}
}
