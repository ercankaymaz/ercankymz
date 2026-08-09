using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.GeometricConstraintResource;

[ExpressType("IfcGridPlacement", 439)]
public class IfcGridPlacement : IfcObjectPlacement, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcGridPlacement>, IIfcGridPlacement, IIfcObjectPlacement
{
	private IfcVirtualGridIntersection _placementLocation;

	private IfcVirtualGridIntersection _placementRefDirection;

	private IIfcGridPlacementDirectionSelect _placementRefDirection4;

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
	public IfcVirtualGridIntersection PlacementRefDirection
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
			SetValue(delegate(IfcVirtualGridIntersection v)
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
			return _placementRefDirection4 ?? PlacementRefDirection;
		}
		set
		{
			if (value == null)
			{
				PlacementRefDirection = null;
				if (_placementRefDirection4 != null)
				{
					SetValue(delegate(IIfcGridPlacementDirectionSelect v)
					{
						_placementRefDirection4 = v;
					}, _placementRefDirection4, null, "PlacementRefDirection", -2);
				}
				return;
			}
			IfcVirtualGridIntersection ifcVirtualGridIntersection = value as IfcVirtualGridIntersection;
			if (ifcVirtualGridIntersection != null)
			{
				PlacementRefDirection = ifcVirtualGridIntersection;
				if (_placementRefDirection4 != null)
				{
					SetValue(delegate(IIfcGridPlacementDirectionSelect v)
					{
						_placementRefDirection4 = v;
					}, _placementRefDirection4, null, "PlacementRefDirection", -2);
				}
			}
			else
			{
				if (PlacementRefDirection != null)
				{
					PlacementRefDirection = null;
				}
				SetValue(delegate(IIfcGridPlacementDirectionSelect v)
				{
					_placementRefDirection4 = v;
				}, _placementRefDirection4, value, "PlacementRefDirection", -2);
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
			_placementRefDirection = (IfcVirtualGridIntersection)value.EntityVal;
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
