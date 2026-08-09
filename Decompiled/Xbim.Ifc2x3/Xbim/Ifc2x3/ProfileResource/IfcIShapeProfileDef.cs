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

[ExpressType("IfcIShapeProfileDef", 352)]
public class IfcIShapeProfileDef : IfcParameterizedProfileDef, IIfcIShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcIShapeProfileDef>, IExpressValidatable
{
	public enum IfcIShapeProfileDefClause
	{
		WR1,
		WR2,
		WR3
	}

	private IfcNonNegativeLengthMeasure? _flangeEdgeRadius;

	private Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? _flangeSlope;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _overallWidth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _overallDepth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _webThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _flangeThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _filletRadius;

	[CrossSchemaAttribute(typeof(IIfcIShapeProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcIShapeProfileDef.OverallWidth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(OverallWidth);
		}
		set
		{
			OverallWidth = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcIShapeProfileDef), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcIShapeProfileDef.OverallDepth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(OverallDepth);
		}
		set
		{
			OverallDepth = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcIShapeProfileDef), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcIShapeProfileDef.WebThickness
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

	[CrossSchemaAttribute(typeof(IIfcIShapeProfileDef), 7)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcIShapeProfileDef.FlangeThickness
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

	[CrossSchemaAttribute(typeof(IIfcIShapeProfileDef), 8)]
	IfcNonNegativeLengthMeasure? IIfcIShapeProfileDef.FilletRadius
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

	[CrossSchemaAttribute(typeof(IIfcIShapeProfileDef), 9)]
	IfcNonNegativeLengthMeasure? IIfcIShapeProfileDef.FlangeEdgeRadius
	{
		get
		{
			return _flangeEdgeRadius;
		}
		set
		{
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_flangeEdgeRadius = v;
			}, _flangeEdgeRadius, value, "FlangeEdgeRadius", -9);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcIShapeProfileDef), 10)]
	Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? IIfcIShapeProfileDef.FlangeSlope
	{
		get
		{
			return _flangeSlope;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure? v)
			{
				_flangeSlope = v;
			}, _flangeSlope, value, "FlangeSlope", -10);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure OverallWidth
	{
		get
		{
			if (_activated)
			{
				return _overallWidth;
			}
			Activate();
			return _overallWidth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_overallWidth = v;
			}, _overallWidth, value, "OverallWidth", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure OverallDepth
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_overallDepth = v;
			}, _overallDepth, value, "OverallDepth", 5);
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

	internal IfcIShapeProfileDef(IModel model, int label, bool activated)
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
			_overallWidth = value.RealVal;
			break;
		case 4:
			_overallDepth = value.RealVal;
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
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcIShapeProfileDef other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcIShapeProfileDefClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcIShapeProfileDefClause.WR1:
				result = (double)FlangeThickness < (double)OverallDepth / 2.0;
				break;
			case IfcIShapeProfileDefClause.WR2:
				result = (double)WebThickness < (double)OverallWidth;
				break;
			case IfcIShapeProfileDefClause.WR3:
				result = !Functions.EXISTS(FilletRadius) || ((double?)FilletRadius <= ((double)OverallWidth - (double)WebThickness) / 2.0 && (double?)FilletRadius <= ((double)OverallDepth - 2.0 * (double)FlangeThickness) / 2.0);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcIShapeProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcIShapeProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcIShapeProfileDefClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcIShapeProfileDef.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcIShapeProfileDefClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcIShapeProfileDef.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcIShapeProfileDefClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcIShapeProfileDef.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
