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

[ExpressType("IfcWindowLiningProperties", 252)]
public class IfcWindowLiningProperties : IfcPreDefinedPropertySet, IInstantiableEntity, IPersistEntity, IPersist, IIfcWindowLiningProperties, IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect, IContainsEntityReferences, IEquatable<IfcWindowLiningProperties>, IExpressValidatable
{
	public enum IfcWindowLiningPropertiesClause
	{
		WR31,
		WR32,
		WR33,
		WR34
	}

	private IfcPositiveLengthMeasure? _liningDepth;

	private IfcNonNegativeLengthMeasure? _liningThickness;

	private IfcNonNegativeLengthMeasure? _transomThickness;

	private IfcNonNegativeLengthMeasure? _mullionThickness;

	private IfcNormalisedRatioMeasure? _firstTransomOffset;

	private IfcNormalisedRatioMeasure? _secondTransomOffset;

	private IfcNormalisedRatioMeasure? _firstMullionOffset;

	private IfcNormalisedRatioMeasure? _secondMullionOffset;

	private IfcShapeAspect _shapeAspectStyle;

	private IfcLengthMeasure? _liningOffset;

	private IfcLengthMeasure? _liningToPanelOffsetX;

	private IfcLengthMeasure? _liningToPanelOffsetY;

	IfcPositiveLengthMeasure? IIfcWindowLiningProperties.LiningDepth
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

	IfcNonNegativeLengthMeasure? IIfcWindowLiningProperties.LiningThickness
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

	IfcNonNegativeLengthMeasure? IIfcWindowLiningProperties.TransomThickness
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

	IfcNonNegativeLengthMeasure? IIfcWindowLiningProperties.MullionThickness
	{
		get
		{
			return MullionThickness;
		}
		set
		{
			MullionThickness = value;
		}
	}

	IfcNormalisedRatioMeasure? IIfcWindowLiningProperties.FirstTransomOffset
	{
		get
		{
			return FirstTransomOffset;
		}
		set
		{
			FirstTransomOffset = value;
		}
	}

	IfcNormalisedRatioMeasure? IIfcWindowLiningProperties.SecondTransomOffset
	{
		get
		{
			return SecondTransomOffset;
		}
		set
		{
			SecondTransomOffset = value;
		}
	}

	IfcNormalisedRatioMeasure? IIfcWindowLiningProperties.FirstMullionOffset
	{
		get
		{
			return FirstMullionOffset;
		}
		set
		{
			FirstMullionOffset = value;
		}
	}

	IfcNormalisedRatioMeasure? IIfcWindowLiningProperties.SecondMullionOffset
	{
		get
		{
			return SecondMullionOffset;
		}
		set
		{
			SecondMullionOffset = value;
		}
	}

	IIfcShapeAspect IIfcWindowLiningProperties.ShapeAspectStyle
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

	IfcLengthMeasure? IIfcWindowLiningProperties.LiningOffset
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

	IfcLengthMeasure? IIfcWindowLiningProperties.LiningToPanelOffsetX
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

	IfcLengthMeasure? IIfcWindowLiningProperties.LiningToPanelOffsetY
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
			}, _transomThickness, value, "TransomThickness", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcNonNegativeLengthMeasure? MullionThickness
	{
		get
		{
			if (_activated)
			{
				return _mullionThickness;
			}
			Activate();
			return _mullionThickness;
		}
		set
		{
			SetValue(delegate(IfcNonNegativeLengthMeasure? v)
			{
				_mullionThickness = v;
			}, _mullionThickness, value, "MullionThickness", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public IfcNormalisedRatioMeasure? FirstTransomOffset
	{
		get
		{
			if (_activated)
			{
				return _firstTransomOffset;
			}
			Activate();
			return _firstTransomOffset;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_firstTransomOffset = v;
			}, _firstTransomOffset, value, "FirstTransomOffset", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public IfcNormalisedRatioMeasure? SecondTransomOffset
	{
		get
		{
			if (_activated)
			{
				return _secondTransomOffset;
			}
			Activate();
			return _secondTransomOffset;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_secondTransomOffset = v;
			}, _secondTransomOffset, value, "SecondTransomOffset", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public IfcNormalisedRatioMeasure? FirstMullionOffset
	{
		get
		{
			if (_activated)
			{
				return _firstMullionOffset;
			}
			Activate();
			return _firstMullionOffset;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_firstMullionOffset = v;
			}, _firstMullionOffset, value, "FirstMullionOffset", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public IfcNormalisedRatioMeasure? SecondMullionOffset
	{
		get
		{
			if (_activated)
			{
				return _secondMullionOffset;
			}
			Activate();
			return _secondMullionOffset;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_secondMullionOffset = v;
			}, _secondMullionOffset, value, "SecondMullionOffset", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 18)]
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
			}, _shapeAspectStyle, value, "ShapeAspectStyle", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
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
			}, _liningOffset, value, "LiningOffset", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
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
			}, _liningToPanelOffsetX, value, "LiningToPanelOffsetX", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
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
			}, _liningToPanelOffsetY, value, "LiningToPanelOffsetY", 16);
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

	internal IfcWindowLiningProperties(IModel model, int label, bool activated)
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
			_transomThickness = value.RealVal;
			break;
		case 7:
			_mullionThickness = value.RealVal;
			break;
		case 8:
			_firstTransomOffset = value.RealVal;
			break;
		case 9:
			_secondTransomOffset = value.RealVal;
			break;
		case 10:
			_firstMullionOffset = value.RealVal;
			break;
		case 11:
			_secondMullionOffset = value.RealVal;
			break;
		case 12:
			_shapeAspectStyle = (IfcShapeAspect)value.EntityVal;
			break;
		case 13:
			_liningOffset = value.RealVal;
			break;
		case 14:
			_liningToPanelOffsetX = value.RealVal;
			break;
		case 15:
			_liningToPanelOffsetY = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWindowLiningProperties other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcWindowLiningPropertiesClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcWindowLiningPropertiesClause.WR31:
				result = !Functions.EXISTS(LiningDepth) || Functions.EXISTS(LiningThickness);
				break;
			case IfcWindowLiningPropertiesClause.WR32:
				result = Functions.EXISTS(FirstTransomOffset) || !Functions.EXISTS(SecondTransomOffset);
				break;
			case IfcWindowLiningPropertiesClause.WR33:
				result = Functions.EXISTS(FirstMullionOffset) || !Functions.EXISTS(SecondMullionOffset);
				break;
			case IfcWindowLiningPropertiesClause.WR34:
				result = Functions.EXISTS(base.DefinesType.ItemAt(0L)) && (Functions.TYPEOF(base.DefinesType.ItemAt(0L)).Contains("IFC4.IFCWINDOWTYPE") || Functions.TYPEOF(base.DefinesType.ItemAt(0L)).Contains("IFC4.IFCWINDOWSTYLE"));
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcWindowLiningProperties>()?.LogError($"Exception thrown evaluating where-clause 'IfcWindowLiningProperties.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcWindowLiningPropertiesClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcWindowLiningProperties.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcWindowLiningPropertiesClause.WR32))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcWindowLiningProperties.WR32",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcWindowLiningPropertiesClause.WR33))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcWindowLiningProperties.WR33",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcWindowLiningPropertiesClause.WR34))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcWindowLiningProperties.WR34",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
