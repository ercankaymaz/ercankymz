using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcContext : IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcLabel? ObjectType { get; set; }

	IfcLabel? LongName { get; set; }

	IfcLabel? Phase { get; set; }

	IItemSet<IIfcRepresentationContext> RepresentationContexts { get; }

	IIfcUnitAssignment UnitsInContext { get; set; }

	IEnumerable<IIfcRelDefinesByProperties> IsDefinedBy { get; }

	IEnumerable<IIfcRelDeclares> Declares { get; }
}
