using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBoundaryCondition : IPersistEntity, IPersist
{
	IfcLabel? Name { get; set; }
}
