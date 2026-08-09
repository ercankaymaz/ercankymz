using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.ActorResource;

[ExpressType("IfcOrganization", 276)]
public class IfcOrganization : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcOrganization, IfcActorSelect, IIfcActorSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcOrganization>
{
	private IfcIdentifier? _identification;

	private IfcLabel _name;

	private IfcText? _description;

	private readonly OptionalItemSet<IfcActorRole> _roles;

	private readonly OptionalItemSet<IfcAddress> _addresses;

	IfcIdentifier? IIfcOrganization.Identification
	{
		get
		{
			return Identification;
		}
		set
		{
			Identification = value;
		}
	}

	IfcLabel IIfcOrganization.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IfcText? IIfcOrganization.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	IItemSet<IIfcActorRole> IIfcOrganization.Roles => new ProxyItemSet<IfcActorRole, IIfcActorRole>(Roles);

	IItemSet<IIfcAddress> IIfcOrganization.Addresses => new ProxyItemSet<IfcAddress, IIfcAddress>(Addresses);

	IEnumerable<IIfcOrganizationRelationship> IIfcOrganization.IsRelatedBy => IsRelatedBy;

	IEnumerable<IIfcOrganizationRelationship> IIfcOrganization.Relates => Relates;

	IEnumerable<IIfcPersonAndOrganization> IIfcOrganization.Engages => Engages;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcIdentifier? Identification
	{
		get
		{
			if (_activated)
			{
				return _identification;
			}
			Activate();
			return _identification;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_identification = v;
			}, _identification, value, "Identification", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
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

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IOptionalItemSet<IfcAddress> Addresses
	{
		get
		{
			if (_activated)
			{
				return _addresses;
			}
			Activate();
			return _addresses;
		}
	}

	[InverseProperty("RelatedOrganizations")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 6)]
	public IEnumerable<IfcOrganizationRelationship> IsRelatedBy => base.Model.Instances.Where((IfcOrganizationRelationship e) => e.RelatedOrganizations != null && e.RelatedOrganizations.Contains(this), "RelatedOrganizations", this);

	[InverseProperty("RelatingOrganization")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 7)]
	public IEnumerable<IfcOrganizationRelationship> Relates => base.Model.Instances.Where((IfcOrganizationRelationship e) => Equals(e.RelatingOrganization), "RelatingOrganization", this);

	[InverseProperty("TheOrganization")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcPersonAndOrganization> Engages => base.Model.Instances.Where((IfcPersonAndOrganization e) => Equals(e.TheOrganization), "TheOrganization", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcActorRole role in Roles)
			{
				yield return role;
			}
			foreach (IfcAddress address in Addresses)
			{
				yield return address;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcAddress address in Addresses)
			{
				yield return address;
			}
		}
	}

	internal IfcOrganization(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_roles = new OptionalItemSet<IfcActorRole>(this, 0, 4);
		_addresses = new OptionalItemSet<IfcAddress>(this, 0, 5);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_identification = value.StringVal;
			break;
		case 1:
			_name = value.StringVal;
			break;
		case 2:
			_description = value.StringVal;
			break;
		case 3:
			_roles.InternalAdd((IfcActorRole)value.EntityVal);
			break;
		case 4:
			_addresses.InternalAdd((IfcAddress)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOrganization other)
	{
		return this == other;
	}
}
