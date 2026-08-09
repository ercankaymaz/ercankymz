using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcClassificationItemRelationship", 210)]
public class IfcClassificationItemRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcClassificationItemRelationship>
{
	private IfcClassificationItem _relatingItem;

	private readonly ItemSet<IfcClassificationItem> _relatedItems;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcClassificationItem RelatingItem
	{
		get
		{
			if (_activated)
			{
				return _relatingItem;
			}
			Activate();
			return _relatingItem;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcClassificationItem v)
			{
				_relatingItem = v;
			}, _relatingItem, value, "RelatingItem", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcClassificationItem> RelatedItems
	{
		get
		{
			if (_activated)
			{
				return _relatedItems;
			}
			Activate();
			return _relatedItems;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RelatingItem != null)
			{
				yield return RelatingItem;
			}
			foreach (IfcClassificationItem relatedItem in RelatedItems)
			{
				yield return relatedItem;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatingItem != null)
			{
				yield return RelatingItem;
			}
			foreach (IfcClassificationItem relatedItem in RelatedItems)
			{
				yield return relatedItem;
			}
		}
	}

	internal IfcClassificationItemRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedItems = new ItemSet<IfcClassificationItem>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_relatingItem = (IfcClassificationItem)value.EntityVal;
			break;
		case 1:
			_relatedItems.InternalAdd((IfcClassificationItem)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcClassificationItemRelationship other)
	{
		return this == other;
	}
}
