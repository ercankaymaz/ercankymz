using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcArbitraryClosedProfileDef", 115)]
public class IfcArbitraryClosedProfileDef : IfcProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcArbitraryClosedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcArbitraryClosedProfileDef>, IExpressValidatable
{
	public enum IfcArbitraryClosedProfileDefClause
	{
		WR1,
		WR2,
		WR3
	}

	private IfcCurve _outerCurve;

	IIfcCurve IIfcArbitraryClosedProfileDef.OuterCurve
	{
		get
		{
			return OuterCurve;
		}
		set
		{
			OuterCurve = value as IfcCurve;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcCurve OuterCurve
	{
		get
		{
			if (_activated)
			{
				return _outerCurve;
			}
			Activate();
			return _outerCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_outerCurve = v;
			}, _outerCurve, value, "OuterCurve", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (OuterCurve != null)
			{
				yield return OuterCurve;
			}
		}
	}

	internal IfcArbitraryClosedProfileDef(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_outerCurve = (IfcCurve)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcArbitraryClosedProfileDef other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcArbitraryClosedProfileDefClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcArbitraryClosedProfileDefClause.WR1:
				result = OuterCurve.Dim == 2L;
				break;
			case IfcArbitraryClosedProfileDefClause.WR2:
				result = !Functions.TYPEOF(OuterCurve).Contains("IFC4.IFCLINE");
				break;
			case IfcArbitraryClosedProfileDefClause.WR3:
				result = !Functions.TYPEOF(OuterCurve).Contains("IFC4.IFCOFFSETCURVE2D");
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcArbitraryClosedProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcArbitraryClosedProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcArbitraryClosedProfileDefClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcArbitraryClosedProfileDef.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcArbitraryClosedProfileDefClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcArbitraryClosedProfileDef.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcArbitraryClosedProfileDefClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcArbitraryClosedProfileDef.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
