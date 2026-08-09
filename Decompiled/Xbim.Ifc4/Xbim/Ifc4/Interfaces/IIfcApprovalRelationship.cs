using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcApprovalRelationship : IIfcResourceLevelRelationship, IPersistEntity, IPersist
{
	IIfcApproval RelatingApproval { get; set; }

	IItemSet<IIfcApproval> RelatedApprovals { get; }
}
