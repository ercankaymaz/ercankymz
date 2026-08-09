using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssignsToResource : IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcResourceSelect RelatingResource { get; set; }
}
