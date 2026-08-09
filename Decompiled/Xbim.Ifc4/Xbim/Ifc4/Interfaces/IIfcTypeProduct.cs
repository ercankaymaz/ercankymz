using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTypeProduct : IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IItemSet<IIfcRepresentationMap> RepresentationMaps { get; }

	IfcLabel? Tag { get; set; }

	IEnumerable<IIfcRelAssignsToProduct> ReferencedBy { get; }
}
