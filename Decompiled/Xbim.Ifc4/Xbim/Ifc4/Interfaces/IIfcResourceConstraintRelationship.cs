using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcResourceConstraintRelationship : IIfcResourceLevelRelationship, IPersistEntity, IPersist
{
	IIfcConstraint RelatingConstraint { get; set; }

	IItemSet<IIfcResourceObjectSelect> RelatedResourceObjects { get; }
}
