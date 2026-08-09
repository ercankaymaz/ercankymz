using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelConnectsPathElements : IIfcRelConnectsElements, IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IItemSet<IfcInteger> RelatingPriorities { get; }

	IItemSet<IfcInteger> RelatedPriorities { get; }

	IfcConnectionTypeEnum RelatedConnectionType { get; set; }

	IfcConnectionTypeEnum RelatingConnectionType { get; set; }
}
