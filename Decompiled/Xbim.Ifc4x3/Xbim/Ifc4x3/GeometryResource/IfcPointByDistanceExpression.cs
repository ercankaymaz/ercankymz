using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcPointByDistanceExpression", 1469)]
public class IfcPointByDistanceExpression : IfcPoint, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcPointByDistanceExpression>
{
	private IfcCurveMeasureSelect _distanceAlong;

	private IfcLengthMeasure? _offsetLateral;

	private IfcLengthMeasure? _offsetVertical;

	private IfcLengthMeasure? _offsetLongitudinal;

	private IfcCurve _basisCurve;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCurveMeasureSelect DistanceAlong
	{
		get
		{
			if (_activated)
			{
				return _distanceAlong;
			}
			Activate();
			return _distanceAlong;
		}
		set
		{
			SetValue(delegate(IfcCurveMeasureSelect v)
			{
				_distanceAlong = v;
			}, _distanceAlong, value, "DistanceAlong", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure? OffsetLateral
	{
		get
		{
			if (_activated)
			{
				return _offsetLateral;
			}
			Activate();
			return _offsetLateral;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_offsetLateral = v;
			}, _offsetLateral, value, "OffsetLateral", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLengthMeasure? OffsetVertical
	{
		get
		{
			if (_activated)
			{
				return _offsetVertical;
			}
			Activate();
			return _offsetVertical;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_offsetVertical = v;
			}, _offsetVertical, value, "OffsetVertical", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLengthMeasure? OffsetLongitudinal
	{
		get
		{
			if (_activated)
			{
				return _offsetLongitudinal;
			}
			Activate();
			return _offsetLongitudinal;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_offsetLongitudinal = v;
			}, _offsetLongitudinal, value, "OffsetLongitudinal", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcCurve BasisCurve
	{
		get
		{
			if (_activated)
			{
				return _basisCurve;
			}
			Activate();
			return _basisCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_basisCurve = v;
			}, _basisCurve, value, "BasisCurve", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (BasisCurve != null)
			{
				yield return BasisCurve;
			}
		}
	}

	internal IfcPointByDistanceExpression(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_distanceAlong = (IfcCurveMeasureSelect)value.EntityVal;
			break;
		case 1:
			_offsetLateral = value.RealVal;
			break;
		case 2:
			_offsetVertical = value.RealVal;
			break;
		case 3:
			_offsetLongitudinal = value.RealVal;
			break;
		case 4:
			_basisCurve = (IfcCurve)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPointByDistanceExpression other)
	{
		return this == other;
	}
}
