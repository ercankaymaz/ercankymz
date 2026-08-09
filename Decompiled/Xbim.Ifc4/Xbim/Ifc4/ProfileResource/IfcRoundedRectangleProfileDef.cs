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

[ExpressType("IfcRoundedRectangleProfileDef", 106)]
public class IfcRoundedRectangleProfileDef : IfcRectangleProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcRoundedRectangleProfileDef, IIfcRectangleProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcRoundedRectangleProfileDef>, IExpressValidatable
{
	public enum IfcRoundedRectangleProfileDefClause
	{
		ValidRadius
	}

	private IfcPositiveLengthMeasure _roundingRadius;

	IfcPositiveLengthMeasure IIfcRoundedRectangleProfileDef.RoundingRadius
	{
		get
		{
			return RoundingRadius;
		}
		set
		{
			RoundingRadius = value;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public IfcPositiveLengthMeasure RoundingRadius
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
			SetValue(delegate(IfcPositiveLengthMeasure v)
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
			if (clause == IfcRoundedRectangleProfileDefClause.ValidRadius)
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
		if (!ValidateClause(IfcRoundedRectangleProfileDefClause.ValidRadius))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRoundedRectangleProfileDef.ValidRadius",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
