using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ActorResource;

[ExpressType("IfcOrganizationRelationship", 486)]
public class IfcOrganizationRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcOrganizationRelationship>, IIfcOrganizationRelationship, IIfcResourceLevelRelationship
{
	private Xbim.Ifc2x3.MeasureResource.IfcLabel _name;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _description;

	private IfcOrganization _relatingOrganization;

	private readonly ItemSet<IfcOrganization> _relatedOrganizations;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
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
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
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
			}, _description, value, "Description", 2);
		}
	}

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

	[CrossSchemaAttribute(typeof(IIfcOrganizationRelationship), 3)]
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

	[CrossSchemaAttribute(typeof(IIfcOrganizationRelationship), 4)]
	IItemSet<IIfcOrganization> IIfcOrganizationRelationship.RelatedOrganizations => new ProxyItemSet<IfcOrganization, IIfcOrganization>(RelatedOrganizations);

	[CrossSchemaAttribute(typeof(IIfcOrganizationRelationship), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcResourceLevelRelationship.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcLabel));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcOrganizationRelationship), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcResourceLevelRelationship.Description
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
			_name = value.StringVal;
			break;
		case 1:
			_description = value.StringVal;
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
