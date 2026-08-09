using System;
using Xbim.Common;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal class IfcQuantityWeightTransient : IfcPhysicalSimpleQuantityTransient, IIfcQuantityWeight, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	private readonly Xbim.Ifc4.MeasureResource.IfcMassMeasure _weightValue;

	public Xbim.Ifc4.MeasureResource.IfcMassMeasure WeightValue
	{
		get
		{
			return _weightValue;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public Xbim.Ifc4.MeasureResource.IfcLabel? Formula
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	internal IfcQuantityWeightTransient()
	{
	}

	internal IfcQuantityWeightTransient(Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit measure)
	{
		Xbim.Ifc2x3.MeasureResource.IfcValue valueComponent = measure.ValueComponent;
		_unit = measure.UnitComponent as IIfcNamedUnit;
		if (valueComponent is Xbim.Ifc2x3.MeasureResource.IfcMassMeasure)
		{
			_weightValue = new Xbim.Ifc4.MeasureResource.IfcMassMeasure((Xbim.Ifc2x3.MeasureResource.IfcMassMeasure)(object)valueComponent);
		}
	}
}
