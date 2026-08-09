using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcTriangulatedFaceSet", 1304)]
public class IfcTriangulatedFaceSet : IfcTessellatedFaceSet, IInstantiableEntity, IPersistEntity, IPersist, IIfcTriangulatedFaceSet, IIfcTessellatedFaceSet, IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IContainsEntityReferences, IEquatable<IfcTriangulatedFaceSet>
{
	private readonly OptionalItemSet<IItemSet<IfcParameterValue>> _normals;

	private IfcBoolean? _closed;

	private readonly ItemSet<IItemSet<IfcPositiveInteger>> _coordIndex;

	private readonly OptionalItemSet<IfcPositiveInteger> _pnIndex;

	IItemSet<IItemSet<IfcParameterValue>> IIfcTriangulatedFaceSet.Normals => Normals;

	IfcBoolean? IIfcTriangulatedFaceSet.Closed
	{
		get
		{
			return Closed;
		}
		set
		{
			Closed = value;
		}
	}

	IItemSet<IItemSet<IfcPositiveInteger>> IIfcTriangulatedFaceSet.CoordIndex => CoordIndex;

	IItemSet<IfcPositiveInteger> IIfcTriangulatedFaceSet.PnIndex => PnIndex;

	IfcInteger IIfcTriangulatedFaceSet.NumberOfTriangles => NumberOfTriangles;

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 3 }, new int[] { -1, 3 }, 6)]
	public IOptionalItemSet<IItemSet<IfcParameterValue>> Normals
	{
		get
		{
			if (_activated)
			{
				return _normals;
			}
			Activate();
			return _normals;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcBoolean? Closed
	{
		get
		{
			if (_activated)
			{
				return _closed;
			}
			Activate();
			return _closed;
		}
		set
		{
			SetValue(delegate(IfcBoolean? v)
			{
				_closed = v;
			}, _closed, value, "Closed", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 3 }, new int[] { -1, 3 }, 8)]
	public IItemSet<IItemSet<IfcPositiveInteger>> CoordIndex
	{
		get
		{
			if (_activated)
			{
				return _coordIndex;
			}
			Activate();
			return _coordIndex;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 9)]
	public IOptionalItemSet<IfcPositiveInteger> PnIndex
	{
		get
		{
			if (_activated)
			{
				return _pnIndex;
			}
			Activate();
			return _pnIndex;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcInteger NumberOfTriangles => CoordIndex.Count;

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Coordinates != null)
			{
				yield return base.Coordinates;
			}
		}
	}

	internal IfcTriangulatedFaceSet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_normals = new OptionalItemSet<IItemSet<IfcParameterValue>>(this, 0, 2);
		_coordIndex = new ItemSet<IItemSet<IfcPositiveInteger>>(this, 0, 4);
		_pnIndex = new OptionalItemSet<IfcPositiveInteger>(this, 0, 5);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			((ItemSet<IfcParameterValue>)_normals.InternalGetAt(nestedIndex[0])).InternalAdd(value.RealVal);
			break;
		case 2:
			_closed = value.BooleanVal;
			break;
		case 3:
			((ItemSet<IfcPositiveInteger>)_coordIndex.InternalGetAt(nestedIndex[0])).InternalAdd(value.IntegerVal);
			break;
		case 4:
			_pnIndex.InternalAdd(value.IntegerVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTriangulatedFaceSet other)
	{
		return this == other;
	}
}
