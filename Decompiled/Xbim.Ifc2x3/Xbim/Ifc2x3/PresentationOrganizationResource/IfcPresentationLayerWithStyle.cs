using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PresentationOrganizationResource;

[ExpressType("IfcPresentationLayerWithStyle", 259)]
public class IfcPresentationLayerWithStyle : IfcPresentationLayerAssignment, IIfcPresentationLayerWithStyle, IIfcPresentationLayerAssignment, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPresentationLayerWithStyle>
{
	private bool? _layerOn;

	private bool? _layerFrozen;

	private bool? _layerBlocked;

	private readonly ItemSet<IfcPresentationStyleSelect> _layerStyles;

	[CrossSchemaAttribute(typeof(IIfcPresentationLayerWithStyle), 5)]
	IfcLogical IIfcPresentationLayerWithStyle.LayerOn
	{
		get
		{
			return new IfcLogical(LayerOn);
		}
		set
		{
			LayerOn = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPresentationLayerWithStyle), 6)]
	IfcLogical IIfcPresentationLayerWithStyle.LayerFrozen
	{
		get
		{
			return new IfcLogical(LayerFrozen);
		}
		set
		{
			LayerFrozen = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPresentationLayerWithStyle), 7)]
	IfcLogical IIfcPresentationLayerWithStyle.LayerBlocked
	{
		get
		{
			return new IfcLogical(LayerBlocked);
		}
		set
		{
			LayerBlocked = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPresentationLayerWithStyle), 8)]
	IItemSet<IIfcPresentationStyle> IIfcPresentationLayerWithStyle.LayerStyles => new VolatileProxyItemSet<IfcPresentationStyleSelect, IIfcPresentationStyle>(LayerStyles);

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public bool? LayerOn
	{
		get
		{
			if (_activated)
			{
				return _layerOn;
			}
			Activate();
			return _layerOn;
		}
		set
		{
			SetValue(delegate(bool? v)
			{
				_layerOn = v;
			}, _layerOn, value, "LayerOn", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public bool? LayerFrozen
	{
		get
		{
			if (_activated)
			{
				return _layerFrozen;
			}
			Activate();
			return _layerFrozen;
		}
		set
		{
			SetValue(delegate(bool? v)
			{
				_layerFrozen = v;
			}, _layerFrozen, value, "LayerFrozen", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public bool? LayerBlocked
	{
		get
		{
			if (_activated)
			{
				return _layerBlocked;
			}
			Activate();
			return _layerBlocked;
		}
		set
		{
			SetValue(delegate(bool? v)
			{
				_layerBlocked = v;
			}, _layerBlocked, value, "LayerBlocked", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IItemSet<IfcPresentationStyleSelect> LayerStyles
	{
		get
		{
			if (_activated)
			{
				return _layerStyles;
			}
			Activate();
			return _layerStyles;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcLayeredItem assignedItem in base.AssignedItems)
			{
				yield return assignedItem;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcLayeredItem assignedItem in base.AssignedItems)
			{
				yield return assignedItem;
			}
		}
	}

	internal IfcPresentationLayerWithStyle(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_layerStyles = new ItemSet<IfcPresentationStyleSelect>(this, 0, 8);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_layerOn = value.BooleanVal;
			break;
		case 5:
			_layerFrozen = value.BooleanVal;
			break;
		case 6:
			_layerBlocked = value.BooleanVal;
			break;
		case 7:
			_layerStyles.InternalAdd((IfcPresentationStyleSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPresentationLayerWithStyle other)
	{
		return this == other;
	}
}
