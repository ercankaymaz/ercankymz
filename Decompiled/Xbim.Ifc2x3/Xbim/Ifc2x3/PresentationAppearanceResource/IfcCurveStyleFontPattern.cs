using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcCurveStyleFontPattern", 637)]
public class IfcCurveStyleFontPattern : PersistEntity, IIfcCurveStyleFontPattern, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcCurveStyleFontPattern>, IExpressValidatable
{
	public enum IfcCurveStyleFontPatternClause
	{
		WR01
	}

	private Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure _visibleSegmentLength;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _invisibleSegmentLength;

	[CrossSchemaAttribute(typeof(IIfcCurveStyleFontPattern), 1)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcCurveStyleFontPattern.VisibleSegmentLength
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(VisibleSegmentLength);
		}
		set
		{
			VisibleSegmentLength = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCurveStyleFontPattern), 2)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcCurveStyleFontPattern.InvisibleSegmentLength
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(InvisibleSegmentLength);
		}
		set
		{
			InvisibleSegmentLength = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure VisibleSegmentLength
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure v)
			{
				_visibleSegmentLength = v;
			}, _visibleSegmentLength, value, "VisibleSegmentLength", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure InvisibleSegmentLength
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
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
			if (clause == IfcCurveStyleFontPatternClause.WR01)
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
		if (!ValidateClause(IfcCurveStyleFontPatternClause.WR01))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCurveStyleFontPattern.WR01",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
