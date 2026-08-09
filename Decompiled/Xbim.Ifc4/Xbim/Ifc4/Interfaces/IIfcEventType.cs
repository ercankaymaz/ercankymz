using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcEventType : IIfcTypeProcess, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect
{
	IfcEventTypeEnum PredefinedType { get; set; }

	IfcEventTriggerTypeEnum EventTriggerType { get; set; }

	IfcLabel? UserDefinedEventTriggerType { get; set; }
}
