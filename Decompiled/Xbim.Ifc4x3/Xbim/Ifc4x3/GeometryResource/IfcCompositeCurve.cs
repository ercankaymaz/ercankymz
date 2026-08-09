using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcCompositeCurve", 279)]
public class IfcCompositeCurve : IfcBoundedCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCompositeCurve>, IIfcCompositeCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve
{
	private readonly ItemSet<IfcSegment> _segments;

	private Xbim.Ifc4x3.MeasureResource.IfcLogical _selfIntersect;

	private IItemSet<IIfcCompositeCurveSegment> _segmentsExtended;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcSegment> Segments
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
	public Xbim.Ifc4x3.MeasureResource.IfcLogical SelfIntersect
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLogical v)
			{
				_selfIntersect = v;
			}, _selfIntersect, value, "SelfIntersect", 2);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger NSegments => Segments.Count;

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.MeasureResource.IfcLogical ClosedCurve
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
			foreach (IfcSegment segment in Segments)
			{
				yield return segment;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcSegment segment in Segments)
			{
				yield return segment;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCompositeCurve), 1)]
	IItemSet<IIfcCompositeCurveSegment> IIfcCompositeCurve.Segments => _segmentsExtended ?? (_segmentsExtended = new ExtendedItemSet<IfcSegment, IIfcCompositeCurveSegment>(Segments, new ItemSet<IIfcCompositeCurveSegment>(this, 0, -16), (IfcSegment ifc4x3) => ifc4x3 as IIfcCompositeCurveSegment, (IIfcCompositeCurveSegment ifc4if) => ifc4if as IfcCompositeCurveSegment));

	[CrossSchemaAttribute(typeof(IIfcCompositeCurve), 2)]
	Xbim.Ifc4.MeasureResource.IfcLogical IIfcCompositeCurve.SelfIntersect
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLogical(SelfIntersect);
		}
		set
		{
			SelfIntersect = new Xbim.Ifc4x3.MeasureResource.IfcLogical(value);
		}
	}

	Xbim.Ifc4.MeasureResource.IfcInteger IIfcCompositeCurve.NSegments => new Xbim.Ifc4.MeasureResource.IfcInteger(NSegments);

	Xbim.Ifc4.MeasureResource.IfcLogical IIfcCompositeCurve.ClosedCurve => new Xbim.Ifc4.MeasureResource.IfcLogical(ClosedCurve);

	internal IfcCompositeCurve(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_segments = new ItemSet<IfcSegment>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_segments.InternalAdd((IfcSegment)value.EntityVal);
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
}
