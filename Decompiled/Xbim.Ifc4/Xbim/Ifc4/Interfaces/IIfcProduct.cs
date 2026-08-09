using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcProduct : IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IIfcObjectPlacement ObjectPlacement { get; set; }

	IIfcProductRepresentation Representation { get; set; }

	IEnumerable<IIfcRelAssignsToProduct> ReferencedBy { get; }

	IIfcSpatialElement IsContainedIn { get; }
}
