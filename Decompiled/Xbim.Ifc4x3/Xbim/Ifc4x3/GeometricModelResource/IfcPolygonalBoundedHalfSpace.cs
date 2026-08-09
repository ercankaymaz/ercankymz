using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcPolygonalBoundedHalfSpace", 623)]
public class IfcPolygonalBoundedHalfSpace : IfcHalfSpaceSolid, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcPolygonalBoundedHalfSpace>, IIfcPolygonalBoundedHalfSpace, IIfcHalfSpaceSolid, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand
{
	private IfcAxis2Placement3D _position;

	private IfcBoundedCurve _polygonalBoundary;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcAxis2Placement3D Position
	{
		get
		{
			if (_activated)
			{
				return _position;
			}
			Activate();
			return _position;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement3D v)
			{
				_position = v;
			}, _position, value, "Position", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcBoundedCurve PolygonalBoundary
	{
		get
		{
			if (_activated)
			{
				return _polygonalBoundary;
			}
			Activate();
			return _polygonalBoundary;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcBoundedCurve v)
			{
				_polygonalBoundary = v;
			}, _polygonalBoundary, value, "PolygonalBoundary", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.BaseSurface != null)
			{
				yield return base.BaseSurface;
			}
			if (Position != null)
			{
				yield return Position;
			}
			if (PolygonalBoundary != null)
			{
				yield return PolygonalBoundary;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPolygonalBoundedHalfSpace), 3)]
	IIfcAxis2Placement3D IIfcPolygonalBoundedHalfSpace.Position
	{
		get
		{
			return Position;
		}
		set
		{
			Position = value as IfcAxis2Placement3D;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPolygonalBoundedHalfSpace), 4)]
	IIfcBoundedCurve IIfcPolygonalBoundedHalfSpace.PolygonalBoundary
	{
		get
		{
			return PolygonalBoundary;
		}
		set
		{
			PolygonalBoundary = value as IfcBoundedCurve;
		}
	}

	internal IfcPolygonalBoundedHalfSpace(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_position = (IfcAxis2Placement3D)value.EntityVal;
			break;
		case 3:
			_polygonalBoundary = (IfcBoundedCurve)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPolygonalBoundedHalfSpace other)
	{
		return this == other;
	}
}
