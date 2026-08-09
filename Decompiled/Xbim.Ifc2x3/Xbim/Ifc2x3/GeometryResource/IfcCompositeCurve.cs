using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcCompositeCurve", 279)]
public class IfcCompositeCurve : IfcBoundedCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCompositeCurve>, IIfcCompositeCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IExpressValidatable
{
	public enum IfcCompositeCurveClause
	{
		WR41,
		WR42
	}

	private readonly ItemSet<IfcCompositeCurveSegment> _segments;

	private bool? _selfIntersect;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcCompositeCurveSegment> Segments
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

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public bool? SelfIntersect
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
			SetValue(delegate(bool? v)
			{
				_selfIntersect = v;
			}, _selfIntersect, value, "SelfIntersect", 2);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public long NSegments => Segments.Count;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public bool? ClosedCurve
	{
		get
		{
			if (Segments.Count == 0)
			{
				return null;
			}
			return Segments.Last().Transition != IfcTransitionCode.DISCONTINUOUS;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcCompositeCurveSegment segment in Segments)
			{
				yield return segment;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcCompositeCurveSegment segment in Segments)
			{
				yield return segment;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCompositeCurve), 1)]
	IItemSet<IIfcCompositeCurveSegment> IIfcCompositeCurve.Segments => new ProxyItemSet<IfcCompositeCurveSegment, IIfcCompositeCurveSegment>(Segments);

	[CrossSchemaAttribute(typeof(IIfcCompositeCurve), 2)]
	IfcLogical IIfcCompositeCurve.SelfIntersect
	{
		get
		{
			return new IfcLogical(SelfIntersect);
		}
		set
		{
			SelfIntersect = value;
		}
	}

	IfcInteger IIfcCompositeCurve.NSegments => new IfcInteger(NSegments);

	IfcLogical IIfcCompositeCurve.ClosedCurve => new IfcLogical(ClosedCurve);

	internal IfcCompositeCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_segments = new ItemSet<IfcCompositeCurveSegment>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_segments.InternalAdd((IfcCompositeCurveSegment)value.EntityVal);
			break;
		case 1:
			_selfIntersect = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCompositeCurve other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCompositeCurveClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcCompositeCurveClause.WR41:
				result = (!ClosedCurve.Value && Functions.SIZEOF(Enumerable.Where(Segments, (IfcCompositeCurveSegment Temp) => Temp.Transition == IfcTransitionCode.DISCONTINUOUS)) == 1) || (ClosedCurve.Value && Functions.SIZEOF(Enumerable.Where(Segments, (IfcCompositeCurveSegment Temp) => Temp.Transition == IfcTransitionCode.DISCONTINUOUS)) == 0);
				break;
			case IfcCompositeCurveClause.WR42:
				result = Functions.SIZEOF(Enumerable.Where(Segments, (IfcCompositeCurveSegment Temp) => Temp.Dim != Segments.ItemAt(0L).Dim)) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCompositeCurve>()?.LogError($"Exception thrown evaluating where-clause 'IfcCompositeCurve.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcCompositeCurveClause.WR41))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCompositeCurve.WR41",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCompositeCurveClause.WR42))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCompositeCurve.WR42",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
