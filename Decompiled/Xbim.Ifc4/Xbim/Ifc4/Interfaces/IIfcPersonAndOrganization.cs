using Xbim.Common;
using Xbim.Ifc4.ActorResource;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcPersonAndOrganization : IPersistEntity, IPersist, IfcActorSelect, IIfcActorSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect
{
	IIfcPerson ThePerson { get; set; }

	IIfcOrganization TheOrganization { get; set; }

	IItemSet<IIfcActorRole> Roles { get; }
}
