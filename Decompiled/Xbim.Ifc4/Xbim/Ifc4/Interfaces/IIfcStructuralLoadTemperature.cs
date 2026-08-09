using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcStructuralLoadTemperature : IIfcStructuralLoadStatic, IIfcStructuralLoadOrResult, IIfcStructuralLoad, IPersistEntity, IPersist
{
	IfcThermodynamicTemperatureMeasure? DeltaTConstant { get; set; }

	IfcThermodynamicTemperatureMeasure? DeltaTY { get; set; }

	IfcThermodynamicTemperatureMeasure? DeltaTZ { get; set; }
}
