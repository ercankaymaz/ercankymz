using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.ProductExtension;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSpace : IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcSpaceBoundarySelect, IIfcSpaceBoundarySelect
{
	IfcSpaceTypeEnum? PredefinedType { get; set; }

	IfcLengthMeasure? ElevationWithFlooring { get; set; }

	IEnumerable<IIfcRelCoversSpaces> HasCoverings { get; }

	IEnumerable<IIfcRelSpaceBoundary> BoundedBy { get; }

	IEnumerable<IIfcSpace> Spaces { get; }
}
