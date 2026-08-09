using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcCartesianPointList3D", 1118)]
public class IfcCartesianPointList3D : IfcCartesianPointList, IInstantiableEntity, IPersistEntity, IPersist, IIfcCartesianPointList3D, IIfcCartesianPointList, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcCartesianPointList3D>
{
	private readonly ItemSet<IItemSet<IfcLengthMeasure>> _coordList;

	private readonly OptionalItemSet<IfcLabel> _tagList;

	IItemSet<IItemSet<IfcLengthMeasure>> IIfcCartesianPointList3D.CoordList => CoordList;

	IItemSet<IfcLabel> IIfcCartesianPointList3D.TagList => TagList;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 3 }, new int[] { -1, 3 }, 3)]
	public IItemSet<IItemSet<IfcLengthMeasure>> CoordList
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
	public IOptionalItemSet<IfcLabel> TagList
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

	internal IfcCartesianPointList3D(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_coordList = new ItemSet<IItemSet<IfcLengthMeasure>>(this, 0, 1);
		_tagList = new OptionalItemSet<IfcLabel>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			((ItemSet<IfcLengthMeasure>)_coordList.InternalGetAt(nestedIndex[0])).InternalAdd(value.RealVal);
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
