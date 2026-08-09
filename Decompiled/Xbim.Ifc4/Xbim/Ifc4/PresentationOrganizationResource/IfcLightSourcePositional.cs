using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.PresentationOrganizationResource;

[ExpressType("IfcLightSourcePositional", 759)]
public class IfcLightSourcePositional : IfcLightSource, IInstantiableEntity, IPersistEntity, IPersist, IIfcLightSourcePositional, IIfcLightSource, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcLightSourcePositional>
{
	private IfcCartesianPoint _position;

	private IfcPositiveLengthMeasure _radius;

	private IfcReal _constantAttenuation;

	private IfcReal _distanceAttenuation;

	private IfcReal _quadricAttenuation;

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

	IfcPositiveLengthMeasure IIfcLightSourcePositional.Radius
	{
		get
		{
			return Radius;
		}
		set
		{
			Radius = value;
		}
	}

	IfcReal IIfcLightSourcePositional.ConstantAttenuation
	{
		get
		{
			return ConstantAttenuation;
		}
		set
		{
			ConstantAttenuation = value;
		}
	}

	IfcReal IIfcLightSourcePositional.DistanceAttenuation
	{
		get
		{
			return DistanceAttenuation;
		}
		set
		{
			DistanceAttenuation = value;
		}
	}

	IfcReal IIfcLightSourcePositional.QuadricAttenuation
	{
		get
		{
			return QuadricAttenuation;
		}
		set
		{
			QuadricAttenuation = value;
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
	public IfcPositiveLengthMeasure Radius
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_radius = v;
			}, _radius, value, "Radius", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcReal ConstantAttenuation
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
			SetValue(delegate(IfcReal v)
			{
				_constantAttenuation = v;
			}, _constantAttenuation, value, "ConstantAttenuation", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcReal DistanceAttenuation
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
			SetValue(delegate(IfcReal v)
			{
				_distanceAttenuation = v;
			}, _distanceAttenuation, value, "DistanceAttenuation", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcReal QuadricAttenuation
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
			SetValue(delegate(IfcReal v)
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
