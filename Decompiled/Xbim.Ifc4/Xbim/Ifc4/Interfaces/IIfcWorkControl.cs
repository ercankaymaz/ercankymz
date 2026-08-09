using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcWorkControl : IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IfcDateTime CreationDate { get; set; }

	IItemSet<IIfcPerson> Creators { get; }

	IfcLabel? Purpose { get; set; }

	IfcDuration? Duration { get; set; }

	IfcDuration? TotalFloat { get; set; }

	IfcDateTime StartTime { get; set; }

	IfcDateTime? FinishTime { get; set; }
}
