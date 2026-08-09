using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelConnectsElements : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcConnectionGeometry ConnectionGeometry { get; set; }

	IIfcElement RelatingElement { get; set; }

	IIfcElement RelatedElement { get; set; }
}
