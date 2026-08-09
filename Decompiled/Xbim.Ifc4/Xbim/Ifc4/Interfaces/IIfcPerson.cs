using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPerson : IPersistEntity, IPersist, IfcActorSelect, IIfcActorSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IfcIdentifier? Identification { get; set; }

	IfcLabel? FamilyName { get; set; }

	IfcLabel? GivenName { get; set; }

	IItemSet<IfcLabel> MiddleNames { get; }

	IItemSet<IfcLabel> PrefixTitles { get; }

	IItemSet<IfcLabel> SuffixTitles { get; }

	IItemSet<IIfcActorRole> Roles { get; }

	IItemSet<IIfcAddress> Addresses { get; }

	IEnumerable<IIfcPersonAndOrganization> EngagedIn { get; }
}
