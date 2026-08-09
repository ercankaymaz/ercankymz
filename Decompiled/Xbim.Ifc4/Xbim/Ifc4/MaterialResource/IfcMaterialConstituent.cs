using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterialConstituent", 1201)]
public class IfcMaterialConstituent : IfcMaterialDefinition, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterialConstituent, IIfcMaterialDefinition, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IEquatable<IfcMaterialConstituent>
{
	private IfcLabel? _name;

	private IfcText? _description;

	private IfcMaterial _material;

	private IfcNormalisedRatioMeasure? _fraction;

	private IfcLabel? _category;

	IfcLabel? IIfcMaterialConstituent.Name
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

	IfcText? IIfcMaterialConstituent.Description
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

	IfcNormalisedRatioMeasure? IIfcMaterialConstituent.Fraction
	{
		get
		{
			return Fraction;
		}
		set
		{
			Fraction = value;
		}
	}

	IfcLabel? IIfcMaterialConstituent.Category
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

	IIfcMaterialConstituentSet IIfcMaterialConstituent.ToMaterialConstituentSet => ToMaterialConstituentSet;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
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
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
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
	public IfcNormalisedRatioMeasure? Fraction
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
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_fraction = v;
			}, _fraction, value, "Fraction", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
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
