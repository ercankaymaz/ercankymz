using Xbim.Common;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcSurfaceStyle : IIfcPresentationStyle, IPersistEntity, IPersist, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, IfcPresentationStyleSelect, IIfcPresentationStyleSelect
{
	IfcSurfaceSide Side { get; set; }

	IItemSet<IIfcSurfaceStyleElementSelect> Styles { get; }
}
