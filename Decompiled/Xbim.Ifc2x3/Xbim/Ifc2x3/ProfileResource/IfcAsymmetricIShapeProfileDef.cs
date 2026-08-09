using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProfileResource;

[ExpressType("IfcAsymmetricIShapeProfileDef", 672)]
public class IfcAsymmetricIShapeProfileDef : IfcIShapeProfileDef, IIfcAsymmetricIShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcAsymmetricIShapeProfileDef>
{
	private IfcNonNegativeLengthMeasure? _bottomFlangeEdgeRadius;

	private Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? _bottomFlangeSlope;

	private IfcNonNegativeLengthMeasure? _topFlangeEdgeRadius;

	private Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? _topFlangeSlope;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _topFlangeWidth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _topFlangeThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _topFlangeFilletRadius;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _centreOfGravityInY;

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.BottomFlangeWidth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(base.OverallWidth);
		}
		set
		{
			base.OverallWidth = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.OverallDepth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(base.OverallDepth);
		}
		set
		{
			base.OverallDepth = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.WebThickness
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(base.WebThickness);
		}
		set
		{
			base.WebThickness = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 7)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.BottomFlangeThickness
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(base.FlangeThickness);
		}
		set
		{
			base.FlangeThickness = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 8)]
	IfcNonNegativeLengthMeasure? IIfcAsymmetricIShapeProfileDef.BottomFlangeFilletRadius
	{
		get
		{
			if (!base.FilletRadius.HasValue)
			{
				return null;
			}
			return new IfcNonNegativeLengthMeasure(base.FilletRadius.Value);
		}
		set
		{
			base.FilletRadius = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 9)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.TopFlangeWidth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(TopFlangeWidth);
		}
		set
		{
			TopFlangeWidth = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 10)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcAsymmetricIShapeProfileDef.TopFlangeThickness
	{
		get
		{
			if (!TopFlangeThickness.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(TopFlangeThickness.Value);
		}
		set
		{
			TopFlangeThickness = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 11)]
	IfcNonNegativeLengthMeasure? IIfcAsymmetricIShapeProfileDef.TopFlangeFilletRadius
	{
		get
		{
			if (!TopFlangeFilletRadius.HasValue)
			{
				return null;
			}
			return new IfcNonNegativeLengthMeasure(TopFlangeFilletRadius.Value);
		}
		set
		{
			TopFlangeFilletRadius = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 12)]
	IfcNonNegativeLengthMeasure? IIfcAsymmetricIShapeProfileDef.BottomFlangeEdgeRadius
	{
		get
		{
			return _bottomFlangeEdgeRadius;
		}
		set
		{
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_bottomFlangeEdgeRadius = v;
			}, _bottomFlangeEdgeRadius, value, "BottomFlangeEdgeRadius", -12);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 13)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcAsymmetricIShapeProfileDef.BottomFlangeSlope
	{
		get
		{
			return _bottomFlangeSlope;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? v)
			{
				_bottomFlangeSlope = v;
			}, _bottomFlangeSlope, value, "BottomFlangeSlope", -13);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 14)]
	IfcNonNegativeLengthMeasure? IIfcAsymmetricIShapeProfileDef.TopFlangeEdgeRadius
	{
		get
		{
			return _topFlangeEdgeRadius;
		}
		set
		{
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_topFlangeEdgeRadius = v;
			}, _topFlangeEdgeRadius, value, "TopFlangeEdgeRadius", -14);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 15)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcAsymmetricIShapeProfileDef.TopFlangeSlope
	{
		get
		{
			return _topFlangeSlope;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? v)
			{
				_topFlangeSlope = v;
			}, _topFlangeSlope, value, "TopFlangeSlope", -15);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure TopFlangeWidth
	{
		get
		{
			if (_activated)
			{
				return _topFlangeWidth;
			}
			Activate();
			return _topFlangeWidth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_topFlangeWidth = v;
			}, _topFlangeWidth, value, "TopFlangeWidth", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? TopFlangeThickness
	{
		get
		{
			if (_activated)
			{
				return _topFlangeThickness;
			}
			Activate();
			return _topFlangeThickness;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_topFlangeThickness = v;
			}, _topFlangeThickness, value, "TopFlangeThickness", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? TopFlangeFilletRadius
	{
		get
		{
			if (_activated)
			{
				return _topFlangeFilletRadius;
			}
			Activate();
			return _topFlangeFilletRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_topFlangeFilletRadius = v;
			}, _topFlangeFilletRadius, value, "TopFlangeFilletRadius", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? CentreOfGravityInY
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
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

	internal IfcAsymmetricIShapeProfileDef(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_topFlangeWidth = value.RealVal;
			break;
		case 9:
			_topFlangeThickness = value.RealVal;
			break;
		case 10:
			_topFlangeFilletRadius = value.RealVal;
			break;
		case 11:
			_centreOfGravityInY = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAsymmetricIShapeProfileDef other)
	{
		return this == other;
	}
}
