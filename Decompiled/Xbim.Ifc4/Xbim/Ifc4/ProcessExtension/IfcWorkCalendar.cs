using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProcessExtension;

[ExpressType("IfcWorkCalendar", 1318)]
public class IfcWorkCalendar : IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IIfcWorkCalendar, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcWorkCalendar>, IExpressValidatable
{
	public enum IfcWorkCalendarClause
	{
		CorrectPredefinedType
	}

	private readonly OptionalItemSet<IfcWorkTime> _workingTimes;

	private readonly OptionalItemSet<IfcWorkTime> _exceptionTimes;

	private IfcWorkCalendarTypeEnum? _predefinedType;

	IItemSet<IIfcWorkTime> IIfcWorkCalendar.WorkingTimes => new ProxyItemSet<IfcWorkTime, IIfcWorkTime>(WorkingTimes);

	IItemSet<IIfcWorkTime> IIfcWorkCalendar.ExceptionTimes => new ProxyItemSet<IfcWorkTime, IIfcWorkTime>(ExceptionTimes);

	IfcWorkCalendarTypeEnum? IIfcWorkCalendar.PredefinedType
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

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 19)]
	public IOptionalItemSet<IfcWorkTime> WorkingTimes
	{
		get
		{
			if (_activated)
			{
				return _workingTimes;
			}
			Activate();
			return _workingTimes;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 20)]
	public IOptionalItemSet<IfcWorkTime> ExceptionTimes
	{
		get
		{
			if (_activated)
			{
				return _exceptionTimes;
			}
			Activate();
			return _exceptionTimes;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 21)]
	public IfcWorkCalendarTypeEnum? PredefinedType
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
			SetValue(delegate(IfcWorkCalendarTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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
			foreach (IfcWorkTime workingTime in WorkingTimes)
			{
				yield return workingTime;
			}
			foreach (IfcWorkTime exceptionTime in ExceptionTimes)
			{
				yield return exceptionTime;
			}
		}
	}

	internal IfcWorkCalendar(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_workingTimes = new OptionalItemSet<IfcWorkTime>(this, 0, 7);
		_exceptionTimes = new OptionalItemSet<IfcWorkTime>(this, 0, 8);
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
			_workingTimes.InternalAdd((IfcWorkTime)value.EntityVal);
			break;
		case 7:
			_exceptionTimes.InternalAdd((IfcWorkTime)value.EntityVal);
			break;
		case 8:
			_predefinedType = (IfcWorkCalendarTypeEnum)Enum.Parse(typeof(IfcWorkCalendarTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWorkCalendar other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcWorkCalendarClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcWorkCalendarClause.CorrectPredefinedType)
			{
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcWorkCalendarTypeEnum.USERDEFINED || (PredefinedType == IfcWorkCalendarTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcWorkCalendar>()?.LogError($"Exception thrown evaluating where-clause 'IfcWorkCalendar.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcWorkCalendarClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcWorkCalendar.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
