using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPixelTexture : IIfcSurfaceTexture, IIfcPresentationItem, IPersistEntity, IPersist
{
	IfcInteger Width { get; set; }

	IfcInteger Height { get; set; }

	IfcInteger ColourComponents { get; set; }

	IItemSet<IfcBinary> Pixel { get; }
}
