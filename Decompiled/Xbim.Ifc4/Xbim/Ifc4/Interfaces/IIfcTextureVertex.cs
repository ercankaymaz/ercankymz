using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTextureVertex : IIfcPresentationItem, IPersistEntity, IPersist
{
	IItemSet<IfcParameterValue> Coordinates { get; }
}
