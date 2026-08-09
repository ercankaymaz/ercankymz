using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricConstraintResource;

[ExpressType("IfcAlignmentCantSegment", 1403)]
public class IfcAlignmentCantSegment : IfcAlignmentParameterSegment, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcAlignmentCantSegment>
{
	private IfcLengthMeasure _startDistAlong;

	private IfcNonNegativeLengthMeasure _horizontalLength;

	private IfcLengthMeasure _startCantLeft;

	private IfcLengthMeasure? _endCantLeft;

	private IfcLengthMeasure _startCantRight;

	private IfcLengthMeasure? _endCantRight;

	private IfcAlignmentCantSegmentTypeEnum _predefinedType;

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
	public IfcLengthMeasure StartCantLeft
	{
		get
		{
			if (_activated)
			{
				return _startCantLeft;
			}
			Activate();
			return _startCantLeft;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_startCantLeft = v;
			}, _startCantLeft, value, "StartCantLeft", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLengthMeasure? EndCantLeft
	{
		get
		{
			if (_activated)
			{
				return _endCantLeft;
			}
			Activate();
			return _endCantLeft;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_endCantLeft = v;
			}, _endCantLeft, value, "EndCantLeft", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcLengthMeasure StartCantRight
	{
		get
		{
			if (_activated)
			{
				return _startCantRight;
			}
			Activate();
			return _startCantRight;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_startCantRight = v;
			}, _startCantRight, value, "StartCantRight", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcLengthMeasure? EndCantRight
	{
		get
		{
			if (_activated)
			{
				return _endCantRight;
			}
			Activate();
			return _endCantRight;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_endCantRight = v;
			}, _endCantRight, value, "EndCantRight", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 9)]
	public IfcAlignmentCantSegmentTypeEnum PredefinedType
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
			SetValue(delegate(IfcAlignmentCantSegmentTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
		}
	}

	internal IfcAlignmentCantSegment(IModel model, int label, bool activated)
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
			_startCantLeft = value.RealVal;
			break;
		case 5:
			_endCantLeft = value.RealVal;
			break;
		case 6:
			_startCantRight = value.RealVal;
			break;
		case 7:
			_endCantRight = value.RealVal;
			break;
		case 8:
			_predefinedType = (IfcAlignmentCantSegmentTypeEnum)Enum.Parse(typeof(IfcAlignmentCantSegmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlignmentCantSegment other)
	{
		return this == other;
	}
}
