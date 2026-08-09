using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.MaterialPropertyResource;

[ExpressType("IfcHygroscopicMaterialProperties", 717)]
public class IfcHygroscopicMaterialProperties : IfcMaterialProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcHygroscopicMaterialProperties>
{
	private IfcPositiveRatioMeasure? _upperVaporResistanceFactor;

	private IfcPositiveRatioMeasure? _lowerVaporResistanceFactor;

	private IfcIsothermalMoistureCapacityMeasure? _isothermalMoistureCapacity;

	private IfcVaporPermeabilityMeasure? _vaporPermeability;

	private IfcMoistureDiffusivityMeasure? _moistureDiffusivity;

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcPositiveRatioMeasure? UpperVaporResistanceFactor
	{
		get
		{
			if (_activated)
			{
				return _upperVaporResistanceFactor;
			}
			Activate();
			return _upperVaporResistanceFactor;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_upperVaporResistanceFactor = v;
			}, _upperVaporResistanceFactor, value, "UpperVaporResistanceFactor", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcPositiveRatioMeasure? LowerVaporResistanceFactor
	{
		get
		{
			if (_activated)
			{
				return _lowerVaporResistanceFactor;
			}
			Activate();
			return _lowerVaporResistanceFactor;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_lowerVaporResistanceFactor = v;
			}, _lowerVaporResistanceFactor, value, "LowerVaporResistanceFactor", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcIsothermalMoistureCapacityMeasure? IsothermalMoistureCapacity
	{
		get
		{
			if (_activated)
			{
				return _isothermalMoistureCapacity;
			}
			Activate();
			return _isothermalMoistureCapacity;
		}
		set
		{
			SetValue(delegate(IfcIsothermalMoistureCapacityMeasure? v)
			{
				_isothermalMoistureCapacity = v;
			}, _isothermalMoistureCapacity, value, "IsothermalMoistureCapacity", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcVaporPermeabilityMeasure? VaporPermeability
	{
		get
		{
			if (_activated)
			{
				return _vaporPermeability;
			}
			Activate();
			return _vaporPermeability;
		}
		set
		{
			SetValue(delegate(IfcVaporPermeabilityMeasure? v)
			{
				_vaporPermeability = v;
			}, _vaporPermeability, value, "VaporPermeability", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcMoistureDiffusivityMeasure? MoistureDiffusivity
	{
		get
		{
			if (_activated)
			{
				return _moistureDiffusivity;
			}
			Activate();
			return _moistureDiffusivity;
		}
		set
		{
			SetValue(delegate(IfcMoistureDiffusivityMeasure? v)
			{
				_moistureDiffusivity = v;
			}, _moistureDiffusivity, value, "MoistureDiffusivity", 6);
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

	internal IfcHygroscopicMaterialProperties(IModel model, int label, bool activated)
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
			_upperVaporResistanceFactor = value.RealVal;
			break;
		case 2:
			_lowerVaporResistanceFactor = value.RealVal;
			break;
		case 3:
			_isothermalMoistureCapacity = value.RealVal;
			break;
		case 4:
			_vaporPermeability = value.RealVal;
			break;
		case 5:
			_moistureDiffusivity = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcHygroscopicMaterialProperties other)
	{
		return this == other;
	}
}
