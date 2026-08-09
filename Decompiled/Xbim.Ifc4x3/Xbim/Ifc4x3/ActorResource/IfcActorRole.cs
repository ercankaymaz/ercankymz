using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.ExternalReferenceResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ActorResource;

[ExpressType("IfcActorRole", 595)]
public class IfcActorRole : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, Xbim.Ifc4x3.ExternalReferenceResource.IfcResourceObjectSelect, IExpressSelectType, IIfcResourceObjectSelect, IEquatable<IfcActorRole>, IIfcActorRole, Xbim.Ifc4.ExternalReferenceResource.IfcResourceObjectSelect
{
	private IfcRoleEnum _role;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _userDefinedRole;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

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
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? UserDefinedRole
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_userDefinedRole = v;
			}, _userDefinedRole, value, "UserDefinedRole", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
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
			}, _description, value, "Description", 3);
		}
	}

	[InverseProperty("RelatedResourceObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 4)]
	public IEnumerable<Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship> HasExternalReference => base.Model.Instances.Where((Xbim.Ifc4x3.ExternalReferenceResource.IfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	public string RoleString
	{
		get
		{
			if (Role == IfcRoleEnum.USERDEFINED)
			{
				Xbim.Ifc4x3.MeasureResource.IfcLabel? userDefinedRole = UserDefinedRole;
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
			Xbim.Ifc4x3.MeasureResource.IfcLabel? userDefinedRole = "";
			IfcRoleEnum role = IfcRoleEnum.ARCHITECT;
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
			return Role switch
			{
				IfcRoleEnum.ARCHITECT => Xbim.Ifc4.Interfaces.IfcRoleEnum.ARCHITECT, 
				IfcRoleEnum.BUILDINGOPERATOR => Xbim.Ifc4.Interfaces.IfcRoleEnum.BUILDINGOPERATOR, 
				IfcRoleEnum.BUILDINGOWNER => Xbim.Ifc4.Interfaces.IfcRoleEnum.BUILDINGOWNER, 
				IfcRoleEnum.CIVILENGINEER => Xbim.Ifc4.Interfaces.IfcRoleEnum.CIVILENGINEER, 
				IfcRoleEnum.CLIENT => Xbim.Ifc4.Interfaces.IfcRoleEnum.CLIENT, 
				IfcRoleEnum.COMMISSIONINGENGINEER => Xbim.Ifc4.Interfaces.IfcRoleEnum.COMMISSIONINGENGINEER, 
				IfcRoleEnum.CONSTRUCTIONMANAGER => Xbim.Ifc4.Interfaces.IfcRoleEnum.CONSTRUCTIONMANAGER, 
				IfcRoleEnum.CONSULTANT => Xbim.Ifc4.Interfaces.IfcRoleEnum.CONSULTANT, 
				IfcRoleEnum.CONTRACTOR => Xbim.Ifc4.Interfaces.IfcRoleEnum.CONTRACTOR, 
				IfcRoleEnum.COSTENGINEER => Xbim.Ifc4.Interfaces.IfcRoleEnum.COSTENGINEER, 
				IfcRoleEnum.ELECTRICALENGINEER => Xbim.Ifc4.Interfaces.IfcRoleEnum.ELECTRICALENGINEER, 
				IfcRoleEnum.ENGINEER => Xbim.Ifc4.Interfaces.IfcRoleEnum.ENGINEER, 
				IfcRoleEnum.FACILITIESMANAGER => Xbim.Ifc4.Interfaces.IfcRoleEnum.FACILITIESMANAGER, 
				IfcRoleEnum.FIELDCONSTRUCTIONMANAGER => Xbim.Ifc4.Interfaces.IfcRoleEnum.FIELDCONSTRUCTIONMANAGER, 
				IfcRoleEnum.MANUFACTURER => Xbim.Ifc4.Interfaces.IfcRoleEnum.MANUFACTURER, 
				IfcRoleEnum.MECHANICALENGINEER => Xbim.Ifc4.Interfaces.IfcRoleEnum.MECHANICALENGINEER, 
				IfcRoleEnum.OWNER => Xbim.Ifc4.Interfaces.IfcRoleEnum.OWNER, 
				IfcRoleEnum.PROJECTMANAGER => Xbim.Ifc4.Interfaces.IfcRoleEnum.PROJECTMANAGER, 
				IfcRoleEnum.RESELLER => Xbim.Ifc4.Interfaces.IfcRoleEnum.RESELLER, 
				IfcRoleEnum.STRUCTURALENGINEER => Xbim.Ifc4.Interfaces.IfcRoleEnum.STRUCTURALENGINEER, 
				IfcRoleEnum.SUBCONTRACTOR => Xbim.Ifc4.Interfaces.IfcRoleEnum.SUBCONTRACTOR, 
				IfcRoleEnum.SUPPLIER => Xbim.Ifc4.Interfaces.IfcRoleEnum.SUPPLIER, 
				IfcRoleEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcRoleEnum.USERDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
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
				Role = IfcRoleEnum.COMMISSIONINGENGINEER;
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
			UserDefinedRole = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
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
			Description = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	IEnumerable<IIfcExternalReferenceRelationship> IIfcActorRole.HasExternalReference => base.Model.Instances.Where((IIfcExternalReferenceRelationship e) => e.RelatedResourceObjects != null && e.RelatedResourceObjects.Contains(this), "RelatedResourceObjects", this);

	string IIfcActorRole.RoleString
	{
		get
		{
			if (Role == IfcRoleEnum.USERDEFINED)
			{
				Xbim.Ifc4x3.MeasureResource.IfcLabel? userDefinedRole = UserDefinedRole;
				if (!userDefinedRole.HasValue)
				{
					return null;
				}
				return userDefinedRole.GetValueOrDefault();
			}
			return Role.ToString();
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

	private static void ConvertRoleString(string value, ref IfcRoleEnum role, ref Xbim.Ifc4x3.MeasureResource.IfcLabel? userDefinedRole)
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
}
