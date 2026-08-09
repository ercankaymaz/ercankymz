using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcOwnerHistory : IPersistEntity, IPersist
{
	IIfcPersonAndOrganization OwningUser { get; set; }

	IIfcApplication OwningApplication { get; set; }

	IfcStateEnum? State { get; set; }

	IfcChangeActionEnum? ChangeAction { get; set; }

	IfcTimeStamp? LastModifiedDate { get; set; }

	IIfcPersonAndOrganization LastModifyingUser { get; set; }

	IIfcApplication LastModifyingApplication { get; set; }

	IfcTimeStamp CreationDate { get; set; }
}
