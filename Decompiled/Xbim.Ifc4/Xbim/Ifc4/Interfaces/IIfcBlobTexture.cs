using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcBlobTexture : IIfcSurfaceTexture, IIfcPresentationItem, IPersistEntity, IPersist
{
	IfcIdentifier RasterFormat { get; set; }

	IfcBinary RasterCode { get; set; }
}
