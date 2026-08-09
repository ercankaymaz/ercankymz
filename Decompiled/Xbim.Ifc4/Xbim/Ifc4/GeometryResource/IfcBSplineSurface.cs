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

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcBSplineSurface", 1102)]
public abstract class IfcBSplineSurface : IfcBoundedSurface, IIfcBSplineSurface, IIfcBoundedSurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IEquatable<IfcBSplineSurface>
{
	private IfcInteger _uDegree;

	private IfcInteger _vDegree;

	private readonly ItemSet<IItemSet<IfcCartesianPoint>> _controlPointsList;

	private IfcBSplineSurfaceForm _surfaceForm;

	private IfcLogical _uClosed;

	private IfcLogical _vClosed;

	private IfcLogical _selfIntersect;

	IfcInteger IIfcBSplineSurface.UDegree
	{
		get
		{
			return UDegree;
		}
		set
		{
			UDegree = value;
		}
	}

	IfcInteger IIfcBSplineSurface.VDegree
	{
		get
		{
			return VDegree;
		}
		set
		{
			VDegree = value;
		}
	}

	IItemSet<IItemSet<IIfcCartesianPoint>> IIfcBSplineSurface.ControlPointsList => new ProxyNestedItemSet<IfcCartesianPoint, IIfcCartesianPoint>(ControlPointsList);

	IfcBSplineSurfaceForm IIfcBSplineSurface.SurfaceForm
	{
		get
		{
			return SurfaceForm;
		}
		set
		{
			SurfaceForm = value;
		}
	}

	IfcLogical IIfcBSplineSurface.UClosed
	{
		get
		{
			return UClosed;
		}
		set
		{
			UClosed = value;
		}
	}

	IfcLogical IIfcBSplineSurface.VClosed
	{
		get
		{
			return VClosed;
		}
		set
		{
			VClosed = value;
		}
	}

	IfcLogical IIfcBSplineSurface.SelfIntersect
	{
		get
		{
			return SelfIntersect;
		}
		set
		{
			SelfIntersect = value;
		}
	}

	IfcInteger IIfcBSplineSurface.UUpper => UUpper;

	IfcInteger IIfcBSplineSurface.VUpper => VUpper;

	List<List<XbimPoint3D>> IIfcBSplineSurface.ControlPoints => new List<List<XbimPoint3D>>(ControlPoints);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcInteger UDegree
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
			SetValue(delegate(IfcInteger v)
			{
				_uDegree = v;
			}, _uDegree, value, "UDegree", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcInteger VDegree
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
			SetValue(delegate(IfcInteger v)
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
	public IfcLogical UClosed
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
			SetValue(delegate(IfcLogical v)
			{
				_uClosed = v;
			}, _uClosed, value, "UClosed", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcLogical VClosed
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
			SetValue(delegate(IfcLogical v)
			{
				_vClosed = v;
			}, _vClosed, value, "VClosed", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcLogical SelfIntersect
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
			SetValue(delegate(IfcLogical v)
			{
				_selfIntersect = v;
			}, _selfIntersect, value, "SelfIntersect", 7);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcInteger UUpper => ControlPointsList.Count - 1;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcInteger VUpper => ControlPointsList[1].Count - 1;

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
