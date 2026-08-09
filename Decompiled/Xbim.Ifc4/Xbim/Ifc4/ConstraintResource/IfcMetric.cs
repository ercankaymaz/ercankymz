using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ConstraintResource;

[ExpressType("IfcMetric", 80)]
public class IfcMetric : IfcConstraint, IInstantiableEntity, IPersistEntity, IPersist, IIfcMetric, IIfcConstraint, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcMetric>
{
	private IfcBenchmarkEnum _benchmark;

	private IfcLabel? _valueSource;

	private IfcMetricValueSelect _dataValue;

	private IfcReference _referencePath;

	IfcBenchmarkEnum IIfcMetric.Benchmark
	{
		get
		{
			return Benchmark;
		}
		set
		{
			Benchmark = value;
		}
	}

	IfcLabel? IIfcMetric.ValueSource
	{
		get
		{
			return ValueSource;
		}
		set
		{
			ValueSource = value;
		}
	}

	IIfcMetricValueSelect IIfcMetric.DataValue
	{
		get
		{
			return DataValue;
		}
		set
		{
			DataValue = value as IfcMetricValueSelect;
		}
	}

	IIfcReference IIfcMetric.ReferencePath
	{
		get
		{
			return ReferencePath;
		}
		set
		{
			ReferencePath = value as IfcReference;
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 10)]
	public IfcBenchmarkEnum Benchmark
	{
		get
		{
			if (_activated)
			{
				return _benchmark;
			}
			Activate();
			return _benchmark;
		}
		set
		{
			SetValue(delegate(IfcBenchmarkEnum v)
			{
				_benchmark = v;
			}, _benchmark, value, "Benchmark", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public IfcLabel? ValueSource
	{
		get
		{
			if (_activated)
			{
				return _valueSource;
			}
			Activate();
			return _valueSource;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_valueSource = v;
			}, _valueSource, value, "ValueSource", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public IfcMetricValueSelect DataValue
	{
		get
		{
			if (_activated)
			{
				return _dataValue;
			}
			Activate();
			return _dataValue;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMetricValueSelect v)
			{
				_dataValue = v;
			}, _dataValue, value, "DataValue", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 13)]
	public IfcReference ReferencePath
	{
		get
		{
			if (_activated)
			{
				return _referencePath;
			}
			Activate();
			return _referencePath;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcReference v)
			{
				_referencePath = v;
			}, _referencePath, value, "ReferencePath", 11);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.CreatingActor != null)
			{
				yield return base.CreatingActor;
			}
			if (ReferencePath != null)
			{
				yield return ReferencePath;
			}
		}
	}

	internal IfcMetric(IModel model, int label, bool activated)
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
		case 4:
		case 5:
		case 6:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_benchmark = (IfcBenchmarkEnum)Enum.Parse(typeof(IfcBenchmarkEnum), value.EnumVal, ignoreCase: true);
			break;
		case 8:
			_valueSource = value.StringVal;
			break;
		case 9:
			_dataValue = (IfcMetricValueSelect)value.EntityVal;
			break;
		case 10:
			_referencePath = (IfcReference)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMetric other)
	{
		return this == other;
	}
}
