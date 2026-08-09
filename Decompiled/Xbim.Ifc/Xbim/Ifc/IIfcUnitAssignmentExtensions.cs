using System;
using System.Linq;
using Xbim.Common;
using Xbim.Ifc2x3.QuantityResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.QuantityResource;
using Xbim.Ifc4x3.QuantityResource;

namespace Xbim.Ifc;

public static class IIfcUnitAssignmentExtensions
{
	public static double Power(this IIfcUnitAssignment obj, IfcUnitEnum unitType)
	{
		IIfcSIUnit ifcSIUnit = obj.Units.OfType<IIfcSIUnit>().FirstOrDefault((IIfcSIUnit u) => u.UnitType == unitType);
		if (ifcSIUnit != null && ifcSIUnit.Prefix.HasValue)
		{
			return ifcSIUnit.Power;
		}
		IIfcConversionBasedUnit ifcConversionBasedUnit = obj.Units.OfType<IIfcConversionBasedUnit>().FirstOrDefault((IIfcConversionBasedUnit u) => u.UnitType == unitType);
		if (ifcConversionBasedUnit == null)
		{
			return 1.0;
		}
		IIfcMeasureWithUnit conversionFactor = ifcConversionBasedUnit.ConversionFactor;
		if (!(conversionFactor.UnitComponent is IIfcSIUnit ifcSIUnit2))
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

	public static bool SetSiLengthUnits(this IIfcUnitAssignment obj, IfcSIUnitName siUnitName, IfcSIPrefix? siPrefix)
	{
		IIfcSIUnit ifcSIUnit = obj.Units.OfType<IIfcSIUnit>().FirstOrDefault((IIfcSIUnit u) => u.UnitType == IfcUnitEnum.LENGTHUNIT);
		if (ifcSIUnit != null)
		{
			ifcSIUnit.Prefix = siPrefix;
			ifcSIUnit.Name = siUnitName;
			return true;
		}
		return false;
	}

	public static void SetOrChangeSiUnit(this IIfcUnitAssignment obj, IfcUnitEnum unitType, IfcSIUnitName siUnitName, IfcSIPrefix? siUnitPrefix)
	{
		IModel model = obj.Model;
		IIfcSIUnit ifcSIUnit = obj.Units.OfType<IIfcSIUnit>().FirstOrDefault((IIfcSIUnit u) => u.UnitType == unitType);
		if (ifcSIUnit != null)
		{
			ifcSIUnit.Prefix = siUnitPrefix;
			ifcSIUnit.Name = siUnitName;
			return;
		}
		EntityCreator entityCreator = new EntityCreator(model);
		obj.Units.Add(entityCreator.SIUnit(delegate(IIfcSIUnit s)
		{
			s.UnitType = unitType;
			s.Name = siUnitName;
			s.Prefix = siUnitPrefix;
		}));
	}

	public static IIfcNamedUnit GetUnitFor(this IIfcUnitAssignment obj, IIfcPropertySingleValue property)
	{
		if (property.Unit != null)
		{
			return (IIfcNamedUnit)property.Unit;
		}
		IIfcValue nominalValue = property.NominalValue;
		IfcUnitEnum? ifcUnitEnum = ((nominalValue is IfcVolumeMeasure) ? new IfcUnitEnum?(IfcUnitEnum.VOLUMEUNIT) : ((nominalValue is IfcAreaMeasure) ? new IfcUnitEnum?(IfcUnitEnum.AREAUNIT) : ((nominalValue is IfcLengthMeasure) ? new IfcUnitEnum?(IfcUnitEnum.LENGTHUNIT) : ((nominalValue is IfcPositiveLengthMeasure) ? new IfcUnitEnum?(IfcUnitEnum.LENGTHUNIT) : ((nominalValue is IfcNonNegativeLengthMeasure) ? new IfcUnitEnum?(IfcUnitEnum.LENGTHUNIT) : ((nominalValue is IfcAmountOfSubstanceMeasure) ? new IfcUnitEnum?(IfcUnitEnum.AMOUNTOFSUBSTANCEUNIT) : ((nominalValue is IfcElectricCurrentMeasure) ? new IfcUnitEnum?(IfcUnitEnum.ELECTRICCURRENTUNIT) : ((nominalValue is IfcLuminousIntensityMeasure) ? new IfcUnitEnum?(IfcUnitEnum.LUMINOUSINTENSITYUNIT) : ((nominalValue is IfcMassMeasure) ? new IfcUnitEnum?(IfcUnitEnum.MASSUNIT) : ((nominalValue is IfcPlaneAngleMeasure) ? new IfcUnitEnum?(IfcUnitEnum.PLANEANGLEUNIT) : ((nominalValue is IfcPositivePlaneAngleMeasure) ? new IfcUnitEnum?(IfcUnitEnum.PLANEANGLEUNIT) : ((nominalValue is IfcThermodynamicTemperatureMeasure) ? new IfcUnitEnum?(IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT) : ((nominalValue is IfcSolidAngleMeasure) ? new IfcUnitEnum?(IfcUnitEnum.SOLIDANGLEUNIT) : ((nominalValue is IfcTimeMeasure) ? new IfcUnitEnum?(IfcUnitEnum.TIMEUNIT) : ((nominalValue is IfcContextDependentMeasure) ? ((IfcUnitEnum?)null) : ((nominalValue is IfcCountMeasure) ? ((IfcUnitEnum?)null) : ((nominalValue is IfcDescriptiveMeasure) ? ((IfcUnitEnum?)null) : ((nominalValue is IfcNormalisedRatioMeasure) ? ((IfcUnitEnum?)null) : ((nominalValue is IfcNumericMeasure) ? ((IfcUnitEnum?)null) : ((nominalValue is IfcParameterValue) ? ((IfcUnitEnum?)null) : ((nominalValue is IfcPositiveRatioMeasure) ? ((IfcUnitEnum?)null) : ((nominalValue is IfcRatioMeasure) ? ((IfcUnitEnum?)null) : ((nominalValue is IfcComplexNumber) ? ((IfcUnitEnum?)null) : ((!(nominalValue is IfcSimpleValue)) ? ((IfcUnitEnum?)null) : ((IfcUnitEnum?)null)))))))))))))))))))))))));
		IfcUnitEnum? requiredUnit = ifcUnitEnum;
		if (!requiredUnit.HasValue)
		{
			return null;
		}
		IIfcNamedUnit ifcNamedUnit = obj.Units.OfType<IIfcSIUnit>().FirstOrDefault((IIfcSIUnit u) => u.UnitType == requiredUnit.Value);
		return ifcNamedUnit ?? obj.Units.OfType<IIfcConversionBasedUnit>().FirstOrDefault((IIfcConversionBasedUnit u) => u.UnitType == requiredUnit.Value);
	}

	public static IIfcNamedUnit GetUnitFor(this IIfcUnitAssignment obj, IIfcPhysicalSimpleQuantity quantity)
	{
		if (quantity.Unit != null)
		{
			return quantity.Unit;
		}
		IfcUnitEnum? ifcUnitEnum = ((quantity is Xbim.Ifc2x3.QuantityResource.IfcQuantityLength) ? new IfcUnitEnum?(IfcUnitEnum.LENGTHUNIT) : ((quantity is Xbim.Ifc2x3.QuantityResource.IfcQuantityArea) ? new IfcUnitEnum?(IfcUnitEnum.AREAUNIT) : ((quantity is Xbim.Ifc2x3.QuantityResource.IfcQuantityVolume) ? new IfcUnitEnum?(IfcUnitEnum.VOLUMEUNIT) : ((quantity is Xbim.Ifc2x3.QuantityResource.IfcQuantityCount) ? ((IfcUnitEnum?)null) : ((quantity is Xbim.Ifc2x3.QuantityResource.IfcQuantityWeight) ? new IfcUnitEnum?(IfcUnitEnum.MASSUNIT) : ((quantity is Xbim.Ifc2x3.QuantityResource.IfcQuantityTime) ? new IfcUnitEnum?(IfcUnitEnum.TIMEUNIT) : ((quantity is Xbim.Ifc4.QuantityResource.IfcQuantityLength) ? new IfcUnitEnum?(IfcUnitEnum.LENGTHUNIT) : ((quantity is Xbim.Ifc4.QuantityResource.IfcQuantityArea) ? new IfcUnitEnum?(IfcUnitEnum.AREAUNIT) : ((quantity is Xbim.Ifc4.QuantityResource.IfcQuantityVolume) ? new IfcUnitEnum?(IfcUnitEnum.VOLUMEUNIT) : ((quantity is Xbim.Ifc4.QuantityResource.IfcQuantityCount) ? ((IfcUnitEnum?)null) : ((quantity is Xbim.Ifc4.QuantityResource.IfcQuantityWeight) ? new IfcUnitEnum?(IfcUnitEnum.MASSUNIT) : ((quantity is Xbim.Ifc4.QuantityResource.IfcQuantityTime) ? new IfcUnitEnum?(IfcUnitEnum.TIMEUNIT) : ((quantity is Xbim.Ifc4x3.QuantityResource.IfcQuantityLength) ? new IfcUnitEnum?(IfcUnitEnum.LENGTHUNIT) : ((quantity is Xbim.Ifc4x3.QuantityResource.IfcQuantityArea) ? new IfcUnitEnum?(IfcUnitEnum.AREAUNIT) : ((quantity is Xbim.Ifc4x3.QuantityResource.IfcQuantityVolume) ? new IfcUnitEnum?(IfcUnitEnum.VOLUMEUNIT) : ((quantity is Xbim.Ifc4x3.QuantityResource.IfcQuantityCount) ? ((IfcUnitEnum?)null) : ((quantity is IfcQuantityNumber) ? ((IfcUnitEnum?)null) : ((quantity is Xbim.Ifc4x3.QuantityResource.IfcQuantityWeight) ? new IfcUnitEnum?(IfcUnitEnum.MASSUNIT) : ((!(quantity is Xbim.Ifc4x3.QuantityResource.IfcQuantityTime)) ? ((IfcUnitEnum?)null) : new IfcUnitEnum?(IfcUnitEnum.TIMEUNIT))))))))))))))))))));
		IfcUnitEnum? requiredUnit = ifcUnitEnum;
		if (!requiredUnit.HasValue)
		{
			return null;
		}
		IIfcNamedUnit ifcNamedUnit = obj.Units.OfType<IIfcSIUnit>().FirstOrDefault((IIfcSIUnit u) => u.UnitType == requiredUnit.Value);
		return ifcNamedUnit ?? obj.Units.OfType<IIfcConversionBasedUnit>().FirstOrDefault((IIfcConversionBasedUnit u) => u.UnitType == requiredUnit.Value);
	}

	public static IIfcNamedUnit GetUnitFor(this IIfcUnitAssignment obj, IfcUnitEnum unitType)
	{
		IIfcNamedUnit ifcNamedUnit = obj.Units.OfType<IIfcSIUnit>().FirstOrDefault((IIfcSIUnit u) => u.UnitType == unitType);
		return ifcNamedUnit ?? obj.Units.OfType<IIfcConversionBasedUnit>().FirstOrDefault((IIfcConversionBasedUnit u) => u.UnitType == unitType);
	}

	public static void SetOrChangeConversionUnit(this IIfcUnitAssignment obj, IfcUnitEnum unitType, ConversionBasedUnit unit)
	{
		IIfcSIUnit ifcSIUnit = obj.Units.OfType<IIfcSIUnit>().FirstOrDefault((IIfcSIUnit u) => u.UnitType == unitType);
		if (ifcSIUnit != null)
		{
			obj.Units.Remove(ifcSIUnit);
			try
			{
				obj.Model.Delete(ifcSIUnit);
			}
			catch (Exception)
			{
			}
		}
		obj.Units.Add(GetNewConversionUnit(obj.Model, unitType, unit));
	}

	private static IIfcConversionBasedUnit GetNewConversionUnit(IModel model, IfcUnitEnum unitType, ConversionBasedUnit unitEnum)
	{
		EntityCreator entityCreator = new EntityCreator(model);
		IIfcConversionBasedUnit ifcConversionBasedUnit = entityCreator.ConversionBasedUnit();
		ifcConversionBasedUnit.UnitType = unitType;
		switch (unitEnum)
		{
		case ConversionBasedUnit.Inch:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "inch", 25.4, IfcUnitEnum.LENGTHUNIT, IfcSIUnitName.METRE, IfcSIPrefix.MILLI, GetLengthDimension(entityCreator));
			break;
		case ConversionBasedUnit.Foot:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "foot", 304.8, IfcUnitEnum.LENGTHUNIT, IfcSIUnitName.METRE, IfcSIPrefix.MILLI, GetLengthDimension(entityCreator));
			break;
		case ConversionBasedUnit.Yard:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "yard", 914.0, IfcUnitEnum.LENGTHUNIT, IfcSIUnitName.METRE, IfcSIPrefix.MILLI, GetLengthDimension(entityCreator));
			break;
		case ConversionBasedUnit.Mile:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "mile", 1609.0, IfcUnitEnum.LENGTHUNIT, IfcSIUnitName.METRE, null, GetLengthDimension(entityCreator));
			break;
		case ConversionBasedUnit.Acre:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "acre", 4046.86, IfcUnitEnum.AREAUNIT, IfcSIUnitName.SQUARE_METRE, null, GetAreaDimension(entityCreator));
			break;
		case ConversionBasedUnit.Litre:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "litre", 0.001, IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.CUBIC_METRE, null, GetVolumeDimension(entityCreator));
			break;
		case ConversionBasedUnit.PintUk:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "pint UK", 0.000568, IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.CUBIC_METRE, null, GetVolumeDimension(entityCreator));
			break;
		case ConversionBasedUnit.PintUs:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "pint US", 0.000473, IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.CUBIC_METRE, null, GetVolumeDimension(entityCreator));
			break;
		case ConversionBasedUnit.GallonUk:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "gallon UK", 0.004546, IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.CUBIC_METRE, null, GetVolumeDimension(entityCreator));
			break;
		case ConversionBasedUnit.GallonUs:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "gallon US", 0.003785, IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.CUBIC_METRE, null, GetVolumeDimension(entityCreator));
			break;
		case ConversionBasedUnit.Ounce:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "ounce", 28.35, IfcUnitEnum.MASSUNIT, IfcSIUnitName.GRAM, null, GetMassDimension(entityCreator));
			break;
		case ConversionBasedUnit.Pound:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "pound", 0.454, IfcUnitEnum.MASSUNIT, IfcSIUnitName.GRAM, IfcSIPrefix.KILO, GetMassDimension(entityCreator));
			break;
		case ConversionBasedUnit.SquareFoot:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "square foot", 92903.04, IfcUnitEnum.AREAUNIT, IfcSIUnitName.METRE, IfcSIPrefix.MILLI, GetAreaDimension(entityCreator));
			break;
		case ConversionBasedUnit.CubicFoot:
			SetConversionUnitsParameters(model, ifcConversionBasedUnit, "cubic foot", 28316846.6, IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.METRE, IfcSIPrefix.MILLI, GetVolumeDimension(entityCreator));
			break;
		}
		return ifcConversionBasedUnit;
	}

	private static void SetConversionUnitsParameters(IModel model, IIfcConversionBasedUnit unit, IfcLabel name, IfcRatioMeasure ratio, IfcUnitEnum unitType, IfcSIUnitName siUnitName, IfcSIPrefix? siUnitPrefix, IIfcDimensionalExponents dimensions)
	{
		EntityCreator entityCreator = new EntityCreator(model);
		unit.Name = name;
		unit.ConversionFactor = entityCreator.MeasureWithUnit();
		unit.ConversionFactor.ValueComponent = ratio;
		unit.ConversionFactor.UnitComponent = entityCreator.SIUnit(delegate(IIfcSIUnit s)
		{
			s.UnitType = unitType;
			s.Name = siUnitName;
			s.Prefix = siUnitPrefix;
		});
		unit.Dimensions = dimensions;
	}

	private static IIfcDimensionalExponents GetLengthDimension(EntityCreator factory)
	{
		IIfcDimensionalExponents ifcDimensionalExponents = factory.DimensionalExponents();
		ifcDimensionalExponents.AmountOfSubstanceExponent = 0L;
		ifcDimensionalExponents.ElectricCurrentExponent = 0L;
		ifcDimensionalExponents.LengthExponent = 1L;
		ifcDimensionalExponents.LuminousIntensityExponent = 0L;
		ifcDimensionalExponents.MassExponent = 0L;
		ifcDimensionalExponents.ThermodynamicTemperatureExponent = 0L;
		ifcDimensionalExponents.TimeExponent = 0L;
		return ifcDimensionalExponents;
	}

	private static IIfcDimensionalExponents GetVolumeDimension(EntityCreator factory)
	{
		IIfcDimensionalExponents ifcDimensionalExponents = factory.DimensionalExponents();
		ifcDimensionalExponents.AmountOfSubstanceExponent = 0L;
		ifcDimensionalExponents.ElectricCurrentExponent = 0L;
		ifcDimensionalExponents.LengthExponent = 3L;
		ifcDimensionalExponents.LuminousIntensityExponent = 0L;
		ifcDimensionalExponents.MassExponent = 0L;
		ifcDimensionalExponents.ThermodynamicTemperatureExponent = 0L;
		ifcDimensionalExponents.TimeExponent = 0L;
		return ifcDimensionalExponents;
	}

	private static IIfcDimensionalExponents GetAreaDimension(EntityCreator factory)
	{
		IIfcDimensionalExponents ifcDimensionalExponents = factory.DimensionalExponents();
		ifcDimensionalExponents.AmountOfSubstanceExponent = 0L;
		ifcDimensionalExponents.ElectricCurrentExponent = 0L;
		ifcDimensionalExponents.LengthExponent = 2L;
		ifcDimensionalExponents.LuminousIntensityExponent = 0L;
		ifcDimensionalExponents.MassExponent = 0L;
		ifcDimensionalExponents.ThermodynamicTemperatureExponent = 0L;
		ifcDimensionalExponents.TimeExponent = 0L;
		return ifcDimensionalExponents;
	}

	private static IIfcDimensionalExponents GetMassDimension(EntityCreator factory)
	{
		IIfcDimensionalExponents ifcDimensionalExponents = factory.DimensionalExponents();
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
