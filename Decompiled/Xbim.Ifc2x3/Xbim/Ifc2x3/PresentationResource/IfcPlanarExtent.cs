using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.PresentationResource;

[ExpressType("IfcPlanarExtent", 469)]
public class IfcPlanarExtent : IfcGeometricRepresentationItem, IIfcPlanarExtent, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IEquatable<IfcPlanarExtent>
{
	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure _sizeInX;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure _sizeInY;

	[CrossSchemaAttribute(typeof(IIfcPlanarExtent), 1)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcPlanarExtent.SizeInX
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(SizeInX);
		}
		set
		{
			SizeInX = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPlanarExtent), 2)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcPlanarExtent.SizeInY
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(SizeInY);
		}
		set
		{
			SizeInY = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure SizeInX
	{
		get
		{
			if (_activated)
			{
				return _sizeInX;
			}
			Activate();
			return _sizeInX;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure v)
			{
				_sizeInX = v;
			}, _sizeInX, value, "SizeInX", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure SizeInY
	{
		get
		{
			if (_activated)
			{
				return _sizeInY;
			}
			Activate();
			return _sizeInY;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure v)
			{
				_sizeInY = v;
			}, _sizeInY, value, "SizeInY", 2);
		}
	}

	internal IfcPlanarExtent(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_sizeInX = value.RealVal;
			break;
		case 1:
			_sizeInY = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPlanarExtent other)
	{
		return this == other;
	}
}
