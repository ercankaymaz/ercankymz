using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralPointReaction", 354)]
public class IfcStructuralPointReaction : IfcStructuralReaction, IIfcStructuralPointReaction, IIfcStructuralReaction, IIfcStructuralActivity, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralPointReaction>, IExpressValidatable
{
	public enum IfcStructuralPointReactionClause
	{
		WR61
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

	internal IfcStructuralPointReaction(IModel model, int label, bool activated)
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

	public bool Equals(IfcStructuralPointReaction other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralPointReactionClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStructuralPointReactionClause.WR61)
			{
				result = Functions.SIZEOF(Functions.NewArray<string>("IFC2X3.IFCSTRUCTURALLOADSINGLEFORCE", "IFC2X3.IFCSTRUCTURALLOADSINGLEDISPLACEMENT") * Functions.TYPEOF(base.AppliedLoad)) == 1;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralPointReaction>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralPointReaction.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralPointReactionClause.WR61))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralPointReaction.WR61",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
