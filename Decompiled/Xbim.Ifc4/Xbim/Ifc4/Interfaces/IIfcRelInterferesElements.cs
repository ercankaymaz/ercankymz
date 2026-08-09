using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelInterferesElements : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcElement RelatingElement { get; set; }

	IIfcElement RelatedElement { get; set; }

	IIfcConnectionGeometry InterferenceGeometry { get; set; }

	IfcIdentifier? InterferenceType { get; set; }

	bool? ImpliedOrder { get; set; }
}
