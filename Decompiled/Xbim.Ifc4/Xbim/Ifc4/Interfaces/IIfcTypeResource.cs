using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTypeResource : IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcResourceSelect, IIfcResourceSelect
{
	IfcIdentifier? Identification { get; set; }

	IfcText? LongDescription { get; set; }

	IfcLabel? ResourceType { get; set; }

	IEnumerable<IIfcRelAssignsToResource> ResourceOf { get; }
}
