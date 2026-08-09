using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

public interface IfcColour : IIfcColour, IIfcFillStyleSelect, IExpressSelectType, IPersist, IPersistEntity, IfcFillStyleSelect
{
}
