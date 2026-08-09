using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCurveStyleFontAndScaling : IIfcPresentationItem, IPersistEntity, IPersist, IfcCurveFontOrScaledCurveFontSelect, IIfcCurveFontOrScaledCurveFontSelect, IExpressSelectType
{
	IfcLabel? Name { get; set; }

	IIfcCurveStyleFontSelect CurveFont { get; set; }

	IfcPositiveRatioMeasure CurveFontScaling { get; set; }
}
