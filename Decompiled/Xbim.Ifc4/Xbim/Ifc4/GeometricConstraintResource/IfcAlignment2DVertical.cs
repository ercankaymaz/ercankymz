using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcAlignment2DVertical", 1338)]
public class IfcAlignment2DVertical : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcAlignment2DVertical, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAlignment2DVertical>
{
	private readonly ItemSet<IfcAlignment2DVerticalSegment> _segments;

	IItemSet<IIfcAlignment2DVerticalSegment> IIfcAlignment2DVertical.Segments => new ProxyItemSet<IfcAlignment2DVerticalSegment, IIfcAlignment2DVerticalSegment>(Segments);

	IEnumerable<IIfcAlignmentCurve> IIfcAlignment2DVertical.ToAlignmentCurve => ToAlignmentCurve;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcAlignment2DVerticalSegment> Segments
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

	[InverseProperty("Vertical")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { 1 }, 4)]
	public IEnumerable<IfcAlignmentCurve> ToAlignmentCurve => base.Model.Instances.Where((IfcAlignmentCurve e) => Equals(e.Vertical), "Vertical", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcAlignment2DVerticalSegment segment in Segments)
			{
				yield return segment;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcAlignment2DVerticalSegment segment in Segments)
			{
				yield return segment;
			}
		}
	}

	internal IfcAlignment2DVertical(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_segments = new ItemSet<IfcAlignment2DVerticalSegment>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_segments.InternalAdd((IfcAlignment2DVerticalSegment)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcAlignment2DVertical other)
	{
		return this == other;
	}
}
