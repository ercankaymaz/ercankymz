using Xbim.Common;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTextLiteral : IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	IfcPresentableText Literal { get; set; }

	IIfcAxis2Placement Placement { get; set; }

	IfcTextPath Path { get; set; }
}
