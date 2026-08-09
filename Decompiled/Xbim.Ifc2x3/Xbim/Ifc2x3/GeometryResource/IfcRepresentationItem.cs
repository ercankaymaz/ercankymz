using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc2x3.PresentationOrganizationResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcRepresentationItem", 31)]
public abstract class IfcRepresentationItem : PersistEntity, Xbim.Ifc2x3.PresentationOrganizationResource.IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IPersist, IPersistEntity, IEquatable<IfcRepresentationItem>, IIfcRepresentationItem, Xbim.Ifc4.PresentationOrganizationResource.IfcLayeredItem
{
	[InverseProperty("AssignedItems")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 1)]
	public IEnumerable<Xbim.Ifc2x3.PresentationOrganizationResource.IfcPresentationLayerAssignment> LayerAssignments => base.Model.Instances.Where((Xbim.Ifc2x3.PresentationOrganizationResource.IfcPresentationLayerAssignment e) => e.AssignedItems != null && e.AssignedItems.Contains(this), "AssignedItems", this);

	[InverseProperty("Item")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 2)]
	public IEnumerable<IfcStyledItem> StyledByItem => base.Model.Instances.Where((IfcStyledItem e) => Equals(e.Item), "Item", this);

	IEnumerable<IIfcPresentationLayerAssignment> IIfcRepresentationItem.LayerAssignment => base.Model.Instances.Where((IIfcPresentationLayerAssignment e) => e.AssignedItems != null && e.AssignedItems.Contains(this), "AssignedItems", this);

	IEnumerable<IIfcStyledItem> IIfcRepresentationItem.StyledByItem => base.Model.Instances.Where((IIfcStyledItem e) => e.Item as IfcRepresentationItem == this, "Item", this);

	internal IfcRepresentationItem(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcRepresentationItem other)
	{
		return this == other;
	}
}
