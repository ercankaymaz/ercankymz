using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.PropertyResource;
using Xbim.Ifc4x3.QuantityResource;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcUnitAssignment", 245)]
public class IfcUnitAssignment : PersistEntity, IIfcUnitAssignment, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcUnitAssignment>
{
	private readonly ItemSet<IfcUnit> _units;

	[CrossSchemaAttribute(typeof(IIfcUnitAssignment), 1)]
	IItemSet<IIfcUnit> IIfcUnitAssignment.Units => new ProxyItemSet<IfcUnit, IIfcUnit>(Units);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<IfcUnit> Units
	{
		get
		{
			if (_activated)
			{
				return _units;
			}
			Activate();
			return _units;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcUnit unit in Units)
			{
				yield return unit;
			}
		}
	}

	public double LengthUnitPower
	{
		get
		{
			IfcSIUnit ifcSIUnit = Units.OfType<IfcSIUnit>().FirstOrDefault((IfcSIUnit u) => u.UnitType == IfcUnitEnum.LENGTHUNIT);
			if (ifcSIUnit != null && ifcSIUnit.Prefix.HasValue)
			{
				return ifcSIUnit.Power;
			}
			IfcConversionBasedUnit ifcConversionBasedUnit = Units.OfType<IfcConversionBasedUnit>().FirstOrDefault((IfcConversionBasedUnit u) => u.UnitType == IfcUnitEnum.LENGTHUNIT);
			if (ifcConversionBasedUnit == null)
			{
				return 1.0;
			}
			IfcMeasureWithUnit conversionFactor = ifcConversionBasedUnit.ConversionFactor;
			IfcSIUnit ifcSIUnit2 = conversionFactor.UnitComponent as IfcSIUnit;
			if (ifcSIUnit2 == null)
			{
				return 1.0;
			}
			IExpressValueType valueComponent = conversionFactor.ValueComponent;
			double num = 1.0;
			if (valueComponent.UnderlyingSystemType == typeof(double))
			{
				num = (double)valueComponent.Value;
			}
			else if (valueComponent.UnderlyingSystemType == typeof(int))
			{
				num = (int)valueComponent.Value;
			}
			else if (valueComponent.UnderlyingSystemType == typeof(long))
			{
				num = (long)valueComponent.Value;
			}
			return ifcSIUnit2.Power * num;
		}
	}

	public IfcNamedUnit AreaUnit => (IfcNamedUnit)(((object)Units.OfType<IfcSIUnit>().FirstOrDefault((IfcSIUnit u) => u.UnitType == IfcUnitEnum.AREAUNIT)) ?? ((object)Units.OfType<IfcConversionBasedUnit>().FirstOrDefault((IfcConversionBasedUnit u) => u.UnitType == IfcUnitEnum.AREAUNIT)));

	public IfcNamedUnit LengthUnit => (IfcNamedUnit)(((object)Units.OfType<IfcSIUnit>().FirstOrDefault((IfcSIUnit u) => u.UnitType == IfcUnitEnum.LENGTHUNIT)) ?? ((object)Units.OfType<IfcConversionBasedUnit>().FirstOrDefault((IfcConversionBasedUnit u) => u.UnitType == IfcUnitEnum.LENGTHUNIT)));

	public IfcNamedUnit VolumeUnit => (IfcNamedUnit)(((object)Units.OfType<IfcSIUnit>().FirstOrDefault((IfcSIUnit u) => u.UnitType == IfcUnitEnum.VOLUMEUNIT)) ?? ((object)Units.OfType<IfcConversionBasedUnit>().FirstOrDefault((IfcConversionBasedUnit u) => u.UnitType == IfcUnitEnum.VOLUMEUNIT)));

	public string LengthUnitName
	{
		get
		{
			IfcSIUnit ifcSIUnit = Units.OfType<IfcSIUnit>().FirstOrDefault((IfcSIUnit u) => u.UnitType == IfcUnitEnum.LENGTHUNIT);
			if (ifcSIUnit != null)
			{
				if (ifcSIUnit.Prefix.HasValue)
				{
					return $"{ifcSIUnit.Prefix.Value.ToString()}{ifcSIUnit.Name.ToString()}";
				}
				return ifcSIUnit.Name.ToString();
			}
			IfcConversionBasedUnit ifcConversionBasedUnit = Units.OfType<IfcConversionBasedUnit>().FirstOrDefault((IfcConversionBasedUnit u) => u.UnitType == IfcUnitEnum.LENGTHUNIT);
			if (ifcConversionBasedUnit != null)
			{
				return ifcConversionBasedUnit.Name;
			}
			IfcConversionBasedUnit ifcConversionBasedUnit2 = Units.OfType<IfcConversionBasedUnit>().FirstOrDefault((IfcConversionBasedUnit u) => u.UnitType == IfcUnitEnum.LENGTHUNIT);
			if (ifcConversionBasedUnit2 != null)
			{
				return ifcConversionBasedUnit2.Name;
			}
			return "";
		}
	}

	internal IfcUnitAssignment(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_units = new ItemSet<IfcUnit>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_units.InternalAdd((IfcUnit)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcUnitAssignment other)
	{
		return this == other;
	}

	public double Power(IfcUnitEnum unitType)
	{
		IfcSIUnit ifcSIUnit = Units.OfType<IfcSIUnit>().FirstOrDefault((IfcSIUnit u) => u.UnitType == unitType);
		if (ifcSIUnit != null && ifcSIUnit.Prefix.HasValue)
		{
			return ifcSIUnit.Power;
		}
		IfcConversionBasedUnit ifcConversionBasedUnit = Units.OfType<IfcConversionBasedUnit>().FirstOrDefault((IfcConversionBasedUnit u) => u.UnitType == unitType);
		if (ifcConversionBasedUnit == null)
		{
			return 1.0;
		}
		IfcMeasureWithUnit conversionFactor = ifcConversionBasedUnit.ConversionFactor;
		IfcSIUnit ifcSIUnit2 = conversionFactor.UnitComponent as IfcSIUnit;
		if (ifcSIUnit2 == null)
		{
			return 1.0;
		}
		IExpressValueType valueComponent = conversionFactor.ValueComponent;
		double num = 1.0;
		if (valueComponent.UnderlyingSystemType == typeof(double))
		{
			num = (double)valueComponent.Value;
		}
		else if (valueComponent.UnderlyingSystemType == typeof(int))
		{
			num = (int)valueComponent.Value;
		}
		else if (valueComponent.UnderlyingSystemType == typeof(long))
		{
			num = (long)valueComponent.Value;
		}
		return ifcSIUnit2.Power * num;
	}

	public bool SetSiLengthUnits(IfcSIUnitName siUnitName, IfcSIPrefix? siPrefix)
	{
		IfcSIUnit ifcSIUnit = Units.OfType<IfcSIUnit>().FirstOrDefault((IfcSIUnit u) => u.UnitType == IfcUnitEnum.LENGTHUNIT);
		if (ifcSIUnit != null)
		{
			ifcSIUnit.Prefix = siPrefix;
			ifcSIUnit.Name = siUnitName;
			return true;
		}
		return false;
	}

	public void SetOrChangeSiUnit(IfcUnitEnum unitType, IfcSIUnitName siUnitName, IfcSIPrefix? siUnitPrefix)
	{
		IModel model = base.Model;
		IfcSIUnit ifcSIUnit = Units.OfType<IfcSIUnit>().FirstOrDefault((IfcSIUnit u) => u.UnitType == unitType);
		if (ifcSIUnit != null)
		{
			ifcSIUnit.Prefix = siUnitPrefix;
			ifcSIUnit.Name = siUnitName;
			return;
		}
		Units.Add(model.Instances.New(delegate(IfcSIUnit s)
		{
			s.UnitType = unitType;
			s.Name = siUnitName;
			s.Prefix = siUnitPrefix;
		}));
	}

	public IfcNamedUnit GetUnitFor(IfcPropertySingleValue property)
	{
		if (property.Unit != null)
		{
			return (IfcNamedUnit)property.Unit;
		}
		IfcUnitEnum? requiredUnit;
		if (property.NominalValue is IfcVolumeMeasure)
		{
			requiredUnit = IfcUnitEnum.VOLUMEUNIT;
		}
		else if (property.NominalValue is IfcAreaMeasure)
		{
			requiredUnit = IfcUnitEnum.AREAUNIT;
		}
		else if (property.NominalValue is IfcLengthMeasure)
		{
			requiredUnit = IfcUnitEnum.LENGTHUNIT;
		}
		else if (property.NominalValue is IfcPositiveLengthMeasure)
		{
			requiredUnit = IfcUnitEnum.LENGTHUNIT;
		}
		else if (property.NominalValue is IfcNonNegativeLengthMeasure)
		{
			requiredUnit = IfcUnitEnum.LENGTHUNIT;
		}
		else if (property.NominalValue is IfcAmountOfSubstanceMeasure)
		{
			requiredUnit = IfcUnitEnum.AMOUNTOFSUBSTANCEUNIT;
		}
		else if (property.NominalValue is IfcContextDependentMeasure)
		{
			requiredUnit = null;
		}
		else if (property.NominalValue is IfcCountMeasure)
		{
			requiredUnit = null;
		}
		else if (property.NominalValue is IfcDescriptiveMeasure)
		{
			requiredUnit = null;
		}
		else if (property.NominalValue is IfcElectricCurrentMeasure)
		{
			requiredUnit = IfcUnitEnum.ELECTRICCURRENTUNIT;
		}
		else if (property.NominalValue is IfcLuminousIntensityMeasure)
		{
			requiredUnit = IfcUnitEnum.LUMINOUSINTENSITYUNIT;
		}
		else if (property.NominalValue is IfcMassMeasure)
		{
			requiredUnit = IfcUnitEnum.MASSUNIT;
		}
		else if (property.NominalValue is IfcNormalisedRatioMeasure)
		{
			requiredUnit = null;
		}
		else if (property.NominalValue is IfcNumericMeasure)
		{
			requiredUnit = null;
		}
		else if (property.NominalValue is IfcParameterValue)
		{
			requiredUnit = null;
		}
		else if (property.NominalValue is IfcPlaneAngleMeasure)
		{
			requiredUnit = IfcUnitEnum.PLANEANGLEUNIT;
		}
		else if (property.NominalValue is IfcPositiveRatioMeasure)
		{
			requiredUnit = null;
		}
		else if (property.NominalValue is IfcPositivePlaneAngleMeasure)
		{
			requiredUnit = IfcUnitEnum.PLANEANGLEUNIT;
		}
		else if (property.NominalValue is IfcRatioMeasure)
		{
			requiredUnit = null;
		}
		else if (property.NominalValue is IfcSolidAngleMeasure)
		{
			requiredUnit = IfcUnitEnum.SOLIDANGLEUNIT;
		}
		else if (property.NominalValue is IfcThermodynamicTemperatureMeasure)
		{
			requiredUnit = IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT;
		}
		else if (property.NominalValue is IfcTimeMeasure)
		{
			requiredUnit = IfcUnitEnum.TIMEUNIT;
		}
		else if (property.NominalValue is IfcComplexNumber)
		{
			requiredUnit = null;
		}
		else if (property.NominalValue is IfcSimpleValue)
		{
			requiredUnit = null;
		}
		else
		{
			requiredUnit = null;
		}
		if (!requiredUnit.HasValue)
		{
			return null;
		}
		return (IfcNamedUnit)(((object)Units.OfType<IfcSIUnit>().FirstOrDefault((IfcSIUnit u) => u.UnitType == requiredUnit.Value)) ?? ((object)Units.OfType<IfcConversionBasedUnit>().FirstOrDefault((IfcConversionBasedUnit u) => u.UnitType == requiredUnit.Value)));
	}

	public IfcNamedUnit GetUnitFor(IfcPhysicalSimpleQuantity quantity)
	{
		if (quantity.Unit != null)
		{
			return quantity.Unit;
		}
		IfcUnitEnum? requiredUnit = null;
		if (quantity is IfcQuantityLength)
		{
			requiredUnit = IfcUnitEnum.LENGTHUNIT;
		}
		else if (quantity is IfcQuantityArea)
		{
			requiredUnit = IfcUnitEnum.AREAUNIT;
		}
		else if (quantity is IfcQuantityVolume)
		{
			requiredUnit = IfcUnitEnum.VOLUMEUNIT;
		}
		else
		{
			if (quantity is IfcQuantityCount)
			{
				return null;
			}
			if (quantity is IfcQuantityWeight)
			{
				requiredUnit = IfcUnitEnum.MASSUNIT;
			}
			else if (quantity is IfcQuantityTime)
			{
				requiredUnit = IfcUnitEnum.TIMEUNIT;
			}
			else if (quantity is IfcQuantityNumber)
			{
				requiredUnit = null;
			}
		}
		if (!requiredUnit.HasValue)
		{
			return null;
		}
		return (IfcNamedUnit)(((object)Units.OfType<IfcSIUnit>().FirstOrDefault((IfcSIUnit u) => u.UnitType == requiredUnit.Value)) ?? ((object)Units.OfType<IfcConversionBasedUnit>().FirstOrDefault((IfcConversionBasedUnit u) => u.UnitType == requiredUnit.Value)));
	}

	public void SetOrChangeConversionUnit(IfcUnitEnum unitType, ConversionBasedUnit unit)
	{
		IfcSIUnit ifcSIUnit = Units.OfType<IfcSIUnit>().FirstOrDefault((IfcSIUnit u) => u.UnitType == unitType);
		if (ifcSIUnit != null)
		{
			Units.Remove(ifcSIUnit);
			try
			{
				base.Model.Delete(ifcSIUnit);
			}
			catch (Exception)
			{
			}
		}
		Units.Add(GetNewConversionUnit(base.Model, unitType, unit));
	}

	private static IfcConversionBasedUnit GetNewConversionUnit(IModel model, IfcUnitEnum unitType, ConversionBasedUnit unitEnum)
	{
		IfcConversionBasedUnit ifcConversionBasedUnit = model.Instances.New<IfcConversionBasedUnit>();
		ifcConversionBasedUnit.UnitType = unitType;
		switch (unitEnum)
		{
		case ConversionBasedUnit.Inch:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "inch", 25.4, IfcUnitEnum.LENGTHUNIT, IfcSIUnitName.METRE, IfcSIPrefix.MILLI, GetLengthDimension(model));
			break;
		case ConversionBasedUnit.Foot:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "foot", 304.8, IfcUnitEnum.LENGTHUNIT, IfcSIUnitName.METRE, IfcSIPrefix.MILLI, GetLengthDimension(model));
			break;
		case ConversionBasedUnit.Yard:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "yard", 914.0, IfcUnitEnum.LENGTHUNIT, IfcSIUnitName.METRE, IfcSIPrefix.MILLI, GetLengthDimension(model));
			break;
		case ConversionBasedUnit.Mile:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "mile", 1609.0, IfcUnitEnum.LENGTHUNIT, IfcSIUnitName.METRE, null, GetLengthDimension(model));
			break;
		case ConversionBasedUnit.Acre:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "acre", 4046.86, IfcUnitEnum.AREAUNIT, IfcSIUnitName.SQUARE_METRE, null, GetAreaDimension(model));
			break;
		case ConversionBasedUnit.Litre:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "litre", 0.001, IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.CUBIC_METRE, null, GetVolumeDimension(model));
			break;
		case ConversionBasedUnit.PintUk:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "pint UK", 0.000568, IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.CUBIC_METRE, null, GetVolumeDimension(model));
			break;
		case ConversionBasedUnit.PintUs:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "pint US", 0.000473, IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.CUBIC_METRE, null, GetVolumeDimension(model));
			break;
		case ConversionBasedUnit.GallonUk:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "gallon UK", 0.004546, IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.CUBIC_METRE, null, GetVolumeDimension(model));
			break;
		case ConversionBasedUnit.GallonUs:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "gallon US", 0.003785, IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.CUBIC_METRE, null, GetVolumeDimension(model));
			break;
		case ConversionBasedUnit.Ounce:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "ounce", 28.35, IfcUnitEnum.MASSUNIT, IfcSIUnitName.GRAM, null, GetMassDimension(model));
			break;
		case ConversionBasedUnit.Pound:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "pound", 0.454, IfcUnitEnum.MASSUNIT, IfcSIUnitName.GRAM, IfcSIPrefix.KILO, GetMassDimension(model));
			break;
		case ConversionBasedUnit.SquareFoot:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "square foot", 92903.04, IfcUnitEnum.AREAUNIT, IfcSIUnitName.METRE, IfcSIPrefix.MILLI, GetAreaDimension(model));
			break;
		case ConversionBasedUnit.CubicFoot:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "cubic foot", 28316846.6, IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.METRE, IfcSIPrefix.MILLI, GetVolumeDimension(model));
			break;
		}
		return ifcConversionBasedUnit;
	}

	private static void SetConversionUnitsParameters(IModel model, IfcConversionBasedUnit unit, IfcLabel name, IfcRatioMeasure ratio, IfcUnitEnum unitType, IfcSIUnitName siUnitName, IfcSIPrefix? siUnitPrefix, IfcDimensionalExponents dimensions)
	{
		unit.Name = name;
		unit.ConversionFactor = model.Instances.New<IfcMeasureWithUnit>();
		unit.ConversionFactor.ValueComponent = ratio;
		unit.ConversionFactor.UnitComponent = model.Instances.New(delegate(IfcSIUnit s)
		{
			s.UnitType = unitType;
			s.Name = siUnitName;
			s.Prefix = siUnitPrefix;
		});
		unit.Dimensions = dimensions;
	}

	private static IfcDimensionalExponents GetLengthDimension(IModel model)
	{
		IfcDimensionalExponents ifcDimensionalExponents = model.Instances.New<IfcDimensionalExponents>();
		ifcDimensionalExponents.AmountOfSubstanceExponent = 0L;
		ifcDimensionalExponents.ElectricCurrentExponent = 0L;
		ifcDimensionalExponents.LengthExponent = 1L;
		ifcDimensionalExponents.LuminousIntensityExponent = 0L;
		ifcDimensionalExponents.MassExponent = 0L;
		ifcDimensionalExponents.ThermodynamicTemperatureExponent = 0L;
		ifcDimensionalExponents.TimeExponent = 0L;
		return ifcDimensionalExponents;
	}

	private static IfcDimensionalExponents GetVolumeDimension(IModel model)
	{
		IfcDimensionalExponents ifcDimensionalExponents = model.Instances.New<IfcDimensionalExponents>();
		ifcDimensionalExponents.AmountOfSubstanceExponent = 0L;
		ifcDimensionalExponents.ElectricCurrentExponent = 0L;
		ifcDimensionalExponents.LengthExponent = 3L;
		ifcDimensionalExponents.LuminousIntensityExponent = 0L;
		ifcDimensionalExponents.MassExponent = 0L;
		ifcDimensionalExponents.ThermodynamicTemperatureExponent = 0L;
		ifcDimensionalExponents.TimeExponent = 0L;
		return ifcDimensionalExponents;
	}

	private static IfcDimensionalExponents GetAreaDimension(IModel model)
	{
		IfcDimensionalExponents ifcDimensionalExponents = model.Instances.New<IfcDimensionalExponents>();
		ifcDimensionalExponents.AmountOfSubstanceExponent = 0L;
		ifcDimensionalExponents.ElectricCurrentExponent = 0L;
		ifcDimensionalExponents.LengthExponent = 2L;
		ifcDimensionalExponents.LuminousIntensityExponent = 0L;
		ifcDimensionalExponents.MassExponent = 0L;
		ifcDimensionalExponents.ThermodynamicTemperatureExponent = 0L;
		ifcDimensionalExponents.TimeExponent = 0L;
		return ifcDimensionalExponents;
	}

	private static IfcDimensionalExponents GetMassDimension(IModel model)
	{
		IfcDimensionalExponents ifcDimensionalExponents = model.Instances.New<IfcDimensionalExponents>();
		ifcDimensionalExponents.AmountOfSubstanceExponent = 0L;
		ifcDimensionalExponents.ElectricCurrentExponent = 0L;
		ifcDimensionalExponents.LengthExponent = 0L;
		ifcDimensionalExponents.LuminousIntensityExponent = 0L;
		ifcDimensionalExponents.MassExponent = 1L;
		ifcDimensionalExponents.ThermodynamicTemperatureExponent = 0L;
		ifcDimensionalExponents.TimeExponent = 0L;
		return ifcDimensionalExponents;
	}
}
