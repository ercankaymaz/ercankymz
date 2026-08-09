using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDocumentInformation : IIfcExternalInformation, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IfcDocumentSelect, IIfcDocumentSelect
{
	IfcIdentifier Identification { get; set; }

	IfcLabel Name { get; set; }

	IfcText? Description { get; set; }

	IfcURIReference? Location { get; set; }

	IfcText? Purpose { get; set; }

	IfcText? IntendedUse { get; set; }

	IfcText? Scope { get; set; }

	IfcLabel? Revision { get; set; }

	IIfcActorSelect DocumentOwner { get; set; }

	IItemSet<IIfcActorSelect> Editors { get; }

	IfcDateTime? CreationTime { get; set; }

	IfcDateTime? LastRevisionTime { get; set; }

	IfcIdentifier? ElectronicFormat { get; set; }

	IfcDate? ValidFrom { get; set; }

	IfcDate? ValidUntil { get; set; }

	IfcDocumentConfidentialityEnum? Confidentiality { get; set; }

	IfcDocumentStatusEnum? Status { get; set; }

	IEnumerable<IIfcRelAssociatesDocument> DocumentInfoForObjects { get; }

	IEnumerable<IIfcDocumentReference> HasDocumentReferences { get; }

	IEnumerable<IIfcDocumentInformationRelationship> IsPointedTo { get; }

	IEnumerable<IIfcDocumentInformationRelationship> IsPointer { get; }
}
