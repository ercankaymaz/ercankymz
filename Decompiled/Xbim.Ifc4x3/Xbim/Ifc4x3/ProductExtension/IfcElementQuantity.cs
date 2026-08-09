using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.QuantityResource;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcElementQuantity", 458)]
public class IfcElementQuantity : Xbim.Ifc4x3.Kernel.IfcQuantitySet, IIfcElementQuantity, IIfcQuantitySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcElementQuantity>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _methodOfMeasurement;

	private readonly ItemSet<IfcPhysicalQuantity> _quantities;

	[CrossSchemaAttribute(typeof(IIfcElementQuantity), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcElementQuantity.MethodOfMeasurement
	{
		get
		{
			if (!MethodOfMeasurement.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(MethodOfMeasurement.Value);
		}
		set
		{
			MethodOfMeasurement = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcElementQuantity), 6)]
	IItemSet<IIfcPhysicalQuantity> IIfcElementQuantity.Quantities => new ProxyItemSet<IfcPhysicalQuantity, IIfcPhysicalQuantity>(Quantities);

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? MethodOfMeasurement
	{
		get
		{
			if (_activated)
			{
				return _methodOfMeasurement;
			}
			Activate();
			return _methodOfMeasurement;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_methodOfMeasurement = v;
			}, _methodOfMeasurement, value, "MethodOfMeasurement", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 11)]
	public IItemSet<IfcPhysicalQuantity> Quantities
	{
		get
		{
			if (_activated)
			{
				return _quantities;
			}
			Activate();
			return _quantities;
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
			foreach (IfcPhysicalQuantity quantity in Quantities)
			{
				yield return quantity;
			}
		}
	}

	internal IfcElementQuantity(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_quantities = new ItemSet<IfcPhysicalQuantity>(this, 0, 6);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_methodOfMeasurement = value.StringVal;
			break;
		case 5:
			_quantities.InternalAdd((IfcPhysicalQuantity)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElementQuantity other)
	{
		return this == other;
	}
}
