using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcCircularArcSegment2D", 1340)]
public class IfcCircularArcSegment2D : IfcCurveSegment2D, IInstantiableEntity, IPersistEntity, IPersist, IIfcCircularArcSegment2D, IIfcCurveSegment2D, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IContainsEntityReferences, IEquatable<IfcCircularArcSegment2D>
{
	private IfcPositiveLengthMeasure _radius;

	private IfcBoolean _isCCW;

	IfcPositiveLengthMeasure IIfcCircularArcSegment2D.Radius
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

	IfcBoolean IIfcCircularArcSegment2D.IsCCW
	{
		get
		{
			return IsCCW;
		}
		set
		{
			IsCCW = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
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
			}, _radius, value, "Radius", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcBoolean IsCCW
	{
		get
		{
			if (_activated)
			{
				return _isCCW;
			}
			Activate();
			return _isCCW;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_isCCW = v;
			}, _isCCW, value, "IsCCW", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.StartPoint != null)
			{
				yield return base.StartPoint;
			}
		}
	}

	internal IfcCircularArcSegment2D(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_radius = value.RealVal;
			break;
		case 4:
			_isCCW = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCircularArcSegment2D other)
	{
		return this == other;
	}
}
