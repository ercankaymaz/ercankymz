using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcProcess : IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect
{
	IfcIdentifier? Identification { get; set; }

	IfcText? LongDescription { get; set; }

	IEnumerable<IIfcRelSequence> IsPredecessorTo { get; }

	IEnumerable<IIfcRelSequence> IsSuccessorFrom { get; }

	IEnumerable<IIfcRelAssignsToProcess> OperatesOn { get; }
}
