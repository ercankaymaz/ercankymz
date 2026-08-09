using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcOrganizationRelationship : IIfcResourceLevelRelationship, IPersistEntity, IPersist
{
	IIfcOrganization RelatingOrganization { get; set; }

	IItemSet<IIfcOrganization> RelatedOrganizations { get; }
}
