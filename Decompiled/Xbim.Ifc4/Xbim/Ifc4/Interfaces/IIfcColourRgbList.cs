using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcColourRgbList : IIfcPresentationItem, IPersistEntity, IPersist
{
	IItemSet<IItemSet<IfcNormalisedRatioMeasure>> ColourList { get; }
}
