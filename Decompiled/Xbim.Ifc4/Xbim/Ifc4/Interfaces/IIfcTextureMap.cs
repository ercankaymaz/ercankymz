using System.Collections.Generic;
using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTextureMap : IIfcTextureCoordinate, IIfcPresentationItem, IPersistEntity, IPersist
{
	IEnumerable<IIfcTextureVertex> Vertices { get; }

	IIfcFace MappedTo { get; set; }
}
