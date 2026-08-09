using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelSpaceBoundary : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcSpaceBoundarySelect RelatingSpace { get; set; }

	IIfcElement RelatedBuildingElement { get; set; }

	IIfcConnectionGeometry ConnectionGeometry { get; set; }

	IfcPhysicalOrVirtualEnum PhysicalOrVirtualBoundary { get; set; }

	IfcInternalOrExternalEnum InternalOrExternalBoundary { get; set; }
}
