using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterialLayerSetUsage", 165)]
public class IfcMaterialLayerSetUsage : IfcMaterialUsageDefinition, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterialLayerSetUsage, IIfcMaterialUsageDefinition, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcMaterialLayerSetUsage>
{
	private IfcMaterialLayerSet _forLayerSet;

	private IfcLayerSetDirectionEnum _layerSetDirection;

	private IfcDirectionSenseEnum _directionSense;

	private IfcLengthMeasure _offsetFromReferenceLine;

	private IfcPositiveLengthMeasure? _referenceExtent;

	IIfcMaterialLayerSet IIfcMaterialLayerSetUsage.ForLayerSet
	{
		get
		{
			return ForLayerSet;
		}
		set
		{
			ForLayerSet = value as IfcMaterialLayerSet;
		}
	}

	IfcLayerSetDirectionEnum IIfcMaterialLayerSetUsage.LayerSetDirection
	{
		get
		{
			return LayerSetDirection;
		}
		set
		{
			LayerSetDirection = value;
		}
	}

	IfcDirectionSenseEnum IIfcMaterialLayerSetUsage.DirectionSense
	{
		get
		{
			return DirectionSense;
		}
		set
		{
			DirectionSense = value;
		}
	}

	IfcLengthMeasure IIfcMaterialLayerSetUsage.OffsetFromReferenceLine
	{
		get
		{
			return OffsetFromReferenceLine;
		}
		set
		{
			OffsetFromReferenceLine = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcMaterialLayerSetUsage.ReferenceExtent
	{
		get
		{
			return ReferenceExtent;
		}
		set
		{
			ReferenceExtent = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcMaterialLayerSet ForLayerSet
	{
		get
		{
			if (_activated)
			{
				return _forLayerSet;
			}
			Activate();
			return _forLayerSet;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMaterialLayerSet v)
			{
				_forLayerSet = v;
			}, _forLayerSet, value, "ForLayerSet", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 3)]
	public IfcLayerSetDirectionEnum LayerSetDirection
	{
		get
		{
			if (_activated)
			{
				return _layerSetDirection;
			}
			Activate();
			return _layerSetDirection;
		}
		set
		{
			SetValue(delegate(IfcLayerSetDirectionEnum v)
			{
				_layerSetDirection = v;
			}, _layerSetDirection, value, "LayerSetDirection", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 4)]
	public IfcDirectionSenseEnum DirectionSense
	{
		get
		{
			if (_activated)
			{
				return _directionSense;
			}
			Activate();
			return _directionSense;
		}
		set
		{
			SetValue(delegate(IfcDirectionSenseEnum v)
			{
				_directionSense = v;
			}, _directionSense, value, "DirectionSense", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLengthMeasure OffsetFromReferenceLine
	{
		get
		{
			if (_activated)
			{
				return _offsetFromReferenceLine;
			}
			Activate();
			return _offsetFromReferenceLine;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_offsetFromReferenceLine = v;
			}, _offsetFromReferenceLine, value, "OffsetFromReferenceLine", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure? ReferenceExtent
	{
		get
		{
			if (_activated)
			{
				return _referenceExtent;
			}
			Activate();
			return _referenceExtent;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_referenceExtent = v;
			}, _referenceExtent, value, "ReferenceExtent", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ForLayerSet != null)
			{
				yield return ForLayerSet;
			}
		}
	}

	internal IfcMaterialLayerSetUsage(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_forLayerSet = (IfcMaterialLayerSet)value.EntityVal;
			break;
		case 1:
			_layerSetDirection = (IfcLayerSetDirectionEnum)Enum.Parse(typeof(IfcLayerSetDirectionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 2:
			_directionSense = (IfcDirectionSenseEnum)Enum.Parse(typeof(IfcDirectionSenseEnum), value.EnumVal, ignoreCase: true);
			break;
		case 3:
			_offsetFromReferenceLine = value.RealVal;
			break;
		case 4:
			_referenceExtent = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialLayerSetUsage other)
	{
		return this == other;
	}
}
