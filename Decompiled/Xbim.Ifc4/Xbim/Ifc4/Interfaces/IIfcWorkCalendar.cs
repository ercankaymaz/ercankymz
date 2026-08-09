using Xbim.Common;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcWorkCalendar : IIfcControl, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType
{
	IItemSet<IIfcWorkTime> WorkingTimes { get; }

	IItemSet<IIfcWorkTime> ExceptionTimes { get; }

	IfcWorkCalendarTypeEnum? PredefinedType { get; set; }
}
