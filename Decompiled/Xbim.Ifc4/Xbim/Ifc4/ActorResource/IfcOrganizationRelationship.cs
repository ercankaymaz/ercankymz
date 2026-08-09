using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.ActorResource;

[ExpressType("IfcOrganizationRelationship", 486)]
public class IfcOrganizationRelationship : IfcResourceLevelRelationship, IInstantiableEntity, IPersistEntity, IPersist, IIfcOrganizationRelationship, IIfcResourceLevelRelationship, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcOrganizationRelationship>
{
	private IfcOrganization _relatingOrganization;

	private readonly ItemSet<IfcOrganization> _relatedOrganizations;

	IIfcOrganization IIfcOrganizationRelationship.RelatingOrganization
	{
		get
		{
			return RelatingOrganization;
		}
		set
		{
			RelatingOrganization = value as IfcOrganization;
		}
	}

	IItemSet<IIfcOrganization> IIfcOrganizationRelationship.RelatedOrganizations => new ProxyItemSet<IfcOrganization, IIfcOrganization>(RelatedOrganizations);

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcOrganization RelatingOrganization
	{
		get
		{
			if (_activated)
			{
				return _relatingOrganization;
			}
			Activate();
			return _relatingOrganization;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcOrganization v)
			{
				_relatingOrganization = v;
			}, _relatingOrganization, value, "RelatingOrganization", 3);
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcOrganization> RelatedOrganizations
	{
		get
		{
			if (_activated)
			{
				return _relatedOrganizations;
			}
			Activate();
			return _relatedOrganizations;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RelatingOrganization != null)
			{
				yield return RelatingOrganization;
			}
			foreach (IfcOrganization relatedOrganization in RelatedOrganizations)
			{
				yield return relatedOrganization;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingOrganization != null)
			{
				yield return RelatingOrganization;
			}
			foreach (IfcOrganization relatedOrganization in RelatedOrganizations)
			{
				yield return relatedOrganization;
			}
		}
	}

	internal IfcOrganizationRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedOrganizations = new ItemSet<IfcOrganization>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_relatingOrganization = (IfcOrganization)value.EntityVal;
			break;
		case 3:
			_relatedOrganizations.InternalAdd((IfcOrganization)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOrganizationRelationship other)
	{
		return this == other;
	}
}
