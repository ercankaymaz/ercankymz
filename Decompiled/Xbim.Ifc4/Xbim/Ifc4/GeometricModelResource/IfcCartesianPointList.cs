using System;
using Xbim.Common;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcCartesianPointList", 1116)]
public abstract class IfcCartesianPointList : IfcGeometricRepresentationItem, IIfcCartesianPointList, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcCartesianPointList>
{
	IfcDimensionCount IIfcCartesianPointList.Dim => Dim;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim
	{
		get
		{
			if (this is IfcCartesianPointList2D)
			{
				return new IfcDimensionCount(2L);
			}
			if (this is IfcCartesianPointList3D)
			{
				return new IfcDimensionCount(3L);
			}
			return 0L;
		}
	}

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
