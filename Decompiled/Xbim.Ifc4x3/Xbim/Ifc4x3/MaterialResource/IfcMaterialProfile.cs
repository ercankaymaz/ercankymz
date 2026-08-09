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
using Xbim.Ifc4x3.ProfileResource;

namespace Xbim.Ifc4x3.MaterialResource;

[ExpressType("IfcMaterialProfile", 1205)]
public class IfcMaterialProfile : IfcMaterialDefinition, IIfcMaterialProfile, IIfcMaterialDefinition, IPersistEntity, IPersist, Xbim.Ifc4.MaterialResource.IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcMaterialProfile>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _name;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private IfcMaterial _material;

	private IfcProfileDef _profile;

	private Xbim.Ifc4x3.MeasureResource.IfcInteger? _priority;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _category;

	[CrossSchemaAttribute(typeof(IIfcMaterialProfile), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMaterialProfile.Name
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

	[CrossSchemaAttribute(typeof(IIfcMaterialProfile), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcMaterialProfile.Description
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

	[CrossSchemaAttribute(typeof(IIfcMaterialProfile), 3)]
	IIfcMaterial IIfcMaterialProfile.Material
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

	[CrossSchemaAttribute(typeof(IIfcMaterialProfile), 4)]
	IIfcProfileDef IIfcMaterialProfile.Profile
	{
		get
		{
			return Profile;
		}
		set
		{
			Profile = value as IfcProfileDef;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMaterialProfile), 5)]
	Xbim.Ifc4.MeasureResource.IfcInteger? IIfcMaterialProfile.Priority
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

	[CrossSchemaAttribute(typeof(IIfcMaterialProfile), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcMaterialProfile.Category
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

	IIfcMaterialProfileSet IIfcMaterialProfile.ToMaterialProfileSet => base.Model.Instances.FirstOrDefault((IIfcMaterialProfileSet e) => e.MaterialProfiles != null && e.MaterialProfiles.Contains(this), "MaterialProfiles", this);

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

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
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

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcProfileDef Profile
	{
		get
		{
			if (_activated)
			{
				return _profile;
			}
			Activate();
			return _profile;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProfileDef v)
			{
				_profile = v;
			}, _profile, value, "Profile", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
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
			}, _priority, value, "Priority", 5);
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

	[InverseProperty("MaterialProfiles")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, null, null, 10)]
	public IfcMaterialProfileSet ToMaterialProfileSet => base.Model.Instances.FirstOrDefault((IfcMaterialProfileSet e) => e.MaterialProfiles != null && e.MaterialProfiles.Contains(this), "MaterialProfiles", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Material != null)
			{
				yield return Material;
			}
			if (Profile != null)
			{
				yield return Profile;
			}
		}
	}

	internal IfcMaterialProfile(IModel model, int label, bool activated)
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
			_profile = (IfcProfileDef)value.EntityVal;
			break;
		case 4:
			_priority = value.IntegerVal;
			break;
		case 5:
			_category = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialProfile other)
	{
		return this == other;
	}
}
