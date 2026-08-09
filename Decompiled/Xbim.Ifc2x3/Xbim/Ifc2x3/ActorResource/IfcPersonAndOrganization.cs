using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.ActorResource;

[ExpressType("IfcPersonAndOrganization", 663)]
public class IfcPersonAndOrganization : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IfcActorSelect, IExpressSelectType, IIfcActorSelect, Xbim.Ifc2x3.PropertyResource.IfcObjectReferenceSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPersonAndOrganization>, IIfcPersonAndOrganization, Xbim.Ifc4.ActorResource.IfcActorSelect, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	private IfcPerson _thePerson;

	private IfcOrganization _theOrganization;

	private readonly OptionalItemSet<IfcActorRole> _roles;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcPerson ThePerson
	{
		get
		{
			if (_activated)
			{
				return _thePerson;
			}
			Activate();
			return _thePerson;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPerson v)
			{
				_thePerson = v;
			}, _thePerson, value, "ThePerson", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcOrganization TheOrganization
	{
		get
		{
			if (_activated)
			{
				return _theOrganization;
			}
			Activate();
			return _theOrganization;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcOrganization v)
			{
				_theOrganization = v;
			}, _theOrganization, value, "TheOrganization", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IOptionalItemSet<IfcActorRole> Roles
	{
		get
		{
			if (_activated)
			{
				return _roles;
			}
			Activate();
			return _roles;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ThePerson != null)
			{
				yield return ThePerson;
			}
			if (TheOrganization != null)
			{
				yield return TheOrganization;
			}
			foreach (IfcActorRole role in Roles)
			{
				yield return role;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ThePerson != null)
			{
				yield return ThePerson;
			}
			if (TheOrganization != null)
			{
				yield return TheOrganization;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPersonAndOrganization), 1)]
	IIfcPerson IIfcPersonAndOrganization.ThePerson
	{
		get
		{
			return ThePerson;
		}
		set
		{
			ThePerson = value as IfcPerson;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPersonAndOrganization), 2)]
	IIfcOrganization IIfcPersonAndOrganization.TheOrganization
	{
		get
		{
			return TheOrganization;
		}
		set
		{
			TheOrganization = value as IfcOrganization;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPersonAndOrganization), 3)]
	IItemSet<IIfcActorRole> IIfcPersonAndOrganization.Roles => new ProxyItemSet<IfcActorRole, IIfcActorRole>(Roles);

	internal IfcPersonAndOrganization(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_roles = new OptionalItemSet<IfcActorRole>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_thePerson = (IfcPerson)value.EntityVal;
			break;
		case 1:
			_theOrganization = (IfcOrganization)value.EntityVal;
			break;
		case 2:
			_roles.InternalAdd((IfcActorRole)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPersonAndOrganization other)
	{
		return this == other;
	}
}
