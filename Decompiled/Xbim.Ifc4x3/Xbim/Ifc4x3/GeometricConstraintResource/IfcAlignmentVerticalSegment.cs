using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricConstraintResource;

[ExpressType("IfcAlignmentVerticalSegment", 1409)]
public class IfcAlignmentVerticalSegment : IfcAlignmentParameterSegment, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcAlignmentVerticalSegment>
{
	private IfcLengthMeasure _startDistAlong;

	private IfcNonNegativeLengthMeasure _horizontalLength;

	private IfcLengthMeasure _startHeight;

	private IfcRatioMeasure _startGradient;

	private IfcRatioMeasure _endGradient;

	private IfcLengthMeasure? _radiusOfCurvature;

	private IfcAlignmentVerticalSegmentTypeEnum _predefinedType;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLengthMeasure StartDistAlong
	{
		get
		{
			if (_activated)
			{
				return _startDistAlong;
			}
			Activate();
			return _startDistAlong;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_startDistAlong = v;
			}, _startDistAlong, value, "StartDistAlong", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcNonNegativeLengthMeasure HorizontalLength
	{
		get
		{
			if (_activated)
			{
				return _horizontalLength;
			}
			Activate();
			return _horizontalLength;
		}
		set
		{
			SetValue(delegate(IfcNonNegativeLengthMeasure v)
			{
				_horizontalLength = v;
			}, _horizontalLength, value, "HorizontalLength", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLengthMeasure StartHeight
	{
		get
		{
			if (_activated)
			{
				return _startHeight;
			}
			Activate();
			return _startHeight;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_startHeight = v;
			}, _startHeight, value, "StartHeight", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcRatioMeasure StartGradient
	{
		get
		{
			if (_activated)
			{
				return _startGradient;
			}
			Activate();
			return _startGradient;
		}
		set
		{
			SetValue(delegate(IfcRatioMeasure v)
			{
				_startGradient = v;
			}, _startGradient, value, "StartGradient", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcRatioMeasure EndGradient
	{
		get
		{
			if (_activated)
			{
				return _endGradient;
			}
			Activate();
			return _endGradient;
		}
		set
		{
			SetValue(delegate(IfcRatioMeasure v)
			{
				_endGradient = v;
			}, _endGradient, value, "EndGradient", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcLengthMeasure? RadiusOfCurvature
	{
		get
		{
			if (_activated)
			{
				return _radiusOfCurvature;
			}
			Activate();
			return _radiusOfCurvature;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_radiusOfCurvature = v;
			}, _radiusOfCurvature, value, "RadiusOfCurvature", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 9)]
	public IfcAlignmentVerticalSegmentTypeEnum PredefinedType
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
			SetValue(delegate(IfcAlignmentVerticalSegmentTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
		}
	}

	internal IfcAlignmentVerticalSegment(IModel model, int label, bool activated)
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
			_startDistAlong = value.RealVal;
			break;
		case 3:
			_horizontalLength = value.RealVal;
			break;
		case 4:
			_startHeight = value.RealVal;
			break;
		case 5:
			_startGradient = value.RealVal;
			break;
		case 6:
			_endGradient = value.RealVal;
			break;
		case 7:
			_radiusOfCurvature = value.RealVal;
			break;
		case 8:
			_predefinedType = (IfcAlignmentVerticalSegmentTypeEnum)Enum.Parse(typeof(IfcAlignmentVerticalSegmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlignmentVerticalSegment other)
	{
		return this == other;
	}
}
