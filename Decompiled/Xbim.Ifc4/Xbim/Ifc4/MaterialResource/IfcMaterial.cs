using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterial", 94)]
public class IfcMaterial : IfcMaterialDefinition, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterial, IIfcMaterialDefinition, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IEquatable<IfcMaterial>
{
	private IfcLabel _name;

	private IfcText? _description;

	private IfcLabel? _category;

	IfcLabel IIfcMaterial.Name
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

	IfcText? IIfcMaterial.Description
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

	IfcLabel? IIfcMaterial.Category
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

	IEnumerable<IIfcMaterialDefinitionRepresentation> IIfcMaterial.HasRepresentation => HasRepresentation;

	IEnumerable<IIfcMaterialRelationship> IIfcMaterial.IsRelatedWith => IsRelatedWith;

	IEnumerable<IIfcMaterialRelationship> IIfcMaterial.RelatesTo => RelatesTo;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLabel Name
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
			SetValue(delegate(IfcLabel v)
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

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
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
			}, _category, value, "Category", 3);
		}
	}

	[InverseProperty("RepresentedMaterial")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 7)]
	public IEnumerable<IfcMaterialDefinitionRepresentation> HasRepresentation => base.Model.Instances.Where((IfcMaterialDefinitionRepresentation e) => Equals(e.RepresentedMaterial), "RepresentedMaterial", this);

	[InverseProperty("RelatedMaterials")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcMaterialRelationship> IsRelatedWith => base.Model.Instances.Where((IfcMaterialRelationship e) => e.RelatedMaterials != null && e.RelatedMaterials.Contains(this), "RelatedMaterials", this);

	[InverseProperty("RelatingMaterial")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 9)]
	public IEnumerable<IfcMaterialRelationship> RelatesTo => base.Model.Instances.Where((IfcMaterialRelationship e) => Equals(e.RelatingMaterial), "RelatingMaterial", this);

	internal IfcMaterial(IModel model, int label, bool activated)
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
			_category = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterial other)
	{
		return this == other;
	}
}
