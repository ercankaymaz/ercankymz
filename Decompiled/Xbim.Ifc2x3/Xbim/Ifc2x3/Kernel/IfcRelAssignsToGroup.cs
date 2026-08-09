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

[ExpressType("IfcRelAssignsToGroup", 278)]
public class IfcRelAssignsToGroup : IfcRelAssigns, IIfcRelAssignsToGroup, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToGroup>, IExpressValidatable
{
	public enum IfcRelAssignsToGroupClause
	{
		WR1
	}

	private IfcGroup _relatingGroup;

	[CrossSchemaAttribute(typeof(IIfcRelAssignsToGroup), 7)]
	IIfcGroup IIfcRelAssignsToGroup.RelatingGroup
	{
		get
		{
			return RelatingGroup;
		}
		set
		{
			RelatingGroup = value as IfcGroup;
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcGroup RelatingGroup
	{
		get
		{
			if (_activated)
			{
				return _relatingGroup;
			}
			Activate();
			return _relatingGroup;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcGroup v)
			{
				_relatingGroup = v;
			}, _relatingGroup, value, "RelatingGroup", 7);
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
			if (RelatingGroup != null)
			{
				yield return RelatingGroup;
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
			if (RelatingGroup != null)
			{
				yield return RelatingGroup;
			}
		}
	}

	internal IfcRelAssignsToGroup(IModel model, int label, bool activated)
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
			_relatingGroup = (IfcGroup)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssignsToGroup other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelAssignsToGroupClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelAssignsToGroupClause.WR1)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcObjectDefinition Temp) => (object)RelatingGroup == Temp)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelAssignsToGroup>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelAssignsToGroup.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRelAssignsToGroupClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssignsToGroup.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
