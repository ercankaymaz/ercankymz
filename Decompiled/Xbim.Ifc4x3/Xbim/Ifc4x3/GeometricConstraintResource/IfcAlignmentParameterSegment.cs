using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricConstraintResource;

[ExpressType("IfcAlignmentParameterSegment", 1406)]
public abstract class IfcAlignmentParameterSegment : PersistEntity, IEquatable<IfcAlignmentParameterSegment>
{
	private IfcLabel? _startTag;

	private IfcLabel? _endTag;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel? StartTag
	{
		get
		{
			if (_activated)
			{
				return _startTag;
			}
			Activate();
			return _startTag;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_startTag = v;
			}, _startTag, value, "StartTag", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel? EndTag
	{
		get
		{
			if (_activated)
			{
				return _endTag;
			}
			Activate();
			return _endTag;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_endTag = v;
			}, _endTag, value, "EndTag", 2);
		}
	}

	internal IfcAlignmentParameterSegment(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_startTag = value.StringVal;
			break;
		case 1:
			_endTag = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlignmentParameterSegment other)
	{
		return this == other;
	}
}
