using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterialProfileWithOffsets", 1209)]
public class IfcMaterialProfileWithOffsets : IfcMaterialProfile, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterialProfileWithOffsets, IIfcMaterialProfile, IIfcMaterialDefinition, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IEquatable<IfcMaterialProfileWithOffsets>
{
	private readonly ItemSet<IfcLengthMeasure> _offsetValues;

	IItemSet<IfcLengthMeasure> IIfcMaterialProfileWithOffsets.OffsetValues => OffsetValues;

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Array, EntityAttributeType.None, new int[] { 1 }, new int[] { 2 }, 11)]
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
			if (base.Profile != null)
			{
				yield return base.Profile;
			}
		}
	}

	internal IfcMaterialProfileWithOffsets(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_offsetValues = new ItemSet<IfcLengthMeasure>(this, 2, 7);
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
			_offsetValues.InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialProfileWithOffsets other)
	{
		return this == other;
	}
}
