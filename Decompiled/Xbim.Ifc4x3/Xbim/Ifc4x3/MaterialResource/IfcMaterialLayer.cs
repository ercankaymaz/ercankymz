using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.MaterialResource;

[ExpressType("IfcMaterialLayer", 446)]
public class IfcMaterialLayer : IfcMaterialDefinition, IIfcMaterialLayer, IIfcMaterialDefinition, IPersistEntity, IPersist, Xbim.Ifc4.MaterialResource.IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcMaterialLayer>
{
	private IfcMaterial _material;

	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure _layerThickness;

	private Xbim.Ifc4x3.MeasureResource.IfcLogical? _isVentilated;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _category;

	private Xbim.Ifc4x3.MeasureResource.IfcInteger? _priority;

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
	Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure IIfcMaterialLayer.LayerThickness
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(LayerThickness);
		}
		set
		{
			LayerThickness = new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value);
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
			IsVentilated = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLogical?(new Xbim.Ifc4x3.MeasureResource.IfcLogical(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLogical?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayer), 4)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMaterialLayer.Name
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

	[CrossSchemaAttribute(typeof(IIfcMaterialLayer), 5)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcMaterialLayer.Description
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

	[CrossSchemaAttribute(typeof(IIfcMaterialLayer), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMaterialLayer.Category
	{
		get
		{
			if (!Category.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Category.Value);
		}
		set
		{
			Category = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialLayer), 7)]
	Xbim.Ifc4.MeasureResource.IfcInteger? IIfcMaterialLayer.Priority
	{
		get
		{
			if (!Priority.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcInteger(Priority.Value);
		}
		set
		{
			Priority = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcInteger?(new Xbim.Ifc4x3.MeasureResource.IfcInteger(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcInteger?)null));
		}
	}

	IIfcMaterialLayerSet IIfcMaterialLayer.ToMaterialLayerSet => base.Model.Instances.FirstOrDefault((IIfcMaterialLayerSet e) => e.MaterialLayers != null && e.MaterialLayers.Contains(this), "MaterialLayers", this);

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
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

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure LayerThickness
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure v)
			{
				_layerThickness = v;
			}, _layerThickness, value, "LayerThickness", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcLogical? IsVentilated
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLogical? v)
			{
				_isVentilated = v;
			}, _isVentilated, value, "IsVentilated", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
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
			}, _name, value, "Name", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
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
			}, _description, value, "Description", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Category
	{
		get
		{
			if (_activated)
			{
				return _category;
			}
			Activate();
			return _category;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_category = v;
			}, _category, value, "Category", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger? Priority
	{
		get
		{
			if (_activated)
			{
				return _priority;
			}
			Activate();
			return _priority;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcInteger? v)
			{
				_priority = v;
			}, _priority, value, "Priority", 7);
		}
	}

	[InverseProperty("MaterialLayers")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, null, null, 11)]
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
		case 3:
			_name = value.StringVal;
			break;
		case 4:
			_description = value.StringVal;
			break;
		case 5:
			_category = value.StringVal;
			break;
		case 6:
			_priority = value.IntegerVal;
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
