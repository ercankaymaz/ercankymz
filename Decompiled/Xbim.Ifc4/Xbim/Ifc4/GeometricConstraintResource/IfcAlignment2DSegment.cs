using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcAlignment2DSegment", 1334)]
public abstract class IfcAlignment2DSegment : IfcGeometricRepresentationItem, IIfcAlignment2DSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcAlignment2DSegment>
{
	private IfcBoolean? _tangentialContinuity;

	private IfcLabel? _startTag;

	private IfcLabel? _endTag;

	IfcBoolean? IIfcAlignment2DSegment.TangentialContinuity
	{
		get
		{
			return TangentialContinuity;
		}
		set
		{
			TangentialContinuity = value;
		}
	}

	IfcLabel? IIfcAlignment2DSegment.StartTag
	{
		get
		{
			return StartTag;
		}
		set
		{
			StartTag = value;
		}
	}

	IfcLabel? IIfcAlignment2DSegment.EndTag
	{
		get
		{
			return EndTag;
		}
		set
		{
			EndTag = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcBoolean? TangentialContinuity
	{
		get
		{
			if (_activated)
			{
				return _tangentialContinuity;
			}
			Activate();
			return _tangentialContinuity;
		}
		set
		{
			SetValue(delegate(IfcBoolean? v)
			{
				_tangentialContinuity = v;
			}, _tangentialContinuity, value, "TangentialContinuity", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
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
			}, _startTag, value, "StartTag", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
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
			}, _endTag, value, "EndTag", 3);
		}
	}

	internal IfcAlignment2DSegment(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_tangentialContinuity = value.BooleanVal;
			break;
		case 1:
			_startTag = value.StringVal;
			break;
		case 2:
			_endTag = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlignment2DSegment other)
	{
		return this == other;
	}
}
