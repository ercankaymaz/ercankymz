using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterialDefinition", 1203)]
public abstract class IfcMaterialDefinition : PersistEntity, IIfcMaterialDefinition, IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IEquatable<IfcMaterialDefinition>
{
	IEnumerable<IIfcRelAssociatesMaterial> IIfcMaterialDefinition.AssociatedTo => AssociatedTo;

	IEnumerable<IIfcExternalReferenceRelationship> IIfcMaterialDefinition.HasExternalReferences => HasExternalReferences;

	IEnumerable<IIfcMaterialProperties> IIfcMaterialDefinition.HasProperties => HasProperties;

	[InverseProperty("RelatingMaterial")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 1)]
	public IEnumerable<IfcRelAssociatesMaterial> AssociatedTo => base.Model.Instances.Where((IfcRelAssociatesMaterial e) => Equals(e.RelatingMaterial), "RelatingMaterial", this);

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 2)]
	public IEnumerable<IfcExternalReferenceRelationship> HasExternalReferences => base.Model.Instances.Where((IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[InverseProperty("Material")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 3)]
	public IEnumerable<IfcMaterialProperties> HasProperties => base.Model.Instances.Where((IfcMaterialProperties e) => Equals(e.Material), "Material", this);

	internal IfcMaterialDefinition(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcMaterialDefinition other)
	{
		return this == other;
	}
}
