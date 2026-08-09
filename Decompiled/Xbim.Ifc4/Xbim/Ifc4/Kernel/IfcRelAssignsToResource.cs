using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRelAssignsToResource", 9)]
public class IfcRelAssignsToResource : IfcRelAssigns, IInstantiableEntity, IPersistEntity, IPersist, IIfcRelAssignsToResource, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToResource>, IExpressValidatable
{
	public enum IfcRelAssignsToResourceClause
	{
		NoSelfReference
	}

	private IfcResourceSelect _relatingResource;

	IIfcResourceSelect IIfcRelAssignsToResource.RelatingResource
	{
		get
		{
			return RelatingResource;
		}
		set
		{
			RelatingResource = value as IfcResourceSelect;
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcResourceSelect RelatingResource
	{
		get
		{
			if (_activated)
			{
				return _relatingResource;
			}
			Activate();
			return _relatingResource;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcResourceSelect v)
			{
				_relatingResource = v;
			}, _relatingResource, value, "RelatingResource", 7);
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
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingResource != null)
			{
				yield return RelatingResource;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcObjectDefinition relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingResource != null)
			{
				yield return RelatingResource;
			}
		}
	}

	internal IfcRelAssignsToResource(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_relatingResource = (IfcResourceSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssignsToResource other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelAssignsToResourceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelAssignsToResourceClause.NoSelfReference)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcObjectDefinition Temp) => RelatingResource == Temp)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelAssignsToResource>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelAssignsToResource.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRelAssignsToResourceClause.NoSelfReference))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssignsToResource.NoSelfReference",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
