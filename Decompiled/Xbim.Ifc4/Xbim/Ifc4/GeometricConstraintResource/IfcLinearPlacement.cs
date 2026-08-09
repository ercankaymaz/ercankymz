using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcLinearPlacement", 1349)]
public class IfcLinearPlacement : IfcObjectPlacement, IInstantiableEntity, IPersistEntity, IPersist, IIfcLinearPlacement, IIfcObjectPlacement, IContainsEntityReferences, IEquatable<IfcLinearPlacement>
{
	private IfcCurve _placementRelTo;

	private IfcDistanceExpression _distance;

	private IfcOrientationExpression _orientation;

	private IfcAxis2Placement3D _cartesianPosition;

	IIfcCurve IIfcLinearPlacement.PlacementRelTo
	{
		get
		{
			return PlacementRelTo;
		}
		set
		{
			PlacementRelTo = value as IfcCurve;
		}
	}

	IIfcDistanceExpression IIfcLinearPlacement.Distance
	{
		get
		{
			return Distance;
		}
		set
		{
			Distance = value as IfcDistanceExpression;
		}
	}

	IIfcOrientationExpression IIfcLinearPlacement.Orientation
	{
		get
		{
			return Orientation;
		}
		set
		{
			Orientation = value as IfcOrientationExpression;
		}
	}

	IIfcAxis2Placement3D IIfcLinearPlacement.CartesianPosition
	{
		get
		{
			return CartesianPosition;
		}
		set
		{
			CartesianPosition = value as IfcAxis2Placement3D;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCurve PlacementRelTo
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
			SetValue(delegate(IfcCurve v)
			{
				_placementRelTo = v;
			}, _placementRelTo, value, "PlacementRelTo", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcDistanceExpression Distance
	{
		get
		{
			if (_activated)
			{
				return _distance;
			}
			Activate();
			return _distance;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDistanceExpression v)
			{
				_distance = v;
			}, _distance, value, "Distance", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcOrientationExpression Orientation
	{
		get
		{
			if (_activated)
			{
				return _orientation;
			}
			Activate();
			return _orientation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcOrientationExpression v)
			{
				_orientation = v;
			}, _orientation, value, "Orientation", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcAxis2Placement3D CartesianPosition
	{
		get
		{
			if (_activated)
			{
				return _cartesianPosition;
			}
			Activate();
			return _cartesianPosition;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement3D v)
			{
				_cartesianPosition = v;
			}, _cartesianPosition, value, "CartesianPosition", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (PlacementRelTo != null)
			{
				yield return PlacementRelTo;
			}
			if (Distance != null)
			{
				yield return Distance;
			}
			if (Orientation != null)
			{
				yield return Orientation;
			}
			if (CartesianPosition != null)
			{
				yield return CartesianPosition;
			}
		}
	}

	internal IfcLinearPlacement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_placementRelTo = (IfcCurve)value.EntityVal;
			break;
		case 1:
			_distance = (IfcDistanceExpression)value.EntityVal;
			break;
		case 2:
			_orientation = (IfcOrientationExpression)value.EntityVal;
			break;
		case 3:
			_cartesianPosition = (IfcAxis2Placement3D)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLinearPlacement other)
	{
		return this == other;
	}
}
