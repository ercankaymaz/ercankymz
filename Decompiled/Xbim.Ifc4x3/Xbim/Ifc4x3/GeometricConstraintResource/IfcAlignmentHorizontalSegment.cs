using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricConstraintResource;

[ExpressType("IfcAlignmentHorizontalSegment", 1405)]
public class IfcAlignmentHorizontalSegment : IfcAlignmentParameterSegment, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcAlignmentHorizontalSegment>
{
	private IfcCartesianPoint _startPoint;

	private IfcPlaneAngleMeasure _startDirection;

	private IfcLengthMeasure _startRadiusOfCurvature;

	private IfcLengthMeasure _endRadiusOfCurvature;

	private IfcNonNegativeLengthMeasure _segmentLength;

	private IfcPositiveLengthMeasure? _gravityCenterLineHeight;

	private IfcAlignmentHorizontalSegmentTypeEnum _predefinedType;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
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
			}, _startPoint, value, "StartPoint", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
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
			}, _startDirection, value, "StartDirection", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLengthMeasure StartRadiusOfCurvature
	{
		get
		{
			if (_activated)
			{
				return _startRadiusOfCurvature;
			}
			Activate();
			return _startRadiusOfCurvature;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_startRadiusOfCurvature = v;
			}, _startRadiusOfCurvature, value, "StartRadiusOfCurvature", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLengthMeasure EndRadiusOfCurvature
	{
		get
		{
			if (_activated)
			{
				return _endRadiusOfCurvature;
			}
			Activate();
			return _endRadiusOfCurvature;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_endRadiusOfCurvature = v;
			}, _endRadiusOfCurvature, value, "EndRadiusOfCurvature", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcNonNegativeLengthMeasure SegmentLength
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
			SetValue(delegate(IfcNonNegativeLengthMeasure v)
			{
				_segmentLength = v;
			}, _segmentLength, value, "SegmentLength", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcPositiveLengthMeasure? GravityCenterLineHeight
	{
		get
		{
			if (_activated)
			{
				return _gravityCenterLineHeight;
			}
			Activate();
			return _gravityCenterLineHeight;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_gravityCenterLineHeight = v;
			}, _gravityCenterLineHeight, value, "GravityCenterLineHeight", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 9)]
	public IfcAlignmentHorizontalSegmentTypeEnum PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcAlignmentHorizontalSegmentTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (StartPoint != null)
			{
				yield return StartPoint;
			}
		}
	}

	internal IfcAlignmentHorizontalSegment(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_startPoint = (IfcCartesianPoint)value.EntityVal;
			break;
		case 3:
			_startDirection = value.RealVal;
			break;
		case 4:
			_startRadiusOfCurvature = value.RealVal;
			break;
		case 5:
			_endRadiusOfCurvature = value.RealVal;
			break;
		case 6:
			_segmentLength = value.RealVal;
			break;
		case 7:
			_gravityCenterLineHeight = value.RealVal;
			break;
		case 8:
			_predefinedType = (IfcAlignmentHorizontalSegmentTypeEnum)Enum.Parse(typeof(IfcAlignmentHorizontalSegmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlignmentHorizontalSegment other)
	{
		return this == other;
	}
}
