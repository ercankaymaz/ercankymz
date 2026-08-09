using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssignsToGroup : IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcGroup RelatingGroup { get; set; }
}
