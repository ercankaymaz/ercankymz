using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcAlignment2DVerSegCircularArc", 1335)]
public class IfcAlignment2DVerSegCircularArc : IfcAlignment2DVerticalSegment, IInstantiableEntity, IPersistEntity, IPersist, IIfcAlignment2DVerSegCircularArc, IIfcAlignment2DVerticalSegment, IIfcAlignment2DSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcAlignment2DVerSegCircularArc>
{
	private IfcPositiveLengthMeasure _radius;

	private IfcBoolean _isConvex;

	IfcPositiveLengthMeasure IIfcAlignment2DVerSegCircularArc.Radius
	{
		get
		{
			return Radius;
		}
		set
		{
			Radius = value;
		}
	}

	IfcBoolean IIfcAlignment2DVerSegCircularArc.IsConvex
	{
		get
		{
			return IsConvex;
		}
		set
		{
			IsConvex = value;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcPositiveLengthMeasure Radius
	{
		get
		{
			if (_activated)
			{
				return _radius;
			}
			Activate();
			return _radius;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_radius = v;
			}, _radius, value, "Radius", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcBoolean IsConvex
	{
		get
		{
			if (_activated)
			{
				return _isConvex;
			}
			Activate();
			return _isConvex;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_isConvex = v;
			}, _isConvex, value, "IsConvex", 9);
		}
	}

	internal IfcAlignment2DVerSegCircularArc(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_radius = value.RealVal;
			break;
		case 8:
			_isConvex = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlignment2DVerSegCircularArc other)
	{
		return this == other;
	}
}
