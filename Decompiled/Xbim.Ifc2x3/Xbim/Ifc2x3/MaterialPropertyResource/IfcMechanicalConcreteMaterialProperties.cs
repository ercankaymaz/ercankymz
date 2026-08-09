using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.MaterialPropertyResource;

[ExpressType("IfcMechanicalConcreteMaterialProperties", 693)]
public class IfcMechanicalConcreteMaterialProperties : IfcMechanicalMaterialProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcMechanicalConcreteMaterialProperties>
{
	private IfcPressureMeasure? _compressiveStrength;

	private IfcPositiveLengthMeasure? _maxAggregateSize;

	private IfcText? _admixturesDescription;

	private IfcText? _workability;

	private IfcNormalisedRatioMeasure? _protectivePoreRatio;

	private IfcText? _waterImpermeability;

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPressureMeasure? CompressiveStrength
	{
		get
		{
			if (_activated)
			{
				return _compressiveStrength;
			}
			Activate();
			return _compressiveStrength;
		}
		set
		{
			SetValue(delegate(IfcPressureMeasure? v)
			{
				_compressiveStrength = v;
			}, _compressiveStrength, value, "CompressiveStrength", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcPositiveLengthMeasure? MaxAggregateSize
	{
		get
		{
			if (_activated)
			{
				return _maxAggregateSize;
			}
			Activate();
			return _maxAggregateSize;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_maxAggregateSize = v;
			}, _maxAggregateSize, value, "MaxAggregateSize", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcText? AdmixturesDescription
	{
		get
		{
			if (_activated)
			{
				return _admixturesDescription;
			}
			Activate();
			return _admixturesDescription;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_admixturesDescription = v;
			}, _admixturesDescription, value, "AdmixturesDescription", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcText? Workability
	{
		get
		{
			if (_activated)
			{
				return _workability;
			}
			Activate();
			return _workability;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_workability = v;
			}, _workability, value, "Workability", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcNormalisedRatioMeasure? ProtectivePoreRatio
	{
		get
		{
			if (_activated)
			{
				return _protectivePoreRatio;
			}
			Activate();
			return _protectivePoreRatio;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_protectivePoreRatio = v;
			}, _protectivePoreRatio, value, "ProtectivePoreRatio", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcText? WaterImpermeability
	{
		get
		{
			if (_activated)
			{
				return _waterImpermeability;
			}
			Activate();
			return _waterImpermeability;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_waterImpermeability = v;
			}, _waterImpermeability, value, "WaterImpermeability", 12);
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

	internal IfcMechanicalConcreteMaterialProperties(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_compressiveStrength = value.RealVal;
			break;
		case 7:
			_maxAggregateSize = value.RealVal;
			break;
		case 8:
			_admixturesDescription = value.StringVal;
			break;
		case 9:
			_workability = value.StringVal;
			break;
		case 10:
			_protectivePoreRatio = value.RealVal;
			break;
		case 11:
			_waterImpermeability = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMechanicalConcreteMaterialProperties other)
	{
		return this == other;
	}
}
