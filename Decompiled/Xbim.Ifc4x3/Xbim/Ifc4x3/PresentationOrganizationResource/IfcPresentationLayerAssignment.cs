using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationOrganizationResource;

[ExpressType("IfcPresentationLayerAssignment", 258)]
public class IfcPresentationLayerAssignment : PersistEntity, IIfcPresentationLayerAssignment, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPresentationLayerAssignment>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel _name;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private readonly ItemSet<IfcLayeredItem> _assignedItems;

	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _identifier;

	[CrossSchemaAttribute(typeof(IIfcPresentationLayerAssignment), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcPresentationLayerAssignment.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = new Xbim.Ifc4x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPresentationLayerAssignment), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcPresentationLayerAssignment.Description
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
			Description = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPresentationLayerAssignment), 3)]
	IItemSet<IIfcLayeredItem> IIfcPresentationLayerAssignment.AssignedItems => new ProxyItemSet<IfcLayeredItem, IIfcLayeredItem>(AssignedItems);

	[CrossSchemaAttribute(typeof(IIfcPresentationLayerAssignment), 4)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcPresentationLayerAssignment.Identifier
	{
		get
		{
			if (!Identifier.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Identifier.Value);
		}
		set
		{
			Identifier = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel Name
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcText? Description
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 2);
		}
	}

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcLayeredItem> AssignedItems
	{
		get
		{
			if (_activated)
			{
				return _assignedItems;
			}
			Activate();
			return _assignedItems;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? Identifier
	{
		get
		{
			if (_activated)
			{
				return _identifier;
			}
			Activate();
			return _identifier;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_identifier = v;
			}, _identifier, value, "Identifier", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcLayeredItem assignedItem in AssignedItems)
			{
				yield return assignedItem;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcLayeredItem assignedItem in AssignedItems)
			{
				yield return assignedItem;
			}
		}
	}

	internal IfcPresentationLayerAssignment(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_assignedItems = new ItemSet<IfcLayeredItem>(this, 0, 3);
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
			_assignedItems.InternalAdd((IfcLayeredItem)value.EntityVal);
			break;
		case 3:
			_identifier = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPresentationLayerAssignment other)
	{
		return this == other;
	}
}
