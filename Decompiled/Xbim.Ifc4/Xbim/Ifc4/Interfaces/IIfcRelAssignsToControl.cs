using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelAssignsToControl : IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcControl RelatingControl { get; set; }
}
