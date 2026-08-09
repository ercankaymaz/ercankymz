using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcIrregularTimeSeriesValue : IPersistEntity, IPersist
{
	IfcDateTime TimeStamp { get; set; }

	IItemSet<IIfcValue> ListValues { get; }
}
