using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.PresentationOrganizationResource;

[ExpressType("IfcLightSourceSpot", 760)]
public class IfcLightSourceSpot : IfcLightSourcePositional, IInstantiableEntity, IPersistEntity, IPersist, IIfcLightSourceSpot, IIfcLightSourcePositional, IIfcLightSource, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcLightSourceSpot>
{
	private IfcDirection _orientation;

	private IfcReal? _concentrationExponent;

	private IfcPositivePlaneAngleMeasure _spreadAngle;

	private IfcPositivePlaneAngleMeasure _beamWidthAngle;

	IIfcDirection IIfcLightSourceSpot.Orientation
	{
		get
		{
			return Orientation;
		}
		set
		{
			Orientation = value as IfcDirection;
		}
	}

	IfcReal? IIfcLightSourceSpot.ConcentrationExponent
	{
		get
		{
			return ConcentrationExponent;
		}
		set
		{
			ConcentrationExponent = value;
		}
	}

	IfcPositivePlaneAngleMeasure IIfcLightSourceSpot.SpreadAngle
	{
		get
		{
			return SpreadAngle;
		}
		set
		{
			SpreadAngle = value;
		}
	}

	IfcPositivePlaneAngleMeasure IIfcLightSourceSpot.BeamWidthAngle
	{
		get
		{
			return BeamWidthAngle;
		}
		set
		{
			BeamWidthAngle = value;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public IfcDirection Orientation
	{
		get
		{
			if (_activated)
			{
				return _orientation;
			}
			Activate();
			return _orientation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDirection v)
			{
				_orientation = v;
			}, _orientation, value, "Orientation", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcReal? ConcentrationExponent
	{
		get
		{
			if (_activated)
			{
				return _concentrationExponent;
			}
			Activate();
			return _concentrationExponent;
		}
		set
		{
			SetValue(delegate(IfcReal? v)
			{
				_concentrationExponent = v;
			}, _concentrationExponent, value, "ConcentrationExponent", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public IfcPositivePlaneAngleMeasure SpreadAngle
	{
		get
		{
			if (_activated)
			{
				return _spreadAngle;
			}
			Activate();
			return _spreadAngle;
		}
		set
		{
			SetValue(delegate(IfcPositivePlaneAngleMeasure v)
			{
				_spreadAngle = v;
			}, _spreadAngle, value, "SpreadAngle", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public IfcPositivePlaneAngleMeasure BeamWidthAngle
	{
		get
		{
			if (_activated)
			{
				return _beamWidthAngle;
			}
			Activate();
			return _beamWidthAngle;
		}
		set
		{
			SetValue(delegate(IfcPositivePlaneAngleMeasure v)
			{
				_beamWidthAngle = v;
			}, _beamWidthAngle, value, "BeamWidthAngle", 13);
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
			if (base.Position != null)
			{
				yield return base.Position;
			}
			if (Orientation != null)
			{
				yield return Orientation;
			}
		}
	}

	internal IfcLightSourceSpot(IModel model, int label, bool activated)
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
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_orientation = (IfcDirection)value.EntityVal;
			break;
		case 10:
			_concentrationExponent = value.RealVal;
			break;
		case 11:
			_spreadAngle = value.RealVal;
			break;
		case 12:
			_beamWidthAngle = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLightSourceSpot other)
	{
		return this == other;
	}
}
