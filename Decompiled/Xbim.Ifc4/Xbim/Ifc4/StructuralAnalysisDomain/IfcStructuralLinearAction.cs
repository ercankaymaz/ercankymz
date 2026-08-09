using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.StructuralAnalysisDomain;

[ExpressType("IfcStructuralLinearAction", 463)]
public class IfcStructuralLinearAction : IfcStructuralCurveAction, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralLinearAction, IIfcStructuralCurveAction, IIfcStructuralAction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralLinearAction>, IExpressValidatable
{
	public enum IfcStructuralLinearActionClause
	{
		SuitableLoadType,
		ConstPredefinedType
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
			if (base.AppliedLoad != null)
			{
				yield return base.AppliedLoad;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcStructuralLinearAction(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 11u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcStructuralLinearAction other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralLinearActionClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcStructuralLinearActionClause.SuitableLoadType:
				result = Functions.SIZEOF(Functions.NewTypesArray("IFC4.IFCSTRUCTURALLOADLINEARFORCE", "IFC4.IFCSTRUCTURALLOADTEMPERATURE") * Functions.TYPEOF(base.AppliedLoad)) == 1;
				break;
			case IfcStructuralLinearActionClause.ConstPredefinedType:
				result = base.PredefinedType == IfcStructuralCurveActivityTypeEnum.CONST;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralLinearAction>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralLinearAction.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralLinearActionClause.SuitableLoadType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralLinearAction.SuitableLoadType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcStructuralLinearActionClause.ConstPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralLinearAction.ConstPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
