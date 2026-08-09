using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.Geometry;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcPlacement", 281)]
public abstract class IfcPlacement : IfcGeometricRepresentationItem, IEquatable<IfcPlacement>, IIfcPlacement, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private IfcCartesianPoint _location;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCartesianPoint Location
	{
		get
		{
			if (_activated)
			{
				return _location;
			}
			Activate();
			return _location;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPoint v)
			{
				_location = v;
			}, _location, value, "Location", 1);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcDimensionCount Dim
	{
		get
		{
			if (!(Location == null))
			{
				return Location.Dim;
			}
			return 0L;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPlacement), 1)]
	IIfcCartesianPoint IIfcPlacement.Location
	{
		get
		{
			return Location;
		}
		set
		{
			Location = value as IfcCartesianPoint;
		}
	}

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcPlacement.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcPlacement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_location = (IfcCartesianPoint)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcPlacement other)
	{
		return this == other;
	}

	public XbimMatrix3D ToMatrix3D()
	{
		IfcAxis2Placement3D ifcAxis2Placement3D = this as IfcAxis2Placement3D;
		if (ifcAxis2Placement3D != null)
		{
			return ifcAxis2Placement3D.ToMatrix3D();
		}
		IfcAxis2Placement2D ifcAxis2Placement2D = this as IfcAxis2Placement2D;
		if (!(ifcAxis2Placement2D != null))
		{
			return XbimMatrix3D.Identity;
		}
		return ifcAxis2Placement2D.ToMatrix3D();
	}
}
