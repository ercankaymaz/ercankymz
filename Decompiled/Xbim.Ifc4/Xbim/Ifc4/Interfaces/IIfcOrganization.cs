using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcOrganization : IPersistEntity, IPersist, IfcActorSelect, IIfcActorSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IfcIdentifier? Identification { get; set; }

	IfcLabel Name { get; set; }

	IfcText? Description { get; set; }

	IItemSet<IIfcActorRole> Roles { get; }

	IItemSet<IIfcAddress> Addresses { get; }

	IEnumerable<IIfcOrganizationRelationship> IsRelatedBy { get; }

	IEnumerable<IIfcOrganizationRelationship> Relates { get; }

	IEnumerable<IIfcPersonAndOrganization> Engages { get; }
}
