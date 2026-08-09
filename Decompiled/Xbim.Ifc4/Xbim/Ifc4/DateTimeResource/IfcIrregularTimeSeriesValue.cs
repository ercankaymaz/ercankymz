using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcIrregularTimeSeriesValue", 609)]
public class IfcIrregularTimeSeriesValue : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcIrregularTimeSeriesValue, IEquatable<IfcIrregularTimeSeriesValue>
{
	private IfcDateTime _timeStamp;

	private readonly ItemSet<IfcValue> _listValues;

	IfcDateTime IIfcIrregularTimeSeriesValue.TimeStamp
	{
		get
		{
			return TimeStamp;
		}
		set
		{
			TimeStamp = value;
		}
	}

	IItemSet<IIfcValue> IIfcIrregularTimeSeriesValue.ListValues => new ProxyItemSet<IfcValue, IIfcValue>(ListValues);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcDateTime TimeStamp
	{
		get
		{
			if (_activated)
			{
				return _timeStamp;
			}
			Activate();
			return _timeStamp;
		}
		set
		{
			SetValue(delegate(IfcDateTime v)
			{
				_timeStamp = v;
			}, _timeStamp, value, "TimeStamp", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
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

	internal IfcIrregularTimeSeriesValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_listValues = new ItemSet<IfcValue>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_timeStamp = value.StringVal;
			break;
		case 1:
			_listValues.InternalAdd((IfcValue)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcIrregularTimeSeriesValue other)
	{
		return this == other;
	}
}
