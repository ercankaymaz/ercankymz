using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcRelNests", 305)]
public class IfcRelNests : IfcRelDecomposes, IIfcRelNests, IIfcRelDecomposes, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelNests>, IExpressValidatable
{
	public enum IfcRelNestsClause
	{
		WR1
	}

	[CrossSchemaAttribute(typeof(IIfcRelNests), 5)]
	IIfcObjectDefinition IIfcRelNests.RelatingObject
	{
		get
		{
			return base.RelatingObject;
		}
		set
		{
			base.RelatingObject = value as IfcObjectDefinition;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelNests), 6)]
	IItemSet<IIfcObjectDefinition> IIfcRelNests.RelatedObjects => new ProxyItemSet<IfcObjectDefinition, IIfcObjectDefinition>(base.RelatedObjects);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.RelatingObject != null)
			{
				yield return base.RelatingObject;
			}
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.RelatingObject != null)
			{
				yield return base.RelatingObject;
			}
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
		}
	}

	internal IfcRelNests(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 5u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcRelNests other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelNestsClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelNestsClause.WR1)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcObjectDefinition Temp) => Functions.TYPEOF(base.RelatingObject) != Functions.TYPEOF(Temp))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelNests>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelNests.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRelNestsClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelNests.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
