using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcAsymmetricIShapeProfileDef", 672)]
public class IfcAsymmetricIShapeProfileDef : IfcParameterizedProfileDef, IIfcAsymmetricIShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcAsymmetricIShapeProfileDef>
{
	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _bottomFlangeWidth;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _overallDepth;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _webThickness;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _bottomFlangeThickness;

	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? _bottomFlangeFilletRadius;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _topFlangeWidth;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _topFlangeThickness;

	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? _topFlangeFilletRadius;

	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? _bottomFlangeEdgeRadius;

	private Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? _bottomFlangeSlope;

	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? _topFlangeEdgeRadius;

	private Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? _topFlangeSlope;

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.BottomFlangeWidth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(BottomFlangeWidth);
		}
		set
		{
			BottomFlangeWidth = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.OverallDepth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(OverallDepth);
		}
		set
		{
			OverallDepth = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.WebThickness
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(WebThickness);
		}
		set
		{
			WebThickness = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 7)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.BottomFlangeThickness
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(BottomFlangeThickness);
		}
		set
		{
			BottomFlangeThickness = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 8)]
	Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcAsymmetricIShapeProfileDef.BottomFlangeFilletRadius
	{
		get
		{
			if (!BottomFlangeFilletRadius.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(BottomFlangeFilletRadius.Value);
		}
		set
		{
			BottomFlangeFilletRadius = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?)null));
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
			TopFlangeWidth = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
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
			TopFlangeThickness = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 11)]
	Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcAsymmetricIShapeProfileDef.TopFlangeFilletRadius
	{
		get
		{
			if (!TopFlangeFilletRadius.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(TopFlangeFilletRadius.Value);
		}
		set
		{
			TopFlangeFilletRadius = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 12)]
	Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcAsymmetricIShapeProfileDef.BottomFlangeEdgeRadius
	{
		get
		{
			if (!BottomFlangeEdgeRadius.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(BottomFlangeEdgeRadius.Value);
		}
		set
		{
			BottomFlangeEdgeRadius = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 13)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcAsymmetricIShapeProfileDef.BottomFlangeSlope
	{
		get
		{
			if (!BottomFlangeSlope.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure(BottomFlangeSlope.Value);
		}
		set
		{
			BottomFlangeSlope = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 14)]
	Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcAsymmetricIShapeProfileDef.TopFlangeEdgeRadius
	{
		get
		{
			if (!TopFlangeEdgeRadius.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(TopFlangeEdgeRadius.Value);
		}
		set
		{
			TopFlangeEdgeRadius = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAsymmetricIShapeProfileDef), 15)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcAsymmetricIShapeProfileDef.TopFlangeSlope
	{
		get
		{
			if (!TopFlangeSlope.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure(TopFlangeSlope.Value);
		}
		set
		{
			TopFlangeSlope = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure?)null));
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure BottomFlangeWidth
	{
		get
		{
			if (_activated)
			{
				return _bottomFlangeWidth;
			}
			Activate();
			return _bottomFlangeWidth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_bottomFlangeWidth = v;
			}, _bottomFlangeWidth, value, "BottomFlangeWidth", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure OverallDepth
	{
		get
		{
			if (_activated)
			{
				return _overallDepth;
			}
			Activate();
			return _overallDepth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_overallDepth = v;
			}, _overallDepth, value, "OverallDepth", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure WebThickness
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_webThickness = v;
			}, _webThickness, value, "WebThickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure BottomFlangeThickness
	{
		get
		{
			if (_activated)
			{
				return _bottomFlangeThickness;
			}
			Activate();
			return _bottomFlangeThickness;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_bottomFlangeThickness = v;
			}, _bottomFlangeThickness, value, "BottomFlangeThickness", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? BottomFlangeFilletRadius
	{
		get
		{
			if (_activated)
			{
				return _bottomFlangeFilletRadius;
			}
			Activate();
			return _bottomFlangeFilletRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? v)
			{
				_bottomFlangeFilletRadius = v;
			}, _bottomFlangeFilletRadius, value, "BottomFlangeFilletRadius", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure TopFlangeWidth
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_topFlangeWidth = v;
			}, _topFlangeWidth, value, "TopFlangeWidth", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? TopFlangeThickness
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_topFlangeThickness = v;
			}, _topFlangeThickness, value, "TopFlangeThickness", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? TopFlangeFilletRadius
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? v)
			{
				_topFlangeFilletRadius = v;
			}, _topFlangeFilletRadius, value, "TopFlangeFilletRadius", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? BottomFlangeEdgeRadius
	{
		get
		{
			if (_activated)
			{
				return _bottomFlangeEdgeRadius;
			}
			Activate();
			return _bottomFlangeEdgeRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? v)
			{
				_bottomFlangeEdgeRadius = v;
			}, _bottomFlangeEdgeRadius, value, "BottomFlangeEdgeRadius", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? BottomFlangeSlope
	{
		get
		{
			if (_activated)
			{
				return _bottomFlangeSlope;
			}
			Activate();
			return _bottomFlangeSlope;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? v)
			{
				_bottomFlangeSlope = v;
			}, _bottomFlangeSlope, value, "BottomFlangeSlope", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? TopFlangeEdgeRadius
	{
		get
		{
			if (_activated)
			{
				return _topFlangeEdgeRadius;
			}
			Activate();
			return _topFlangeEdgeRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? v)
			{
				_topFlangeEdgeRadius = v;
			}, _topFlangeEdgeRadius, value, "TopFlangeEdgeRadius", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? TopFlangeSlope
	{
		get
		{
			if (_activated)
			{
				return _topFlangeSlope;
			}
			Activate();
			return _topFlangeSlope;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? v)
			{
				_topFlangeSlope = v;
			}, _topFlangeSlope, value, "TopFlangeSlope", 15);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_bottomFlangeWidth = value.RealVal;
			break;
		case 4:
			_overallDepth = value.RealVal;
			break;
		case 5:
			_webThickness = value.RealVal;
			break;
		case 6:
			_bottomFlangeThickness = value.RealVal;
			break;
		case 7:
			_bottomFlangeFilletRadius = value.RealVal;
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
			_bottomFlangeEdgeRadius = value.RealVal;
			break;
		case 12:
			_bottomFlangeSlope = value.RealVal;
			break;
		case 13:
			_topFlangeEdgeRadius = value.RealVal;
			break;
		case 14:
			_topFlangeSlope = value.RealVal;
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
