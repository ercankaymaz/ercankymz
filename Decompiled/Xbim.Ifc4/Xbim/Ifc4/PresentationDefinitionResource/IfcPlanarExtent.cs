using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.PresentationDefinitionResource;

[ExpressType("IfcPlanarExtent", 469)]
public class IfcPlanarExtent : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcPlanarExtent, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcPlanarExtent>
{
	private IfcLengthMeasure _sizeInX;

	private IfcLengthMeasure _sizeInY;

	IfcLengthMeasure IIfcPlanarExtent.SizeInX
	{
		get
		{
			return SizeInX;
		}
		set
		{
			SizeInX = value;
		}
	}

	IfcLengthMeasure IIfcPlanarExtent.SizeInY
	{
		get
		{
			return SizeInY;
		}
		set
		{
			SizeInY = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLengthMeasure SizeInX
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
			SetValue(delegate(IfcLengthMeasure v)
			{
				_sizeInX = v;
			}, _sizeInX, value, "SizeInX", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure SizeInY
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
			SetValue(delegate(IfcLengthMeasure v)
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
