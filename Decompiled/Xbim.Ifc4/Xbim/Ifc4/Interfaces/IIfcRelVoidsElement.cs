using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelVoidsElement : IIfcRelDecomposes, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcElement RelatingBuildingElement { get; set; }

	IIfcFeatureElementSubtraction RelatedOpeningElement { get; set; }
}
