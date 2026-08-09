using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcConnectionPointEccentricity", 405)]
public class IfcConnectionPointEccentricity : IfcConnectionPointGeometry, IInstantiableEntity, IPersistEntity, IPersist, IIfcConnectionPointEccentricity, IIfcConnectionPointGeometry, IIfcConnectionGeometry, IContainsEntityReferences, IEquatable<IfcConnectionPointEccentricity>
{
	private IfcLengthMeasure? _eccentricityInX;

	private IfcLengthMeasure? _eccentricityInY;

	private IfcLengthMeasure? _eccentricityInZ;

	IfcLengthMeasure? IIfcConnectionPointEccentricity.EccentricityInX
	{
		get
		{
			return EccentricityInX;
		}
		set
		{
			EccentricityInX = value;
		}
	}

	IfcLengthMeasure? IIfcConnectionPointEccentricity.EccentricityInY
	{
		get
		{
			return EccentricityInY;
		}
		set
		{
			EccentricityInY = value;
		}
	}

	IfcLengthMeasure? IIfcConnectionPointEccentricity.EccentricityInZ
	{
		get
		{
			return EccentricityInZ;
		}
		set
		{
			EccentricityInZ = value;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLengthMeasure? EccentricityInX
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
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_eccentricityInX = v;
			}, _eccentricityInX, value, "EccentricityInX", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLengthMeasure? EccentricityInY
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
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_eccentricityInY = v;
			}, _eccentricityInY, value, "EccentricityInY", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLengthMeasure? EccentricityInZ
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
			SetValue(delegate(IfcLengthMeasure? v)
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
