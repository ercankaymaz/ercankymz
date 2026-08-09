using System;
using Xbim.Common;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal class IfcQuantityAreaTransient : IfcPhysicalSimpleQuantityTransient, IIfcQuantityArea, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	private readonly Xbim.Ifc4.MeasureResource.IfcAreaMeasure _areaValue;

	public Xbim.Ifc4.MeasureResource.IfcAreaMeasure AreaValue
	{
		get
		{
			return _areaValue;
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

	internal IfcQuantityAreaTransient()
	{
	}

	internal IfcQuantityAreaTransient(Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit measure)
	{
		Xbim.Ifc2x3.MeasureResource.IfcValue valueComponent = measure.ValueComponent;
		_unit = measure.UnitComponent as IIfcNamedUnit;
		if (valueComponent is Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure)
		{
			_areaValue = new Xbim.Ifc4.MeasureResource.IfcAreaMeasure((Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure)(object)valueComponent);
		}
	}
}
