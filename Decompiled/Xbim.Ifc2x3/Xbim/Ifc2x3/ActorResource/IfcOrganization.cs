using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.ActorResource;

[ExpressType("IfcOrganization", 276)]
public class IfcOrganization : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IfcActorSelect, IExpressSelectType, IIfcActorSelect, Xbim.Ifc2x3.PropertyResource.IfcObjectReferenceSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcOrganization>, IIfcOrganization, Xbim.Ifc4.ActorResource.IfcActorSelect, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier? _id;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel _name;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _description;

	private readonly OptionalItemSet<IfcActorRole> _roles;

	private readonly OptionalItemSet<IfcAddress> _addresses;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier? Id
	{
		get
		{
			if (_activated)
			{
				return _id;
			}
			Activate();
			return _id;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier? v)
			{
				_id = v;
			}, _id, value, "Id", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel Name
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? Description
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
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

	[CrossSchemaAttribute(typeof(IIfcOrganization), 1)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcOrganization.Identification
	{
		get
		{
			if (!Id.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Id.Value);
		}
		set
		{
			Id = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc2x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOrganization), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcOrganization.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = new Xbim.Ifc2x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOrganization), 3)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcOrganization.Description
	{
		get
		{
			if (!Description.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Description.Value);
		}
		set
		{
			Description = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOrganization), 4)]
	IItemSet<IIfcActorRole> IIfcOrganization.Roles => new ProxyItemSet<IfcActorRole, IIfcActorRole>(Roles);

	[CrossSchemaAttribute(typeof(IIfcOrganization), 5)]
	IItemSet<IIfcAddress> IIfcOrganization.Addresses => new ProxyItemSet<IfcAddress, IIfcAddress>(Addresses);

	IEnumerable<IIfcOrganizationRelationship> IIfcOrganization.IsRelatedBy => base.Model.Instances.Where((IIfcOrganizationRelationship e) => e.RelatedOrganizations != null && e.RelatedOrganizations.Contains(this), "RelatedOrganizations", this);

	IEnumerable<IIfcOrganizationRelationship> IIfcOrganization.Relates => base.Model.Instances.Where((IIfcOrganizationRelationship e) => e.RelatingOrganization as IfcOrganization == this, "RelatingOrganization", this);

	IEnumerable<IIfcPersonAndOrganization> IIfcOrganization.Engages => base.Model.Instances.Where((IIfcPersonAndOrganization e) => e.TheOrganization as IfcOrganization == this, "TheOrganization", this);

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
			_id = value.StringVal;
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

	public void AddRole(IfcActorRole newRole)
	{
		Roles.Add(newRole);
	}
}
