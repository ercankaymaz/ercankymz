using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcOpenCrossProfileDef", 1466)]
public class IfcOpenCrossProfileDef : IfcProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcOpenCrossProfileDef>
{
	private IfcBoolean _horizontalWidths;

	private readonly ItemSet<IfcNonNegativeLengthMeasure> _widths;

	private readonly ItemSet<IfcPlaneAngleMeasure> _slopes;

	private readonly OptionalItemSet<IfcLabel> _tags;

	private IfcCartesianPoint _offsetPoint;

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcBoolean HorizontalWidths
	{
		get
		{
			if (_activated)
			{
				return _horizontalWidths;
			}
			Activate();
			return _horizontalWidths;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_horizontalWidths = v;
			}, _horizontalWidths, value, "HorizontalWidths", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<IfcNonNegativeLengthMeasure> Widths
	{
		get
		{
			if (_activated)
			{
				return _widths;
			}
			Activate();
			return _widths;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 7)]
	public IItemSet<IfcPlaneAngleMeasure> Slopes
	{
		get
		{
			if (_activated)
			{
				return _slopes;
			}
			Activate();
			return _slopes;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { -1 }, 8)]
	public IOptionalItemSet<IfcLabel> Tags
	{
		get
		{
			if (_activated)
			{
				return _tags;
			}
			Activate();
			return _tags;
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 9)]
	public IfcCartesianPoint OffsetPoint
	{
		get
		{
			if (_activated)
			{
				return _offsetPoint;
			}
			Activate();
			return _offsetPoint;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPoint v)
			{
				_offsetPoint = v;
			}, _offsetPoint, value, "OffsetPoint", 7);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (OffsetPoint != null)
			{
				yield return OffsetPoint;
			}
		}
	}

	internal IfcOpenCrossProfileDef(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_widths = new ItemSet<IfcNonNegativeLengthMeasure>(this, 0, 4);
		_slopes = new ItemSet<IfcPlaneAngleMeasure>(this, 0, 5);
		_tags = new OptionalItemSet<IfcLabel>(this, 0, 6);
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
			_horizontalWidths = value.BooleanVal;
			break;
		case 3:
			_widths.InternalAdd(value.RealVal);
			break;
		case 4:
			_slopes.InternalAdd(value.RealVal);
			break;
		case 5:
			_tags.InternalAdd(value.StringVal);
			break;
		case 6:
			_offsetPoint = (IfcCartesianPoint)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOpenCrossProfileDef other)
	{
		return this == other;
	}
}
