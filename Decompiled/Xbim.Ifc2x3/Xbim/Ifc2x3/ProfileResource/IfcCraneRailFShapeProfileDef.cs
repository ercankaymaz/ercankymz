using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.ProfileResource;

[ExpressType("IfcCraneRailFShapeProfileDef", 112)]
public class IfcCraneRailFShapeProfileDef : IfcParameterizedProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcCraneRailFShapeProfileDef>
{
	private IfcPositiveLengthMeasure _overallHeight;

	private IfcPositiveLengthMeasure _headWidth;

	private IfcPositiveLengthMeasure? _radius;

	private IfcPositiveLengthMeasure _headDepth2;

	private IfcPositiveLengthMeasure _headDepth3;

	private IfcPositiveLengthMeasure _webThickness;

	private IfcPositiveLengthMeasure _baseDepth1;

	private IfcPositiveLengthMeasure _baseDepth2;

	private IfcPositiveLengthMeasure? _centreOfGravityInY;

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPositiveLengthMeasure OverallHeight
	{
		get
		{
			if (_activated)
			{
				return _overallHeight;
			}
			Activate();
			return _overallHeight;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_overallHeight = v;
			}, _overallHeight, value, "OverallHeight", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveLengthMeasure HeadWidth
	{
		get
		{
			if (_activated)
			{
				return _headWidth;
			}
			Activate();
			return _headWidth;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_headWidth = v;
			}, _headWidth, value, "HeadWidth", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure? Radius
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
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_radius = v;
			}, _radius, value, "Radius", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPositiveLengthMeasure HeadDepth2
	{
		get
		{
			if (_activated)
			{
				return _headDepth2;
			}
			Activate();
			return _headDepth2;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_headDepth2 = v;
			}, _headDepth2, value, "HeadDepth2", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcPositiveLengthMeasure HeadDepth3
	{
		get
		{
			if (_activated)
			{
				return _headDepth3;
			}
			Activate();
			return _headDepth3;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_headDepth3 = v;
			}, _headDepth3, value, "HeadDepth3", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcPositiveLengthMeasure WebThickness
	{
		get
		{
			if (_activated)
			{
				return _webThickness;
			}
			Activate();
			return _webThickness;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_webThickness = v;
			}, _webThickness, value, "WebThickness", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcPositiveLengthMeasure BaseDepth1
	{
		get
		{
			if (_activated)
			{
				return _baseDepth1;
			}
			Activate();
			return _baseDepth1;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_baseDepth1 = v;
			}, _baseDepth1, value, "BaseDepth1", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcPositiveLengthMeasure BaseDepth2
	{
		get
		{
			if (_activated)
			{
				return _baseDepth2;
			}
			Activate();
			return _baseDepth2;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_baseDepth2 = v;
			}, _baseDepth2, value, "BaseDepth2", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcPositiveLengthMeasure? CentreOfGravityInY
	{
		get
		{
			if (_activated)
			{
				return _centreOfGravityInY;
			}
			Activate();
			return _centreOfGravityInY;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_centreOfGravityInY = v;
			}, _centreOfGravityInY, value, "CentreOfGravityInY", 12);
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

	internal IfcCraneRailFShapeProfileDef(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_overallHeight = value.RealVal;
			break;
		case 4:
			_headWidth = value.RealVal;
			break;
		case 5:
			_radius = value.RealVal;
			break;
		case 6:
			_headDepth2 = value.RealVal;
			break;
		case 7:
			_headDepth3 = value.RealVal;
			break;
		case 8:
			_webThickness = value.RealVal;
			break;
		case 9:
			_baseDepth1 = value.RealVal;
			break;
		case 10:
			_baseDepth2 = value.RealVal;
			break;
		case 11:
			_centreOfGravityInY = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCraneRailFShapeProfileDef other)
	{
		return this == other;
	}
}
