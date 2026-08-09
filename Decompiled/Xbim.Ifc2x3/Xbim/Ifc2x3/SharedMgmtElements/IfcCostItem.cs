using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.SharedMgmtElements;

[ExpressType("IfcCostItem", 694)]
public class IfcCostItem : Xbim.Ifc2x3.Kernel.IfcControl, IIfcCostItem, IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcCostItem>
{
	private IfcCostItemTypeEnum? _predefinedType;

	private IItemSet<IIfcCostValue> _costValues;

	private IItemSet<IIfcPhysicalQuantity> _costQuantities;

	[CrossSchemaAttribute(typeof(IIfcCostItem), 7)]
	IfcCostItemTypeEnum? IIfcCostItem.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcCostItemTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -7);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcCostItem), 8)]
	IItemSet<IIfcCostValue> IIfcCostItem.CostValues => _costValues ?? (_costValues = new ItemSet<IIfcCostValue>(this, 0, -8));

	[CrossSchemaAttribute(typeof(IIfcCostItem), 9)]
	IItemSet<IIfcPhysicalQuantity> IIfcCostItem.CostQuantities => _costQuantities ?? (_costQuantities = new ItemSet<IIfcPhysicalQuantity>(this, 0, -9));

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

	internal IfcCostItem(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 4u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcCostItem other)
	{
		return this == other;
	}
}
