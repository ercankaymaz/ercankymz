using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcCurveStyle", 118)]
public class IfcCurveStyle : IfcPresentationStyle, IInstantiableEntity, IPersistEntity, IPersist, IIfcCurveStyle, IIfcPresentationStyle, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, IfcPresentationStyleSelect, IIfcPresentationStyleSelect, IContainsEntityReferences, IEquatable<IfcCurveStyle>, IExpressValidatable
{
	public enum IfcCurveStyleClause
	{
		MeasureOfWidth,
		IdentifiableCurveStyle
	}

	private IfcCurveFontOrScaledCurveFontSelect _curveFont;

	private IfcSizeSelect _curveWidth;

	private IfcColour _curveColour;

	private IfcBoolean? _modelOrDraughting;

	IIfcCurveFontOrScaledCurveFontSelect IIfcCurveStyle.CurveFont
	{
		get
		{
			return CurveFont;
		}
		set
		{
			CurveFont = value as IfcCurveFontOrScaledCurveFontSelect;
		}
	}

	IIfcSizeSelect IIfcCurveStyle.CurveWidth
	{
		get
		{
			return CurveWidth;
		}
		set
		{
			CurveWidth = value as IfcSizeSelect;
		}
	}

	IIfcColour IIfcCurveStyle.CurveColour
	{
		get
		{
			return CurveColour;
		}
		set
		{
			CurveColour = value as IfcColour;
		}
	}

	IfcBoolean? IIfcCurveStyle.ModelOrDraughting
	{
		get
		{
			return ModelOrDraughting;
		}
		set
		{
			ModelOrDraughting = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcCurveFontOrScaledCurveFontSelect CurveFont
	{
		get
		{
			if (_activated)
			{
				return _curveFont;
			}
			Activate();
			return _curveFont;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurveFontOrScaledCurveFontSelect v)
			{
				_curveFont = v;
			}, _curveFont, value, "CurveFont", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcSizeSelect CurveWidth
	{
		get
		{
			if (_activated)
			{
				return _curveWidth;
			}
			Activate();
			return _curveWidth;
		}
		set
		{
			SetValue(delegate(IfcSizeSelect v)
			{
				_curveWidth = v;
			}, _curveWidth, value, "CurveWidth", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcColour CurveColour
	{
		get
		{
			if (_activated)
			{
				return _curveColour;
			}
			Activate();
			return _curveColour;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColour v)
			{
				_curveColour = v;
			}, _curveColour, value, "CurveColour", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcBoolean? ModelOrDraughting
	{
		get
		{
			if (_activated)
			{
				return _modelOrDraughting;
			}
			Activate();
			return _modelOrDraughting;
		}
		set
		{
			SetValue(delegate(IfcBoolean? v)
			{
				_modelOrDraughting = v;
			}, _modelOrDraughting, value, "ModelOrDraughting", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (CurveFont != null)
			{
				yield return CurveFont;
			}
			if (CurveColour != null)
			{
				yield return CurveColour;
			}
		}
	}

	internal IfcCurveStyle(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_curveFont = (IfcCurveFontOrScaledCurveFontSelect)value.EntityVal;
			break;
		case 2:
			_curveWidth = (IfcSizeSelect)value.EntityVal;
			break;
		case 3:
			_curveColour = (IfcColour)value.EntityVal;
			break;
		case 4:
			_modelOrDraughting = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCurveStyle other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCurveStyleClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcCurveStyleClause.MeasureOfWidth:
				result = !Functions.EXISTS(CurveWidth) || Functions.TYPEOF(CurveWidth).Contains("IFC4.IFCPOSITIVELENGTHMEASURE") || (Functions.TYPEOF(CurveWidth).Contains("IFC4.IFCDESCRIPTIVEMEASURE") && CurveWidth.AsIfcDescriptiveMeasure() == (IfcDescriptiveMeasure)"by layer");
				break;
			case IfcCurveStyleClause.IdentifiableCurveStyle:
				result = Functions.EXISTS(CurveFont) || Functions.EXISTS(CurveWidth) || Functions.EXISTS(CurveColour);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCurveStyle>()?.LogError($"Exception thrown evaluating where-clause 'IfcCurveStyle.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcCurveStyleClause.MeasureOfWidth))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCurveStyle.MeasureOfWidth",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcCurveStyleClause.IdentifiableCurveStyle))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCurveStyle.IdentifiableCurveStyle",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
