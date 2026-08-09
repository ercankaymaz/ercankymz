using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssociatesClassification : IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcClassificationSelect RelatingClassification { get; set; }
}
