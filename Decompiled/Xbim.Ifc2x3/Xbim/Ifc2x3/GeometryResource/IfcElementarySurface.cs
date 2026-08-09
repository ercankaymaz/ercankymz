using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcElementarySurface", 389)]
public abstract class IfcElementarySurface : IfcSurface, IEquatable<IfcElementarySurface>, IIfcElementarySurface, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface
{
	private IfcAxis2Placement3D _position;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
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
			}, _position, value, "Position", 1);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public override IfcDimensionCount Dim => Position.Dim;

	[CrossSchemaAttribute(typeof(IIfcElementarySurface), 1)]
	IIfcAxis2Placement3D IIfcElementarySurface.Position
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

	internal IfcElementarySurface(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_position = (IfcAxis2Placement3D)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcElementarySurface other)
	{
		return this == other;
	}
}
