using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ControlExtension;

[ExpressType("IfcPerformanceHistory", 710)]
public class IfcPerformanceHistory : Xbim.Ifc4x3.Kernel.IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcPerformanceHistory>, IIfcPerformanceHistory, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel _lifeCyclePhase;

	private IfcPerformanceHistoryTypeEnum? _predefinedType;

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel LifeCyclePhase
	{
		get
		{
			if (_activated)
			{
				return _lifeCyclePhase;
			}
			Activate();
			return _lifeCyclePhase;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel v)
			{
				_lifeCyclePhase = v;
			}, _lifeCyclePhase, value, "LifeCyclePhase", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 20)]
	public IfcPerformanceHistoryTypeEnum? PredefinedType
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
			SetValue(delegate(IfcPerformanceHistoryTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 8);
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

	[CrossSchemaAttribute(typeof(IIfcPerformanceHistory), 7)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcPerformanceHistory.LifeCyclePhase
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(LifeCyclePhase);
		}
		set
		{
			LifeCyclePhase = new Xbim.Ifc4x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPerformanceHistory), 8)]
	Xbim.Ifc4.Interfaces.IfcPerformanceHistoryTypeEnum? IIfcPerformanceHistory.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcPerformanceHistoryTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcPerformanceHistoryTypeEnum.USERDEFINED, 
				IfcPerformanceHistoryTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcPerformanceHistoryTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPerformanceHistoryTypeEnum.USERDEFINED:
				PredefinedType = IfcPerformanceHistoryTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPerformanceHistoryTypeEnum.NOTDEFINED:
				PredefinedType = IfcPerformanceHistoryTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcPerformanceHistory(IModel model, int label, bool activated)
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
			_lifeCyclePhase = value.StringVal;
			break;
		case 7:
			_predefinedType = (IfcPerformanceHistoryTypeEnum)Enum.Parse(typeof(IfcPerformanceHistoryTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPerformanceHistory other)
	{
		return this == other;
	}
}
