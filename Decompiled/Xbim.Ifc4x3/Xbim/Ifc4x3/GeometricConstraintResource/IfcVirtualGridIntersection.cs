using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricConstraintResource;

[ExpressType("IfcVirtualGridIntersection", 589)]
public class IfcVirtualGridIntersection : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IfcGridPlacementDirectionSelect, IExpressSelectType, IIfcGridPlacementDirectionSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcVirtualGridIntersection>, IIfcVirtualGridIntersection, Xbim.Ifc4.GeometricConstraintResource.IfcGridPlacementDirectionSelect
{
	private readonly ItemSet<IfcGridAxis> _intersectingAxes;

	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure> _offsetDistances;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 2 }, new int[] { 2 }, 1)]
	public IItemSet<IfcGridAxis> IntersectingAxes
	{
		get
		{
			if (_activated)
			{
				return _intersectingAxes;
			}
			Activate();
			return _intersectingAxes;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 2 }, new int[] { 3 }, 2)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure> OffsetDistances
	{
		get
		{
			if (_activated)
			{
				return _offsetDistances;
			}
			Activate();
			return _offsetDistances;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcGridAxis intersectingAxis in IntersectingAxes)
			{
				yield return intersectingAxis;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcGridAxis intersectingAxis in IntersectingAxes)
			{
				yield return intersectingAxis;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcVirtualGridIntersection), 1)]
	IItemSet<IIfcGridAxis> IIfcVirtualGridIntersection.IntersectingAxes => new ProxyItemSet<IfcGridAxis, IIfcGridAxis>(IntersectingAxes);

	[CrossSchemaAttribute(typeof(IIfcVirtualGridIntersection), 2)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLengthMeasure> IIfcVirtualGridIntersection.OffsetDistances => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure, Xbim.Ifc4.MeasureResource.IfcLengthMeasure>(OffsetDistances, (Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure s) => new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(s), (Xbim.Ifc4.MeasureResource.IfcLengthMeasure t) => new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(t));

	internal IfcVirtualGridIntersection(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_intersectingAxes = new ItemSet<IfcGridAxis>(this, 2, 1);
		_offsetDistances = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>(this, 3, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_intersectingAxes.InternalAdd((IfcGridAxis)value.EntityVal);
			break;
		case 1:
			_offsetDistances.InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcVirtualGridIntersection other)
	{
		return this == other;
	}
}
