using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PresentationResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcCurveStyle", 118)]
public class IfcCurveStyle : IfcPresentationStyle, IIfcCurveStyle, IIfcPresentationStyle, IPersistEntity, IPersist, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, Xbim.Ifc4.PresentationAppearanceResource.IfcPresentationStyleSelect, IIfcPresentationStyleSelect, IInstantiableEntity, IfcPresentationStyleSelect, IContainsEntityReferences, IEquatable<IfcCurveStyle>, IExpressValidatable
{
	public enum IfcCurveStyleClause
	{
		WR11
	}

	private Xbim.Ifc4.MeasureResource.IfcBoolean? _modelOrDraughting;

	private IfcCurveFontOrScaledCurveFontSelect _curveFont;

	private IfcSizeSelect _curveWidth;

	private Xbim.Ifc2x3.PresentationResource.IfcColour _curveColour;

	[CrossSchemaAttribute(typeof(IIfcCurveStyle), 2)]
	IIfcCurveFontOrScaledCurveFontSelect IIfcCurveStyle.CurveFont
	{
		get
		{
			if (CurveFont == null)
			{
				return null;
			}
			IfcPreDefinedCurveFont ifcPreDefinedCurveFont = CurveFont as IfcPreDefinedCurveFont;
			if (ifcPreDefinedCurveFont != null)
			{
				return ifcPreDefinedCurveFont;
			}
			IfcCurveStyleFont ifcCurveStyleFont = CurveFont as IfcCurveStyleFont;
			if (ifcCurveStyleFont != null)
			{
				return ifcCurveStyleFont;
			}
			IfcCurveStyleFontAndScaling ifcCurveStyleFontAndScaling = CurveFont as IfcCurveStyleFontAndScaling;
			if (ifcCurveStyleFontAndScaling != null)
			{
				return ifcCurveStyleFontAndScaling;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				CurveFont = null;
				return;
			}
			IfcCurveStyleFont ifcCurveStyleFont = value as IfcCurveStyleFont;
			if (ifcCurveStyleFont != null)
			{
				CurveFont = ifcCurveStyleFont;
				return;
			}
			IfcCurveStyleFontAndScaling ifcCurveStyleFontAndScaling = value as IfcCurveStyleFontAndScaling;
			if (ifcCurveStyleFontAndScaling != null)
			{
				CurveFont = ifcCurveStyleFontAndScaling;
				return;
			}
			IfcPreDefinedCurveFont ifcPreDefinedCurveFont = value as IfcPreDefinedCurveFont;
			if (ifcPreDefinedCurveFont != null)
			{
				CurveFont = ifcPreDefinedCurveFont;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurveStyle), 3)]
	IIfcSizeSelect IIfcCurveStyle.CurveWidth
	{
		get
		{
			if (CurveWidth == null)
			{
				return null;
			}
			if (CurveWidth is Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure)(object)CurveWidth);
			}
			if (CurveWidth is Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure)(object)CurveWidth);
			}
			if (CurveWidth is Xbim.Ifc2x3.MeasureResource.IfcDescriptiveMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc2x3.MeasureResource.IfcDescriptiveMeasure)(object)CurveWidth);
			}
			if (CurveWidth is Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure)(object)CurveWidth);
			}
			if (CurveWidth is Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)(object)CurveWidth);
			}
			if (CurveWidth is Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure)(object)CurveWidth);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				CurveWidth = null;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)
			{
				CurveWidth = new Xbim.Ifc2x3.MeasureResource.IfcDescriptiveMeasure((Xbim.Ifc4.MeasureResource.IfcDescriptiveMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcLengthMeasure)
			{
				CurveWidth = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				CurveWidth = new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)
			{
				CurveWidth = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)
			{
				CurveWidth = new Xbim.Ifc2x3.MeasureResource.IfcPositiveRatioMeasure((Xbim.Ifc4.MeasureResource.IfcPositiveRatioMeasure)(object)value);
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				CurveWidth = new Xbim.Ifc2x3.MeasureResource.IfcRatioMeasure((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurveStyle), 4)]
	IIfcColour IIfcCurveStyle.CurveColour
	{
		get
		{
			if (CurveColour == null)
			{
				return null;
			}
			Xbim.Ifc2x3.PresentationResource.IfcColourSpecification ifcColourSpecification = CurveColour as Xbim.Ifc2x3.PresentationResource.IfcColourSpecification;
			if (ifcColourSpecification != null)
			{
				return ifcColourSpecification;
			}
			Xbim.Ifc2x3.PresentationResource.IfcPreDefinedColour ifcPreDefinedColour = CurveColour as Xbim.Ifc2x3.PresentationResource.IfcPreDefinedColour;
			if (ifcPreDefinedColour != null)
			{
				return ifcPreDefinedColour;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				CurveColour = null;
				return;
			}
			Xbim.Ifc2x3.PresentationResource.IfcColourSpecification ifcColourSpecification = value as Xbim.Ifc2x3.PresentationResource.IfcColourSpecification;
			if (ifcColourSpecification != null)
			{
				CurveColour = ifcColourSpecification;
				return;
			}
			Xbim.Ifc2x3.PresentationResource.IfcPreDefinedColour ifcPreDefinedColour = value as Xbim.Ifc2x3.PresentationResource.IfcPreDefinedColour;
			if (ifcPreDefinedColour != null)
			{
				CurveColour = ifcPreDefinedColour;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurveStyle), 5)]
	Xbim.Ifc4.MeasureResource.IfcBoolean? IIfcCurveStyle.ModelOrDraughting
	{
		get
		{
			return _modelOrDraughting;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcBoolean? v)
			{
				_modelOrDraughting = v;
			}, _modelOrDraughting, value, "ModelOrDraughting", -5);
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
	public Xbim.Ifc2x3.PresentationResource.IfcColour CurveColour
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
			SetValue(delegate(Xbim.Ifc2x3.PresentationResource.IfcColour v)
			{
				_curveColour = v;
			}, _curveColour, value, "CurveColour", 4);
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
			_curveColour = (Xbim.Ifc2x3.PresentationResource.IfcColour)value.EntityVal;
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
			if (clause == IfcCurveStyleClause.WR11)
			{
				result = !Functions.EXISTS(CurveWidth) || Functions.TYPEOF(CurveWidth).Contains("IFC2X3.IFCPOSITIVELENGTHMEASURE") || (Functions.TYPEOF(CurveWidth).Contains("IFC2X3.IFCDESCRIPTIVEMEASURE") && CurveWidth.AsIfcDescriptiveMeasure() == (Xbim.Ifc2x3.MeasureResource.IfcDescriptiveMeasure)"by layer");
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
		if (!ValidateClause(IfcCurveStyleClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCurveStyle.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
