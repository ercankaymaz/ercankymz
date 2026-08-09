using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralLoadResource;

[ExpressType("IfcStructuralLoadConfiguration", 1282)]
public class IfcStructuralLoadConfiguration : IfcStructuralLoad, IIfcStructuralLoadConfiguration, IIfcStructuralLoad, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcStructuralLoadConfiguration>
{
	private readonly ItemSet<IfcStructuralLoadOrResult> _values;

	private readonly OptionalItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>> _locations;

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadConfiguration), 2)]
	IItemSet<IIfcStructuralLoadOrResult> IIfcStructuralLoadConfiguration.Values => new ProxyItemSet<IfcStructuralLoadOrResult, IIfcStructuralLoadOrResult>(Values);

	[CrossSchemaAttribute(typeof(IIfcStructuralLoadConfiguration), 3)]
	IItemSet<IItemSet<Xbim.Ifc4.MeasureResource.IfcLengthMeasure>> IIfcStructuralLoadConfiguration.Locations => new ProxyNestedValueSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure, Xbim.Ifc4.MeasureResource.IfcLengthMeasure>(Locations, (Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure s) => new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(s), (Xbim.Ifc4.MeasureResource.IfcLengthMeasure t) => new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(t));

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcStructuralLoadOrResult> Values
	{
		get
		{
			if (_activated)
			{
				return _values;
			}
			Activate();
			return _values;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.List, new int[] { 1, 1 }, new int[] { -1, 2 }, 3)]
	public IOptionalItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>> Locations
	{
		get
		{
			if (_activated)
			{
				return _locations;
			}
			Activate();
			return _locations;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcStructuralLoadOrResult value in Values)
			{
				yield return value;
			}
		}
	}

	internal IfcStructuralLoadConfiguration(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_values = new ItemSet<IfcStructuralLoadOrResult>(this, 0, 2);
		_locations = new OptionalItemSet<IItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_values.InternalAdd((IfcStructuralLoadOrResult)value.EntityVal);
			break;
		case 2:
			((ItemSet<Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure>)_locations.InternalGetAt(nestedIndex[0])).InternalAdd(value.RealVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralLoadConfiguration other)
	{
		return this == other;
	}
}
