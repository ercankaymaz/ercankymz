using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRepresentationContext : IPersistEntity, IPersist
{
	IfcLabel? ContextIdentifier { get; set; }

	IfcLabel? ContextType { get; set; }

	IEnumerable<IIfcRepresentation> RepresentationsInContext { get; }
}
