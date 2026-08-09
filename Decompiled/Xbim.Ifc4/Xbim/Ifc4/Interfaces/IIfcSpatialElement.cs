using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSpatialElement : IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect
{
	IfcLabel? LongName { get; set; }

	IEnumerable<IIfcRelContainedInSpatialStructure> ContainsElements { get; }

	IEnumerable<IIfcRelServicesBuildings> ServicedBySystems { get; }

	IEnumerable<IIfcRelReferencedInSpatialStructure> ReferencesElements { get; }
}
