using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.SharedMgmtElements;

[ExpressType("IfcCostSchedule", 695)]
public class IfcCostSchedule : Xbim.Ifc2x3.Kernel.IfcControl, IIfcCostSchedule, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcCostSchedule>
{
	private IfcActorSelect _submittedBy;

	private IfcActorSelect _preparedBy;

	private IfcDateTimeSelect _submittedOn;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _status;

	private readonly OptionalItemSet<IfcActorSelect> _targetUsers;

	private IfcDateTimeSelect _updateDate;

	private Xbim.Ifc2x3.MeasureResource.IfcIdentifier _iD;

	private IfcCostScheduleTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcCostSchedule), 7)]
	Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum? IIfcCostSchedule.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCostScheduleTypeEnum.BUDGET => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.BUDGET, 
				IfcCostScheduleTypeEnum.COSTPLAN => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.COSTPLAN, 
				IfcCostScheduleTypeEnum.ESTIMATE => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.ESTIMATE, 
				IfcCostScheduleTypeEnum.TENDER => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.TENDER, 
				IfcCostScheduleTypeEnum.PRICEDBILLOFQUANTITIES => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.PRICEDBILLOFQUANTITIES, 
				IfcCostScheduleTypeEnum.UNPRICEDBILLOFQUANTITIES => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.UNPRICEDBILLOFQUANTITIES, 
				IfcCostScheduleTypeEnum.SCHEDULEOFRATES => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.SCHEDULEOFRATES, 
				IfcCostScheduleTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.USERDEFINED, 
				IfcCostScheduleTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.BUDGET:
				PredefinedType = IfcCostScheduleTypeEnum.BUDGET;
				break;
			case Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.COSTPLAN:
				PredefinedType = IfcCostScheduleTypeEnum.COSTPLAN;
				break;
			case Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.ESTIMATE:
				PredefinedType = IfcCostScheduleTypeEnum.ESTIMATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.TENDER:
				PredefinedType = IfcCostScheduleTypeEnum.TENDER;
				break;
			case Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.PRICEDBILLOFQUANTITIES:
				PredefinedType = IfcCostScheduleTypeEnum.PRICEDBILLOFQUANTITIES;
				break;
			case Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.UNPRICEDBILLOFQUANTITIES:
				PredefinedType = IfcCostScheduleTypeEnum.UNPRICEDBILLOFQUANTITIES;
				break;
			case Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.SCHEDULEOFRATES:
				PredefinedType = IfcCostScheduleTypeEnum.SCHEDULEOFRATES;
				break;
			case Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.USERDEFINED:
				PredefinedType = IfcCostScheduleTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.NOTDEFINED:
				PredefinedType = IfcCostScheduleTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = IfcCostScheduleTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCostSchedule), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcCostSchedule.Status
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

	[CrossSchemaAttribute(typeof(IIfcCostSchedule), 9)]
	IfcDateTime? IIfcCostSchedule.SubmittedOn
	{
		get
		{
			return (SubmittedOn != null) ? new IfcDateTime(SubmittedOn.ToISODateTimeString()) : ((IfcDateTime)null);
		}
		set
		{
			if (!value.HasValue)
			{
				SubmittedOn = null;
				return;
			}
			DateTime d = value.Value;
			SubmittedOn = base.Model.Instances.New(delegate(IfcDateAndTime dt)
			{
				dt.DateComponent = base.Model.Instances.New(delegate(IfcCalendarDate date)
				{
					date.YearComponent = d.Year;
					date.MonthComponent = d.Month;
					date.DayComponent = d.Day;
				});
				dt.TimeComponent = base.Model.Instances.New(delegate(IfcLocalTime t)
				{
					t.HourComponent = d.Hour;
					t.MinuteComponent = d.Minute;
					t.SecondComponent = d.Second;
				});
			});
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCostSchedule), 10)]
	IfcDateTime? IIfcCostSchedule.UpdateDate
	{
		get
		{
			return (UpdateDate != null) ? new IfcDateTime(UpdateDate.ToISODateTimeString()) : ((IfcDateTime)null);
		}
		set
		{
			if (!value.HasValue)
			{
				UpdateDate = null;
				return;
			}
			DateTime d = value.Value;
			UpdateDate = base.Model.Instances.New(delegate(IfcDateAndTime dt)
			{
				dt.DateComponent = base.Model.Instances.New(delegate(IfcCalendarDate date)
				{
					date.YearComponent = d.Year;
					date.MonthComponent = d.Month;
					date.DayComponent = d.Day;
				});
				dt.TimeComponent = base.Model.Instances.New(delegate(IfcLocalTime t)
				{
					t.HourComponent = d.Hour;
					t.MinuteComponent = d.Minute;
					t.SecondComponent = d.Second;
				});
			});
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public IfcActorSelect SubmittedBy
	{
		get
		{
			if (_activated)
			{
				return _submittedBy;
			}
			Activate();
			return _submittedBy;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_submittedBy = v;
			}, _submittedBy, value, "SubmittedBy", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
	public IfcActorSelect PreparedBy
	{
		get
		{
			if (_activated)
			{
				return _preparedBy;
			}
			Activate();
			return _preparedBy;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcActorSelect v)
			{
				_preparedBy = v;
			}, _preparedBy, value, "PreparedBy", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
	public IfcDateTimeSelect SubmittedOn
	{
		get
		{
			if (_activated)
			{
				return _submittedOn;
			}
			Activate();
			return _submittedOn;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateTimeSelect v)
			{
				_submittedOn = v;
			}, _submittedOn, value, "SubmittedOn", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
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
			}, _status, value, "Status", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 16)]
	public IOptionalItemSet<IfcActorSelect> TargetUsers
	{
		get
		{
			if (_activated)
			{
				return _targetUsers;
			}
			Activate();
			return _targetUsers;
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 17)]
	public IfcDateTimeSelect UpdateDate
	{
		get
		{
			if (_activated)
			{
				return _updateDate;
			}
			Activate();
			return _updateDate;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDateTimeSelect v)
			{
				_updateDate = v;
			}, _updateDate, value, "UpdateDate", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 18)]
	public Xbim.Ifc2x3.MeasureResource.IfcIdentifier ID
	{
		get
		{
			if (_activated)
			{
				return _iD;
			}
			Activate();
			return _iD;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcIdentifier v)
			{
				_iD = v;
			}, _iD, value, "ID", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcCostScheduleTypeEnum PredefinedType
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
			SetValue(delegate(IfcCostScheduleTypeEnum v)
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
			if (SubmittedBy != null)
			{
				yield return SubmittedBy;
			}
			if (PreparedBy != null)
			{
				yield return PreparedBy;
			}
			if (SubmittedOn != null)
			{
				yield return SubmittedOn;
			}
			foreach (IfcActorSelect targetUser in TargetUsers)
			{
				yield return targetUser;
			}
			if (UpdateDate != null)
			{
				yield return UpdateDate;
			}
		}
	}

	internal IfcCostSchedule(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_targetUsers = new OptionalItemSet<IfcActorSelect>(this, 0, 10);
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
			_submittedBy = (IfcActorSelect)value.EntityVal;
			break;
		case 6:
			_preparedBy = (IfcActorSelect)value.EntityVal;
			break;
		case 7:
			_submittedOn = (IfcDateTimeSelect)value.EntityVal;
			break;
		case 8:
			_status = value.StringVal;
			break;
		case 9:
			_targetUsers.InternalAdd((IfcActorSelect)value.EntityVal);
			break;
		case 10:
			_updateDate = (IfcDateTimeSelect)value.EntityVal;
			break;
		case 11:
			_iD = value.StringVal;
			break;
		case 12:
			_predefinedType = (IfcCostScheduleTypeEnum)Enum.Parse(typeof(IfcCostScheduleTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCostSchedule other)
	{
		return this == other;
	}
}
