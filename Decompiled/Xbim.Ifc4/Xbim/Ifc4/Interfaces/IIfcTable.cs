using Xbim.Common;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTable : IPersistEntity, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect
{
	IfcLabel? Name { get; set; }

	IItemSet<IIfcTableRow> Rows { get; }

	IItemSet<IIfcTableColumn> Columns { get; }

	IfcInteger NumberOfCellsInRow { get; }

	IfcInteger NumberOfHeadings { get; }

	IfcInteger NumberOfDataRows { get; }
}
