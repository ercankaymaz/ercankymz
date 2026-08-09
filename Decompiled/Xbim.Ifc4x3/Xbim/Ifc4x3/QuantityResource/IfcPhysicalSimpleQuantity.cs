using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.QuantityResource;

[ExpressType("IfcPhysicalSimpleQuantity", 101)]
public abstract class IfcPhysicalSimpleQuantity : IfcPhysicalQuantity, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcPhysicalSimpleQuantity>
{
	private IfcNamedUnit _unit;

	[CrossSchemaAttribute(typeof(IIfcPhysicalSimpleQuantity), 3)]
	IIfcNamedUnit IIfcPhysicalSimpleQuantity.Unit
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

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
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
			}, _unit, value, "Unit", 3);
		}
	}

	internal IfcPhysicalSimpleQuantity(IModel model, int label, bool activated)
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
			_unit = (IfcNamedUnit)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPhysicalSimpleQuantity other)
	{
		return this == other;
	}
}
