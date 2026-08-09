using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcConversionBasedUnitWithOffset : IIfcConversionBasedUnit, IIfcNamedUnit, IPersistEntity, IPersist, IfcUnit, IIfcUnit, IExpressSelectType, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IfcReal ConversionOffset { get; set; }
}
