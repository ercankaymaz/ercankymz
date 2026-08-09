using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcObjectPlacement", 440)]
public abstract class IfcObjectPlacement : PersistEntity, IIfcObjectPlacement, IPersistEntity, IPersist, IEquatable<IfcObjectPlacement>
{
	IEnumerable<IIfcProduct> IIfcObjectPlacement.PlacesObject => PlacesObject;

	IEnumerable<IIfcLocalPlacement> IIfcObjectPlacement.ReferencedByPlacements => ReferencedByPlacements;

	[InverseProperty("ObjectPlacement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 1)]
	public IEnumerable<IfcProduct> PlacesObject => base.Model.Instances.Where((IfcProduct e) => Equals(e.ObjectPlacement), "ObjectPlacement", this);

	[InverseProperty("PlacementRelTo")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 2)]
	public IEnumerable<IfcLocalPlacement> ReferencedByPlacements => base.Model.Instances.Where((IfcLocalPlacement e) => Equals(e.PlacementRelTo), "PlacementRelTo", this);

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
