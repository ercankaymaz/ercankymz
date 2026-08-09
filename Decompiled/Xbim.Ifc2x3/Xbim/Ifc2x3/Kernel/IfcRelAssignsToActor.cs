using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcRelAssignsToActor", 323)]
public class IfcRelAssignsToActor : IfcRelAssigns, IIfcRelAssignsToActor, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToActor>, IExpressValidatable
{
	public enum IfcRelAssignsToActorClause
	{
		WR1
	}

	private IfcActor _relatingActor;

	private IfcActorRole _actingRole;

	[CrossSchemaAttribute(typeof(IIfcRelAssignsToActor), 7)]
	IIfcActor IIfcRelAssignsToActor.RelatingActor
	{
		get
		{
			return RelatingActor;
		}
		set
		{
			RelatingActor = value as IfcActor;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRelAssignsToActor), 8)]
	IIfcActorRole IIfcRelAssignsToActor.ActingRole
	{
		get
		{
			return ActingRole;
		}
		set
		{
			ActingRole = value as IfcActorRole;
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcActor RelatingActor
	{
		get
		{
			if (_activated)
			{
				return _relatingActor;
			}
			Activate();
			return _relatingActor;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActor v)
			{
				_relatingActor = v;
			}, _relatingActor, value, "RelatingActor", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcActorRole ActingRole
	{
		get
		{
			if (_activated)
			{
				return _actingRole;
			}
			Activate();
			return _actingRole;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorRole v)
			{
				_actingRole = v;
			}, _actingRole, value, "ActingRole", 8);
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
			if (RelatingActor != null)
			{
				yield return RelatingActor;
			}
			if (ActingRole != null)
			{
				yield return ActingRole;
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
			if (RelatingActor != null)
			{
				yield return RelatingActor;
			}
		}
	}

	internal IfcRelAssignsToActor(IModel model, int label, bool activated)
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
			_relatingActor = (IfcActor)value.EntityVal;
			break;
		case 7:
			_actingRole = (IfcActorRole)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssignsToActor other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcRelAssignsToActorClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcRelAssignsToActorClause.WR1)
			{
				result = Functions.SIZEOF(Enumerable.Where(base.RelatedObjects, (IfcObjectDefinition Temp) => (object)RelatingActor == Temp)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcRelAssignsToActor>()?.LogError($"Exception thrown evaluating where-clause 'IfcRelAssignsToActor.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcRelAssignsToActorClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcRelAssignsToActor.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
