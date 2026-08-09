using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcTimeSeriesValue", 35)]
public class IfcTimeSeriesValue : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcTimeSeriesValue, IEquatable<IfcTimeSeriesValue>
{
	private readonly ItemSet<IfcValue> _listValues;

	IItemSet<IIfcValue> IIfcTimeSeriesValue.ListValues => new ProxyItemSet<IfcValue, IIfcValue>(ListValues);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<IfcValue> ListValues
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

	internal IfcTimeSeriesValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_listValues = new ItemSet<IfcValue>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_listValues.InternalAdd((IfcValue)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcTimeSeriesValue other)
	{
		return this == other;
	}
}
