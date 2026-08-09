using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.MaterialResource;

[ExpressType("IfcMaterialLayerSet", 205)]
public class IfcMaterialLayerSet : IfcMaterialDefinition, IIfcMaterialLayerSet, IIfcMaterialDefinition, IPersistEntity, IPersist, Xbim.Ifc4.MaterialResource.IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMaterialLayerSet>
{
	private readonly ItemSet<IfcMaterialLayer> _materialLayers;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _layerSetName;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	[CrossSchemaAttribute(typeof(IIfcMaterialLayerSet), 1)]
	IItemSet<IIfcMaterialLayer> IIfcMaterialLayerSet.MaterialLayers => new ProxyItemSet<IfcMaterialLayer, IIfcMaterialLayer>(MaterialLayers);

	[CrossSchemaAttribute(typeof(IIfcMaterialLayerSet), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMaterialLayerSet.LayerSetName
	{
		get
		{
			if (!LayerSetName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(LayerSetName.Value);
		}
		set
		{
			LayerSetName = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayerSet), 3)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcMaterialLayerSet.Description
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

	Xbim.Ifc4.MeasureResource.IfcLengthMeasure IIfcMaterialLayerSet.TotalThickness => new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(TotalThickness);

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
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? LayerSetName
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_layerSetName = v;
			}, _layerSetName, value, "LayerSetName", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
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
			}, _description, value, "Description", 3);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure TotalThickness => MaterialLayers.Sum((IfcMaterialLayer l) => l.LayerThickness);

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
