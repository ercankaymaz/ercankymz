using System;
using Xbim.Common;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal class IfcQuantityLengthTransient : IfcPhysicalSimpleQuantityTransient, IIfcQuantityLength, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	private readonly Xbim.Ifc4.MeasureResource.IfcLengthMeasure _lengthValue;

	public Xbim.Ifc4.MeasureResource.IfcLengthMeasure LengthValue
	{
		get
		{
			return _lengthValue;
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

	internal IfcQuantityLengthTransient()
	{
	}

	internal IfcQuantityLengthTransient(Xbim.Ifc2x3.MeasureResource.IfcMeasureWithUnit measure)
	{
		Xbim.Ifc2x3.MeasureResource.IfcValue valueComponent = measure.ValueComponent;
		_unit = measure.UnitComponent as IIfcNamedUnit;
		if (valueComponent is Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure)
		{
			_lengthValue = new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure)(object)valueComponent);
		}
	}
}
