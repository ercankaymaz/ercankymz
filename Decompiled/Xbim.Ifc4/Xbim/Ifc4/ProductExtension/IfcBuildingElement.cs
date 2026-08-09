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

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcBuildingElement", 26)]
public abstract class IfcBuildingElement : IfcElement, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IEquatable<IfcBuildingElement>, IExpressValidatable
{
	public enum IfcBuildingElementClause
	{
		MaxOneMaterialAssociation
	}

	internal IfcBuildingElement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 7u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcBuildingElement other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcBuildingElementClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcBuildingElementClause.MaxOneMaterialAssociation)
			{
				result = Functions.SIZEOF(base.HasAssociations.Where((IfcRelAssociates temp) => Functions.TYPEOF(temp).Contains("IFC4.IFCRELASSOCIATESMATERIAL"))) <= 1;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcBuildingElement>()?.LogError($"Exception thrown evaluating where-clause 'IfcBuildingElement.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcBuildingElementClause.MaxOneMaterialAssociation))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBuildingElement.MaxOneMaterialAssociation",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
