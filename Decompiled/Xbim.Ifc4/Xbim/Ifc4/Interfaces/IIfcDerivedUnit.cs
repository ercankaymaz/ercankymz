using Xbim.Common;
using Xbim.Common.Geometry;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDerivedUnit : IPersistEntity, IPersist, IfcUnit, IIfcUnit, IExpressSelectType
{
	IItemSet<IIfcDerivedUnitElement> Elements { get; }

	IfcDerivedUnitEnum UnitType { get; set; }

	IfcLabel? UserDefinedType { get; set; }

	Xbim.Common.Geometry.XbimDimensionalExponents Dimensions { get; }
}
