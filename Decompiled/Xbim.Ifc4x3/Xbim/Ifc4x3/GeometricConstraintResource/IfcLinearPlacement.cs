using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.GeometricConstraintResource;

[ExpressType("IfcLinearPlacement", 1349)]
public class IfcLinearPlacement : IfcObjectPlacement, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcLinearPlacement>, IIfcLinearPlacement, IIfcObjectPlacement
{
	private IfcAxis2PlacementLinear _relativePlacement;

	private IfcAxis2Placement3D _cartesianPosition;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcAxis2PlacementLinear RelativePlacement
	{
		get
		{
			if (_activated)
			{
				return _relativePlacement;
			}
			Activate();
			return _relativePlacement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2PlacementLinear v)
			{
				_relativePlacement = v;
			}, _relativePlacement, value, "RelativePlacement", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
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
			}, _cartesianPosition, value, "CartesianPosition", 3);
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
			if (RelativePlacement != null)
			{
				yield return RelativePlacement;
			}
			if (CartesianPosition != null)
			{
				yield return CartesianPosition;
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

	[CrossSchemaAttribute(typeof(IIfcLinearPlacement), 1)]
	IIfcCurve IIfcLinearPlacement.PlacementRelTo
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLinearPlacement), 2)]
	IIfcDistanceExpression IIfcLinearPlacement.Distance
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLinearPlacement), 3)]
	IIfcOrientationExpression IIfcLinearPlacement.Orientation
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLinearPlacement), 4)]
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

	internal IfcLinearPlacement(IModel model, int label, bool activated)
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
			_relativePlacement = (IfcAxis2PlacementLinear)value.EntityVal;
			break;
		case 2:
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
