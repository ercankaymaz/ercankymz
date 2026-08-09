using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProfileResource;

[ExpressType("IfcLShapeProfileDef", 284)]
public class IfcLShapeProfileDef : IfcParameterizedProfileDef, IIfcLShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcLShapeProfileDef>, IExpressValidatable
{
	public enum IfcLShapeProfileDefClause
	{
		WR21,
		WR22
	}

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _depth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _width;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _thickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _filletRadius;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _edgeRadius;

	private Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure? _legSlope;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _centreOfGravityInX;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _centreOfGravityInY;

	[CrossSchemaAttribute(typeof(IIfcLShapeProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcLShapeProfileDef.Depth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Depth);
		}
		set
		{
			Depth = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
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
			Width = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
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
			Thickness = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLShapeProfileDef), 7)]
	IfcNonNegativeLengthMeasure? IIfcLShapeProfileDef.FilletRadius
	{
		get
		{
			if (!FilletRadius.HasValue)
			{
				return null;
			}
			return new IfcNonNegativeLengthMeasure(FilletRadius.Value);
		}
		set
		{
			FilletRadius = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLShapeProfileDef), 8)]
	IfcNonNegativeLengthMeasure? IIfcLShapeProfileDef.EdgeRadius
	{
		get
		{
			if (!EdgeRadius.HasValue)
			{
				return null;
			}
			return new IfcNonNegativeLengthMeasure(EdgeRadius.Value);
		}
		set
		{
			EdgeRadius = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
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
			LegSlope = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure?)null));
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure Depth
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_depth = v;
			}, _depth, value, "Depth", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? Width
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_width = v;
			}, _width, value, "Width", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure Thickness
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_thickness = v;
			}, _thickness, value, "Thickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? FilletRadius
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_filletRadius = v;
			}, _filletRadius, value, "FilletRadius", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? EdgeRadius
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_edgeRadius = v;
			}, _edgeRadius, value, "EdgeRadius", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure? LegSlope
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure? v)
			{
				_legSlope = v;
			}, _legSlope, value, "LegSlope", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? CentreOfGravityInX
	{
		get
		{
			if (_activated)
			{
				return _centreOfGravityInX;
			}
			Activate();
			return _centreOfGravityInX;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_centreOfGravityInX = v;
			}, _centreOfGravityInX, value, "CentreOfGravityInX", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
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
			}, _centreOfGravityInY, value, "CentreOfGravityInY", 11);
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
		case 9:
			_centreOfGravityInX = value.RealVal;
			break;
		case 10:
			_centreOfGravityInY = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLShapeProfileDef other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcLShapeProfileDefClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcLShapeProfileDefClause.WR21:
				result = (double)Thickness < (double)Depth;
				break;
			case IfcLShapeProfileDefClause.WR22:
				result = !Functions.EXISTS(Width) || (double)Thickness < (double?)Width;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcLShapeProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcLShapeProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcLShapeProfileDefClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcLShapeProfileDef.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcLShapeProfileDefClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcLShapeProfileDef.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
