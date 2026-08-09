using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcNamedUnit : IPersistEntity, IPersist, IfcUnit, IIfcUnit, IExpressSelectType
{
	IIfcDimensionalExponents Dimensions { get; set; }

	IfcUnitEnum UnitType { get; set; }

	string Symbol { get; }
}
