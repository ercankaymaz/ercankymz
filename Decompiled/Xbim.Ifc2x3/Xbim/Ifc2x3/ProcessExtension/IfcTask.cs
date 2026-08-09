using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProcessExtension;

[ExpressType("IfcTask", 72)]
public class IfcTask : Xbim.Ifc2x3.Kernel.IfcProcess, IIfcTask, IIfcProcess, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcTask>, IExpressValidatable
{
	public enum IfcTaskClause
	{
		WR1,
		WR2,
		WR3
	}

	private IIfcTaskTime _taskTime;

	private IfcTaskTypeEnum? _predefinedType;

	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier _taskId;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _status;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _workMethod;

	private bool _isMilestone;

	private long? _priority;

	[CrossSchemaAttribute(typeof(IIfcTask), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcTask.Status
	{
		get
		{
			if (!Status.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Status.Value);
		}
		set
		{
			Status = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTask), 9)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcTask.WorkMethod
	{
		get
		{
			if (!WorkMethod.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(WorkMethod.Value);
		}
		set
		{
			WorkMethod = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTask), 10)]
	Xbim.Ifc4.MeasureResource.IfcBoolean IIfcTask.IsMilestone
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(IsMilestone);
		}
		set
		{
			IsMilestone = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTask), 11)]
	Xbim.Ifc4.MeasureResource.IfcInteger? IIfcTask.Priority
	{
		get
		{
			if (!Priority.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcInteger(Priority.Value);
		}
		set
		{
			Priority = value;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTask), 12)]
	IIfcTaskTime IIfcTask.TaskTime
	{
		get
		{
			return _taskTime;
		}
		set
		{
			SetValue(delegate(IIfcTaskTime v)
			{
				_taskTime = v;
			}, _taskTime, value, "TaskTime", -12);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTask), 13)]
	IfcTaskTypeEnum? IIfcTask.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcTaskTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -13);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier TaskId
	{
		get
		{
			if (_activated)
			{
				return _taskId;
			}
			Activate();
			return _taskId;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier v)
			{
				_taskId = v;
			}, _taskId, value, "TaskId", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Status
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_status = v;
			}, _status, value, "Status", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? WorkMethod
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_workMethod = v;
			}, _workMethod, value, "WorkMethod", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public bool IsMilestone
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
			SetValue(delegate(bool v)
			{
				_isMilestone = v;
			}, _isMilestone, value, "IsMilestone", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
	public long? Priority
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
			SetValue(delegate(long? v)
			{
				_priority = v;
			}, _priority, value, "Priority", 10);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_taskId = value.StringVal;
			break;
		case 6:
			_status = value.StringVal;
			break;
		case 7:
			_workMethod = value.StringVal;
			break;
		case 8:
			_isMilestone = value.BooleanVal;
			break;
		case 9:
			_priority = value.IntegerVal;
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
			case IfcTaskClause.WR1:
				result = Functions.SIZEOF(base.Decomposes.Where((Xbim.Ifc2x3.Kernel.IfcRelDecomposes temp) => !Functions.TYPEOF(temp).Contains("IFC2X3.IFCRELNESTS"))) == 0;
				break;
			case IfcTaskClause.WR2:
				result = Functions.SIZEOF(base.IsDecomposedBy.Where((Xbim.Ifc2x3.Kernel.IfcRelDecomposes temp) => !Functions.TYPEOF(temp).Contains("IFC2X3.IFCRELNESTS"))) == 0;
				break;
			case IfcTaskClause.WR3:
				result = Functions.EXISTS(base.Name);
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
		if (!ValidateClause(IfcTaskClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTask.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTaskClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTask.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcTaskClause.WR3))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTask.WR3",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
