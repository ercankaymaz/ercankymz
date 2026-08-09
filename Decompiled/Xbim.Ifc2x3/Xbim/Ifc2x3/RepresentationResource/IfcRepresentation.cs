using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PresentationOrganizationResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.RepresentationResource;

[ExpressType("IfcRepresentation", 87)]
public class IfcRepresentation : PersistEntity, IIfcRepresentation, IPersistEntity, IPersist, Xbim.Ifc4.PresentationOrganizationResource.IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, Xbim.Ifc2x3.PresentationOrganizationResource.IfcLayeredItem, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRepresentation>
{
	private IfcRepresentationContext _contextOfItems;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _representationIdentifier;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _representationType;

	private readonly ItemSet<IfcRepresentationItem> _items;

	[CrossSchemaAttribute(typeof(IIfcRepresentation), 1)]
	IIfcRepresentationContext IIfcRepresentation.ContextOfItems
	{
		get
		{
			return ContextOfItems;
		}
		set
		{
			ContextOfItems = value as IfcRepresentationContext;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRepresentation), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcRepresentation.RepresentationIdentifier
	{
		get
		{
			if (!RepresentationIdentifier.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(RepresentationIdentifier.Value);
		}
		set
		{
			RepresentationIdentifier = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRepresentation), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcRepresentation.RepresentationType
	{
		get
		{
			if (!RepresentationType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(RepresentationType.Value);
		}
		set
		{
			RepresentationType = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRepresentation), 4)]
	IItemSet<IIfcRepresentationItem> IIfcRepresentation.Items => new ProxyItemSet<IfcRepresentationItem, IIfcRepresentationItem>(Items);

	IEnumerable<IIfcRepresentationMap> IIfcRepresentation.RepresentationMap => base.Model.Instances.Where((IIfcRepresentationMap e) => e.MappedRepresentation as IfcRepresentation == this, "MappedRepresentation", this);

	IEnumerable<IIfcPresentationLayerAssignment> IIfcRepresentation.LayerAssignments => base.Model.Instances.Where((IIfcPresentationLayerAssignment e) => e.AssignedItems != null && e.AssignedItems.Contains(this), "AssignedItems", this);

	IEnumerable<IIfcProductRepresentation> IIfcRepresentation.OfProductRepresentation => base.Model.Instances.Where((IIfcProductRepresentation e) => e.Representations != null && e.Representations.Contains(this), "Representations", this);

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcRepresentationContext ContextOfItems
	{
		get
		{
			if (_activated)
			{
				return _contextOfItems;
			}
			Activate();
			return _contextOfItems;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcRepresentationContext v)
			{
				_contextOfItems = v;
			}, _contextOfItems, value, "ContextOfItems", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? RepresentationIdentifier
	{
		get
		{
			if (_activated)
			{
				return _representationIdentifier;
			}
			Activate();
			return _representationIdentifier;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_representationIdentifier = v;
			}, _representationIdentifier, value, "RepresentationIdentifier", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? RepresentationType
	{
		get
		{
			if (_activated)
			{
				return _representationType;
			}
			Activate();
			return _representationType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_representationType = v;
			}, _representationType, value, "RepresentationType", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcRepresentationItem> Items
	{
		get
		{
			if (_activated)
			{
				return _items;
			}
			Activate();
			return _items;
		}
	}

	[InverseProperty("MappedRepresentation")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 5)]
	public IEnumerable<IfcRepresentationMap> RepresentationMap => base.Model.Instances.Where((IfcRepresentationMap e) => Equals(e.MappedRepresentation), "MappedRepresentation", this);

	[InverseProperty("AssignedItems")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 6)]
	public IEnumerable<Xbim.Ifc2x3.PresentationOrganizationResource.IfcPresentationLayerAssignment> LayerAssignments => base.Model.Instances.Where((Xbim.Ifc2x3.PresentationOrganizationResource.IfcPresentationLayerAssignment e) => e.AssignedItems != null && e.AssignedItems.Contains(this), "AssignedItems", this);

	[InverseProperty("Representations")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 7)]
	public IEnumerable<IfcProductRepresentation> OfProductRepresentation => base.Model.Instances.Where((IfcProductRepresentation e) => e.Representations != null && e.Representations.Contains(this), "Representations", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ContextOfItems != null)
			{
				yield return ContextOfItems;
			}
			foreach (IfcRepresentationItem item in Items)
			{
				yield return item;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ContextOfItems != null)
			{
				yield return ContextOfItems;
			}
		}
	}

	internal IfcRepresentation(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_items = new ItemSet<IfcRepresentationItem>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_contextOfItems = (IfcRepresentationContext)value.EntityVal;
			break;
		case 1:
			_representationIdentifier = value.StringVal;
			break;
		case 2:
			_representationType = value.StringVal;
			break;
		case 3:
			_items.InternalAdd((IfcRepresentationItem)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRepresentation other)
	{
		return this == other;
	}
}
