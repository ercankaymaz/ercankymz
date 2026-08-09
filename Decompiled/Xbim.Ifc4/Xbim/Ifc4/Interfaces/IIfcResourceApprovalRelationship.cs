using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcResourceApprovalRelationship : IIfcResourceLevelRelationship, IPersistEntity, IPersist
{
	IItemSet<IIfcResourceObjectSelect> RelatedResourceObjects { get; }

	IIfcApproval RelatingApproval { get; set; }
}
