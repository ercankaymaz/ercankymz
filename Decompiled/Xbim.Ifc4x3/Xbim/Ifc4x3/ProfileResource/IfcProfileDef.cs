using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.ExternalReferenceResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcProfileDef", 105)]
public class IfcProfileDef : PersistEntity, IIfcProfileDef, IPersistEntity, IPersist, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, Xbim.Ifc4x3.ExternalReferenceResource.IfcResourceObjectSelect, IEquatable<IfcProfileDef>
{
	private IfcProfileTypeEnum _profileType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _profileName;

	[CrossSchemaAttribute(typeof(IIfcProfileDef), 1)]
	Xbim.Ifc4.Interfaces.IfcProfileTypeEnum IIfcProfileDef.ProfileType
	{
		get
		{
			return ProfileType switch
			{
				IfcProfileTypeEnum.AREA => Xbim.Ifc4.Interfaces.IfcProfileTypeEnum.AREA, 
				IfcProfileTypeEnum.CURVE => Xbim.Ifc4.Interfaces.IfcProfileTypeEnum.CURVE, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcProfileTypeEnum.CURVE:
				ProfileType = IfcProfileTypeEnum.CURVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcProfileTypeEnum.AREA:
				ProfileType = IfcProfileTypeEnum.AREA;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProfileDef), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcProfileDef.ProfileName
	{
		get
		{
			if (!ProfileName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ProfileName.Value);
		}
		set
		{
			ProfileName = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcProfileDef.HasExternalReference => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	IEnumerable<IIfcProfileProperties> IIfcProfileDef.HasProperties => base.Model.Instances.Where((IIfcProfileProperties e) => e.ProfileDefinition as IfcProfileDef == this, "ProfileDefinition", this);

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
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? ProfileName
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_profileName = v;
			}, _profileName, value, "ProfileName", 2);
		}
	}

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 3)]
	public IEnumerable<Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship> HasExternalReference => base.Model.Instances.Where((Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

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
