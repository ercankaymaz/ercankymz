using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcBooleanClippingResult", 340)]
public class IfcBooleanClippingResult : IfcBooleanResult, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcBooleanClippingResult>, IIfcBooleanClippingResult, IIfcBooleanResult, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, Xbim.Ifc4.GeometricModelResource.IfcCsgSelect, IIfcCsgSelect, IExpressValidatable
{
	public enum IfcBooleanClippingResultClause
	{
		WR1,
		WR2,
		WR3
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.FirstOperand != null)
			{
				yield return base.FirstOperand;
			}
			if (base.SecondOperand != null)
			{
				yield return base.SecondOperand;
			}
		}
	}

	internal IfcBooleanClippingResult(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 2u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcBooleanClippingResult other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcBooleanClippingResultClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcBooleanClippingResultClause.WR1:
				result = Functions.TYPEOF(base.FirstOperand).Contains("IFC2X3.IFCSWEPTAREASOLID") || Functions.TYPEOF(base.FirstOperand).Contains("IFC2X3.IFCBOOLEANCLIPPINGRESULT");
				break;
			case IfcBooleanClippingResultClause.WR2:
				result = Functions.TYPEOF(base.SecondOperand).Contains("IFC2X3.IFCHALFSPACESOLID");
				break;
			case IfcBooleanClippingResultClause.WR3:
				result = base.Operator == IfcBooleanOperator.DIFFERENCE;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcBooleanClippingResult>()?.LogError($"Exception thrown evaluating where-clause 'IfcBooleanClippingResult.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcBooleanClippingResultClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBooleanClippingResult.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcBooleanClippingResultClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBooleanClippingResult.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcBooleanClippingResultClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBooleanClippingResult.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
