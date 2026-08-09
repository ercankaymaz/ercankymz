using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcRightCircularCylinder", 704)]
public class IfcRightCircularCylinder : IfcCsgPrimitive3D, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcRightCircularCylinder>, IIfcRightCircularCylinder, IIfcCsgPrimitive3D, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, Xbim.Ifc4.GeometricModelResource.IfcCsgSelect, IIfcCsgSelect
{
	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _height;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _radius;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure Height
	{
		get
		{
			if (_activated)
			{
				return _height;
			}
			Activate();
			return _height;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_height = v;
			}, _height, value, "Height", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure Radius
	{
		get
		{
			if (_activated)
			{
				return _radius;
			}
			Activate();
			return _radius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_radius = v;
			}, _radius, value, "Radius", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Position != null)
			{
				yield return base.Position;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRightCircularCylinder), 2)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcRightCircularCylinder.Height
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Height);
		}
		set
		{
			Height = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRightCircularCylinder), 3)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcRightCircularCylinder.Radius
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Radius);
		}
		set
		{
			Radius = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	internal IfcRightCircularCylinder(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_height = value.RealVal;
			break;
		case 2:
			_radius = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRightCircularCylinder other)
	{
		return this == other;
	}
}
