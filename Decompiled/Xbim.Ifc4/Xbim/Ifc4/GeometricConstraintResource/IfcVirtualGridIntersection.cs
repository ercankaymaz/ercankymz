using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcVirtualGridIntersection", 589)]
public class IfcVirtualGridIntersection : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcVirtualGridIntersection, IfcGridPlacementDirectionSelect, IIfcGridPlacementDirectionSelect, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcVirtualGridIntersection>
{
	private readonly ItemSet<IfcGridAxis> _intersectingAxes;

	private readonly ItemSet<IfcLengthMeasure> _offsetDistances;

	IItemSet<IIfcGridAxis> IIfcVirtualGridIntersection.IntersectingAxes => new ProxyItemSet<IfcGridAxis, IIfcGridAxis>(IntersectingAxes);

	IItemSet<IfcLengthMeasure> IIfcVirtualGridIntersection.OffsetDistances => OffsetDistances;

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
	public IItemSet<IfcLengthMeasure> OffsetDistances
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

	internal IfcVirtualGridIntersection(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_intersectingAxes = new ItemSet<IfcGridAxis>(this, 2, 1);
		_offsetDistances = new ItemSet<IfcLengthMeasure>(this, 3, 2);
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
