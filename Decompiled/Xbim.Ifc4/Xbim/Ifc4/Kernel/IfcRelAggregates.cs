using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRelAggregates", 631)]
public class IfcRelAggregates : IfcRelDecomposes, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelAggregates, IIfcRelDecomposes, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAggregates>, IExpressValidatable
{
	public enum IfcRelAggregatesClause
	{
		NoSelfReference
	}

	private IfcObjectDefinition _relatingObject;

	private readonly ItemSet<IfcObjectDefinition> _relatedObjects;

	IIfcObjectDefinition IIfcRelAggregates.RelatingObject
	{
		get
		{
			return RelatingObject;
		}
		set
		{
			RelatingObject = value as IfcObjectDefinition;
		}
	}

	IItemSet<IIfcObjectDefinition> IIfcRelAggregates.RelatedObjects => new ProxyItemSet<IfcObjectDefinition, IIfcObjectDefinition>(RelatedObjects);

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcObjectDefinition RelatingObject
	{
		get
		{
			if (_activated)
			{
				return _relatingObject;
			}
			Activate();
			return _relatingObject;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcObjectDefinition v)
			{
				_relatingObject = v;
			}, _relatingObject, value, "RelatingObject", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<IfcObjectDefinition> RelatedObjects
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
			if (RelatingObject != null)
			{
				yield return RelatingObject;
			}
			foreach (IfcObjectDefinition relatedObject in RelatedObjects)
			{
				yield return relatedObject;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingObject != null)
			{
				yield return RelatingObject;
			}
			foreach (IfcObjectDefinition relatedObject in RelatedObjects)
			{
				yield return relatedObject;
			}
		}
	}

	internal IfcRelAggregates(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedObjects = new ItemSet<IfcObjectDefinition>(this, 0, 6);
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
			_relatingObject = (IfcObjectDefinition)value.EntityVal;
			break;
		case 5:
			_relatedObjects.InternalAdd((IfcObjectDefinition)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAggregates other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelAggregatesClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelAggregatesClause.NoSelfReference)
			{
				result = Functions.SIZEOF(Enumerable.Where(RelatedObjects, (IfcObjectDefinition Temp) => (object)RelatingObject == Temp)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelAggregates>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelAggregates.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelAggregatesClause.NoSelfReference))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAggregates.NoSelfReference",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
