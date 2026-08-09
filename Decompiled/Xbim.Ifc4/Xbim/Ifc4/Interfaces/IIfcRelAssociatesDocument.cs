using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssociatesDocument : IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcDocumentSelect RelatingDocument { get; set; }
}
