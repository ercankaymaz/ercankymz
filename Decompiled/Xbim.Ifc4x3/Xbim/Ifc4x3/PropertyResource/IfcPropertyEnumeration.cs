using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PropertyResource;

[ExpressType("IfcPropertyEnumeration", 597)]
public class IfcPropertyEnumeration : IfcPropertyAbstraction, IIfcPropertyEnumeration, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPropertyEnumeration>
{
	private IItemSet<IIfcValue> _enumerationValuesIfc4;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel _name;

	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcValue> _enumerationValues;

	private Xbim.Ifc4x3.MeasureResource.IfcUnit _unit;

	[CrossSchemaAttribute(typeof(IIfcPropertyEnumeration), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcPropertyEnumeration.Name
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name);
		}
		set
		{
			Name = new Xbim.Ifc4x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPropertyEnumeration), 2)]
	IItemSet<IIfcValue> IIfcPropertyEnumeration.EnumerationValues => _enumerationValuesIfc4 ?? (_enumerationValuesIfc4 = new ExtendedItemSet<Xbim.Ifc4x3.MeasureResource.IfcValue, IIfcValue>(EnumerationValues, new ItemSet<IIfcValue>(this, 0, -2), (Xbim.Ifc4x3.MeasureResource.IfcValue v) => v.ToIfc4(), (IIfcValue v) => v.ToIfc3()));

	[CrossSchemaAttribute(typeof(IIfcPropertyEnumeration), 3)]
	IIfcUnit IIfcPropertyEnumeration.Unit
	{
		get
		{
			if (Unit == null)
			{
				return null;
			}
			Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = Unit as Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				return ifcDerivedUnit;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = Unit as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				return ifcMonetaryUnit;
			}
			Xbim.Ifc4x3.MeasureResource.IfcNamedUnit ifcNamedUnit = Unit as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
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
			Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit ifcDerivedUnit = value as Xbim.Ifc4x3.MeasureResource.IfcDerivedUnit;
			if (ifcDerivedUnit != null)
			{
				Unit = ifcDerivedUnit;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit ifcMonetaryUnit = value as Xbim.Ifc4x3.MeasureResource.IfcMonetaryUnit;
			if (ifcMonetaryUnit != null)
			{
				Unit = ifcMonetaryUnit;
				return;
			}
			Xbim.Ifc4x3.MeasureResource.IfcNamedUnit ifcNamedUnit = value as Xbim.Ifc4x3.MeasureResource.IfcNamedUnit;
			if (ifcNamedUnit != null)
			{
				Unit = ifcNamedUnit;
			}
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel Name
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.ListUnique, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcValue> EnumerationValues
	{
		get
		{
			if (_activated)
			{
				return _enumerationValues;
			}
			Activate();
			return _enumerationValues;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcUnit Unit
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcUnit v)
			{
				_unit = v;
			}, _unit, value, "Unit", 3);
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

	internal IfcPropertyEnumeration(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_enumerationValues = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcValue>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_enumerationValues.InternalAdd((Xbim.Ifc4x3.MeasureResource.IfcValue)value.EntityVal);
			break;
		case 2:
			_unit = (Xbim.Ifc4x3.MeasureResource.IfcUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertyEnumeration other)
	{
		return this == other;
	}
}
