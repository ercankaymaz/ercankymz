using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.GeometricConstraintResource;

[ExpressType("IfcGridPlacement", 439)]
public class IfcGridPlacement : IfcObjectPlacement, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcGridPlacement>, IIfcGridPlacement, IIfcObjectPlacement
{
	private IfcVirtualGridIntersection _placementLocation;

	private IfcGridPlacementDirectionSelect _placementRefDirection;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcVirtualGridIntersection PlacementLocation
	{
		get
		{
			if (_activated)
			{
				return _placementLocation;
			}
			Activate();
			return _placementLocation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcVirtualGridIntersection v)
			{
				_placementLocation = v;
			}, _placementLocation, value, "PlacementLocation", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcGridPlacementDirectionSelect PlacementRefDirection
	{
		get
		{
			if (_activated)
			{
				return _placementRefDirection;
			}
			Activate();
			return _placementRefDirection;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcGridPlacementDirectionSelect v)
			{
				_placementRefDirection = v;
			}, _placementRefDirection, value, "PlacementRefDirection", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.PlacementRelTo != null)
			{
				yield return base.PlacementRelTo;
			}
			if (PlacementLocation != null)
			{
				yield return PlacementLocation;
			}
			if (PlacementRefDirection != null)
			{
				yield return PlacementRefDirection;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.PlacementRelTo != null)
			{
				yield return base.PlacementRelTo;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGridPlacement), 1)]
	IIfcVirtualGridIntersection IIfcGridPlacement.PlacementLocation
	{
		get
		{
			return PlacementLocation;
		}
		set
		{
			PlacementLocation = value as IfcVirtualGridIntersection;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGridPlacement), 2)]
	IIfcGridPlacementDirectionSelect IIfcGridPlacement.PlacementRefDirection
	{
		get
		{
			if (PlacementRefDirection == null)
			{
				return null;
			}
			IfcDirection ifcDirection = PlacementRefDirection as IfcDirection;
			if (ifcDirection != null)
			{
				return ifcDirection;
			}
			IfcVirtualGridIntersection ifcVirtualGridIntersection = PlacementRefDirection as IfcVirtualGridIntersection;
			if (ifcVirtualGridIntersection != null)
			{
				return ifcVirtualGridIntersection;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				PlacementRefDirection = null;
				return;
			}
			IfcDirection ifcDirection = value as IfcDirection;
			if (ifcDirection != null)
			{
				PlacementRefDirection = ifcDirection;
				return;
			}
			IfcVirtualGridIntersection ifcVirtualGridIntersection = value as IfcVirtualGridIntersection;
			if (ifcVirtualGridIntersection != null)
			{
				PlacementRefDirection = ifcVirtualGridIntersection;
			}
		}
	}

	internal IfcGridPlacement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_placementLocation = (IfcVirtualGridIntersection)value.EntityVal;
			break;
		case 2:
			_placementRefDirection = (IfcGridPlacementDirectionSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcGridPlacement other)
	{
		return this == other;
	}
}
