using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometryResource;

[ExpressType("IfcIndexedPolyCurve", 1190)]
public class IfcIndexedPolyCurve : IfcBoundedCurve, IInstantiableEntity, IPersistEntity, IPersist, IIfcIndexedPolyCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IContainsEntityReferences, IEquatable<IfcIndexedPolyCurve>, IExpressValidatable
{
	public enum IfcIndexedPolyCurveClause
	{
		Consecutive
	}

	private IfcCartesianPointList _points;

	private readonly OptionalItemSet<IfcSegmentIndexSelect> _segments;

	private IfcBoolean? _selfIntersect;

	IIfcCartesianPointList IIfcIndexedPolyCurve.Points
	{
		get
		{
			return Points;
		}
		set
		{
			Points = value as IfcCartesianPointList;
		}
	}

	IItemSet<IIfcSegmentIndexSelect> IIfcIndexedPolyCurve.Segments => new ProxyItemSet<IfcSegmentIndexSelect, IIfcSegmentIndexSelect>(Segments);

	IfcBoolean? IIfcIndexedPolyCurve.SelfIntersect
	{
		get
		{
			return SelfIntersect;
		}
		set
		{
			SelfIntersect = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCartesianPointList Points
	{
		get
		{
			if (_activated)
			{
				return _points;
			}
			Activate();
			return _points;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPointList v)
			{
				_points = v;
			}, _points, value, "Points", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IOptionalItemSet<IfcSegmentIndexSelect> Segments
	{
		get
		{
			if (_activated)
			{
				return _segments;
			}
			Activate();
			return _segments;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcBoolean? SelfIntersect
	{
		get
		{
			if (_activated)
			{
				return _selfIntersect;
			}
			Activate();
			return _selfIntersect;
		}
		set
		{
			SetValue(delegate(IfcBoolean? v)
			{
				_selfIntersect = v;
			}, _selfIntersect, value, "SelfIntersect", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Points != null)
			{
				yield return Points;
			}
		}
	}

	internal IfcIndexedPolyCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_segments = new OptionalItemSet<IfcSegmentIndexSelect>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_points = (IfcCartesianPointList)value.EntityVal;
			break;
		case 1:
			_segments.InternalAdd((IfcSegmentIndexSelect)value.EntityVal);
			break;
		case 2:
			_selfIntersect = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcIndexedPolyCurve other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcIndexedPolyCurveClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcIndexedPolyCurveClause.Consecutive)
			{
				result = Functions.SIZEOF(Segments) == 0 || Functions.IfcConsecutiveSegments(Segments);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcIndexedPolyCurve>()?.LogError($"Exception thrown evaluating where-clause 'IfcIndexedPolyCurve.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcIndexedPolyCurveClause.Consecutive))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcIndexedPolyCurve.Consecutive",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
