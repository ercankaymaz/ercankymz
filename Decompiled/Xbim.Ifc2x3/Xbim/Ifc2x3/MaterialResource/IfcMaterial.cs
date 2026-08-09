using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MaterialResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc2x3.MaterialResource;

[ExpressType("IfcMaterial", 94)]
public class IfcMaterial : PersistEntity, IIfcMaterial, IIfcMaterialDefinition, IPersistEntity, IPersist, Xbim.Ifc4.MaterialResource.IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IInstantiableEntity, IfcMaterialSelect, Xbim.Ifc2x3.PropertyResource.IfcObjectReferenceSelect, IEquatable<IfcMaterial>
{
	private Xbim.Ifc4.MeasureResource.IfcText? _description;

	private Xbim.Ifc4.MeasureResource.IfcLabel? _category;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel _name;

	[CrossSchemaAttribute(typeof(IIfcMaterial), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcMaterial.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = new Xbim.Ifc2x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterial), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcMaterial.Description
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
			}, _description, value, "Description", -2);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterial), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMaterial.Category
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
			}, _category, value, "Category", -3);
		}
	}

	IEnumerable<IIfcMaterialDefinitionRepresentation> IIfcMaterial.HasRepresentation => base.Model.Instances.Where((IIfcMaterialDefinitionRepresentation e) => e.RepresentedMaterial as IfcMaterial == this, "RepresentedMaterial", this);

	IEnumerable<IIfcMaterialRelationship> IIfcMaterial.IsRelatedWith => base.Model.Instances.Where((IIfcMaterialRelationship e) => e.RelatedMaterials != null && e.RelatedMaterials.Contains(this), "RelatedMaterials", this);

	IEnumerable<IIfcMaterialRelationship> IIfcMaterial.RelatesTo => base.Model.Instances.Where((IIfcMaterialRelationship e) => e.RelatingMaterial as IfcMaterial == this, "RelatingMaterial", this);

	IEnumerable<IIfcRelAssociatesMaterial> IIfcMaterialDefinition.AssociatedTo => base.Model.Instances.Where((IIfcRelAssociatesMaterial e) => e.RelatingMaterial as IfcMaterial == this, "RelatingMaterial", this);

	IEnumerable<IIfcExternalReferenceRelationship> IIfcMaterialDefinition.HasExternalReferences => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	IEnumerable<IIfcMaterialProperties> IIfcMaterialDefinition.HasProperties => base.Model.Instances.Where((IIfcMaterialProperties e) => e.Material as IfcMaterial == this, "Material", this);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel Name
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[InverseProperty("RepresentedMaterial")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 2)]
	public IEnumerable<IfcMaterialDefinitionRepresentation> HasRepresentation => base.Model.Instances.Where((IfcMaterialDefinitionRepresentation e) => Equals(e.RepresentedMaterial), "RepresentedMaterial", this);

	[InverseProperty("ClassifiedMaterial")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 3)]
	public IEnumerable<IfcMaterialClassificationRelationship> ClassifiedAs => base.Model.Instances.Where((IfcMaterialClassificationRelationship e) => Equals(e.ClassifiedMaterial), "ClassifiedMaterial", this);

	internal IfcMaterial(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_name = value.StringVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcMaterial other)
	{
		return this == other;
	}
}
