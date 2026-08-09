using System;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.TopologyResource;

[ExpressType("IfcVertex", 520)]
public class IfcVertex : IfcTopologicalRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcVertex, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcVertex>
{
	internal IfcVertex(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcVertex other)
	{
		return this == other;
	}
}
