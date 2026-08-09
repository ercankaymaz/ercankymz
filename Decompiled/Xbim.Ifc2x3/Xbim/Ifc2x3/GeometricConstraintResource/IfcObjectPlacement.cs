using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.GeometricConstraintResource;

[ExpressType("IfcObjectPlacement", 440)]
public abstract class IfcObjectPlacement : PersistEntity, IEquatable<IfcObjectPlacement>, IIfcObjectPlacement, IPersistEntity, IPersist
{
	[InverseProperty("ObjectPlacement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { 1 }, 1)]
	public IEnumerable<IfcProduct> PlacesObject => base.Model.Instances.Where((IfcProduct e) => Equals(e.ObjectPlacement), "ObjectPlacement", this);

	[InverseProperty("PlacementRelTo")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 2)]
	public IEnumerable<IfcLocalPlacement> ReferencedByPlacements => base.Model.Instances.Where((IfcLocalPlacement e) => Equals(e.PlacementRelTo), "PlacementRelTo", this);

	IEnumerable<IIfcProduct> IIfcObjectPlacement.PlacesObject => base.Model.Instances.Where((IIfcProduct e) => e.ObjectPlacement as IfcObjectPlacement == this, "ObjectPlacement", this);

	IEnumerable<IIfcLocalPlacement> IIfcObjectPlacement.ReferencedByPlacements => base.Model.Instances.Where((IIfcLocalPlacement e) => e.PlacementRelTo as IfcObjectPlacement == this, "PlacementRelTo", this);

	internal IfcObjectPlacement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcObjectPlacement other)
	{
		return this == other;
	}
}
