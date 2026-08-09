using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.ProcessExtension;

[ExpressType("IfcTask", 72)]
public class IfcTask : IfcProcess, IInstantiableEntity, IPersistEntity, IPersist, IIfcTask, IIfcProcess, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect, IContainsEntityReferences, IEquatable<IfcTask>, IExpressValidatable
{
	public enum IfcTaskClause
	{
		HasName,
		CorrectPredefinedType
	}

	private IfcLabel? _status;

	private IfcLabel? _workMethod;

	private IfcBoolean _isMilestone;

	private IfcInteger? _priority;

	private IfcTaskTime _taskTime;

	private IfcTaskTypeEnum? _predefinedType;

	IfcLabel? IIfcTask.Status
	{
		get
		{
			return Status;
		}
		set
		{
			Status = value;
		}
	}

	IfcLabel? IIfcTask.WorkMethod
	{
		get
		{
			return WorkMethod;
		}
		set
		{
			WorkMethod = value;
		}
	}

	IfcBoolean IIfcTask.IsMilestone
	{
		get
		{
			return IsMilestone;
		}
		set
		{
			IsMilestone = value;
		}
	}

	IfcInteger? IIfcTask.Priority
	{
		get
		{
			return Priority;
		}
		set
		{
			Priority = value;
		}
	}

	IIfcTaskTime IIfcTask.TaskTime
	{
		get
		{
			return TaskTime;
		}
		set
		{
			TaskTime = value as IfcTaskTime;
		}
	}

	IfcTaskTypeEnum? IIfcTask.PredefinedType
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

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public IfcLabel? Status
	{
		get
		{
			if (_activated)
			{
				return _status;
			}
			Activate();
			return _status;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_status = v;
			}, _status, value, "Status", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 23)]
	public IfcLabel? WorkMethod
	{
		get
		{
			if (_activated)
			{
				return _workMethod;
			}
			Activate();
			return _workMethod;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_workMethod = v;
			}, _workMethod, value, "WorkMethod", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 24)]
	public IfcBoolean IsMilestone
	{
		get
		{
			if (_activated)
			{
				return _isMilestone;
			}
			Activate();
			return _isMilestone;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_isMilestone = v;
			}, _isMilestone, value, "IsMilestone", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
	public IfcInteger? Priority
	{
		get
		{
			if (_activated)
			{
				return _priority;
			}
			Activate();
			return _priority;
		}
		set
		{
			SetValue(delegate(IfcInteger? v)
			{
				_priority = v;
			}, _priority, value, "Priority", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 26)]
	public IfcTaskTime TaskTime
	{
		get
		{
			if (_activated)
			{
				return _taskTime;
			}
			Activate();
			return _taskTime;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTaskTime v)
			{
				_taskTime = v;
			}, _taskTime, value, "TaskTime", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
	public IfcTaskTypeEnum? PredefinedType
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
			SetValue(delegate(IfcTaskTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 13);
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
			if (TaskTime != null)
			{
				yield return TaskTime;
			}
		}
	}

	internal IfcTask(IModel model, int label, bool activated)
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
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_status = value.StringVal;
			break;
		case 8:
			_workMethod = value.StringVal;
			break;
		case 9:
			_isMilestone = value.BooleanVal;
			break;
		case 10:
			_priority = value.IntegerVal;
			break;
		case 11:
			_taskTime = (IfcTaskTime)value.EntityVal;
			break;
		case 12:
			_predefinedType = (IfcTaskTypeEnum)Enum.Parse(typeof(IfcTaskTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTask other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcTaskClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcTaskClause.HasName:
				result = Functions.EXISTS(base.Name);
				break;
			case IfcTaskClause.CorrectPredefinedType:
				result = !Functions.EXISTS(PredefinedType) || PredefinedType != IfcTaskTypeEnum.USERDEFINED || (PredefinedType == IfcTaskTypeEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTask>()?.LogError($"Exception thrown evaluating where-clause 'IfcTask.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcTaskClause.HasName))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTask.HasName",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTaskClause.CorrectPredefinedType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTask.CorrectPredefinedType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
