using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.RepresentationResource;

[ExpressType("IfcStyledRepresentation", 162)]
public class IfcStyledRepresentation : IfcStyleModel, IIfcStyledRepresentation, IIfcStyleModel, IIfcRepresentation, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStyledRepresentation>, IExpressValidatable
{
	public enum IfcStyledRepresentationClause
	{
		WR21
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.ContextOfItems != null)
			{
				yield return base.ContextOfItems;
			}
			foreach (IfcRepresentationItem item in base.Items)
			{
				yield return item;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ContextOfItems != null)
			{
				yield return base.ContextOfItems;
			}
		}
	}

	internal IfcStyledRepresentation(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 3u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcStyledRepresentation other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStyledRepresentationClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStyledRepresentationClause.WR21)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.Items, (IfcRepresentationItem temp) => !Functions.TYPEOF(temp).Contains("IFC2X3.IFCSTYLEDITEM"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStyledRepresentation>()?.LogError($"Exception thrown evaluating where-clause 'IfcStyledRepresentation.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcStyledRepresentationClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStyledRepresentation.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
