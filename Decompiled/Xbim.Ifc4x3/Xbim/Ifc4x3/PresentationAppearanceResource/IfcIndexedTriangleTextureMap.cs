using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcIndexedTriangleTextureMap", 1192)]
public class IfcIndexedTriangleTextureMap : IfcIndexedTextureMap, IIfcIndexedTriangleTextureMap, IIfcIndexedTextureMap, IIfcTextureCoordinate, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcIndexedTriangleTextureMap>
{
	private readonly OptionalItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>> _texCoordIndex;

	[CrossSchemaAttribute(typeof(IIfcIndexedTriangleTextureMap), 4)]
	IItemSet<IItemSet<Xbim.Ifc4.MeasureResource.IfcPositiveInteger>> IIfcIndexedTriangleTextureMap.TexCoordIndex => new ProxyNestedValueSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger, Xbim.Ifc4.MeasureResource.IfcPositiveInteger>(TexCoordIndex, (Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger s) => new Xbim.Ifc4.MeasureResource.IfcPositiveInteger(s), (Xbim.Ifc4.MeasureResource.IfcPositiveInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger(t));

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 3 }, new int[] { -1, 3 }, 4)]
	public IOptionalItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>> TexCoordIndex
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
		}
	}

	internal IfcIndexedTriangleTextureMap(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_texCoordIndex = new OptionalItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>>(this, 0, 4);
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
			((ItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>)_texCoordIndex.InternalGetAt(nestedIndex[0])).InternalAdd(value.IntegerVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcIndexedTriangleTextureMap other)
	{
		return this == other;
	}
}
