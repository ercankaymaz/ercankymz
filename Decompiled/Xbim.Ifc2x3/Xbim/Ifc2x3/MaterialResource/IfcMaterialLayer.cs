using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.MaterialResource;

[ExpressType("IfcMaterialLayer", 446)]
public class IfcMaterialLayer : PersistEntity, IIfcMaterialLayer, IIfcMaterialDefinition, IPersistEntity, IPersist, Xbim.Ifc4.MaterialResource.IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IInstantiableEntity, IfcMaterialSelect, Xbim.Ifc2x3.PropertyResource.IfcObjectReferenceSelect, IContainsEntityReferences, IEquatable<IfcMaterialLayer>
{
	private Xbim.Ifc4.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc4.MeasureResource.IfcText? _description;

	private Xbim.Ifc4.MeasureResource.IfcLabel? _category;

	private Xbim.Ifc4.MeasureResource.IfcInteger? _priority;

	private IfcMaterial _material;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _layerThickness;

	private Xbim.Ifc2x3.MeasureResource.IfcLogical? _isVentilated;

	[CrossSchemaAttribute(typeof(IIfcMaterialLayer), 1)]
	IIfcMaterial IIfcMaterialLayer.Material
	{
		get
		{
			return Material;
		}
		set
		{
			Material = value as IfcMaterial;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayer), 2)]
	IfcNonNegativeLengthMeasure IIfcMaterialLayer.LayerThickness
	{
		get
		{
			return new IfcNonNegativeLengthMeasure(LayerThickness);
		}
		set
		{
			LayerThickness = new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayer), 3)]
	Xbim.Ifc4.MeasureResource.IfcLogical? IIfcMaterialLayer.IsVentilated
	{
		get
		{
			if (!IsVentilated.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLogical(IsVentilated.Value);
		}
		set
		{
			IsVentilated = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLogical?(new Xbim.Ifc2x3.MeasureResource.IfcLogical(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLogical?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayer), 4)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMaterialLayer.Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", -4);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayer), 5)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcMaterialLayer.Description
	{
		get
		{
			return _description;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", -5);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayer), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMaterialLayer.Category
	{
		get
		{
			return _category;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcLabel? v)
			{
				_category = v;
			}, _category, value, "Category", -6);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayer), 7)]
	Xbim.Ifc4.MeasureResource.IfcInteger? IIfcMaterialLayer.Priority
	{
		get
		{
			return _priority;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcInteger? v)
			{
				_priority = v;
			}, _priority, value, "Priority", -7);
		}
	}

	IIfcMaterialLayerSet IIfcMaterialLayer.ToMaterialLayerSet => base.Model.Instances.FirstOrDefault((IIfcMaterialLayerSet e) => e.MaterialLayers != null && e.MaterialLayers.Contains(this), "MaterialLayers", this);

	IEnumerable<IIfcRelAssociatesMaterial> IIfcMaterialDefinition.AssociatedTo => base.Model.Instances.Where((IIfcRelAssociatesMaterial e) => e.RelatingMaterial as IfcMaterialLayer == this, "RelatingMaterial", this);

	IEnumerable<IIfcExternalReferenceRelationship> IIfcMaterialDefinition.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	IEnumerable<IIfcMaterialProperties> IIfcMaterialDefinition.HasProperties => base.Model.Instances.Where((IIfcMaterialProperties e) => e.Material as IfcMaterialLayer == this, "Material", this);

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcMaterial Material
	{
		get
		{
			if (_activated)
			{
				return _material;
			}
			Activate();
			return _material;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMaterial v)
			{
				_material = v;
			}, _material, value, "Material", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure LayerThickness
	{
		get
		{
			if (_activated)
			{
				return _layerThickness;
			}
			Activate();
			return _layerThickness;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_layerThickness = v;
			}, _layerThickness, value, "LayerThickness", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLogical? IsVentilated
	{
		get
		{
			if (_activated)
			{
				return _isVentilated;
			}
			Activate();
			return _isVentilated;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLogical? v)
			{
				_isVentilated = v;
			}, _isVentilated, value, "IsVentilated", 3);
		}
	}

	[InverseProperty("MaterialLayers")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, null, null, 4)]
	public IfcMaterialLayerSet ToMaterialLayerSet => base.Model.Instances.FirstOrDefault((IfcMaterialLayerSet e) => e.MaterialLayers != null && e.MaterialLayers.Contains(this), "MaterialLayers", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Material != null)
			{
				yield return Material;
			}
		}
	}

	internal IfcMaterialLayer(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_material = (IfcMaterial)value.EntityVal;
			break;
		case 1:
			_layerThickness = value.RealVal;
			break;
		case 2:
			_isVentilated = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialLayer other)
	{
		return this == other;
	}
}
