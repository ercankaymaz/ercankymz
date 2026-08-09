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
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ActorResource;

[ExpressType("IfcActorRole", 595)]
public class IfcActorRole : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcActorRole, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcActorRole>, IExpressValidatable
{
	public enum IfcActorRoleClause
	{
		WR1
	}

	private IfcRoleEnum _role;

	private IfcLabel? _userDefinedRole;

	private IfcText? _description;

	IfcRoleEnum IIfcActorRole.Role
	{
		get
		{
			return Role;
		}
		set
		{
			Role = value;
		}
	}

	IfcLabel? IIfcActorRole.UserDefinedRole
	{
		get
		{
			return UserDefinedRole;
		}
		set
		{
			UserDefinedRole = value;
		}
	}

	IfcText? IIfcActorRole.Description
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

	IEnumerable<IIfcExternalReferenceRelationship> IIfcActorRole.HasExternalReference => HasExternalReference;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 1)]
	public IfcRoleEnum Role
	{
		get
		{
			if (_activated)
			{
				return _role;
			}
			Activate();
			return _role;
		}
		set
		{
			SetValue(delegate(IfcRoleEnum v)
			{
				_role = v;
			}, _role, value, "Role", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel? UserDefinedRole
	{
		get
		{
			if (_activated)
			{
				return _userDefinedRole;
			}
			Activate();
			return _userDefinedRole;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedRole = v;
			}, _userDefinedRole, value, "UserDefinedRole", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
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
			}, _description, value, "Description", 3);
		}
	}

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 4)]
	public IEnumerable<IfcExternalReferenceRelationship> HasExternalReference => base.Model.Instances.Where((IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	public string RoleString
	{
		get
		{
			if (Role == IfcRoleEnum.USERDEFINED)
			{
				IfcLabel? userDefinedRole = UserDefinedRole;
				if (!userDefinedRole.HasValue)
				{
					return null;
				}
				return userDefinedRole.GetValueOrDefault();
			}
			return Role.ToString();
		}
		set
		{
			IfcLabel? userDefinedRole = "";
			IfcRoleEnum role = IfcRoleEnum.SUPPLIER;
			ConvertRoleString(value, ref role, ref userDefinedRole);
			Role = role;
			UserDefinedRole = userDefinedRole;
		}
	}

	internal IfcActorRole(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_role = (IfcRoleEnum)Enum.Parse(typeof(IfcRoleEnum), value.EnumVal, ignoreCase: true);
			break;
		case 1:
			_userDefinedRole = value.StringVal;
			break;
		case 2:
			_description = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcActorRole other)
	{
		return this == other;
	}

	private static void ConvertRoleString(string value, ref IfcRoleEnum role, ref IfcLabel? userDefinedRole)
	{
		if (!string.IsNullOrEmpty(value))
		{
			string text = value.Trim();
			string value2 = text.Replace(" ", "");
			if (Enum.IsDefined(typeof(IfcRoleEnum), value2))
			{
				IfcRoleEnum ifcRoleEnum = (IfcRoleEnum)Enum.Parse(typeof(IfcRoleEnum), value2, ignoreCase: true);
				role = ifcRoleEnum;
				userDefinedRole = null;
			}
			else
			{
				userDefinedRole = text;
				role = IfcRoleEnum.USERDEFINED;
			}
		}
	}

	public bool ValidateClause(IfcActorRoleClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcActorRoleClause.WR1)
			{
				result = Role != IfcRoleEnum.USERDEFINED || (Role == IfcRoleEnum.USERDEFINED && Functions.EXISTS(UserDefinedRole));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcActorRole>()?.LogError($"Exception thrown evaluating where-clause 'IfcActorRole.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcActorRoleClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcActorRole.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
