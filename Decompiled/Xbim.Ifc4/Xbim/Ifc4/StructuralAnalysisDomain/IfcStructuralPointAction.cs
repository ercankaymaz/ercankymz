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

[ExpressType("IfcStructuralPointAction", 356)]
public class IfcStructuralPointAction : IfcStructuralAction, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralPointAction, IIfcStructuralAction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralPointAction>, IExpressValidatable
{
	public enum IfcStructuralPointActionClause
	{
		SuitableLoadType
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

	internal IfcStructuralPointAction(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 9u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcStructuralPointAction other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralPointActionClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStructuralPointActionClause.SuitableLoadType)
			{
				result = Functions.SIZEOF(Functions.NewTypesArray("IFC4.IFCSTRUCTURALLOADSINGLEFORCE", "IFC4.IFCSTRUCTURALLOADSINGLEDISPLACEMENT") * Functions.TYPEOF(base.AppliedLoad)) == 1;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralPointAction>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralPointAction.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralPointActionClause.SuitableLoadType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralPointAction.SuitableLoadType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
