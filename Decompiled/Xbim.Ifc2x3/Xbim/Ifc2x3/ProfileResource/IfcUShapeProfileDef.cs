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

[ExpressType("IfcUShapeProfileDef", 670)]
public class IfcUShapeProfileDef : IfcParameterizedProfileDef, IIfcUShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcUShapeProfileDef>, IExpressValidatable
{
	public enum IfcUShapeProfileDefClause
	{
		WR21,
		WR22
	}

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _depth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _flangeWidth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _webThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _flangeThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _filletRadius;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _edgeRadius;

	private Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure? _flangeSlope;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _centreOfGravityInX;

	[CrossSchemaAttribute(typeof(IIfcUShapeProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcUShapeProfileDef.Depth
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

	[CrossSchemaAttribute(typeof(IIfcUShapeProfileDef), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcUShapeProfileDef.FlangeWidth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(FlangeWidth);
		}
		set
		{
			FlangeWidth = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcUShapeProfileDef), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcUShapeProfileDef.WebThickness
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(WebThickness);
		}
		set
		{
			WebThickness = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcUShapeProfileDef), 7)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcUShapeProfileDef.FlangeThickness
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(FlangeThickness);
		}
		set
		{
			FlangeThickness = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcUShapeProfileDef), 8)]
	IfcNonNegativeLengthMeasure? IIfcUShapeProfileDef.FilletRadius
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

	[CrossSchemaAttribute(typeof(IIfcUShapeProfileDef), 9)]
	IfcNonNegativeLengthMeasure? IIfcUShapeProfileDef.EdgeRadius
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

	[CrossSchemaAttribute(typeof(IIfcUShapeProfileDef), 10)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcUShapeProfileDef.FlangeSlope
	{
		get
		{
			if (!FlangeSlope.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure(FlangeSlope.Value);
		}
		set
		{
			FlangeSlope = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure?)null));
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

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure FlangeWidth
	{
		get
		{
			if (_activated)
			{
				return _flangeWidth;
			}
			Activate();
			return _flangeWidth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_flangeWidth = v;
			}, _flangeWidth, value, "FlangeWidth", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure WebThickness
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_webThickness = v;
			}, _webThickness, value, "WebThickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure FlangeThickness
	{
		get
		{
			if (_activated)
			{
				return _flangeThickness;
			}
			Activate();
			return _flangeThickness;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_flangeThickness = v;
			}, _flangeThickness, value, "FlangeThickness", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
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
			}, _filletRadius, value, "FilletRadius", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
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
			}, _edgeRadius, value, "EdgeRadius", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure? FlangeSlope
	{
		get
		{
			if (_activated)
			{
				return _flangeSlope;
			}
			Activate();
			return _flangeSlope;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure? v)
			{
				_flangeSlope = v;
			}, _flangeSlope, value, "FlangeSlope", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
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
			}, _centreOfGravityInX, value, "CentreOfGravityInX", 11);
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

	internal IfcUShapeProfileDef(IModel model, int label, bool activated)
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
			_flangeWidth = value.RealVal;
			break;
		case 5:
			_webThickness = value.RealVal;
			break;
		case 6:
			_flangeThickness = value.RealVal;
			break;
		case 7:
			_filletRadius = value.RealVal;
			break;
		case 8:
			_edgeRadius = value.RealVal;
			break;
		case 9:
			_flangeSlope = value.RealVal;
			break;
		case 10:
			_centreOfGravityInX = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcUShapeProfileDef other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcUShapeProfileDefClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcUShapeProfileDefClause.WR21:
				result = (double)FlangeThickness < (double)Depth / 2.0;
				break;
			case IfcUShapeProfileDefClause.WR22:
				result = (double)WebThickness < (double)FlangeWidth;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcUShapeProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcUShapeProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcUShapeProfileDefClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcUShapeProfileDef.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcUShapeProfileDefClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcUShapeProfileDef.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
