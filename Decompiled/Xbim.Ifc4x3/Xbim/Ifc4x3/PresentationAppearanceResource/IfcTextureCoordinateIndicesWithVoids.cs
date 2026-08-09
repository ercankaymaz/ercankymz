using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcTextureCoordinateIndicesWithVoids", 1497)]
public class IfcTextureCoordinateIndicesWithVoids : IfcTextureCoordinateIndices, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTextureCoordinateIndicesWithVoids>
{
	private readonly ItemSet<IItemSet<IfcPositiveInteger>> _innerTexCoordIndices;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 3 }, new int[] { -1, -1 }, 4)]
	public IItemSet<IItemSet<IfcPositiveInteger>> InnerTexCoordIndices
	{
		get
		{
			if (_activated)
			{
				return _innerTexCoordIndices;
			}
			Activate();
			return _innerTexCoordIndices;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.TexCoordsOf != null)
			{
				yield return base.TexCoordsOf;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.TexCoordsOf != null)
			{
				yield return base.TexCoordsOf;
			}
		}
	}

	internal IfcTextureCoordinateIndicesWithVoids(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_innerTexCoordIndices = new ItemSet<IItemSet<IfcPositiveInteger>>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			((ItemSet<IfcPositiveInteger>)_innerTexCoordIndices.InternalGetAt(nestedIndex[0])).InternalAdd(value.IntegerVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTextureCoordinateIndicesWithVoids other)
	{
		return this == other;
	}
}
