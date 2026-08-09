using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcBooleanClippingResult", 340)]
public class IfcBooleanClippingResult : IfcBooleanResult, IInstantiableEntity, IPersistEntity, IPersist, IIfcBooleanClippingResult, IIfcBooleanResult, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcCsgSelect, IIfcCsgSelect, IContainsEntityReferences, IEquatable<IfcBooleanClippingResult>, IExpressValidatable
{
	public enum IfcBooleanClippingResultClause
	{
		FirstOperandType,
		SecondOperandType,
		OperatorType
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
			case IfcBooleanClippingResultClause.FirstOperandType:
				result = Functions.TYPEOF(base.FirstOperand).Contains("IFC4.IFCSWEPTAREASOLID") || Functions.TYPEOF(base.FirstOperand).Contains("IFC4.IFCSWEPTDISCSOLID") || Functions.TYPEOF(base.FirstOperand).Contains("IFC4.IFCBOOLEANCLIPPINGRESULT");
				break;
			case IfcBooleanClippingResultClause.SecondOperandType:
				result = Functions.TYPEOF(base.SecondOperand).Contains("IFC4.IFCHALFSPACESOLID");
				break;
			case IfcBooleanClippingResultClause.OperatorType:
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
		if (!ValidateClause(IfcBooleanClippingResultClause.FirstOperandType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBooleanClippingResult.FirstOperandType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcBooleanClippingResultClause.SecondOperandType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBooleanClippingResult.SecondOperandType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcBooleanClippingResultClause.OperatorType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBooleanClippingResult.OperatorType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
