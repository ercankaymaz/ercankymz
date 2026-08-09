using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ActorResource;

[ExpressType("IfcActorRole", 595)]
public class IfcActorRole : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcActorRole>, IIfcActorRole, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IExpressValidatable
{
	public enum IfcActorRoleClause
	{
		WR1
	}

	private IfcRoleEnum _role;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _userDefinedRole;

	private Xbim.Ifc2x3.MeasureResource.IfcText? _description;

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
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? UserDefinedRole
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_userDefinedRole = v;
			}, _userDefinedRole, value, "UserDefinedRole", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcText? Description
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 3);
		}
	}

	public string RoleString
	{
		get
		{
			if (Role == IfcRoleEnum.USERDEFINED)
			{
				Xbim.Ifc2x3.MeasureResource.IfcLabel? userDefinedRole = UserDefinedRole;
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
			Xbim.Ifc2x3.MeasureResource.IfcLabel? userDefinedRole = "";
			IfcRoleEnum role = IfcRoleEnum.SUPPLIER;
			ConvertRoleString(value, ref role, ref userDefinedRole);
			Role = role;
			UserDefinedRole = userDefinedRole;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcActorRole), 1)]
	Xbim.Ifc4.Interfaces.IfcRoleEnum IIfcActorRole.Role
	{
		get
		{
			switch (Role)
			{
			case IfcRoleEnum.SUPPLIER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.SUPPLIER;
			case IfcRoleEnum.MANUFACTURER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.MANUFACTURER;
			case IfcRoleEnum.CONTRACTOR:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.CONTRACTOR;
			case IfcRoleEnum.SUBCONTRACTOR:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.SUBCONTRACTOR;
			case IfcRoleEnum.ARCHITECT:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.ARCHITECT;
			case IfcRoleEnum.STRUCTURALENGINEER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.STRUCTURALENGINEER;
			case IfcRoleEnum.COSTENGINEER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.COSTENGINEER;
			case IfcRoleEnum.CLIENT:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.CLIENT;
			case IfcRoleEnum.BUILDINGOWNER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.BUILDINGOWNER;
			case IfcRoleEnum.BUILDINGOPERATOR:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.BUILDINGOPERATOR;
			case IfcRoleEnum.MECHANICALENGINEER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.MECHANICALENGINEER;
			case IfcRoleEnum.ELECTRICALENGINEER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.ELECTRICALENGINEER;
			case IfcRoleEnum.PROJECTMANAGER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.PROJECTMANAGER;
			case IfcRoleEnum.FACILITIESMANAGER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.FACILITIESMANAGER;
			case IfcRoleEnum.CIVILENGINEER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.CIVILENGINEER;
			case IfcRoleEnum.COMISSIONINGENGINEER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.COMMISSIONINGENGINEER;
			case IfcRoleEnum.ENGINEER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.ENGINEER;
			case IfcRoleEnum.OWNER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.OWNER;
			case IfcRoleEnum.CONSULTANT:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.CONSULTANT;
			case IfcRoleEnum.CONSTRUCTIONMANAGER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.CONSTRUCTIONMANAGER;
			case IfcRoleEnum.FIELDCONSTRUCTIONMANAGER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.FIELDCONSTRUCTIONMANAGER;
			case IfcRoleEnum.RESELLER:
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.RESELLER;
			case IfcRoleEnum.USERDEFINED:
				if (UserDefinedRole == (Xbim.Ifc2x3.MeasureResource.IfcLabel?)(Xbim.Ifc2x3.MeasureResource.IfcLabel)"COMMISSIONINGENGINEER")
				{
					return Xbim.Ifc4.Interfaces.IfcRoleEnum.COMMISSIONINGENGINEER;
				}
				return Xbim.Ifc4.Interfaces.IfcRoleEnum.USERDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.SUPPLIER:
				Role = IfcRoleEnum.SUPPLIER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.MANUFACTURER:
				Role = IfcRoleEnum.MANUFACTURER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.CONTRACTOR:
				Role = IfcRoleEnum.CONTRACTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.SUBCONTRACTOR:
				Role = IfcRoleEnum.SUBCONTRACTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.ARCHITECT:
				Role = IfcRoleEnum.ARCHITECT;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.STRUCTURALENGINEER:
				Role = IfcRoleEnum.STRUCTURALENGINEER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.COSTENGINEER:
				Role = IfcRoleEnum.COSTENGINEER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.CLIENT:
				Role = IfcRoleEnum.CLIENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.BUILDINGOWNER:
				Role = IfcRoleEnum.BUILDINGOWNER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.BUILDINGOPERATOR:
				Role = IfcRoleEnum.BUILDINGOPERATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.MECHANICALENGINEER:
				Role = IfcRoleEnum.MECHANICALENGINEER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.ELECTRICALENGINEER:
				Role = IfcRoleEnum.ELECTRICALENGINEER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.PROJECTMANAGER:
				Role = IfcRoleEnum.PROJECTMANAGER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.FACILITIESMANAGER:
				Role = IfcRoleEnum.FACILITIESMANAGER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.CIVILENGINEER:
				Role = IfcRoleEnum.CIVILENGINEER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.COMMISSIONINGENGINEER:
				Role = IfcRoleEnum.COMISSIONINGENGINEER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.ENGINEER:
				Role = IfcRoleEnum.ENGINEER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.OWNER:
				Role = IfcRoleEnum.OWNER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.CONSULTANT:
				Role = IfcRoleEnum.CONSULTANT;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.CONSTRUCTIONMANAGER:
				Role = IfcRoleEnum.CONSTRUCTIONMANAGER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.FIELDCONSTRUCTIONMANAGER:
				Role = IfcRoleEnum.FIELDCONSTRUCTIONMANAGER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.RESELLER:
				Role = IfcRoleEnum.RESELLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoleEnum.USERDEFINED:
				Role = IfcRoleEnum.USERDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcActorRole), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcActorRole.UserDefinedRole
	{
		get
		{
			if (!UserDefinedRole.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UserDefinedRole.Value);
		}
		set
		{
			UserDefinedRole = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcActorRole), 3)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcActorRole.Description
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
			Description = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcText?(new Xbim.Ifc2x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcText?)null));
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcActorRole.HasExternalReference => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

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

	private static void ConvertRoleString(string value, ref IfcRoleEnum role, ref Xbim.Ifc2x3.MeasureResource.IfcLabel? userDefinedRole)
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
