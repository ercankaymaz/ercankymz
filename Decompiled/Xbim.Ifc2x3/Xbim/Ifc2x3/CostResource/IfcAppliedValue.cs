using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.CostResource;

[ExpressType("IfcAppliedValue", 79)]
public abstract class IfcAppliedValue : PersistEntity, Xbim.Ifc2x3.PropertyResource.IfcObjectReferenceSelect, IExpressSelectType, IPersist, IPersistEntity, IEquatable<IfcAppliedValue>, IIfcAppliedValue, IfcMetricValueSelect, IIfcMetricValueSelect, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressValidatable
{
	public enum IfcAppliedValueClause
	{
		WR1
	}

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _description;

	private IfcAppliedValueSelect _appliedValue;

	private Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit _unitBasis;

	private IfcDateTimeSelect _applicableDate;

	private IfcDateTimeSelect _fixedUntilDate;

	private IIfcAppliedValueSelect _appliedValue4;

	private Xbim.Ifc4.MeasureResource.IfcLabel? _category;

	private Xbim.Ifc4.MeasureResource.IfcLabel? _condition;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Name
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? Description
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
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
	public Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit UnitBasis
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit v)
			{
				_unitBasis = v;
			}, _unitBasis, value, "UnitBasis", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcDateTimeSelect ApplicableDate
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
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateTimeSelect v)
			{
				_applicableDate = v;
			}, _applicableDate, value, "ApplicableDate", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcDateTimeSelect FixedUntilDate
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
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateTimeSelect v)
			{
				_fixedUntilDate = v;
			}, _fixedUntilDate, value, "FixedUntilDate", 6);
		}
	}

	[InverseProperty("ReferencingValues")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 7)]
	public IEnumerable<IfcReferencesValueDocument> ValuesReferenced => base.Model.Instances.Where((IfcReferencesValueDocument e) => e.ReferencingValues != null && e.ReferencingValues.Contains(this), "ReferencingValues", this);

	[InverseProperty("ComponentOfTotal")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcAppliedValueRelationship> ValueOfComponents => base.Model.Instances.Where((IfcAppliedValueRelationship e) => Equals(e.ComponentOfTotal), "ComponentOfTotal", this);

	[InverseProperty("Components")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 9)]
	public IEnumerable<IfcAppliedValueRelationship> IsComponentIn => base.Model.Instances.Where((IfcAppliedValueRelationship e) => e.Components != null && e.Components.Contains(this), "Components", this);

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
			Name = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
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
			Description = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
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
			if (AppliedValue is Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure)(object)AppliedValue);
			}
			Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit ifcMeasureWithUnit = AppliedValue as Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit;
			if (ifcMeasureWithUnit != null)
			{
				return ifcMeasureWithUnit;
			}
			if (AppliedValue is Xbim.Ifc2x3.MeasureResource.IfcMonetaryMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc2x3.MeasureResource.IfcMonetaryMeasure)(object)AppliedValue);
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
			Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit ifcMeasureWithUnit = value as Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit;
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
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAbsorbedDoseMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAccelerationMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAngularVelocityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is IfcAreaDensityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCompoundPlaneAngleMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCurvatureMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDoseEquivalentMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDynamicViscosityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCapacitanceMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricChargeMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricConductanceMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricResistanceMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricVoltageMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcEnergyMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcForceMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcFrequencyMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatFluxDensityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcHeatingValueMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIlluminanceMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInductanceMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIntegerCountRateMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIonConcentrationMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIsothermalMoistureCapacityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcKinematicViscosityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearForceMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearMomentMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearStiffnessMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLinearVelocityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityDistributionMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxDensityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMagneticFluxMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassDensityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassFlowRateMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassPerLengthMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfElasticityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfLinearSubgradeReactionMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfRotationalSubgradeReactionMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcModulusOfSubgradeReactionMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMoistureDiffusivityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMolecularWeightMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMomentOfInertiaMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)
			{
				AppliedValue = new Xbim.Ifc2x3.MeasureResource.IfcMonetaryMeasure((Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)(object)value);
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
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlanarForceMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPowerMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPressureMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRadioActivityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalFrequencyMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalMassMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRotationalStiffnessMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionModulusMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSectionalAreaIntegralMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcShearModulusMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is IfcSoundPowerLevelMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPowerMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is IfcSoundPressureLevelMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSoundPressureMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcSpecificHeatCapacityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTemperatureGradientMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is IfcTemperatureRateOfChangeMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalAdmittanceMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalConductivityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalExpansionCoefficientMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalResistanceMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermalTransmittanceMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTorqueMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVaporPermeabilityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumetricFlowRateMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingConstantMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcWarpingMomentMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAmountOfSubstanceMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcAreaMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcComplexNumber)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcContextDependentMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcCountMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcElectricCurrentMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLuminousIntensityMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcMassMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is IfcNonNegativeLengthMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNumericMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcParameterValue)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositivePlaneAngleMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				AppliedValue = new Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
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
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcTimeMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcVolumeMeasure)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is IfcBinary)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcBoolean)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is IfcDate)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is IfcDateTime)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is IfcDuration)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcIdentifier)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcInteger)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLabel)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLogical)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is IfcPositiveInteger)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcReal)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcText)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is IfcTime)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
			}
			else if (value is Xbim.Ifc4.DateTimeResource.IfcTimeStamp)
			{
				if (AppliedValue != null)
				{
					AppliedValue = null;
				}
				SetValue(delegate(IIfcAppliedValueSelect v)
				{
					_appliedValue4 = v;
				}, _appliedValue4, value, "AppliedValue", -3);
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
			UnitBasis = value as Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 5)]
	IfcDate? IIfcAppliedValue.ApplicableDate
	{
		get
		{
			return (ApplicableDate != null) ? new IfcDate(ApplicableDate.ToISODateTimeString()) : ((IfcDate)null);
		}
		set
		{
			if (!value.HasValue)
			{
				ApplicableDate = null;
				return;
			}
			DateTime date = value.Value;
			ApplicableDate = base.Model.Instances.New(delegate(IfcCalendarDate d)
			{
				d.YearComponent = date.Year;
				d.MonthComponent = date.Month;
				d.DayComponent = date.Day;
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 6)]
	IfcDate? IIfcAppliedValue.FixedUntilDate
	{
		get
		{
			return (FixedUntilDate != null) ? new IfcDate(FixedUntilDate.ToISODateTimeString()) : ((IfcDate)null);
		}
		set
		{
			if (!value.HasValue)
			{
				FixedUntilDate = null;
				return;
			}
			DateTime date = value.Value;
			FixedUntilDate = base.Model.Instances.New(delegate(IfcCalendarDate d)
			{
				d.YearComponent = date.Year;
				d.MonthComponent = date.Month;
				d.DayComponent = date.Day;
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 7)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcAppliedValue.Category
	{
		get
		{
			return _category;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLabel? v)
			{
				_category = v;
			}, _category, value, "Category", -7);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcAppliedValue.Condition
	{
		get
		{
			return _condition;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLabel? v)
			{
				_condition = v;
			}, _condition, value, "Condition", -8);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 9)]
	Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum? IIfcAppliedValue.ArithmeticOperator
	{
		get
		{
			IfcAppliedValueRelationship ifcAppliedValueRelationship = ValueOfComponents.FirstOrDefault();
			if (ifcAppliedValueRelationship == null)
			{
				return null;
			}
			return ifcAppliedValueRelationship.ArithmeticOperator switch
			{
				IfcArithmeticOperatorEnum.ADD => Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.ADD, 
				IfcArithmeticOperatorEnum.DIVIDE => Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.DIVIDE, 
				IfcArithmeticOperatorEnum.MULTIPLY => Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.MULTIPLY, 
				IfcArithmeticOperatorEnum.SUBTRACT => Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.SUBTRACT, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			if (!value.HasValue)
			{
				ValueOfComponents.ToList().ForEach(delegate(IfcAppliedValueRelationship r)
				{
					r.ComponentOfTotal = null;
				});
				return;
			}
			IfcAppliedValueRelationship ifcAppliedValueRelationship = ValueOfComponents.FirstOrDefault() ?? base.Model.Instances.New(delegate(IfcAppliedValueRelationship r)
			{
				r.ComponentOfTotal = this;
			});
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.ADD:
				ifcAppliedValueRelationship.ArithmeticOperator = IfcArithmeticOperatorEnum.ADD;
				break;
			case Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.DIVIDE:
				ifcAppliedValueRelationship.ArithmeticOperator = IfcArithmeticOperatorEnum.DIVIDE;
				break;
			case Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.MULTIPLY:
				ifcAppliedValueRelationship.ArithmeticOperator = IfcArithmeticOperatorEnum.MULTIPLY;
				break;
			case Xbim.Ifc4.Interfaces.IfcArithmeticOperatorEnum.SUBTRACT:
				ifcAppliedValueRelationship.ArithmeticOperator = IfcArithmeticOperatorEnum.SUBTRACT;
				break;
			default:
				throw new ArgumentOutOfRangeException("value", value, null);
			case null:
				break;
			}
			NotifyPropertyChanged("ArithmeticOperator");
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAppliedValue), 10)]
	IEnumerable<IIfcAppliedValue> IIfcAppliedValue.Components => ValueOfComponents.SelectMany((IfcAppliedValueRelationship relationship) => relationship.Components);

	IEnumerable<IIfcExternalReferenceRelationship> IIfcAppliedValue.HasExternalReference => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	internal IfcAppliedValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
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
			_unitBasis = (Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit)value.EntityVal;
			break;
		case 4:
			_applicableDate = (IfcDateTimeSelect)value.EntityVal;
			break;
		case 5:
			_fixedUntilDate = (IfcDateTimeSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAppliedValue other)
	{
		return this == other;
	}

	public string AsString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (Description.HasValue)
		{
			Xbim.Ifc2x3.MeasureResource.IfcText? description = Description;
			if (!string.IsNullOrEmpty(description.HasValue ? ((string)description.GetValueOrDefault()) : null))
			{
				description = Description;
				stringBuilder.Append(description.HasValue ? ((string)description.GetValueOrDefault()) : null);
				stringBuilder.Append(", ");
			}
		}
		if (AppliedValue != null)
		{
			stringBuilder.Append("AppliedValue: ");
			if (AppliedValue is Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure)
			{
				stringBuilder.Append($"{((Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure)(object)AppliedValue).Value:N2}");
			}
			if (AppliedValue is Xbim.Ifc2x3.MeasureResource.IfcMonetaryMeasure)
			{
				stringBuilder.Append($"{((Xbim.Ifc2x3.MeasureResource.IfcMonetaryMeasure)(object)AppliedValue).Value:N2}");
			}
			if (AppliedValue is Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit)
			{
				stringBuilder.Append(((Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit)AppliedValue).AsString());
			}
			stringBuilder.Append(", ");
		}
		if (UnitBasis != null)
		{
			stringBuilder.Append("UnitBase: ");
			stringBuilder.Append(UnitBasis.AsString());
			stringBuilder.Append(", ");
		}
		if (ApplicableDate != null)
		{
			stringBuilder.Append("ApplicableDate: ");
			stringBuilder.Append(ApplicableDate.AsString());
			stringBuilder.Append(", ");
		}
		if (FixedUntilDate != null)
		{
			stringBuilder.Append("FixedUntilDate: ");
			stringBuilder.Append(FixedUntilDate.AsString());
			stringBuilder.Append(", ");
		}
		if (this is IfcCostValue)
		{
			IfcCostValue ifcCostValue = (IfcCostValue)this;
			if (ifcCostValue.CostType != null)
			{
				stringBuilder.Append("CostType: ");
				stringBuilder.Append(ifcCostValue.CostType);
				stringBuilder.Append(", ");
			}
			if (ifcCostValue.Condition.HasValue)
			{
				stringBuilder.Append("Condition: ");
				Xbim.Ifc2x3.MeasureResource.IfcText? description = ifcCostValue.Condition;
				stringBuilder.Append(description.HasValue ? ((string)description.GetValueOrDefault()) : null);
				stringBuilder.Append(", ");
			}
		}
		if (this is IfcEnvironmentalImpactValue)
		{
			IfcEnvironmentalImpactValue ifcEnvironmentalImpactValue = (IfcEnvironmentalImpactValue)this;
			if (ifcEnvironmentalImpactValue.ImpactType != null)
			{
				stringBuilder.Append("ImpactType: ");
				stringBuilder.Append(ifcEnvironmentalImpactValue.ImpactType);
				stringBuilder.Append(", ");
			}
			stringBuilder.Append("Category: ");
			stringBuilder.Append(ifcEnvironmentalImpactValue.Category.ToString());
			stringBuilder.Append(", ");
			if (ifcEnvironmentalImpactValue.UserDefinedCategory.HasValue)
			{
				stringBuilder.Append("UserDefinedCategory: ");
				Xbim.Ifc2x3.MeasureResource.IfcLabel? userDefinedCategory = ifcEnvironmentalImpactValue.UserDefinedCategory;
				stringBuilder.Append(userDefinedCategory.HasValue ? ((string)userDefinedCategory.GetValueOrDefault()) : null);
				stringBuilder.Append(", ");
			}
		}
		return stringBuilder.ToString();
	}

	public bool ValidateClause(IfcAppliedValueClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcAppliedValueClause.WR1)
			{
				result = Functions.EXISTS(AppliedValue) || Functions.EXISTS(ValueOfComponents);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAppliedValue>()?.LogError($"Exception thrown evaluating where-clause 'IfcAppliedValue.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcAppliedValueClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAppliedValue.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
