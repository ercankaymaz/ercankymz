using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ArchitectureDomain;

[ExpressType("IfcDoorLiningProperties", 493)]
public class IfcDoorLiningProperties : IfcPreDefinedPropertySet, IInstantiableEntity, IPersistEntity, IPersist, IIfcDoorLiningProperties, IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect, IContainsEntityReferences, IEquatable<IfcDoorLiningProperties>, IExpressValidatable
{
	public enum IfcDoorLiningPropertiesClause
	{
		WR31,
		WR32,
		WR33,
		WR34,
		WR35
	}

	private IfcPositiveLengthMeasure? _liningDepth;

	private IfcNonNegativeLengthMeasure? _liningThickness;

	private IfcPositiveLengthMeasure? _thresholdDepth;

	private IfcNonNegativeLengthMeasure? _thresholdThickness;

	private IfcNonNegativeLengthMeasure? _transomThickness;

	private IfcLengthMeasure? _transomOffset;

	private IfcLengthMeasure? _liningOffset;

	private IfcLengthMeasure? _thresholdOffset;

	private IfcPositiveLengthMeasure? _casingThickness;

	private IfcPositiveLengthMeasure? _casingDepth;

	private IfcShapeAspect _shapeAspectStyle;

	private IfcLengthMeasure? _liningToPanelOffsetX;

	private IfcLengthMeasure? _liningToPanelOffsetY;

