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

[ExpressType("IfcPlateStandardCase", 1224)]
public class IfcPlateStandardCase : IfcPlate, IInstantiableEntity, IPersistEntity, IPersist, IIfcPlateStandardCase, IIfcPlate, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPlateStandardCase>, IExpressValidatable
{
	public enum IfcPlateStandardCaseClause
	{
		HasMaterialLayerSetUsage
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

	internal IfcPlateStandardCase(IModel model, int label, bool activated)
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

	public bool Equals(IfcPlateStandardCase other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcPlateStandardCaseClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPlateStandardCaseClause.HasMaterialLayerSetUsage)
			{
				result = Functions.SIZEOF(from temp in Functions.USEDIN(this, "IFC4.IFCRELASSOCIATES.RELATEDOBJECTS")
					where Functions.TYPEOF(temp).Contains("IFC4.IFCRELASSOCIATESMATERIAL") && Functions.TYPEOF(temp.AsIfcRelAssociatesMaterial().RelatingMaterial).Contains("IFC4.IFCMATERIALLAYERSETUSAGE")
					select temp) == 1;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPlateStandardCase>()?.LogError($"Exception thrown evaluating where-clause 'IfcPlateStandardCase.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcPlateStandardCaseClause.HasMaterialLayerSetUsage))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPlateStandardCase.HasMaterialLayerSetUsage",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
