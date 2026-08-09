using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.TopologyResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcAdvancedBrep", 1092)]
public class IfcAdvancedBrep : IfcManifoldSolidBrep, IInstantiableEntity, IPersistEntity, IPersist, IIfcAdvancedBrep, IIfcManifoldSolidBrep, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell, IContainsEntityReferences, IEquatable<IfcAdvancedBrep>, IExpressValidatable
{
	public enum IfcAdvancedBrepClause
	{
		HasAdvancedFaces
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Outer != null)
			{
				yield return base.Outer;
			}
		}
	}

	internal IfcAdvancedBrep(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcAdvancedBrep other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcAdvancedBrepClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcAdvancedBrepClause.HasAdvancedFaces)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.Outer.CfsFaces, (IfcFace Afs) => !Functions.TYPEOF(Afs).Contains("IFC4.IFCADVANCEDFACE"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAdvancedBrep>()?.LogError($"Exception thrown evaluating where-clause 'IfcAdvancedBrep.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcAdvancedBrepClause.HasAdvancedFaces))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAdvancedBrep.HasAdvancedFaces",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
