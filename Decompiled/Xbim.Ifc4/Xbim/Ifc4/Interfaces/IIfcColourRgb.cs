using Xbim.Common;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcColourRgb : IIfcColourSpecification, IIfcPresentationItem, IPersistEntity, IPersist, IfcColour, IfcFillStyleSelect, IIfcFillStyleSelect, IExpressSelectType, IIfcColour, IfcColourOrFactor, IIfcColourOrFactor
{
	IfcNormalisedRatioMeasure Red { get; set; }

	IfcNormalisedRatioMeasure Green { get; set; }

	IfcNormalisedRatioMeasure Blue { get; set; }
}
