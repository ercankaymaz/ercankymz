using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.SharedMgmtElements;

[ExpressType("IfcCostSchedule", 695)]
public class IfcCostSchedule : IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IIfcCostSchedule, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcCostSchedule>
{
	private IfcCostScheduleTypeEnum? _predefinedType;

	private IfcLabel? _status;

	private IfcDateTime? _submittedOn;

	private IfcDateTime? _updateDate;

	IfcCostScheduleTypeEnum? IIfcCostSchedule.PredefinedType
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

	IfcLabel? IIfcCostSchedule.Status
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

	IfcDateTime? IIfcCostSchedule.SubmittedOn
	{
		get
		{
			return SubmittedOn;
		}
		set
		{
			SubmittedOn = value;
		}
	}

	IfcDateTime? IIfcCostSchedule.UpdateDate
	{
		get
		{
			return UpdateDate;
		}
		set
		{
			UpdateDate = value;
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

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public IfcDateTime? SubmittedOn
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
			SetValue(delegate(IfcDateTime? v)
			{
				_submittedOn = v;
			}, _submittedOn, value, "SubmittedOn", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
	public IfcDateTime? UpdateDate
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
			SetValue(delegate(IfcDateTime? v)
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
