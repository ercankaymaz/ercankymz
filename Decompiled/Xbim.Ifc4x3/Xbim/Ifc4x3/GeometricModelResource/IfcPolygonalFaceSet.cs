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

[ExpressType("IfcPolygonalFaceSet", 1324)]
public class IfcPolygonalFaceSet : IfcTessellatedFaceSet, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPolygonalFaceSet>, IIfcPolygonalFaceSet, IIfcTessellatedFaceSet, IIfcTessellatedItem, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand
{
	private Xbim.Ifc4x3.MeasureResource.IfcBoolean? _closed;

	private readonly ItemSet<IfcIndexedPolygonalFace> _faces;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger> _pnIndex;

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
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
			}, _closed, value, "Closed", 2);
		}
	}

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 7)]
	public IItemSet<IfcIndexedPolygonalFace> Faces
	{
		get
		{
			if (_activated)
			{
				return _faces;
			}
			Activate();
			return _faces;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 8)]
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

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Coordinates != null)
			{
				yield return base.Coordinates;
			}
			foreach (IfcIndexedPolygonalFace face in Faces)
			{
				yield return face;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcIndexedPolygonalFace face in Faces)
			{
				yield return face;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPolygonalFaceSet), 2)]
	Xbim.Ifc4.MeasureResource.IfcBoolean? IIfcPolygonalFaceSet.Closed
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

	[CrossSchemaAttribute(typeof(IIfcPolygonalFaceSet), 3)]
	IItemSet<IIfcIndexedPolygonalFace> IIfcPolygonalFaceSet.Faces => new ProxyItemSet<IfcIndexedPolygonalFace, IIfcIndexedPolygonalFace>(Faces);

	[CrossSchemaAttribute(typeof(IIfcPolygonalFaceSet), 4)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcPositiveInteger> IIfcPolygonalFaceSet.PnIndex => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger, Xbim.Ifc4.MeasureResource.IfcPositiveInteger>(PnIndex, (Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger s) => new Xbim.Ifc4.MeasureResource.IfcPositiveInteger(s), (Xbim.Ifc4.MeasureResource.IfcPositiveInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger(t));

	internal IfcPolygonalFaceSet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_faces = new ItemSet<IfcIndexedPolygonalFace>(this, 0, 3);
		_pnIndex = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcPositiveInteger>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_closed = value.BooleanVal;
			break;
		case 2:
			_faces.InternalAdd((IfcIndexedPolygonalFace)value.EntityVal);
			break;
		case 3:
			_pnIndex.InternalAdd(value.IntegerVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPolygonalFaceSet other)
	{
		return this == other;
	}
}
