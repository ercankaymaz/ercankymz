using Xbim.Common;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTask : IIfcProcess, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProcessSelect, IIfcProcessSelect
{
	IfcLabel? Status { get; set; }

	IfcLabel? WorkMethod { get; set; }

	IfcBoolean IsMilestone { get; set; }

	IfcInteger? Priority { get; set; }

	IIfcTaskTime TaskTime { get; set; }

	IfcTaskTypeEnum? PredefinedType { get; set; }
}
