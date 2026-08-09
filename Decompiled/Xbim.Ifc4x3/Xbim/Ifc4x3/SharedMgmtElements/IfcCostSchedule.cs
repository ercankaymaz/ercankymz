using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.DateTimeResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.SharedMgmtElements;

[ExpressType("IfcCostSchedule", 695)]
public class IfcCostSchedule : Xbim.Ifc4x3.Kernel.IfcControl, IIfcCostSchedule, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcCostSchedule>
{
	private IfcCostScheduleTypeEnum? _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _status;

	private Xbim.Ifc4x3.DateTimeResource.IfcDateTime? _submittedOn;

	private Xbim.Ifc4x3.DateTimeResource.IfcDateTime? _updateDate;

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
				IfcCostScheduleTypeEnum.PRICEDBILLOFQUANTITIES => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.PRICEDBILLOFQUANTITIES, 
				IfcCostScheduleTypeEnum.SCHEDULEOFRATES => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.SCHEDULEOFRATES, 
				IfcCostScheduleTypeEnum.TENDER => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.TENDER, 
				IfcCostScheduleTypeEnum.UNPRICEDBILLOFQUANTITIES => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.UNPRICEDBILLOFQUANTITIES, 
				IfcCostScheduleTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.USERDEFINED, 
				IfcCostScheduleTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCostScheduleTypeEnum.NOTDEFINED, 
				null => null, 
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
				PredefinedType = null;
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
			Status = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCostSchedule), 9)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcCostSchedule.SubmittedOn
	{
		get
		{
			if (!SubmittedOn.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(SubmittedOn.Value);
		}
		set
		{
			SubmittedOn = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDateTime?(new Xbim.Ifc4x3.DateTimeResource.IfcDateTime(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDateTime?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCostSchedule), 10)]
	Xbim.Ifc4.DateTimeResource.IfcDateTime? IIfcCostSchedule.UpdateDate
	{
		get
		{
			if (!UpdateDate.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.DateTimeResource.IfcDateTime(UpdateDate.Value);
		}
		set
		{
			UpdateDate = (value.HasValue ? new Xbim.Ifc4x3.DateTimeResource.IfcDateTime?(new Xbim.Ifc4x3.DateTimeResource.IfcDateTime(value.Value)) : ((Xbim.Ifc4x3.DateTimeResource.IfcDateTime?)null));
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcCostScheduleTypeEnum? PredefinedType
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
			SetValue(delegate(IfcCostScheduleTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDateTime? SubmittedOn
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
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDateTime? v)
			{
				_submittedOn = v;
			}, _submittedOn, value, "SubmittedOn", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public Xbim.Ifc4x3.DateTimeResource.IfcDateTime? UpdateDate
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
			SetValue(delegate(Xbim.Ifc4x3.DateTimeResource.IfcDateTime? v)
			{
				_updateDate = v;
			}, _updateDate, value, "UpdateDate", 10);
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

	internal IfcCostSchedule(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCostScheduleTypeEnum)Enum.Parse(typeof(IfcCostScheduleTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 7:
			_status = value.StringVal;
			break;
		case 8:
			_submittedOn = value.StringVal;
			break;
		case 9:
			_updateDate = value.StringVal;
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
