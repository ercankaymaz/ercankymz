using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.MaterialPropertyResource;

[ExpressType("IfcFuelProperties", 715)]
public class IfcFuelProperties : IfcMaterialProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcFuelProperties>
{
	private IfcThermodynamicTemperatureMeasure? _combustionTemperature;

	private IfcPositiveRatioMeasure? _carbonContent;

	private IfcHeatingValueMeasure? _lowerHeatingValue;

	private IfcHeatingValueMeasure? _higherHeatingValue;

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcThermodynamicTemperatureMeasure? CombustionTemperature
	{
		get
		{
			if (_activated)
			{
				return _combustionTemperature;
			}
			Activate();
			return _combustionTemperature;
		}
		set
		{
			SetValue(delegate(IfcThermodynamicTemperatureMeasure? v)
			{
				_combustionTemperature = v;
			}, _combustionTemperature, value, "CombustionTemperature", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcPositiveRatioMeasure? CarbonContent
	{
		get
		{
			if (_activated)
			{
				return _carbonContent;
			}
			Activate();
			return _carbonContent;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_carbonContent = v;
			}, _carbonContent, value, "CarbonContent", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcHeatingValueMeasure? LowerHeatingValue
	{
		get
		{
			if (_activated)
			{
				return _lowerHeatingValue;
			}
			Activate();
			return _lowerHeatingValue;
		}
		set
		{
			SetValue(delegate(IfcHeatingValueMeasure? v)
			{
				_lowerHeatingValue = v;
			}, _lowerHeatingValue, value, "LowerHeatingValue", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcHeatingValueMeasure? HigherHeatingValue
	{
		get
		{
			if (_activated)
			{
				return _higherHeatingValue;
			}
			Activate();
			return _higherHeatingValue;
		}
		set
		{
			SetValue(delegate(IfcHeatingValueMeasure? v)
			{
				_higherHeatingValue = v;
			}, _higherHeatingValue, value, "HigherHeatingValue", 5);
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

	internal IfcFuelProperties(IModel model, int label, bool activated)
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
			_combustionTemperature = value.RealVal;
			break;
		case 2:
			_carbonContent = value.RealVal;
			break;
		case 3:
			_lowerHeatingValue = value.RealVal;
			break;
		case 4:
			_higherHeatingValue = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFuelProperties other)
	{
		return this == other;
	}
}
