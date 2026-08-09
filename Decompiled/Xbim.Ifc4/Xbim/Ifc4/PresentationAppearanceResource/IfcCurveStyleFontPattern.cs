using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationDefinitionResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcCurveStyleFontPattern", 637)]
public class IfcCurveStyleFontPattern : IfcPresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcCurveStyleFontPattern, IIfcPresentationItem, IEquatable<IfcCurveStyleFontPattern>, IExpressValidatable
{
	public enum IfcCurveStyleFontPatternClause
	{
		VisibleLengthGreaterEqualZero
	}

	private IfcLengthMeasure _visibleSegmentLength;

	private IfcPositiveLengthMeasure _invisibleSegmentLength;

	IfcLengthMeasure IIfcCurveStyleFontPattern.VisibleSegmentLength
	{
		get
		{
			return VisibleSegmentLength;
		}
		set
		{
			VisibleSegmentLength = value;
		}
	}

	IfcPositiveLengthMeasure IIfcCurveStyleFontPattern.InvisibleSegmentLength
	{
		get
		{
			return InvisibleSegmentLength;
		}
		set
		{
			InvisibleSegmentLength = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLengthMeasure VisibleSegmentLength
	{
		get
		{
			if (_activated)
			{
				return _visibleSegmentLength;
			}
			Activate();
			return _visibleSegmentLength;
		}
		set
		{
			SetValue(delegate(IfcLengthMeasure v)
			{
				_visibleSegmentLength = v;
			}, _visibleSegmentLength, value, "VisibleSegmentLength", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcPositiveLengthMeasure InvisibleSegmentLength
	{
		get
		{
			if (_activated)
			{
				return _invisibleSegmentLength;
			}
			Activate();
			return _invisibleSegmentLength;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_invisibleSegmentLength = v;
			}, _invisibleSegmentLength, value, "InvisibleSegmentLength", 2);
		}
	}

	internal IfcCurveStyleFontPattern(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_visibleSegmentLength = value.RealVal;
			break;
		case 1:
			_invisibleSegmentLength = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCurveStyleFontPattern other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCurveStyleFontPatternClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCurveStyleFontPatternClause.VisibleLengthGreaterEqualZero)
			{
				result = (double)VisibleSegmentLength >= 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCurveStyleFontPattern>()?.LogError($"Exception thrown evaluating where-clause 'IfcCurveStyleFontPattern.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcCurveStyleFontPatternClause.VisibleLengthGreaterEqualZero))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCurveStyleFontPattern.VisibleLengthGreaterEqualZero",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
