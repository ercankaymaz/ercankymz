using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcShapeModel : IIfcRepresentation, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IEnumerable<IIfcShapeAspect> OfShapeAspect { get; }
}
