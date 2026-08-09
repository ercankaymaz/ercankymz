using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometricModelResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcIndexedPolyCurve", 1190)]
public class IfcIndexedPolyCurve : IfcBoundedCurve, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcIndexedPolyCurve>, IIfcIndexedPolyCurve, IIfcBoundedCurve, IIfcCurve, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcGeometricSetSelect, IIfcGeometricSetSelect, IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve
{
	private Xbim.Ifc4x3.GeometricModelResource.IfcCartesianPointList _points;

	private readonly OptionalItemSet<IfcSegmentIndexSelect> _segments;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean? _selfIntersect;

	private IItemSet<IIfcSegmentIndexSelect> _segmentsIfc4;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.GeometricModelResource.IfcCartesianPointList Points
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
			SetValue(delegate(Xbim.Ifc4x3.GeometricModelResource.IfcCartesianPointList v)
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
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean? SelfIntersect
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean? v)
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

	[CrossSchemaAttribute(typeof(IIfcIndexedPolyCurve), 1)]
	IIfcCartesianPointList IIfcIndexedPolyCurve.Points
	{
		get
		{
			return Points;
		}
		set
		{
			Points = value as Xbim.Ifc4x3.GeometricModelResource.IfcCartesianPointList;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcIndexedPolyCurve), 2)]
	IItemSet<IIfcSegmentIndexSelect> IIfcIndexedPolyCurve.Segments => _segmentsIfc4 ?? (_segmentsIfc4 = new ExtendedItemSet<IfcSegmentIndexSelect, IIfcSegmentIndexSelect>(Segments, new ItemSet<IIfcSegmentIndexSelect>(this, 0, -2), SegmentsToIfc4, SegmentsToIfc2X3));

	[CrossSchemaAttribute(typeof(IIfcIndexedPolyCurve), 3)]
	Xbim.Ifc4.MeasureResource.IfcBoolean? IIfcIndexedPolyCurve.SelfIntersect
	{
		get
		{
			if (!SelfIntersect.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(SelfIntersect.Value);
		}
		set
		{
			SelfIntersect = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcBoolean?(new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcBoolean?)null));
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
			_points = (Xbim.Ifc4x3.GeometricModelResource.IfcCartesianPointList)value.EntityVal;
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

	private static IIfcSegmentIndexSelect SegmentsToIfc4(IfcSegmentIndexSelect member)
	{
		if (member == null)
		{
			return null;
		}
		string name = member.GetType().Name;
		if (!(name == "IfcArcIndex"))
		{
			if (name == "IfcLineIndex")
			{
				return new Xbim.Ifc4.GeometryResource.IfcLineIndex((member.Value as IEnumerable<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>).Select((Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger p) => new Xbim.Ifc4.MeasureResource.IfcPositiveInteger((long)p.Value)).ToList());
			}
			throw new NotSupportedException();
		}
		return new Xbim.Ifc4.GeometryResource.IfcArcIndex((member.Value as IEnumerable<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>).Select((Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger p) => new Xbim.Ifc4.MeasureResource.IfcPositiveInteger((long)p.Value)).ToList());
	}

	private static IfcSegmentIndexSelect SegmentsToIfc2X3(IIfcSegmentIndexSelect member)
	{
		if (member == null)
		{
			return null;
		}
		string name = member.GetType().Name;
		if (!(name == "IfcArcIndex"))
		{
			if (name == "IfcLineIndex")
			{
				return new IfcLineIndex((member.Value as IEnumerable<Xbim.Ifc4.MeasureResource.IfcPositiveInteger>).Select((Xbim.Ifc4.MeasureResource.IfcPositiveInteger p) => new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger((long)p.Value)).ToList());
			}
			throw new NotSupportedException();
		}
		return new IfcArcIndex((member.Value as IEnumerable<Xbim.Ifc4.MeasureResource.IfcPositiveInteger>).Select((Xbim.Ifc4.MeasureResource.IfcPositiveInteger p) => new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger((long)p.Value)).ToList());
	}
}
