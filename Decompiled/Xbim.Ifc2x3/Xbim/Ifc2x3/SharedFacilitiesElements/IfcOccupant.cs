using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.SharedFacilitiesElements;

[ExpressType("IfcOccupant", 641)]
public class IfcOccupant : Xbim.Ifc2x3.Kernel.IfcActor, IIfcOccupant, IIfcActor, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcOccupant>, IExpressValidatable
{
	public enum IfcOccupantClause
	{
		WR31
	}

	private IfcOccupantTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcOccupant), 7)]
	Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum? IIfcOccupant.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcOccupantTypeEnum.ASSIGNEE => Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.ASSIGNEE, 
				IfcOccupantTypeEnum.ASSIGNOR => Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.ASSIGNOR, 
				IfcOccupantTypeEnum.LESSEE => Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.LESSEE, 
				IfcOccupantTypeEnum.LESSOR => Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.LESSOR, 
				IfcOccupantTypeEnum.LETTINGAGENT => Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.LETTINGAGENT, 
				IfcOccupantTypeEnum.OWNER => Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.OWNER, 
				IfcOccupantTypeEnum.TENANT => Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.TENANT, 
				IfcOccupantTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.USERDEFINED, 
				IfcOccupantTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.ASSIGNEE:
				PredefinedType = IfcOccupantTypeEnum.ASSIGNEE;
				break;
			case Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.ASSIGNOR:
				PredefinedType = IfcOccupantTypeEnum.ASSIGNOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.LESSEE:
				PredefinedType = IfcOccupantTypeEnum.LESSEE;
				break;
			case Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.LESSOR:
				PredefinedType = IfcOccupantTypeEnum.LESSOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.LETTINGAGENT:
				PredefinedType = IfcOccupantTypeEnum.LETTINGAGENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.OWNER:
				PredefinedType = IfcOccupantTypeEnum.OWNER;
				break;
			case Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.TENANT:
				PredefinedType = IfcOccupantTypeEnum.TENANT;
				break;
			case Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.USERDEFINED:
				PredefinedType = IfcOccupantTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcOccupantTypeEnum.NOTDEFINED:
				PredefinedType = IfcOccupantTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = IfcOccupantTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 13)]
	public IfcOccupantTypeEnum PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcOccupantTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 7);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.TheActor != null)
			{
				yield return base.TheActor;
			}
		}
	}

	internal IfcOccupant(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 6:
			_predefinedType = (IfcOccupantTypeEnum)Enum.Parse(typeof(IfcOccupantTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOccupant other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcOccupantClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcOccupantClause.WR31)
			{
				result = PredefinedType != IfcOccupantTypeEnum.USERDEFINED || Functions.EXISTS(base.ObjectType);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcOccupant>()?.LogError($"Exception thrown evaluating where-clause 'IfcOccupant.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcOccupantClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcOccupant.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
