using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.QuantityResource;

namespace Xbim.Ifc4x3.SharedMgmtElements;

[ExpressType("IfcCostItem", 694)]
public class IfcCostItem : Xbim.Ifc4x3.Kernel.IfcControl, IIfcCostItem, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcCostItem>
{
	private IfcCostItemTypeEnum? _predefinedType;

	private readonly OptionalItemSet<IfcCostValue> _costValues;

	private readonly OptionalItemSet<IfcPhysicalQuantity> _costQuantities;

	[CrossSchemaAttribute(typeof(IIfcCostItem), 7)]
	Xbim.Ifc4.Interfaces.IfcCostItemTypeEnum? IIfcCostItem.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCostItemTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCostItemTypeEnum.USERDEFINED, 
				IfcCostItemTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCostItemTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCostItemTypeEnum.USERDEFINED:
				PredefinedType = IfcCostItemTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCostItemTypeEnum.NOTDEFINED:
				PredefinedType = IfcCostItemTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCostItem), 8)]
	IItemSet<IIfcCostValue> IIfcCostItem.CostValues => new ProxyItemSet<IfcCostValue, IIfcCostValue>(CostValues);

	[CrossSchemaAttribute(typeof(IIfcCostItem), 9)]
	IItemSet<IIfcPhysicalQuantity> IIfcCostItem.CostQuantities => new ProxyItemSet<IfcPhysicalQuantity, IIfcPhysicalQuantity>(CostQuantities);

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcCostItemTypeEnum? PredefinedType
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
			SetValue(delegate(IfcCostItemTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 20)]
	public IOptionalItemSet<IfcCostValue> CostValues
	{
		get
		{
			if (_activated)
			{
				return _costValues;
			}
			Activate();
			return _costValues;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 21)]
	public IOptionalItemSet<IfcPhysicalQuantity> CostQuantities
	{
		get
		{
			if (_activated)
			{
				return _costQuantities;
			}
			Activate();
			return _costQuantities;
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
			foreach (IfcCostValue costValue in CostValues)
			{
				yield return costValue;
			}
			foreach (IfcPhysicalQuantity costQuantity in CostQuantities)
			{
				yield return costQuantity;
			}
		}
	}

	internal IfcCostItem(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_costValues = new OptionalItemSet<IfcCostValue>(this, 0, 8);
		_costQuantities = new OptionalItemSet<IfcPhysicalQuantity>(this, 0, 9);
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
			_predefinedType = (IfcCostItemTypeEnum)Enum.Parse(typeof(IfcCostItemTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 7:
			_costValues.InternalAdd((IfcCostValue)value.EntityVal);
			break;
		case 8:
			_costQuantities.InternalAdd((IfcPhysicalQuantity)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCostItem other)
	{
		return this == other;
	}
}
