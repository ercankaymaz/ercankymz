using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcCurveSegment2D", 1342)]
public abstract class IfcCurveSegment2D : IfcBoundedCurve, IIfcCurveSegment2D, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IEquatable<IfcCurveSegment2D>
{
	private IfcCartesianPoint _startPoint;

	private IfcPlaneAngleMeasure _startDirection;

	private IfcPositiveLengthMeasure _segmentLength;

	IIfcCartesianPoint IIfcCurveSegment2D.StartPoint
	{
		get
		{
			return StartPoint;
		}
		set
		{
			StartPoint = value as IfcCartesianPoint;
		}
	}

	IfcPlaneAngleMeasure IIfcCurveSegment2D.StartDirection
	{
		get
		{
			return StartDirection;
		}
		set
		{
			StartDirection = value;
		}
	}

	IfcPositiveLengthMeasure IIfcCurveSegment2D.SegmentLength
	{
		get
		{
			return SegmentLength;
		}
		set
		{
			SegmentLength = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCartesianPoint StartPoint
	{
		get
		{
			if (_activated)
			{
				return _startPoint;
			}
			Activate();
			return _startPoint;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPoint v)
			{
				_startPoint = v;
			}, _startPoint, value, "StartPoint", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPlaneAngleMeasure StartDirection
	{
		get
		{
			if (_activated)
			{
				return _startDirection;
			}
			Activate();
			return _startDirection;
		}
		set
		{
			SetValue(delegate(IfcPlaneAngleMeasure v)
			{
				_startDirection = v;
			}, _startDirection, value, "StartDirection", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveLengthMeasure SegmentLength
	{
		get
		{
			if (_activated)
			{
				return _segmentLength;
			}
			Activate();
			return _segmentLength;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_segmentLength = v;
			}, _segmentLength, value, "SegmentLength", 3);
		}
	}

	internal IfcCurveSegment2D(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_startPoint = (IfcCartesianPoint)value.EntityVal;
			break;
		case 1:
			_startDirection = value.RealVal;
			break;
		case 2:
			_segmentLength = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCurveSegment2D other)
	{
		return this == other;
	}
}
