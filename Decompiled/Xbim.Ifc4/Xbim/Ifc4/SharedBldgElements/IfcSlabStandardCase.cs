using System;
using System.Collections.Generic;
using System.Linq;
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

[ExpressType("IfcSlabStandardCase", 1269)]
public class IfcSlabStandardCase : IfcSlab, IInstantiableEntity, IPersistEntity, IPersist, IIfcSlabStandardCase, IIfcSlab, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSlabStandardCase>, IExpressValidatable
{
	public enum IfcSlabStandardCaseClause
	{
		HasMaterialLayerSetusage
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

	internal IfcSlabStandardCase(IModel model, int label, bool activated)
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

	public bool Equals(IfcSlabStandardCase other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSlabStandardCaseClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcSlabStandardCaseClause.HasMaterialLayerSetusage)
			{
				result = Functions.SIZEOF(from temp in Functions.USEDIN(this, "IFC4.IFCRELASSOCIATES.RELATEDOBJECTS")
					where Functions.TYPEOF(temp).Contains("IFC4.IFCRELASSOCIATESMATERIAL") && Functions.TYPEOF(temp.AsIfcRelAssociatesMaterial().RelatingMaterial).Contains("IFC4.IFCMATERIALLAYERSETUSAGE")
					select temp) == 1;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSlabStandardCase>()?.LogError($"Exception thrown evaluating where-clause 'IfcSlabStandardCase.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcSlabStandardCaseClause.HasMaterialLayerSetusage))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSlabStandardCase.HasMaterialLayerSetusage",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
