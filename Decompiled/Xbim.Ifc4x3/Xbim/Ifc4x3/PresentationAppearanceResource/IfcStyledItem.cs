using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcStyledItem", 56)]
public class IfcStyledItem : IfcRepresentationItem, IIfcStyledItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStyledItem>
{
	private IItemSet<IIfcStyleAssignmentSelect> _stylesIfc4;

	private IfcRepresentationItem _item;

	private readonly ItemSet<IfcPresentationStyle> _styles;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	[CrossSchemaAttribute(typeof(IIfcStyledItem), 1)]
	IIfcRepresentationItem IIfcStyledItem.Item
	{
		get
		{
			return Item;
		}
		set
		{
			Item = value as IfcRepresentationItem;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStyledItem), 2)]
	IItemSet<IIfcStyleAssignmentSelect> IIfcStyledItem.Styles => _stylesIfc4 ?? (_stylesIfc4 = new ExtendedItemSet<IfcPresentationStyle, IIfcStyleAssignmentSelect>(Styles, new ItemSet<IIfcStyleAssignmentSelect>(this, 0, -2), StylesToIfc4, StylesToIfc2X3));

	[CrossSchemaAttribute(typeof(IIfcStyledItem), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcStyledItem.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcRepresentationItem Item
	{
		get
		{
			if (_activated)
			{
				return _item;
			}
			Activate();
			return _item;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcRepresentationItem v)
			{
				_item = v;
			}, _item, value, "Item", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcPresentationStyle> Styles
	{
		get
		{
			if (_activated)
			{
				return _styles;
			}
			Activate();
			return _styles;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Name
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Item != null)
			{
				yield return Item;
			}
			foreach (IfcPresentationStyle style in Styles)
			{
				yield return style;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (Item != null)
			{
				yield return Item;
			}
		}
	}

	private static IIfcStyleAssignmentSelect StylesToIfc4(IfcPresentationStyle member)
	{
		return member;
	}

	private static IfcPresentationStyle StylesToIfc2X3(IIfcStyleAssignmentSelect member)
	{
		return member as IfcPresentationStyle;
	}

	internal IfcStyledItem(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_styles = new ItemSet<IfcPresentationStyle>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_item = (IfcRepresentationItem)value.EntityVal;
			break;
		case 1:
			_styles.InternalAdd((IfcPresentationStyle)value.EntityVal);
			break;
		case 2:
			_name = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStyledItem other)
	{
		return this == other;
	}
}
