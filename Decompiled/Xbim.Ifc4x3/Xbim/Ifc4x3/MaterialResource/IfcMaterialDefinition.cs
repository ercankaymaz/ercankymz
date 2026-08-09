using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4x3.ExternalReferenceResource;
using Xbim.Ifc4x3.ProductExtension;
using Xbim.Ifc4x3.PropertyResource;

namespace Xbim.Ifc4x3.MaterialResource;

[ExpressType("IfcMaterialDefinition", 1203)]
public abstract class IfcMaterialDefinition : PersistEntity, IIfcMaterialDefinition, IPersistEntity, IPersist, Xbim.Ifc4.MaterialResource.IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect, IIfcResourceObjectSelect, IfcMaterialSelect, Xbim.Ifc4x3.PropertyResource.IfcObjectReferenceSelect, Xbim.Ifc4x3.ExternalReferenceResource.IfcResourceObjectSelect, IEquatable<IfcMaterialDefinition>
{
	IEnumerable<IIfcRelAssociatesMaterial> IIfcMaterialDefinition.AssociatedTo => base.Model.Instances.Where((IIfcRelAssociatesMaterial e) => e.RelatingMaterial as IfcMaterialDefinition == this, "RelatingMaterial", this);

	IEnumerable<IIfcExternalReferenceRelationship> IIfcMaterialDefinition.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	IEnumerable<IIfcMaterialProperties> IIfcMaterialDefinition.HasProperties => base.Model.Instances.Where((IIfcMaterialProperties e) => e.Material as IfcMaterialDefinition == this, "Material", this);

	[InverseProperty("RelatingMaterial")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 1)]
	public IEnumerable<IfcRelAssociatesMaterial> AssociatedTo => base.Model.Instances.Where((IfcRelAssociatesMaterial e) => Equals(e.RelatingMaterial), "RelatingMaterial", this);

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 2)]
	public IEnumerable<Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship> HasExternalReferences => base.Model.Instances.Where((Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

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
