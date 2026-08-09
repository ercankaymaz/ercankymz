using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.UtilityResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRoot : IPersistEntity, IPersist
{
	IfcGloballyUniqueId GlobalId { get; set; }

	IIfcOwnerHistory OwnerHistory { get; set; }

	IfcLabel? Name { get; set; }

	IfcText? Description { get; set; }
}
