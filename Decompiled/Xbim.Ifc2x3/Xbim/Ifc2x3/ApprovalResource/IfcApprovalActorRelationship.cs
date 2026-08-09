using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ActorResource;

namespace Xbim.Ifc2x3.ApprovalResource;

[ExpressType("IfcApprovalActorRelationship", 442)]
public class IfcApprovalActorRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcApprovalActorRelationship>
{
	private IfcActorSelect _actor;

	private IfcApproval _approval;

	private IfcActorRole _role;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcActorSelect Actor
	{
		get
		{
			if (_activated)
			{
				return _actor;
			}
			Activate();
			return _actor;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_actor = v;
			}, _actor, value, "Actor", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcApproval Approval
	{
		get
		{
			if (_activated)
			{
				return _approval;
			}
			Activate();
			return _approval;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcApproval v)
			{
				_approval = v;
			}, _approval, value, "Approval", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcActorRole Role
	{
		get
		{
			if (_activated)
			{
				return _role;
			}
			Activate();
			return _role;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorRole v)
			{
				_role = v;
			}, _role, value, "Role", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Actor != null)
			{
				yield return Actor;
			}
			if (Approval != null)
			{
				yield return Approval;
			}
			if (Role != null)
			{
				yield return Role;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (Approval != null)
			{
				yield return Approval;
			}
		}
	}

	internal IfcApprovalActorRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_actor = (IfcActorSelect)value.EntityVal;
			break;
		case 1:
			_approval = (IfcApproval)value.EntityVal;
			break;
		case 2:
			_role = (IfcActorRole)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcApprovalActorRelationship other)
	{
		return this == other;
	}
}
