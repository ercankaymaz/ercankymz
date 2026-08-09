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

[ExpressType("IfcStructuralPlanarAction", 39)]
public class IfcStructuralPlanarAction : IfcStructuralSurfaceAction, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralPlanarAction, IIfcStructuralSurfaceAction, IIfcStructuralAction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralPlanarAction>, IExpressValidatable
{
	public enum IfcStructuralPlanarActionClause
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

	internal IfcStructuralPlanarAction(IModel model, int label, bool activated)
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

	public bool Equals(IfcStructuralPlanarAction other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralPlanarActionClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcStructuralPlanarActionClause.SuitableLoadType:
				result = Functions.SIZEOF(Functions.NewTypesArray("IFC4.IFCSTRUCTURALLOADPLANARFORCE", "IFC4.IFCSTRUCTURALLOADTEMPERATURE") * Functions.TYPEOF(base.AppliedLoad)) == 1;
				break;
			case IfcStructuralPlanarActionClause.ConstPredefinedType:
				result = base.PredefinedType == IfcStructuralSurfaceActivityTypeEnum.CONST;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralPlanarAction>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralPlanarAction.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralPlanarActionClause.SuitableLoadType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralPlanarAction.SuitableLoadType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcStructuralPlanarActionClause.ConstPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralPlanarAction.ConstPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
