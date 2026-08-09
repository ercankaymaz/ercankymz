using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcIShapeProfileDef", 352)]
public class IfcIShapeProfileDef : IfcParameterizedProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcIShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcIShapeProfileDef>, IExpressValidatable
{
	public enum IfcIShapeProfileDefClause
	{
		ValidFlangeThickness,
		ValidWebThickness,
		ValidFilletRadius
	}

	private IfcPositiveLengthMeasure _overallWidth;

	private IfcPositiveLengthMeasure _overallDepth;

	private IfcPositiveLengthMeasure _webThickness;

	private IfcPositiveLengthMeasure _flangeThickness;

	private IfcNonNegativeLengthMeasure? _filletRadius;

	private IfcNonNegativeLengthMeasure? _flangeEdgeRadius;

	private IfcPlaneAngleMeasure? _flangeSlope;

	IfcPositiveLengthMeasure IIfcIShapeProfileDef.OverallWidth
	{
		get
		{
			return OverallWidth;
		}
		set
		{
			OverallWidth = value;
		}
	}

	IfcPositiveLengthMeasure IIfcIShapeProfileDef.OverallDepth
	{
		get
		{
			return OverallDepth;
		}
		set
		{
			OverallDepth = value;
		}
	}

	IfcPositiveLengthMeasure IIfcIShapeProfileDef.WebThickness
	{
		get
		{
			return WebThickness;
		}
		set
		{
			WebThickness = value;
		}
	}

	IfcPositiveLengthMeasure IIfcIShapeProfileDef.FlangeThickness
	{
		get
		{
			return FlangeThickness;
		}
		set
		{
			FlangeThickness = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcIShapeProfileDef.FilletRadius
	{
		get
		{
			return FilletRadius;
		}
		set
		{
			FilletRadius = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcIShapeProfileDef.FlangeEdgeRadius
	{
		get
		{
			return FlangeEdgeRadius;
		}
		set
		{
			FlangeEdgeRadius = value;
		}
	}

	IfcPlaneAngleMeasure? IIfcIShapeProfileDef.FlangeSlope
	{
		get
		{
			return FlangeSlope;
		}
		set
		{
			FlangeSlope = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure OverallWidth
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_overallWidth = v;
			}, _overallWidth, value, "OverallWidth", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPositiveLengthMeasure OverallDepth
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_overallDepth = v;
			}, _overallDepth, value, "OverallDepth", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
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
			}, _webThickness, value, "WebThickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcPositiveLengthMeasure FlangeThickness
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_flangeThickness = v;
			}, _flangeThickness, value, "FlangeThickness", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcNonNegativeLengthMeasure? FilletRadius
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
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_filletRadius = v;
			}, _filletRadius, value, "FilletRadius", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcNonNegativeLengthMeasure? FlangeEdgeRadius
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
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_flangeEdgeRadius = v;
			}, _flangeEdgeRadius, value, "FlangeEdgeRadius", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcPlaneAngleMeasure? FlangeSlope
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
			SetValue(delegate(IfcPlaneAngleMeasure? v)
			{
				_flangeSlope = v;
			}, _flangeSlope, value, "FlangeSlope", 10);
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
		case 8:
			_flangeEdgeRadius = value.RealVal;
			break;
		case 9:
			_flangeSlope = value.RealVal;
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
			case IfcIShapeProfileDefClause.ValidFlangeThickness:
				result = 2.0 * (double)FlangeThickness < (double)OverallDepth;
				break;
			case IfcIShapeProfileDefClause.ValidWebThickness:
				result = (double)WebThickness < (double)OverallWidth;
				break;
			case IfcIShapeProfileDefClause.ValidFilletRadius:
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
		if (!ValidateClause(IfcIShapeProfileDefClause.ValidFlangeThickness))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcIShapeProfileDef.ValidFlangeThickness",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcIShapeProfileDefClause.ValidWebThickness))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcIShapeProfileDef.ValidWebThickness",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcIShapeProfileDefClause.ValidFilletRadius))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcIShapeProfileDef.ValidFilletRadius",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
