using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssociatesConstraint : IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IfcLabel? Intent { get; set; }

	IIfcConstraint RelatingConstraint { get; set; }
}
