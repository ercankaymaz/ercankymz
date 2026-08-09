using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.ActorResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcRelAssignsToActor", 323)]
public class IfcRelAssignsToActor : IfcRelAssigns, IIfcRelAssignsToActor, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelAssignsToActor>
{
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
}
