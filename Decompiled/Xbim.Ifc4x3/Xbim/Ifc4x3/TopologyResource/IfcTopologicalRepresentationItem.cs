using System;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.TopologyResource;

[ExpressType("IfcTopologicalRepresentationItem", 84)]
public abstract class IfcTopologicalRepresentationItem : IfcRepresentationItem, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcTopologicalRepresentationItem>
{
	internal IfcTopologicalRepresentationItem(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcTopologicalRepresentationItem other)
	{
		return this == other;
	}
}
