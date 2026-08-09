using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPropertyDependencyRelationship : IIfcResourceLevelRelationship, IPersistEntity, IPersist
{
	IIfcProperty DependingProperty { get; set; }

	IIfcProperty DependantProperty { get; set; }

	IfcText? Expression { get; set; }
}
