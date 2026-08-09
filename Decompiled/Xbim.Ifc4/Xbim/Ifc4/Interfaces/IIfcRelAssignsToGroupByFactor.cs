using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssignsToGroupByFactor : IIfcRelAssignsToGroup, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IfcRatioMeasure Factor { get; set; }
}
