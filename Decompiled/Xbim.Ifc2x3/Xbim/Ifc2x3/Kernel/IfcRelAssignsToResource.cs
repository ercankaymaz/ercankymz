using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcRelAssignsToResource", 9)]
public class IfcRelAssignsToResource : IfcRelAssigns, IIfcRelAssignsToResource, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToResource>, IExpressValidatable
{
	public enum IfcRelAssignsToResourceClause
	{
		WR1
	}

	private IIfcResourceSelect _relatingResource4;

	private IfcResource _relatingResource;

	[CrossSchemaAttribute(typeof(IIfcRelAssignsToResource), 7)]
	IIfcResourceSelect IIfcRelAssignsToResource.RelatingResource
	{
		get
		{
			return _relatingResource4 ?? RelatingResource;
		}
		set
		{
			if (value == null)
			{
				RelatingResource = null;
				if (_relatingResource4 != null)
				{
					SetValue(delegate(IIfcResourceSelect v)
					{
						_relatingResource4 = v;
					}, _relatingResource4, null, "RelatingResource", -7);
				}
				return;
			}
			IfcResource ifcResource = value as IfcResource;
			if (ifcResource != null)
			{
				RelatingResource = ifcResource;
				if (_relatingResource4 != null)
				{
					SetValue(delegate(IIfcResourceSelect v)
					{
						_relatingResource4 = v;
					}, _relatingResource4, null, "RelatingResource", -7);
				}
			}
			else
			{
				if (RelatingResource != null)
				{
					RelatingResource = null;
				}
				SetValue(delegate(IIfcResourceSelect v)
				{
					_relatingResource4 = v;
				}, _relatingResource4, value, "RelatingResource", -7);
			}
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcResource RelatingResource
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
			SetValue(delegate(IfcResource v)
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
			_relatingResource = (IfcResource)value.EntityVal;
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
			if (clause == IfcRelAssignsToResourceClause.WR1)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcObjectDefinition Temp) => (object)RelatingResource == Temp)) == 0;
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
		if (!ValidateClause(IfcRelAssignsToResourceClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssignsToResource.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
