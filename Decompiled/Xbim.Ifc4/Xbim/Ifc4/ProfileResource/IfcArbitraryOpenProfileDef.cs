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

[ExpressType("IfcArbitraryOpenProfileDef", 219)]
public class IfcArbitraryOpenProfileDef : IfcProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcArbitraryOpenProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcArbitraryOpenProfileDef>, IExpressValidatable
{
	public enum IfcArbitraryOpenProfileDefClause
	{
		WR11,
		WR12
	}

	private IfcBoundedCurve _curve;

	IIfcBoundedCurve IIfcArbitraryOpenProfileDef.Curve
	{
		get
		{
			return Curve;
		}
		set
		{
			Curve = value as IfcBoundedCurve;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcBoundedCurve Curve
	{
		get
		{
			if (_activated)
			{
				return _curve;
			}
			Activate();
			return _curve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcBoundedCurve v)
			{
				_curve = v;
			}, _curve, value, "Curve", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Curve != null)
			{
				yield return Curve;
			}
		}
	}

	internal IfcArbitraryOpenProfileDef(IModel model, int label, bool activated)
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
			_curve = (IfcBoundedCurve)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcArbitraryOpenProfileDef other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcArbitraryOpenProfileDefClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcArbitraryOpenProfileDefClause.WR11:
				result = Functions.TYPEOF(this).Contains("IFC4.IFCCENTERLINEPROFILEDEF") || base.ProfileType == IfcProfileTypeEnum.CURVE;
				break;
			case IfcArbitraryOpenProfileDefClause.WR12:
				result = Curve.Dim == 2L;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcArbitraryOpenProfileDef>()?.LogError($"Exception thrown evaluating where-clause 'IfcArbitraryOpenProfileDef.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcArbitraryOpenProfileDefClause.WR11))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcArbitraryOpenProfileDef.WR11",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcArbitraryOpenProfileDefClause.WR12))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcArbitraryOpenProfileDef.WR12",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
