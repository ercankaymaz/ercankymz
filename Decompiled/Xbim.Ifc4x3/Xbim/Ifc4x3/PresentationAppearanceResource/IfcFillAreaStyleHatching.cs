using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcFillAreaStyleHatching", 462)]
public class IfcFillAreaStyleHatching : IfcGeometricRepresentationItem, IIfcFillAreaStyleHatching, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.PresentationAppearanceResource.IfcFillStyleSelect, IIfcFillStyleSelect, IInstantiableEntity, IfcFillStyleSelect, IContainsEntityReferences, IEquatable<IfcFillAreaStyleHatching>
{
	private IfcCurveStyle _hatchLineAppearance;

	private IfcHatchLineDistanceSelect _startOfNextHatchLine;

	private IfcCartesianPoint _pointOfReferenceHatchLine;

	private IfcCartesianPoint _patternStart;

	private Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure _hatchLineAngle;

	[CrossSchemaAttribute(typeof(IIfcFillAreaStyleHatching), 1)]
	IIfcCurveStyle IIfcFillAreaStyleHatching.HatchLineAppearance
	{
		get
		{
			return HatchLineAppearance;
		}
		set
		{
			HatchLineAppearance = value as IfcCurveStyle;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFillAreaStyleHatching), 2)]
	IIfcHatchLineDistanceSelect IIfcFillAreaStyleHatching.StartOfNextHatchLine
	{
		get
		{
			if (StartOfNextHatchLine == null)
			{
				return null;
			}
			if (StartOfNextHatchLine is Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure)(object)StartOfNextHatchLine);
			}
			IfcVector ifcVector = StartOfNextHatchLine as IfcVector;
			if (ifcVector != null)
			{
				return ifcVector;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				StartOfNextHatchLine = null;
				return;
			}
			IfcVector ifcVector = value as IfcVector;
			if (ifcVector != null)
			{
				StartOfNextHatchLine = ifcVector;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				StartOfNextHatchLine = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFillAreaStyleHatching), 3)]
	IIfcCartesianPoint IIfcFillAreaStyleHatching.PointOfReferenceHatchLine
	{
		get
		{
			return PointOfReferenceHatchLine;
		}
		set
		{
			PointOfReferenceHatchLine = value as IfcCartesianPoint;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFillAreaStyleHatching), 4)]
	IIfcCartesianPoint IIfcFillAreaStyleHatching.PatternStart
	{
		get
		{
			return PatternStart;
		}
		set
		{
			PatternStart = value as IfcCartesianPoint;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFillAreaStyleHatching), 5)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure IIfcFillAreaStyleHatching.HatchLineAngle
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure(HatchLineAngle);
		}
		set
		{
			HatchLineAngle = new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure(value);
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcCurveStyle HatchLineAppearance
	{
		get
		{
			if (_activated)
			{
				return _hatchLineAppearance;
			}
			Activate();
			return _hatchLineAppearance;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurveStyle v)
			{
				_hatchLineAppearance = v;
			}, _hatchLineAppearance, value, "HatchLineAppearance", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcHatchLineDistanceSelect StartOfNextHatchLine
	{
		get
		{
			if (_activated)
			{
				return _startOfNextHatchLine;
			}
			Activate();
			return _startOfNextHatchLine;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcHatchLineDistanceSelect v)
			{
				_startOfNextHatchLine = v;
			}, _startOfNextHatchLine, value, "StartOfNextHatchLine", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcCartesianPoint PointOfReferenceHatchLine
	{
		get
		{
			if (_activated)
			{
				return _pointOfReferenceHatchLine;
			}
			Activate();
			return _pointOfReferenceHatchLine;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPoint v)
			{
				_pointOfReferenceHatchLine = v;
			}, _pointOfReferenceHatchLine, value, "PointOfReferenceHatchLine", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcCartesianPoint PatternStart
	{
		get
		{
			if (_activated)
			{
				return _patternStart;
			}
			Activate();
			return _patternStart;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianPoint v)
			{
				_patternStart = v;
			}, _patternStart, value, "PatternStart", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure HatchLineAngle
	{
		get
		{
			if (_activated)
			{
				return _hatchLineAngle;
			}
			Activate();
			return _hatchLineAngle;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure v)
			{
				_hatchLineAngle = v;
			}, _hatchLineAngle, value, "HatchLineAngle", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (HatchLineAppearance != null)
			{
				yield return HatchLineAppearance;
			}
			if (PointOfReferenceHatchLine != null)
			{
				yield return PointOfReferenceHatchLine;
			}
			if (PatternStart != null)
			{
				yield return PatternStart;
			}
		}
	}

	internal IfcFillAreaStyleHatching(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_hatchLineAppearance = (IfcCurveStyle)value.EntityVal;
			break;
		case 1:
			_startOfNextHatchLine = (IfcHatchLineDistanceSelect)value.EntityVal;
			break;
		case 2:
			_pointOfReferenceHatchLine = (IfcCartesianPoint)value.EntityVal;
			break;
		case 3:
			_patternStart = (IfcCartesianPoint)value.EntityVal;
			break;
		case 4:
			_hatchLineAngle = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFillAreaStyleHatching other)
	{
		return this == other;
	}
}
