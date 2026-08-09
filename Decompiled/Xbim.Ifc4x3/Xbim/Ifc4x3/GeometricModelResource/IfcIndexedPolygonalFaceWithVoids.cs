using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcIndexedPolygonalFaceWithVoids", 1322)]
public class IfcIndexedPolygonalFaceWithVoids : IfcIndexedPolygonalFace, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcIndexedPolygonalFaceWithVoids>, IIfcIndexedPolygonalFaceWithVoids, IIfcIndexedPolygonalFace, IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private readonly ItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>> _innerCoordIndices;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 3 }, new int[] { -1, -1 }, 6)]
	public IItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>> InnerCoordIndices
	{
		get
		{
			if (_activated)
			{
				return _innerCoordIndices;
			}
			Activate();
			return _innerCoordIndices;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcIndexedPolygonalFaceWithVoids), 2)]
	IItemSet<IItemSet<Xbim.Ifc4.MeasureResource.IfcPositiveInteger>> IIfcIndexedPolygonalFaceWithVoids.InnerCoordIndices => new ProxyNestedValueSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger, Xbim.Ifc4.MeasureResource.IfcPositiveInteger>(InnerCoordIndices, (Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger s) => new Xbim.Ifc4.MeasureResource.IfcPositiveInteger(s), (Xbim.Ifc4.MeasureResource.IfcPositiveInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger(t));

	internal IfcIndexedPolygonalFaceWithVoids(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_innerCoordIndices = new ItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			((ItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>)_innerCoordIndices.InternalGetAt(nestedIndex[0])).InternalAdd(value.IntegerVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcIndexedPolygonalFaceWithVoids other)
	{
		return this == other;
	}
}
