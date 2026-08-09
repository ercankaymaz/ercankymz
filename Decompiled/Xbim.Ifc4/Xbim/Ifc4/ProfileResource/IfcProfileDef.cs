using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcProfileDef", 105)]
public class IfcProfileDef : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcProfileDef>
{
	private IfcProfileTypeEnum _profileType;

	private IfcLabel? _profileName;

	IfcProfileTypeEnum IIfcProfileDef.ProfileType
	{
		get
		{
			return ProfileType;
		}
		set
		{
			ProfileType = value;
		}
	}

	IfcLabel? IIfcProfileDef.ProfileName
	{
		get
		{
			return ProfileName;
		}
		set
		{
			ProfileName = value;
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcProfileDef.HasExternalReference => HasExternalReference;

	IEnumerable<IIfcProfileProperties> IIfcProfileDef.HasProperties => HasProperties;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 1)]
	public IfcProfileTypeEnum ProfileType
	{
		get
		{
			if (_activated)
			{
				return _profileType;
			}
			Activate();
			return _profileType;
		}
		set
		{
			SetValue(delegate(IfcProfileTypeEnum v)
			{
				_profileType = v;
			}, _profileType, value, "ProfileType", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel? ProfileName
	{
		get
		{
			if (_activated)
			{
				return _profileName;
			}
			Activate();
			return _profileName;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_profileName = v;
			}, _profileName, value, "ProfileName", 2);
		}
	}

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 3)]
	public IEnumerable<IfcExternalReferenceRelationship> HasExternalReference => base.Model.Instances.Where((IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	[InverseProperty("ProfileDefinition")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcProfileProperties> HasProperties => base.Model.Instances.Where((IfcProfileProperties e) => Equals(e.ProfileDefinition), "ProfileDefinition", this);

	internal IfcProfileDef(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_profileType = (IfcProfileTypeEnum)Enum.Parse(typeof(IfcProfileTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 1:
			_profileName = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProfileDef other)
	{
		return this == other;
	}
}
