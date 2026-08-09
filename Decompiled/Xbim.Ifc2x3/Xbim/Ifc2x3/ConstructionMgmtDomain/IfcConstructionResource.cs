using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.QuantityResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ConstructionMgmtDomain;

[ExpressType("IfcConstructionResource", 157)]
public abstract class IfcConstructionResource : Xbim.Ifc2x3.Kernel.IfcResource, IEquatable<IfcConstructionResource>, IIfcConstructionResource, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect
{
	private IfcIdentifier? _resourceIdentifier;

	private IfcLabel? _resourceGroup;

	private IfcResourceConsumptionEnum? _resourceConsumption;

	private IfcMeasureWithUnit _baseQuantity;

	private IIfcResourceTime _usage;

	private IItemSet<IIfcAppliedValue> _baseCosts;

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcIdentifier? ResourceIdentifier
	{
		get
		{
			if (_activated)
			{
				return _resourceIdentifier;
			}
			Activate();
			return _resourceIdentifier;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_resourceIdentifier = v;
			}, _resourceIdentifier, value, "ResourceIdentifier", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcLabel? ResourceGroup
	{
		get
		{
			if (_activated)
			{
				return _resourceGroup;
			}
			Activate();
			return _resourceGroup;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_resourceGroup = v;
			}, _resourceGroup, value, "ResourceGroup", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 14)]
	public IfcResourceConsumptionEnum? ResourceConsumption
	{
		get
		{
			if (_activated)
			{
				return _resourceConsumption;
			}
			Activate();
			return _resourceConsumption;
		}
		set
		{
			SetValue(delegate(IfcResourceConsumptionEnum? v)
			{
				_resourceConsumption = v;
			}, _resourceConsumption, value, "ResourceConsumption", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 15)]
	public IfcMeasureWithUnit BaseQuantity
	{
		get
		{
			if (_activated)
			{
				return _baseQuantity;
			}
			Activate();
			return _baseQuantity;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMeasureWithUnit v)
			{
				_baseQuantity = v;
			}, _baseQuantity, value, "BaseQuantity", 9);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConstructionResource), 8)]
	IIfcResourceTime IIfcConstructionResource.Usage
	{
		get
		{
			return _usage;
		}
		set
		{
			SetValue(delegate(IIfcResourceTime v)
			{
				_usage = v;
			}, _usage, value, "Usage", -8);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcConstructionResource), 9)]
	IItemSet<IIfcAppliedValue> IIfcConstructionResource.BaseCosts => _baseCosts ?? (_baseCosts = new ItemSet<IIfcAppliedValue>(this, 0, -9));

	[CrossSchemaAttribute(typeof(IIfcConstructionResource), 10)]
	IIfcPhysicalQuantity IIfcConstructionResource.BaseQuantity
	{
		get
		{
			return BaseQuantity.ToPhysicalSimpleQuantity();
		}
		set
		{
			IfcPhysicalSimpleQuantity val = value as IfcPhysicalSimpleQuantity;
			if (val == null)
			{
				BaseQuantity = null;
				return;
			}
			BaseQuantity = base.Model.Instances.New(delegate(IfcMeasureWithUnit m)
			{
				m.UnitComponent = val.Unit;
				IfcQuantityLength ifcQuantityLength = val as IfcQuantityLength;
				if (ifcQuantityLength != null)
				{
					m.ValueComponent = ifcQuantityLength.LengthValue;
				}
				IfcQuantityArea ifcQuantityArea = val as IfcQuantityArea;
				if (ifcQuantityArea != null)
				{
					m.ValueComponent = ifcQuantityArea.AreaValue;
				}
				IfcQuantityVolume ifcQuantityVolume = val as IfcQuantityVolume;
				if (ifcQuantityVolume != null)
				{
					m.ValueComponent = ifcQuantityVolume.VolumeValue;
				}
				IfcQuantityCount ifcQuantityCount = val as IfcQuantityCount;
				if (ifcQuantityCount != null)
				{
					m.ValueComponent = ifcQuantityCount.CountValue;
				}
				IfcQuantityWeight ifcQuantityWeight = val as IfcQuantityWeight;
				if (ifcQuantityWeight != null)
				{
					m.ValueComponent = ifcQuantityWeight.WeightValue;
				}
				IfcQuantityTime ifcQuantityTime = val as IfcQuantityTime;
				if (ifcQuantityTime != null)
				{
					m.ValueComponent = ifcQuantityTime.TimeValue;
				}
			});
		}
	}

	internal IfcConstructionResource(IModel model, int label, bool activated)
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
			_resourceIdentifier = value.StringVal;
			break;
		case 6:
			_resourceGroup = value.StringVal;
			break;
		case 7:
			_resourceConsumption = (IfcResourceConsumptionEnum)Enum.Parse(typeof(IfcResourceConsumptionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_baseQuantity = (IfcMeasureWithUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstructionResource other)
	{
		return this == other;
	}
}
