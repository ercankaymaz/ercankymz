using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProcessExtension;

[ExpressType("IfcTask", 72)]
public class IfcTask : Xbim.Ifc4x3.Kernel.IfcProcess, IIfcTask, IIfcProcess, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProcessSelect, IIfcProcessSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcTask>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _status;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _workMethod;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean _isMilestone;

	private Xbim.Ifc4x3.MeasureResource.IfcInteger? _priority;

	private IfcTaskTime _taskTime;

	private IfcTaskTypeEnum? _predefinedType;

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
			Status = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
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
			WorkMethod = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
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
			IsMilestone = new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value);
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
			Priority = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcInteger?(new Xbim.Ifc4x3.MeasureResource.IfcInteger(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcInteger?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTask), 12)]
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

	[CrossSchemaAttribute(typeof(IIfcTask), 13)]
	Xbim.Ifc4.Interfaces.IfcTaskTypeEnum? IIfcTask.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcTaskTypeEnum.ADJUSTMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.ATTENDANCE => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.ATTENDANCE, 
				IfcTaskTypeEnum.CALIBRATION => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.CONSTRUCTION => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.CONSTRUCTION, 
				IfcTaskTypeEnum.DEMOLITION => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.DEMOLITION, 
				IfcTaskTypeEnum.DISMANTLE => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.DISMANTLE, 
				IfcTaskTypeEnum.DISPOSAL => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.DISPOSAL, 
				IfcTaskTypeEnum.EMERGENCY => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.INSPECTION => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.INSTALLATION => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.INSTALLATION, 
				IfcTaskTypeEnum.LOGISTIC => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.LOGISTIC, 
				IfcTaskTypeEnum.MAINTENANCE => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.MAINTENANCE, 
				IfcTaskTypeEnum.MOVE => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.MOVE, 
				IfcTaskTypeEnum.OPERATION => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.OPERATION, 
				IfcTaskTypeEnum.REMOVAL => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.REMOVAL, 
				IfcTaskTypeEnum.RENOVATION => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.RENOVATION, 
				IfcTaskTypeEnum.SAFETY => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.SHUTDOWN => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.STARTUP => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.TESTING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.TROUBLESHOOTING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTaskTypeEnum>(), 
				IfcTaskTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.USERDEFINED, 
				IfcTaskTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.ATTENDANCE:
				PredefinedType = IfcTaskTypeEnum.ATTENDANCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.CONSTRUCTION:
				PredefinedType = IfcTaskTypeEnum.CONSTRUCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.DEMOLITION:
				PredefinedType = IfcTaskTypeEnum.DEMOLITION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.DISMANTLE:
				PredefinedType = IfcTaskTypeEnum.DISMANTLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.DISPOSAL:
				PredefinedType = IfcTaskTypeEnum.DISPOSAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.INSTALLATION:
				PredefinedType = IfcTaskTypeEnum.INSTALLATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.LOGISTIC:
				PredefinedType = IfcTaskTypeEnum.LOGISTIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.MAINTENANCE:
				PredefinedType = IfcTaskTypeEnum.MAINTENANCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.MOVE:
				PredefinedType = IfcTaskTypeEnum.MOVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.OPERATION:
				PredefinedType = IfcTaskTypeEnum.OPERATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.REMOVAL:
				PredefinedType = IfcTaskTypeEnum.REMOVAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.RENOVATION:
				PredefinedType = IfcTaskTypeEnum.RENOVATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.USERDEFINED:
				PredefinedType = IfcTaskTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTaskTypeEnum.NOTDEFINED:
				PredefinedType = IfcTaskTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Status
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_status = v;
			}, _status, value, "Status", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 23)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? WorkMethod
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_workMethod = v;
			}, _workMethod, value, "WorkMethod", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 24)]
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean IsMilestone
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean v)
			{
				_isMilestone = v;
			}, _isMilestone, value, "IsMilestone", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger? Priority
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcInteger? v)
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
}
