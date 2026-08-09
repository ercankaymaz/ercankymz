using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssociatesApproval : IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcApproval RelatingApproval { get; set; }
}
