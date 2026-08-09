using System;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.TopologyResource;

[ExpressType("IfcLoop", 199)]
public class IfcLoop : IfcTopologicalRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcLoop, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcLoop>
{
	internal IfcLoop(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcLoop other)
	{
		return this == other;
	}
}
