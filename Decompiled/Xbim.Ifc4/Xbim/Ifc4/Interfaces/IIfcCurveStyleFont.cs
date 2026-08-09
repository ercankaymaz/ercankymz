using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCurveStyleFont : IIfcPresentationItem, IPersistEntity, IPersist, IfcCurveStyleFontSelect, IfcCurveFontOrScaledCurveFontSelect, IIfcCurveFontOrScaledCurveFontSelect, IExpressSelectType, IIfcCurveStyleFontSelect
{
	IfcLabel? Name { get; set; }

	IItemSet<IIfcCurveStyleFontPattern> PatternList { get; }
}
