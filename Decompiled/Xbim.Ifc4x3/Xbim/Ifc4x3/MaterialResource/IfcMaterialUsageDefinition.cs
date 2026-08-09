using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.MaterialResource;

[ExpressType("IfcMaterialUsageDefinition", 1211)]
public abstract class IfcMaterialUsageDefinition : PersistEntity, IIfcMaterialUsageDefinition, IPersistEntity, IPersist, Xbim.Ifc4.MaterialResource.IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcMaterialSelect, IEquatable<IfcMaterialUsageDefinition>
{
	IEnumerable<IIfcRelAssociatesMaterial> IIfcMaterialUsageDefinition.AssociatedTo => base.Model.Instances.Where((IIfcRelAssociatesMaterial e) => e.RelatingMaterial as IfcMaterialUsageDefinition == this, "RelatingMaterial", this);

	[InverseProperty("RelatingMaterial")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IEnumerable<IfcRelAssociatesMaterial> AssociatedTo => base.Model.Instances.Where((IfcRelAssociatesMaterial e) => Equals(e.RelatingMaterial), "RelatingMaterial", this);

	internal IfcMaterialUsageDefinition(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcMaterialUsageDefinition other)
	{
		return this == other;
	}
}
