using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.ExternalReferenceResource;

namespace Xbim.Ifc4x3.PropertyResource;

[ExpressType("IfcPropertyAbstraction", 1231)]
public abstract class IfcPropertyAbstraction : PersistEntity, IIfcPropertyAbstraction, IPersistEntity, IPersist, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, Xbim.Ifc4x3.ExternalReferenceResource.IfcResourceObjectSelect, IEquatable<IfcPropertyAbstraction>
{
	IEnumerable<IIfcExternalReferenceRelationship> IIfcPropertyAbstraction.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 1)]
	public IEnumerable<Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship> HasExternalReferences => base.Model.Instances.Where((Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	internal IfcPropertyAbstraction(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcPropertyAbstraction other)
	{
		return this == other;
	}
}
