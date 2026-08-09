using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcActorRole : IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IfcRoleEnum Role { get; set; }

	IfcLabel? UserDefinedRole { get; set; }

	IfcText? Description { get; set; }

	IEnumerable<IIfcExternalReferenceRelationship> HasExternalReference { get; }

	string RoleString { get; }
}
