using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialDefinitionRepresentation : IIfcProductRepresentation, IPersistEntity, IPersist
{
	IIfcMaterial RepresentedMaterial { get; set; }
}
