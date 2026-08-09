using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelConnectsPortToElement : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcPort RelatingPort { get; set; }

	IIfcDistributionElement RelatedElement { get; set; }
}
