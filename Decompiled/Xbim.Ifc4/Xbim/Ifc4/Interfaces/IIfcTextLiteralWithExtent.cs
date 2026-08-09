using Xbim.Common;
using Xbim.Ifc4.PresentationDefinitionResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTextLiteralWithExtent : IIfcTextLiteral, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IIfcPlanarExtent Extent { get; set; }

	IfcBoxAlignment BoxAlignment { get; set; }
}
