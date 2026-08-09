using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCostSchedule : IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcCostScheduleTypeEnum? PredefinedType { get; set; }

	IfcLabel? Status { get; set; }

	IfcDateTime? SubmittedOn { get; set; }

	IfcDateTime? UpdateDate { get; set; }
}
