using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.MaterialPropertyResource;

[ExpressType("IfcProductsOfCombustionProperties", 719)]
public class IfcProductsOfCombustionProperties : IfcMaterialProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcProductsOfCombustionProperties>
{
	private IfcSpecificHeatCapacityMeasure? _specificHeatCapacity;

	private IfcPositiveRatioMeasure? _n20Content;

	private IfcPositiveRatioMeasure? _cOContent;

	private IfcPositiveRatioMeasure? _cO2Content;

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
	public IfcPositiveRatioMeasure? N20Content
	{
		get
		{
			if (_activated)
			{
				return _n20Content;
			}
			Activate();
			return _n20Content;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_n20Content = v;
			}, _n20Content, value, "N20Content", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPositiveRatioMeasure? COContent
	{
		get
		{
			if (_activated)
			{
				return _cOContent;
			}
			Activate();
			return _cOContent;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_cOContent = v;
			}, _cOContent, value, "COContent", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveRatioMeasure? CO2Content
	{
		get
		{
			if (_activated)
			{
				return _cO2Content;
			}
			Activate();
			return _cO2Content;
		}
		set
		{
			SetValue(delegate(IfcPositiveRatioMeasure? v)
			{
				_cO2Content = v;
			}, _cO2Content, value, "CO2Content", 5);
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

	internal IfcProductsOfCombustionProperties(IModel model, int label, bool activated)
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
			_n20Content = value.RealVal;
			break;
		case 3:
			_cOContent = value.RealVal;
			break;
		case 4:
			_cO2Content = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProductsOfCombustionProperties other)
	{
		return this == other;
	}
}
