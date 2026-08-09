using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcApproval : IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcIdentifier? Identifier { get; set; }

	IfcLabel? Name { get; set; }

	IfcText? Description { get; set; }

	IfcDateTime? TimeOfApproval { get; set; }

	IfcLabel? Status { get; set; }

	IfcLabel? Level { get; set; }

	IfcText? Qualifier { get; set; }

	IIfcActorSelect RequestingApproval { get; set; }

	IIfcActorSelect GivingApproval { get; set; }

	IEnumerable<IIfcExternalReferenceRelationship> HasExternalReferences { get; }

	IEnumerable<IIfcRelAssociatesApproval> ApprovedObjects { get; }

	IEnumerable<IIfcResourceApprovalRelationship> ApprovedResources { get; }

	IEnumerable<IIfcApprovalRelationship> IsRelatedWith { get; }

	IEnumerable<IIfcApprovalRelationship> Relates { get; }
}
