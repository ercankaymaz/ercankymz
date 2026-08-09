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

[ExpressType("IfcRelDeclares", 1249)]
public class IfcRelDeclares : IfcRelationship, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelDeclares, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelDeclares>, IExpressValidatable
{
	public enum IfcRelDeclaresClause
	{
		NoSelfReference
	}

	private IfcContext _relatingContext;

	private readonly ItemSet<IfcDefinitionSelect> _relatedDefinitions;

	IIfcContext IIfcRelDeclares.RelatingContext
	{
		get
		{
			return RelatingContext;
		}
		set
		{
			RelatingContext = value as IfcContext;
		}
	}

	IItemSet<IIfcDefinitionSelect> IIfcRelDeclares.RelatedDefinitions => new ProxyItemSet<IfcDefinitionSelect, IIfcDefinitionSelect>(RelatedDefinitions);

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcContext RelatingContext
	{
		get
		{
			if (_activated)
			{
				return _relatingContext;
			}
			Activate();
			return _relatingContext;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcContext v)
			{
				_relatingContext = v;
			}, _relatingContext, value, "RelatingContext", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<IfcDefinitionSelect> RelatedDefinitions
	{
		get
		{
			if (_activated)
			{
				return _relatedDefinitions;
			}
			Activate();
			return _relatedDefinitions;
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
			if (RelatingContext != null)
			{
				yield return RelatingContext;
			}
			foreach (IfcDefinitionSelect relatedDefinition in RelatedDefinitions)
			{
				yield return relatedDefinition;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingContext != null)
			{
				yield return RelatingContext;
			}
			foreach (IfcDefinitionSelect relatedDefinition in RelatedDefinitions)
			{
				yield return relatedDefinition;
			}
		}
	}

	internal IfcRelDeclares(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedDefinitions = new ItemSet<IfcDefinitionSelect>(this, 0, 6);
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
			_relatingContext = (IfcContext)value.EntityVal;
			break;
		case 5:
			_relatedDefinitions.InternalAdd((IfcDefinitionSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelDeclares other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelDeclaresClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelDeclaresClause.NoSelfReference)
			{
				result = Functions.SIZEOF(Enumerable.Where(RelatedDefinitions, (IfcDefinitionSelect Temp) => (object)RelatingContext == Temp)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelDeclares>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelDeclares.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcRelDeclaresClause.NoSelfReference))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelDeclares.NoSelfReference",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
