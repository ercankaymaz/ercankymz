using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcTableColumn : IPersistEntity, IPersist
{
	IfcIdentifier? Identifier { get; set; }

	IfcLabel? Name { get; set; }

	IfcText? Description { get; set; }

	IIfcUnit Unit { get; set; }

	IIfcReference ReferencePath { get; set; }
}
