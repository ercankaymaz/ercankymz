using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelFlowControlElements : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IItemSet<IIfcDistributionControlElement> RelatedControlElements { get; }

	IIfcDistributionFlowElement RelatingFlowElement { get; set; }
}
