using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PresentationAppearanceResource;

namespace Xbim.Ifc4x3.PresentationOrganizationResource;

[ExpressType("IfcPresentationLayerWithStyle", 259)]
public class IfcPresentationLayerWithStyle : IfcPresentationLayerAssignment, IIfcPresentationLayerWithStyle, IIfcPresentationLayerAssignment, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPresentationLayerWithStyle>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLogical _layerOn;

	private Xbim.Ifc4x3.MeasureResource.IfcLogical _layerFrozen;

	private Xbim.Ifc4x3.MeasureResource.IfcLogical _layerBlocked;

	private readonly ItemSet<IfcPresentationStyle> _layerStyles;

	[CrossSchemaAttribute(typeof(IIfcPresentationLayerWithStyle), 5)]
	Xbim.Ifc4.MeasureResource.IfcLogical IIfcPresentationLayerWithStyle.LayerOn
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLogical(LayerOn);
		}
		set
		{
			LayerOn = new Xbim.Ifc4x3.MeasureResource.IfcLogical(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPresentationLayerWithStyle), 6)]
	Xbim.Ifc4.MeasureResource.IfcLogical IIfcPresentationLayerWithStyle.LayerFrozen
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLogical(LayerFrozen);
		}
		set
		{
			LayerFrozen = new Xbim.Ifc4x3.MeasureResource.IfcLogical(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPresentationLayerWithStyle), 7)]
	Xbim.Ifc4.MeasureResource.IfcLogical IIfcPresentationLayerWithStyle.LayerBlocked
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLogical(LayerBlocked);
		}
		set
		{
			LayerBlocked = new Xbim.Ifc4x3.MeasureResource.IfcLogical(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPresentationLayerWithStyle), 8)]
	IItemSet<IIfcPresentationStyle> IIfcPresentationLayerWithStyle.LayerStyles => new ProxyItemSet<IfcPresentationStyle, IIfcPresentationStyle>(LayerStyles);

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcLogical LayerOn
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLogical v)
			{
				_layerOn = v;
			}, _layerOn, value, "LayerOn", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcLogical LayerFrozen
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLogical v)
			{
				_layerFrozen = v;
			}, _layerFrozen, value, "LayerFrozen", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcLogical LayerBlocked
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLogical v)
			{
				_layerBlocked = v;
			}, _layerBlocked, value, "LayerBlocked", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IItemSet<IfcPresentationStyle> LayerStyles
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
			foreach (IfcPresentationStyle layerStyle in LayerStyles)
			{
				yield return layerStyle;
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
		_layerStyles = new ItemSet<IfcPresentationStyle>(this, 0, 8);
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
			_layerStyles.InternalAdd((IfcPresentationStyle)value.EntityVal);
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
