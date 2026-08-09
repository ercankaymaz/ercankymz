using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.PropertyResource;

namespace Xbim.Ifc4x3.ActorResource;

[ExpressType("IfcAddress", 554)]
public abstract class IfcAddress : PersistEntity, Xbim.Ifc4x3.PropertyResource.IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IExpressSelectType, IPersist, IPersistEntity, IEquatable<IfcAddress>, IIfcAddress, Xbim.Ifc4.PropertyResource.IfcObjectReferenceSelect
{
	private IfcAddressTypeEnum? _purpose;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _userDefinedPurpose;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 1)]
	public IfcAddressTypeEnum? Purpose
	{
		get
		{
			if (_activated)
			{
				return _purpose;
			}
			Activate();
			return _purpose;
		}
		set
		{
			SetValue(delegate(IfcAddressTypeEnum? v)
			{
				_purpose = v;
			}, _purpose, value, "Purpose", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
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

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? UserDefinedPurpose
	{
		get
		{
			if (_activated)
			{
				return _userDefinedPurpose;
			}
			Activate();
			return _userDefinedPurpose;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_userDefinedPurpose = v;
			}, _userDefinedPurpose, value, "UserDefinedPurpose", 3);
		}
	}

	[InverseProperty("Addresses")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcPerson> OfPerson => base.Model.Instances.Where((IfcPerson e) => e.Addresses != null && e.Addresses.Contains(this), "Addresses", this);

	[InverseProperty("Addresses")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 5)]
	public IEnumerable<IfcOrganization> OfOrganization => base.Model.Instances.Where((IfcOrganization e) => e.Addresses != null && e.Addresses.Contains(this), "Addresses", this);

	[CrossSchemaAttribute(typeof(IIfcAddress), 1)]
	Xbim.Ifc4.Interfaces.IfcAddressTypeEnum? IIfcAddress.Purpose
	{
		get
		{
			return Purpose switch
			{
				IfcAddressTypeEnum.DISTRIBUTIONPOINT => Xbim.Ifc4.Interfaces.IfcAddressTypeEnum.DISTRIBUTIONPOINT, 
				IfcAddressTypeEnum.HOME => Xbim.Ifc4.Interfaces.IfcAddressTypeEnum.HOME, 
				IfcAddressTypeEnum.OFFICE => Xbim.Ifc4.Interfaces.IfcAddressTypeEnum.OFFICE, 
				IfcAddressTypeEnum.SITE => Xbim.Ifc4.Interfaces.IfcAddressTypeEnum.SITE, 
				IfcAddressTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcAddressTypeEnum.USERDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAddressTypeEnum.OFFICE:
				Purpose = IfcAddressTypeEnum.OFFICE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAddressTypeEnum.SITE:
				Purpose = IfcAddressTypeEnum.SITE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAddressTypeEnum.HOME:
				Purpose = IfcAddressTypeEnum.HOME;
				break;
			case Xbim.Ifc4.Interfaces.IfcAddressTypeEnum.DISTRIBUTIONPOINT:
				Purpose = IfcAddressTypeEnum.DISTRIBUTIONPOINT;
				break;
			case Xbim.Ifc4.Interfaces.IfcAddressTypeEnum.USERDEFINED:
				Purpose = IfcAddressTypeEnum.USERDEFINED;
				break;
			case null:
				Purpose = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcAddress), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcAddress.Description
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

	[CrossSchemaAttribute(typeof(IIfcAddress), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcAddress.UserDefinedPurpose
	{
		get
		{
			if (!UserDefinedPurpose.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UserDefinedPurpose.Value);
		}
		set
		{
			UserDefinedPurpose = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcPerson> IIfcAddress.OfPerson => base.Model.Instances.Where((IIfcPerson e) => e.Addresses != null && e.Addresses.Contains(this), "Addresses", this);

	IEnumerable<IIfcOrganization> IIfcAddress.OfOrganization => base.Model.Instances.Where((IIfcOrganization e) => e.Addresses != null && e.Addresses.Contains(this), "Addresses", this);

	internal IfcAddress(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_purpose = (IfcAddressTypeEnum)Enum.Parse(typeof(IfcAddressTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 1:
			_description = value.StringVal;
			break;
		case 2:
			_userDefinedPurpose = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAddress other)
	{
		return this == other;
	}
}
