using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelFillsElement : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcOpeningElement RelatingOpeningElement { get; set; }

	IIfcElement RelatedBuildingElement { get; set; }
}
