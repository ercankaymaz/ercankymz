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

[ExpressType("IfcCircleHollowProfileDef", 114)]
public class IfcCircleHollowProfileDef : IfcCircleProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcCircleHollowProfileDef, IIfcCircleProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcCircleHollowProfileDef>, IExpressValidatable
{
	public enum IfcCircleHollowProfileDefClause
	{
		WR1
	}

	private IfcPositiveLengthMeasure _wallThickness;

	IfcPositiveLengthMeasure IIfcCircleHollowProfileDef.WallThickness
	{
		get
		{
			return WallThickness;
		}
		set
		{
			WallThickness = value;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPositiveLengthMeasure WallThickness
	{
		get
		{
			if (_activated)
			{
				return _wallThickness;
			}
			Activate();
			return _wallThickness;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_wallThickness = v;
			}, _wallThickness, value, "WallThickness", 5);
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

	internal IfcCircleHollowProfileDef(IModel model, int label, bool activated)
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
			_wallThickness = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCircleHollowProfileDef other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcCircleHollowProfileDefClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCircleHollowProfileDefClause.WR1)
			{
				result = (double)WallThickness < (double)base.Radius;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCircleHollowProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcCircleHollowProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcCircleHollowProfileDefClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCircleHollowProfileDef.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
