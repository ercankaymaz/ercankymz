using System;
using Xbim.Common;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal class IfcQuantityCountTransient : IfcPhysicalSimpleQuantityTransient, IIfcQuantityCount, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	private readonly Xbim.Ifc4.MeasureResource.IfcCountMeasure _countValue;

	public Xbim.Ifc4.MeasureResource.IfcCountMeasure CountValue
	{
		get
		{
			return _countValue;
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

	internal IfcQuantityCountTransient()
	{
	}

	internal IfcQuantityCountTransient(Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit measure)
	{
		Xbim.Ifc2x3.MeasureResource.IfcValue valueComponent = measure.ValueComponent;
		_unit = measure.UnitComponent as IIfcNamedUnit;
		if (valueComponent is Xbim.Ifc2x3.MeasureResource.IfcCountMeasure)
		{
			_countValue = new Xbim.Ifc4.MeasureResource.IfcCountMeasure((Xbim.Ifc2x3.MeasureResource.IfcCountMeasure)(object)valueComponent);
		}
	}
}
