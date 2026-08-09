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

[ExpressType("IfcTShapeProfileDef", 671)]
public class IfcTShapeProfileDef : IfcParameterizedProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcTShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcTShapeProfileDef>, IExpressValidatable
{
	public enum IfcTShapeProfileDefClause
	{
		ValidFlangeThickness,
		ValidWebThickness
	}

	private IfcPositiveLengthMeasure _depth;

	private IfcPositiveLengthMeasure _flangeWidth;

	private IfcPositiveLengthMeasure _webThickness;

	private IfcPositiveLengthMeasure _flangeThickness;

	private IfcNonNegativeLengthMeasure? _filletRadius;

	private IfcNonNegativeLengthMeasure? _flangeEdgeRadius;

	private IfcNonNegativeLengthMeasure? _webEdgeRadius;

	private IfcPlaneAngleMeasure? _webSlope;

	private IfcPlaneAngleMeasure? _flangeSlope;

	IfcPositiveLengthMeasure IIfcTShapeProfileDef.Depth
	{
		get
		{
			return Depth;
		}
		set
		{
			Depth = value;
		}
	}

	IfcPositiveLengthMeasure IIfcTShapeProfileDef.FlangeWidth
	{
		get
		{
			return FlangeWidth;
		}
		set
		{
			FlangeWidth = value;
		}
	}

	IfcPositiveLengthMeasure IIfcTShapeProfileDef.WebThickness
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

	IfcPositiveLengthMeasure IIfcTShapeProfileDef.FlangeThickness
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

	IfcNonNegativeLengthMeasure? IIfcTShapeProfileDef.FilletRadius
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

	IfcNonNegativeLengthMeasure? IIfcTShapeProfileDef.FlangeEdgeRadius
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

	IfcNonNegativeLengthMeasure? IIfcTShapeProfileDef.WebEdgeRadius
	{
		get
		{
			return WebEdgeRadius;
		}
		set
		{
			WebEdgeRadius = value;
		}
	}

	IfcPlaneAngleMeasure? IIfcTShapeProfileDef.WebSlope
	{
		get
		{
			return WebSlope;
		}
		set
		{
			WebSlope = value;
		}
	}

	IfcPlaneAngleMeasure? IIfcTShapeProfileDef.FlangeSlope
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
	public IfcPositiveLengthMeasure Depth
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_depth = v;
			}, _depth, value, "Depth", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPositiveLengthMeasure FlangeWidth
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_flangeWidth = v;
			}, _flangeWidth, value, "FlangeWidth", 5);
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
	public IfcNonNegativeLengthMeasure? WebEdgeRadius
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
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_webEdgeRadius = v;
			}, _webEdgeRadius, value, "WebEdgeRadius", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcPlaneAngleMeasure? WebSlope
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
			SetValue(delegate(IfcPlaneAngleMeasure? v)
			{
				_webSlope = v;
			}, _webSlope, value, "WebSlope", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
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
			}, _flangeSlope, value, "FlangeSlope", 12);
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
			case IfcTShapeProfileDefClause.ValidFlangeThickness:
				result = (double)FlangeThickness < (double)Depth;
				break;
			case IfcTShapeProfileDefClause.ValidWebThickness:
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
		if (!ValidateClause(IfcTShapeProfileDefClause.ValidFlangeThickness))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTShapeProfileDef.ValidFlangeThickness",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTShapeProfileDefClause.ValidWebThickness))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTShapeProfileDef.ValidWebThickness",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
