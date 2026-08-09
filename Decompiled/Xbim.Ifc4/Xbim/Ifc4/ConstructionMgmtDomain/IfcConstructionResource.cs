using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.QuantityResource;

namespace Xbim.Ifc4.ConstructionMgmtDomain;

[ExpressType("IfcConstructionResource", 157)]
public abstract class IfcConstructionResource : IfcResource, IIfcConstructionResource, IIfcResource, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect, IEquatable<IfcConstructionResource>
{
	private IfcResourceTime _usage;

	private readonly OptionalItemSet<IfcAppliedValue> _baseCosts;

	private IfcPhysicalQuantity _baseQuantity;

	IIfcResourceTime IIfcConstructionResource.Usage
	{
		get
		{
			return Usage;
		}
		set
		{
			Usage = value as IfcResourceTime;
		}
	}

	IItemSet<IIfcAppliedValue> IIfcConstructionResource.BaseCosts => new ProxyItemSet<IfcAppliedValue, IIfcAppliedValue>(BaseCosts);

	IIfcPhysicalQuantity IIfcConstructionResource.BaseQuantity
	{
		get
		{
			return BaseQuantity;
		}
		set
		{
			BaseQuantity = value as IfcPhysicalQuantity;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
	public IfcResourceTime Usage
	{
		get
		{
			if (_activated)
			{
				return _usage;
			}
			Activate();
			return _usage;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcResourceTime v)
			{
				_usage = v;
			}, _usage, value, "Usage", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 21)]
	public IOptionalItemSet<IfcAppliedValue> BaseCosts
	{
		get
		{
			if (_activated)
			{
				return _baseCosts;
			}
			Activate();
			return _baseCosts;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 22)]
	public IfcPhysicalQuantity BaseQuantity
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
			SetValue(delegate(IfcPhysicalQuantity v)
			{
				_baseQuantity = v;
			}, _baseQuantity, value, "BaseQuantity", 10);
		}
	}

	internal IfcConstructionResource(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_baseCosts = new OptionalItemSet<IfcAppliedValue>(this, 0, 9);
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
			_usage = (IfcResourceTime)value.EntityVal;
			break;
		case 8:
			_baseCosts.InternalAdd((IfcAppliedValue)value.EntityVal);
			break;
		case 9:
			_baseQuantity = (IfcPhysicalQuantity)value.EntityVal;
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
