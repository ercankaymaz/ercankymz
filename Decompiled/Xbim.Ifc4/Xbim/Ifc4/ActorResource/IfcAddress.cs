using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ActorResource;

[ExpressType("IfcAddress", 554)]
public abstract class IfcAddress : PersistEntity, IIfcAddress, IPersistEntity, IPersist, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IExpressSelectType, IEquatable<IfcAddress>, IExpressValidatable
{
	public enum IfcAddressClause
	{
		WR1
	}

	private IfcAddressTypeEnum? _purpose;

	private IfcText? _description;

	private IfcLabel? _userDefinedPurpose;

	IfcAddressTypeEnum? IIfcAddress.Purpose
	{
		get
		{
			return Purpose;
		}
		set
		{
			Purpose = value;
		}
	}

	IfcText? IIfcAddress.Description
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

	IfcLabel? IIfcAddress.UserDefinedPurpose
	{
		get
		{
			return UserDefinedPurpose;
		}
		set
		{
			UserDefinedPurpose = value;
		}
	}

	IEnumerable<IIfcPerson> IIfcAddress.OfPerson => OfPerson;

	IEnumerable<IIfcOrganization> IIfcAddress.OfOrganization => OfOrganization;

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

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLabel? UserDefinedPurpose
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
			SetValue(delegate(IfcLabel? v)
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

	public bool ValidateClause(IfcAddressClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcAddressClause.WR1)
			{
				result = !Functions.EXISTS(Purpose) || Purpose != IfcAddressTypeEnum.USERDEFINED || (Purpose == IfcAddressTypeEnum.USERDEFINED && Functions.EXISTS(UserDefinedPurpose));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcAddress>()?.LogError($"Exception thrown evaluating where-clause 'IfcAddress.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcAddressClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcAddress.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
