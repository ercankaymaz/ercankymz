using System;
using Xbim.Common;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal class IfcQuantityTimeTransient : IfcPhysicalSimpleQuantityTransient, IIfcQuantityTime, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	private readonly Xbim.Ifc4.MeasureResource.IfcTimeMeasure _timeValue;

	public Xbim.Ifc4.MeasureResource.IfcTimeMeasure TimeValue
	{
		get
		{
			return _timeValue;
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

	internal IfcQuantityTimeTransient()
	{
	}

	internal IfcQuantityTimeTransient(Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit measure)
	{
		Xbim.Ifc2x3.MeasureResource.IfcValue valueComponent = measure.ValueComponent;
		_unit = measure.UnitComponent as IIfcNamedUnit;
		if (valueComponent is Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure)
		{
			_timeValue = new Xbim.Ifc4.MeasureResource.IfcTimeMeasure((Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure)(object)valueComponent);
		}
	}
}
