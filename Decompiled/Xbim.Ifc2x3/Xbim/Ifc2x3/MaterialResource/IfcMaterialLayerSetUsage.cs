using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.MaterialResource;

[ExpressType("IfcMaterialLayerSetUsage", 165)]
public class IfcMaterialLayerSetUsage : PersistEntity, IIfcMaterialLayerSetUsage, IIfcMaterialUsageDefinition, IPersistEntity, IPersist, Xbim.Ifc4.MaterialResource.IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IInstantiableEntity, IfcMaterialSelect, IContainsEntityReferences, IEquatable<IfcMaterialLayerSetUsage>
{
	private Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? _referenceExtent;

	private IfcMaterialLayerSet _forLayerSet;

	private IfcLayerSetDirectionEnum _layerSetDirection;

	private IfcDirectionSenseEnum _directionSense;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure _offsetFromReferenceLine;

	[CrossSchemaAttribute(typeof(IIfcMaterialLayerSetUsage), 1)]
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

	[CrossSchemaAttribute(typeof(IIfcMaterialLayerSetUsage), 2)]
	Xbim.Ifc4.Interfaces.IfcLayerSetDirectionEnum IIfcMaterialLayerSetUsage.LayerSetDirection
	{
		get
		{
			return LayerSetDirection switch
			{
				IfcLayerSetDirectionEnum.AXIS1 => Xbim.Ifc4.Interfaces.IfcLayerSetDirectionEnum.AXIS1, 
				IfcLayerSetDirectionEnum.AXIS2 => Xbim.Ifc4.Interfaces.IfcLayerSetDirectionEnum.AXIS2, 
				IfcLayerSetDirectionEnum.AXIS3 => Xbim.Ifc4.Interfaces.IfcLayerSetDirectionEnum.AXIS3, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcLayerSetDirectionEnum.AXIS1:
				LayerSetDirection = IfcLayerSetDirectionEnum.AXIS1;
				break;
			case Xbim.Ifc4.Interfaces.IfcLayerSetDirectionEnum.AXIS2:
				LayerSetDirection = IfcLayerSetDirectionEnum.AXIS2;
				break;
			case Xbim.Ifc4.Interfaces.IfcLayerSetDirectionEnum.AXIS3:
				LayerSetDirection = IfcLayerSetDirectionEnum.AXIS3;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayerSetUsage), 3)]
	Xbim.Ifc4.Interfaces.IfcDirectionSenseEnum IIfcMaterialLayerSetUsage.DirectionSense
	{
		get
		{
			return DirectionSense switch
			{
				IfcDirectionSenseEnum.POSITIVE => Xbim.Ifc4.Interfaces.IfcDirectionSenseEnum.POSITIVE, 
				IfcDirectionSenseEnum.NEGATIVE => Xbim.Ifc4.Interfaces.IfcDirectionSenseEnum.NEGATIVE, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDirectionSenseEnum.POSITIVE:
				DirectionSense = IfcDirectionSenseEnum.POSITIVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDirectionSenseEnum.NEGATIVE:
				DirectionSense = IfcDirectionSenseEnum.NEGATIVE;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayerSetUsage), 4)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcMaterialLayerSetUsage.OffsetFromReferenceLine
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(OffsetFromReferenceLine);
		}
		set
		{
			OffsetFromReferenceLine = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayerSetUsage), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcMaterialLayerSetUsage.ReferenceExtent
	{
		get
		{
			return _referenceExtent;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_referenceExtent = v;
			}, _referenceExtent, value, "ReferenceExtent", -5);
		}
	}

	IEnumerable<IIfcRelAssociatesMaterial> IIfcMaterialUsageDefinition.AssociatedTo => base.Model.Instances.Where((IIfcRelAssociatesMaterial e) => e.RelatingMaterial as IfcMaterialLayerSetUsage == this, "RelatingMaterial", this);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
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

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 2)]
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

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 3)]
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

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure OffsetFromReferenceLine
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure v)
			{
				_offsetFromReferenceLine = v;
			}, _offsetFromReferenceLine, value, "OffsetFromReferenceLine", 4);
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
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialLayerSetUsage other)
	{
		return this == other;
	}
}
