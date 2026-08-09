using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.GeometricModelResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcTextureCoordinateIndices", 1496)]
public class IfcTextureCoordinateIndices : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTextureCoordinateIndices>
{
	private readonly ItemSet<IfcPositiveInteger> _texCoordIndex;

	private IfcIndexedPolygonalFace _texCoordsOf;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 3 }, new int[] { -1 }, 1)]
	public IItemSet<IfcPositiveInteger> TexCoordIndex
	{
		get
		{
			if (_activated)
			{
				return _texCoordIndex;
			}
			Activate();
			return _texCoordIndex;
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcIndexedPolygonalFace TexCoordsOf
	{
		get
		{
			if (_activated)
			{
				return _texCoordsOf;
			}
			Activate();
			return _texCoordsOf;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcIndexedPolygonalFace v)
			{
				_texCoordsOf = v;
			}, _texCoordsOf, value, "TexCoordsOf", 2);
		}
	}

	[InverseProperty("TexCoordIndices")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, null, null, 3)]
	public IfcIndexedPolygonalTextureMap ToTexMap => base.Model.Instances.FirstOrDefault((IfcIndexedPolygonalTextureMap e) => e.TexCoordIndices != null && e.TexCoordIndices.Contains(this), "TexCoordIndices", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (TexCoordsOf != null)
			{
				yield return TexCoordsOf;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (TexCoordsOf != null)
			{
				yield return TexCoordsOf;
			}
		}
	}

	internal IfcTextureCoordinateIndices(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_texCoordIndex = new ItemSet<IfcPositiveInteger>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_texCoordIndex.InternalAdd(value.IntegerVal);
			break;
		case 1:
			_texCoordsOf = (IfcIndexedPolygonalFace)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTextureCoordinateIndices other)
	{
		return this == other;
	}
}
