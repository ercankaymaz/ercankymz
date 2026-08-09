using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcIndexedColourMap : IIfcPresentationItem, IPersistEntity, IPersist
{
	IIfcTessellatedFaceSet MappedTo { get; set; }

	IfcNormalisedRatioMeasure? Opacity { get; set; }

	IIfcColourRgbList Colours { get; set; }

	IItemSet<IfcPositiveInteger> ColourIndex { get; }
}
