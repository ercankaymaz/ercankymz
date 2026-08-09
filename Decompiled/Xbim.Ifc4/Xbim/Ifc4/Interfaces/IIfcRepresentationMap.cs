using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRepresentationMap : IPersistEntity, IPersist, IfcProductRepresentationSelect, IIfcProductRepresentationSelect, IExpressSelectType
{
	IIfcAxis2Placement MappingOrigin { get; set; }

	IIfcRepresentation MappedRepresentation { get; set; }

	IEnumerable<IIfcShapeAspect> HasShapeAspects { get; }

	IEnumerable<IIfcMappedItem> MapUsage { get; }
}
