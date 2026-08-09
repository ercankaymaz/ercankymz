using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRepresentationItem : IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IEnumerable<IIfcPresentationLayerAssignment> LayerAssignment { get; }

	IEnumerable<IIfcStyledItem> StyledByItem { get; }
}
