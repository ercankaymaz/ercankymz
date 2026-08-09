using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.CostResource;

[ExpressType("IfcAppliedValueRelationship", 691)]
public class IfcAppliedValueRelationship : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAppliedValueRelationship>
{
	private IfcAppliedValue _componentOfTotal;

	private readonly ItemSet<IfcAppliedValue> _components;

	private IfcArithmeticOperatorEnum _arithmeticOperator;

	private IfcLabel? _name;

	private IfcText? _description;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcAppliedValue ComponentOfTotal
	{
		get
		{
			if (_activated)
			{
				return _componentOfTotal;
			}
			Activate();
			return _componentOfTotal;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAppliedValue v)
			{
				_componentOfTotal = v;
			}, _componentOfTotal, value, "ComponentOfTotal", 1);
		}
	}

	[IndexedProperty]
	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcAppliedValue> Components
	{
		get
		{
			if (_activated)
			{
				return _components;
			}
			Activate();
			return _components;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 3)]
	public IfcArithmeticOperatorEnum ArithmeticOperator
	{
		get
		{
			if (_activated)
			{
				return _arithmeticOperator;
			}
			Activate();
			return _arithmeticOperator;
		}
		set
		{
			SetValue(delegate(IfcArithmeticOperatorEnum v)
			{
				_arithmeticOperator = v;
			}, _arithmeticOperator, value, "ArithmeticOperator", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ComponentOfTotal != null)
			{
				yield return ComponentOfTotal;
			}
			foreach (IfcAppliedValue component in Components)
			{
				yield return component;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ComponentOfTotal != null)
			{
				yield return ComponentOfTotal;
			}
			foreach (IfcAppliedValue component in Components)
			{
				yield return component;
			}
		}
	}

	internal IfcAppliedValueRelationship(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_components = new ItemSet<IfcAppliedValue>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_componentOfTotal = (IfcAppliedValue)value.EntityVal;
			break;
		case 1:
			_components.InternalAdd((IfcAppliedValue)value.EntityVal);
			break;
		case 2:
			_arithmeticOperator = (IfcArithmeticOperatorEnum)Enum.Parse(typeof(IfcArithmeticOperatorEnum), value.EnumVal, ignoreCase: true);
			break;
		case 3:
			_name = value.StringVal;
			break;
		case 4:
			_description = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAppliedValueRelationship other)
	{
		return this == other;
	}
}
