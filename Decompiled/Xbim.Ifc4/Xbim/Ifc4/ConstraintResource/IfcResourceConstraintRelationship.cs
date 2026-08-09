using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.ConstraintResource;

[ExpressType("IfcResourceConstraintRelationship", 1257)]
public class IfcResourceConstraintRelationship : IfcResourceLevelRelationship, IInstantiableEntity, IPersistEntity, IPersist, IIfcResourceConstraintRelationship, IIfcResourceLevelRelationship, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcResourceConstraintRelationship>
{
	private IfcConstraint _relatingConstraint;

	private readonly ItemSet<IfcResourceObjectSelect> _relatedResourceObjects;

	IIfcConstraint IIfcResourceConstraintRelationship.RelatingConstraint
	{
		get
		{
			return RelatingConstraint;
		}
		set
		{
			RelatingConstraint = value as IfcConstraint;
		}
	}

	IItemSet<IIfcResourceObjectSelect> IIfcResourceConstraintRelationship.RelatedResourceObjects => new ProxyItemSet<IfcResourceObjectSelect, IIfcResourceObjectSelect>(RelatedResourceObjects);

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcConstraint RelatingConstraint
	{
		get
		{
			if (_activated)
			{
				return _relatingConstraint;
			}
			Activate();
			return _relatingConstraint;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcConstraint v)
			{
				_relatingConstraint = v;
			}, _relatingConstraint, value, "RelatingConstraint", 3);
		}
	}

	[IndexedProperty]
	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcResourceObjectSelect> RelatedResourceObjects
	{
		get
		{
			if (_activated)
			{
				return _relatedResourceObjects;
			}
			Activate();
			return _relatedResourceObjects;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RelatingConstraint != null)
			{
				yield return RelatingConstraint;
			}
			foreach (IfcResourceObjectSelect relatedResourceObject in RelatedResourceObjects)
			{
				yield return relatedResourceObject;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingConstraint != null)
			{
				yield return RelatingConstraint;
			}
			foreach (IfcResourceObjectSelect relatedResourceObject in RelatedResourceObjects)
			{
				yield return relatedResourceObject;
			}
		}
	}

	internal IfcResourceConstraintRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedResourceObjects = new ItemSet<IfcResourceObjectSelect>(this, 0, 4);
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
			_relatingConstraint = (IfcConstraint)value.EntityVal;
			break;
		case 3:
			_relatedResourceObjects.InternalAdd((IfcResourceObjectSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcResourceConstraintRelationship other)
	{
		return this == other;
	}
}
