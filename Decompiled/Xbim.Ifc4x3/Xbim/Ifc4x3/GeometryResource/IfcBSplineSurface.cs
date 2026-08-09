using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Common.Geometry;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcBSplineSurface", 1102)]
public abstract class IfcBSplineSurface : IfcBoundedSurface, IEquatable<IfcBSplineSurface>, IIfcBSplineSurface, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface
{
	private Xbim.Ifc4x3.MeasureResource.IfcInteger _uDegree;

	private Xbim.Ifc4x3.MeasureResource.IfcInteger _vDegree;

	private readonly ItemSet<IItemSet<IfcCartesianPoint>> _controlPointsList;

	private IfcBSplineSurfaceForm _surfaceForm;

	private Xbim.Ifc4x3.MeasureResource.IfcLogical _uClosed;

	private Xbim.Ifc4x3.MeasureResource.IfcLogical _vClosed;

	private Xbim.Ifc4x3.MeasureResource.IfcLogical _selfIntersect;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger UDegree
	{
		get
		{
			if (_activated)
			{
				return _uDegree;
			}
			Activate();
			return _uDegree;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcInteger v)
			{
				_uDegree = v;
			}, _uDegree, value, "UDegree", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger VDegree
	{
		get
		{
			if (_activated)
			{
				return _vDegree;
			}
			Activate();
			return _vDegree;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcInteger v)
			{
				_vDegree = v;
			}, _vDegree, value, "VDegree", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 2, 2 }, new int[] { -1, -1 }, 5)]
	public IItemSet<IItemSet<IfcCartesianPoint>> ControlPointsList
	{
		get
		{
			if (_activated)
			{
				return _controlPointsList;
			}
			Activate();
			return _controlPointsList;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 6)]
	public IfcBSplineSurfaceForm SurfaceForm
	{
		get
		{
			if (_activated)
			{
				return _surfaceForm;
			}
			Activate();
			return _surfaceForm;
		}
		set
		{
			SetValue(delegate(IfcBSplineSurfaceForm v)
			{
				_surfaceForm = v;
			}, _surfaceForm, value, "SurfaceForm", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcLogical UClosed
	{
		get
		{
			if (_activated)
			{
				return _uClosed;
			}
			Activate();
			return _uClosed;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLogical v)
			{
				_uClosed = v;
			}, _uClosed, value, "UClosed", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcLogical VClosed
	{
		get
		{
			if (_activated)
			{
				return _vClosed;
			}
			Activate();
			return _vClosed;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLogical v)
			{
				_vClosed = v;
			}, _vClosed, value, "VClosed", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcLogical SelfIntersect
	{
		get
		{
			if (_activated)
			{
				return _selfIntersect;
			}
			Activate();
			return _selfIntersect;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLogical v)
			{
				_selfIntersect = v;
			}, _selfIntersect, value, "SelfIntersect", 7);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger UUpper => ControlPointsList.Count - 1;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger VUpper => ControlPointsList[1].Count - 1;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Array, EntityAttributeType.Array, new int[] { 0, 0 }, new int[] { -1, -1 }, 0)]
	public List<List<XbimPoint3D>> ControlPoints
	{
		get
		{
			List<List<XbimPoint3D>> list = new List<List<XbimPoint3D>>();
			foreach (IItemSet<IfcCartesianPoint> controlPoints in ControlPointsList)
			{
				List<XbimPoint3D> list2 = new List<XbimPoint3D>();
				list.Add(list2);
				list2.AddRange(controlPoints.Select((IfcCartesianPoint point) => new XbimPoint3D(point.X, point.Y, point.Z)));
			}
			return list;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBSplineSurface), 1)]
	Xbim.Ifc4.MeasureResource.IfcInteger IIfcBSplineSurface.UDegree
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcInteger(UDegree);
		}
		set
		{
			UDegree = new Xbim.Ifc4x3.MeasureResource.IfcInteger(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBSplineSurface), 2)]
	Xbim.Ifc4.MeasureResource.IfcInteger IIfcBSplineSurface.VDegree
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcInteger(VDegree);
		}
		set
		{
			VDegree = new Xbim.Ifc4x3.MeasureResource.IfcInteger(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBSplineSurface), 3)]
	IItemSet<IItemSet<IIfcCartesianPoint>> IIfcBSplineSurface.ControlPointsList => new ProxyNestedItemSet<IfcCartesianPoint, IIfcCartesianPoint>(ControlPointsList);

	[CrossSchemaAttribute(typeof(IIfcBSplineSurface), 4)]
	Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm IIfcBSplineSurface.SurfaceForm
	{
		get
		{
			return SurfaceForm switch
			{
				IfcBSplineSurfaceForm.CONICAL_SURF => Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.CONICAL_SURF, 
				IfcBSplineSurfaceForm.CYLINDRICAL_SURF => Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.CYLINDRICAL_SURF, 
				IfcBSplineSurfaceForm.GENERALISED_CONE => Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.GENERALISED_CONE, 
				IfcBSplineSurfaceForm.PLANE_SURF => Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.PLANE_SURF, 
				IfcBSplineSurfaceForm.QUADRIC_SURF => Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.QUADRIC_SURF, 
				IfcBSplineSurfaceForm.RULED_SURF => Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.RULED_SURF, 
				IfcBSplineSurfaceForm.SPHERICAL_SURF => Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.SPHERICAL_SURF, 
				IfcBSplineSurfaceForm.SURF_OF_LINEAR_EXTRUSION => Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.SURF_OF_LINEAR_EXTRUSION, 
				IfcBSplineSurfaceForm.SURF_OF_REVOLUTION => Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.SURF_OF_REVOLUTION, 
				IfcBSplineSurfaceForm.TOROIDAL_SURF => Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.TOROIDAL_SURF, 
				IfcBSplineSurfaceForm.UNSPECIFIED => Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.UNSPECIFIED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.PLANE_SURF:
				SurfaceForm = IfcBSplineSurfaceForm.PLANE_SURF;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.CYLINDRICAL_SURF:
				SurfaceForm = IfcBSplineSurfaceForm.CYLINDRICAL_SURF;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.CONICAL_SURF:
				SurfaceForm = IfcBSplineSurfaceForm.CONICAL_SURF;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.SPHERICAL_SURF:
				SurfaceForm = IfcBSplineSurfaceForm.SPHERICAL_SURF;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.TOROIDAL_SURF:
				SurfaceForm = IfcBSplineSurfaceForm.TOROIDAL_SURF;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.SURF_OF_REVOLUTION:
				SurfaceForm = IfcBSplineSurfaceForm.SURF_OF_REVOLUTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.RULED_SURF:
				SurfaceForm = IfcBSplineSurfaceForm.RULED_SURF;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.GENERALISED_CONE:
				SurfaceForm = IfcBSplineSurfaceForm.GENERALISED_CONE;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.QUADRIC_SURF:
				SurfaceForm = IfcBSplineSurfaceForm.QUADRIC_SURF;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.SURF_OF_LINEAR_EXTRUSION:
				SurfaceForm = IfcBSplineSurfaceForm.SURF_OF_LINEAR_EXTRUSION;
				break;
			case Xbim.Ifc4.Interfaces.IfcBSplineSurfaceForm.UNSPECIFIED:
				SurfaceForm = IfcBSplineSurfaceForm.UNSPECIFIED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBSplineSurface), 5)]
	Xbim.Ifc4.MeasureResource.IfcLogical IIfcBSplineSurface.UClosed
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLogical(UClosed);
		}
		set
		{
			UClosed = new Xbim.Ifc4x3.MeasureResource.IfcLogical(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBSplineSurface), 6)]
	Xbim.Ifc4.MeasureResource.IfcLogical IIfcBSplineSurface.VClosed
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLogical(VClosed);
		}
		set
		{
			VClosed = new Xbim.Ifc4x3.MeasureResource.IfcLogical(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcBSplineSurface), 7)]
	Xbim.Ifc4.MeasureResource.IfcLogical IIfcBSplineSurface.SelfIntersect
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLogical(SelfIntersect);
		}
		set
		{
			SelfIntersect = new Xbim.Ifc4x3.MeasureResource.IfcLogical(value);
		}
	}

	Xbim.Ifc4.MeasureResource.IfcInteger IIfcBSplineSurface.UUpper => new Xbim.Ifc4.MeasureResource.IfcInteger(UUpper);

	Xbim.Ifc4.MeasureResource.IfcInteger IIfcBSplineSurface.VUpper => new Xbim.Ifc4.MeasureResource.IfcInteger(VUpper);

	List<List<XbimPoint3D>> IIfcBSplineSurface.ControlPoints => ControlPoints;

	internal IfcBSplineSurface(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_controlPointsList = new ItemSet<IItemSet<IfcCartesianPoint>>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_uDegree = value.IntegerVal;
			break;
		case 1:
			_vDegree = value.IntegerVal;
			break;
		case 2:
			((ItemSet<IfcCartesianPoint>)_controlPointsList.InternalGetAt(nestedIndex[0])).InternalAdd((IfcCartesianPoint)value.EntityVal);
			break;
		case 3:
			_surfaceForm = (IfcBSplineSurfaceForm)Enum.Parse(typeof(IfcBSplineSurfaceForm), value.EnumVal, ignoreCase: true);
			break;
		case 4:
			_uClosed = value.BooleanVal;
			break;
		case 5:
			_vClosed = value.BooleanVal;
			break;
		case 6:
			_selfIntersect = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcBSplineSurface other)
	{
		return this == other;
	}
}
