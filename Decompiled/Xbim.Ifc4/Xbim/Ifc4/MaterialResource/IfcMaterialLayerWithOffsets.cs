using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterialLayerWithOffsets", 1204)]
public class IfcMaterialLayerWithOffsets : IfcMaterialLayer, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterialLayerWithOffsets, IIfcMaterialLayer, IIfcMaterialDefinition, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IEquatable<IfcMaterialLayerWithOffsets>
{
	private IfcLayerSetDirectionEnum _offsetDirection;

	private readonly ItemSet<IfcLengthMeasure> _offsetValues;

	IfcLayerSetDirectionEnum IIfcMaterialLayerWithOffsets.OffsetDirection
	{
		get
		{
			return OffsetDirection;
		}
		set
		{
			OffsetDirection = value;
		}
	}

	IItemSet<IfcLengthMeasure> IIfcMaterialLayerWithOffsets.OffsetValues => OffsetValues;

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
	public IItemSet<IfcLengthMeasure> OffsetValues
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
		_offsetValues = new ItemSet<IfcLengthMeasure>(this, 2, 9);
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
