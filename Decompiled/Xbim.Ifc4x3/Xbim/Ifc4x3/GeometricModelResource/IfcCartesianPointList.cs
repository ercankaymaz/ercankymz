using System;
using Xbim.Common;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcCartesianPointList", 1116)]
public abstract class IfcCartesianPointList : Xbim.Ifc4x3.GeometryResource.IfcGeometricRepresentationItem, IEquatable<IfcCartesianPointList>, IIfcCartesianPointList, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.GeometryResource.IfcDimensionCount Dim
	{
		get
		{
			if (this is IfcCartesianPointList2D)
			{
				return 2L;
			}
			if (this is IfcCartesianPointList3D)
			{
				return 3L;
			}
			throw new NotSupportedException();
		}
	}

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcCartesianPointList.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcCartesianPointList(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcCartesianPointList other)
	{
		return this == other;
	}
}
