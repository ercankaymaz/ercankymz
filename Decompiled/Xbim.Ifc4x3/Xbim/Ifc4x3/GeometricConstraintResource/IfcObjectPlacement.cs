using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.GeometricConstraintResource;

[ExpressType("IfcObjectPlacement", 440)]
public abstract class IfcObjectPlacement : PersistEntity, IEquatable<IfcObjectPlacement>, IIfcObjectPlacement, IPersistEntity, IPersist
{
	private IfcObjectPlacement _placementRelTo;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcObjectPlacement PlacementRelTo
	{
		get
		{
			if (_activated)
			{
				return _placementRelTo;
			}
			Activate();
			return _placementRelTo;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcObjectPlacement v)
			{
				_placementRelTo = v;
			}, _placementRelTo, value, "PlacementRelTo", 1);
		}
	}

	[InverseProperty("ObjectPlacement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 2)]
	public IEnumerable<IfcProduct> PlacesObject => base.Model.Instances.Where((IfcProduct e) => Equals(e.ObjectPlacement), "ObjectPlacement", this);

	[InverseProperty("PlacementRelTo")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 3)]
	public IEnumerable<IfcObjectPlacement> ReferencedByPlacements => base.Model.Instances.Where((IfcObjectPlacement e) => Equals(e.PlacementRelTo), "PlacementRelTo", this);

	IEnumerable<IIfcProduct> IIfcObjectPlacement.PlacesObject => base.Model.Instances.Where((IIfcProduct e) => e.ObjectPlacement as IfcObjectPlacement == this, "ObjectPlacement", this);

	IEnumerable<IIfcLocalPlacement> IIfcObjectPlacement.ReferencedByPlacements => base.Model.Instances.Where((IIfcLocalPlacement e) => e.PlacementRelTo as IfcObjectPlacement == this, "PlacementRelTo", this);

	internal IfcObjectPlacement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_placementRelTo = (IfcObjectPlacement)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcObjectPlacement other)
	{
		return this == other;
	}
}
