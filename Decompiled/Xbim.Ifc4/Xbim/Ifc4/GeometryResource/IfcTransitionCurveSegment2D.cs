using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcTransitionCurveSegment2D", 1356)]
public class IfcTransitionCurveSegment2D : IfcCurveSegment2D, IInstantiableEntity, IPersistEntity, IPersist, IIfcTransitionCurveSegment2D, IIfcCurveSegment2D, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IContainsEntityReferences, IEquatable<IfcTransitionCurveSegment2D>
{
	private IfcPositiveLengthMeasure? _startRadius;

	private IfcPositiveLengthMeasure? _endRadius;

	private IfcBoolean _isStartRadiusCCW;

	private IfcBoolean _isEndRadiusCCW;

	private IfcTransitionCurveType _transitionCurveType;

	IfcPositiveLengthMeasure? IIfcTransitionCurveSegment2D.StartRadius
	{
		get
		{
			return StartRadius;
		}
		set
		{
			StartRadius = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcTransitionCurveSegment2D.EndRadius
	{
		get
		{
			return EndRadius;
		}
		set
		{
			EndRadius = value;
		}
	}

	IfcBoolean IIfcTransitionCurveSegment2D.IsStartRadiusCCW
	{
		get
		{
			return IsStartRadiusCCW;
		}
		set
		{
			IsStartRadiusCCW = value;
		}
	}

	IfcBoolean IIfcTransitionCurveSegment2D.IsEndRadiusCCW
	{
		get
		{
			return IsEndRadiusCCW;
		}
		set
		{
			IsEndRadiusCCW = value;
		}
	}

	IfcTransitionCurveType IIfcTransitionCurveSegment2D.TransitionCurveType
	{
		get
		{
			return TransitionCurveType;
		}
		set
		{
			TransitionCurveType = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure? StartRadius
	{
		get
		{
			if (_activated)
			{
				return _startRadius;
			}
			Activate();
			return _startRadius;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_startRadius = v;
			}, _startRadius, value, "StartRadius", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPositiveLengthMeasure? EndRadius
	{
		get
		{
			if (_activated)
			{
				return _endRadius;
			}
			Activate();
			return _endRadius;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_endRadius = v;
			}, _endRadius, value, "EndRadius", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcBoolean IsStartRadiusCCW
	{
		get
		{
			if (_activated)
			{
				return _isStartRadiusCCW;
			}
			Activate();
			return _isStartRadiusCCW;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_isStartRadiusCCW = v;
			}, _isStartRadiusCCW, value, "IsStartRadiusCCW", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcBoolean IsEndRadiusCCW
	{
		get
		{
			if (_activated)
			{
				return _isEndRadiusCCW;
			}
			Activate();
			return _isEndRadiusCCW;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_isEndRadiusCCW = v;
			}, _isEndRadiusCCW, value, "IsEndRadiusCCW", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 10)]
	public IfcTransitionCurveType TransitionCurveType
	{
		get
		{
			if (_activated)
			{
				return _transitionCurveType;
			}
			Activate();
			return _transitionCurveType;
		}
		set
		{
			SetValue(delegate(IfcTransitionCurveType v)
			{
				_transitionCurveType = v;
			}, _transitionCurveType, value, "TransitionCurveType", 8);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.StartPoint != null)
			{
				yield return base.StartPoint;
			}
		}
	}

	internal IfcTransitionCurveSegment2D(IModel model, int label, bool activated)
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
			_startRadius = value.RealVal;
			break;
		case 4:
			_endRadius = value.RealVal;
			break;
		case 5:
			_isStartRadiusCCW = value.BooleanVal;
			break;
		case 6:
			_isEndRadiusCCW = value.BooleanVal;
			break;
		case 7:
			_transitionCurveType = (IfcTransitionCurveType)Enum.Parse(typeof(IfcTransitionCurveType), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTransitionCurveSegment2D other)
	{
		return this == other;
	}
}
