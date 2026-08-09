using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTypeProcess : IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect
{
	IfcIdentifier? Identification { get; set; }

	IfcText? LongDescription { get; set; }

	IfcLabel? ProcessType { get; set; }

	IEnumerable<IIfcRelAssignsToProcess> OperatesOn { get; }
}
