using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcFace : IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IItemSet<IIfcFaceBound> Bounds { get; }

	IEnumerable<IIfcTextureMap> HasTextureMaps { get; }
}
