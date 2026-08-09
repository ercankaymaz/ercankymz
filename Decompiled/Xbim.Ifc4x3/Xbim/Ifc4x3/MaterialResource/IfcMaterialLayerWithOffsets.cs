using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.MaterialResource;

[ExpressType("IfcMaterialLayerWithOffsets", 1204)]
public class IfcMaterialLayerWithOffsets : IfcMaterialLayer, IIfcMaterialLayerWithOffsets, IIfcMaterialLayer, IIfcMaterialDefinition, IPersistEntity, IPersist, Xbim.Ifc4.MaterialResource.IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcMaterialLayerWithOffsets>
{
	private IfcLayerSetDirectionEnum _offsetDirection;

	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure> _offsetValues;

	[CrossSchemaAttribute(typeof(IIfcMaterialLayerWithOffsets), 8)]
	Xbim.Ifc4.Interfaces.IfcLayerSetDirectionEnum IIfcMaterialLayerWithOffsets.OffsetDirection
	{
		get
		{
			return OffsetDirection switch
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
				OffsetDirection = IfcLayerSetDirectionEnum.AXIS1;
				break;
			case Xbim.Ifc4.Interfaces.IfcLayerSetDirectionEnum.AXIS2:
				OffsetDirection = IfcLayerSetDirectionEnum.AXIS2;
				break;
			case Xbim.Ifc4.Interfaces.IfcLayerSetDirectionEnum.AXIS3:
				OffsetDirection = IfcLayerSetDirectionEnum.AXIS3;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayerWithOffsets), 9)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLengthMeasure> IIfcMaterialLayerWithOffsets.OffsetValues => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure, Xbim.Ifc4.MeasureResource.IfcLengthMeasure>(OffsetValues, (Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure s) => new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(s), (Xbim.Ifc4.MeasureResource.IfcLengthMeasure t) => new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(t));

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 12)]
	public IfcLayerSetDirectionEnum OffsetDirection
	{
		get
		{
			if (_activated)
			{
				return _offsetDirection;
			}
			Activate();
			return _offsetDirection;
		}
		set
		{
			SetValue(delegate(IfcLayerSetDirectionEnum v)
			{
				_offsetDirection = v;
			}, _offsetDirection, value, "OffsetDirection", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Array, EntityAttributeType.None, new int[] { 1 }, new int[] { 2 }, 13)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure> OffsetValues
	{
		get
		{
			if (_activated)
			{
				return _offsetValues;
			}
			Activate();
			return _offsetValues;
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

	internal IfcMaterialLayerWithOffsets(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_offsetValues = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>(this, 2, 9);
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
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_offsetDirection = (IfcLayerSetDirectionEnum)Enum.Parse(typeof(IfcLayerSetDirectionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_offsetValues.InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialLayerWithOffsets other)
	{
		return this == other;
	}
}
