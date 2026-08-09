using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.ProfileResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcSweptAreaSolid", 239)]
public abstract class IfcSweptAreaSolid : IfcSolidModel, IEquatable<IfcSweptAreaSolid>, IIfcSweptAreaSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private IfcProfileDef _sweptArea;

	private IfcAxis2Placement3D _position;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcProfileDef SweptArea
	{
		get
		{
			if (_activated)
			{
				return _sweptArea;
			}
			Activate();
			return _sweptArea;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProfileDef v)
			{
				_sweptArea = v;
			}, _sweptArea, value, "SweptArea", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
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
			}, _position, value, "Position", 2);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSweptAreaSolid), 1)]
	IIfcProfileDef IIfcSweptAreaSolid.SweptArea
	{
		get
		{
			return SweptArea;
		}
		set
		{
			SweptArea = value as IfcProfileDef;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSweptAreaSolid), 2)]
	IIfcAxis2Placement3D IIfcSweptAreaSolid.Position
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

	internal IfcSweptAreaSolid(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_sweptArea = (IfcProfileDef)value.EntityVal;
			break;
		case 1:
			_position = (IfcAxis2Placement3D)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSweptAreaSolid other)
	{
		return this == other;
	}
}
