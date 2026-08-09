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

[ExpressType("IfcMaterialConstituent", 1201)]
public class IfcMaterialConstituent : IfcMaterialDefinition, IIfcMaterialConstituent, IIfcMaterialDefinition, IPersistEntity, IPersist, Xbim.Ifc4.MaterialResource.IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcMaterialConstituent>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private IfcMaterial _material;

	private Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? _fraction;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _category;

	[CrossSchemaAttribute(typeof(IIfcMaterialConstituent), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMaterialConstituent.Name
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

	[CrossSchemaAttribute(typeof(IIfcMaterialConstituent), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcMaterialConstituent.Description
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

	[CrossSchemaAttribute(typeof(IIfcMaterialConstituent), 3)]
	IIfcMaterial IIfcMaterialConstituent.Material
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

	[CrossSchemaAttribute(typeof(IIfcMaterialConstituent), 4)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcMaterialConstituent.Fraction
	{
		get
		{
			if (!Fraction.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(Fraction.Value);
		}
		set
		{
			Fraction = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialConstituent), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMaterialConstituent.Category
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

	IIfcMaterialConstituentSet IIfcMaterialConstituent.ToMaterialConstituentSet => base.Model.Instances.FirstOrDefault((IIfcMaterialConstituentSet e) => e.MaterialConstituents != null && e.MaterialConstituents.Contains(this), "MaterialConstituents", this);

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
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
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
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

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
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
			}, _material, value, "Material", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? Fraction
	{
		get
		{
			if (_activated)
			{
				return _fraction;
			}
			Activate();
			return _fraction;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? v)
			{
				_fraction = v;
			}, _fraction, value, "Fraction", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
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
			}, _category, value, "Category", 5);
		}
	}

	[InverseProperty("MaterialConstituents")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, null, null, 9)]
	public IfcMaterialConstituentSet ToMaterialConstituentSet => base.Model.Instances.FirstOrDefault((IfcMaterialConstituentSet e) => e.MaterialConstituents != null && e.MaterialConstituents.Contains(this), "MaterialConstituents", this);

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

	internal IfcMaterialConstituent(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
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
			_material = (IfcMaterial)value.EntityVal;
			break;
		case 3:
			_fraction = value.RealVal;
			break;
		case 4:
			_category = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialConstituent other)
	{
		return this == other;
	}
}
