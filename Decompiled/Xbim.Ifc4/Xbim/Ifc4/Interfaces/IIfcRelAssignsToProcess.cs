using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssignsToProcess : IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcProcessSelect RelatingProcess { get; set; }

	IIfcMeasureWithUnit QuantityInProcess { get; set; }
}
