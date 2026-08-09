using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcCurveSegment", 1427)]
public class IfcCurveSegment : IfcSegment, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCurveSegment>
{
	private IfcPlacement _placement;

	private IfcCurveMeasureSelect _segmentStart;

	private IfcCurveMeasureSelect _segmentLength;

	private IfcCurve _parentCurve;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcPlacement Placement
	{
		get
		{
			if (_activated)
			{
				return _placement;
			}
			Activate();
			return _placement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPlacement v)
			{
				_placement = v;
			}, _placement, value, "Placement", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcCurveMeasureSelect SegmentStart
	{
		get
		{
			if (_activated)
			{
				return _segmentStart;
			}
			Activate();
			return _segmentStart;
		}
		set
		{
			SetValue(delegate(IfcCurveMeasureSelect v)
			{
				_segmentStart = v;
			}, _segmentStart, value, "SegmentStart", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcCurveMeasureSelect SegmentLength
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
			SetValue(delegate(IfcCurveMeasureSelect v)
			{
				_segmentLength = v;
			}, _segmentLength, value, "SegmentLength", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcCurve ParentCurve
	{
		get
		{
			if (_activated)
			{
				return _parentCurve;
			}
			Activate();
			return _parentCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_parentCurve = v;
			}, _parentCurve, value, "ParentCurve", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Placement != null)
			{
				yield return Placement;
			}
			if (ParentCurve != null)
			{
				yield return ParentCurve;
			}
		}
	}

	internal IfcCurveSegment(IModel model, int label, bool activated)
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
			_placement = (IfcPlacement)value.EntityVal;
			break;
		case 2:
			_segmentStart = (IfcCurveMeasureSelect)value.EntityVal;
			break;
		case 3:
			_segmentLength = (IfcCurveMeasureSelect)value.EntityVal;
			break;
		case 4:
			_parentCurve = (IfcCurve)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCurveSegment other)
	{
		return this == other;
	}
}
