using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.TimeSeriesResource;

namespace Xbim.Ifc2x3.SharedBldgServiceElements;

[ExpressType("IfcSoundValue", 266)]
public class IfcSoundValue : IfcPropertySetDefinition, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcSoundValue>
{
	private IfcTimeSeries _soundLevelTimeSeries;

	private IfcFrequencyMeasure _frequency;

	private IfcDerivedMeasureValue _soundLevelSingleValue;

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcTimeSeries SoundLevelTimeSeries
	{
		get
		{
			if (_activated)
			{
				return _soundLevelTimeSeries;
			}
			Activate();
			return _soundLevelTimeSeries;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcTimeSeries v)
			{
				_soundLevelTimeSeries = v;
			}, _soundLevelTimeSeries, value, "SoundLevelTimeSeries", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public IfcFrequencyMeasure Frequency
	{
		get
		{
			if (_activated)
			{
				return _frequency;
			}
			Activate();
			return _frequency;
		}
		set
		{
			SetValue(delegate(IfcFrequencyMeasure v)
			{
				_frequency = v;
			}, _frequency, value, "Frequency", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 10)]
	public IfcDerivedMeasureValue SoundLevelSingleValue
	{
		get
		{
			if (_activated)
			{
				return _soundLevelSingleValue;
			}
			Activate();
			return _soundLevelSingleValue;
		}
		set
		{
			SetValue(delegate(IfcDerivedMeasureValue v)
			{
				_soundLevelSingleValue = v;
			}, _soundLevelSingleValue, value, "SoundLevelSingleValue", 7);
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
			if (SoundLevelTimeSeries != null)
			{
				yield return SoundLevelTimeSeries;
			}
		}
	}

	internal IfcSoundValue(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
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
			_soundLevelTimeSeries = (IfcTimeSeries)value.EntityVal;
			break;
		case 5:
			_frequency = value.RealVal;
			break;
		case 6:
			_soundLevelSingleValue = (IfcDerivedMeasureValue)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSoundValue other)
	{
		return this == other;
	}
}
