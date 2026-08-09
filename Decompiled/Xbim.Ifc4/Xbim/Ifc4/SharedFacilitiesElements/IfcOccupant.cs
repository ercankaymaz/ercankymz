using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.SharedFacilitiesElements;

[ExpressType("IfcOccupant", 641)]
public class IfcOccupant : IfcActor, IInstantiableEntity, IPersistEntity, IPersist, IIfcOccupant, IIfcActor, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcOccupant>, IExpressValidatable
{
	public enum IfcOccupantClause
	{
		WR31
	}

	private IfcOccupantTypeEnum? _predefinedType;

	IfcOccupantTypeEnum? IIfcOccupant.PredefinedType
	{
		get
		{
			return PredefinedType;
		}
		set
		{
			PredefinedType = value;
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcOccupantTypeEnum? PredefinedType
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
			SetValue(delegate(IfcOccupantTypeEnum? v)
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
