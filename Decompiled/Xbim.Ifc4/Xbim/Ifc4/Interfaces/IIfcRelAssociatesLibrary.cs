using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssociatesLibrary : IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcLibrarySelect RelatingLibrary { get; set; }
}
