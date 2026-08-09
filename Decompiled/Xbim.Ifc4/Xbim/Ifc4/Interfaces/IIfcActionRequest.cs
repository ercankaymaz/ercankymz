using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcActionRequest : IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcActionRequestTypeEnum? PredefinedType { get; set; }

	IfcLabel? Status { get; set; }

	IfcText? LongDescription { get; set; }
}
