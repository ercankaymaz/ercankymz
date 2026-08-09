using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcCurveStyle : IIfcPresentationStyle, IPersistEntity, IPersist, IfcStyleAssignmentSelect, IIfcStyleAssignmentSelect, IExpressSelectType, IfcPresentationStyleSelect, IIfcPresentationStyleSelect
{
	IIfcCurveFontOrScaledCurveFontSelect CurveFont { get; set; }

	IIfcSizeSelect CurveWidth { get; set; }

	IIfcColour CurveColour { get; set; }

	IfcBoolean? ModelOrDraughting { get; set; }
}
