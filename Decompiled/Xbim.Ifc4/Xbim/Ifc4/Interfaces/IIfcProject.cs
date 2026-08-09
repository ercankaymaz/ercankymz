using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcProject : IIfcContext, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IEnumerable<IIfcSite> Sites { get; }

	IEnumerable<IIfcBuilding> Buildings { get; }

	IEnumerable<IIfcSpatialStructureElement> SpatialStructuralElements { get; }

	void Initialize(ProjectUnits units);
}
