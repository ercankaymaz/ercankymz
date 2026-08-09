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

[ExpressType("IfcRelAssociates", 308)]
public class IfcRelAssociates : IfcRelationship, IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssociates>, IExpressValidatable
{
	public enum IfcRelAssociatesClause
	{
		WR21
	}

	private readonly ItemSet<IfcRoot> _relatedObjects;

	[CrossSchemaAttribute(typeof(IIfcRelAssociates), 5)]
	IItemSet<IIfcDefinitionSelect> IIfcRelAssociates.RelatedObjects => new VolatileProxyItemSet<IfcRoot, IIfcDefinitionSelect>(RelatedObjects);

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IItemSet<IfcRoot> RelatedObjects
	{
		get
		{
			if (_activated)
			{
				return _relatedObjects;
			}
			Activate();
			return _relatedObjects;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcRoot relatedObject in RelatedObjects)
			{
				yield return relatedObject;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcRoot relatedObject in RelatedObjects)
			{
				yield return relatedObject;
			}
		}
	}

	internal IfcRelAssociates(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedObjects = new ItemSet<IfcRoot>(this, 0, 5);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_relatedObjects.InternalAdd((IfcRoot)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssociates other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelAssociatesClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelAssociatesClause.WR21)
			{
				result = Functions.SIZEOF(Enumerable.Where(RelatedObjects, (IfcRoot temp) => !Functions.TYPEOF(temp).Contains("IFC2X3.IFCOBJECTDEFINITION") && !Functions.TYPEOF(temp).Contains("IFC2X3.IFCPROPERTYDEFINITION"))) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelAssociates>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelAssociates.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelAssociatesClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssociates.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
