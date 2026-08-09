using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterialLayer", 446)]
public class IfcMaterialLayer : IfcMaterialDefinition, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterialLayer, IIfcMaterialDefinition, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IEquatable<IfcMaterialLayer>, IExpressValidatable
{
	public enum IfcMaterialLayerClause
	{
		NormalizedPriority
	}

	private IfcMaterial _material;

	private IfcNonNegativeLengthMeasure _layerThickness;

	private IfcLogical? _isVentilated;

	private IfcLabel? _name;

	private IfcText? _description;

	private IfcLabel? _category;

	private IfcInteger? _priority;

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

	IfcNonNegativeLengthMeasure IIfcMaterialLayer.LayerThickness
	{
		get
		{
			return LayerThickness;
		}
		set
		{
			LayerThickness = value;
		}
	}

	IfcLogical? IIfcMaterialLayer.IsVentilated
	{
		get
		{
			return IsVentilated;
		}
		set
		{
			IsVentilated = value;
		}
	}

	IfcLabel? IIfcMaterialLayer.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	IfcText? IIfcMaterialLayer.Description
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

	IfcLabel? IIfcMaterialLayer.Category
	{
		get
		{
			return Category;
		}
		set
		{
			Category = value;
		}
	}

	IfcInteger? IIfcMaterialLayer.Priority
	{
		get
		{
			return Priority;
		}
		set
		{
			Priority = value;
		}
	}

	IIfcMaterialLayerSet IIfcMaterialLayer.ToMaterialLayerSet => ToMaterialLayerSet;

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
	public IfcNonNegativeLengthMeasure LayerThickness
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
			SetValue(delegate(IfcNonNegativeLengthMeasure v)
			{
				_layerThickness = v;
			}, _layerThickness, value, "LayerThickness", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcLogical? IsVentilated
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
			SetValue(delegate(IfcLogical? v)
			{
				_isVentilated = v;
			}, _isVentilated, value, "IsVentilated", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcLabel? Name
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
			SetValue(delegate(IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
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
			}, _description, value, "Description", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcLabel? Category
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
			SetValue(delegate(IfcLabel? v)
			{
				_category = v;
			}, _category, value, "Category", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcInteger? Priority
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
			SetValue(delegate(IfcInteger? v)
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

	public bool ValidateClause(IfcMaterialLayerClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcMaterialLayerClause.NormalizedPriority)
			{
				result = !Functions.EXISTS(Priority) || (0 <= (long?)Priority && (long?)Priority <= 100);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcMaterialLayer>()?.LogError($"Exception thrown evaluating where-clause 'IfcMaterialLayer.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcMaterialLayerClause.NormalizedPriority))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMaterialLayer.NormalizedPriority",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
