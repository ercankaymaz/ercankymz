using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRepresentation : IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcRepresentationContext ContextOfItems { get; set; }

	IfcLabel? RepresentationIdentifier { get; set; }

	IfcLabel? RepresentationType { get; set; }

	IItemSet<IIfcRepresentationItem> Items { get; }

	IEnumerable<IIfcRepresentationMap> RepresentationMap { get; }

	IEnumerable<IIfcPresentationLayerAssignment> LayerAssignments { get; }

	IEnumerable<IIfcProductRepresentation> OfProductRepresentation { get; }
}
