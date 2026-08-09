using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.ActorResource;

namespace Xbim.Ifc4x3.ProcessExtension;

[ExpressType("IfcWorkSchedule", 186)]
public class IfcWorkSchedule : IfcWorkControl, IIfcWorkSchedule, IIfcWorkControl, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcWorkSchedule>
{
	private IfcWorkScheduleTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcWorkSchedule), 14)]
	Xbim.Ifc4.Interfaces.IfcWorkScheduleTypeEnum? IIfcWorkSchedule.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcWorkScheduleTypeEnum.ACTUAL => Xbim.Ifc4.Interfaces.IfcWorkScheduleTypeEnum.ACTUAL, 
				IfcWorkScheduleTypeEnum.BASELINE => Xbim.Ifc4.Interfaces.IfcWorkScheduleTypeEnum.BASELINE, 
				IfcWorkScheduleTypeEnum.PLANNED => Xbim.Ifc4.Interfaces.IfcWorkScheduleTypeEnum.PLANNED, 
				IfcWorkScheduleTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcWorkScheduleTypeEnum.USERDEFINED, 
				IfcWorkScheduleTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcWorkScheduleTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcWorkScheduleTypeEnum.ACTUAL:
				PredefinedType = IfcWorkScheduleTypeEnum.ACTUAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWorkScheduleTypeEnum.BASELINE:
				PredefinedType = IfcWorkScheduleTypeEnum.BASELINE;
				break;
			case Xbim.Ifc4.Interfaces.IfcWorkScheduleTypeEnum.PLANNED:
				PredefinedType = IfcWorkScheduleTypeEnum.PLANNED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWorkScheduleTypeEnum.USERDEFINED:
				PredefinedType = IfcWorkScheduleTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWorkScheduleTypeEnum.NOTDEFINED:
				PredefinedType = IfcWorkScheduleTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 26)]
	public IfcWorkScheduleTypeEnum? PredefinedType
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
			SetValue(delegate(IfcWorkScheduleTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 14);
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
			foreach (IfcPerson creator in base.Creators)
			{
				yield return creator;
			}
		}
	}

	internal IfcWorkSchedule(IModel model, int label, bool activated)
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
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 13:
			_predefinedType = (IfcWorkScheduleTypeEnum)Enum.Parse(typeof(IfcWorkScheduleTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWorkSchedule other)
	{
		return this == other;
	}
}
