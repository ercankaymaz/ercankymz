using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.ExternalReferenceResource;

[ExpressType("IfcExternalReferenceRelationship", 1173)]
public class IfcExternalReferenceRelationship : IfcResourceLevelRelationship, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcExternalReferenceRelationship>, IIfcExternalReferenceRelationship, IIfcResourceLevelRelationship
{
	private IfcExternalReference _relatingReference;

	private readonly ItemSet<IfcResourceObjectSelect> _relatedResourceObjects;

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcExternalReference RelatingReference
	{
		get
		{
			if (_activated)
			{
				return _relatingReference;
			}
			Activate();
			return _relatingReference;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcExternalReference v)
			{
				_relatingReference = v;
			}, _relatingReference, value, "RelatingReference", 3);
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
			if (RelatingReference != null)
			{
				yield return RelatingReference;
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
			if (RelatingReference != null)
			{
				yield return RelatingReference;
			}
			foreach (IfcResourceObjectSelect relatedResourceObject in RelatedResourceObjects)
			{
				yield return relatedResourceObject;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcExternalReferenceRelationship), 3)]
	IIfcExternalReference IIfcExternalReferenceRelationship.RelatingReference
	{
		get
		{
			return RelatingReference;
		}
		set
		{
			RelatingReference = value as IfcExternalReference;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcExternalReferenceRelationship), 4)]
	IItemSet<IIfcResourceObjectSelect> IIfcExternalReferenceRelationship.RelatedResourceObjects => new ProxyItemSet<IfcResourceObjectSelect, IIfcResourceObjectSelect>(RelatedResourceObjects);

	internal IfcExternalReferenceRelationship(IModel model, int label, bool activated)
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
			_relatingReference = (IfcExternalReference)value.EntityVal;
			break;
		case 3:
			_relatedResourceObjects.InternalAdd((IfcResourceObjectSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcExternalReferenceRelationship other)
	{
		return this == other;
	}
}
