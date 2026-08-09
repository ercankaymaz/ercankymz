using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProfileResource;

[ExpressType("IfcProfileDef", 105)]
public abstract class IfcProfileDef : PersistEntity, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcProfileDef>
{
	private IfcProfileTypeEnum _profileType;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _profileName;

	[CrossSchemaAttribute(typeof(IIfcProfileDef), 1)]
	Xbim.Ifc4.Interfaces.IfcProfileTypeEnum IIfcProfileDef.ProfileType
	{
		get
		{
			return ProfileType switch
			{
				IfcProfileTypeEnum.CURVE => Xbim.Ifc4.Interfaces.IfcProfileTypeEnum.CURVE, 
				IfcProfileTypeEnum.AREA => Xbim.Ifc4.Interfaces.IfcProfileTypeEnum.AREA, 
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
			ProfileName = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
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
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? ProfileName
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_profileName = v;
			}, _profileName, value, "ProfileName", 2);
		}
	}

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
