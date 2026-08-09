using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProfileResource;

[ExpressType("IfcRoundedRectangleProfileDef", 106)]
public class IfcRoundedRectangleProfileDef : IfcRectangleProfileDef, IIfcRoundedRectangleProfileDef, IIfcRectangleProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcRoundedRectangleProfileDef>, IExpressValidatable
{
	public enum IfcRoundedRectangleProfileDefClause
	{
		WR31
	}

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _roundingRadius;

	[CrossSchemaAttribute(typeof(IIfcRoundedRectangleProfileDef), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcRoundedRectangleProfileDef.RoundingRadius
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(RoundingRadius);
		}
		set
		{
			RoundingRadius = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure RoundingRadius
	{
		get
		{
			if (_activated)
			{
				return _roundingRadius;
			}
			Activate();
			return _roundingRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_roundingRadius = v;
			}, _roundingRadius, value, "RoundingRadius", 6);
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

	internal IfcRoundedRectangleProfileDef(IModel model, int label, bool activated)
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
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_roundingRadius = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRoundedRectangleProfileDef other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRoundedRectangleProfileDefClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRoundedRectangleProfileDefClause.WR31)
			{
				result = (double)RoundingRadius <= (double)base.XDim / 2.0 && (double)RoundingRadius <= (double)base.YDim / 2.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRoundedRectangleProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcRoundedRectangleProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRoundedRectangleProfileDefClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRoundedRectangleProfileDef.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
