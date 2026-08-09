using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcGridPlacement", 439)]
public class IfcGridPlacement : IfcObjectPlacement, IInstantiableEntity, IPersistEntity, IPersist, IIfcGridPlacement, IIfcObjectPlacement, IContainsEntityReferences, IEquatable<IfcGridPlacement>
{
	private IfcVirtualGridIntersection _placementLocation;

	private IfcGridPlacementDirectionSelect _placementRefDirection;

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

	IIfcGridPlacementDirectionSelect IIfcGridPlacement.PlacementRefDirection
	{
		get
		{
			return PlacementRefDirection;
		}
		set
		{
			PlacementRefDirection = value as IfcGridPlacementDirectionSelect;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
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
			}, _placementLocation, value, "PlacementLocation", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
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
			}, _placementRefDirection, value, "PlacementRefDirection", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
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

	internal IfcGridPlacement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_placementLocation = (IfcVirtualGridIntersection)value.EntityVal;
			break;
		case 1:
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
