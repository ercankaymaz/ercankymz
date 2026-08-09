using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.SharedBldgElements;

[ExpressType("IfcWallElementedCase", 1314)]
public class IfcWallElementedCase : IfcWall, IInstantiableEntity, IPersistEntity, IPersist, IIfcWallElementedCase, IIfcWall, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWallElementedCase>, IExpressValidatable
{
	public enum IfcWallElementedCaseClause
	{
		HasDecomposition
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

	internal IfcWallElementedCase(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 8u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcWallElementedCase other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcWallElementedCaseClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcWallElementedCaseClause.HasDecomposition)
			{
				result = Functions.HIINDEX(base.IsDecomposedBy) > 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcWallElementedCase>()?.LogError($"Exception thrown evaluating where-clause 'IfcWallElementedCase.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcWallElementedCaseClause.HasDecomposition))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcWallElementedCase.HasDecomposition",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
