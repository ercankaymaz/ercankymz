using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.MaterialPropertyResource;

[ExpressType("IfcWaterProperties", 721)]
public class IfcWaterProperties : IfcMaterialProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcWaterProperties>
{
	private bool? _isPotable;

	private IfcIonConcentrationMeasure? _hardness;

	private IfcIonConcentrationMeasure? _alkalinityConcentration;

	private IfcIonConcentrationMeasure? _acidityConcentration;

	private IfcNormalisedRatioMeasure? _impuritiesContent;

	private IfcPHMeasure? _pHLevel;

	private IfcNormalisedRatioMeasure? _dissolvedSolidsContent;

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public bool? IsPotable
	{
		get
		{
			if (_activated)
			{
				return _isPotable;
			}
			Activate();
			return _isPotable;
		}
		set
		{
			SetValue(delegate(bool? v)
			{
				_isPotable = v;
			}, _isPotable, value, "IsPotable", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcIonConcentrationMeasure? Hardness
	{
		get
		{
			if (_activated)
			{
				return _hardness;
			}
			Activate();
			return _hardness;
		}
		set
		{
			SetValue(delegate(IfcIonConcentrationMeasure? v)
			{
				_hardness = v;
			}, _hardness, value, "Hardness", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcIonConcentrationMeasure? AlkalinityConcentration
	{
		get
		{
			if (_activated)
			{
				return _alkalinityConcentration;
			}
			Activate();
			return _alkalinityConcentration;
		}
		set
		{
			SetValue(delegate(IfcIonConcentrationMeasure? v)
			{
				_alkalinityConcentration = v;
			}, _alkalinityConcentration, value, "AlkalinityConcentration", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcIonConcentrationMeasure? AcidityConcentration
	{
		get
		{
			if (_activated)
			{
				return _acidityConcentration;
			}
			Activate();
			return _acidityConcentration;
		}
		set
		{
			SetValue(delegate(IfcIonConcentrationMeasure? v)
			{
				_acidityConcentration = v;
			}, _acidityConcentration, value, "AcidityConcentration", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcNormalisedRatioMeasure? ImpuritiesContent
	{
		get
		{
			if (_activated)
			{
				return _impuritiesContent;
			}
			Activate();
			return _impuritiesContent;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_impuritiesContent = v;
			}, _impuritiesContent, value, "ImpuritiesContent", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPHMeasure? PHLevel
	{
		get
		{
			if (_activated)
			{
				return _pHLevel;
			}
			Activate();
			return _pHLevel;
		}
		set
		{
			SetValue(delegate(IfcPHMeasure? v)
			{
				_pHLevel = v;
			}, _pHLevel, value, "PHLevel", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcNormalisedRatioMeasure? DissolvedSolidsContent
	{
		get
		{
			if (_activated)
			{
				return _dissolvedSolidsContent;
			}
			Activate();
			return _dissolvedSolidsContent;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_dissolvedSolidsContent = v;
			}, _dissolvedSolidsContent, value, "DissolvedSolidsContent", 8);
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

	internal IfcWaterProperties(IModel model, int label, bool activated)
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
			_isPotable = value.BooleanVal;
			break;
		case 2:
			_hardness = value.RealVal;
			break;
		case 3:
			_alkalinityConcentration = value.RealVal;
			break;
		case 4:
			_acidityConcentration = value.RealVal;
			break;
		case 5:
			_impuritiesContent = value.RealVal;
			break;
		case 6:
			_pHLevel = value.RealVal;
			break;
		case 7:
			_dissolvedSolidsContent = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWaterProperties other)
	{
		return this == other;
	}
}
