using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelCoversSpaces : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcSpace RelatingSpace { get; set; }

	IItemSet<IIfcCovering> RelatedCoverings { get; }
}
