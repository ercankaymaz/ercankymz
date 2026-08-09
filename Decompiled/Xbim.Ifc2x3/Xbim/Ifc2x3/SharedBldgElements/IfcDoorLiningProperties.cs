using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.SharedBldgElements;

[ExpressType("IfcDoorLiningProperties", 493)]
public class IfcDoorLiningProperties : Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition, IIfcDoorLiningProperties, IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcDoorLiningProperties>, IExpressValidatable
{
	public enum IfcDoorLiningPropertiesClause
	{
		WR31,
		WR32,
		WR33,
		WR34,
		WR35
	}

	private Xbim.Ifc4.MeasureResource.IfcLengthMeasure? _liningToPanelOffsetX;

	private Xbim.Ifc4.MeasureResource.IfcLengthMeasure? _liningToPanelOffsetY;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _liningDepth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _liningThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _thresholdDepth;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _thresholdThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _transomThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _transomOffset;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _liningOffset;

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? _thresholdOffset;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _casingThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _casingDepth;

	private IfcShapeAspect _shapeAspectStyle;

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcDoorLiningProperties.LiningDepth
	{
		get
		{
			if (!LiningDepth.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(LiningDepth.Value);
		}
		set
		{
			LiningDepth = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 6)]
	IfcNonNegativeLengthMeasure? IIfcDoorLiningProperties.LiningThickness
	{
		get
		{
			if (!LiningThickness.HasValue)
			{
				return null;
			}
			return new IfcNonNegativeLengthMeasure(LiningThickness.Value);
		}
		set
		{
			LiningThickness = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 7)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcDoorLiningProperties.ThresholdDepth
	{
		get
		{
			if (!ThresholdDepth.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(ThresholdDepth.Value);
		}
		set
		{
			ThresholdDepth = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 8)]
	IfcNonNegativeLengthMeasure? IIfcDoorLiningProperties.ThresholdThickness
	{
		get
		{
			if (!ThresholdThickness.HasValue)
			{
				return null;
			}
			return new IfcNonNegativeLengthMeasure(ThresholdThickness.Value);
		}
		set
		{
			ThresholdThickness = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 9)]
	IfcNonNegativeLengthMeasure? IIfcDoorLiningProperties.TransomThickness
	{
		get
		{
			if (!TransomThickness.HasValue)
			{
				return null;
			}
			return new IfcNonNegativeLengthMeasure(TransomThickness.Value);
		}
		set
		{
			TransomThickness = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 10)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcDoorLiningProperties.TransomOffset
	{
		get
		{
			if (!TransomOffset.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(TransomOffset.Value);
		}
		set
		{
			TransomOffset = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 11)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcDoorLiningProperties.LiningOffset
	{
		get
		{
			if (!LiningOffset.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(LiningOffset.Value);
		}
		set
		{
			LiningOffset = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 12)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcDoorLiningProperties.ThresholdOffset
	{
		get
		{
			if (!ThresholdOffset.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(ThresholdOffset.Value);
		}
		set
		{
			ThresholdOffset = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 13)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcDoorLiningProperties.CasingThickness
	{
		get
		{
			if (!CasingThickness.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(CasingThickness.Value);
		}
		set
		{
			CasingThickness = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 14)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcDoorLiningProperties.CasingDepth
	{
		get
		{
			if (!CasingDepth.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(CasingDepth.Value);
		}
		set
		{
			CasingDepth = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 15)]
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

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 16)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcDoorLiningProperties.LiningToPanelOffsetX
	{
		get
		{
			return _liningToPanelOffsetX;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLengthMeasure? v)
			{
				_liningToPanelOffsetX = v;
			}, _liningToPanelOffsetX, value, "LiningToPanelOffsetX", -16);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDoorLiningProperties), 17)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcDoorLiningProperties.LiningToPanelOffsetY
	{
		get
		{
			return _liningToPanelOffsetY;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLengthMeasure? v)
			{
				_liningToPanelOffsetY = v;
			}, _liningToPanelOffsetY, value, "LiningToPanelOffsetY", -17);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? LiningDepth
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_liningDepth = v;
			}, _liningDepth, value, "LiningDepth", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? LiningThickness
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_liningThickness = v;
			}, _liningThickness, value, "LiningThickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? ThresholdDepth
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_thresholdDepth = v;
			}, _thresholdDepth, value, "ThresholdDepth", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? ThresholdThickness
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_thresholdThickness = v;
			}, _thresholdThickness, value, "ThresholdThickness", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? TransomThickness
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_transomThickness = v;
			}, _transomThickness, value, "TransomThickness", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? TransomOffset
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_transomOffset = v;
			}, _transomOffset, value, "TransomOffset", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? LiningOffset
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_liningOffset = v;
			}, _liningOffset, value, "LiningOffset", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? ThresholdOffset
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure? v)
			{
				_thresholdOffset = v;
			}, _thresholdOffset, value, "ThresholdOffset", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? CasingThickness
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_casingThickness = v;
			}, _casingThickness, value, "CasingThickness", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? CasingDepth
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_casingDepth = v;
			}, _casingDepth, value, "CasingDepth", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 18)]
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
				result = Functions.EXISTS(LiningDepth) || !Functions.EXISTS(LiningThickness);
				break;
			case IfcDoorLiningPropertiesClause.WR32:
				result = Functions.EXISTS(ThresholdDepth) || !Functions.EXISTS(ThresholdThickness);
				break;
			case IfcDoorLiningPropertiesClause.WR33:
				result = (Functions.EXISTS(TransomOffset) && Functions.EXISTS(TransomThickness)) ^ (!Functions.EXISTS(TransomOffset) && !Functions.EXISTS(TransomThickness));
				break;
			case IfcDoorLiningPropertiesClause.WR34:
				result = (Functions.EXISTS(CasingDepth) && Functions.EXISTS(CasingThickness)) ^ (!Functions.EXISTS(CasingDepth) && !Functions.EXISTS(CasingThickness));
				break;
			case IfcDoorLiningPropertiesClause.WR35:
				result = Functions.EXISTS(base.DefinesType.ItemAt(0L)) && Functions.TYPEOF(base.DefinesType.ItemAt(0L)).Contains("IFC2X3.IFCDOORSTYLE");
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
