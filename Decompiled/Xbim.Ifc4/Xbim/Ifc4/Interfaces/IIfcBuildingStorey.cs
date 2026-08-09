using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBuildingStorey : IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcLengthMeasure? Elevation { get; set; }

	IEnumerable<IIfcSpace> Spaces { get; }

	IEnumerable<IIfcBuildingStorey> BuildingStoreys { get; }

	IfcAreaMeasure? GrossFloorArea { get; }

	IfcLengthMeasure? TotalHeight { get; }
}
