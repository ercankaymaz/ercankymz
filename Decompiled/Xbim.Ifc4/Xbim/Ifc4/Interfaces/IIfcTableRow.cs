using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTableRow : IPersistEntity, IPersist
{
	IItemSet<IIfcValue> RowCells { get; }

	IfcBoolean? IsHeading { get; set; }
}
