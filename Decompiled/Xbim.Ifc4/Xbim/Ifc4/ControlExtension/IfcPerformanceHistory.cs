using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ControlExtension;

[ExpressType("IfcPerformanceHistory", 710)]
public class IfcPerformanceHistory : IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IIfcPerformanceHistory, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcPerformanceHistory>
{
	private IfcLabel _lifeCyclePhase;

	private IfcPerformanceHistoryTypeEnum? _predefinedType;

	IfcLabel IIfcPerformanceHistory.LifeCyclePhase
	{
		get
		{
			return LifeCyclePhase;
		}
		set
		{
			LifeCyclePhase = value;
		}
	}

	IfcPerformanceHistoryTypeEnum? IIfcPerformanceHistory.PredefinedType
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

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public IfcLabel LifeCyclePhase
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
			SetValue(delegate(IfcLabel v)
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
