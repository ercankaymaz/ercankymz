using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcRepresentationItem", 31)]
public abstract class IfcRepresentationItem : PersistEntity, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcRepresentationItem>
{
	IEnumerable<IIfcPresentationLayerAssignment> IIfcRepresentationItem.LayerAssignment => LayerAssignment;

	IEnumerable<IIfcStyledItem> IIfcRepresentationItem.StyledByItem => StyledByItem;

	[InverseProperty("AssignedItems")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 1)]
	public IEnumerable<IfcPresentationLayerAssignment> LayerAssignment => base.Model.Instances.Where((IfcPresentationLayerAssignment e) => e.AssignedItems != null && e.AssignedItems.Contains(this), "AssignedItems", this);

	[InverseProperty("Item")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 2)]
	public IEnumerable<IfcStyledItem> StyledByItem => base.Model.Instances.Where((IfcStyledItem e) => Equals(e.Item), "Item", this);

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
