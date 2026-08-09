using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBuilding : IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcLengthMeasure? ElevationOfRefHeight { get; set; }

	IfcLengthMeasure? ElevationOfTerrain { get; set; }

	IIfcPostalAddress BuildingAddress { get; set; }

	IIfcSite Site { get; }

	IEnumerable<IIfcBuilding> Buildings { get; }

	IEnumerable<IIfcSpace> Spaces { get; }

	IEnumerable<IIfcBuildingStorey> BuildingStoreys { get; }
}
