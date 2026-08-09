using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcCartesianPointList3D", 1118)]
public class IfcCartesianPointList3D : IfcCartesianPointList, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcCartesianPointList3D>, IIfcCartesianPointList3D, IIfcCartesianPointList, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private readonly ItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>> _coordList;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLabel> _tagList;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 3 }, new int[] { -1, 3 }, 3)]
	public IItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>> CoordList
	{
		get
		{
			if (_activated)
			{
				return _coordList;
			}
			Activate();
			return _coordList;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 4)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLabel> TagList
	{
		get
		{
			if (_activated)
			{
				return _tagList;
			}
			Activate();
			return _tagList;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCartesianPointList3D), 1)]
	IItemSet<IItemSet<Xbim.Ifc4.MeasureResource.IfcLengthMeasure>> IIfcCartesianPointList3D.CoordList => new ProxyNestedValueSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure, Xbim.Ifc4.MeasureResource.IfcLengthMeasure>(CoordList, (Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure s) => new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(s), (Xbim.Ifc4.MeasureResource.IfcLengthMeasure t) => new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(t));

	[CrossSchemaAttribute(typeof(IIfcCartesianPointList3D), 2)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcLabel> IIfcCartesianPointList3D.TagList => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcLabel, Xbim.Ifc4.MeasureResource.IfcLabel>(TagList, (Xbim.Ifc4x3.MeasureResource.IfcLabel s) => new Xbim.Ifc4.MeasureResource.IfcLabel(s), (Xbim.Ifc4.MeasureResource.IfcLabel t) => new Xbim.Ifc4x3.MeasureResource.IfcLabel(t));

	internal IfcCartesianPointList3D(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_coordList = new ItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>>(this, 0, 1);
		_tagList = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcLabel>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			((ItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>)_coordList.InternalGetAt(nestedIndex[0])).InternalAdd(value.RealVal);
			break;
		case 1:
			_tagList.InternalAdd(value.StringVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCartesianPointList3D other)
	{
		return this == other;
	}
}
