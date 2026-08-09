using Xbim.Common;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.PresentationResource;

public interface IfcColour : IIfcColour, IIfcFillStyleSelect, IExpressSelectType, IPersist, IPersistEntity, IfcFillStyleSelect, IfcSymbolStyleSelect
{
}
