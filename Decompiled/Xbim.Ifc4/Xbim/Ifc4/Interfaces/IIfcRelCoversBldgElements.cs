using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelCoversBldgElements : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcElement RelatingBuildingElement { get; set; }

	IItemSet<IIfcCovering> RelatedCoverings { get; }
}
