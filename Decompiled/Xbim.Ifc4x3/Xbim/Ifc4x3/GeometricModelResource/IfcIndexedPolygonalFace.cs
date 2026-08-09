using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PresentationAppearanceResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcIndexedPolygonalFace", 1321)]
public class IfcIndexedPolygonalFace : IfcTessellatedItem, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcIndexedPolygonalFace>, IIfcIndexedPolygonalFace, IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger> _coordIndex;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 3 }, new int[] { -1 }, 3)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger> CoordIndex
	{
		get
		{
			if (_activated)
			{
				return _coordIndex;
			}
			Activate();
			return _coordIndex;
		}
	}

	[InverseProperty("Faces")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcPolygonalFaceSet> ToFaceSet => base.Model.Instances.Where((IfcPolygonalFaceSet e) => e.Faces != null && e.Faces.Contains(this), "Faces", this);

	[InverseProperty("TexCoordsOf")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 5)]
	public IEnumerable<IfcTextureCoordinateIndices> HasTexCoords => base.Model.Instances.Where((IfcTextureCoordinateIndices e) => Equals(e.TexCoordsOf), "TexCoordsOf", this);

	[CrossSchemaAttribute(typeof(IIfcIndexedPolygonalFace), 1)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcPositiveInteger> IIfcIndexedPolygonalFace.CoordIndex => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger, Xbim.Ifc4.MeasureResource.IfcPositiveInteger>(CoordIndex, (Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger s) => new Xbim.Ifc4.MeasureResource.IfcPositiveInteger(s), (Xbim.Ifc4.MeasureResource.IfcPositiveInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger(t));

	IEnumerable<IIfcPolygonalFaceSet> IIfcIndexedPolygonalFace.ToFaceSet => base.Model.Instances.Where((IIfcPolygonalFaceSet e) => e.Faces != null && e.Faces.Contains(this), "Faces", this);

	internal IfcIndexedPolygonalFace(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_coordIndex = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_coordIndex.InternalAdd(value.IntegerVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcIndexedPolygonalFace other)
	{
		return this == other;
	}
}
