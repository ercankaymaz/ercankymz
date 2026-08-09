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

[ExpressType("IfcTShapeProfileDef", 671)]
public class IfcTShapeProfileDef : IfcParameterizedProfileDef, IIfcTShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcTShapeProfileDef>, IExpressValidatable
{
	public enum IfcTShapeProfileDefClause
	{
		WR1,
		WR2
	}

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _depth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _flangeWidth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _webThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _flangeThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _filletRadius;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _flangeEdgeRadius;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _webEdgeRadius;

	private Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure? _webSlope;

	private Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure? _flangeSlope;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _centreOfGravityInY;

	[CrossSchemaAttribute(typeof(IIfcTShapeProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcTShapeProfileDef.Depth
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

	[CrossSchemaAttribute(typeof(IIfcTShapeProfileDef), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcTShapeProfileDef.FlangeWidth
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

	[CrossSchemaAttribute(typeof(IIfcTShapeProfileDef), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcTShapeProfileDef.WebThickness
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

	[CrossSchemaAttribute(typeof(IIfcTShapeProfileDef), 7)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcTShapeProfileDef.FlangeThickness
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

	[CrossSchemaAttribute(typeof(IIfcTShapeProfileDef), 8)]
	IfcNonNegativeLengthMeasure? IIfcTShapeProfileDef.FilletRadius
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

	[CrossSchemaAttribute(typeof(IIfcTShapeProfileDef), 9)]
	IfcNonNegativeLengthMeasure? IIfcTShapeProfileDef.FlangeEdgeRadius
	{
		get
		{
			if (!FlangeEdgeRadius.HasValue)
			{
				return null;
			}
			return new IfcNonNegativeLengthMeasure(FlangeEdgeRadius.Value);
		}
		set
		{
			FlangeEdgeRadius = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTShapeProfileDef), 10)]
	IfcNonNegativeLengthMeasure? IIfcTShapeProfileDef.WebEdgeRadius
	{
		get
		{
			if (!WebEdgeRadius.HasValue)
			{
				return null;
			}
			return new IfcNonNegativeLengthMeasure(WebEdgeRadius.Value);
		}
		set
		{
			WebEdgeRadius = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTShapeProfileDef), 11)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcTShapeProfileDef.WebSlope
	{
		get
		{
			if (!WebSlope.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure(WebSlope.Value);
		}
		set
		{
			WebSlope = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTShapeProfileDef), 12)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcTShapeProfileDef.FlangeSlope
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
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? FlangeEdgeRadius
	{
		get
		{
			if (_activated)
			{
				return _flangeEdgeRadius;
			}
			Activate();
			return _flangeEdgeRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_flangeEdgeRadius = v;
			}, _flangeEdgeRadius, value, "FlangeEdgeRadius", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? WebEdgeRadius
	{
		get
		{
			if (_activated)
			{
				return _webEdgeRadius;
			}
			Activate();
			return _webEdgeRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_webEdgeRadius = v;
			}, _webEdgeRadius, value, "WebEdgeRadius", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure? WebSlope
	{
		get
		{
			if (_activated)
			{
				return _webSlope;
			}
			Activate();
			return _webSlope;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPlaneAngleMeasure? v)
			{
				_webSlope = v;
			}, _webSlope, value, "WebSlope", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
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
			}, _flangeSlope, value, "FlangeSlope", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
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
			}, _centreOfGravityInY, value, "CentreOfGravityInY", 13);
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

	internal IfcTShapeProfileDef(IModel model, int label, bool activated)
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
			_flangeEdgeRadius = value.RealVal;
			break;
		case 9:
			_webEdgeRadius = value.RealVal;
			break;
		case 10:
			_webSlope = value.RealVal;
			break;
		case 11:
			_flangeSlope = value.RealVal;
			break;
		case 12:
			_centreOfGravityInY = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTShapeProfileDef other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTShapeProfileDefClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcTShapeProfileDefClause.WR1:
				result = (double)FlangeThickness < (double)Depth;
				break;
			case IfcTShapeProfileDefClause.WR2:
				result = (double)WebThickness < (double)FlangeWidth;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTShapeProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcTShapeProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcTShapeProfileDefClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTShapeProfileDef.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTShapeProfileDefClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTShapeProfileDef.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
