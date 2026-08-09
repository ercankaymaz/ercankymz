using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcIndexedPolygonalFaceWithVoids", 1322)]
public class IfcIndexedPolygonalFaceWithVoids : IfcIndexedPolygonalFace, IInstantiableEntity, IPersistEntity, IPersist, IIfcIndexedPolygonalFaceWithVoids, IIfcIndexedPolygonalFace, IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcIndexedPolygonalFaceWithVoids>
{
	private readonly ItemSet<IItemSet<IfcPositiveInteger>> _innerCoordIndices;

	IItemSet<IItemSet<IfcPositiveInteger>> IIfcIndexedPolygonalFaceWithVoids.InnerCoordIndices => InnerCoordIndices;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 3 }, new int[] { -1, -1 }, 5)]
	public IItemSet<IItemSet<IfcPositiveInteger>> InnerCoordIndices
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

	internal IfcIndexedPolygonalFaceWithVoids(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_innerCoordIndices = new ItemSet<IItemSet<IfcPositiveInteger>>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			((ItemSet<IfcPositiveInteger>)_innerCoordIndices.InternalGetAt(nestedIndex[0])).InternalAdd(value.IntegerVal);
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
