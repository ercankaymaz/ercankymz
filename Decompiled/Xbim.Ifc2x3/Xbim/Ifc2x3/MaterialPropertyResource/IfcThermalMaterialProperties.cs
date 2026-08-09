using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.MaterialPropertyResource;

[ExpressType("IfcThermalMaterialProperties", 720)]
public class IfcThermalMaterialProperties : IfcMaterialProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcThermalMaterialProperties>
{
	private IfcSpecificHeatCapacityMeasure? _specificHeatCapacity;

	private IfcThermodynamicTemperatureMeasure? _boilingPoint;

	private IfcThermodynamicTemperatureMeasure? _freezingPoint;

	private IfcThermalConductivityMeasure? _thermalConductivity;

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcSpecificHeatCapacityMeasure? SpecificHeatCapacity
	{
		get
		{
			if (_activated)
			{
				return _specificHeatCapacity;
			}
			Activate();
			return _specificHeatCapacity;
		}
		set
		{
			SetValue(delegate(IfcSpecificHeatCapacityMeasure? v)
			{
				_specificHeatCapacity = v;
			}, _specificHeatCapacity, value, "SpecificHeatCapacity", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcThermodynamicTemperatureMeasure? BoilingPoint
	{
		get
		{
			if (_activated)
			{
				return _boilingPoint;
			}
			Activate();
			return _boilingPoint;
		}
		set
		{
			SetValue(delegate(IfcThermodynamicTemperatureMeasure? v)
			{
				_boilingPoint = v;
			}, _boilingPoint, value, "BoilingPoint", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcThermodynamicTemperatureMeasure? FreezingPoint
	{
		get
		{
			if (_activated)
			{
				return _freezingPoint;
			}
			Activate();
			return _freezingPoint;
		}
		set
		{
			SetValue(delegate(IfcThermodynamicTemperatureMeasure? v)
			{
				_freezingPoint = v;
			}, _freezingPoint, value, "FreezingPoint", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcThermalConductivityMeasure? ThermalConductivity
	{
		get
		{
			if (_activated)
			{
				return _thermalConductivity;
			}
			Activate();
			return _thermalConductivity;
		}
		set
		{
			SetValue(delegate(IfcThermalConductivityMeasure? v)
			{
				_thermalConductivity = v;
			}, _thermalConductivity, value, "ThermalConductivity", 5);
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

	internal IfcThermalMaterialProperties(IModel model, int label, bool activated)
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
			_specificHeatCapacity = value.RealVal;
			break;
		case 2:
			_boilingPoint = value.RealVal;
			break;
		case 3:
			_freezingPoint = value.RealVal;
			break;
		case 4:
			_thermalConductivity = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcThermalMaterialProperties other)
	{
		return this == other;
	}
}
