using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.ProfileResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterialProfileSet", 1206)]
public class IfcMaterialProfileSet : IfcMaterialDefinition, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterialProfileSet, IIfcMaterialDefinition, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMaterialProfileSet>
{
	private IfcLabel? _name;

	private IfcText? _description;

	private readonly ItemSet<IfcMaterialProfile> _materialProfiles;

	private IfcCompositeProfileDef _compositeProfile;

	IfcLabel? IIfcMaterialProfileSet.Name
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

	IfcText? IIfcMaterialProfileSet.Description
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

	IItemSet<IIfcMaterialProfile> IIfcMaterialProfileSet.MaterialProfiles => new ProxyItemSet<IfcMaterialProfile, IIfcMaterialProfile>(MaterialProfiles);

	IIfcCompositeProfileDef IIfcMaterialProfileSet.CompositeProfile
	{
		get
		{
			return CompositeProfile;
		}
		set
		{
			CompositeProfile = value as IfcCompositeProfileDef;
		}
	}

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

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IItemSet<IfcMaterialProfile> MaterialProfiles
	{
		get
		{
			if (_activated)
			{
				return _materialProfiles;
			}
			Activate();
			return _materialProfiles;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcCompositeProfileDef CompositeProfile
	{
		get
		{
			if (_activated)
			{
				return _compositeProfile;
			}
			Activate();
			return _compositeProfile;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCompositeProfileDef v)
			{
				_compositeProfile = v;
			}, _compositeProfile, value, "CompositeProfile", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcMaterialProfile materialProfile in MaterialProfiles)
			{
				yield return materialProfile;
			}
			if (CompositeProfile != null)
			{
				yield return CompositeProfile;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcMaterialProfile materialProfile in MaterialProfiles)
			{
				yield return materialProfile;
			}
		}
	}

	internal IfcMaterialProfileSet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_materialProfiles = new ItemSet<IfcMaterialProfile>(this, 0, 3);
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
			_materialProfiles.InternalAdd((IfcMaterialProfile)value.EntityVal);
			break;
		case 3:
			_compositeProfile = (IfcCompositeProfileDef)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialProfileSet other)
	{
		return this == other;
	}
}
