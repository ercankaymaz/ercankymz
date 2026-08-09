using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcStyledRepresentation", 162)]
public class IfcStyledRepresentation : IfcStyleModel, IInstantiableEntity, IPersistEntity, IPersist, IIfcStyledRepresentation, IIfcStyleModel, IIfcRepresentation, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStyledRepresentation>, IExpressValidatable
{
	public enum IfcStyledRepresentationClause
	{
		OnlyStyledItems
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
			if (clause == IfcStyledRepresentationClause.OnlyStyledItems)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.Items, (IfcRepresentationItem temp) => !Functions.TYPEOF(temp).Contains("IFC4.IFCSTYLEDITEM"))) == 0;
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
		if (!ValidateClause(IfcStyledRepresentationClause.OnlyStyledItems))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStyledRepresentation.OnlyStyledItems",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
