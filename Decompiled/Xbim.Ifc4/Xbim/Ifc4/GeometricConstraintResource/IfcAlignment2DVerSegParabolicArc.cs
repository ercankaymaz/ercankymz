using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcAlignment2DVerSegParabolicArc", 1337)]
public class IfcAlignment2DVerSegParabolicArc : IfcAlignment2DVerticalSegment, IInstantiableEntity, IPersistEntity, IPersist, IIfcAlignment2DVerSegParabolicArc, IIfcAlignment2DVerticalSegment, IIfcAlignment2DSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcAlignment2DVerSegParabolicArc>
{
	private IfcPositiveLengthMeasure _parabolaConstant;

	private IfcBoolean _isConvex;

	IfcPositiveLengthMeasure IIfcAlignment2DVerSegParabolicArc.ParabolaConstant
	{
		get
		{
			return ParabolaConstant;
		}
		set
		{
			ParabolaConstant = value;
		}
	}

	IfcBoolean IIfcAlignment2DVerSegParabolicArc.IsConvex
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
	public IfcPositiveLengthMeasure ParabolaConstant
	{
		get
		{
			if (_activated)
			{
				return _parabolaConstant;
			}
			Activate();
			return _parabolaConstant;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_parabolaConstant = v;
			}, _parabolaConstant, value, "ParabolaConstant", 8);
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

	internal IfcAlignment2DVerSegParabolicArc(IModel model, int label, bool activated)
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
			_parabolaConstant = value.RealVal;
			break;
		case 8:
			_isConvex = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlignment2DVerSegParabolicArc other)
	{
		return this == other;
	}
}
