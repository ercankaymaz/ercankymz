using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcIndexedTextureMap : IIfcTextureCoordinate, IIfcPresentationItem, IPersistEntity, IPersist
{
	IIfcTessellatedFaceSet MappedTo { get; set; }

	IIfcTextureVertexList TexCoords { get; set; }
}
