using System;
using Xbim.Common;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal class IfcQuantityVolumeTransient : IfcPhysicalSimpleQuantityTransient, IIfcQuantityVolume, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	private readonly Xbim.Ifc4.MeasureResource.IfcVolumeMeasure _volumeValue;

	public Xbim.Ifc4.MeasureResource.IfcVolumeMeasure VolumeValue
	{
		get
		{
			return _volumeValue;
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

	internal IfcQuantityVolumeTransient()
	{
	}

	internal IfcQuantityVolumeTransient(Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit measure)
	{
		Xbim.Ifc2x3.MeasureResource.IfcValue valueComponent = measure.ValueComponent;
		_unit = measure.UnitComponent as IIfcNamedUnit;
		if (valueComponent is Xbim.Ifc2x3.MeasureResource.IfcVolumeMeasure)
		{
			_volumeValue = new Xbim.Ifc4.MeasureResource.IfcVolumeMeasure((Xbim.Ifc2x3.MeasureResource.IfcVolumeMeasure)(object)valueComponent);
		}
	}
}
