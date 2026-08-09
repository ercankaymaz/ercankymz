using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.QuantityResource;

namespace Xbim.Ifc4.ConstructionMgmtDomain;

[ExpressType("IfcConstructionResourceType", 1137)]
public abstract class IfcConstructionResourceType : IfcTypeResource, IIfcConstructionResourceType, IIfcTypeResource, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect, IEquatable<IfcConstructionResourceType>
{
	private readonly OptionalItemSet<IfcAppliedValue> _baseCosts;

	private IfcPhysicalQuantity _baseQuantity;

	IItemSet<IIfcAppliedValue> IIfcConstructionResourceType.BaseCosts => new ProxyItemSet<IfcAppliedValue, IIfcAppliedValue>(BaseCosts);

	IIfcPhysicalQuantity IIfcConstructionResourceType.BaseQuantity
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

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 19)]
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

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
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
			}, _baseQuantity, value, "BaseQuantity", 11);
		}
	}

	internal IfcConstructionResourceType(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_baseCosts = new OptionalItemSet<IfcAppliedValue>(this, 0, 10);
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_baseCosts.InternalAdd((IfcAppliedValue)value.EntityVal);
			break;
		case 10:
			_baseQuantity = (IfcPhysicalQuantity)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcConstructionResourceType other)
	{
		return this == other;
	}
}
