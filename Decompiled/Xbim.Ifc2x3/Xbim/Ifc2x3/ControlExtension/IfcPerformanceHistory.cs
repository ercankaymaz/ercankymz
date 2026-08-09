using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ControlExtension;

[ExpressType("IfcPerformanceHistory", 710)]
public class IfcPerformanceHistory : Xbim.Ifc2x3.Kernel.IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcPerformanceHistory>, IIfcPerformanceHistory, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	private Xbim.Ifc2x3.MeasureResource.IfcLabel _lifeCyclePhase;

	private IfcPerformanceHistoryTypeEnum? _predefinedType;

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel LifeCyclePhase
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_lifeCyclePhase = v;
			}, _lifeCyclePhase, value, "LifeCyclePhase", 6);
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
			LifeCyclePhase = new Xbim.Ifc2x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPerformanceHistory), 8)]
	IfcPerformanceHistoryTypeEnum? IIfcPerformanceHistory.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcPerformanceHistoryTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -8);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_lifeCyclePhase = value.StringVal;
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
