using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterialLayerSet", 205)]
public class IfcMaterialLayerSet : IfcMaterialDefinition, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterialLayerSet, IIfcMaterialDefinition, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMaterialLayerSet>
{
	private readonly ItemSet<IfcMaterialLayer> _materialLayers;

	private IfcLabel? _layerSetName;

	private IfcText? _description;

	IItemSet<IIfcMaterialLayer> IIfcMaterialLayerSet.MaterialLayers => new ProxyItemSet<IfcMaterialLayer, IIfcMaterialLayer>(MaterialLayers);

	IfcLabel? IIfcMaterialLayerSet.LayerSetName
	{
		get
		{
			return LayerSetName;
		}
		set
		{
			LayerSetName = value;
		}
	}

	IfcText? IIfcMaterialLayerSet.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	IfcLengthMeasure IIfcMaterialLayerSet.TotalThickness => TotalThickness;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcMaterialLayer> MaterialLayers
	{
		get
		{
			if (_activated)
			{
				return _materialLayers;
			}
			Activate();
			return _materialLayers;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcLabel? LayerSetName
	{
		get
		{
			if (_activated)
			{
				return _layerSetName;
			}
			Activate();
			return _layerSetName;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_layerSetName = v;
			}, _layerSetName, value, "LayerSetName", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcText? Description
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
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 3);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public IfcLengthMeasure TotalThickness => MaterialLayers.Aggregate(0.0, (double i, IfcMaterialLayer layer) => i + (double)layer.LayerThickness);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcMaterialLayer materialLayer in MaterialLayers)
			{
				yield return materialLayer;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcMaterialLayer materialLayer in MaterialLayers)
			{
				yield return materialLayer;
			}
		}
	}

	internal IfcMaterialLayerSet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_materialLayers = new ItemSet<IfcMaterialLayer>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_materialLayers.InternalAdd((IfcMaterialLayer)value.EntityVal);
			break;
		case 1:
			_layerSetName = value.StringVal;
			break;
		case 2:
			_description = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialLayerSet other)
	{
		return this == other;
	}
}
