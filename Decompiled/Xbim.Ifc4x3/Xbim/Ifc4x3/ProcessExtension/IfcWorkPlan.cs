using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.ActorResource;

namespace Xbim.Ifc4x3.ProcessExtension;

[ExpressType("IfcWorkPlan", 187)]
public class IfcWorkPlan : IfcWorkControl, IIfcWorkPlan, IIfcWorkControl, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcWorkPlan>
{
	private IfcWorkPlanTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcWorkPlan), 14)]
	Xbim.Ifc4.Interfaces.IfcWorkPlanTypeEnum? IIfcWorkPlan.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcWorkPlanTypeEnum.ACTUAL => Xbim.Ifc4.Interfaces.IfcWorkPlanTypeEnum.ACTUAL, 
				IfcWorkPlanTypeEnum.BASELINE => Xbim.Ifc4.Interfaces.IfcWorkPlanTypeEnum.BASELINE, 
				IfcWorkPlanTypeEnum.PLANNED => Xbim.Ifc4.Interfaces.IfcWorkPlanTypeEnum.PLANNED, 
				IfcWorkPlanTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcWorkPlanTypeEnum.USERDEFINED, 
				IfcWorkPlanTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcWorkPlanTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcWorkPlanTypeEnum.ACTUAL:
				PredefinedType = IfcWorkPlanTypeEnum.ACTUAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWorkPlanTypeEnum.BASELINE:
				PredefinedType = IfcWorkPlanTypeEnum.BASELINE;
				break;
			case Xbim.Ifc4.Interfaces.IfcWorkPlanTypeEnum.PLANNED:
				PredefinedType = IfcWorkPlanTypeEnum.PLANNED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWorkPlanTypeEnum.USERDEFINED:
				PredefinedType = IfcWorkPlanTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWorkPlanTypeEnum.NOTDEFINED:
				PredefinedType = IfcWorkPlanTypeEnum.NOTDEFINED;
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
	public IfcWorkPlanTypeEnum? PredefinedType
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
			SetValue(delegate(IfcWorkPlanTypeEnum? v)
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

	internal IfcWorkPlan(IModel model, int label, bool activated)
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
			_predefinedType = (IfcWorkPlanTypeEnum)Enum.Parse(typeof(IfcWorkPlanTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWorkPlan other)
	{
		return this == other;
	}
}
