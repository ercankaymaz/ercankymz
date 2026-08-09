using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationOrganizationResource;

[ExpressType("IfcLightSourcePositional", 759)]
public class IfcLightSourcePositional : IfcLightSource, IIfcLightSourcePositional, IIfcLightSource, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationOrganizationResource.IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcLightSourcePositional>
{
	private IfcCartesianPoint _position;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _radius;

	private Xbim.Ifc4x3.MeasureResource.IfcReal _constantAttenuation;

	private Xbim.Ifc4x3.MeasureResource.IfcReal _distanceAttenuation;

	private Xbim.Ifc4x3.MeasureResource.IfcReal _quadricAttenuation;

	[CrossSchemaAttribute(typeof(IIfcLightSourcePositional), 5)]
	IIfcCartesianPoint IIfcLightSourcePositional.Position
	{
		get
		{
			return Position;
		}
		set
		{
			Position = value as IfcCartesianPoint;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightSourcePositional), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcLightSourcePositional.Radius
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Radius);
		}
		set
		{
			Radius = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightSourcePositional), 7)]
	Xbim.Ifc4.MeasureResource.IfcReal IIfcLightSourcePositional.ConstantAttenuation
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcReal(ConstantAttenuation);
		}
		set
		{
			ConstantAttenuation = new Xbim.Ifc4x3.MeasureResource.IfcReal(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightSourcePositional), 8)]
	Xbim.Ifc4.MeasureResource.IfcReal IIfcLightSourcePositional.DistanceAttenuation
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcReal(DistanceAttenuation);
		}
		set
		{
			DistanceAttenuation = new Xbim.Ifc4x3.MeasureResource.IfcReal(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightSourcePositional), 9)]
	Xbim.Ifc4.MeasureResource.IfcReal IIfcLightSourcePositional.QuadricAttenuation
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcReal(QuadricAttenuation);
		}
		set
		{
			QuadricAttenuation = new Xbim.Ifc4x3.MeasureResource.IfcReal(value);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcCartesianPoint Position
	{
		get
		{
			if (_activated)
			{
				return _position;
			}
			Activate();
			return _position;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPoint v)
			{
				_position = v;
			}, _position, value, "Position", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure Radius
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_radius = v;
			}, _radius, value, "Radius", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcReal ConstantAttenuation
	{
		get
		{
			if (_activated)
			{
				return _constantAttenuation;
			}
			Activate();
			return _constantAttenuation;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcReal v)
			{
				_constantAttenuation = v;
			}, _constantAttenuation, value, "ConstantAttenuation", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc4x3.MeasureResource.IfcReal DistanceAttenuation
	{
		get
		{
			if (_activated)
			{
				return _distanceAttenuation;
			}
			Activate();
			return _distanceAttenuation;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcReal v)
			{
				_distanceAttenuation = v;
			}, _distanceAttenuation, value, "DistanceAttenuation", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc4x3.MeasureResource.IfcReal QuadricAttenuation
	{
		get
		{
			if (_activated)
			{
				return _quadricAttenuation;
			}
			Activate();
			return _quadricAttenuation;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcReal v)
			{
				_quadricAttenuation = v;
			}, _quadricAttenuation, value, "QuadricAttenuation", 9);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.LightColour != null)
			{
				yield return base.LightColour;
			}
			if (Position != null)
			{
				yield return Position;
			}
		}
	}

	internal IfcLightSourcePositional(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_position = (IfcCartesianPoint)value.EntityVal;
			break;
		case 5:
			_radius = value.RealVal;
			break;
		case 6:
			_constantAttenuation = value.RealVal;
			break;
		case 7:
			_distanceAttenuation = value.RealVal;
			break;
		case 8:
			_quadricAttenuation = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLightSourcePositional other)
	{
		return this == other;
	}
}
