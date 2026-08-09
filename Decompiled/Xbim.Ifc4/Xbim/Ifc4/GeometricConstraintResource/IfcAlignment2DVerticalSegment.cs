using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcAlignment2DVerticalSegment", 1339)]
public abstract class IfcAlignment2DVerticalSegment : IfcAlignment2DSegment, IIfcAlignment2DVerticalSegment, IIfcAlignment2DSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcAlignment2DVerticalSegment>
{
	private IfcLengthMeasure _startDistAlong;

	private IfcPositiveLengthMeasure _horizontalLength;

	private IfcLengthMeasure _startHeight;

	private IfcRatioMeasure _startGradient;

	IfcLengthMeasure IIfcAlignment2DVerticalSegment.StartDistAlong
	{
		get
		{
			return StartDistAlong;
		}
		set
		{
			StartDistAlong = value;
		}
	}

	IfcPositiveLengthMeasure IIfcAlignment2DVerticalSegment.HorizontalLength
	{
		get
		{
			return HorizontalLength;
		}
		set
		{
			HorizontalLength = value;
		}
	}

	IfcLengthMeasure IIfcAlignment2DVerticalSegment.StartHeight
	{
		get
		{
			return StartHeight;
		}
		set
		{
			StartHeight = value;
		}
	}

	IfcRatioMeasure IIfcAlignment2DVerticalSegment.StartGradient
	{
		get
		{
			return StartGradient;
		}
		set
		{
			StartGradient = value;
		}
	}

	IEnumerable<IIfcAlignment2DVertical> IIfcAlignment2DVerticalSegment.ToVertical => ToVertical;

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
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
			}, _startDistAlong, value, "StartDistAlong", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPositiveLengthMeasure HorizontalLength
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_horizontalLength = v;
			}, _horizontalLength, value, "HorizontalLength", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
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
			}, _startHeight, value, "StartHeight", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
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
			}, _startGradient, value, "StartGradient", 7);
		}
	}

	[InverseProperty("Segments")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { 1 }, 10)]
	public IEnumerable<IfcAlignment2DVertical> ToVertical => base.Model.Instances.Where((IfcAlignment2DVertical e) => e.Segments != null && e.Segments.Contains(this), "Segments", this);

	internal IfcAlignment2DVerticalSegment(IModel model, int label, bool activated)
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
			_startDistAlong = value.RealVal;
			break;
		case 4:
			_horizontalLength = value.RealVal;
			break;
		case 5:
			_startHeight = value.RealVal;
			break;
		case 6:
			_startGradient = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlignment2DVerticalSegment other)
	{
		return this == other;
	}
}
