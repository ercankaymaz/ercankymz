using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSIUnit : IIfcNamedUnit, IPersistEntity, IPersist, IfcUnit, IIfcUnit, IExpressSelectType
{
	IfcSIPrefix? Prefix { get; set; }

	IfcSIUnitName Name { get; set; }

	double Power { get; }
}
