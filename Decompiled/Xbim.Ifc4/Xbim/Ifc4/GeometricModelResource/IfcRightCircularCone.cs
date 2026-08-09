using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcRightCircularCone", 703)]
public class IfcRightCircularCone : IfcCsgPrimitive3D, IInstantiableEntity, IPersistEntity, IPersist, IIfcRightCircularCone, IIfcCsgPrimitive3D, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcCsgSelect, IIfcCsgSelect, IContainsEntityReferences, IEquatable<IfcRightCircularCone>
{
	private IfcPositiveLengthMeasure _height;

	private IfcPositiveLengthMeasure _bottomRadius;

	IfcPositiveLengthMeasure IIfcRightCircularCone.Height
	{
		get
		{
			return Height;
		}
		set
		{
			Height = value;
		}
	}

	IfcPositiveLengthMeasure IIfcRightCircularCone.BottomRadius
	{
		get
		{
			return BottomRadius;
		}
		set
		{
			BottomRadius = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPositiveLengthMeasure Height
	{
		get
		{
			if (_activated)
			{
				return _height;
			}
			Activate();
			return _height;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_height = v;
			}, _height, value, "Height", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveLengthMeasure BottomRadius
	{
		get
		{
			if (_activated)
			{
				return _bottomRadius;
			}
			Activate();
			return _bottomRadius;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_bottomRadius = v;
			}, _bottomRadius, value, "BottomRadius", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Position != null)
			{
				yield return base.Position;
			}
		}
	}

	internal IfcRightCircularCone(IModel model, int label, bool activated)
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
			_height = value.RealVal;
			break;
		case 2:
			_bottomRadius = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRightCircularCone other)
	{
		return this == other;
	}
}
