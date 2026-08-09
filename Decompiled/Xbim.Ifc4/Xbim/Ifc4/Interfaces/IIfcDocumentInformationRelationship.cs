using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDocumentInformationRelationship : IIfcResourceLevelRelationship, IPersistEntity, IPersist
{
	IIfcDocumentInformation RelatingDocument { get; set; }

	IItemSet<IIfcDocumentInformation> RelatedDocuments { get; }

	IfcLabel? RelationshipType { get; set; }
}
