using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcExternalReferenceRelationship : IIfcResourceLevelRelationship, IPersistEntity, IPersist
{
	IIfcExternalReference RelatingReference { get; set; }

	IItemSet<IIfcResourceObjectSelect> RelatedResourceObjects { get; }
}
