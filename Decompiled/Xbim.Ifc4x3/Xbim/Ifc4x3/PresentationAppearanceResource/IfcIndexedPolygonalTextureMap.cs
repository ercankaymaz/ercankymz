using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcIndexedPolygonalTextureMap", 1451)]
public class IfcIndexedPolygonalTextureMap : IfcIndexedTextureMap, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcIndexedPolygonalTextureMap>
{
	private readonly ItemSet<IfcTextureCoordinateIndices> _texCoordIndices;

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcTextureCoordinateIndices> TexCoordIndices
	{
		get
		{
			if (_activated)
			{
				return _texCoordIndices;
			}
			Activate();
			return _texCoordIndices;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcSurfaceTexture map in base.Maps)
			{
				yield return map;
			}
			if (base.MappedTo != null)
			{
				yield return base.MappedTo;
			}
			if (base.TexCoords != null)
			{
				yield return base.TexCoords;
			}
			foreach (IfcTextureCoordinateIndices texCoordIndex in TexCoordIndices)
			{
				yield return texCoordIndex;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcSurfaceTexture map in base.Maps)
			{
				yield return map;
			}
			if (base.MappedTo != null)
			{
				yield return base.MappedTo;
			}
			foreach (IfcTextureCoordinateIndices texCoordIndex in TexCoordIndices)
			{
				yield return texCoordIndex;
			}
		}
	}

	internal IfcIndexedPolygonalTextureMap(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_texCoordIndices = new ItemSet<IfcTextureCoordinateIndices>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_texCoordIndices.InternalAdd((IfcTextureCoordinateIndices)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcIndexedPolygonalTextureMap other)
	{
		return this == other;
	}
}