	IfcPositiveLengthMeasure? IIfcDoorLiningProperties.LiningDepth
	{
		get
		{
			return LiningDepth;
		}
		set
		{
			LiningDepth = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcDoorLiningProperties.LiningThickness
	{
		get
		{
			return LiningThickness;
		}
		set
		{
			LiningThickness = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcDoorLiningProperties.ThresholdDepth
	{
		get
		{
			return ThresholdDepth;
		}
		set
		{
			ThresholdDepth = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcDoorLiningProperties.ThresholdThickness
	{
		get
		{
			return ThresholdThickness;
		}
		set
		{
			ThresholdThickness = value;
		}
	}

	IfcNonNegativeLengthMeasure? IIfcDoorLiningProperties.TransomThickness
	{
		get
		{
			return TransomThickness;
		}
		set
		{
			TransomThickness = value;
		}
	}

	IfcLengthMeasure? IIfcDoorLiningProperties.TransomOffset
	{
		get
		{
			return TransomOffset;
		}
		set
		{
			TransomOffset = value;
		}
	}

	IfcLengthMeasure? IIfcDoorLiningProperties.LiningOffset
	{
		get
		{
			return LiningOffset;
		}
		set
		{
			LiningOffset = value;
		}
	}

	IfcLengthMeasure? IIfcDoorLiningProperties.ThresholdOffset
	{
		get
		{
			return ThresholdOffset;
		}
		set
		{
			ThresholdOffset = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcDoorLiningProperties.CasingThickness
	{
		get
		{
			return CasingThickness;
		}
		set
		{
			CasingThickness = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcDoorLiningProperties.CasingDepth
	{
		get
		{
			return CasingDepth;
		}
		set
		{
			CasingDepth = value;
		}
	}

	IIfcShapeAspect IIfcDoorLiningProperties.ShapeAspectStyle
	{
		get
		{
			return ShapeAspectStyle;
		}
		set
		{
			ShapeAspectStyle = value as IfcShapeAspect;
		}
	}

	IfcLengthMeasure? IIfcDoorLiningProperties.LiningToPanelOffsetX
	{
		get
		{
			return LiningToPanelOffsetX;
		}
		set
		{
			LiningToPanelOffsetX = value;
		}
	}

	IfcLengthMeasure? IIfcDoorLiningProperties.LiningToPanelOffsetY
	{
		get
		{
			return LiningToPanelOffsetY;
		}
		set
		{
			LiningToPanelOffsetY = value;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcPositiveLengthMeasure? LiningDepth
	{
		get
		{
			if (_activated)
			{
				return _liningDepth;
			}
			Activate();
			return _liningDepth;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_liningDepth = v;
			}, _liningDepth, value, "LiningDepth", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcNonNegativeLengthMeasure? LiningThickness
	{
		get
		{
			if (_activated)
			{
				return _liningThickness;
			}
			Activate();
			return _liningThickness;
		}
		set
		{
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_liningThickness = v;
			}, _liningThickness, value, "LiningThickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcPositiveLengthMeasure? ThresholdDepth
	{
		get
		{
			if (_activated)
			{
				return _thresholdDepth;
			}
			Activate();
			return _thresholdDepth;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_thresholdDepth = v;
			}, _thresholdDepth, value, "ThresholdDepth", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcNonNegativeLengthMeasure? ThresholdThickness
	{
		get
		{
			if (_activated)
			{
				return _thresholdThickness;
			}
			Activate();
			return _thresholdThickness;
		}
		set
		{
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_thresholdThickness = v;
			}, _thresholdThickness, value, "ThresholdThickness", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public IfcNonNegativeLengthMeasure? TransomThickness
	{
		get
		{
			if (_activated)
			{
				return _transomThickness;
			}
			Activate();
			return _transomThickness;
		}
		set
		{
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_transomThickness = v;
			}, _transomThickness, value, "TransomThickness", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public IfcLengthMeasure? TransomOffset
	{
		get
		{
			if (_activated)
			{
				return _transomOffset;
			}
			Activate();
			return _transomOffset;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_transomOffset = v;
			}, _transomOffset, value, "TransomOffset", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public IfcLengthMeasure? LiningOffset
	{
		get
		{
			if (_activated)
			{
				return _liningOffset;
			}
			Activate();
			return _liningOffset;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_liningOffset = v;
			}, _liningOffset, value, "LiningOffset", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public IfcLengthMeasure? ThresholdOffset
	{
		get
		{
			if (_activated)
			{
				return _thresholdOffset;
			}
			Activate();
			return _thresholdOffset;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_thresholdOffset = v;
			}, _thresholdOffset, value, "ThresholdOffset", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
	public IfcPositiveLengthMeasure? CasingThickness
	{
		get
		{
			if (_activated)
			{
				return _casingThickness;
			}
			Activate();
			return _casingThickness;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_casingThickness = v;
			}, _casingThickness, value, "CasingThickness", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public IfcPositiveLengthMeasure? CasingDepth
	{
		get
		{
			if (_activated)
			{
				return _casingDepth;
			}
			Activate();
			return _casingDepth;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_casingDepth = v;
			}, _casingDepth, value, "CasingDepth", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
	public IfcShapeAspect ShapeAspectStyle
	{
		get
		{
			if (_activated)
			{
				return _shapeAspectStyle;
			}
			Activate();
			return _shapeAspectStyle;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcShapeAspect v)
			{
				_shapeAspectStyle = v;
			}, _shapeAspectStyle, value, "ShapeAspectStyle", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public IfcLengthMeasure? LiningToPanelOffsetX
	{
		get
		{
			if (_activated)
			{
				return _liningToPanelOffsetX;
			}
			Activate();
			return _liningToPanelOffsetX;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_liningToPanelOffsetX = v;
			}, _liningToPanelOffsetX, value, "LiningToPanelOffsetX", 16);
		}
	}

	[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public IfcLengthMeasure? LiningToPanelOffsetY
	{
		get
		{
			if (_activated)
			{
				return _liningToPanelOffsetY;
			}
			Activate();
			return _liningToPanelOffsetY;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure? v)
			{
				_liningToPanelOffsetY = v;
			}, _liningToPanelOffsetY, value, "LiningToPanelOffsetY", 17);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (ShapeAspectStyle != null)
			{
				yield return ShapeAspectStyle;
			}
		}
	}

	internal IfcDoorLiningProperties(IModel model, int label, bool activated)
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
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_liningDepth = value.RealVal;
			break;
		case 5:
			_liningThickness = value.RealVal;
			break;
		case 6:
			_thresholdDepth = value.RealVal;
			break;
		case 7:
			_thresholdThickness = value.RealVal;
			break;
		case 8:
			_transomThickness = value.RealVal;
			break;
		case 9:
			_transomOffset = value.RealVal;
			break;
		case 10:
			_liningOffset = value.RealVal;
			break;
		case 11:
			_thresholdOffset = value.RealVal;
			break;
		case 12:
			_casingThickness = value.RealVal;
			break;
		case 13:
			_casingDepth = value.RealVal;
			break;
		case 14:
			_shapeAspectStyle = (IfcShapeAspect)value.EntityVal;
			break;
		case 15:
			_liningToPanelOffsetX = value.RealVal;
			break;
		case 16:
			_liningToPanelOffsetY = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDoorLiningProperties other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDoorLiningPropertiesClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcDoorLiningPropertiesClause.WR31:
				result = !Functions.EXISTS(LiningDepth) || Functions.EXISTS(LiningThickness);
				break;
			case IfcDoorLiningPropertiesClause.WR32:
				result = !Functions.EXISTS(ThresholdDepth) || Functions.EXISTS(ThresholdThickness);
				break;
			case IfcDoorLiningPropertiesClause.WR33:
				result = (Functions.EXISTS(TransomOffset) && Functions.EXISTS(TransomThickness)) ^ (!Functions.EXISTS(TransomOffset) && !Functions.EXISTS(TransomThickness));
				break;
			case IfcDoorLiningPropertiesClause.WR34:
				result = (Functions.EXISTS(CasingDepth) && Functions.EXISTS(CasingThickness)) ^ (!Functions.EXISTS(CasingDepth) && !Functions.EXISTS(CasingThickness));
				break;
			case IfcDoorLiningPropertiesClause.WR35:
				result = Functions.EXISTS(base.DefinesType.ItemAt(0L)) && (Functions.TYPEOF(base.DefinesType.ItemAt(0L)).Contains("IFC4.IFCDOORTYPE") || Functions.TYPEOF(base.DefinesType.ItemAt(0L)).Contains("IFC4.IFCDOORSTYLE"));
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDoorLiningProperties>()?.LogError($"Exception thrown evaluating where-clause 'IfcDoorLiningProperties.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDoorLiningPropertiesClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDoorLiningProperties.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDoorLiningPropertiesClause.WR32))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDoorLiningProperties.WR32",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDoorLiningPropertiesClause.WR33))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDoorLiningProperties.WR33",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDoorLiningPropertiesClause.WR34))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDoorLiningProperties.WR34",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDoorLiningPropertiesClause.WR35))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDoorLiningProperties.WR35",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
