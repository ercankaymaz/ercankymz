using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.QuantityResource;

[ExpressType("IfcQuantityVolume", 100)]
public class IfcQuantityVolume : IfcPhysicalSimpleQuantity, IIfcQuantityVolume, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcQuantityVolume>
{
	private Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure _volumeValue;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _formula;

	[CrossSchemaAttribute(typeof(IIfcQuantityVolume), 4)]
	Xbim.Ifc4.MeasureResource.IfcVolumeMeasure IIfcQuantityVolume.VolumeValue
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcVolumeMeasure(VolumeValue);
		}
		set
		{
			VolumeValue = new Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcQuantityVolume), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcQuantityVolume.Formula
	{
		get
		{
			if (!Formula.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Formula.Value);
		}
		set
		{
			Formula = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure VolumeValue
	{
		get
		{
			if (_activated)
			{
				return _volumeValue;
			}
			Activate();
			return _volumeValue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcVolumeMeasure v)
			{
				_volumeValue = v;
			}, _volumeValue, value, "VolumeValue", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Formula
	{
		get
		{
			if (_activated)
			{
				return _formula;
			}
			Activate();
			return _formula;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_formula = v;
			}, _formula, value, "Formula", 5);
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
		}
	}

	internal IfcQuantityVolume(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_volumeValue = value.RealVal;
			break;
		case 4:
			_formula = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcQuantityVolume other)
	{
		return this == other;
	}
}
