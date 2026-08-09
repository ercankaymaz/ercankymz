using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcLShapeProfileDef", 284)]
public class IfcLShapeProfileDef : IfcParameterizedProfileDef, IIfcLShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcLShapeProfileDef>
{
	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _depth;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _width;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _thickness;

	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? _filletRadius;

	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? _edgeRadius;

	private Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? _legSlope;

	[CrossSchemaAttribute(typeof(IIfcLShapeProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcLShapeProfileDef.Depth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Depth);
		}
		set
		{
			Depth = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLShapeProfileDef), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcLShapeProfileDef.Width
	{
		get
		{
			if (!Width.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Width.Value);
		}
		set
		{
			Width = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLShapeProfileDef), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcLShapeProfileDef.Thickness
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Thickness);
		}
		set
		{
			Thickness = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLShapeProfileDef), 7)]
	Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcLShapeProfileDef.FilletRadius
	{
		get
		{
			if (!FilletRadius.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(FilletRadius.Value);
		}
		set
		{
			FilletRadius = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLShapeProfileDef), 8)]
	Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcLShapeProfileDef.EdgeRadius
	{
		get
		{
			if (!EdgeRadius.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(EdgeRadius.Value);
		}
		set
		{
			EdgeRadius = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLShapeProfileDef), 9)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcLShapeProfileDef.LegSlope
	{
		get
		{
			if (!LegSlope.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure(LegSlope.Value);
		}
		set
		{
			LegSlope = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure?)null));
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure Depth
	{
		get
		{
			if (_activated)
			{
				return _depth;
			}
			Activate();
			return _depth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_depth = v;
			}, _depth, value, "Depth", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? Width
	{
		get
		{
			if (_activated)
			{
				return _width;
			}
			Activate();
			return _width;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_width = v;
			}, _width, value, "Width", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure Thickness
	{
		get
		{
			if (_activated)
			{
				return _thickness;
			}
			Activate();
			return _thickness;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_thickness = v;
			}, _thickness, value, "Thickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? FilletRadius
	{
		get
		{
			if (_activated)
			{
				return _filletRadius;
			}
			Activate();
			return _filletRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? v)
			{
				_filletRadius = v;
			}, _filletRadius, value, "FilletRadius", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? EdgeRadius
	{
		get
		{
			if (_activated)
			{
				return _edgeRadius;
			}
			Activate();
			return _edgeRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? v)
			{
				_edgeRadius = v;
			}, _edgeRadius, value, "EdgeRadius", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? LegSlope
	{
		get
		{
			if (_activated)
			{
				return _legSlope;
			}
			Activate();
			return _legSlope;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure? v)
			{
				_legSlope = v;
			}, _legSlope, value, "LegSlope", 9);
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

	internal IfcLShapeProfileDef(IModel model, int label, bool activated)
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
			_depth = value.RealVal;
			break;
		case 4:
			_width = value.RealVal;
			break;
		case 5:
			_thickness = value.RealVal;
			break;
		case 6:
			_filletRadius = value.RealVal;
			break;
		case 7:
			_edgeRadius = value.RealVal;
			break;
		case 8:
			_legSlope = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLShapeProfileDef other)
	{
		return this == other;
	}
}
