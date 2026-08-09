using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4x3.DateTimeResource;

[ExpressType("IfcIrregularTimeSeries", 570)]
public class IfcIrregularTimeSeries : IfcTimeSeries, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcIrregularTimeSeries>, IIfcIrregularTimeSeries, IIfcTimeSeries, IfcMetricValueSelect, IIfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	private readonly ItemSet<IfcIrregularTimeSeriesValue> _values;

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 10)]
	public IItemSet<IfcIrregularTimeSeriesValue> Values
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

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Unit != null)
			{
				yield return base.Unit;
			}
			foreach (IfcIrregularTimeSeriesValue value in Values)
			{
				yield return value;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcIrregularTimeSeries), 9)]
	IItemSet<IIfcIrregularTimeSeriesValue> IIfcIrregularTimeSeries.Values => new ProxyItemSet<IfcIrregularTimeSeriesValue, IIfcIrregularTimeSeriesValue>(Values);

	internal IfcIrregularTimeSeries(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_values = new ItemSet<IfcIrregularTimeSeriesValue>(this, 0, 9);
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
		case 6:
		case 7:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_values.InternalAdd((IfcIrregularTimeSeriesValue)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcIrregularTimeSeries other)
	{
		return this == other;
	}
}
