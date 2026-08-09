using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssociatesMaterial : IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcMaterialSelect RelatingMaterial { get; set; }
}
