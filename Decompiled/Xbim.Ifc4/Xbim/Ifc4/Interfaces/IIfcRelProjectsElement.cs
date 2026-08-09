using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelProjectsElement : IIfcRelDecomposes, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcElement RelatingElement { get; set; }

	IIfcFeatureElementAddition RelatedFeatureElement { get; set; }
}
