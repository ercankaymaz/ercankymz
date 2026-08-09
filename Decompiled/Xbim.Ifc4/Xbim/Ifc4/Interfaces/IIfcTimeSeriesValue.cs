using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTimeSeriesValue : IPersistEntity, IPersist
{
	IItemSet<IIfcValue> ListValues { get; }
}
