using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.ProductExtension;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcExternalSpatialElement : IIfcExternalSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcSpaceBoundarySelect, IIfcSpaceBoundarySelect
{
	IfcExternalSpatialElementTypeEnum? PredefinedType { get; set; }

	IEnumerable<IIfcRelSpaceBoundary> BoundedBy { get; }
}
