using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelContainedInSpatialStructure : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IItemSet<IIfcProduct> RelatedElements { get; }

	IIfcSpatialElement RelatingStructure { get; set; }
}
