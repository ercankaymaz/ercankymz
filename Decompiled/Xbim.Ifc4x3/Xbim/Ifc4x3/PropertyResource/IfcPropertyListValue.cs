using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PropertyResource;

[ExpressType("IfcPropertyListValue", 489)]
public class IfcPropertyListValue : IfcSimpleProperty, IIfcPropertyListValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPropertyListValue>
{
	private IItemSet<IIfcValue> _listValuesIfc4;

	private readonly OptionalItemSet<IfcValue> _listValues;

	private IfcUnit _unit;

	[CrossSchemaAttribute(typeof(IIfcPropertyListValue), 3)]
	IItemSet<IIfcValue> IIfcPropertyListValue.ListValues => _listValuesIfc4 ?? (_listValuesIfc4 = new ExtendedItemSet<IfcValue, IIfcValue>(ListValues, new ItemSet<IIfcValue>(this, 0, -3), (IfcValue v) => v.ToIfc4(), (IIfcValue v) => v.ToIfc3()));

	[CrossSchemaAttribute(typeof(IIfcPropertyListValue), 4)]
	IIfcUnit IIfcPropertyListValue.Unit
	{
		get
		{
			if (Unit == null)
			{
				return null;
			}
			IfcDerivedUnit ifcDerivedUnit = Unit as IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			IfcMonetaryUnit ifcMonetaryUnit = Unit as IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				return ifcMonetaryUnit;
			}
			IfcNamedUnit ifcNamedUnit = Unit as IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				return ifcNamedUnit;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				Unit = null;
				return;
			}
			IfcDerivedUnit ifcDerivedUnit = value as IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				Unit = ifcDerivedUnit;
				return;
			}
			IfcMonetaryUnit ifcMonetaryUnit = value as IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				Unit = ifcMonetaryUnit;
				return;
			}
			IfcNamedUnit ifcNamedUnit = value as IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				Unit = ifcNamedUnit;
			}
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 10)]
	public IOptionalItemSet<IfcValue> ListValues
	{
		get
		{
			if (_activated)
			{
				return _listValues;
			}
			Activate();
			return _listValues;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 11)]
	public IfcUnit Unit
	{
		get
		{
			if (_activated)
			{
				return _unit;
			}
			Activate();
			return _unit;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcUnit v)
			{
				_unit = v;
			}, _unit, value, "Unit", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Unit != null)
			{
				yield return Unit;
			}
		}
	}

	internal IfcPropertyListValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_listValues = new OptionalItemSet<IfcValue>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_listValues.InternalAdd((IfcValue)value.EntityVal);
			break;
		case 3:
			_unit = (IfcUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyListValue other)
	{
		return this == other;
	}
}
