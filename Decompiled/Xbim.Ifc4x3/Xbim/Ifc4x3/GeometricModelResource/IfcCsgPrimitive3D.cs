using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcCsgPrimitive3D", 714)]
public abstract class IfcCsgPrimitive3D : Xbim.Ifc4x3.GeometryResource.IfcGeometricRepresentationItem, IfcBooleanOperand, IExpressSelectType, IPersist, IPersistEntity, IIfcBooleanOperand, IfcCsgSelect, IIfcCsgSelect, IEquatable<IfcCsgPrimitive3D>, IIfcCsgPrimitive3D, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, Xbim.Ifc4.GeometricModelResource.IfcCsgSelect
{
	private Xbim.Ifc4x3.GeometryResource.IfcAxis2Placement3D _position;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.GeometryResource.IfcAxis2Placement3D Position
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
			SetValue(delegate(Xbim.Ifc4x3.GeometryResource.IfcAxis2Placement3D v)
			{
				_position = v;
			}, _position, value, "Position", 1);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.GeometryResource.IfcDimensionCount Dim => 3L;

	[CrossSchemaAttribute(typeof(IIfcCsgPrimitive3D), 1)]
	IIfcAxis2Placement3D IIfcCsgPrimitive3D.Position
	{
		get
		{
			return Position;
		}
		set
		{
			Position = value as Xbim.Ifc4x3.GeometryResource.IfcAxis2Placement3D;
		}
	}

	Xbim.Ifc4.GeometryResource.IfcDimensionCount Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcCsgPrimitive3D(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_position = (Xbim.Ifc4x3.GeometryResource.IfcAxis2Placement3D)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcCsgPrimitive3D other)
	{
		return this == other;
	}
}
