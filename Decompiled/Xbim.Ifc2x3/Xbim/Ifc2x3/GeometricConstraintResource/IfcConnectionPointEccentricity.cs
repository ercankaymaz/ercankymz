using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.GeometricConstraintResource;

[ExpressType("IfcConnectionPointEccentricity", 405)]
public class IfcConnectionPointEccentricity : IfcConnectionPointGeometry, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcConnectionPointEccentricity>, IIfcConnectionPointEccentricity, IIfcConnectionPointGeometry, IIfcConnectionGeometry
{
	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _eccentricityInX;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _eccentricityInY;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _eccentricityInZ;

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? EccentricityInX
	{
		get
		{
			if (_activated)
			{
				return _eccentricityInX;
			}
			Activate();
			return _eccentricityInX;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_eccentricityInX = v;
			}, _eccentricityInX, value, "EccentricityInX", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? EccentricityInY
	{
		get
		{
			if (_activated)
			{
				return _eccentricityInY;
			}
			Activate();
			return _eccentricityInY;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_eccentricityInY = v;
			}, _eccentricityInY, value, "EccentricityInY", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? EccentricityInZ
	{
		get
		{
			if (_activated)
			{
				return _eccentricityInZ;
			}
			Activate();
			return _eccentricityInZ;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_eccentricityInZ = v;
			}, _eccentricityInZ, value, "EccentricityInZ", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.PointOnRelatingElement != null)
			{
				yield return base.PointOnRelatingElement;
			}
			if (base.PointOnRelatedElement != null)
			{
				yield return base.PointOnRelatedElement;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConnectionPointEccentricity), 3)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcConnectionPointEccentricity.EccentricityInX
	{
		get
		{
			if (!EccentricityInX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(EccentricityInX.Value);
		}
		set
		{
			EccentricityInX = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConnectionPointEccentricity), 4)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcConnectionPointEccentricity.EccentricityInY
	{
		get
		{
			if (!EccentricityInY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(EccentricityInY.Value);
		}
		set
		{
			EccentricityInY = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConnectionPointEccentricity), 5)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcConnectionPointEccentricity.EccentricityInZ
	{
		get
		{
			if (!EccentricityInZ.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(EccentricityInZ.Value);
		}
		set
		{
			EccentricityInZ = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	internal IfcConnectionPointEccentricity(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_eccentricityInX = value.RealVal;
			break;
		case 3:
			_eccentricityInY = value.RealVal;
			break;
		case 4:
			_eccentricityInZ = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConnectionPointEccentricity other)
	{
		return this == other;
	}
}
