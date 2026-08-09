using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelConnectsPorts : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcPort RelatingPort { get; set; }

	IIfcPort RelatedPort { get; set; }

	IIfcElement RealizingElement { get; set; }
}
