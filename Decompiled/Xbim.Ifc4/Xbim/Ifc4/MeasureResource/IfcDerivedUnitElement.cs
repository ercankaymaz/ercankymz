using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.MeasureResource;

[ExpressType("IfcDerivedUnitElement", 380)]
public class IfcDerivedUnitElement : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcDerivedUnitElement, IContainsEntityReferences, IEquatable<IfcDerivedUnitElement>
{
	private IfcNamedUnit _unit;

	private long _exponent;

	IIfcNamedUnit IIfcDerivedUnitElement.Unit
	{
		get
		{
			return Unit;
		}
		set
		{
			Unit = value as IfcNamedUnit;
		}
	}

	long IIfcDerivedUnitElement.Exponent
	{
		get
		{
			return Exponent;
		}
		set
		{
			Exponent = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcNamedUnit Unit
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
			SetValue(delegate(IfcNamedUnit v)
			{
				_unit = v;
			}, _unit, value, "Unit", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public long Exponent
	{
		get
		{
			if (_activated)
			{
				return _exponent;
			}
			Activate();
			return _exponent;
		}
		set
		{
			SetValue(delegate(long v)
			{
				_exponent = v;
			}, _exponent, value, "Exponent", 2);
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

	internal IfcDerivedUnitElement(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_unit = (IfcNamedUnit)value.EntityVal;
			break;
		case 1:
			_exponent = value.IntegerVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDerivedUnitElement other)
	{
		return this == other;
	}
}
