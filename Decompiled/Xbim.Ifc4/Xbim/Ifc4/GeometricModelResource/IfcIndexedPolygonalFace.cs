using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcIndexedPolygonalFace", 1321)]
public class IfcIndexedPolygonalFace : IfcTessellatedItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcIndexedPolygonalFace, IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcIndexedPolygonalFace>
{
	private readonly ItemSet<IfcPositiveInteger> _coordIndex;

	IItemSet<IfcPositiveInteger> IIfcIndexedPolygonalFace.CoordIndex => CoordIndex;

	IEnumerable<IIfcPolygonalFaceSet> IIfcIndexedPolygonalFace.ToFaceSet => ToFaceSet;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 3 }, new int[] { -1 }, 3)]
	public IItemSet<IfcPositiveInteger> CoordIndex
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

	internal IfcIndexedPolygonalFace(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_coordIndex = new ItemSet<IfcPositiveInteger>(this, 0, 1);
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
