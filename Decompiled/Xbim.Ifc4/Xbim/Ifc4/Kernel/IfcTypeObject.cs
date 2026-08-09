using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcTypeObject", 42)]
public class IfcTypeObject : IfcObjectDefinition, IInstantiableEntity, IPersistEntity, IPersist, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTypeObject>, IExpressValidatable
{
	public enum IfcTypeObjectClause
	{
		NameRequired,
		UniquePropertySetNames
	}

	private IfcIdentifier? _applicableOccurrence;

	private readonly OptionalItemSet<IfcPropertySetDefinition> _hasPropertySets;

	IfcIdentifier? IIfcTypeObject.ApplicableOccurrence
	{
		get
		{
			return ApplicableOccurrence;
		}
		set
		{
			ApplicableOccurrence = value;
		}
	}

	IItemSet<IIfcPropertySetDefinition> IIfcTypeObject.HasPropertySets => new ProxyItemSet<IfcPropertySetDefinition, IIfcPropertySetDefinition>(HasPropertySets);

	IEnumerable<IIfcRelDefinesByType> IIfcTypeObject.Types => Types;

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcIdentifier? ApplicableOccurrence
	{
		get
		{
			if (_activated)
			{
				return _applicableOccurrence;
			}
			Activate();
			return _applicableOccurrence;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_applicableOccurrence = v;
			}, _applicableOccurrence, value, "ApplicableOccurrence", 5);
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 13)]
	public IOptionalItemSet<IfcPropertySetDefinition> HasPropertySets
	{
		get
		{
			if (_activated)
			{
				return _hasPropertySets;
			}
			Activate();
			return _hasPropertySets;
		}
	}

	[InverseProperty("RelatingType")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 14)]
	public IEnumerable<IfcRelDefinesByType> Types => base.Model.Instances.Where((IfcRelDefinesByType e) => Equals(e.RelatingType), "RelatingType", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcPropertySetDefinition hasPropertySet in HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcPropertySetDefinition hasPropertySet in HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	public IEnumerable<IIfcRelDefinesByProperties> DefinedByProperties => base.Model.Instances.Where((IfcRelDefinesByProperties e) => e.RelatedObjects.Contains(this), "RelatedObjects", this);

	internal IfcTypeObject(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_hasPropertySets = new OptionalItemSet<IfcPropertySetDefinition>(this, 0, 6);
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
			_applicableOccurrence = value.StringVal;
			break;
		case 5:
			_hasPropertySets.InternalAdd((IfcPropertySetDefinition)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTypeObject other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTypeObjectClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcTypeObjectClause.NameRequired:
				result = Functions.EXISTS(base.Name);
				break;
			case IfcTypeObjectClause.UniquePropertySetNames:
				result = !Functions.EXISTS(HasPropertySets) || Functions.IfcUniquePropertySetNames(HasPropertySets);
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTypeObject>()?.LogError($"Exception thrown evaluating where-clause 'IfcTypeObject.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcTypeObjectClause.NameRequired))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTypeObject.NameRequired",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTypeObjectClause.UniquePropertySetNames))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTypeObject.UniquePropertySetNames",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
