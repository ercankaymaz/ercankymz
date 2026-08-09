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

[ExpressType("IfcAsymmetricIShapeProfileDef", 672)]
public class IfcAsymmetricIShapeProfileDef : IfcParameterizedProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcAsymmetricIShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcAsymmetricIShapeProfileDef>, IExpressValidatable
{
	public enum IfcAsymmetricIShapeProfileDefClause
	{
		ValidFlangeThickness,
		ValidWebThickness,
		ValidBottomFilletRadius,
		ValidTopFilletRadius
	}

	private IfcPositiveLengthMeasure _bottomFlangeWidth;

	private IfcPositiveLengthMeasure _overallDepth;

	private IfcPositiveLengthMeasure _webThickness;

	private IfcPositiveLengthMeasure _bottomFlangeThickness;

	private IfcNonNegativeLengthMeasure? _bottomFlangeFilletRadius;

	private IfcPositiveLengthMeasure _topFlangeWidth;

	private IfcPositiveLengthMeasure? _topFlangeThickness;

	private IfcNonNegativeLengthMeasure? _topFlangeFilletRadius;

	private IfcNonNegativeLengthMeasure? _bottomFlangeEdgeRadius;

	private IfcPlaneAngleMeasure? _bottomFlangeSlope;

	private IfcNonNegativeLengthMeasure? _topFlangeEdgeRadius;

	private IfcPlaneAngleMeasure? _topFlangeSlope;

	IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.BottomFlangeWidth
	{
		get
		{
			return BottomFlangeWidth;
		}
		set
		{
			BottomFlangeWidth = value;
		}
	}

	IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.OverallDepth
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

	IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.WebThickness
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

	IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.BottomFlangeThickness
	{
		get
		{
			return BottomFlangeThickness;
		}
		set
		{
			BottomFlangeThickness = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcAsymmetricIShapeProfileDef.BottomFlangeFilletRadius
	{
		get
		{
			return BottomFlangeFilletRadius;
		}
		set
		{
			BottomFlangeFilletRadius = value;
		}
	}

	IfcPositiveLengthMeasure IIfcAsymmetricIShapeProfileDef.TopFlangeWidth
	{
		get
		{
			return TopFlangeWidth;
		}
		set
		{
			TopFlangeWidth = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcAsymmetricIShapeProfileDef.TopFlangeThickness
	{
		get
		{
			return TopFlangeThickness;
		}
		set
		{
			TopFlangeThickness = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcAsymmetricIShapeProfileDef.TopFlangeFilletRadius
	{
		get
		{
			return TopFlangeFilletRadius;
		}
		set
		{
			TopFlangeFilletRadius = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcAsymmetricIShapeProfileDef.BottomFlangeEdgeRadius
	{
		get
		{
			return BottomFlangeEdgeRadius;
		}
		set
		{
			BottomFlangeEdgeRadius = value;
		}
	}

	IfcPlaneAngleMeasure? IIfcAsymmetricIShapeProfileDef.BottomFlangeSlope
	{
		get
		{
			return BottomFlangeSlope;
		}
		set
		{
			BottomFlangeSlope = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcAsymmetricIShapeProfileDef.TopFlangeEdgeRadius
	{
		get
		{
			return TopFlangeEdgeRadius;
		}
		set
		{
			TopFlangeEdgeRadius = value;
		}
	}

	IfcPlaneAngleMeasure? IIfcAsymmetricIShapeProfileDef.TopFlangeSlope
	{
		get
		{
			return TopFlangeSlope;
		}
		set
		{
			TopFlangeSlope = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure BottomFlangeWidth
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_bottomFlangeWidth = v;
			}, _bottomFlangeWidth, value, "BottomFlangeWidth", 4);
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
	public IfcPositiveLengthMeasure BottomFlangeThickness
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_bottomFlangeThickness = v;
			}, _bottomFlangeThickness, value, "BottomFlangeThickness", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcNonNegativeLengthMeasure? BottomFlangeFilletRadius
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
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_bottomFlangeFilletRadius = v;
			}, _bottomFlangeFilletRadius, value, "BottomFlangeFilletRadius", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcPositiveLengthMeasure TopFlangeWidth
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_topFlangeWidth = v;
			}, _topFlangeWidth, value, "TopFlangeWidth", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcPositiveLengthMeasure? TopFlangeThickness
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
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_topFlangeThickness = v;
			}, _topFlangeThickness, value, "TopFlangeThickness", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcNonNegativeLengthMeasure? TopFlangeFilletRadius
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
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_topFlangeFilletRadius = v;
			}, _topFlangeFilletRadius, value, "TopFlangeFilletRadius", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public IfcNonNegativeLengthMeasure? BottomFlangeEdgeRadius
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
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_bottomFlangeEdgeRadius = v;
			}, _bottomFlangeEdgeRadius, value, "BottomFlangeEdgeRadius", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public IfcPlaneAngleMeasure? BottomFlangeSlope
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
			SetValue(delegate(IfcPlaneAngleMeasure? v)
			{
				_bottomFlangeSlope = v;
			}, _bottomFlangeSlope, value, "BottomFlangeSlope", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public IfcNonNegativeLengthMeasure? TopFlangeEdgeRadius
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
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_topFlangeEdgeRadius = v;
			}, _topFlangeEdgeRadius, value, "TopFlangeEdgeRadius", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public IfcPlaneAngleMeasure? TopFlangeSlope
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
			SetValue(delegate(IfcPlaneAngleMeasure? v)
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

	public bool ValidateClause(IfcAsymmetricIShapeProfileDefClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcAsymmetricIShapeProfileDefClause.ValidFlangeThickness:
				result = !Functions.EXISTS(TopFlangeThickness) || (double)BottomFlangeThickness + (double?)TopFlangeThickness < (double)OverallDepth;
				break;
			case IfcAsymmetricIShapeProfileDefClause.ValidWebThickness:
				result = (double)WebThickness < (double)BottomFlangeWidth && (double)WebThickness < (double)TopFlangeWidth;
				break;
			case IfcAsymmetricIShapeProfileDefClause.ValidBottomFilletRadius:
				result = !Functions.EXISTS(BottomFlangeFilletRadius) || (double?)BottomFlangeFilletRadius <= ((double)BottomFlangeWidth - (double)WebThickness) / 2.0;
				break;
			case IfcAsymmetricIShapeProfileDefClause.ValidTopFilletRadius:
				result = !Functions.EXISTS(TopFlangeFilletRadius) || (double?)TopFlangeFilletRadius <= ((double)TopFlangeWidth - (double)WebThickness) / 2.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAsymmetricIShapeProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcAsymmetricIShapeProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcAsymmetricIShapeProfileDefClause.ValidFlangeThickness))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAsymmetricIShapeProfileDef.ValidFlangeThickness",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAsymmetricIShapeProfileDefClause.ValidWebThickness))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAsymmetricIShapeProfileDef.ValidWebThickness",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAsymmetricIShapeProfileDefClause.ValidBottomFilletRadius))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAsymmetricIShapeProfileDef.ValidBottomFilletRadius",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcAsymmetricIShapeProfileDefClause.ValidTopFilletRadius))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAsymmetricIShapeProfileDef.ValidTopFilletRadius",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
