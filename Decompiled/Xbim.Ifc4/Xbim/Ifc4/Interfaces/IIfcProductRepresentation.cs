using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcProductRepresentation : IPersistEntity, IPersist
{
	IfcLabel? Name { get; set; }

	IfcText? Description { get; set; }

	IItemSet<IIfcRepresentation> Representations { get; }
}
