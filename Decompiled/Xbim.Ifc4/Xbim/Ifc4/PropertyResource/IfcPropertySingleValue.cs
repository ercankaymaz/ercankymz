using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.PropertyResource;

[ExpressType("IfcPropertySingleValue", 628)]
public class IfcPropertySingleValue : IfcSimpleProperty, IInstantiableEntity, IPersistEntity, IPersist, IIfcPropertySingleValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcPropertySingleValue>
{
	private IfcValue _nominalValue;

	private IfcUnit _unit;

	IIfcValue IIfcPropertySingleValue.NominalValue
	{
		get
		{
			return NominalValue;
		}
		set
		{
			NominalValue = value as IfcValue;
		}
	}

	IIfcUnit IIfcPropertySingleValue.Unit
	{
		get
		{
			return Unit;
		}
		set
		{
			Unit = value as IfcUnit;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 10)]
	public IfcValue NominalValue
	{
		get
		{
			if (_activated)
			{
				return _nominalValue;
			}
			Activate();
			return _nominalValue;
		}
		set
		{
			SetValue(delegate(IfcValue v)
			{
				_nominalValue = v;
			}, _nominalValue, value, "NominalValue", 3);
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

	internal IfcPropertySingleValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
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
			_nominalValue = (IfcValue)value.EntityVal;
			break;
		case 3:
			_unit = (IfcUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertySingleValue other)
	{
		return this == other;
	}
}
