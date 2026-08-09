using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcProductDefinitionShape : IIfcProductRepresentation, IPersistEntity, IPersist, IfcProductRepresentationSelect, IIfcProductRepresentationSelect, IExpressSelectType
{
	IEnumerable<IIfcProduct> ShapeOfProduct { get; }

	IEnumerable<IIfcShapeAspect> HasShapeAspects { get; }
}
