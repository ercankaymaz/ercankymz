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

[ExpressType("IfcUShapeProfileDef", 670)]
public class IfcUShapeProfileDef : IfcParameterizedProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcUShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcUShapeProfileDef>, IExpressValidatable
{
	public enum IfcUShapeProfileDefClause
	{
		ValidFlangeThickness,
		ValidWebThickness
	}

	private IfcPositiveLengthMeasure _depth;

	private IfcPositiveLengthMeasure _flangeWidth;

	private IfcPositiveLengthMeasure _webThickness;

	private IfcPositiveLengthMeasure _flangeThickness;

	private IfcNonNegativeLengthMeasure? _filletRadius;

	private IfcNonNegativeLengthMeasure? _edgeRadius;

	private IfcPlaneAngleMeasure? _flangeSlope;

	IfcPositiveLengthMeasure IIfcUShapeProfileDef.Depth
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

	IfcPositiveLengthMeasure IIfcUShapeProfileDef.FlangeWidth
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

	IfcPositiveLengthMeasure IIfcUShapeProfileDef.WebThickness
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

	IfcPositiveLengthMeasure IIfcUShapeProfileDef.FlangeThickness
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

	IfcNonNegativeLengthMeasure? IIfcUShapeProfileDef.FilletRadius
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

	IfcNonNegativeLengthMeasure? IIfcUShapeProfileDef.EdgeRadius
	{
		get
		{
			return EdgeRadius;
		}
		set
		{
			EdgeRadius = value;
		}
	}

	IfcPlaneAngleMeasure? IIfcUShapeProfileDef.FlangeSlope
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
	public IfcNonNegativeLengthMeasure? EdgeRadius
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
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_edgeRadius = v;
			}, _edgeRadius, value, "EdgeRadius", 9);
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
			case IfcUShapeProfileDefClause.ValidFlangeThickness:
				result = (double)FlangeThickness < (double)Depth / 2.0;
				break;
			case IfcUShapeProfileDefClause.ValidWebThickness:
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
		if (!ValidateClause(IfcUShapeProfileDefClause.ValidFlangeThickness))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcUShapeProfileDef.ValidFlangeThickness",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcUShapeProfileDefClause.ValidWebThickness))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcUShapeProfileDef.ValidWebThickness",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
