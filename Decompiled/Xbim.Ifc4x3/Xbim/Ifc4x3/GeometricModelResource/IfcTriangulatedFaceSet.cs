using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcTriangulatedFaceSet", 1304)]
public class IfcTriangulatedFaceSet : IfcTessellatedFaceSet, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcTriangulatedFaceSet>, IIfcTriangulatedFaceSet, IIfcTessellatedFaceSet, IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand
{
	private readonly OptionalItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue>> _normals;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean? _closed;

	private readonly ItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>> _coordIndex;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger> _pnIndex;

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 3 }, new int[] { -1, 3 }, 6)]
	public IOptionalItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue>> Normals
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
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean? Closed
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean? v)
			{
				_closed = v;
			}, _closed, value, "Closed", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 3 }, new int[] { -1, 3 }, 8)]
	public IItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>> CoordIndex
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
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger> PnIndex
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
	public Xbim.Ifc4x3.MeasureResource.IfcInteger NumberOfTriangles => CoordIndex.Count;

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

	[CrossSchemaAttribute(typeof(IIfcTriangulatedFaceSet), 2)]
	IItemSet<IItemSet<Xbim.Ifc4.MeasureResource.IfcParameterValue>> IIfcTriangulatedFaceSet.Normals => new ProxyNestedValueSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue, Xbim.Ifc4.MeasureResource.IfcParameterValue>(Normals, (Xbim.Ifc4x3.MeasureResource.IfcParameterValue s) => new Xbim.Ifc4.MeasureResource.IfcParameterValue(s), (Xbim.Ifc4.MeasureResource.IfcParameterValue t) => new Xbim.Ifc4x3.MeasureResource.IfcParameterValue(t));

	[CrossSchemaAttribute(typeof(IIfcTriangulatedFaceSet), 3)]
	Xbim.Ifc4.MeasureResource.IfcBoolean? IIfcTriangulatedFaceSet.Closed
	{
		get
		{
			if (!Closed.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(Closed.Value);
		}
		set
		{
			Closed = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcBoolean?(new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcBoolean?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTriangulatedFaceSet), 4)]
	IItemSet<IItemSet<Xbim.Ifc4.MeasureResource.IfcPositiveInteger>> IIfcTriangulatedFaceSet.CoordIndex => new ProxyNestedValueSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger, Xbim.Ifc4.MeasureResource.IfcPositiveInteger>(CoordIndex, (Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger s) => new Xbim.Ifc4.MeasureResource.IfcPositiveInteger(s), (Xbim.Ifc4.MeasureResource.IfcPositiveInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger(t));

	[CrossSchemaAttribute(typeof(IIfcTriangulatedFaceSet), 5)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcPositiveInteger> IIfcTriangulatedFaceSet.PnIndex => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger, Xbim.Ifc4.MeasureResource.IfcPositiveInteger>(PnIndex, (Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger s) => new Xbim.Ifc4.MeasureResource.IfcPositiveInteger(s), (Xbim.Ifc4.MeasureResource.IfcPositiveInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger(t));

	Xbim.Ifc4.MeasureResource.IfcInteger IIfcTriangulatedFaceSet.NumberOfTriangles => new Xbim.Ifc4.MeasureResource.IfcInteger(NumberOfTriangles);

	internal IfcTriangulatedFaceSet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_normals = new OptionalItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue>>(this, 0, 2);
		_coordIndex = new ItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>>(this, 0, 4);
		_pnIndex = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>(this, 0, 5);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			((ItemSet<Xbim.Ifc4x3.MeasureResource.IfcParameterValue>)_normals.InternalGetAt(nestedIndex[0])).InternalAdd(value.RealVal);
			break;
		case 2:
			_closed = value.BooleanVal;
			break;
		case 3:
			((ItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>)_coordIndex.InternalGetAt(nestedIndex[0])).InternalAdd(value.IntegerVal);
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
