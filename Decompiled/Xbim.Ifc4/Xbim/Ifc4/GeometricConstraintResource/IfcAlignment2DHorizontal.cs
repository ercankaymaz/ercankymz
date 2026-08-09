using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcAlignment2DHorizontal", 1332)]
public class IfcAlignment2DHorizontal : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcAlignment2DHorizontal, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAlignment2DHorizontal>
{
	private IfcLengthMeasure? _startDistAlong;

	private readonly ItemSet<IfcAlignment2DHorizontalSegment> _segments;

	IfcLengthMeasure? IIfcAlignment2DHorizontal.StartDistAlong
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

	IItemSet<IIfcAlignment2DHorizontalSegment> IIfcAlignment2DHorizontal.Segments => new ProxyItemSet<IfcAlignment2DHorizontalSegment, IIfcAlignment2DHorizontalSegment>(Segments);

	IEnumerable<IIfcAlignmentCurve> IIfcAlignment2DHorizontal.ToAlignmentCurve => ToAlignmentCurve;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLengthMeasure? StartDistAlong
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
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_startDistAlong = v;
			}, _startDistAlong, value, "StartDistAlong", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcAlignment2DHorizontalSegment> Segments
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

	[InverseProperty("Horizontal")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IEnumerable<IfcAlignmentCurve> ToAlignmentCurve => base.Model.Instances.Where((IfcAlignmentCurve e) => Equals(e.Horizontal), "Horizontal", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcAlignment2DHorizontalSegment segment in Segments)
			{
				yield return segment;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcAlignment2DHorizontalSegment segment in Segments)
			{
				yield return segment;
			}
		}
	}

	internal IfcAlignment2DHorizontal(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_segments = new ItemSet<IfcAlignment2DHorizontalSegment>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_startDistAlong = value.RealVal;
			break;
		case 1:
			_segments.InternalAdd((IfcAlignment2DHorizontalSegment)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlignment2DHorizontal other)
	{
		return this == other;
	}
}
