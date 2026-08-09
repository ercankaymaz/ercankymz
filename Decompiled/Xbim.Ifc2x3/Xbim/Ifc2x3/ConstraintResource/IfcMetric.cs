using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.CostResource;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.TimeSeriesResource;
using Xbim.Ifc2x3.UtilityResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ConstraintResource;

[ExpressType("IfcMetric", 80)]
public class IfcMetric : IfcConstraint, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcMetric>, IIfcMetric, IIfcConstraint, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	private IfcBenchmarkEnum _benchmark;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _valueSource;

	private IfcMetricValueSelect _dataValue;

	private IIfcMetricValueSelect _dataValue4;

	private IIfcReference _referencePath;

	private Xbim.Ifc4.Interfaces.IfcBenchmarkEnum? _benchmark4;

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 14)]
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? ValueSource
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_valueSource = v;
			}, _valueSource, value, "ValueSource", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 16)]
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

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.CreatingActor != null)
			{
				yield return base.CreatingActor;
			}
			if (base.CreationTime != null)
			{
				yield return base.CreationTime;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMetric), 8)]
	Xbim.Ifc4.Interfaces.IfcBenchmarkEnum IIfcMetric.Benchmark
	{
		get
		{
			if (_benchmark4.HasValue)
			{
				return _benchmark4.Value;
			}
			return Benchmark switch
			{
				IfcBenchmarkEnum.GREATERTHAN => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.GREATERTHAN, 
				IfcBenchmarkEnum.GREATERTHANOREQUALTO => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.GREATERTHANOREQUALTO, 
				IfcBenchmarkEnum.LESSTHAN => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.LESSTHAN, 
				IfcBenchmarkEnum.LESSTHANOREQUALTO => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.LESSTHANOREQUALTO, 
				IfcBenchmarkEnum.EQUALTO => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.EQUALTO, 
				IfcBenchmarkEnum.NOTEQUALTO => Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.NOTEQUALTO, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			if (_benchmark4.HasValue && (int)value < 6)
			{
				SetValue(delegate(Xbim.Ifc4.Interfaces.IfcBenchmarkEnum? v)
				{
					_benchmark4 = v;
				}, _benchmark4, null, "Benchmark", -8);
			}
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
				SetValue(delegate(Xbim.Ifc4.Interfaces.IfcBenchmarkEnum? v)
				{
					_benchmark4 = v;
				}, _benchmark4, value, "Benchmark", -8);
				break;
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.NOTINCLUDES:
				SetValue(delegate(Xbim.Ifc4.Interfaces.IfcBenchmarkEnum? v)
				{
					_benchmark4 = v;
				}, _benchmark4, value, "Benchmark", -8);
				break;
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.INCLUDEDIN:
				SetValue(delegate(Xbim.Ifc4.Interfaces.IfcBenchmarkEnum? v)
				{
					_benchmark4 = v;
				}, _benchmark4, value, "Benchmark", -8);
				break;
			case Xbim.Ifc4.Interfaces.IfcBenchmarkEnum.NOTINCLUDEDIN:
				SetValue(delegate(Xbim.Ifc4.Interfaces.IfcBenchmarkEnum? v)
				{
					_benchmark4 = v;
				}, _benchmark4, value, "Benchmark", -8);
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
			ValueSource = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
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
			IfcCalendarDate ifcCalendarDate = DataValue as IfcCalendarDate;
			if (ifcCalendarDate != null)
			{
				return new IfcDate(ifcCalendarDate.ToISODateTimeString());
			}
			IfcLocalTime ifcLocalTime = DataValue as IfcLocalTime;
			if (ifcLocalTime != null)
			{
				return new IfcTime(ifcLocalTime.ToISODateTimeString());
			}
			IfcDateAndTime ifcDateAndTime = DataValue as IfcDateAndTime;
			if (ifcDateAndTime != null)
			{
				return new IfcDateTime(ifcDateAndTime.ToISODateTimeString());
			}
			Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit ifcMeasureWithUnit = DataValue as Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit;
			if (ifcMeasureWithUnit != null)
			{
				return ifcMeasureWithUnit;
			}
			IfcTable ifcTable = DataValue as IfcTable;
			if (ifcTable != null)
			{
				return ifcTable;
			}
			if (DataValue is Xbim.Ifc2x3.MeasureResource.IfcText)
			{
				return new Xbim.Ifc4.MeasureResource.IfcText((Xbim.Ifc2x3.MeasureResource.IfcText)(object)DataValue);
			}
			Xbim.Ifc2x3.TimeSeriesResource.IfcTimeSeries ifcTimeSeries = DataValue as Xbim.Ifc2x3.TimeSeriesResource.IfcTimeSeries;
			if (ifcTimeSeries != null)
			{
				return ifcTimeSeries;
			}
			IfcCostValue ifcCostValue = DataValue as IfcCostValue;
			if (ifcCostValue != null)
			{
				return ifcCostValue;
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
			if (value as IfcAppliedValue != null)
			{
				IfcCostValue ifcCostValue = value as IfcCostValue;
				if (ifcCostValue != null)
				{
					DataValue = ifcCostValue;
					if (_dataValue4 != null)
					{
						SetValue(delegate(IIfcMetricValueSelect v)
						{
							_dataValue4 = v;
						}, _dataValue4, null, "DataValue", -10);
					}
				}
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
				return;
			}
			Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit ifcMeasureWithUnit = value as Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit;
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
			Xbim.Ifc2x3.TimeSeriesResource.IfcTimeSeries ifcTimeSeries = value as Xbim.Ifc2x3.TimeSeriesResource.IfcTimeSeries;
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
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is IfcAreaDensityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcForceMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPHMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPowerMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPressureMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is IfcSoundPowerLevelMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is IfcSoundPressureLevelMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is IfcTemperatureRateOfChangeMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcComplexNumber)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCountMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is IfcNonNegativeLengthMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNumericMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcParameterValue)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSolidAngleMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTimeMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is IfcBinary)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is IfcDate)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is IfcDateTime)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is IfcDuration)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIdentifier)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInteger)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLabel)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLogical)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is IfcPositiveInteger)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcReal)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcText)
			{
				DataValue = new Xbim.Ifc2x3.MeasureResource.IfcText((Xbim.Ifc4.MeasureResource.IfcText)(object)value);
				if (_dataValue4 != null)
				{
					SetValue(delegate(IIfcMetricValueSelect v)
					{
						_dataValue4 = v;
					}, _dataValue4, null, "DataValue", -10);
				}
			}
			else if (value is IfcTime)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcTimeStamp)
			{
				if (DataValue != null)
				{
					DataValue = null;
				}
				SetValue(delegate(IIfcMetricValueSelect v)
				{
					_dataValue4 = v;
				}, _dataValue4, value, "DataValue", -10);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMetric), 11)]
	IIfcReference IIfcMetric.ReferencePath
	{
		get
		{
			return _referencePath;
		}
		set
		{
			SetValue(delegate(IIfcReference v)
			{
				_referencePath = v;
			}, _referencePath, value, "ReferencePath", -11);
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
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMetric other)
	{
		return this == other;
	}
}
