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
using Xbim.Ifc4.ProfileResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterialProfile", 1205)]
public class IfcMaterialProfile : IfcMaterialDefinition, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterialProfile, IIfcMaterialDefinition, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IEquatable<IfcMaterialProfile>, IExpressValidatable
{
	public enum IfcMaterialProfileClause
	{
		NormalizedPriority
	}

	private IfcLabel? _name;

	private IfcText? _description;

	private IfcMaterial _material;

	private IfcProfileDef _profile;

	private IfcInteger? _priority;

	private IfcLabel? _category;

	IfcLabel? IIfcMaterialProfile.Name
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

	IfcText? IIfcMaterialProfile.Description
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

	IfcInteger? IIfcMaterialProfile.Priority
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

	IfcLabel? IIfcMaterialProfile.Category
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

	IIfcMaterialProfileSet IIfcMaterialProfile.ToMaterialProfileSet => ToMaterialProfileSet;

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
			}, _priority, value, "Priority", 5);
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

	public bool ValidateClause(IfcMaterialProfileClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcMaterialProfileClause.NormalizedPriority)
			{
				result = !Functions.EXISTS(Priority) || (0 <= (long?)Priority && (long?)Priority <= 100);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcMaterialProfile>()?.LogError($"Exception thrown evaluating where-clause 'IfcMaterialProfile.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcMaterialProfileClause.NormalizedPriority))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMaterialProfile.NormalizedPriority",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
