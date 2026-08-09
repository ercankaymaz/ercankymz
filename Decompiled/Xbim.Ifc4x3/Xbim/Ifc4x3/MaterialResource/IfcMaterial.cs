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
using Xbim.Ifc4x3.RepresentationResource;

namespace Xbim.Ifc4x3.MaterialResource;

[ExpressType("IfcMaterial", 94)]
public class IfcMaterial : IfcMaterialDefinition, IIfcMaterial, IIfcMaterialDefinition, IPersistEntity, IPersist, Xbim.Ifc4.MaterialResource.IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IInstantiableEntity, IEquatable<IfcMaterial>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel _name;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _category;

	[CrossSchemaAttribute(typeof(IIfcMaterial), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcMaterial.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = new Xbim.Ifc4x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterial), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcMaterial.Description
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

	[CrossSchemaAttribute(typeof(IIfcMaterial), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMaterial.Category
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

	IEnumerable<IIfcMaterialDefinitionRepresentation> IIfcMaterial.HasRepresentation => base.Model.Instances.Where((IIfcMaterialDefinitionRepresentation e) => e.RepresentedMaterial as IfcMaterial == this, "RepresentedMaterial", this);

	IEnumerable<IIfcMaterialRelationship> IIfcMaterial.IsRelatedWith => base.Model.Instances.Where((IIfcMaterialRelationship e) => e.RelatedMaterials != null && e.RelatedMaterials.Contains(this), "RelatedMaterials", this);

	IEnumerable<IIfcMaterialRelationship> IIfcMaterial.RelatesTo => base.Model.Instances.Where((IIfcMaterialRelationship e) => e.RelatingMaterial as IfcMaterial == this, "RelatingMaterial", this);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel Name
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel v)
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

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
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
